
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MensagemDia
        Inherits XMWebEditPage
        Dim cls As clsMensagemDia
        Protected Const VW_IDMENSAGEMDIA As String = "IDMensagemDia"
        Dim strLen As String = ""
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemDia()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagem?")
                ViewState(VW_IDMENSAGEMDIA) = Cint("0" & Request("IDMensagemDia"))
                cls.Load(ViewState(VW_IDMENSAGEMDIA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))


                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("TODOS", 0))

                btnGravar.Attributes.Add("onclick", "alert('Algumas versões do aplicativo móvel não suportam 1000 caracteres. Verifique a versão utilizada');")

                ViewState("TamanhoMensagem") = SettingsExpression.GetProperty("tamanhomaximo", "Mensagem", "1000")
                If Not IsNumeric(ViewState("TamanhoMensagem")) Then ViewState("TamanhoMensagem") = "1000"
                customMensagem.ErrorMessage = "A mensagem não pode conter caracteres especiais e o tamanho dever no máximo " & ViewState("TamanhoMensagem") & " caracteres "

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
            setComboValue(cboIDCategoria, cls.IDCategoria)

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.MensagemDia, cls.IDMensagemDia)


        End Sub

        Protected Sub Deflate()
            cls.Mensagem = txtMensagem.Text
            cls.DataInicio = txtDataInicio.Text
            cls.DataDim = txtDataDim.Text
            cls.IDCategoria = cboIDCategoria.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If Page.IsValid Then
                If cls.isValid Then
                    cls.Update()

                    'Notify All Observers
                    Me.NotifyUpdate(enTipoEntidade.MensagemDia, cls.IDMensagemDia)

                    Inflate()
                    MostraGravado("~/cadastros/MensagemDia.aspx?idmensagemdia=" & cls.IDMensagemDia)
                End If
                lstErros.DataSource = cls.BrokenRules
                lstErros.DataBind()

            End If
            
        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.MensagemDia, cls.IDMensagemDia)

                cls.Delete()
                Response.Redirect("MensagemDias.aspx")
            End If
        End Sub

        Sub verificaMensagem(source As Object, args As ServerValidateEventArgs)

            Try

                args.IsValid = (txtMensagem.Text.Length <= ViewState("TamanhoMensagem"))

            Catch ex As Exception

                args.IsValid = False

            End Try

        End Sub
    End Class

End Namespace

