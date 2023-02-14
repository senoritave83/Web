
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Visitas
        Inherits XMWebPage
        Dim cls As clsVisita

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then

                Dim jus As New clsJustificativa
                cboIDJustificativa.DataSource = jus.Listar
                cboIDJustificativa.DataBind()
                cboIDJustificativa.Items.Insert(0, New ListItem("Todas as visitas", "0"))
                cboIDJustificativa.Items.Insert(0, New ListItem("Somente justificadas", "-1"))
                cboIDJustificativa.Items.Insert(0, New ListItem("Todas visitas realizadas", "-2"))
                setComboValue(cboIDJustificativa, -1)
                jus = Nothing

                Dim uf As New clsUF
                cboUf.DataSource = uf.Listar
                cboUf.DataBind()
                cboUf.Items.Insert(0, New ListItem("TODOS", ""))
                uf = Nothing

                txtDataEmissaoInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
                txtDataEmissaoFinal.Text = Now.ToString("dd/MM/yyyy")

                Me.RecuperaFiltro(Paginate1, txtVendedor, txtCliente, txtDataEmissaoInicial, txtDataEmissaoFinal, cboIDJustificativa, cboUf)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(txtCliente.Text, txtVendedor.Text, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, cboIDJustificativa.SelectedValue, cboUf.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(Paginate1, txtVendedor, txtCliente, txtDataEmissaoInicial, txtDataEmissaoFinal, cboIDJustificativa, cboUf)
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
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

End Namespace

