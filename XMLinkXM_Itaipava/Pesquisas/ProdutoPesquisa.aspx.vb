Imports Classes

Namespace Pages.Pesquisas

    Partial Public Class ProdutoPesquisa
        Inherits XMWebPage

        Dim cls As clsProdutoPesquisa
        Protected Const VW_IDProdutoPesquisa As String = "IDProdutoPesquisa"
        Protected Const Secao As String = "Cadastro de Produtos da Pesquisa"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsProdutoPesquisa()

            If Not Page.IsPostBack Then

                subAddConfirm(btnApagar, "Deseja realmente apagar este produto?")
                ViewState(VW_IDProdutoPesquisa) = CInt("0" & Request("IDProdutoPesquisa"))
                cls.Load(ViewState(VW_IDProdutoPesquisa))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Dim clsCatPesq As New clsCategoriaPesquisa()
                cboCategoriaPesquisa.DataSource = clsCatPesq.Listar()
                cboCategoriaPesquisa.DataBind()
                clsCatPesq = Nothing

                Inflate()

            Else

                cls.Load(ViewState(VW_IDProdutoPesquisa))

            End If

        End Sub

        Protected Sub Inflate()

            txtCodigo.Text = cls.Codigo
            txtProdutoPesquisa.Text = cls.ProdutoPesquisa

            If cls.PrecoPontaMinimo = "" Then
                txtPrecoPontaMinimo.Text = ""
            Else
                txtPrecoPontaMinimo.Text = FormatNumber(cls.PrecoPontaMinimo, 2)
            End If

            If cls.PrecoPontaMaximo = "" Then
                txtPrecoPontaMaximo.Text = ""
            Else
                txtPrecoPontaMaximo.Text = FormatNumber(cls.PrecoPontaMaximo, 2)
            End If

            If cls.PrecoVarejoMinimo = "" Then
                txtPrecoVarejoMinimo.Text = ""
            Else
                txtPrecoVarejoMinimo.Text = FormatNumber(cls.PrecoVarejoMinimo, 2)
            End If

            If cls.PrecoVarejoMaximo = "" Then
                txtPrecoVarejoMaximo.Text = ""
            Else
                txtPrecoVarejoMaximo.Text = FormatNumber(cls.PrecoVarejoMaximo, 2)
            End If

            For Each chk As ListItem In chkTipoPergunta.Items
                If (chk.Value And cls.TipoPergunta) > 0 Then
                    chk.Selected = True
                End If
            Next

            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

        End Sub

        Protected Sub Deflate()

            cls.Codigo = txtCodigo.Text
            cls.ProdutoPesquisa = txtProdutoPesquisa.Text

            cls.PrecoPontaMinimo = txtPrecoPontaMinimo.Text
            cls.PrecoPontaMaximo = txtPrecoPontaMaximo.Text

            cls.PrecoVarejoMinimo = txtPrecoVarejoMinimo.Text
            cls.PrecoVarejoMaximo = txtPrecoVarejoMaximo.Text

            cls.ProdutoPesquisa = txtProdutoPesquisa.Text

            Dim intTipoPergunta As Integer = 0
            For Each chk As ListItem In chkTipoPergunta.Items
                If chk.Selected = True Then
                    intTipoPergunta = intTipoPergunta + chk.Value
                End If
            Next

            cls.TipoPergunta = intTipoPergunta

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/pesquisas/produtopesquisa.aspx?idprodutopesquisa=" & cls.IDProdutoPesquisa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("produtopesquisas.aspx")
            End If
        End Sub


    End Class

End Namespace

