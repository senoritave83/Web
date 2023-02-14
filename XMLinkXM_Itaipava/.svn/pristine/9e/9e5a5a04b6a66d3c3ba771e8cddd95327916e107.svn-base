
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsEmpresa
        Inherits BaseClass

#Region "Declarations"
        Protected m_strEmpresa As String
        Protected m_sngLatitude As Single
        Protected m_sngLongitude As Single
        Protected m_blnPermiteBonificacao As Boolean
        Protected m_blnPermitePrecoLivre As Boolean
        Protected m_intTransacaoVenda As Integer
        Protected m_intTransacaoBonificacao As Integer
        Protected m_blnPermiteForaRota As Boolean
        Protected m_blnLimiteCreditoCliente As Boolean
#End Region

#Region "Properties"

        Public ReadOnly Property Empresa As String
            Get
                Return m_strEmpresa
            End Get
        End Property

        Public Property TransacaoBonificacao As Integer
            Get
                Return m_intTransacaoBonificacao
            End Get
            Set(ByVal Value As Integer)
                m_intTransacaoBonificacao = Value
            End Set
        End Property

        Public Property TransacaoVenda As Integer
            Get
                Return m_intTransacaoVenda
            End Get
            Set(ByVal Value As Integer)
                m_intTransacaoVenda = Value
            End Set
        End Property

        Public Overridable Property Latitude As Single
            Get
                Return m_sngLatitude
            End Get
            Set(ByVal Value As Single)
                m_sngLatitude = Value
            End Set
        End Property

        Public Overridable Property Longitude As Single
            Get
                Return m_sngLongitude
            End Get
            Set(ByVal Value As Single)
                m_sngLongitude = Value
            End Set
        End Property

        Public Overridable Property PermiteBonificacao As Boolean
            Get
                Return m_blnPermiteBonificacao
            End Get
            Set(ByVal Value As Boolean)
                m_blnPermiteBonificacao = Value
            End Set
        End Property

        Public Overridable Property PermitePrecoLivre As Boolean
            Get
                Return m_blnPermitePrecoLivre
            End Get
            Set(ByVal Value As Boolean)
                m_blnPermitePrecoLivre = Value
            End Set
        End Property

        Public Overridable Property PermiteForaRota As Boolean
            Get
                Return m_blnPermiteForaRota
            End Get
            Set(ByVal Value As Boolean)
                m_blnPermiteForaRota = Value
            End Set
        End Property

        Public Overridable Property AplicaLimiteCreditoCliente As Boolean
            Get
                Return m_blnLimiteCreditoCliente
            End Get
            Set(ByVal Value As Boolean)
                m_blnLimiteCreditoCliente = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_EMPRESAS"
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vFilter As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_EMPRESAS"
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function ListarAutorizadas() As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_EMPRESAS_AUTORIZADAS"
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            Return ExecuteReader(cmd)
        End Function

        Public Function ListarAutorizadas(ByVal vIdRegional As Integer) As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_EMPRESAS_AUTORIZADAS"
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
            Return ExecuteReader(cmd)
        End Function

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            If dr.IsDBNull(dr.GetOrdinal("Empresa")) Then
                m_strEmpresa = ""
            Else
                m_strEmpresa = dr.GetString(dr.GetOrdinal("Empresa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Latitude")) Then
                m_sngLatitude = 0
            Else
                m_sngLatitude = dr.GetFloat(dr.GetOrdinal("Latitude"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Longitude")) Then
                m_sngLongitude = 0
            Else
                m_sngLongitude = dr.GetFloat(dr.GetOrdinal("Longitude"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PermiteBonificacao")) Then
                m_blnPermiteBonificacao = Nothing
            Else
                m_blnPermiteBonificacao = dr.GetBoolean(dr.GetOrdinal("PermiteBonificacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PermitePrecoLivre")) Then
                m_blnPermitePrecoLivre = Nothing
            Else
                m_blnPermitePrecoLivre = dr.GetBoolean(dr.GetOrdinal("PermitePrecoLivre"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TransacaoVenda")) Then
                m_intTransacaoVenda = 0
            Else
                m_intTransacaoVenda = dr.GetInt32(dr.GetOrdinal("TransacaoVenda"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TransacaoBonificacao")) Then
                m_intTransacaoBonificacao = 0
            Else
                m_intTransacaoBonificacao = dr.GetInt32(dr.GetOrdinal("TransacaoBonificacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PermiteForaRota")) Then
                m_blnPermiteForaRota = False
            Else
                m_blnPermiteForaRota = dr.GetBoolean(dr.GetOrdinal("PermiteForaRota"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LimiteCreditoCliente")) Then
                m_blnLimiteCreditoCliente = False
            Else
                m_blnLimiteCreditoCliente = dr.GetBoolean(dr.GetOrdinal("LimiteCreditoCliente"))
            End If

        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_EMPRESA"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LATITUDE", SqlDbType.Real).Value = m_sngLatitude
            cmd.Parameters.Add("@LONGITUDE", SqlDbType.Real).value = m_sngLongitude
            cmd.Parameters.Add("@PERMITEBONIFICACAO", SqlDbType.Bit).value = m_blnPermiteBonificacao
            cmd.Parameters.Add("@PERMITEPRECOLIVRE", SqlDbType.Bit).Value = m_blnPermitePrecoLivre
            cmd.Parameters.Add("@TRANSACAOVENDA", SqlDbType.Int).Value = m_intTransacaoVenda
            cmd.Parameters.Add("@TRANSACAOBONIFICACAO", SqlDbType.Int).Value = m_intTransacaoBonificacao
            cmd.Parameters.Add("@PERMITEFORAROTA", SqlDbType.Bit).Value = m_blnPermiteForaRota
            cmd.Parameters.Add("@APLICA_LIMITECREDITOCLIENTE", SqlDbType.Bit).Value = m_blnLimiteCreditoCliente

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
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_sngLatitude = 0
            m_sngLongitude = 0
            m_blnPermiteBonificacao = False
            m_blnPermitePrecoLivre = False
            m_intTransacaoBonificacao = 0
            m_intTransacaoVenda = 0
            m_blnPermiteForaRota = False
            m_blnLimiteCreditoCliente = False
        End Sub

        Public Sub New()
            Load(User.IDEmpresa)
        End Sub

        Public Sub New(ByVal vIDEmpresa As Integer)
            Load(vIDEmpresa)
        End Sub

        Protected Sub Load(ByVal vIDEmpresa As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_EMPRESA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
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

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid
        End Function

#End Region

    End Class
End Namespace