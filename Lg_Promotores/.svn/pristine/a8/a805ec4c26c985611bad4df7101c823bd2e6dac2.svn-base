Imports Classes

Namespace Pages.Cadastros

    Partial Public Class SubCategoria
        Inherits XMWebPage
        Dim cls As clsSubCategoria
        Protected Const VW_IDSUBCATEGORIA As String = "IDSubCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsSubCategoria()
            If Not Page.IsPostBack Then

                Dim clsCat As clsCategoria
                clsCat = New clsCategoria
                cboIDCategoria.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("Selecione a categoria...", "0"))
                clsCat = Nothing

                subAddConfirm(btnApagar, "Deseja realmente apagar esta subcategoria?")
                ViewState(VW_IDSUBCATEGORIA) = CInt("0" & Request("IDSubCategoria"))
                cls.Load(ViewState(VW_IDSUBCATEGORIA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()

            Else
                cls.Load(ViewState(VW_IDSUBCATEGORIA))

            End If
        End Sub

        Protected Sub Inflate()
			SetComboValue(cboIDCategoria, cls.IDCategoria)
			txtSubCategoria.Text = cls.SubCategoria
			me.PageName = cls.SubCategoria
			lblCriado.Text = cls.Criado
        End Sub

        Protected Sub Deflate()
			cls.IDCategoria = cboIDCategoria.SelectedValue
			cls.SubCategoria = txtSubCategoria.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/SubCategoria.aspx?idsubcategoria=" & cls.idsubcategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("SubCategorias.aspx")
        End Sub
    End Class

End Namespace

