Imports ITCOffLine

Public Class Produtos

    Inherits XMWebPage
    Private Prod As clsProdutos

    Protected WithEvents dtgProdutos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents btnProcurar As Button
    Protected WithEvents txtProduto As System.Web.UI.WebControls.TextBox
    Protected WithEvents BarraNavegacao As BarraNavegacao

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
            Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Produtos", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0))
        End If
    End Sub

    Private Sub BindGrid()
        dtgProdutos.DataSource = Prod.ListProdutos(txtProduto.Text)
        dtgProdutos.DataBind()
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        dtgProdutos.CurrentPageIndex = 0
        Prod = New clsProdutos()
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao.NextReg
        If (dtgProdutos.CurrentPageIndex < (dtgProdutos.PageCount - 1)) Then
            dtgProdutos.CurrentPageIndex += 1
        End If
        Prod = New clsProdutos()
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao.LastReg
        dtgProdutos.CurrentPageIndex = (dtgProdutos.PageCount - 1)
        Prod = New clsProdutos()
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao.FirstReg
        dtgProdutos.CurrentPageIndex = 0
        Prod = New clsProdutos()
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao.PreviousReg
        If (dtgProdutos.CurrentPageIndex > 0) Then
            dtgProdutos.CurrentPageIndex -= 1
        End If
        Prod = New clsProdutos()
        BindGrid()
        Prod = Nothing
    End Sub

    Private Sub Barra_Incluir() Handles Barra.Incluir

        Response.Redirect("ProdutosDet.aspx")

    End Sub

End Class
