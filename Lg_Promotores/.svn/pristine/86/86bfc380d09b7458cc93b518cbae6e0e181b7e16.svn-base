
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Lider
        Inherits XMWebPage
        Dim cls As clsLider
        Protected WithEvents filUpload As System.Web.UI.HtmlControls.HtmlInputFile
        Protected Const VW_IDLIDER As String = "IDLider"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsLider()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta lider?")
                ViewState(VW_IDLIDER) = Cint("0" & Request("IDLider"))
                cls.Load(ViewState(VW_IDLIDER))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                'Bind Combos
                Dim crd As New clsCoordenador
                cboIDCoordenador.DataSource = crd.Listar
                cboIDCoordenador.DataBind()
                cboIDCoordenador.Items.Insert(0, New ListItem("Selecione..", 0))

                Dim usu As New clsUsuario()
                drpIdUsuario.DataSource = usu.Listar(TipoPermissao.LIDER, DataClass.enReturnType.DataReader)
                drpIdUsuario.DataBind()
                drpIdUsuario.Items.Insert(0, New ListItem("Selecione o usuário", "0"))
                usu = Nothing

                MensagensErroPersonalizadas()

                Inflate()

            Else

                cls.Load(ViewState(VW_IDLIDER))

          End If
        End Sub

        Private Sub MensagensErroPersonalizadas()
            valReqLider.ErrorMessage = SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider") & " é um campo obrigatório!"
            valReqIDCoordenador.ErrorMessage = SettingsExpression.GetProperty("caption", "Promotor.FiltroCoordenador", "Coordenador") & " é um campo obrigatório!"
        End Sub

        Protected Sub Inflate()
			txtLider.Text = cls.Lider
			me.PageName = cls.Lider
            setComboValue(cboIDCoordenador, cls.IDCoordenador)

            If SettingsExpression.GetProperty("visualiza", "Lider.UsuarioWeb", False) = True Then
                chkAcessoWeb.Checked = cls.AcessoWeb
                setComboValue(drpIdUsuario, cls.IdUsuario)
                trUsuarioAcessoWeb.Visible = chkAcessoWeb.Checked
            End If

            ImageUploaderLider.Imagem = cls.Foto

        End Sub

        Protected Sub Deflate()
			cls.Lider = txtLider.Text
            cls.IDCoordenador = cboIDCoordenador.SelectedValue
            cls.AcessoWeb = IIf(chkAcessoWeb.Checked, 1, 0)
            cls.IdUsuario = getComboValue(drpIdUsuario)
            cls.Foto = ImageUploaderLider.Imagem
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid And Page.IsValid Then
                cls.Update()
                Inflate()
                If Not ImageUploaderLider.ShowSaveButton And ImageUploaderLider.HasPostedFile Then
                    ImageUploaderLider.Gravar()
                End If
                MostraGravado("~/cadastros/Lider.aspx?idlider=" & cls.IDLider)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If Not cls.ExistePromotores(cls.IDLider) Then
                cls.Delete()
                Response.Redirect("Lideres.aspx")
            Else
                Response.Write("<script>")
                Response.Write("alert('" & SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider") & " não pode ser apagado, pois ainda possui promotores associados');")
                Response.Write("document.location.href='Lider.aspx?IDCoordenador=" & cls.IDCoordenador & "&IDLider=" & cls.IDLider & "'")
                Response.Write("</script>")
                Response.End()
            End If
        End Sub

        Protected Sub chkAcessoWeb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAcessoWeb.CheckedChanged

            trUsuarioAcessoWeb.Visible = chkAcessoWeb.Checked
            setComboValue(drpIdUsuario, 0)

        End Sub

        Protected Sub ImageUploaderLider_onSavingFile(ByRef filename As String) Handles ImageUploaderLider.onSavingFile
            filename = Guid.NewGuid.ToString() & IO.Path.GetExtension(filename)
        End Sub

    End Class



End Namespace

