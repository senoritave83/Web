
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Clientes
        Inherits XMWebPage

        Protected Const SECAO As String = "Cadastro de Clientes"
		Dim cls As clsCliente
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCliente()
            If Not Page.IsPostBack Then
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)

                'Bind Combos
                Dim uf As New clsUF
                cboUF.DataSource = uf.Listar
                cboUF.DataBind()
                cboUF.Items.Insert(0, New ListItem("TODOS", ""))
				uf = Nothing

                Dim pas As New clsPasta
                cboIDPasta.DataSource = pas.Listar
                cboIDPasta.DataBind()
                cboIDPasta.Items.Insert(0, New ListItem("TODOS", 0))
				pas = Nothing

                Dim blq As New clsBloqueio
                cboIDBloqueio.DataSource = blq.Listar
                cboIDBloqueio.DataBind()
                cboIDBloqueio.Items.Insert(0, New ListItem("TODOS", 0))
				blq = Nothing

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboIDPasta, cboIDBloqueio)
                BindGrid()
            End If			
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, cboUF.selectedValue, cboIDPasta.selectedValue, cboIDBloqueio.selectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
			ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1, cboUF, cboIDPasta, cboIDBloqueio)
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

End Namespace

