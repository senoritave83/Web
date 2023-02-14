
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsMensagemGeral
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDMensagemGeral As Integer
        Protected m_strTitulo As String
        Protected m_strMensagem As String
        Protected m_strData As String
        Protected m_strRemetente As String
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDMensagemGeral As Integer
            Get
                Return m_intIDMensagemGeral
            End Get
        End Property

        Public Overridable Property Titulo As String
            Get
                Return m_strTitulo
            End Get
            Set(ByVal Value As String)
                m_strTitulo = Value
            End Set
        End Property

        Public Overridable Property Mensagem As String
            Get
                Return m_strMensagem
            End Get
            Set(ByVal Value As String)
                m_strMensagem = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Data As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable ReadOnly Property Remetente As String
            Get
                Return m_strRemetente
            End Get
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
            m_intIDMensagemGeral = dr.GetInt32(dr.GetOrdinal("IDMensagemGeral"))
            m_strTitulo = dr.GetString(dr.GetOrdinal("Titulo"))
            m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            m_strRemetente = dr.GetString(dr.GetOrdinal("Remetente"))
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_MENSAGEMGERAL"
            cmd.Parameters.Add("@IDMENSAGEMGERAL", SqlDbType.Int).value = m_intIDMensagemGeral
            cmd.Parameters.Add("@TITULO", SqlDbType.VarChar, 255).value = m_strTitulo
            cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 5000).value = m_strMensagem
            cmd.Parameters.Add("@REMETENTE", SqlDbType.VarChar, 100).Value = User.Name
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
        Public Function Load(ByVal vIDMensagemGeral As Integer) As Boolean
            If vIDMensagemGeral = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_MENSAGEMGERAL"
            cmd.Parameters.Add("@IDMENSAGEMGERAL", SqlDbType.Int).value = vIDMensagemGeral
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
            m_intIDMensagemGeral = 0
            m_strTitulo = ""
            m_strMensagem = ""
            m_strData = ""
            m_strRemetente = ""
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_MENSAGEMGERAL"
            cmd.Parameters.Add("@IDMENSAGEMGERAL", SqlDbType.Int).value = m_intIDMensagemGeral

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MensagemGeral' the following row:  IDMensagemGeral=" & m_intIDMensagemGeral & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_MENSAGEMGERAIS"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)

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
            cmd.CommandText = PREFIXO & "NV_MENSAGEMGERAIS"
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace