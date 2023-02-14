

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsUsuario
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDUsuario As Integer
		Protected m_strUsuario As String
		Protected m_strlogin As String
		Protected m_strSenha As String
        Protected m_blnAdministrador As Boolean
		Protected m_strCriado As String
		Protected m_strObservacao As String
		Protected m_strEmail As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable Property IDUsuario As Integer
			Get
				Return m_intIDUsuario
			End Get
			Set(ByVal Value As Integer)
				m_intIDUsuario = Value
			End Set
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

        Public ReadOnly Property Administrador() As Boolean
            Get
                Return m_blnAdministrador
            End Get
        End Property



		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
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




		Public readonly property IsNew() as Boolean
			Get
				return m_blnIsNew
			End Get
		end Property
		
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
			m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
			m_strlogin = dr.GetString(dr.GetOrdinal("login"))
			if dr.IsDBNull(dr.GetOrdinal("Senha")) Then 
				m_strSenha = ""
			else
				m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
			end if
            m_blnAdministrador = (dr.GetByte(dr.GetOrdinal("Administrador")) = 1)
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
                m_strObservacao = ""
            Else
                m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            End If
			if dr.IsDBNull(dr.GetOrdinal("Email")) Then 
				m_strEmail = ""
			else
				m_strEmail = dr.GetString(dr.GetOrdinal("Email"))
			end if
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_USUARIO"
			cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).value = m_strUsuario
			cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).value = m_strlogin
			cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).value = m_strSenha
            cmd.Parameters.Add("@OBSERVACAO", SqlDbType.Text, 2147483647).Value = m_strObservacao
			cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 256).value = m_strEmail
			Dim dr As IDataReader = ExecuteReader(cmd)
			try
				If dr.Read Then
					Inflate(dr)
				Else
					Clear()
				End If
			finally
				If (Not dr Is Nothing) Then
					dr.Close()
					dr = Nothing
				End If
			end try
		End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDUsuario">Chave primaria IDUsuario</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDUsuario As Integer) As Boolean
            If vIDUsuario = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_USUARIO"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = vIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            m_strCriado = ""
			m_strObservacao = ""
			m_strEmail = ""
			m_blnIsNew = true 
		End Sub


        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_USUARIO"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Usuario' the following row:  IDUsuario=" & m_intIDUsuario & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub



        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_USUARIOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            cmd.CommandText = PREFIXO & "NV_USUARIOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        Public Function LoginExiste(ByVal vIDUsuario As Integer, ByVal vLogin As String, ByVal vSenha As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_USUARIO_LOGIN_EXISTENTE"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).Value = vLogin
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = vSenha

            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If LoginExiste(m_intIDUsuario, m_strlogin, m_strSenha) Then
                blnValid = False
                AddBrokenRule("Login já existe!")
            ElseIf VerificaSenha(m_strSenha) = False Then
                blnValid = False
                AddBrokenRule("Senha inválida!")
            End If
            Return blnValid
        End Function


        Protected Function VerificaSenha(ByVal newPassword As String) As Boolean

            Dim mb As Membership = Nothing
            Dim blnValid As Boolean = True
            If (newPassword.Length < Membership.MinRequiredPasswordLength) Then
                AddBrokenRule("A senha precisa de no mínimo " & Membership.MinRequiredPasswordLength & " caracteres.")
                blnValid = False
            End If
            Dim i As Integer, num As Integer = 0
            For i = 0 To newPassword.Length - 1
                If Not Char.IsLetterOrDigit(newPassword, i) Then
                    num += 1
                End If
            Next i
            If (num < Membership.MinRequiredNonAlphanumericCharacters) Then
                AddBrokenRule("A senha precisa de " & Membership.MinRequiredNonAlphanumericCharacters & " caracteres especiais")
                blnValid = False
            End If
            If Not Membership.PasswordStrengthRegularExpression Is Nothing Then
                If ((Membership.PasswordStrengthRegularExpression.Length > 0) AndAlso Not Regex.IsMatch(newPassword, Membership.PasswordStrengthRegularExpression)) Then
                    AddBrokenRule("A senha precisa ser mais complexa.")
                    blnValid = False
                End If
            End If

            Return blnValid
        End Function

	#End Region

	End Class
End Namespace

