
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Categoria
        Inherits XMWebEditPage
        Dim cls As clsCategoria
        Protected Const VW_IDCATEGORIA As String = "IDCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCategoria()
            If Not Page.IsPostBack Then

                subAddConfirm(btnApagar, SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem2", "Deseja realmente apagar esta categoria?"))
                valReqCategoria.ErrorMessage = SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem5", "Segmento é um campo obrigatório")

                ViewState(VW_IDCATEGORIA) = Cint("0" & Request("IDCategoria"))
                cls.Load(ViewState(VW_IDCATEGORIA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                divOrdem.Visible = (cls.IDCategoria > 0)

                Inflate()

            Else

                cls.Load(ViewState(VW_IDCATEGORIA))

          End If
        End Sub

        Protected Sub Inflate()
			txtCategoria.Text = cls.Categoria
			me.PageName = cls.Categoria
			lblCriado.Text = cls.Criado
            txtOrdem.Text = cls.Ordem
            setComboValue(rdStatus, cls.IdStatus)
            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Categoria, cls.IDCategoria)

        End Sub

        Protected Sub Deflate()
            cls.Categoria = txtCategoria.Text
            cls.IdStatus = rdStatus.SelectedItem.Value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Categoria, cls.IDCategoria)

                Inflate()
                MostraGravado("~/cadastros/Categoria.aspx?idcategoria=" & cls.idcategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Categoria, cls.IDCategoria)

                If cls.Delete() Then
                    Response.Redirect("Categorias.aspx")
                Else
                    ShowMsg(SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem1", "O Segmento não pode ser apagado, pois existe(m) categoria(s) vinculada(s) a ele!"))
                End If

            End If
        End Sub
    End Class

End Namespace

