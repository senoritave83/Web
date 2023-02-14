
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Perguntas
        Inherits XMWebPage
        Dim cls As clsPergunta
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPergunta()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                BindGrid()
            End If			
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(txtFiltro.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
			ret = Nothing
		End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub

    End Class

End Namespace

