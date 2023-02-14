
Partial Class configuracoes_grupo_det
    Inherits XMProtectedPage

    Protected cls As clsGrupo
    Protected Const VW_IDGRUPO As String = "IDGRUPO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsGrupo
        If Not Page.IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            ViewState(VW_IDGRUPO) = Request("idgrupo")

            btnExcluir.Attributes.Add("onClick", "return fnConfirm('E');")
            btnNovo.Attributes.Add("onClick", "return fnConfirm('N');")

        End If
        cls.Load(ViewState(VW_IDGRUPO))
        If Not IsPostBack Then
            Inflate()
            BindResponsaveis()
        End If
    End Sub

    Protected Sub Inflate()
        txtNome.Text = cls.Grupo

        btnExcluir.Visible = cls.IDGrupo > 0
        btnNovo.Visible = cls.IDGrupo > 0
    End Sub

    Protected Sub Deflate()
        cls.Grupo = txtNome.Text

        cls.Responsaveis.Clear()
        For intJ As Integer = 0 To rptResponsavel.Items.Count - 1
            Dim chkResponsavel As System.Web.UI.HtmlControls.HtmlInputCheckBox = CType(rptResponsavel.Items(intJ).FindControl("chkResponsavel"), System.Web.UI.HtmlControls.HtmlInputCheckBox)
            If chkResponsavel.Checked Then cls.Responsaveis.Add(chkResponsavel.Value)
        Next

    End Sub

    Protected Sub BindResponsaveis()
        rptResponsavel.DataSource = cls.ListarResponsaveis(cls.IDGrupo, True)
        rptResponsavel.DataBind()
    End Sub

    Protected Sub rptResponsavel_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptResponsavel.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim oRowView As System.Data.Common.DbDataRecord = CType(e.Item.DataItem, System.Data.Common.DbDataRecord)

            If oRowView.GetInt32(oRowView.GetOrdinal("Selected")) = 1 Then
                Dim chkResponsavel As System.Web.UI.HtmlControls.HtmlInputCheckBox = CType(e.Item.FindControl("chkResponsavel"), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                chkResponsavel.Checked = True
            End If

        End If


    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("grupos.aspx")
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Deflate()
        If cls.isValid Then
            cls.Update()
            MostraGravado("grupos.aspx")
        End If
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        If CheckPermission("Cadastro de Grupos", "Excluir Grupo") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        cls.Delete()
        Response.Redirect("grupos.aspx")
    End Sub

    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("grupo_det.aspx?idgrupo=0")
    End Sub
End Class
