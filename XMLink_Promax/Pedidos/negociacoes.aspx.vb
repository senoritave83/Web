﻿Imports Classes

Partial Class Pedidos_negociacoes
    Inherits XMWebPage
    Dim cls As clsNegociacao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsNegociacao()
        If Not Page.IsPostBack Then

            txtDataEmissaoInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
            txtDataEmissaoFinal.Text = Now.ToString("dd/MM/yyyy")

            Me.RecuperaFiltro(Paginate1, txtVendedor, txtCliente, txtDataEmissaoInicial, txtDataEmissaoFinal)
            BindGrid()
        End If
    End Sub

    Public Sub BindGrid()
        Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, txtVendedor.Text, txtCliente.Text, "", "", 0, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

        Me.GravaFiltro(Paginate1, txtVendedor, txtCliente, txtDataEmissaoInicial, txtDataEmissaoFinal)
    End Sub

    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindGrid()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Paginate1.CurrentPage = 0
        Paginate1.Filtro = txtFiltro.Text
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
