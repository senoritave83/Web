
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsMensagemDia
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDMensagemDiaria As Integer
        Protected m_strMensagem As String
        Protected m_strDataInicio As String
        Protected m_strDataFim As String
        Protected m_strImagem As String
        Protected m_strIDCategoria As String
        Protected m_blnIsNew As Boolean = True
#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IDMensagemDiaria As Integer
            Get
                Return m_intIDMensagemDiaria
            End Get
        End Property

        Public Overridable Property Mensagem As String
            Get
                Return m_strMensagem
            End Get
            Set(ByVal Value As String)
                m_strMensagem = Value
            End Set
        End Property


        Public Overridable Property DataInicio As String
            Get
                Return _getDateTimePropertyValue(m_strDataInicio)
            End Get
            Set(ByVal Value As String)
                m_strDataInicio = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property DataFim As String
            Get
                Return _getDateTimePropertyValue(m_strDataFim)
            End Get
            Set(ByVal Value As String)
                m_strDataFim = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable ReadOnly Property IDCategoria As Integer
            Get
                Return m_strIDCategoria
            End Get
        End Property


        Public Overridable Property Imagem As String
            Get
                Return m_strImagem
            End Get
            Set(ByVal Value As String)
                m_strImagem = Value
            End Set
        End Property


        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDMensagemDiaria = dr.GetInt32(dr.GetOrdinal("IDMensagemDiaria"))
            m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
            m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
            m_strDataFim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataFim")))
            m_strImagem = dr.GetString(dr.GetOrdinal("Imagem"))
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_MENSAGEMDIARIA"
            cmd.Parameters.Add("@IDMENSAGEMDIARIA", SqlDbType.Int).Value = m_intIDMensagemDiaria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.VarChar, 255).Value = User.IDEmpresa
            cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 5000).Value = m_strMensagem
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.VarChar, 100).Value = m_strDataInicio
            cmd.Parameters.Add("@DATAFIM", SqlDbType.VarChar, 100).Value = m_strDataFim
            cmd.Parameters.Add("@IMAGEM", SqlDbType.VarChar, 500).Value = m_strImagem

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
        ''' <param name="vIDMensagemGeral">Chave primaria IDMensagemGeral</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal IDMensagemDiaria As Integer) As Boolean
            If IDMensagemDiaria = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_MENSAGEMDIARIA"
            cmd.Parameters.Add("@IDMENSAGEMDIARIA", SqlDbType.Int).Value = IDMensagemDiaria
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

            Return True

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDMensagemDiaria = 0
            m_strMensagem = ""
            m_strDataInicio = ""
            m_strDataFim = ""
            m_strImagem = ""
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_MENSAGEMDIARIA"
            cmd.Parameters.Add("@@IDMENSAGEMDIARIA", SqlDbType.Int).Value = m_intIDMensagemDiaria

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MensagemGeral' the following row:  IDMensagemGeral=" & m_intIDMensagemDiaria & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal IDMensagemDiaria As Integer) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_MENSAGENSDIARIAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDMENSAGEMDIARIA", SqlDbType.Int).Value = m_intIDMensagemDiaria
            Dim dr As IDataReader = ExecuteReader(cmd)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_MENSAGENSDIARIAS"
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace