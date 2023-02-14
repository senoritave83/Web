
Imports Classes


Namespace Pages.Cadastros

    Partial Public Class CampoAdicionais
        Inherits XMWebPage
        Dim cls As clsCampoAdicional
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCampoAdicional()
            If Not Page.IsPostBack Then
                btnNovo.Enabled = VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                Me.RecuperaFiltro(cboEntidade, txtFiltro, Paginate1, Letras1, cboAtivo)
                BindGrid()
            End If			
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(cboEntidade.SelectedValue, Paginate1.Filtro, cboAtivo.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
			ret = Nothing

            Me.GravaFiltro(cboEntidade, txtFiltro, Letras1, Paginate1, cboAtivo)
		End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Protected Sub cboEntidade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntidade.SelectedIndexChanged
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub

        Protected Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            Letras1.Letra = ""
            Paginate1.Filtro = cboEntidade.SelectedValue
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

        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            Response.Redirect("CampoAdicional.aspx?idcampoadicional=0&entidade=" & cboEntidade.SelectedValue)
        End Sub
    End Class

End Namespace

