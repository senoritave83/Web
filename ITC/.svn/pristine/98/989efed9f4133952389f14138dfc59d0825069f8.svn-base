Imports System
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports System.Text
Imports System.Diagnostics
Imports System.IO
Imports System.Configuration.ConfigurationSettings
Imports System.Web.HttpServerUtility
Imports System.Web


Public Class XMWebPageDemo

    Inherits System.Web.UI.Page

    Private m_DataClass As DataClass

    Public IdUsuario As Integer = 1
    Public IdEmpresa As Integer = 0
    Private XMCookie As HttpCookie

    Public Enum MODULO
        OBRAS = 1
        ASSOCIADOS = 3
        EMPRESAS = 2
    End Enum

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        '***************************************************
        'CHECAGEM DA CHAMADA MANUAL DOS 
        'RELATÓRIOS ENVIADOS POR LINK
        '***************************************************

        Dim p_Authenticate As String = CObj(Page.Request("auth") & "")

        If Request.Path.EndsWith("/relatorioobrasd.aspx") = True Or _
                Request.Path.EndsWith("/relatorioempresasd.aspx") = True Then

            Dim p_ReportGuid As String = CObj(Page.Request("gd") & "")

            If p_ReportGuid.ToString() <> "" Then

                Dim clsPesq As New clsPesquisas
                Dim strURL As String = clsPesq.getReportGuid_Data(p_ReportGuid)
                clsPesq = Nothing

                If strURL <> "" Then
                    PostRedirect(strURL & "&auth=" & p_ReportGuid)
                End If

            End If

        End If

    End Sub

    Public Sub PostRedirect(ByVal URL As String)

        Dim vFields() As String
        Dim strHTML As String
        Dim conf As New XMLConfig

        Dim i, j As Integer
        j = InStr(URL, "?")
        strHTML = "<html><body><form name='frm' action='" & URL.Substring(0, j - 1) & "' method='POST'>" & vbCrLf
        vFields = Split(URL.Substring(j), "&")
        For i = 0 To UBound(vFields)
            j = InStr(vFields(i), "=")
            strHTML &= "<input type='hidden' name='" & vFields(i).Substring(0, j - 1) & "' value='" & Server.UrlDecode(vFields(i).Substring(j)) & "'>" & vbCrLf
        Next
        If conf.GetValue("debug", "False") = "True" Then
            strHTML &= "<input type='submit' Value='Enviar'></form></body></html>" & vbCrLf
        Else
            strHTML &= "</form><script>document.frm.submit();</script></body></html>" & vbCrLf
        End If

        Response.Clear()
        Response.Write(strHTML)
        Response.End()

    End Sub

    Public Function Data() As DataClass
        Return m_DataClass
    End Function

    Public Function CryptographyEncoded(ByVal param As String) As String
        If param Is Nothing Then Return ""
        Dim strReturn As String = MyBase.Server.UrlEncode(XMCrypto.Encrypt(param))
        Return strReturn
    End Function

    Public Function Cryptography(ByVal param As String) As String
        If param Is Nothing Then Return ""
        Dim strReturn As String = XMCrypto.Encrypt(param)
        Return strReturn
    End Function

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Public Sub Gravado(ByVal p_Volta As String, Optional ByVal p_Fechar As Boolean = False)
        Response.Redirect("gravado.aspx?" & IIf(p_Fechar = True, "ft=1&", "") & "v=" & Server.UrlEncode(p_Volta))
    End Sub

End Class

Public Class XMWebPage

    Inherits System.Web.UI.Page
    Private m_Usuario As Usuario
    Private m_DataClass As DataClass
    Protected WithEvents Top1 As Top
    Protected WithEvents Menu1 As Menu
    Protected WithEvents UserData1 As UserData
    Private XMCookie As HttpCookie

    Public Enum MODULO
        OBRAS = 1
        ASSOCIADOS = 3
        EMPRESAS = 2
    End Enum

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '***************************************************
        'CHECAGEM DA CHAMADA MANUAL DOS 
        'RELATÓRIOS ENVIADOS POR LINK
        '***************************************************

        Dim p_Authenticate As String = CObj(Page.Request("auth") & "")

        If Request.Path.ToLower.EndsWith("/relatorioobras.aspx") = True Or _
                Request.Path.ToLower.EndsWith("/relatorioempresas.aspx") = True Then

            Dim p_ReportGuid As String = CObj(Page.Request("gd") & "")
            Dim p_AgradecAvaliado As String = CObj(Page.Request("aa") & "").ToString()

            If DeCryptography(p_Authenticate) = "CARTAAGRADECIMENTO" And p_AgradecAvaliado = "" Then

                Dim vNewGuid As String = System.Guid.NewGuid().ToString
                PostRedirect(Page.Request.Url.AbsoluteUri & "&aa=" & vNewGuid)

            ElseIf p_ReportGuid.ToString() <> "" Then

                Dim clsPesq As New clsPesquisas
                Dim strURL As String = clsPesq.getReportGuid_Data(p_ReportGuid)
                clsPesq = Nothing

                If strURL <> "" Then
                    PostRedirect(strURL & "&auth=" & p_ReportGuid & "&authRep=" & p_ReportGuid)
                Else
                    Response.Redirect(AppSettings("PaginaInicial") & "", True)
                End If

                Exit Sub

            Else

                Dim strAuthRep As String = Page.Request("authRep") & ""
                Dim strAuth As String = Page.Request("auth")

                If m_Usuario Is Nothing Then m_Usuario = New Usuario(Me)
                If (m_Usuario.IDUsuario < 1 Or p_Authenticate = "") And strAuthRep = "" Then
                    'VERIFICA SE A PÁGINA 
                    If Request.Path.EndsWith("/default.aspx") = False Then
                        Response.Redirect("default.aspx", True)
                    End If
                End If

            End If
        Else

            p_Authenticate = ""

        End If

        If m_Usuario Is Nothing Then m_Usuario = New Usuario(Me)
        If m_Usuario.IDUsuario < 1 And p_Authenticate = "" Then
            'VERIFICA SE A PÁGINA 
            If Request.Path.EndsWith("/default.aspx") = False Then
                Response.Redirect("default.aspx", True)
            End If
        End If

        '***************************************************
        'FIM CHECAGEM DA CHAMADA MANUAL 
        'DOS RELATÓRIOS ENVIADOS POR LINK
        '***************************************************

        'If Request.Path.EndsWith("/default.aspx") = False Then
        '    Dim conf As New XMLConfig
        '    Dim hostName As String = conf.GetValue("HostName", "www.itc.etc.br", False)
        '    Dim refName As String = Request.ServerVariables("HTTP_REFERER")
        '    If Not refName Is Nothing Then
        '        If Not IsValidReferer(hostName, refName) Then
        '            Me.Usuario.Logout()
        '            Response.Redirect("Default.aspx")
        '        End If
        '    End If
        'End If
        If Not Top1 Is Nothing Then
            'If Not Menu1 Is Nothing Then
            'Menu1.MontaMenu(Me.MontaMenu)
            If Usuario.Login = "" Then
                Top1.UserData("")
            Else
                Dim strDadosUsuario As String = ""
                If Usuario.IdEmpresa = -1 Then
                    strDadosUsuario = "<b>Usuário:</b> " & Usuario.Login.ToUpper & " <b>Último acesso em</b> " & Usuario.DataUltimoAcesso.ToString("dd/MM/yyyy")
                    'strDadosUsuario &= "<br>&nbsp;" '<b>Acesso ao banco de dados completo</b>"
                Else
                    Dim InfoUsuario As Usuario.Informacoes_Usuario = Usuario.InformacoesUsuario()
                    strDadosUsuario = "<b>Associado:</b> " & Usuario.Login.ToUpper & " <b>Último acesso em</b> " & Usuario.DataUltimoAcesso.ToString("dd/MM/yyyy")
                    'strDadosUsuario &= "<br>&nbsp;" 'Banco de Dados de " & Usuario.DataInicioPlano & " até " & Usuario.DataFimPlano & " - Total de " & InfoUsuario.Quantidade_Obras & " obras e " & InfoUsuario.Quantidade_Empresas & " empresas "
                End If
                Top1.UserData(strDadosUsuario)
            End If
        End If
        'End If
    End Sub

    Public Sub PostRedirect(ByVal URL As String)

        Dim vFields() As String
        Dim strHTML As String
        Dim conf As New XMLConfig

        Dim i, j As Integer
        j = InStr(URL, "?")
        strHTML = "<html><body><form name='frm' action='" & URL.Substring(0, j - 1) & "' method='POST'>" & vbCrLf
        vFields = Split(URL.Substring(j), "&")
        For i = 0 To UBound(vFields)
            j = InStr(vFields(i), "=")
            strHTML &= "<input type='hidden' name='" & vFields(i).Substring(0, j - 1) & "' value='" & Server.UrlDecode(vFields(i).Substring(j)) & "'>" & vbCrLf
        Next
        If conf.GetValue("debug", "False") = "True" Then
            strHTML &= "<input type='submit' Value='Enviar'></form></body></html>" & vbCrLf
        Else
            strHTML &= "</form><script>document.frm.submit();</script></body></html>" & vbCrLf
        End If

        Response.Clear()
        Response.Write(strHTML)
        Response.End()

    End Sub

    Public ReadOnly Property Debug() As Boolean
        Get
            Try
                Dim xmc As New XMLConfig
                Return IIf(xmc.GetValue("Debug", "0") = "1", True, False)
            Catch e As Exception
                Return False
            End Try
        End Get
    End Property

    Public Sub EnviarEmail(ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_Body As String)
        Dim dt As New DataClass
        dt.ExecuteNonQuery("SP_DTS_IN_INSERE_EMAIL '" & Msg_Subject & "','" & Msg_Body & "','" & Msg_To & "'," & Me.Usuario.IDUsuario)
    End Sub

    Public Function getFileData(ByVal p_FileName As String) As String

        Dim p_Path As String = AppSettings(p_FileName).ToString()
        Dim p_File As StreamReader

        p_File = File.OpenText(p_Path)
        Dim p_Return As String = p_File.ReadToEnd
        p_File.Close()
        p_File = Nothing

        Return p_Return

    End Function

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

    Private Function IsValidReferer(ByRef host As String, ByRef referer As String) As Boolean
        Return IIf(referer.StartsWith("http://" & host), True, False)
    End Function

    Public Function Log_Usuario(ByVal Acao As String, ByVal IdModulo As MODULO)
        Dim DT As New DataClass
        DT.ExecuteNonQuery("SP_SV_LOG_USUARIOS " & Usuario.IDUsuario & ", '" & Acao.Replace("'", "''") & "'," & IdModulo)
        DT = Nothing
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
        If param Is Nothing Then Return ""
        Dim strReturn As String = MyBase.Server.UrlEncode(XMCrypto.Encrypt(param))
        Return strReturn
    End Function

    Public Function Cryptography(ByVal param As String) As String
        If param Is Nothing Then Return ""
        Dim strReturn As String = XMCrypto.Encrypt(param)
        Return strReturn
    End Function

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Public Sub Gravado(ByVal p_Volta As String, Optional ByVal p_Fechar As Boolean = False)
        Response.Redirect("gravado.aspx?" & IIf(p_Fechar = True, "ft=1&", "") & "v=" & Server.UrlEncode(p_Volta))
    End Sub

End Class

Public Enum enAuthorize
    NotAuthorized = 0
    Authorized = 1
    SubscriptionFinished = 2
    SetPassword = 3
    UserAlreadyLoggedIn = 4 'o usuário já está logado em outro Ip / Máquina
    UserSuspended = 5 'o usuário está suspenso até regularizar a situação junto ao ITC
End Enum

Public Class Usuario

    Inherits DataClass
    Private m_strUsuario As String
    Private m_strLogin As String
    Private m_intID As Integer
    Private m_intIDGrupo As Integer
    Private m_intIdEmpresa As Integer
    Private m_intAuthorized As enAuthorize
    Private m_dtmDataUltimoAcesso As Date
    Private m_dtmDataInicioPlano As Date
    Private m_dtmDataFimPlano As Date
    Private m_QuantObras As Integer = 0
    Private m_QuantEmpresas As Integer = 0
    Private m_IndTipoUsuario As TIPO_USUARIO = ITC_Global.TIPO_USUARIO.USUARIO
    Private m_IndMaster As Integer = 0
    Private m_indUpdatePasswordNextLogon As Integer = 0
    Private m_TipoArea As Tipo_Area
    Private m_intIdGestor As Integer
    Private m_strGuid As String
    Private Const COOKIE_NAME As String = "XM-ITC"

    Public Enum Tipo_Area
        Associado = 1
        Empresa_Obra = 2
        Associado_Empresa_Obra = 3
    End Enum

    Public Structure Informacoes_Usuario
        Dim Quantidade_Obras As Integer
        Dim Quantidade_Empresas As Integer
        Dim Acesso_Brasil As Boolean
    End Structure

    Public ReadOnly Property TipoArea() As Tipo_Area
        Get
            Return m_TipoArea
        End Get
    End Property

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

    Public ReadOnly Property DataInicioPlano() As Date
        Get
            Return m_dtmDataInicioPlano
        End Get
    End Property

    Public ReadOnly Property DataFimPlano() As Date
        Get
            Return m_dtmDataFimPlano
        End Get
    End Property

    Public ReadOnly Property DataUltimoAcesso() As Date
        Get
            Return m_dtmDataUltimoAcesso
        End Get
    End Property

    Public ReadOnly Property UserGuid() As String
        Get
            Return m_strGuid
        End Get
    End Property

    Public ReadOnly Property InformacoesUsuario() As Usuario.Informacoes_Usuario
        Get
            Dim InfoUser As Usuario.Informacoes_Usuario
            Dim dsUsuario As DataSet = GetDataSet("SP_SE_INFORMACOES_USUARIO " & m_intID)
            With dsUsuario.Tables
                If .Count > 0 Then
                    If .Item(0).Rows.Count > 0 Then
                        InfoUser.Acesso_Brasil = .Item(0).Rows(0).Item("BRASIL")
                        InfoUser.Quantidade_Empresas = .Item(0).Rows(0).Item("QUANTIDADE_EMPRESAS")
                        InfoUser.Quantidade_Obras = .Item(0).Rows(0).Item("QUANTIDADE_OBRAS")
                    End If
                End If
            End With
            Return InfoUser
        End Get
    End Property

    Public ReadOnly Property TipoUsuario() As TIPO_USUARIO
        Get
            Return m_IndTipoUsuario
        End Get
    End Property

    Public ReadOnly Property Master() As Boolean
        Get
            Return IIf(m_IndMaster = 1, True, False)
        End Get
    End Property

    Public ReadOnly Property IDGestor() As Integer
        Get
            Return m_intIdGestor
        End Get
    End Property

    Public ReadOnly Property AuthGuid() As String
        Get
            Return Environment.TickCount()
        End Get
    End Property

    Sub New(ByVal vXMPage As XMWebPage)

        MyBase.New(vXMPage)

        'm_intID = 10
        'm_strUsuario = "Marcelo"
        'm_intIDGrupo = 1
        'm_intIdEmpresa = -1
        'm_intAuthorized = 1
        'm_strLogin = "marcelo"
        'm_dtmDataInicioPlano = "01/01/1990"
        'm_dtmDataFimPlano = "01/01/2060"
        'm_dtmDataUltimoAcesso = "13/02/2009"

        'm_QuantObras = 1000
        'm_QuantEmpresas = 1000
        'm_IndMaster = 1
        'm_IndTipoUsuario = 1
        'm_intIdGestor = 0
        'm_TipoArea = 1

        'Exit Sub

        m_intID = XMCookie.getEncryptedCookieValue("sID")
        m_strUsuario = System.Web.HttpUtility.HtmlDecode(XMCookie.getEncryptedCookieValue("Usuario"))
        m_intIDGrupo = XMCookie.getEncryptedCookieValue("IDGrupo")
        m_intIdEmpresa = XMCookie.getEncryptedCookieValue("IDEmpresa")
        m_intAuthorized = XMCookie.getEncryptedCookieValue("Authorized")
        m_strLogin = XMCookie.getEncryptedCookieValue("Login")
        m_strGuid = XMCookie.getEncryptedCookieValue("lgGuid")

        Try
            m_dtmDataInicioPlano = XMCookie.getEncryptedCookieValue("DataInicioPlano")
            m_dtmDataFimPlano = XMCookie.getEncryptedCookieValue("DataFimPlano")
            m_dtmDataUltimoAcesso = XMCookie.getEncryptedCookieValue("DataUltimoAcesso")
        Catch e As Exception

        End Try

        m_QuantObras = XMCookie.getEncryptedCookieValue("QuantidadeObras")
        m_QuantEmpresas = XMCookie.getEncryptedCookieValue("QuantidadeEmpresas")
        m_IndMaster = XMCookie.getEncryptedCookieValue("Master")
        m_IndTipoUsuario = XMCookie.getEncryptedCookieValue("TipoUsuario")
        m_intIdGestor = XMCookie.getEncryptedCookieValue("IdGestor")
        m_TipoArea = XMCookie.getEncryptedCookieValue("TipoArea")

        If m_intID > 0 And m_intAuthorized = enAuthorize.Authorized Then

            AddNavigation(m_intIdEmpresa, m_intID, "", m_strGuid)

        End If

    End Sub

    Public Function SavePassword(ByVal vNewPassword As String) As Boolean
        Try
            ExecuteNonQuery("SP_UP_SENHA " & m_intID & ", " & vNewPassword)
            m_intAuthorized = enAuthorize.Authorized
            XMCookie.setEncryptedCookie("Authorized", m_intAuthorized)
            Return True
        Catch e As Exception
            XMPage.ShowErro("Ocorreu um erro ao tentar alterar a senha. Contate o administrador do sistema - " & e.Message)
            Return False
        End Try
    End Function

    Public Sub IniciarDebug()

        Me.m_intID = 10
        Me.m_strUsuario = "Marcelo"
        Me.m_strLogin = "Marcelo"
        Me.m_intIDGrupo = 1
        Me.m_intIdEmpresa = -1
        Me.m_dtmDataInicioPlano = Now.AddDays(-1)
        Me.m_dtmDataFimPlano = Now.AddDays(365)
        Me.m_dtmDataUltimoAcesso = Now()
        Me.m_indUpdatePasswordNextLogon = 0
        Me.m_QuantObras = 500
        Me.m_QuantEmpresas = 500
        Me.m_IndMaster = 1
        Me.m_intIdGestor = 0
        Me.m_TipoArea = 0

        XMCookie.setEncryptedCookie("sID", m_intID)
        XMCookie.setEncryptedCookie("Usuario", m_strUsuario)
        XMCookie.setEncryptedCookie("IDGrupo", m_intIDGrupo)
        XMCookie.setEncryptedCookie("Authorized", m_intAuthorized)
        XMCookie.setEncryptedCookie("Login", m_strLogin)
        XMCookie.setEncryptedCookie("DataInicioPlano", m_dtmDataInicioPlano)
        XMCookie.setEncryptedCookie("DataFimPlano", m_dtmDataFimPlano)
        XMCookie.setEncryptedCookie("DataUltimoAcesso", m_dtmDataUltimoAcesso)
        XMCookie.setEncryptedCookie("IDEmpresa", m_intIdEmpresa)
        XMCookie.setEncryptedCookie("QuantidadeObras", m_QuantObras)
        XMCookie.setEncryptedCookie("QuantidadeEmpresas", m_QuantEmpresas)
        XMCookie.setEncryptedCookie("Master", m_IndMaster)
        XMCookie.setEncryptedCookie("TipoUsuario", TIPO_USUARIO.MASTER)
        XMCookie.setEncryptedCookie("TipoArea", m_TipoArea)
        XMCookie.setEncryptedCookie("IdGestor", m_intIdGestor)
        XMCookie.setEncryptedCookie("lgGuid", "testeGuid")

    End Sub

    Private Sub Inflate(ByVal row As DataRow)

        Me.m_intID = CInt(0 & row("USU_USUARIO_INT_PK"))
        Me.m_strUsuario = CStr(row("USU_USUARIO_CHR") & "")
        Me.m_strLogin = CStr(row("USU_LOGIN_CHR") & "")
        Me.m_intIDGrupo = CInt(0 & row("IDGRUPO"))
        Me.m_intIdEmpresa = CInt(row("EMP_IDEMPRESA_INT_FK"))
        Me.m_dtmDataInicioPlano = CDate(row("DATAINICIOPLANO"))
        Me.m_dtmDataFimPlano = CDate(row("DATAFIMPLANO"))
        Me.m_dtmDataUltimoAcesso = CDate(row("DATAULTIMOACESSO"))
        Me.m_indUpdatePasswordNextLogon = CInt(0 & row("usu_UpdatePasswordNextLogon_ind"))
        Me.m_QuantObras = CInt(0 & row("QUANTIDADEOBRAS"))
        Me.m_QuantEmpresas = CInt(0 & row("QUANTIDADEEMPRESAS"))
        Me.m_IndMaster = CInt(0 & row("USU_TIPOUSUARIO_INT"))
        Me.m_IndTipoUsuario = CInt(0 & row("USU_TIPOUSUARIO_INT"))
        Me.m_TipoArea = CInt(0 & row("are_Area_int_FK"))
        Me.m_intIdGestor = CInt(0 & row("IdGestor"))
        Me.m_strGuid = CStr(row("Guid") & "")

        Dim m_indAutorizadoNavegacaoUsuario As Integer = CInt(0 & row("RetornoLogin"))

        If Me.m_intID = 0 Then
            Me.m_intAuthorized = enAuthorize.NotAuthorized
        Else
            If m_indAutorizadoNavegacaoUsuario = 1 Then
                If m_indUpdatePasswordNextLogon = 1 Then
                    Me.m_intAuthorized = enAuthorize.SetPassword
                Else
                    Me.m_intAuthorized = enAuthorize.Authorized
                End If
            ElseIf m_indAutorizadoNavegacaoUsuario = 5 Then
                Me.m_intAuthorized = enAuthorize.UserSuspended
            Else
                Me.m_intAuthorized = enAuthorize.UserAlreadyLoggedIn
            End If
        End If

        XMCookie.setEncryptedCookie("sID", m_intID)
        XMCookie.setEncryptedCookie("Usuario", m_strUsuario)
        XMCookie.setEncryptedCookie("IDGrupo", m_intIDGrupo)
        XMCookie.setEncryptedCookie("Authorized", m_intAuthorized)
        XMCookie.setEncryptedCookie("Login", m_strLogin)
        XMCookie.setEncryptedCookie("DataInicioPlano", m_dtmDataInicioPlano)
        XMCookie.setEncryptedCookie("DataFimPlano", m_dtmDataFimPlano)
        XMCookie.setEncryptedCookie("DataUltimoAcesso", m_dtmDataUltimoAcesso)
        XMCookie.setEncryptedCookie("IDEmpresa", m_intIdEmpresa)
        XMCookie.setEncryptedCookie("QuantidadeObras", m_QuantObras)
        XMCookie.setEncryptedCookie("QuantidadeEmpresas", m_QuantEmpresas)
        XMCookie.setEncryptedCookie("Master", m_IndMaster)
        XMCookie.setEncryptedCookie("TipoUsuario", m_IndTipoUsuario)
        XMCookie.setEncryptedCookie("TipoArea", m_TipoArea)
        XMCookie.setEncryptedCookie("IdGestor", m_intIdGestor)
        XMCookie.setEncryptedCookie("lgGuid", m_strGuid)

    End Sub

    Public Function Logout() As Boolean

        XMCookie.deleteCookie("sID")
        XMCookie.deleteCookie("Usuario")
        XMCookie.deleteCookie("IDGrupo")
        XMCookie.deleteCookie("Authorized")
        XMCookie.deleteCookie("Login")
        XMCookie.deleteCookie("IDEmpresa")
        XMCookie.deleteCookie("DataInicioPlano")
        XMCookie.deleteCookie("DataFimPlano")
        XMCookie.deleteCookie("QuantidadeObras")
        XMCookie.deleteCookie("QuantidadeEmpresas")
        XMCookie.deleteCookie("Master")
        XMCookie.deleteCookie("TipoUsuario")
        XMCookie.deleteCookie("TipoArea")
        XMCookie.deleteCookie("IdGestor")
        XMCookie.deleteCookie("lgGuid")

        'XMCookie.SetEncryptedCookie("sID", 0)
        'XMCookie.SetEncryptedCookie("Usuario", "")
        'XMCookie.SetEncryptedCookie("IDGrupo", 0)
        'XMCookie.SetEncryptedCookie("Authorized", enAuthorize.NotAuthorized)
        'XMCookie.SetEncryptedCookie("Login", "")
        'XMCookie.SetEncryptedCookie("IDEmpresa", 0)
        'XMCookie.SetEncryptedCookie("DataInicioPlano", "")
        'XMCookie.SetEncryptedCookie("DataFimPlano", "")
        'XMCookie.SetEncryptedCookie("QuantidadeObras", 0)
        'XMCookie.SetEncryptedCookie("QuantidadeEmpresas", 0)
        'XMCookie.SetEncryptedCookie("Master", 0)

    End Function

    Public Function AddNavigation(ByVal IdEmpresa As Integer, ByVal IdUsuario As Integer, ByVal SessionId As String, ByVal Guid As String)

        ExecuteNonQuery("SP_BS_LOGNAVEGACAOUSUARIO " & IdEmpresa & "," & IdUsuario & ",'" & Guid & "'")

    End Function

    Public Function AddHistory(ByVal IdUsuario As Integer, ByVal IP As String, ByVal Browser As String, ByVal SistemaOperacional As String, ByVal Descricao As String)
        ExecuteNonQuery("SP_BS_ADDHISTORY " & IdUsuario & ",'" & IP & "','" & Browser & "','" & SistemaOperacional & "','" & Descricao & "'")
    End Function

    Public Function Authenticate(ByVal vLogin As String, ByVal vPassword As String, ByVal vGuid As String) As enAuthorize

        Return Authenticate(vLogin, vPassword, vGuid, 0)

    End Function

    Public Function Authenticate(ByVal vLogin As String, ByVal vPassword As String, ByVal vGuid As String, ByVal vUltimoAcesso As Integer) As enAuthorize

        Dim myData As DataSet
        Dim iReturnValue As Integer = 0
        'Dim UltimoAcesso As Integer = 0

        Dim cmdLogin As SqlParameter = New SqlParameter("@LOGIN", SqlDbType.VarChar, 20)
        cmdLogin.Value = vLogin.Replace("'", "''")

        Dim cmdSenha As SqlParameter = New SqlParameter("@SENHA", SqlDbType.VarChar, 10)
        cmdSenha.Value = vPassword.Replace("'", "''")

        Dim cmdUltimoAcesso As SqlParameter = New SqlParameter("@CONFEREULTIMOACESSO", SqlDbType.Int)
        cmdUltimoAcesso.Value = vUltimoAcesso

        Dim cmdGuid As SqlParameter = New SqlParameter("@GUID", SqlDbType.VarChar, 500)
        cmdGuid.Value = vGuid

        Dim parameters As SqlParameter() = {cmdLogin, cmdSenha, cmdUltimoAcesso, cmdGuid}
        Dim sql As String = "SP_SE_LOGIN"

        myData = GetDataSet(sql, parameters, iReturnValue)

        If myData.Tables(0).Rows.Count <= 0 Then
            Clear()
            Me.m_intAuthorized = enAuthorize.NotAuthorized
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
        m_QuantObras = 0
        m_QuantEmpresas = 0
        m_IndMaster = 0
        m_IndTipoUsuario = ITC_Global.TIPO_USUARIO.USUARIO
        m_strGuid = ""
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
            Throw New Exception(e.Message)
        Catch e As Exception
            LogError(e, "DataClass")
            Throw New Exception(e.Message)
        Finally
            Close()
        End Try
        Return myData

    End Function

    Public Function GetDataSet(ByVal SQL As String, ByVal Params As IDataParameter(), ByRef iReturn_Value As Integer) As DataSet

        Dim ds As New DataSet

        Try

            Dim prm As SqlParameter
            Open()

            Dim da As New SqlDataAdapter(SQL, Connection)
            With da
                .SelectCommand.Parameters.Clear()
                .SelectCommand.CommandType = CommandType.StoredProcedure
                .SelectCommand.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, 0, 0, String.Empty, DataRowVersion.Default, Nothing))
                For Each prm In Params
                    .SelectCommand.Parameters.Add(prm)
                Next
                .Fill(ds, "data")
                iReturn_Value = .SelectCommand.Parameters("ReturnValue").Value()
            End With

            Return ds

        Catch e As Exception
            LogError(e, "DataClass")
        Finally
            Close()
        End Try

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

    Public Function ExecuteScalar(ByVal SQL As String) As Object
        Open()
        Dim myCommand As New SqlCommand
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        ExecuteScalar = myCommand.ExecuteScalar()
        'clean up
        Close()
        myCommand.Dispose()
    End Function

    Public Function ExecuteReader(ByVal SQL As String) As SqlDataReader
        Open()
        Dim myCommand As New SqlCommand
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        ExecuteReader = myCommand.ExecuteReader
    End Function

    Protected ReadOnly Property ConnectionString() As String

        Get
            'Dim strTemp As String = System.Environment.CurrentDirectory
            'Dim dom As New System.Xml.XmlDocument()
            'dom.Load(strTemp & "\xmconfig.xml")
            'Return dom.SelectSingleNode("/AppConfig/Database/ConnectionString").InnerXml.Replace(Chr(10), "").Replace(Chr(9), "").Trim
            Dim xmc As New XMLConfig
            Return xmc.GetValue("ConnectionString", "", False)
            'Return "Server=200.204.169.79;UID=xmlink;PWD=xm;Database=ITC"
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

    Public Shared Sub setEncryptedCookie(ByVal key As String, ByVal value As String)
        key = XMCrypto.Encrypt(key)
        value = XMCrypto.Encrypt(value)
        setCookie(key, value)
    End Sub

    Public Shared Sub setEncryptedCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)
        key = XMCrypto.Encrypt(key)
        value = XMCrypto.Encrypt(value)
        setCookie(key, value, expires)
    End Sub

    Public Shared Sub setCookie(ByVal key As String, ByVal value As String)
        key = HttpContext.Current.Server.UrlEncode(key)
        value = HttpContext.Current.Server.UrlEncode(value)
        Dim cookie As HttpCookie
        cookie = New HttpCookie(key, value)
        setCookie(cookie)
    End Sub

    Public Shared Sub setCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)
        key = HttpContext.Current.Server.UrlEncode(key)
        value = HttpContext.Current.Server.UrlEncode(value)
        Dim cookie As HttpCookie
        cookie = New HttpCookie(key, value)
        cookie.Expires = expires
        setCookie(cookie)
    End Sub

    Public Shared Sub setCookie(ByVal cookie As HttpCookie)
        HttpContext.Current.Response.Cookies.Set(cookie)
    End Sub

    Public Shared Function getEncryptedCookieValue(ByVal key As String) As String
        'key = System.Web.HttpUtility.HtmlDecode(key)
        key = XMCrypto.Encrypt(key)
        Dim value As String
        value = getCookieValue(key)
        value = XMCrypto.Decrypt(value)
        Return value
    End Function

    Public Shared Function getCookie(ByVal key As String) As HttpCookie
        key = HttpContext.Current.Server.UrlEncode(key)
        Return HttpContext.Current.Request.Cookies.Get(key)
    End Function

    Public Shared Function getCookieValue(ByVal key As String) As String
        Try
            Dim value As String
            value = getCookie(key).Value
            value = HttpContext.Current.Server.UrlDecode(value)
            Return value
        Catch
        End Try
    End Function

    Public Shared Sub deleteCookie(ByVal key As String)
        HttpContext.Current.Response.Cookies.Remove(key)
    End Sub

End Class

'Public Class XMCookie

'    Protected Const COOKIENAME As String = "ITCCOOKIE"

'    Public Sub New()
'    End Sub

'    Public Shared Sub setEncryptedCookie(ByVal key As String, ByVal value As String)

'        key = XMCrypto.Encrypt(key)
'        value = XMCrypto.Encrypt(value)
'        setCookie(key, value)

'    End Sub

'    'Public Shared Sub setEncryptedCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)

'    '    key = XMCrypto.Encrypt(key)
'    '    value = XMCrypto.Encrypt(value)
'    '    setCookie(key, value, expires)

'    'End Sub

'    Public Shared Sub setCookie(ByVal key As String, ByVal value As String)

'        Dim m_Cookie As HttpCookie
'        m_Cookie = HttpContext.Current.Request.Cookies.Get(COOKIENAME)
'        If m_Cookie Is Nothing Then
'            m_Cookie = New HttpCookie(COOKIENAME)
'        End If

'        key = HttpContext.Current.Server.UrlEncode(key)
'        value = HttpContext.Current.Server.UrlEncode(value)
'        m_Cookie.Values.Item(key) = value
'        HttpContext.Current.Response.Cookies.Add(m_Cookie)

'        'Dim cookie As HttpCookie
'        'cookie = New HttpCookie(key, value)
'        'setCookie(cookie)

'    End Sub

'    'Public Shared Sub setCookie(ByVal key As String, ByVal value As String, ByVal expires As Date)
'    '    key = HttpContext.Current.Server.UrlEncode(key)
'    '    value = HttpContext.Current.Server.UrlEncode(value)
'    '    Dim cookie As HttpCookie
'    '    cookie = New HttpCookie(key, value)
'    '    cookie.Expires = expires
'    '    setCookie(cookie)
'    'End Sub

'    'Public Shared Sub setCookie(ByVal cookie As HttpCookie)
'    '    HttpContext.Current.Response.Cookies.Set(cookie)
'    'End Sub

'    Public Shared Function getEncryptedCookieValue(ByVal key As String) As String
'        key = XMCrypto.Encrypt(key)
'        Dim value As String
'        value = getCookieValue(key)
'        value = XMCrypto.Decrypt(value)
'        Return value
'    End Function

'    Public Shared Function getCookie(ByVal key As String) As HttpCookie
'        key = HttpContext.Current.Server.UrlEncode(key)
'        Return HttpContext.Current.Request.Cookies.Get(key)
'    End Function

'    Public Shared Function getCookieValue(ByVal key As String) As String
'        Try
'            Dim value As String
'            value = getCookie(key).Value
'            value = HttpContext.Current.Server.UrlDecode(value)
'            Return value
'        Catch
'        End Try
'    End Function

'    Public Shared Sub deleteCookie(ByVal key As String)
'        HttpContext.Current.Response.Cookies.Remove(key)
'    End Sub

'End Class