
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class CampoAdicional
        Inherits XMWebPage
		
        Dim cls As clsCampoAdicional
        Protected Const VW_IDCAMPOADICIONAL As String = "IDCampoAdicional"
        Protected Const VW_ENTIDADE As String = "Entidade"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCampoAdicional()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar este campo adicional?")
                ViewState(VW_IDCAMPOADICIONAL) = CInt("0" & Request("IDCampoAdicional"))
                ViewState(VW_ENTIDADE) = CStr("" & Request("entidade"))
                cls.Load(ViewState(VW_IDCAMPOADICIONAL), ViewState(VW_ENTIDADE))
				
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Enabled = VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))
                BindGrid()

                Inflate()
            Else
                cls.Load(ViewState(VW_IDCAMPOADICIONAL), ViewState(VW_ENTIDADE))
            End If
        End Sub

        Protected Sub Inflate()
            lblEntidade.Text = cls.Entidade
            txtNome.Text = cls.Nome
            txtFormato.Text = cls.Formato
            chkRequirido.Checked = cls.Requirido
            chkQuebraLinha.Checked = cls.QuebraDeLinha
            txtTamanho.Text = cls.Tamanho
            txtTamanhoMaximoTexto.Text = cls.TamanhoMaximo
            setComboValue(cboTipo, cls.Tipo)
            pnlLista.Visible = (cls.Tipo = 1)
            pnlInsert.Visible = Not cls.IsNew
        End Sub

        Protected Sub Deflate()
            '			cls.Entidade = txtEntidade.Text
            cls.Nome = txtNome.Text
            cls.Formato = txtFormato.Text
            cls.Requirido = chkRequirido.Checked
            cls.Tipo = cboTipo.SelectedValue
            cls.QuebraDeLinha = chkQuebraLinha.Checked
            cls.Tamanho = IIf(IsNumeric(txtTamanho.Text), txtTamanho.Text, 100)
            cls.TamanhoMaximo = IIf(IsNumeric(txtTamanhoMaximoTexto.Text), txtTamanhoMaximoTexto.Text, 150)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/CampoAdicional.aspx?idcampoadicional=" & cls.IDCampoAdicional & "&entidade=" & cls.Entidade)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("CampoAdicionais.aspx")
            End If
        End Sub

#Region "Lista de opções"

        Public Sub BindGrid()
            GridView1.DataSource = cls.ListarOpcoes()
            GridView1.DataBind()
        End Sub

        Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
            If txtNovo.Text <> "" Then
                cls.AdicionarOpcao(cls.Entidade, cls.IDCampoAdicional, txtNovo.Text)
                txtNovo.Text = ""
                BindGrid()
            End If
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Excluir" Then
                cls.ExcluirOpcao(GridView1.DataKeys(e.CommandArgument).Value)
                BindGrid()
            End If

        End Sub


#End Region

        Protected Sub cboTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
            pnlLista.Visible = (cboTipo.SelectedValue = "1")
        End Sub

        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            Response.Redirect("CampoAdicional.aspx?idcampoadicional=0&entidade=" & cls.Entidade)
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("CampoAdicionais.aspx?entidade=" & cls.Entidade)
        End Sub
    End Class

End Namespace

