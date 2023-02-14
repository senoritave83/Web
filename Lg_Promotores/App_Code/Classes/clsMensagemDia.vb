

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsMensagemDia
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDMensagemDia As Integer
        Protected m_strMensagem As String
        Protected m_strDataInicio As String
        Protected m_strDataDim As String
        Protected m_intIDCategoria As Integer

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDMensagemDia() As Integer
            Get
                Return m_intIDMensagemDia
            End Get
        End Property

        Public Overridable Property Mensagem() As String
            Get
                Return m_strMensagem
            End Get
            Set(ByVal Value As String)
                m_strMensagem = Value
            End Set
        End Property

        Public Overridable Property DataInicio() As String
            Get
                Return _getDatePropertyValue(m_strDataInicio)
            End Get
            Set(ByVal Value As String)
                m_strDataInicio = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property DataDim() As String
            Get
                Return _getDatePropertyValue(m_strDataDim)
            End Get
            Set(ByVal Value As String)
                m_strDataDim = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property IDCategoria() As Integer
            Get
                Return m_intIDCategoria
            End Get
            Set(ByVal Value As Integer)
                m_intIDCategoria = Value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDMensagemDia = 0
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDMensagemDia = dr.GetInt32(dr.GetOrdinal("IDMensagemDia"))
            If dr.IsDBNull(dr.GetOrdinal("Mensagem")) Then
                m_strMensagem = ""
            Else
                m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataInicio")) Then
                m_strDataInicio = ""
            Else
                m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataDim")) Then
                m_strDataDim = ""
            Else
                m_strDataDim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataDim")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then
                m_intIDCategoria = 0
            Else
                m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
            End If


        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_MENSAGEMDIA"
            cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).Value = m_intIDMensagemDia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 255).Value = m_strMensagem
            If m_strDataInicio <> "" Then
                cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataInicio)
            End If
            If m_strDataDim <> "" Then
                cmd.Parameters.Add("@DATADIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataDim)
            End If
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
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

            Me.User.Log("Cadastro de Mensagens", "Gravar - IDMENSAGEMDIA=" & m_intIDMensagemDia & " MENSAGEM=" & m_strMensagem & " DATAINICIO=" & m_strDataInicio & _
                        " DATADIM=" & m_strDataDim & " IDCATEGORIA=" & m_intIDCategoria)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDMensagemDia">Chave primaria IDMensagemDia</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDMensagemDia As Integer) As Boolean


            If vIDMensagemDia = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_MENSAGEMDIA"
            cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).Value = vIDMensagemDia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

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

            Me.User.Log("Cadastro de Mensagens", "Visualizar - IDMENSAGEMDIA=" & vIDMensagemDia)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDMensagemDia = 0
            m_strMensagem = ""
            m_strDataInicio = ""
            m_strDataDim = ""
            m_intIDCategoria = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_MENSAGEMDIA"
            cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).Value = m_intIDMensagemDia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Mensagens", "Apagar - IDMENSAGEMDIA=" & m_intIDMensagemDia)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MensagemDia' the following row:  IDMensagemDia=" & m_intIDMensagemDia & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_MENSAGEMDIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vPeriodoInicial">Filtro</param>
        ''' <param name="vPeriodoFinal">Filtro</param>
        ''' <param name="vIDCategoria">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vPeriodoInicial As String, ByVal vPeriodoFinal As String, ByVal vIDCategoria As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_MENSAGEMDIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            If vPeriodoInicial <> "" Then
                cmd.Parameters.Add("@PERIODOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vPeriodoInicial)
            End If
            If vPeriodoFinal <> "" Then
                cmd.Parameters.Add("@PERIODOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vPeriodoFinal)
            End If
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
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



