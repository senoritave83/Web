Public Class EmpresasVersao
    Inherits XMWebPage
    Private Empresas As New clsEmpresas(0)
    Protected WithEvents dtgEmpresasVersoes As DataGrid
    Private ds As DataSet

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindDataGrid()
    End Sub

    Private Sub BindDataGrid()
        ds = Empresas.ListVersoes(Empresas.Codigo)
        dtgEmpresasVersoes.DataSource = ds
        dtgEmpresasVersoes.DataBind()
    End Sub

End Class
