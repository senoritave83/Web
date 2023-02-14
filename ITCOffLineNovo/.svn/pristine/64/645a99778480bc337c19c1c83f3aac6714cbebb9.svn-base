Imports ITCOffLine

Public Class Grupos
    Inherits XMWebPage
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFiltro As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgCargo As System.Web.UI.WebControls.DataGrid
    Protected cls As clsGrupos
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
        cls = New clsGrupos()
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Sub DataGrid_Page(ByVal Sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgCargo.CurrentPageIndex = e.NewPageIndex
        BindGrid()
    End Sub


    Sub BindGrid()
        dtgCargo.DataSource = cls.List()
        dtgCargo.DataBind()
    End Sub


End Class
