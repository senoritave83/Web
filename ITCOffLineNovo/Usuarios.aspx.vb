Imports ITCOffLine

Public Class Usuarios

    Inherits XMWebPage

    Protected WithEvents btnProcurar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Barra As BarraBotoes2
    Private Usuarios As New clsUsuario()

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
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        dtgUsuarios.DataSource = Usuarios.List(txtNome.Text, txtLogin.Text)
        dtgUsuarios.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        BindGrid()
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("UsuariosDet.aspx?Codigo=0")
    End Sub

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        BindGrid()
    End Sub
End Class
