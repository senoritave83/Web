
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoLoja
        Inherits XMWebPage
        Dim cls As clsTipoLoja
        Protected Const VW_IDTIPOLOJA As String = "IDTipoLoja"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoLoja()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta tipoloja?")
                ViewState(VW_IDTIPOLOJA) = Cint("0" & Request("IDTipoLoja"))
                cls.Load(ViewState(VW_IDTIPOLOJA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDTIPOLOJA))
          End If
        End Sub

        Protected Sub Inflate()
			txtTipoLoja.Text = cls.TipoLoja
			me.PageName = cls.TipoLoja
			lblCriado.Text = cls.Criado
        End Sub

        Protected Sub Deflate()
			cls.TipoLoja = txtTipoLoja.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/TipoLoja.aspx?idtipoloja=" & cls.idtipoloja)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("TipoLojas.aspx")
        End Sub
    End Class

End Namespace

