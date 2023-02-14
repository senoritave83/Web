

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Collections.Generic

Namespace Classes

	Public Class clsUsuario
        Inherits BaseClass


#Region "Declarations"
        Protected m_intIDUsuario As Integer
        Protected m_strCodigo As String
        Protected m_strUsuario As String
        Protected m_strCPF As String
        Protected m_strlogin As String
        Protected m_strSenha As String
        Protected m_intIDCargo As Integer
        Protected m_intIDSuperior As Integer
        Protected m_indAdministrador As Byte
        Protected m_strUltimoAcesso As String
        Protected m_strSenhaAlterada As String
        Protected m_strUltimaAtividade As String
        Protected m_strCriado As String
        Protected m_strEmail As String
        Protected m_strObservacao As String
        Protected m_strValidSenha As String
        Protected m_strEndereco As String
        Protected m_strNumero As String
        Protected m_strComplemento As String
        Protected m_strBairro As String
        Protected m_strCep As String
        Protected m_strCidade As String
        Protected m_strUF As String
        Protected m_strContato As String
        Protected m_strTelefone As String
        Protected m_strCelular As String
        Protected m_strFax As String
        Protected m_indTeste As Byte
        Protected m_strGuid As String
        Protected m_strFoto As String
        Protected m_objPermissoes As clsPermissaoUsuario
        Protected m_intIDStatus As Integer
        Protected m_indAdicionarLoja As Byte
        Protected m_indAtivo As Byte
        Protected m_blnIsNew As Boolean = True

        Public Enum enOpcaoTeste As Byte
            Todos = 2
            Teste = 1
            Normal = 0
        End Enum

        Public Enum enOpcaoStatus As Byte
            Inativos = 1
            Ativos = 2
            Afastados = 4
            Todos = 8
        End Enum

#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IDUsuario() As Integer
            Get
                Return m_intIDUsuario
            End Get
        End Property

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property Usuario() As String
            Get
                Return m_strUsuario
            End Get
            Set(ByVal Value As String)
                m_strUsuario = Value
            End Set
        End Property

        Public Overridable Property CPF() As String
            Get
                Return m_strCPF
            End Get
            Set(ByVal Value As String)
                m_strCPF = Value
            End Set
        End Property

        Public Overridable Property login() As String
            Get
                Return m_strlogin
            End Get
            Set(ByVal Value As String)
                m_strlogin = Value
            End Set
        End Property

        Public Overridable Property Senha() As String
            Get
                Return m_strSenha
            End Get
            Set(ByVal Value As String)
                m_strSenha = Value
            End Set
        End Property

        Public Overridable Property IDCargo() As Integer
            Get
                Return m_intIDCargo
            End Get
            Set(ByVal Value As Integer)
                m_intIDCargo = Value
            End Set
        End Property

        Public Overridable Property IDSuperior() As Integer
            Get
                Return m_intIDSuperior
            End Get
            Set(ByVal Value As Integer)
                m_intIDSuperior = Value
            End Set
        End Property

        Public Overridable Property Administrador() As Byte
            Get
                Return m_indAdministrador
            End Get
            Set(ByVal Value As Byte)
                m_indAdministrador = Value
            End Set
        End Property

        Public Overridable ReadOnly Property UltimoAcesso() As String
            Get
                Return _getDateTimePropertyValue(m_strUltimoAcesso)
            End Get
        End Property

        Public Overridable ReadOnly Property SenhaAlterada() As String
            Get
                Return _getDateTimePropertyValue(m_strSenhaAlterada)
            End Get
        End Property

        Public Overridable ReadOnly Property UltimaAtividade() As String
            Get
                Return _getDateTimePropertyValue(m_strUltimaAtividade)
            End Get
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public ReadOnly Property Ativo() As Byte
            Get
                Return m_indAtivo
            End Get
        End Property

        Public Overridable Property Email() As String
            Get
                Return m_strEmail
            End Get
            Set(ByVal Value As String)
                m_strEmail = Value
            End Set
        End Property

        Public Overridable Property Observacao() As String
            Get
                Return m_strObservacao
            End Get
            Set(ByVal Value As String)
                m_strObservacao = Value
            End Set
        End Property

        Public Overridable ReadOnly Property ValidSenha() As String
            Get
                Return _getDateTimePropertyValue(m_strValidSenha)
            End Get
        End Property

        Public Overridable Property Endereco() As String
            Get
                Return m_strEndereco
            End Get
            Set(ByVal Value As String)
                m_strEndereco = Value
            End Set
        End Property

        Public Overridable Property Numero() As String
            Get
                Return m_strNumero
            End Get
            Set(ByVal Value As String)
                m_strNumero = Value
            End Set
        End Property

        Public Overridable Property Complemento() As String
            Get
                Return m_strComplemento
            End Get
            Set(ByVal Value As String)
                m_strComplemento = Value
            End Set
        End Property

        Public Overridable Property Bairro() As String
            Get
                Return m_strBairro
            End Get
            Set(ByVal Value As String)
                m_strBairro = Value
            End Set
        End Property

        Public Overridable Property Cep() As String
            Get
                Return m_strCep
            End Get
            Set(ByVal Value As String)
                m_strCep = Value
            End Set
        End Property

        Public Overridable Property Cidade() As String
            Get
                Return m_strCidade
            End Get
            Set(ByVal Value As String)
                m_strCidade = Value
            End Set
        End Property

        Public Overridable Property UF() As String
            Get
                Return m_strUF
            End Get
            Set(ByVal Value As String)
                m_strUF = Value
            End Set
        End Property

        Public Overridable Property Contato() As String
            Get
                Return m_strContato
            End Get
            Set(ByVal Value As String)
                m_strContato = Value
            End Set
        End Property

        Public Overridable Property Telefone() As String
            Get
                Return m_strTelefone
            End Get
            Set(ByVal Value As String)
                m_strTelefone = Value
            End Set
        End Property

        Public Overridable Property Celular() As String
            Get
                Return m_strCelular
            End Get
            Set(ByVal Value As String)
                m_strCelular = Value
            End Set
        End Property

        Public Overridable Property Fax() As String
            Get
                Return m_strFax
            End Get
            Set(ByVal Value As String)
                m_strFax = Value
            End Set
        End Property

        Public Overridable Property Teste() As Byte
            Get
                Return m_indTeste
            End Get
            Set(ByVal Value As Byte)
                m_indTeste = Value
            End Set
        End Property

        Public Overridable Property Guid() As String
            Get
                Return m_strGuid
            End Get
            Set(ByVal Value As String)
                m_strGuid = Value
            End Set
        End Property

        Public Overridable Property Foto() As String
            Get
                Return m_strFoto
            End Get
            Set(ByVal Value As String)
                m_strFoto = Value
            End Set
        End Property

        Public ReadOnly Property Permissoes() As clsPermissaoUsuario
            Get
                If m_objPermissoes Is Nothing Then
                    m_objPermissoes = New clsPermissaoUsuario(m_intIDUsuario)
                End If
                Return m_objPermissoes
            End Get
        End Property

        Public Property IDStatus() As Integer
            Get
                'Todo: Incluir a informação de status
                m_intIDStatus = 1
                Return m_intIDStatus
            End Get
            Set(ByVal value As Integer)
                m_intIDStatus = value
            End Set
        End Property



        Public Overridable Property AdicionarLoja() As Byte
            Get
                Return m_indAdicionarLoja
            End Get
            Set(ByVal Value As Byte)
                m_indAdicionarLoja = Value
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
            m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
            If dr.IsDBNull(dr.GetOrdinal("CPF")) Then
                m_strCPF = ""
            Else
                m_strCPF = dr.GetString(dr.GetOrdinal("CPF"))
            End If
            m_strlogin = dr.GetString(dr.GetOrdinal("login"))
            If dr.IsDBNull(dr.GetOrdinal("Senha")) Then
                m_strSenha = ""
            Else
                m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDCargo")) Then
                m_intIDCargo = 0
            Else
                m_intIDCargo = dr.GetInt32(dr.GetOrdinal("IDCargo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDSuperior")) Then
                m_intIDSuperior = 0
            Else
                m_intIDSuperior = dr.GetInt32(dr.GetOrdinal("IDSuperior"))
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
            If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
                m_strEndereco = ""
            Else
                m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Numero")) Then
                m_strNumero = ""
            Else
                m_strNumero = dr.GetString(dr.GetOrdinal("Numero"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Complemento")) Then
                m_strComplemento = ""
            Else
                m_strComplemento = dr.GetString(dr.GetOrdinal("Complemento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Bairro")) Then
                m_strBairro = ""
            Else
                m_strBairro = dr.GetString(dr.GetOrdinal("Bairro"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cep")) Then
                m_strCep = ""
            Else
                m_strCep = dr.GetString(dr.GetOrdinal("Cep"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cidade")) Then
                m_strCidade = ""
            Else
                m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("UF")) Then
                m_strUF = ""
            Else
                m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
                m_strContato = ""
            Else
                m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
                m_strTelefone = ""
            Else
                m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Celular")) Then
                m_strCelular = ""
            Else
                m_strCelular = dr.GetString(dr.GetOrdinal("Celular"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Fax")) Then
                m_strFax = ""
            Else
                m_strFax = dr.GetString(dr.GetOrdinal("Fax"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Teste")) Then
                m_indTeste = 0
            Else
                m_indTeste = dr.GetByte(dr.GetOrdinal("Teste"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Guid")) Then
                m_strGuid = ""
            Else
                m_strGuid = dr.GetString(dr.GetOrdinal("Guid"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Foto")) Then
                m_strFoto = ""
            Else
                m_strFoto = dr.GetString(dr.GetOrdinal("Foto"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("AdicionarLoja")) Then
                m_indAdicionarLoja = 3
            Else
                m_indAdicionarLoja = dr.GetByte(dr.GetOrdinal("AdicionarLoja"))
            End If
            m_indAtivo = dr.GetByte(dr.GetOrdinal("Ativo"))
            m_objPermissoes = Nothing
            m_blnIsNew = False
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
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).value = m_strUsuario
            cmd.Parameters.Add("@CPF", SqlDbType.VarChar, 20).value = m_strCPF
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).value = m_strlogin
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).value = m_strSenha
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).value = m_intIDCargo
            cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).value = m_intIDSuperior
            cmd.Parameters.Add("@ADMINISTRADOR", SqlDbType.TinyInt).value = m_indAdministrador
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 256).value = m_strEmail
            cmd.Parameters.Add("@OBSERVACAO", SqlDbType.Text, 2147483647).value = m_strObservacao
            cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 100).value = m_strEndereco
            cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar, 50).value = m_strNumero
            cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar, 20).value = m_strComplemento
            cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar, 50).value = m_strBairro
            cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 50).value = m_strCep
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 50).value = m_strCidade
            cmd.Parameters.Add("@UF", SqlDbType.VarChar, 2).value = m_strUF
            cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 100).value = m_strContato
            cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 100).value = m_strTelefone
            cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar, 30).value = m_strCelular
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 30).value = m_strFax
            cmd.Parameters.Add("@TESTE", SqlDbType.TinyInt).value = m_indTeste
            cmd.Parameters.Add("@GUID", SqlDbType.VarChar, 40).value = m_strGuid
            cmd.Parameters.Add("@FOTO", SqlDbType.VarChar, 255).value = m_strFoto
            cmd.Parameters.Add("@ADICIONARLOJA", SqlDbType.TinyInt).Value = m_indAdicionarLoja
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
            m_strCodigo = ""
            m_strUsuario = ""
            m_strCPF = ""
            m_strlogin = ""
            m_strSenha = ""
            m_intIDCargo = 0
            m_intIDSuperior = 0
            m_indAdministrador = 0
            m_strUltimoAcesso = ""
            m_strSenhaAlterada = ""
            m_strUltimaAtividade = ""
            m_strCriado = ""
            m_strEmail = ""
            m_strObservacao = ""
            m_strValidSenha = ""
            m_strEndereco = ""
            m_strNumero = ""
            m_strComplemento = ""
            m_strBairro = ""
            m_strCep = ""
            m_strCidade = ""
            m_strUF = ""
            m_strContato = ""
            m_strTelefone = ""
            m_strCelular = ""
            m_strFax = ""
            m_indTeste = 0
            m_strGuid = ""
            m_strFoto = ""
            m_indAdicionarLoja = 3
            m_objPermissoes = Nothing
            m_indAtivo = 1
            m_blnIsNew = True
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
        Public Function ListarUsuariosVisita(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_USUARIOS_VISITA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = User.IDUser
            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(0, 0, 0, enOpcaoStatus.Ativos, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCargo As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(vIDCargo, 0, 0, enOpcaoStatus.Ativos, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(vIDCargo, vIDSuperior, 0, enOpcaoStatus.Ativos, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer, ByVal vIDModuloAcesso As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(vIDCargo, vIDSuperior, vIDModuloAcesso, enOpcaoStatus.Ativos, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer, ByVal vIDModuloAcesso As Integer, ByVal vIDStatus As enOpcaoStatus, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_USUARIOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
            cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = vIDSuperior
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.TinyInt).Value = vIDStatus
            cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDMODULOS", SqlDbType.Int).Value = vIDModuloAcesso
            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarUsuariosMobile(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return Listar(0, 0, 2, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCargo As Integer, ByVal vSuperiores As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_USUARIOS_SUPERIORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
            cmd.Parameters.Add("@SUPERIORES", SqlDbType.VarChar, 8000).Value = vSuperiores
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarUsuariosProximoNivel(ByVal vIDCargo As Integer, ByVal vSuperiores As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_USUARIOS_PROXIMONIVEL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
            cmd.Parameters.Add("@SUPERIORES", SqlDbType.VarChar, 8000).Value = vSuperiores
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCargo">Filtro</param>
        ''' <param name="vIDSuperior">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Return Listar(vFilter, vIDCargo, vIDSuperior, enOpcaoTeste.Todos, "", enOpcaoStatus.Ativos, 0, vOrder, vDescending, vPage, vPageSize, vReturnType)

        End Function

        Public Function Listar(ByVal vFilter As String, ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer, ByVal vTipoUsuario As enOpcaoTeste, ByVal vUF As String, ByVal vIDStatus As enOpcaoStatus, ByVal vIDModulo As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_USUARIOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCARGO", SqlDbType.Int).Value = vIDCargo
            cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = vIDSuperior
            cmd.Parameters.Add("@TIPOUSUARIO", SqlDbType.TinyInt).Value = vTipoUsuario
            cmd.Parameters.Add("@UF", SqlDbType.VarChar, 20).Value = vUF
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIDStatus
            cmd.Parameters.Add("@IDMODULO", SqlDbType.Int).Value = vIDModulo
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@IDUSUARIOLOGADO", SqlDbType.Int).Value = User.IDUser

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
        ''' <remarks>Caso ocorra algum erro dentro do login a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDUsuario">Chave primaria IDUsuario do registro atual.</param>
        ''' <param name="vLogin">Login que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDUsuario As Integer, ByVal vLogin As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOGIN_EXISTENTE"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).Value = vLogin
            Return ExecuteScalar(cmd)

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo Codigo informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDUsuario">Chave primaria IDUsuario do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function ExisteCodigo(ByVal vIDUsuario As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CODIGO_EXISTENTE"
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = vCodigo
            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            If m_strlogin = "" Then
                AddBrokenRule(System.Web.HttpUtility.HtmlEncode("Login obrigatorio!"))
                blnValid = False
            ElseIf Existe(m_intIDUsuario, m_strlogin) Then
                AddBrokenRule(System.Web.HttpUtility.HtmlEncode("O login informado ja existe!"))
                blnValid = False
            ElseIf ExisteCodigo(m_intIDUsuario, m_strCodigo) Then
                AddBrokenRule(System.Web.HttpUtility.HtmlEncode("O Codigo informado ja existe!"))
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

        Public Class clsPermissaoUsuario
            Inherits BaseClass

#Region "Declarations"
            Protected m_intIDUsuario As Integer
            Protected m_lstPermissoes As List(Of Integer) = Nothing
#End Region

            Friend Sub New(ByVal vIDUsuario As Integer)
                m_intIDUsuario = vIDUsuario
            End Sub

#Region "Metodos"

            ''' <summary>
            ''' 	Função que adiciona um item na tabela
            ''' </summary>
            Public Sub Add(ByVal vIDPermissao As Integer, ByVal vIDUsuario As Integer)
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "IN_PERMISSAO_USUARIO"
                cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                ExecuteNonQuery(cmd)
            End Sub

            ''' <summary>
            ''' 	Função que adiciona um item na tabela
            ''' </summary>
            Public Sub Add(ByVal vIDPermissao As Integer)
                Add(vIDPermissao, m_intIDUsuario)
            End Sub

            ''' <summary>
            ''' 	Função que remove um item na tabela
            ''' </summary>
            Public Sub Delete(ByVal vIDPermissao As Integer, ByVal vIDUsuario As Integer)
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_PERMISSAO_USUARIO"
                cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                ExecuteNonQuery(cmd)
            End Sub

            ''' <summary>
            ''' 	Função que remove um item na tabela
            ''' </summary>
            Public Sub Delete(ByVal vIDPermissao As Integer)
                Delete(vIDPermissao, m_intIDUsuario)
            End Sub


            ''' <summary>
            ''' 	Função que retorna uma listagem de Permissoes no Cargo
            ''' </summary>
            ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
            ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
            Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

                Dim cmd As New SqlCommand()
                cmd.CommandText = PREFIXO & "LS_USUARIO_PERMISSOES"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUsuario
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                Return ExecuteCommand(cmd, vReturnType)

            End Function

            Public Function Contains(ByVal vIDPermissao As Integer) As Boolean
                If m_lstPermissoes Is Nothing Then
                    Dim dr As IDataReader = Nothing
                    Try
                        dr = Listar(enReturnType.DataReader)
                        m_lstPermissoes = New List(Of Integer)
                        Listar(enReturnType.DataReader)
                        Do While dr.Read
                            m_lstPermissoes.Add(dr.GetInt32(dr.GetOrdinal("IDPermissao")))
                        Loop
                    Finally
                        If Not dr Is Nothing Then
                            If Not dr.IsClosed Then
                                dr.Close()
                            End If
                            dr = Nothing
                        End If
                    End Try
                End If
                Return m_lstPermissoes.Contains(vIDPermissao)
            End Function

            Public Function Contains(ByVal vIDPermissao As Integer, ByVal vIDUsuario As Integer) As Boolean
                Dim cn As SqlConnection = GetDBConnection()
                Try
                    Dim cmd As New SqlCommand()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = PREFIXO & "BS_PERMISSAO_USUARIO_EXISTE"
                    Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                    parameter.Direction = ParameterDirection.ReturnValue
                    cmd.Parameters.Add(parameter)
                    cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
                    cmd.Parameters.Add("@IDPERMISSAO", SqlDbType.Int).Value = vIDPermissao
                    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    Contains = (ExecuteScalar(cmd) > 0)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            End Function

#End Region


        End Class


    End Class
End Namespace

