
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produto
        Inherits XMWebPage
        Dim cls As clsProduto
        Protected Const VW_IDPRODUTO As String = "IDProduto"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsProduto()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta produto?")
                ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDPRODUTO))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("Selecione...", 0))

                Inflate()


                BindFoto()
            Else
                cls.Load(ViewState(VW_IDPRODUTO))
            End If

        End Sub

        Sub FuncaoPrecoVista_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles FuncaoPrecoVista.ServerValidate
            Try
                If IsNumeric(txtPrecoVista.Text) = False Then
                    args.IsValid = False
                Else
                    args.IsValid = True
                End If

            Catch ex As Exception
                args.IsValid = False
            End Try

        End Sub


        Sub FuncaoPrecoPre_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles FuncaoPrecoPre.ServerValidate
            Try
                If IsNumeric(txtPrecoPre.Text) = False Then
                    args.IsValid = False
                Else
                    args.IsValid = True
                End If

            Catch ex As Exception
                args.IsValid = False
            End Try

        End Sub


        Sub FuncaoPrecoBoleto_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles FuncaoPrecoBoleto.ServerValidate
            If IsNumeric(txtPrecoBoleto.Text) = False Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If
        End Sub


        Protected Sub BindFoto()
            If UsaFotos Then
                pnlFoto.Visible = True

                Dim foto As New clsProdutoFoto
                Dim dr As System.Data.IDataReader = foto.Listar(ViewState(VW_IDPRODUTO), DataClass.enReturnType.DataReader)

                If dr.Read Then
                    lnkFoto.NavigateUrl = "produtofoto.aspx?idproduto=" & ViewState(VW_IDPRODUTO) & "&idprodutofoto=" & dr.GetGuid(dr.GetOrdinal("idprodutofoto")).ToString
                    imgProduto.ImageUrl = "../thumbnail.ashx?width=200&filename=~/imagens/produtos/" & dr.GetString(dr.GetOrdinal("Nome"))
                End If
            Else
                pnlFoto.Visible = False
            End If
        End Sub


        Protected Sub Inflate()
            txtCodigo.Text = cls.Codigo
            txtDescricao.Text = cls.Descricao
            setComboValue(cboIDCategoria, cls.IDCategoria)
            txtEstoque.Text = cls.Estoque
            txtPrecoUnitario.Text = FormatNumber(cls.PrecoUnitario, 2) '.ToString("#0.00")
            txtPrecoVista.Text = cls.PrecoVista.ToString("#0.00")
            txtPrecoPre.Text = cls.PrecoPre.ToString("#0.00")
            txtPrecoBoleto.Text = cls.PrecoBoleto.ToString("#0.00")
            If cls.Criado = "" Then
                DataCriado.Text = DateTime.Now
            Else
                DataCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
            cls.Codigo = txtCodigo.Text
            cls.Descricao = txtDescricao.Text
            cls.IDCategoria = cboIDCategoria.SelectedValue
            cls.Estoque = txtEstoque.Text
            cls.PrecoUnitario = txtPrecoUnitario.Text
            cls.Criado = DataCriado.Text
            cls.PrecoVista = txtPrecoVista.Text
            cls.PrecoPre = txtPrecoPre.Text
            cls.PrecoBoleto = txtPrecoBoleto.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            If Page.IsValid Then
                Deflate()
                If cls.isValid Then
                    cls.Update()
                    Inflate()
                    MostraGravado("~/Cadastros/Produto.aspx?idproduto=" & cls.IDProduto)
                End If
                lstErros.DataSource = cls.BrokenRules
                lstErros.DataBind()
            End If
        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Produtos.aspx")
        End Sub


    End Class

End Namespace

