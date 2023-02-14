

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsUsuario
		Inherits BaseClass

	#Region "Declarations" 
        Protected m_intIDUsuario As Integer
		Protected m_strUsuario As String
		Protected m_strlogin As String
		Protected m_strSenha As String
		Protected m_indAdministrador As Byte
		Protected m_strUltimoAcesso As String
		Protected m_strSenhaAlterada As String
		Protected m_strUltimaAtividade As String
		Protected m_strCriado As String
		Protected m_strEmail As String
		Protected m_strObservacao As String
        Protected m_strValidSenha As String
        Protected m_intIdCoordenador As Integer
        Protected m_intIdLider As Integer

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

		Public Overridable Property Administrador As Byte
			Get
				Return m_indAdministrador
			End Get
			Set(ByVal Value As Byte)
				m_indAdministrador = Value
			End Set
		End Property

		Public Overridable Property UltimoAcesso As String
			Get
				Return _getDateTimePropertyValue(m_strUltimoAcesso)
			End Get
			Set(ByVal Value As String)
				m_strUltimoAcesso = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property SenhaAlterada As String
			Get
				Return _getDateTimePropertyValue(m_strSenhaAlterada)
			End Get
			Set(ByVal Value As String)
				m_strSenhaAlterada = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property UltimaAtividade As String
			Get
				Return _getDateTimePropertyValue(m_strUltimaAtividade)
			End Get
			Set(ByVal Value As String)
				m_strUltimaAtividade = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property Email As String
			Get
				Return m_strEmail
			End Get
			Set(ByVal Value As String)
				m_strEmail = Value
			End Set
		End Property

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

		Public Overridable Property ValidSenha As String
			Get
				Return _getDateTimePropertyValue(m_strValidSenha)
			End Get
			Set(ByVal Value As String)
				m_strValidSenha = _setDateTimePropertyValue(Value)
			End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDUsuario = 0
            End Get
        End Property

        Public Overridable ReadOnly Property IdCoordenador() As Integer
            Get
                Return m_intIdCoordenador
            End Get
        End Property

        Public Overridable ReadOnly Property IdLider() As Integer
            Get
                Return m_intIdLider
            End Get
        End Property

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
            If dr.IsDBNull(dr.GetOrdinal("Senha")) Then
                m_strSenha = ""
            Else
                m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
            End If
            m_indAdministrador = dr.GetByte(dr.GetOrdinal("Administrador"))
            If dr.IsDBNull(dr.GetOrdinal("UltimoAcesso")) Then
                m_strUltimoAcesso = ""
            Else
                m_strUltimoAcesso = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("UltimoAcesso")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("SenhaAlterada")) Then
                m_strSenhaAlterada = ""
            Else
                m_strSenhaAlterada = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("SenhaAlterada")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("UltimaAtividade")) Then
                m_strUltimaAtividade = ""
            Else
                m_strUltimaAtividade = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("UltimaAtividade")))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("Email")) Then
                m_strEmail = ""
            Else
                m_strEmail = dr.GetString(dr.GetOrdinal("Email"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Observacao")) Then
                m_strObservacao = ""
            Else
                m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("ValidSenha")) Then
                m_strValidSenha = ""
            Else
                m_strValidSenha = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("ValidSenha")))
            End If

            '********************************************
            'SE O USUÁRIO FOR UM LÍDER OU COORDENADOR
            '********************************************
            m_intIdCoordenador = dr.GetInt32(dr.GetOrdinal("IDCoordenador"))
            m_intIdLider = dr.GetInt32(dr.GetOrdinal("IDLider"))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_USUARIO"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).Value = m_strUsuario
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).Value = m_strlogin
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = m_strSenha
            cmd.Parameters.Add("@ADMINISTRADOR", SqlDbType.TinyInt).Value = m_indAdministrador
            If m_strUltimoAcesso <> "" Then
                cmd.Parameters.Add("@ULTIMOACESSO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strUltimoAcesso)
            End If
            If m_strSenhaAlterada <> "" Then
                cmd.Parameters.Add("@SENHAALTERADA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strSenhaAlterada)
            End If
            If m_strUltimaAtividade <> "" Then
                cmd.Parameters.Add("@ULTIMAATIVIDADE", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strUltimaAtividade)
            End If
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 256).Value = m_strEmail
            cmd.Parameters.Add("@OBSERVACAO", SqlDbType.Text, 2147483647).Value = m_strObservacao
            If m_strValidSenha <> "" Then
                cmd.Parameters.Add("@VALIDSENHA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strValidSenha)
            End If

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

            Me.User.Log("Usuarios do Sistema", "Gravar - USUARIO=" & m_strUsuario & " LOGIN=" & m_strlogin & " SENHA=" & m_strSenha & " ADMINISTRADOR=" & m_indAdministrador & _
                        " ULTIMOACESSO=" & m_strUltimoAcesso & " SENHAALTERADA=" & m_strSenhaAlterada & " ULTIMAATIVIDADE=" & m_strUltimaAtividade & " EMAIL=" & m_strEmail & _
                        " OBSERVACAO=" & m_strObservacao & " VALIDSENHA=" & m_strValidSenha)

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
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
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

            Me.User.Log("Usuarios do Sistema", "Visualizar - IDUSUARIO=" & vIDUsuario)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDUsuario = 0
            m_strUsuario = ""
            m_strlogin = ""
            m_strSenha = ""
            m_indAdministrador = 0
            m_strUltimoAcesso = ""
            m_strSenhaAlterada = ""
            m_strUltimaAtividade = ""
            m_strCriado = ""
            m_strEmail = ""
            m_strObservacao = ""
            m_strValidSenha = ""
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

            Me.User.Log("Usuarios do Sistema", "Apagar - IDUSUARIO=" & m_intIDUsuario)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Usuario' the following row:  IDUsuario=" & m_intIDUsuario & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

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
            cmd.CommandText = PREFIXO & "LS_USUARIOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIdTipo">Tipo de Permissão que o usuário tem - 1 COORDENADOR 2 - LÍDER</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>

        Public Function Listar(ByVal vIdTipo As XMWebPage.TipoPermissao, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_USUARIOS_MODULOACESSO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TIPOPERMISSAO", SqlDbType.Int, 0).Value = vIdTipo

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
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

        ''' <summary>
        ''' 	Sub que solicita a alteração de senha
        ''' </summary>
        ''' <param name="p_Senha">Nova Senha</param>		
        Public Sub AlterarSenha(ByVal p_Senha As String, ByVal p_ValidaAte As String)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_USUARIO_ALTERARSENHA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUsuario
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = p_Senha
            If IsDate(p_ValidaAte) Then
                cmd.Parameters.Add("@VALIDSENHA", SqlDbType.DateTime).Value = _setDateTimeDBValue(p_ValidaAte)
            End If

            ExecuteNonQuery(cmd)

            Me.User.Log("Usuarios do Sistema", "AlterarSenha - SENHA=" & p_Senha & " VALIDSENHA=" & p_ValidaAte)

        End Sub

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo login informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDUsuario">Chave primaria IDUsuario do registro atual.</param>
        ''' <param name="vLogin">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDUsuario As Integer, ByVal vLogin As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOGIN_EXISTENTE"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25).Value = vLogin
            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            If m_strlogin = "" Then
                AddBrokenRule("O login é obrigatório!")
                blnValid = False
            ElseIf Existe(m_intIDUsuario, m_strlogin) Then
                AddBrokenRule("O login informado já existe!")
                blnValid = False
            End If

            Return blnValid
        End Function

        Public Sub GravarPermissoes(ByVal vPermissoes() As String)
            LimparPermissoes()

            Dim cmd As New SqlCommand()
            Dim cn As SqlConnection = GetDBConnection()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PERMISSAO_USUARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUsuario
            Dim prm As SqlParameter = cmd.Parameters.Add("@PERMISSAO", SqlDbType.VarChar)

            For Each strItem As String In vPermissoes
                prm.Value = strItem
                cmd.ExecuteNonQuery()
            Next
            cn.Close()

            Me.User.Log("Usuarios do Sistema", "GravarPermissoes - IDUSUARIO=" & m_intIDUsuario & " PERMISSAO=" & prm.Value)

        End Sub


        Protected Sub LimparPermissoes()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERMISSOES_USUARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUsuario
            MyBase.ExecuteNonQuery(cmd)

            Me.User.Log("Usuarios do Sistema", "LimparPermissoes - IDUSUARIO=" & m_intIDUsuario)

        End Sub



#End Region



    End Class
End Namespace

