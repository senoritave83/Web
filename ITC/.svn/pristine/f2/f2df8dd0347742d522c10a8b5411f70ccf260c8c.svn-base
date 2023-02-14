Public Class gravado1

    Inherits XMWebPage
    Protected WithEvents btnVoltar As LinkButton
    Protected WithEvents frmGravado As System.Web.UI.HtmlControls.HtmlForm

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            If Request("ft") <> "" Then
                ViewState("Close") = "1"
            Else
                ViewState("Volta") = Request("v")
            End If

        End If
    End Sub

    Private Sub btnVoltar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        If ViewState("Close") = "1" Then
            Response.Write("<script language='javascript'>{ window.opener.xmRefresh();window.close(); }</script>")
        Else
            Response.Redirect(ViewState("Volta"))
        End If

    End Sub
End Class
