

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsMensagemDia
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDMensagemDia As Integer
		Protected m_strMensagem As String
		Protected m_strDataInicio As String
		Protected m_strDataDim As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDMensagemDia As Integer
			Get
				Return m_intIDMensagemDia
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
                Return _getDatePropertyValue(m_strDataInicio)
			End Get
			Set(ByVal Value As String)
				m_strDataInicio = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property DataDim As String
			Get
                Return _getDatePropertyValue(m_strDataDim)
			End Get
			Set(ByVal Value As String)
				m_strDataDim = _setDateTimePropertyValue(Value)
			End Set
		End Property


	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			try
				m_intIDMensagemDia = dr.GetInt32(dr.GetOrdinal("IDMensagemDia"))
				if dr.IsDBNull(dr.GetOrdinal("Mensagem")) Then 
					m_strMensagem = ""
				else
					m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("DataInicio")) Then 
					m_strDataInicio = ""
				else
					m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("DataDim")) Then 
					m_strDataDim = ""
				else
                    m_strDataDim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataDim")))
				end if

			Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_MENSAGEMDIA"
                cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = m_intIDMensagemDia
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 255).value = m_strMensagem
                If m_strDataInicio <> "" Then
                    cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strDataInicio)
                End If
                If m_strDataDim <> "" Then
                    cmd.Parameters.Add("@DATADIM", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strDataDim)
                End If
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDMensagemDia">Chave primaria IDMensagemDia</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDMensagemDia As Integer) As Boolean
            Try
                If vIDMensagemDia = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_MENSAGEMDIA"
                cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = vIDMensagemDia
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDMensagemDia = 0
            m_strMensagem = ""
            m_strDataInicio = ""
            m_strDataDim = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_MENSAGEMDIA"
                cmd.Parameters.Add("@IDMENSAGEMDIA", SqlDbType.Int).value = m_intIDMensagemDia
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MensagemDia' the following row:  IDMensagemDia=" & m_intIDMensagemDia & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
                Clear()
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_MENSAGEMDIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

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
            Dim ret As New PaginateResult
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_MENSAGEMDIAS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize
                cn.Open()

                If vReturnType = enReturnType.DataReader Then
                    Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.Read Then
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = dr.GetInt32(0)
                        If dr.NextResult Then
                            ret.Data = dr
                        End If
                    End If
                Else
                    Try
                        Dim ad As New SQLDataAdapter(cmd)
                        Dim ds As New dataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.tables(0).rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return ret
        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnValid
        End Function

	#End Region



	End Class
End Namespace

