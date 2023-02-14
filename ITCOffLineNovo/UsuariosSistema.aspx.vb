Imports ITCOffLine

Public Class UsuariosSistema
    Inherits XMWebPage
    Protected WithEvents dtgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Barra As BarraBotoes2
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
            Barra.AtivarBotoes(IIf(CheckPermission("Usuários do Sistema", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0))
        End If
    End Sub

    Private Sub BindGrid()
        dtgUsuarios.DataSource = Usuarios.ListUsuariosSistema()
        dtgUsuarios.DataBind()
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("UsuariosSistemaDet.aspx?IdUsuario=0")
    End Sub

End Class
