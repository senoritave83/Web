Imports Classes


Partial Class formulario_Default
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindPromotores()
        End If

    End Sub



#Region "LISTA PROMOTORES"


    Protected Sub BindPromotores()
        GridView1.SelectedIndex = -1
        Dim clsProm As New clsUsuario
        Dim ret As IPaginaResult = clsProm.Listar(Paginate1.Filtro, 0, FiltroSuperior1.IDSuperior, clsUsuario.enOpcaoTeste.Todos, "", clsUsuario.enOpcaoStatus.Ativos, 2, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing
    End Sub


    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindPromotores()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Paginate1.CurrentPage = 0
        Letras1.Letra = ""
        Paginate1.Filtro = txtFiltro.Text
        BindPromotores()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindPromotores()
    End Sub


    Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
        Paginate1.CurrentPage = 0
        Paginate1.Filtro = vLetra
        BindPromotores()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindPromotores()
    End Sub


    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Paginate1.SortExpression = e.SortExpression
    End Sub


#End Region

End Class
