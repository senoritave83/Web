
Partial Class configuracoes_grupos
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Protected cls As clsGrupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsGrupo
        If Not Page.IsPostBack Then
            If Request("Desc") Is Nothing Then
                ViewState("Desc") = 0
            Else
                ViewState("Desc") = IIf(Request("Desc") = 0, 1, 0)
            End If

            ViewState("Sort") = Request("Sort")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
            'ViewState("Type") = Request("type")

            'BindGrupos()
        End If

        BindGrid()

    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = cls.Listar(ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        rptGrupos.DataSource = ret.DataSet.Tables(0)
        rptGrupos.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()

    End Sub

    'Protected Sub BindGrupos()
    '    rptGrupos.DataSource = cls.Listar
    '    rptGrupos.DataBind()
    'End Sub

    Protected Sub rptGrupos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptGrupos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim oRowView As System.Data.DataRowView = CType(e.Item.DataItem, System.Data.DataRowView)
            Dim oRptResponsaveis As System.Web.UI.WebControls.Repeater = CType(e.Item.FindControl("rptResponsaveis"), System.Web.UI.WebControls.Repeater)
            Dim oplhSetas As System.Web.UI.WebControls.PlaceHolder = CType(e.Item.FindControl("plhSetas"), System.Web.UI.WebControls.PlaceHolder)
            oRptResponsaveis.DataSource = cls.ListarResponsaveis(oRowView.Item("grp_Grupo_int_PK"), False)
            oRptResponsaveis.DataBind()
            oRptResponsaveis.Visible = oRptResponsaveis.Items.Count > 0
            oplhSetas.Visible = oRptResponsaveis.Visible
        End If

    End Sub

    Protected Sub rptResponsaveis_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

        End If
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click

        If Not String.IsNullOrEmpty(Request("chkGrupo")) Then
            Dim sep As String = ","
            Dim arrGrupo As Array

            arrGrupo = Request("chkGrupo").Split(sep)

            For i As Integer = 0 To arrGrupo.Length - 1
                cls.Delete(arrGrupo(i).ToString)
            Next

            Response.Redirect("grupos.aspx")
        End If
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click
        Response.Redirect("grupo_det.aspx?idgrupo=0")
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub
End Class
