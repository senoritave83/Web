Imports XMSistemas.Web.Base

Partial Class home_selcliente
    Inherits XMWebPage

    Protected Const PageSize As Integer = 20

    Protected cli As clsClientes


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Identity.Logado = False Then
            ltrScript.Text = "<script>self.close();</script>"
            Exit Sub
        End If
        cli = New clsClientes()
        If Not IsPostBack Then
            txtFiltro.Text = Request("Filtro")

            ViewState("Desc") = 0 'False
            ViewState("Sort") = "Cliente"
            ViewState("Type") = Request("type")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
        End If
        BindGrid()
    End Sub

    Private Sub BindGrid()
        'Dim ret As IPaginaResult = cli.ListarClientes(Paginate1.CurrentPage, 20, txtFiltro.Text)
        Dim ret As IPaginaResult = cli.ListarClientes(ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"), txtFiltro.Text)
        dtgGrid.DataSource = ret.Tables(0)
        dtgGrid.DataBind()
        dtgGrid.Visible = (dtgGrid.Items.Count > 0)
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        lblMensagem.Visible = Not dtgGrid.Visible
        btnLimpar.Visible = (txtFiltro.Text <> "")
    End Sub

    Private Sub dtgGrid_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dtgGrid.SortCommand
        ViewState("Sort") = e.SortExpression
        ViewState("Desc") = IIf(ViewState("Desc") = 0, 1, 0)
        BindGrid()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindGrid()
    End Sub

    Protected Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLimpar.Click
        txtFiltro.Text = ""
        Paginate1.CurrentPage = 0
        BindGrid()
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub
End Class
