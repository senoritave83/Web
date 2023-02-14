
Imports Classes

Partial Class consignado_vendedores
    Inherits XMWebPage
    Dim cls As clsVendedor
    Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos os estoques de vendedores"
    Protected Const VW_IDVENDEDOR As String = "IDVENDEDOR"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cls = New clsVendedor()
        ViewState(VW_IDVENDEDOR) = 0

        If Not VerificaPermissao(SecaoAtual, ACAO_VISUALIZAR_TODOS) Then

            ViewState(VW_IDVENDEDOR) = cls.RecuperaCodigoVendedor(Me.User.IDUser)

            If ViewState(VW_IDVENDEDOR) > 0 Then

                Response.Redirect("estvendedores.aspx?idvendedor=" & ViewState(VW_IDVENDEDOR))

            Else

                tmrTimer.Enabled = True
                pnlMain.Visible = False
                pnlMensagem.Visible = True

                Exit Sub

            End If

        End If

        If Not Page.IsPostBack Then
            Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1)
            BindGrid()
        End If

    End Sub

    Protected Sub tmrTimer_Tick(sender As Object, e As System.EventArgs) Handles tmrTimer.Tick
        Response.Redirect("~/controle/default.aspx")
    End Sub

    Public Sub BindGrid()
        Dim ret As IPaginaResult

        ret = cls.ListarVendedoresConsignacao(ViewState("Filtro"), SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)

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
        ViewState("Filtro") = txtFiltro.Text
        BindGrid()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindGrid()
    End Sub


    Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
        Paginate1.CurrentPage = 0
        ViewState("Filtro") = vLetra
        txtFiltro.Text = ""
        BindGrid()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindGrid()
    End Sub

#Region "Sorting"


    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If SortExpression = e.SortExpression Then
            If SortDirection = WebControls.SortDirection.Ascending Then
                SortDirection = WebControls.SortDirection.Descending
            Else
                SortDirection = WebControls.SortDirection.Ascending
            End If
        Else
            SortExpression = e.SortExpression
            SortDirection = WebControls.SortDirection.Ascending
        End If
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

#End Region


End Class
