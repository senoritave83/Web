Imports Classes

Partial Class Roteiros_Default
    Inherits XMWebPage
    Dim cls As clsUsuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsUsuario()
        If Not Page.IsPostBack Then

            'Bind Combos
            Dim uf As New clsEstado
            cboUF.DataSource = uf.Listar
            cboUF.DataBind()
            cboUF.Items.Insert(0, New ListItem("TODOS", ""))
            uf = Nothing

            Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboUF, FiltroSuperior1, cboTeste)

            BindGrid()

        End If
    End Sub

    Public Sub BindGrid()
        Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, 0, FiltroSuperior1.IDSuperior, cboTeste.SelectedValue, cboUF.SelectedValue, clsUsuario.enOpcaoStatus.Todos, 2, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE, DataClass.enReturnType.DataReader)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

        Me.GravaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboTeste, FiltroSuperior1)
    End Sub


    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Paginate1.CurrentPage = 0
        Letras1.Letra = ""
        Paginate1.Filtro = txtFiltro.Text
        BindGrid()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindGrid()
    End Sub


    Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
        Paginate1.CurrentPage = 0
        Paginate1.Filtro = vLetra
        txtFiltro.Text = ""
        BindGrid()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindGrid()
    End Sub

    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Paginate1.SortExpression = e.SortExpression
    End Sub



End Class
