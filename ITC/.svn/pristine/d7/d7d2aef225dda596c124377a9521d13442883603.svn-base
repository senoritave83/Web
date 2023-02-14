
Public Class Produtos

    Inherits XMWebPage
    Private Prod As clsProdutos

    Protected WithEvents dtgProdutos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnProcurar As Button
    Protected WithEvents btnIncluir As Button
    Protected WithEvents txtProduto As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblNav As HtmlTable
    Protected WithEvents nav As BarraNavegacao

    Private ds As DataSet

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
            tblNav.Visible = False
            IIf(CheckPermission("Cadastro de Produtos", "Adicionar"), btnIncluir.Visible = True, btnIncluir.Visible = False)
        End If
    End Sub

    'Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
    '    dtgProdutos.CurrentPageIndex = e.NewPageIndex
    '    BindGrid()
    '    Prod = Nothing
    'End Sub

    Private Sub BindGrid()
        ds = Prod.ListProdutos(txtProduto.Text)
        dtgProdutos.DataSource = ds
        dtgProdutos.DataBind()
    End Sub

    Private Sub BarraNavegacao_NextReg() Handles nav.NextReg
        If (dtgProdutos.CurrentPageIndex < (dtgProdutos.PageCount - 1)) Then
            dtgProdutos.CurrentPageIndex += 1
        End If
        Prod = New clsProdutos
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao_LastReg() Handles nav.LastReg
        dtgProdutos.CurrentPageIndex = (dtgProdutos.PageCount - 1)
        Prod = New clsProdutos
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao_FirstReg() Handles nav.FirstReg
        dtgProdutos.CurrentPageIndex = 0
        Prod = New clsProdutos
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao_PreviousReg() Handles nav.PreviousReg
        If (dtgProdutos.CurrentPageIndex > 0) Then
            dtgProdutos.CurrentPageIndex -= 1
        End If
        Prod = New clsProdutos
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        tblNav.Visible = True
        dtgProdutos.CurrentPageIndex = 0
        Prod = New clsProdutos
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Response.Redirect("ProdutosDet.aspx")
    End Sub
End Class
