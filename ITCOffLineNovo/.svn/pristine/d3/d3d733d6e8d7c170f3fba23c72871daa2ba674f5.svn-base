Imports System
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports System.Text
Imports System.Diagnostics
Imports System.IO
Imports System.Data
Imports ITCOffLine

Public Class XMWebPage

    Inherits System.Web.UI.Page
    Private m_Usuario As Usuario
    Private m_DataClass As DataClass
    Protected WithEvents Top1 As Top
    Protected WithEvents Menu1 As Menu
    Private XMCookie As HttpCookie

    Public Enum MODULO
        ASSOCIADOS = 1
        EMPRESAS = 2
        OBRAS = 3
        PEDIDOS = 4
        PROPOSTAS = 5
    End Enum

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If m_Usuario Is Nothing Then m_Usuario = New Usuario(Me)
        If m_Usuario.IDUsuario < 1 Then
            If Request.Path.EndsWith("/default.aspx") = False Then
                Response.Redirect("default.aspx", True)
            End If
        End If
        If Request.Path.EndsWith("/default.aspx") = False Then
            Dim conf As New XMLConfig
            Dim host As Object, hosts As Object = conf.GetValue("HostName", "www.itc.etc.br", False).ToUpper.Split(",")
            Dim refName As String = Request.ServerVariables("HTTP_REFERER")
            Dim blnRef As Boolean = False
            For Each host In hosts
                If refName Is Nothing Then
                    blnRef = True
                Else

                    If Not IsValidReferer(host.ToString(), refName) Then
                        blnRef = True
                    End If
                End If
            Next
            If blnRef = False Then
                m_Usuario.AddHistory(m_Usuario.IDUsuario, "", "", "", "Não logou - " & Request.ServerVariables("HTTP_REFERER"))
                Me.Usuario.Logout()
                Response.Redirect("Default.aspx", True)
            End If
        End If
        If Not Top1 Is Nothing Then
            If Not Menu1 Is Nothing Then
                Menu1.MontaMenu(Me.MontaMenu)
            End If
        End If
    End Sub

    Public Function getPropriedade(ByVal p_Nome As String) As String

        Try
            Dim xmc As New XMLConfig
            Return xmc.GetValue(p_Nome, "", False)
        Catch e As Exception
            Return ""
        End Try

    End Function

    Protected ReadOnly Property CartaAgradecimento() As String

        Get
            Try
                Dim xmc As New XMLConfig
                Return Server.MapPath(xmc.GetValue("CartaAgradecimento", "", False))
            Catch e As Exception
                Return ""
            End Try
        End Get

    End Property

    Protected ReadOnly Property ServidorEmail() As String

        Get
            Try
                Dim xmc As New XMLConfig
                Return xmc.GetValue("ServidorEmail", "", False)
            Catch e As Exception
                Return ""
            End Try
        End Get

    End Property


    Public Sub EnviarEmail(ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_Body As String)

        Dim dt As New DataClass
        dt.ExecuteNonQuery("SP_DTS_IN_INSERE_EMAIL '" & Msg_Subject.Replace("'", "''") & "','" & Msg_Body.Replace("'", "''") & "','" & Msg_To.Replace("'", "''") & "'," & Me.Usuario.IDUsuario)

    End Sub

    Public Sub EnviarEmail_Pedido(ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_Cc As String, ByVal Msg_Cco As String, ByVal Msg_Body As String)

        Dim dt As New DataClass
        dt.ExecuteNonQuery("SP_DTS_IN_INSERE_EMAIL_PEDIDO '" & Msg_Subject.Replace("'", "''") & "','" & Msg_Body.Replace("'", "''") & "','" & Msg_To.Replace("'", "''") & "','" & Msg_Cc.Replace("'", "''") & "','" & Msg_Cco.Replace("'", "''") & "'," & Me.Usuario.IDUsuario)

    End Sub

    Public Sub EnviarEmail_Proposta(ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_Cc As String, ByVal Msg_Cco As String, ByVal Msg_Body As String, ByVal Msg_From As String)

        Dim dt As New DataClass
        dt.ExecuteNonQuery("SP_DTS_IN_INSERE_EMAIL_PROPOSTA '" & Msg_Subject.Replace("'", "''") & "','" & Msg_Body.Replace("'", "''") & "','" & Msg_To.Replace("'", "''") & "','" & Msg_Cc.Replace("'", "''") & "','" & Msg_Cco.Replace("'", "''") & "'," & Me.Usuario.IDUsuario & ",'" & Msg_From.Replace("'", "''") & "'")

    End Sub

    Protected ReadOnly Property CaminhoExportacao() As String

        Get
            Try
                Dim xmc As New XMLConfig
                Return Server.MapPath(xmc.GetValue("LocalExportacao", "", False))
            Catch e As Exception
                Return Server.MapPath("/")
            End Try
        End Get

    End Property

    Protected ReadOnly Property CaminhoExportacaoDownload() As String

        Get
            Try
                Dim xmc As New XMLConfig
                Return xmc.GetValue("LocalExportacao", "", False)
            Catch e As Exception
                Return "/"
            End Try
        End Get

    End Property

    Public Function GetLink(ByVal vLink As String)
        Dim strLink As String = ""
        Try
            strLink = "relatorioobras.aspx?auth=" & CryptographyEncoded("CARTAAGRADECIMENTO") & "&dt=" & CryptographyEncoded(Now()) & "&o=" & CryptographyEncoded(vLink) & "&t=1&q="
        Catch ex As Exception
            strLink = ""
        End Try
        Return strLink
    End Function

    Private Function IsValidReferer(ByRef host As String, ByRef referer As String) As Boolean
        Return IIf(referer.StartsWith("http://" & host), True, False)
    End Function

    Public Function Log_Usuario(ByVal Acao As String, ByVal IdModulo As MODULO)
        Dim DT As New DataClass
        DT.ExecuteNonQuery("SP_SV_LOG_USUARIOS " & Usuario.IDUsuario & ", '" & Acao.Replace("'", "''") & "'," & IdModulo)
        DT = Nothing
    End Function

    Private Function MontaMenu() As String

        Dim strMenu As String = ""

        strMenu = "<script language='javascript'>" & vbCrLf

        Dim blnCadastros As Boolean = False
        Dim blnPesquisas As Boolean = False
        Dim blnRelatorios As Boolean = False

        If CheckPermission("Cadastros", "VISUALIZAR") Then
            blnCadastros = True
            strMenu &= "var mCadastro = new WebFXMenu;" & vbCrLf
            If CheckPermission("Cadastro de Empresas", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Empresa_Obra _
            Or CheckPermission("Cadastro de Empresas", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Associado_Empresa_Obra _
            Or Usuario.Master = True Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Empresas', 'empresas.aspx', null));" & vbCrLf
            End If
            If CheckPermission("Cadastro de Obras", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Empresa_Obra _
            Or CheckPermission("Cadastro de Obras", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Associado_Empresa_Obra _
            Or Usuario.Master = True Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Obras', 'obras.aspx', null));" & vbCrLf
            End If
            'strMenu &= "mCadastro.add(new WebFXMenuSeparator());" & vbCrLf
            If CheckPermission("Cadastro de Associados", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Associado _
            Or CheckPermission("Cadastro de Associados", "VISUALIZAR") And Usuario.TipoArea = Usuario.Tipo_Area.Associado_Empresa_Obra _
            Or Usuario.Master = True Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Clientes', 'associados.aspx', null));" & vbCrLf
            End If
            'strMenu &= "mCadastro.add(new WebFXMenuSeparator());" & vbCrLf
            If CheckPermission("Grupos", "VISUALIZAR") Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Grupos', 'grupo.aspx', null));" & vbCrLf
            End If
            If CheckPermission("Usuários do Sistema", "VISUALIZAR") Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Usuários', 'usuariossistema.aspx', null));" & vbCrLf
            End If
            If CheckPermission("Cadastro de Produtos", "VISUALIZAR") Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Produtos', 'produtos.aspx', null));" & vbCrLf
            End If
            If CheckPermission("Cadastro de Pedidos", "VISUALIZAR") Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Pedidos', 'Pedidos.aspx', null));" & vbCrLf
            End If
            If CheckPermission("Cadastro de Propostas", "VISUALIZAR") Then
                strMenu &= "mCadastro.add(new WebFXMenuItem('Propostas', 'Propostas.aspx', null));" & vbCrLf
            End If
        End If

        strMenu &= "var mSair = new WebFXMenu;" & vbCrLf
        strMenu &= "mSair.add(new WebFXMenuItem('Logout', 'Logout.aspx', null));" & vbCrLf

        strMenu &= "//Menu Principal" & vbCrLf
        strMenu &= "var menuPrincipal = new WebFXMenuBar;" & vbCrLf
        If blnCadastros Then
            strMenu &= "menuPrincipal.add(new WebFXMenuButton('Cadastros', null, null, mCadastro));" & vbCrLf
        End If
        strMenu &= "menuPrincipal.add(new WebFXMenuButton('Sair', null, null, mSair));" & vbCrLf

        strMenu &= "var top = tabelaHeader.offsetTop + tabelaHeader.offsetHeight + 105;" & vbCrLf
        strMenu &= "var left = 10;" & vbCrLf

        strMenu &= "// POSIÇÕES" & vbCrLf

        If blnCadastros Then
            strMenu &= "// Cadastro" & vbCrLf
            strMenu &= "mCadastro.width = 150;" & vbCrLf
            strMenu &= "mCadastro.left  = left;" & vbCrLf
            strMenu &= "mCadastro.top   = top;" & vbCrLf
            strMenu &= "left = mCadastro.left + 78;" & vbCrLf
        End If

        strMenu &= "mSair.width = 150;" & vbCrLf
        strMenu &= "mSair.left  = left;" & vbCrLf
        strMenu &= "mSair.top   = top;" & vbCrLf

        strMenu &= "</script>" & vbCrLf
        strMenu &= "<table height='20' width='100%' border='0' cellpadding='0' cellspacing='0' id='header'>" & vbCrLf
        strMenu &= "<tr>" & vbCrLf
        strMenu &= "<td width='4'>&nbsp;</td>" & vbCrLf
        strMenu &= "<td nowrap>" & vbCrLf
        strMenu &= "<script>" & vbCrLf
        strMenu &= "document.write(menuPrincipal);" & vbCrLf
        strMenu &= "</script>" & vbCrLf
        strMenu &= "</td>" & vbCrLf
        strMenu &= "<td nowrap width='200'><b></b>&nbsp;</td>" & vbCrLf
        strMenu &= "<td nowrap width='150' align='right'><p><font face='verdana' size='2'>&nbsp;</font></p>" & vbCrLf
        strMenu &= "</td>" & vbCrLf
        strMenu &= "<td width='4'>&nbsp;</td>" & vbCrLf
        strMenu &= "</tr>" & vbCrLf
        strMenu &= "</table>" & vbCrLf

        Return strMenu

    End Function

    Public Sub ShowErro(ByVal vCaption As String)
        If Not IsNothing(Top1) Then
            Top1.Show(vCaption)
        End If
    End Sub

    Public Function CheckPermission(ByVal vSection As String, ByVal vAction As String) As Boolean
        Dim ds As DataSet
        m_DataClass = New DataClass
        ds = m_DataClass.GetDataSet("SP_BS_VERIFICAR_PERMISSAO " & Usuario.IDUsuario & ", '" & vSection.Replace("''", "'") & "', '" & vAction.Replace("''", "'") & "'")
        Try
            Return CBool(ds.Tables(0).Rows(0).Item(0) = 1)
        Catch e As Exception
            Return False
        End Try
    End Function

    Public ReadOnly Property Usuario() As Usuario
        Get
            Return m_Usuario
        End Get
    End Property

    Public Function Data() As DataClass
        Return m_DataClass
    End Function

    Public Function CryptographyEncoded(ByVal param As String) As String
        Dim strReturn As String = MyBase.Server.UrlEncode(XMCrypto.Encrypt(param))
        Return strReturn
    End Function

    Public Function Cryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Encrypt(param)
        Return strReturn
    End Function

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Public Sub Gravado(ByVal p_Volta As String)
        Response.Redirect("gravado.aspx?v=" & Server.UrlEncode(p_Volta))
    End Sub

End Class

Public Enum enAuthorize
    NotAuthorized = 0
    Authorized = 1
    SubscriptionFinished = 2
    SetPassword = 3
End Enum

Public Class Usuario

    Inherits DataClass

    Public Enum Tipo_Area
        Associado = 1
        Empresa_Obra = 2
        Associado_Empresa_Obra = 3
    End Enum

    Private m_strUsuario As String
    Private m_strLogin As String
    Private m_intID As Integer
    Private m_intIDGrupo As Integer
    Private m_intIdEmpresa As Integer
    Private m_intAuthorized As enAuthorize
    Private m_IndMaster As Integer = 0
    Private m_indUpdatePasswordNextLogon As Integer = 0
    Private m_intIdGestor As Integer
    Private m_TipoArea As Tipo_Area
    Private Const COOKIE_NAME As String = "XM-ITC"

    Public ReadOnly Property Nome() As String
        Get
            Return m_strUsuario
        End Get
    End Property

    Public ReadOnly Property Login() As String
        Get
            Return m_strLogin
        End Get
    End Property

    Public ReadOnly Property IDUsuario() As Integer
        Get
            Return m_intID
        End Get
    End Property

    Public ReadOnly Property IDGrupo() As Integer
        Get
            Return m_intIDGrupo
        End Get
    End Property

    Public ReadOnly Property IdEmpresa() As Integer
        Get
            Return m_intIdEmpresa
        End Get
    End Property

    Public ReadOnly Property TipoArea() As Tipo_Area
        Get
            Return m_TipoArea
        End Get
    End Property

    Public ReadOnly Property Master() As Boolean
        Get
            Return IIf(m_IndMaster = 1, True, False)
        End Get
    End Property

    Public ReadOnly Property IdGestor() As Integer
        Get
            Return m_intIdGestor
        End Get
    End Property

    Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        m_intID = XMCookie.GetEncryptedCookieValue("sID")
        m_strUsuario = XMCookie.GetEncryptedCookieValue("Usuario")
        m_intIDGrupo = XMCookie.GetEncryptedCookieValue("IDGrupo")
        m_intIdEmpresa = XMCookie.GetEncryptedCookieValue("IDEmpresa")
        m_intAuthorized = XMCookie.GetEncryptedCookieValue("Authorized")
        m_strLogin = XMCookie.GetEncryptedCookieValue("Login")
        m_IndMaster = XMCookie.GetEncryptedCookieValue("Master")
        m_intIdGestor = XMCookie.GetEncryptedCookieValue("IdGestor")
        m_TipoArea = XMCookie.GetEncryptedCookieValue("TipoArea")
    End Sub

    Public Function SavePassword(ByVal vNewPassword As String) As Boolean
        Try
            ExecuteNonQuery("SP_UP_SENHA " & m_intID & ", " & vNewPassword)
            m_intAuthorized = enAuthorize.Authorized
            XMCookie.SetEncryptedCookie("Authorized", m_intAuthorized)
            Return True
        Catch e As Exception
            XMPage.ShowErro("Ocorreu um erro ao tentar alterar a senha. Contate o administrador do sistema - " & e.Message)
            Return False
        End Try
    End Function

    Private Sub Inflate(ByVal row As DataRow)

        Me.m_intID = CInt(0 & row("USU_USUARIO_INT_PK"))
        Me.m_strUsuario = CStr(row("USU_USUARIO_CHR") & "")
        Me.m_strLogin = CStr(row("USU_LOGIN_CHR") & "")
        Me.m_intIDGrupo = CInt(0 & row("IDGRUPO"))
        Me.m_intIDGrupo = CInt(0 & row("IDGRUPO"))
        Me.m_intIdEmpresa = CInt(row("EMP_IDEMPRESA_INT_FK"))
        Me.m_indUpdatePasswordNextLogon = CInt(0 & row("usu_UpdatePasswordNextLogon_ind"))
        Me.m_IndMaster = CInt(0 & row("USU_TIPOUSUARIO_INT"))
        Me.m_TipoArea = CInt(0 & row("are_Area_int_FK"))
        Me.m_intIdGestor = CInt(0 & row("IdGestor"))

        If Me.m_intID = 0 Then
            Me.m_intAuthorized = enAuthorize.NotAuthorized
        Else
            If m_indUpdatePasswordNextLogon = 1 Then
                Me.m_intAuthorized = enAuthorize.SetPassword
            Else
                Me.m_intAuthorized = enAuthorize.Authorized
            End If
        End If

        XMCookie.SetEncryptedCookie("sID", m_intID)
        XMCookie.SetEncryptedCookie("Usuario", m_strUsuario)
        XMCookie.SetEncryptedCookie("IDGrupo", m_intIDGrupo)
        XMCookie.SetEncryptedCookie("Authorized", m_intAuthorized)
        XMCookie.SetEncryptedCookie("Login", m_strLogin)
        XMCookie.SetEncryptedCookie("IDEmpresa", m_intIdEmpresa)
        XMCookie.SetEncryptedCookie("Master", m_IndMaster)
        XMCookie.SetEncryptedCookie("IdGestor", m_intIdGestor)
        XMCookie.SetEncryptedCookie("TipoArea", m_TipoArea)

    End Sub

    Public Function Logout() As Boolean

        XMCookie.SetEncryptedCookie("sID", 0)
        XMCookie.SetEncryptedCookie("Usuario", "")
        XMCookie.SetEncryptedCookie("IDGrupo", 0)
        XMCookie.SetEncryptedCookie("Authorized", enAuthorize.NotAuthorized)
        XMCookie.SetEncryptedCookie("Login", "")
        XMCookie.SetEncryptedCookie("IDEmpresa", 0)
        XMCookie.SetEncryptedCookie("DataInicioPlano", "")
        XMCookie.SetEncryptedCookie("DataFimPlano", "")
        XMCookie.SetEncryptedCookie("QuantidadeObras", 0)
        XMCookie.SetEncryptedCookie("QuantidadeEmpresas", 0)
        XMCookie.SetEncryptedCookie("Master", 0)
        XMCookie.SetEncryptedCookie("IdGestor", 0)
        XMCookie.SetEncryptedCookie("TipoArea", 0)

    End Function

    Public Function AddHistory(ByVal IdUsuario As Integer, ByVal IP As String, ByVal Browser As String, ByVal SistemaOperacional As String, ByVal Descricao As String)
        ExecuteNonQuery("SP_BS_ADDHISTORY " & IdUsuario & ",'" & IP & "','" & Browser & "','" & SistemaOperacional & "','" & Descricao & "'")
    End Function

    Public Function Authenticate(ByVal vLogin As String, ByVal vPassword As String) As enAuthorize

        Dim myData As DataSet
        Dim iReturnValue As Integer = 0

        Dim cmdLogin As SqlParameter = New SqlParameter("@LOGIN", SqlDbType.VarChar, 20)
        cmdLogin.Value = vLogin.Replace("'", "''")

        Dim cmdSenha As SqlParameter = New SqlParameter("@SENHA", SqlDbType.VarChar, 10)
        cmdSenha.Value = vPassword.Replace("'", "''")

        Dim parameters As SqlParameter() = {cmdLogin, cmdSenha}
        Dim sql As String = "SP_SE_LOGIN"

        myData = GetDataSet(sql, parameters, iReturnValue)

        If myData.Tables(0).Rows.Count <= 0 Then
            Clear()
            Me.m_intAuthorized = enAuthorize.NotAuthorized
            AddHistory(m_intID, HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), "", "Erro ao tentar login no sistema.")
        Else
            Inflate(myData.Tables(0).Rows(0))
            AddHistory(m_intID, HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), "", "Login efetuado no sistema.")
        End If

        myData.Dispose()

        Return Me.m_intAuthorized

    End Function

    Public ReadOnly Property Authorized() As enAuthorize
        Get
            Return m_intAuthorized
        End Get
    End Property

    Private Sub Clear()
        m_intID = -1
        m_strUsuario = ""
        m_intIDGrupo = 0
        m_intAuthorized = enAuthorize.NotAuthorized
        m_strLogin = ""
        m_IndMaster = 0
        m_intIdGestor = 0
        m_TipoArea = 0
    End Sub

End Class

Public Class DataClass

    Private m_strConnectionString As String
    Private m_XMWebPage As XMWebPage
    Private Connection As SqlConnection

    Public Sub New()
        m_strConnectionString = ConnectionString
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        m_XMWebPage = vXMPage
        m_strConnectionString = ConnectionString
    End Sub

    Public ReadOnly Property XMPage() As XMWebPage
        Get
            Return m_XMWebPage
        End Get
    End Property

    Protected Sub Close()
        If Not Connection Is Nothing Then
            Connection.Close()
        End If
    End Sub

    Protected Sub Open()
        If Connection Is Nothing Then
            Connection = New SqlConnection(m_strConnectionString)
        End If
        If Connection.State <> ConnectionState.Open Then Connection.Open()
    End Sub

    Public Function GetDataSet(ByVal SQL As String) As DataSet
        Open()
        Dim myData As New DataSet

        Try
            Dim adapter As New SqlDataAdapter(SQL, Connection)
            adapter.Fill(myData, "data")
            adapter.Dispose()
        Catch e As SqlException
            If e.Number = 50000 Then
                LogError(e, "DataClass")
            End If
        Catch e As Exception
            LogError(e, "DataClass")
        Finally
            Close()
        End Try
        Return myData

    End Function

    Public Function GetDataSet(ByVal SQL As String, ByVal Params As IDataParameter(), ByRef iReturn_Value As Integer) As DataSet

        Dim ds As New DataSet

        Dim prm As SqlParameter
        Open()

        Dim da As New SqlDataAdapter(SQL, Connection)
        With da
            .SelectCommand.CommandType = CommandType.StoredProcedure
            .SelectCommand.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, 0, 0, String.Empty, DataRowVersion.Default, Nothing))
            For Each prm In Params
                .SelectCommand.Parameters.Add(prm)
            Next
            .Fill(ds, "data")
            iReturn_Value = .SelectCommand.Parameters("ReturnValue").Value()
        End With

        Close()

        Return ds

    End Function

    Public Function GetDataSet(ByVal SQL As String, ByRef vMessage As String) As DataSet

        Open()
        Dim myData As New DataSet

        Try
            Dim adapter As New SqlDataAdapter(SQL, Connection)
            adapter.Fill(myData, "data")
            adapter.Dispose()
        Catch e As SqlException
            vMessage = e.Message
            If e.Number = 50000 Then
                LogError(e, "DataClass")
            End If
        Catch e As Exception
            LogError(e, "DataClass")
        Finally
            Close()
        End Try

        Return myData

    End Function

    Public Sub LogError(ByVal e As Exception, ByVal vModule As String)
        'se der erro aqui a coisa tá feia
        Try
            'ExecuteNonQuery("SP_IN_ERROS 0, '" & e.Message.Replace("'", "''") & "', '" & e.Source.Replace("'", "''") & "', '" & vModule.Replace("'", "''") & "', 'WebManagement', '" & System.Environment.Version.ToString.Replace("'", "''") & "', '" & e.TargetSite.Name.Replace("'", "''") & e.StackTrace.Replace("'", "''") & "'")
        Finally
        End Try
    End Sub

    Public Sub ExecuteNonQuery(ByVal SQL As String)
        Open()
        Dim myCommand As New SqlCommand
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        myCommand.ExecuteNonQuery()
        'clean up
        Close()
        myCommand.Dispose()
    End Sub

    Public Function ExecuteReader(ByVal SQL As String) As SqlDataReader
        Open()
        Dim myCommand As New SqlCommand
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        ExecuteReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        'clean up
        'myCommand.Dispose()
    End Function

    Protected Sub ExecuteNonQuery(ByVal cmd As SqlCommand)
        Open()
        cmd.Connection = Connection
        Try
            cmd.ExecuteNonQuery()
        Finally
            Close()
        End Try
    End Sub

    Protected Function GetDataSet(ByVal cmd As SqlCommand) As DataSet

        'ESTE MÉTODO DEVE ABRIR A CONEXÃO COM O BANCO DA MESMA FORMA QUE O MÉTODO ACIMA ABRE (ExecuteNonQuery), PROVAVELMENTE ESTE MÉTODO NÃO ESTÁ FUNCIONANDO.

        Dim da As SqlDataAdapter
        Dim ds As New DataSet
        Dim cn As SqlConnection = Connection
        cn.Open()

        Try

            da = New SqlDataAdapter(cmd)
            da.SelectCommand.Connection = cn
            da.Fill(ds, "data")

        Finally

            da = Nothing
            cn.Close()
            cn = Nothing

        End Try

        Return ds

    End Function

    'Protected Function ExecuteReader(ByRef cmd As SqlCommand, ByVal Params As SqlParameterCollection) As SqlDataReader
    '    Dim cn As SqlConnection = Connection
    '    Dim dr As SqlDataReader = Nothing
    '    Dim prm As SqlParameter
    '    Try
    '        cmd.Connection = cn
    '        cn.Open()
    '        For Each prm In Params
    '            cmd.Parameters.Add(prm)
    '        Next
    '        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '    Catch ex As Exception
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '        Throw ex
    '    End Try
    '    Return dr
    'End Function

    Protected Function ExecuteReader(ByRef cmd As SqlCommand) As SqlDataReader

        Dim dr As SqlDataReader = Nothing
        Try
            Open()
            cmd.Connection = Connection
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw ex
        End Try
        Return dr
    End Function

    Protected Function ExecuteScalar(ByRef cmd As SqlCommand) As Object
        Dim cn As SqlConnection = Connection
        Dim ret As Object = Nothing
        Try
            cmd.Connection = cn
            cn.Open()
            ret = cmd.ExecuteScalar()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
        Return ret
    End Function

    Protected Function ExecuteDataSet(ByRef cmd As SqlCommand) As DataSet
        Dim cn As SqlConnection = Connection
        Dim myData As New DataSet("data")

        Try
            cmd.Connection = cn
            cn.Open()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(myData)
            adapter.Dispose()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
        Return myData
    End Function
    Protected ReadOnly Property ConnectionString() As String

        Get
            Dim xmc As New XMLConfig
            Return xmc.GetValue("ConnectionString", "", False)
        End Get

    End Property

End Class
Public Class XMCrypto

    Private Const cryptoKey As String = "ITC_XM_2005"
    Private Shared IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, 173, 59}
    Private Shared IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, 42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}

    Public Shared Function Encrypt(ByVal p_Val As String) As String
        Dim buffer As Byte() = Encoding.ASCII.GetBytes(p_Val)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
        des.IV = IV
        Return Convert.ToBase64String(des.CreateEncryptor.TransformFinalBlock(buffer, 0, buffer.Length))
    End Function

    Public Shared Function Decrypt(ByVal p_Val As String) As String
        Try
            Dim buffer As Byte() = Convert.FromBase64String(p_Val)
            Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
            des.IV = IV
            Return Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
        Catch ex As Exception
            'Throw New Exception()
        End Try
    End Function

End Class

Public Class XMCookie

    Public Shared Sub SetEncryptedCookie(ByVal key As String, ByVal value As String)
        key = XMCrypto.Encrypt(key)
        value = XMCrypto.Encrypt(value)
        SetCookie(key, value)
    End Sub

    Public Shared Sub SetEncryptedCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)
        key = XMCrypto.Encrypt(key)
        value = XMCrypto.Encrypt(value)
        SetCookie(key, value, expires)
    End Sub

    Public Shared Sub SetCookie(ByVal key As String, ByVal value As String)
        key = HttpContext.Current.Server.UrlEncode(key)
        value = HttpContext.Current.Server.UrlEncode(value)
        Dim cookie As HttpCookie
        cookie = New HttpCookie(key, value)
        SetCookie(cookie)
    End Sub

    Public Shared Sub SetCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)
        key = HttpContext.Current.Server.UrlEncode(key)
        value = HttpContext.Current.Server.UrlEncode(value)
        Dim cookie As HttpCookie
        cookie = New HttpCookie(key, value)
        cookie.Expires = expires
        SetCookie(cookie)
    End Sub

    Public Shared Sub SetCookie(ByVal cookie As HttpCookie)
        HttpContext.Current.Response.Cookies.Set(cookie)
    End Sub

    Public Shared Function GetEncryptedCookieValue(ByVal key As String) As String
        key = XMCrypto.Encrypt(key)
        Dim value As String
        value = GetCookieValue(key)
        value = XMCrypto.Decrypt(value)
        Return value
    End Function

    Public Shared Function GetCookie(ByVal key As String) As HttpCookie
        key = HttpContext.Current.Server.UrlEncode(key)
        Return HttpContext.Current.Request.Cookies.Get(key)
    End Function

    Public Shared Function GetCookieValue(ByVal key As String) As String
        Try
            Dim value As String
            value = GetCookie(key).Value
            value = HttpContext.Current.Server.UrlDecode(value)
            Return value
        Catch
        End Try
    End Function

End Class