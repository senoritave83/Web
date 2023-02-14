Public Class cadastros
    Inherits XMProtectedPage
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected tdCadUsuarios As System.Web.UI.HtmlControls.HtmlTableCell

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
            If CheckPermission("Acesso do Sistema", "Visualizar Cadastros") = False Then
                Response.Redirect("principal.aspx")
            End If

            If CheckPermission("Cadastro de Usuarios", "Visualizar") Then
                tdCadUsuarios.Visible = True
            End If
        End If

    End Sub

End Class
