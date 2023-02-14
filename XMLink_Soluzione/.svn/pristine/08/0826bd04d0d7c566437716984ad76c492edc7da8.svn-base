Public MustInherit Class inc_menu
    Inherits System.Web.UI.UserControl
    Protected WithEvents tblMenu As System.Web.UI.HtmlControls.HtmlTable
    Protected lblUsuarioLogado As System.Web.UI.WebControls.Label
    Protected lnkrelatorios As System.Web.UI.HtmlControls.HtmlAnchor
    Protected lnkcadastros As System.Web.UI.HtmlControls.HtmlAnchor
    Protected lnkconfiguracoes As System.Web.UI.HtmlControls.HtmlAnchor
    Protected lnkvisitas As System.Web.UI.HtmlControls.HtmlAnchor


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



    End Sub

    Public Sub SetUser(ByVal value As UsuarioLogged)
        If value.IDUsuario < 1 Then
            tblMenu.Visible = False

            lnkrelatorios.Visible = False
            lnkcadastros.Visible = False
            lnkconfiguracoes.Visible = False
            lnkvisitas.Visible = False
        Else
            tblMenu.Visible = True
            lblUsuarioLogado.Text = value.Login
            fncGetMenu(value)
        End If
    End Sub

    Private Function fncGetMenu(ByVal vUsuario As UsuarioLogged)

        lnkrelatorios.Visible = vUsuario.CheckPermission("Acesso do Sistema", "Visualizar Relatórios")

        lnkcadastros.Visible = vUsuario.CheckPermission("Acesso do Sistema", "Visualizar Cadastros")

        lnkconfiguracoes.Visible = vUsuario.CheckPermission("Acesso do Sistema", "Configurações do Sistema")

        lnkvisitas.Visible = vUsuario.CheckPermission("Acesso do Sistema", "Visualizar Visitas")
    End Function



End Class
