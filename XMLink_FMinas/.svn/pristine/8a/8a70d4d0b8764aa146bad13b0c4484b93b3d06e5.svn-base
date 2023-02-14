
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class UF
        Inherits XMWebPage

        Protected Const SECAO As String = "Cadastro de UF"
        Dim cls As clsUF
        Protected Const VW_UF As String = "UF"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsUF()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta UF?")
                ViewState(VW_UF) = Request("uf")

                Dim uf As New clsUF
                cboUF.DataSource = uf.ListarUFsDisponiveis(ViewState(VW_UF))
                cboUF.DataBind()
                cboUF.Items.Insert(0, New ListItem("Selecione...", 0))
                uf = Nothing

                cls.Load(ViewState(VW_UF))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_UF))
            End If
        End Sub

        Protected Sub Inflate()
            txtDesconto.Text = cls.DescontoMax
            cboUF.SelectedValue = cls.UF
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
            If txtDesconto.Text <> "" Then
                cls.DescontoMax = txtDesconto.Text
            Else
                cls.DescontoMax = txtDesconto.Text = "0"
            End If
            cls.UF = cboUF.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/UF.aspx?uf=" & cls.UF)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SECAO, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("UFs.aspx")
            End If
        End Sub


    End Class

End Namespace

