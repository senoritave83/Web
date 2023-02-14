Public Class UsuariosSistema
    Inherits XMWebPage
    Protected WithEvents dtgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes As BarraBotoes
    Private Usuarios As clsUsuario
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
        If Not Page.IsPostBack Then
            Usuarios = New clsUsuario()
            BindGrid()
            Usuarios = Nothing
            'BarraBotoes.AtivarBotoes(IIf(CheckPermission("Usuários do Sistema", "Adicionar"), BarraBotoes.Botoes_Ativos.Incluir, 0))
            'BarraBotoes.AtivarBotoes(BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Private Sub BindGrid()
        dtgUsuarios.DataSource = Usuarios.ListUsuariosSistema(0)
        dtgUsuarios.DataBind()
    End Sub

    Private Sub BarraBotoes_Incluir() Handles BarraBotoes.Incluir
        Response.Redirect("UsuariosSistemaDet.aspx?IdUsuario=0")
    End Sub

End Class
