Public MustInherit Class BarraLateral

    Inherits System.Web.UI.UserControl

    Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink4 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink5 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink6 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink7 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink8 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink9 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink10 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink11 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink12 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink13 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink14 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink15 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink16 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink17 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink18 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink19 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink20 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink21 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink22 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink23 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink24 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Login1 As Login

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
    End Sub

    Public Sub MostraLogin(Optional ByVal p_Mostra As Boolean = True)
        Login1.Visible = p_Mostra
    End Sub

End Class
