﻿
Imports Classes

Namespace Pages.Cadastros

    Partial Class LinhasNegocio
        Inherits XMWebPage

        Dim cls As clsLinhaNegocio

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsLinhaNegocio()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            grdLinhaNegocio.DataSource = ret.Data
            grdLinhaNegocio.DataBind()
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
            Paginate1.Filtro = txtFiltro.Text
            BindGrid()
        End Sub

        Private Sub grdLinhaNegocio_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLinhaNegocio.Sorted
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

        Private Sub grdLinhaNegocio_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdLinhaNegocio.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub
    End Class
End Namespace