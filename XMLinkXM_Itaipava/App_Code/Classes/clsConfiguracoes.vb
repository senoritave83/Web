Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsConfiguracoes
        Inherits BaseClass

#Region "Declarations"
        Dim m_intIdEmpresa As Integer
        Dim m_blnAceitaSomenteCondicoesCadastradas As Boolean
        Dim m_blnAguardaAprovacaoCondicaoCliente As Boolean
        Dim m_blnAguardaAprovacaoClienteDuplicataVencida As Boolean
        Dim m_blnPermiteAcumuloRoteiros As Boolean
        Dim m_blnAguardaAprovacaoPedidosBonificados As Boolean
#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IdEmpresa() As Integer
            Get
                Return m_intIdEmpresa
            End Get
        End Property

        Public Overridable Property AceitaSomenteCondicoesCadastradas() As Boolean
            Get
                Return m_blnAceitaSomenteCondicoesCadastradas
            End Get
            Set(ByVal Value As Boolean)
                m_blnAceitaSomenteCondicoesCadastradas = Value
            End Set
        End Property

        Public Overridable Property AguardaAprovacaoCondicaoCliente As Boolean
            Get
                Return m_blnAguardaAprovacaoCondicaoCliente
            End Get
            Set(ByVal Value As Boolean)
                m_blnAguardaAprovacaoCondicaoCliente = Value
            End Set
        End Property

        Public Overridable Property AguardaAprovacaoClienteDuplicataVencida As Boolean
            Get
                Return m_blnAguardaAprovacaoClienteDuplicataVencida
            End Get
            Set(ByVal Value As Boolean)
                m_blnAguardaAprovacaoClienteDuplicataVencida = Value
            End Set
        End Property


        Public Overridable Property AguardaAprovacaoPedidosBonificados As Boolean
            Get
                Return m_blnAguardaAprovacaoPedidosBonificados
            End Get
            Set(ByVal Value As Boolean)
                m_blnAguardaAprovacaoPedidosBonificados = Value
            End Set
        End Property

        Public Overridable Property RevendaPermiteAcumuloRoteiros As Boolean
            Get
                Return m_blnPermiteAcumuloRoteiros
            End Get
            Set(ByVal Value As Boolean)
                m_blnPermiteAcumuloRoteiros = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIdEmpresa = dr.GetInt32(dr.GetOrdinal("IDEmpresa"))
            m_blnAceitaSomenteCondicoesCadastradas = IIf(dr.GetByte(dr.GetOrdinal("AceitaSomenteCondicoesCadastradas")) = 1, True, False)
            m_blnAguardaAprovacaoCondicaoCliente = IIf(dr.GetByte(dr.GetOrdinal("AguardaAprovacaoCondicaoCliente")) = 1, True, False)
            m_blnAguardaAprovacaoClienteDuplicataVencida = IIf(dr.GetByte(dr.GetOrdinal("AguardaAprovacaoClienteDuplicataVencida")) = 1, True, False)
            m_blnPermiteAcumuloRoteiros = IIf(dr.GetByte(dr.GetOrdinal("PermiteAcumuloRoteiros")) = 1, True, False)
            m_blnAguardaAprovacaoPedidosBonificados = IIf(dr.GetByte(dr.GetOrdinal("AguardaAprovacaoPedidosBonificados")) = 1, True, False)
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CONFIGURACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ACEITASOMENTECONDICOESCADASTRADAS", SqlDbType.TinyInt).Value = IIf(m_blnAceitaSomenteCondicoesCadastradas, 1, 0)
            cmd.Parameters.Add("@AGUARDAAPROVACAOCONDICAOCLIENTE", SqlDbType.TinyInt).Value = IIf(m_blnAguardaAprovacaoCondicaoCliente, 1, 0)
            cmd.Parameters.Add("@AGUARDAAPROVACAOCLIENTEDUPLICATAVENCIDA", SqlDbType.TinyInt).Value = IIf(m_blnAguardaAprovacaoClienteDuplicataVencida, 1, 0)
            cmd.Parameters.Add("@PERMITEACUMULOROTEIROS", SqlDbType.TinyInt).Value = IIf(m_blnPermiteAcumuloRoteiros, 1, 0)
            cmd.Parameters.Add("@AGUARDAAPROVACAOPEDIDOSBONIFICADOS", SqlDbType.TinyInt).Value = IIf(m_blnAguardaAprovacaoPedidosBonificados, 1, 0)
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDEmpresa">Chave primaria IDBloqueio</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDEmpresa As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDEmpresa = 0 Then vIDEmpresa = User.IDEmpresa
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CONFIGURACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    blnReturn = True
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
            Return blnReturn
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnAceitaSomenteCondicoesCadastradas = False
            m_blnAguardaAprovacaoCondicaoCliente = False
            m_blnAguardaAprovacaoClienteDuplicataVencida = False
            m_blnPermiteAcumuloRoteiros = False
            m_blnAguardaAprovacaoPedidosBonificados = False
        End Sub

#End Region

    End Class

End Namespace

