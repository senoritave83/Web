
Partial Class configuracoes_respostadet
    Inherits XMProtectedPage
    Protected cls As clsResposta
    Protected rad As clsRespostaAdicional

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsResposta
        rad = New clsRespostaAdicional
        If Not Page.IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            ViewState("IDRESPOSTA") = CInt("0" & Request("idresposta"))
            cls.Load(ViewState("IDRESPOSTA"))
            inflate()
            BindGrid()
        Else
            cls.Load(ViewState("IDRESPOSTA"))
        End If
    End Sub

    Protected Sub inflate()
        ltrResposta.Text = cls.Resposta
        setComboValue(cboOpcaoObs, cls.OpcaoObservacao)
        ctrFormatoObs.Formato = cls.FormatoObservacao
    End Sub

    Protected Sub BindGrid()
        rptAdicionais.DataSource = rad.Listar(cls.IDResposta)
        rptAdicionais.DataBind()
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click
        rad.Gravar(0, cls.IDResposta, txtTextoNovo.Text, cboOpcaoNovo.SelectedValue, fopFormatoNovo.Formato)
        BindGrid()
        txtTextoNovo.Text = ""
        cboOpcaoNovo.SelectedIndex = 0
        fopFormatoNovo.Formato = ""
    End Sub

    Protected Sub rptAdicionais_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAdicionais.ItemCommand
        If e.CommandName = "Apagar" Then
            Dim intIDRespostaAdicional As Integer = e.CommandArgument
            rad.Delete(intIDRespostaAdicional, cls.IDResposta)
            BindGrid()
        End If
    End Sub

    Protected Sub rptAdicionais_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptAdicionais.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim cbo As DropDownList = e.Item.FindControl("cboOpcao")
            setComboValue(cbo, e.Item.DataItem("Preenchimento"))
        End If
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        For Each item As RepeaterItem In rptAdicionais.Items
            If item.ItemType = ListItemType.AlternatingItem Or item.ItemType = ListItemType.Item Then
                Dim hid As HiddenField = item.FindControl("hidAdicional")
                Dim intIDRespostaAdicional As Integer = hid.Value
                Dim txt As TextBox = item.FindControl("txtTexto")
                Dim cbo As DropDownList = item.FindControl("cboOpcao")
                Dim ctrFormato As Controls.FormatOption = item.FindControl("ctrFormato")

                rad.Gravar(intIDRespostaAdicional, cls.IDResposta, txt.Text, cbo.SelectedValue, ctrFormato.Formato)
            End If
        Next
        cls.GravarOpcaoObservacao(cboOpcaoObs.SelectedValue, ctrFormatoObs.Formato)
        inflate()
        BindGrid()
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("respostas.aspx?idsuperior=" & cls.IDSuperior)
    End Sub
End Class
