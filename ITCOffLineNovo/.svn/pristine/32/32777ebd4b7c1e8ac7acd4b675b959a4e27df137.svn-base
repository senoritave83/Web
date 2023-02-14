Imports ITCOffLine

Public Class gravado1

    Inherits XMWebPage
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm

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
            ViewState("Volta") = Request("v")
        End If
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Page.Response.Redirect(ViewState("Volta"))
    End Sub

End Class
