
Imports Classes


Namespace Pages.Cadastros

    Partial Public Class CatalogoProdutos
        Inherits XMWebPage

        Dim cls As clsCatalogoProduto
        Protected Const WID_SECAO As String = "Cadastro de Catálogo de Produtos"
     
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCatalogoProduto()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(WID_SECAO, ACAO_ADICIONAR)

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(txtFiltro.Text, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1)
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            Letras1.Letra = ""
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub


        Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
            Paginate1.CurrentPage = 0
            txtFiltro.Text = ""
            BindGrid()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            SortExpression = e.SortExpression
        End Sub

        Protected Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                ViewState("SortExpression") = value
            End Set
        End Property

        Protected Property SortDirection() As SortDirection
            Get
                If ViewState("SortDirection") Is Nothing Then
                    Return WebControls.SortDirection.Ascending
                Else
                    Return ViewState("SortDirection")
                End If
            End Get
            Set(ByVal value As SortDirection)
                ViewState("SortDirection") = value
            End Set
        End Property

    End Class

End Namespace

