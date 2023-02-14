Imports System.Net.Mail

Public Class XMWebPage
    Inherits System.Web.UI.Page
    Private m_LoggedIn As Boolean = False
    Private m_Identity As clsIdentity


    Public ReadOnly Property Identity() As clsIdentity
        Get
            If (m_Identity Is Nothing) Then
                m_Identity = New clsIdentity
            End If
            Return m_Identity
        End Get
    End Property

    Public Function IsAdmin() As Boolean
        Return Me.Identity.Administrador
    End Function

    Public Function GetSetting(ByVal vKey As String, ByVal vDefault As String) As String
        Dim cfg As New System.Configuration.AppSettingsReader
        Try
            Return cfg.GetValue(vKey, GetType(System.String))
        Catch e As Exception
            Return vDefault
        End Try
        cfg = Nothing
    End Function

    Public ReadOnly Property MaxSizeList() As Integer
        Get
            Return CInt("0" & System.Configuration.ConfigurationManager.AppSettings("MaxSizeClientList"))
        End Get
    End Property


    Public Sub ShowError(ByVal vError As String)
        Response.Redirect("~/home/mostraerro.aspx?Volta=" & Server.UrlEncode(Request.Url.ToString) & "&Erro=" & Server.UrlEncode(vError), True)
    End Sub

    Public Sub ShowMsg(ByVal vCaption As String)
        Response.Write("<script>alert('" & vCaption & "');</script>")
    End Sub

    Public Overridable Function CheckPermission(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        Return True
    End Function

    Public Sub SendMessage(ByVal vMessage As MailMessage)
        Dim smtp As New SmtpClient()
        smtp.Send(vMessage)
    End Sub

    Private Function GetPage(ByVal vURL As String) As String
        Dim req As Net.HttpWebRequest
        Dim rsp As Net.HttpWebResponse
        Try
            req = Net.WebRequest.Create(vURL)
            rsp = req.GetResponse
            Dim str As New IO.StreamReader(rsp.GetResponseStream())
            GetPage = str.ReadToEnd
            rsp.Close()
        Catch e As Exception
            GetPage = ""
        End Try
        rsp = Nothing
        req = Nothing
    End Function

    Public Sub SendEmailConfirmacao(ByVal Msg_IdEmpresa As Integer, ByVal Msg_Usuario As String, ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_From As String, ByVal Msg_Body As String)

        Dim ut As New Util
        ut.SendEmailConfirmacao(Msg_IdEmpresa, Msg_Usuario, Msg_Subject, Msg_To, Msg_From, Msg_Body)
        ut = Nothing

    End Sub

    Public Sub SendSMS(ByVal vTelefone As String, ByVal vMensagem As String)
        Dim strURL As String = GetSetting("SMSServer", "")
        If strURL <> "" Then
            strURL = strURL.Replace("[mensagem]", vMensagem)
            strURL = strURL.Replace("[ddd]", vTelefone.Substring(0, 2))
            strURL = strURL.Replace("[phone]", vTelefone.Substring(2))
        End If
        GetPage(strURL)

        'GetPage("http://www.nextel.com.br/smsweb/gateway/Queue.aspx?_apkey=d79941aa-0be2-4e1d-b56e-de5632c266b7&_apmtp=1&_apusr=Felipe&_appwd=felipe&_bdmsg=" & vMensagem & "&_clddd=" & Left(vNextel, 2) & "&_clphone=" & Right(vNextel, 8), False)

    End Sub

    Public Sub MostraGravado(ByVal vVolta As String)
        Response.Redirect(vVolta, True)
        'Response.Redirect("gravado.aspx?Volta=" & Server.UrlEncode(vVolta), True)
    End Sub

    Public Sub PostRedirect(ByVal URL As String)
        Dim vFields() As String
        Dim strHTML As String

        Dim i, j As Integer
        j = InStr(URL, "?")
        strHTML = "<html><body><form name='frm' action='" & URL.Substring(0, j - 1) & "' method='POST'>" & vbCrLf
        vFields = Split(URL.Substring(j), "&")
        For i = 0 To UBound(vFields)
            j = InStr(vFields(i), "=")
            strHTML &= "<input type='hidden' name='" & vFields(i).Substring(0, j - 1) & "' value='" & Server.UrlDecode(vFields(i).Substring(j)) & "'>" & vbCrLf
        Next
        If GetSetting("debug", "False") = "True" Then
            strHTML &= "<input type='submit' Value='Enviar'></form></body></html>" & vbCrLf
        Else
            strHTML &= "</form><script>document.frm.submit();</script></body></html>" & vbCrLf
        End If
        Response.Clear()
        Response.Write(strHTML)
        Response.End()
    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub
End Class


Public Class XMProtectedPage
    Inherits XMWebPage


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetNoStore()



        If Identity.Logado = False Then
            Dim StrPath, StrQS As String
            StrPath = Request.Path
            StrQS = Request.ServerVariables("QUERY_STRING")
            StrPath = StrPath & IIf(StrQS = "", "", "?" & StrQS)
            If Me.Request.Url.LocalPath.ToLower.EndsWith("listaos.aspx") Then
                Me.Response.Write("<script style='text/javascript'>window.parent.reload();</script>")
            Else
                Response.Redirect("~/inicio/login.aspx" & IIf(StrPath = "", "", "?RedirectTo=" & Server.UrlEncode(StrPath)), True)
            End If
        End If
    End Sub

    Public Overrides Function CheckPermission(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        Return Identity.Administrador
    End Function

    Public Sub GravaFiltro(ByVal ParamArray vControls() As Control)
        Dim cookie As New HttpCookie("FILTRO")
        cookie.Values.Add("URL", Request.Path)
        For Each ctr As Control In vControls
            If ctr.GetType Is GetType(TextBox) Then
                cookie.Values.Add(ctr.ID, CType(ctr, TextBox).Text)
            ElseIf ctr.GetType Is GetType(DropDownList) Then
                cookie.Values.Add(ctr.ID, CType(ctr, DropDownList).SelectedValue)
            ElseIf TypeOf ctr Is IFiltroControl Then
                cookie.Values.Add(ctr.ID, CType(ctr, IFiltroControl).Value)
            ElseIf TypeOf ctr Is ListControl Then
                Dim strValues As String = ""
                For Each it As ListItem In CType(ctr, ListControl).Items
                    If it.Selected Then strValues &= IIf(strValues = "", "", ",") & it.Value
                Next
                cookie.Values.Add(ctr.ID, strValues)
            End If
        Next

        Response.Cookies.Add(cookie)
    End Sub

    Public Function RecuperaFiltro(ByVal ParamArray vControls() As Control) As Boolean

        Dim cookie As HttpCookie = Request.Cookies.Item("FILTRO")
        If Not cookie Is Nothing Then
            If cookie.Values("URL").ToLower() = Request.Path.ToLower() Then
                For Each ctr As Control In vControls
                    If ctr.GetType Is GetType(TextBox) Then
                        CType(ctr, TextBox).Text = cookie.Values(ctr.ID)
                    ElseIf ctr.GetType Is GetType(DropDownList) Then
                        setComboValue(ctr, cookie.Values(ctr.ID))
                    ElseIf TypeOf ctr Is IFiltroControl Then
                        CType(ctr, IFiltroControl).Value = cookie.Values(ctr.ID)
                    ElseIf TypeOf ctr Is ListControl Then
                        Dim strValues As String = "," & cookie.Values(ctr.ID) & ","
                        For Each it As ListItem In CType(ctr, ListControl).Items
                            it.Selected = (InStr(strValues, "," & it.Value & ",") > 0)
                        Next
                        cookie.Values.Add(ctr.ID, strValues)
                    End If
                Next
                Return True
            End If
        End If
        Return False
    End Function

End Class