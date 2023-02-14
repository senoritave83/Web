
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MensagemDia
        Inherits XMWebPage
        Dim cls As clsMensagemDia
        Protected Const VW_IDMENSAGEMDIA As String = "IDMensagemDia"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemDia()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagem?")
                ViewState(VW_IDMENSAGEMDIA) = Cint("0" & Request("IDMensagemDia"))
                cls.Load(ViewState(VW_IDMENSAGEMDIA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))


                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("TODOS", 0))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMENSAGEMDIA))
          End If
        End Sub

        Protected Sub Inflate()
            txtMensagem.Text = cls.Mensagem
            Me.PageName = cls.Mensagem
            txtDataInicio.Text = cls.DataInicio
            txtDataDim.Text = cls.DataDim
            SetComboValue(cboIDCategoria, cls.IDCategoria)
        End Sub

        Protected Sub Deflate()
            cls.Mensagem = txtMensagem.Text
            cls.DataInicio = txtDataInicio.Text
            cls.DataDim = txtDataDim.Text
            cls.IDCategoria = cboIDCategoria.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/MensagemDia.aspx?idmensagemdia=" & cls.idmensagemdia)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("MensagemDias.aspx")
        End Sub
    End Class

End Namespace

