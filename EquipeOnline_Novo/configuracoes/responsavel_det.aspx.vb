
Partial Class configuracoes_responsavel_det
    Inherits XMProtectedPage

    Protected cls As clsResponsaveis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsResponsaveis

        If Not Page.IsPostBack Then
            ViewState("IDRESPONSAVEL") = CInt("0" & Request("id"))
            cls.Load(ViewState("IDRESPONSAVEL"))
            Inflate()
            BindGrupos()

        Else
            cls.Load(ViewState("IDRESPONSAVEL"))
        End If

        txtTelefone.Attributes.Add("onKeyPress", "return fncOnlyInteger();")
        If (cls.IDResponsavel <> 0) Then
            btnNovo.Visible = True
            btnExcluir.Visible = True
            plhNovo.Visible = True
            plhSalvar.Visible = True
            ltrSalvar.Text = "Grave este registro na Lista de Responsáveis."
            plhExcluir.Visible = True
        Else
            plhNovo.Visible = False '
            plhSalvar.Visible = True
            btnNovo.Visible = False
            btnExcluir.Visible = False
            ltrSalvar.Text = "Salve o novo registro na Lista de Responsável."
            plhExcluir.Visible = False
        End If

        Dim conf As New clsConfig
        If conf.ModuloJava = True Then
            trDadosUsuario.Visible = True
        Else
            trDadosUsuario.Visible = False
        End If

        If cls.IDResponsavel = 0 Then
            txtSenha.Visible = True
            btnNovaSenha.Visible = False
        Else
            txtSenha.Visible = False
            btnNovaSenha.Visible = True
        End If

        btnExcluir.Attributes.Add("onClick", "return fncConfirm();")
    End Sub


    Protected Sub BindGrupos()
        'Dim grp As New clsGrupo
        rptGrupo.DataSource = cls.ListarGrupos()
        rptGrupo.DataBind()
    End Sub

    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Response.Redirect("responsavel_det.aspx")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        cls.Delete()
        Response.Redirect("responsaveis.aspx")
    End Sub

    Private Function fn_ValidaID() As Boolean
        Dim Texto As String = txtID.Text
        Dim Expressao As String = "55\*\d{1,6}\*\d{1,7}"
        Dim oExpressao As Regex = New Regex(Expressao, RegexOptions.IgnoreCase)
        Dim oValidador As Match = oExpressao.Match(Texto)
        Return (oValidador.Success)
    End Function

    Private Function fn_ValidaTelefone() As Boolean
        Dim Texto As String = txtID.Text
        Dim Expressao As String = "\d{1,10}"
        Dim oExpressao As Regex = New Regex(Expressao, RegexOptions.IgnoreCase)
        Dim oValidador As Match = oExpressao.Match(Texto)
    End Function


    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Deflate()
        If cls.isValid Then
            If cls.IDResponsavel = 0 Then 'Novo Cadastro
                cls.Update()
                Response.Write("<scri" & "pt>alert('O responsável " & cls.Responsavel & " foi adicionado com sucesso!');document.location.href='responsavel_det.aspx';</scri" & "pt>")
            Else
                cls.Update()
            End If
            plhErro.Visible = False
        Else
            plhErro.Visible = True
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()
        End If
    End Sub

    Protected Sub Inflate()
        txtNome.Text = cls.Responsavel
        txtTelefone.Text = cls.Telefone
        txtID.Text = cls.ID
        txtObs.Text = cls.Observacao
        txtLogin.Text = cls.Login
    End Sub

    Protected Sub Deflate()
        cls.Responsavel = txtNome.Text
        cls.Telefone = txtTelefone.Text
        cls.ID = txtID.Text
        cls.Observacao = txtObs.Text
        cls.Login = txtLogin.Text
        If txtSenha.Text <> "" Then cls.Senha = txtSenha.Text

        cls.Grupos.Clear()
        For intJ As Integer = 0 To rptGrupo.Items.Count - 1
            Dim chkGrupo As System.Web.UI.HtmlControls.HtmlInputCheckBox = CType(rptGrupo.Items(intJ).FindControl("chkGrupo"), System.Web.UI.HtmlControls.HtmlInputCheckBox)
            If chkGrupo.Checked Then cls.Grupos.Add(chkGrupo.Value)
        Next

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("responsaveis.aspx")
    End Sub

    Protected Sub rptGrupo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptGrupo.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim oRowView As System.Data.Common.DbDataRecord = CType(e.Item.DataItem, System.Data.Common.DbDataRecord)

            If oRowView.GetInt32(oRowView.GetOrdinal("Selected")) = 1 Then
                Dim chkGrupo As System.Web.UI.HtmlControls.HtmlInputCheckBox = CType(e.Item.FindControl("chkGrupo"), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                chkGrupo.Checked = True
            End If

        End If

    End Sub

    Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
        txtSenha.Visible = True
        btnNovaSenha.Visible = False
    End Sub

End Class


