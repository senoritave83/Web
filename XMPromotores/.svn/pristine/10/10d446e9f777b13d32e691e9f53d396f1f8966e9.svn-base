
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produtos
        Inherits XMWebPage
        Dim cls As clsProduto
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsProduto()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)

                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("TODOS", 0))
                cat = Nothing

                Dim sct As New clsSubCategoria
                cboIDSubCategoria.DataSource = sct.Listar(0)
                cboIDSubCategoria.DataBind()
                cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", 0))
                sct = Nothing

                Dim frn As New clsFornecedor
                cboIDFornecedor.DataSource = frn.Listar
                cboIDFornecedor.DataBind()
                cboIDFornecedor.Items.Insert(0, New ListItem("TODAS", 0))
                frn = Nothing

                If Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboIDCategoria, cboIDSubCategoria, cboIDFornecedor) Then
                    Dim iValue As Integer = cboIDSubCategoria.SelectedValue
                    sct = New clsSubCategoria
                    cboIDSubCategoria.DataSource = sct.Listar(CInt(cboIDCategoria.SelectedValue))
                    cboIDSubCategoria.DataBind()
                    cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", 0))
                    sct = Nothing
                    setComboValue(cboIDSubCategoria, iValue)
                End If

                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, CInt(cboIDCategoria.SelectedValue), CInt(cboIDSubCategoria.SelectedValue), CInt(cboIDFornecedor.SelectedValue), clsFornecedor.vOpcaoConcorrente.Todos, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE, rdStatusProduto.SelectedItem.Value, DataClass.enReturnType.DataReader)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1, cboIDCategoria, cboIDSubCategoria, cboIDFornecedor)

        End Sub

        Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs)

            If e.CommandName = "UP" Then
                Dim intIdProduto As Integer = e.CommandArgument
                cls.TrocarOrdem(intIdProduto, 1)
            ElseIf e.CommandName = "DOWN" Then
                Dim intIdProduto As Integer = e.CommandArgument
                cls.TrocarOrdem(intIdProduto, 2)
            End If
            BindGrid()

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

        Protected Sub cboIDCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCategoria.SelectedIndexChanged
            Dim sct As New clsSubCategoria
            cboIDSubCategoria.DataSource = sct.Listar(CInt(cboIDCategoria.SelectedValue))
            cboIDSubCategoria.DataBind()
            cboIDSubCategoria.Items.Insert(0, New ListItem("TODAS", 0))
            sct = Nothing
        End Sub
    End Class

End Namespace

