

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsUsuario
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDUsuario As Integer
		Protected m_strUsuario As String
		Protected m_strlogin As String
		Protected m_strSenha As String
        Protected m_blnAdministrador As Boolean
		Protected m_strUltimoAcesso As String
		Protected m_strCriado As String
		Protected m_strValidSenha As String
		Protected m_intIDVendedor As Integer
		Protected m_strVendedor As String
		Protected m_strSenhaAlterada As String
		Protected m_strObservacao As String
		Protected m_strEmail As String
		Protected m_strUltimaAtividade As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDUsuario As Integer
			Get
				Return m_intIDUsuario
			End Get
		End Property

		Public Overridable Property Usuario As String
			Get
				Return m_strUsuario
			End Get
			Set(ByVal Value As String)
				m_strUsuario = Value
			End Set
		End Property

		Public Overridable Property login As String
			Get
				Return m_strlogin
			End Get
			Set(ByVal Value As String)
				m_strlogin = Value
			End Set
		End Property

		Public Overridable Property Senha As String
			Get
				Return m_strSenha
			End Get
			Set(ByVal Value As String)
				m_strSenha = Value
			End Set
		End Property

        Public Overridable Property Administrador() As Boolean
            Get
                Return m_blnAdministrador
            End Get
            Set(ByVal Value As Boolean)
                m_blnAdministrador = Value
            End Set
        End Property

		Public Overridable ReadOnly Property UltimoAcesso As String
			Get
				Return _getDateTimePropertyValue(m_strUltimoAcesso)
			End Get
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable ReadOnly Property ValidSenha As String
			Get
				Return _getDateTimePropertyValue(m_strValidSenha)
			End Get
		End Property

		Public Overridable Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
			Set(ByVal Value As Integer)
				m_intIDVendedor = Value
			End Set
		End Property

		Public Overridable readonly Property Vendedor As String
			Get
				Return m_strVendedor
			End Get
		End Property

		Public Overridable ReadOnly Property SenhaAlterada As String
			Get
				Return _getDateTimePropertyValue(m_strSenhaAlterada)
			End Get
		End Property

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

		Public Overridable Property Email As String
			Get
				Return m_strEmail
			End Get
			Set(ByVal Value As String)
				m_strEmail = Value
			End Set
		End Property

		Public Overridable ReadOnly Property UltimaAtividade As String
			Get
				Return _getDateTimePropertyValue(m_strUltimaAtividade)
			End Get
		End Property


	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			try
				m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
				m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
				m_strlogin = dr.GetString(dr.GetOrdinal("login"))
				if dr.IsDBNull(dr.GetOrdinal("Senha")) Then 
					m_strSenha = ""
				else
					m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
                End If

                If dr.IsDBNull(dr.GetOrdinal("Administrador")) Then
                    m_blnAdministrador = False
                Else
                    m_blnAdministrador = (dr.GetByte(dr.GetOrdinal("Administrador")) > 0)
                End If
                If dr.IsDBNull(dr.GetOrdinal("UltimoAcesso")) Then
                    m_strUltimoAcesso = ""
                Else
                    m_strUltimoAcesso = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("UltimoAcesso")))
                End If
				m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
				if dr.IsDBNull(dr.GetOrdinal("ValidSenha")) Then 
					m_strValidSenha = ""
				else
					m_strValidSenha = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("ValidSenha")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("IDVendedor")) Then 
					m_intIDVendedor = 0
				else
					m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then 
					m_strVendedor = ""
				else
					m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("SenhaAlterada")) Then 
					m_strSenhaAlterada = ""
				else
					m_strSenhaAlterada = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("SenhaAlterada")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
					m_strObservacao = ""
				else
					m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Email")) Then 
					m_strEmail = ""
				else
					m_strEmail = dr.GetString(dr.GetOrdinal("Email"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("UltimaAtividade")) Then 
					m_strUltimaAtividade = ""
				else
					m_strUltimaAtividade = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("UltimaAtividade")))
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
                cmd.CommandText = PREFIXO & "SV_USUARIO"
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).value = m_strUsuario
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).value = m_strlogin
                cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).value = m_strSenha
                cmd.Parameters.Add("@ADMINISTRADOR", SqlDbType.TinyInt).Value = IIf(m_blnAdministrador, 1, 0)
                cmd.Parameters.Add("@OBSERVACAO", SqlDbType.Text, 2147483647).Value = m_strObservacao
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 256).value = m_strEmail
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
        ''' <param name="vIDUsuario">Chave primaria IDUsuario</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDUsuario As Integer) As Boolean
            Try
                If vIDUsuario = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_USUARIO"
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = vIDUsuario
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
            m_intIDUsuario = 0
            m_strUsuario = ""
            m_strlogin = ""
            m_strSenha = ""
            m_blnAdministrador = False
            m_strUltimoAcesso = ""
            m_strCriado = ""
            m_strValidSenha = ""
            m_intIDVendedor = 0
            m_strSenhaAlterada = ""
            m_strObservacao = ""
            m_strEmail = ""
            m_strUltimaAtividade = ""
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
                cmd.CommandText = PREFIXO & "DE_USUARIO"
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Usuario' the following row:  IDUsuario=" & m_intIDUsuario & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
            cmd.CommandText = PREFIXO & "LS_USUARIOS"
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
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_USUARIOS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
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
                        Dim ad As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
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

