
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Coordenador
        Inherits XMWebPage
        Dim cls As clsCoordenador
        Protected Const VW_IDCOORDENADOR As String = "IDCoordenador"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCoordenador()
            If Not Page.IsPostBack Then

                subAddConfirm(btnApagar, "Deseja realmente apagar esta coordenador?")
                ViewState(VW_IDCOORDENADOR) = CInt("0" & Request("IDCoordenador"))
                cls.Load(ViewState(VW_IDCOORDENADOR))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Dim usu As New clsUsuario()
                drpIdUsuario.DataSource = usu.Listar(TipoPermissao.COORDENADOR, DataClass.enReturnType.DataReader)
                drpIdUsuario.DataBind()
                drpIdUsuario.Items.Insert(0, New ListItem("Selecione o usuário", "0"))
                usu = Nothing

                MensagensErroPeronalizadas()

                Inflate()

            Else

                cls.Load(ViewState(VW_IDCOORDENADOR))

            End If

        End Sub

        Private Sub MensagensErroPeronalizadas()
            valReqCoordenador.ErrorMessage = SettingsExpression.GetProperty("caption", "Coordenadores.FiltroCoordenador", "Coordenador") & " é obrigatório."
        End Sub

        Protected Sub Inflate()

            txtCoordenador.Text = cls.Coordenador
            Me.PageName = cls.Coordenador
            chkAcessoWeb.Checked = cls.AcessoWeb
            If SettingsExpression.GetProperty("visualiza", "Coordenadores.UsuarioWeb", False) = True Then
                trUsuario.Visible = chkAcessoWeb.Checked
                If trUsuario.Visible Then
                    setComboValue(drpIdUsuario, cls.IdUsuario)
                Else
                    setComboValue(drpIdUsuario, 0)
                End If
            End If

        End Sub

        Protected Sub Deflate()

            cls.Coordenador = txtCoordenador.Text
            cls.AcessoWeb = chkAcessoWeb.Checked
            cls.IdUsuario = getComboValue(drpIdUsuario)

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Coordenador.aspx?idcoordenador=" & cls.idcoordenador)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If Not cls.ExisteLideres(cls.IDCoordenador) Then
                cls.Delete()
                Response.Redirect("Coordenadores.aspx")
            Else
                Response.Write("<script>")
                Response.Write("alert('" & SettingsExpression.GetProperty("caption", "Coordenadores.FiltroCoordenador", "Coordenador") & " não pode ser apagado, pois ainda possui " & SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider") & "es associados');")
                Response.Write("document.location.href='Coordenador.aspx?IDCoordenador=" & cls.IDCoordenador & "'")
                Response.Write("</script>")
                Response.End()
            End If
            
        End Sub

        Protected Sub chkAcessoWeb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAcessoWeb.CheckedChanged

            trUsuario.Visible = chkAcessoWeb.Checked
            setComboValue(drpIdUsuario, 0)

        End Sub

    End Class

End Namespace

