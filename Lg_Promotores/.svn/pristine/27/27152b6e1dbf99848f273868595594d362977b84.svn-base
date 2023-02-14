
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Lojas
        Inherits XMWebPage
        Dim cls As clsLoja
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsLoja()

            If Not Page.IsPostBack Then

                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                'Bind Combos
                Dim cli As New clsCliente
                cboIDCliente.DataSource = cli.Listar
                cboIDCliente.DataBind()
                cboIDCliente.Items.Insert(0, New ListItem("TODAS", 0))
                cli = Nothing

                Dim uf As New clsEstado
                cboUF.DataSource = uf.Listar
                cboUF.DataBind()
                cboUF.Items.Insert(0, New ListItem("TODOS", ""))
                uf = Nothing

                Dim sho As New clsShopping
                cboIDShopping.DataSource = sho.Listar
                cboIDShopping.DataBind()
                cboIDShopping.Items.Insert(0, New ListItem("TODAS", 0))
                cboIDShopping.Items.Insert(0, New ListItem("LOJAS DE RUA", -1))
                cboIDShopping.SelectedValue = 0
                sho = Nothing


                Dim tlj As New clsTipoLoja
                cboIDTipoLoja.DataSource = tlj.Listar
                cboIDTipoLoja.DataBind()
                cboIDTipoLoja.Items.Insert(0, New ListItem("TODOS", 0))
                tlj = Nothing

                Dim reg As New clsRegiao
                cboIDRegiao.DataSource = reg.Listar
                cboIDRegiao.DataBind()
                cboIDRegiao.Items.Insert(0, New ListItem("TODAS", 0))
                reg = Nothing

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboIDCliente, cboUF, cboIDTipoLoja, cboIDShopping, cboIDRegiao)
                BindGrid()

            End If

        End Sub
        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, cboIDCliente.SelectedValue, cboUF.SelectedValue, cboIDTipoLoja.SelectedValue, cboIDShopping.SelectedValue, cboIDRegiao.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1, cboIDCliente, cboUF, cboIDTipoLoja, cboIDShopping, cboIDRegiao)

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

