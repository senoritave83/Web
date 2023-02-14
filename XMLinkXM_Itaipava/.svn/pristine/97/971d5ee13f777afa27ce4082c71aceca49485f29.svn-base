Imports System.Collections.Generic
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produto
        Inherits XMWebPage

        Protected Const SECAO As String = "Cadastro de Produtos"
        Dim cls As clsProduto
        Protected Const VW_IDPRODUTO As String = "IDProduto"
        Protected Const ACAO_ALTERARTRANSACAO As String = "Alterar código de transação"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsProduto()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta produto?")
                ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDPRODUTO))

                btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = iif(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))

                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("TODOS", 0))

                'Bind Linhas
                Dim lin As New clsLinha
                cboIDLinha.DataSource = lin.Listar
                cboIDLinha.DataBind()
                cboIDLinha.Items.Insert(0, New ListItem("TODAS", 0))

                Inflate()

                Dim emp As New clsEmpresa
                divBonificacao.Visible = False ' emp.PermiteBonificacao
            Else
                cls.Load(ViewState(VW_IDPRODUTO))
            End If
        End Sub

        'Protected Sub BindProdutosFotos()
        '    dtgProdutosFoto.DataSource = cls.ListarFotosProduto(ViewState(VW_IDPRODUTO))
        '    dtgProdutosFoto.DataBind()
        ' End Sub

        Protected Sub BindTransacao()
            rptTransacao.DataSource = cls.ListarTransacoes()
            rptTransacao.DataBind()
        End Sub

        Protected Sub BindTabelasPreco()

            Dim clsTab As New clsTabela

            grdTabelaProduto.DataSource = clsTab.ListarTabelas(ViewState(VW_IDPRODUTO))
            grdTabelaProduto.DataBind()

            grdHistorico.DataSource = cls.ListarHistorico(ViewState(VW_IDPRODUTO))
            grdHistorico.DataBind()

            clsTab = Nothing

        End Sub

        Protected Sub BindFamilias()

            grdFamilias.DataSource = cls.ListarFamilias()
            grdFamilias.DataBind()

        End Sub

        Protected Sub Inflate()

            txtDescricao.Text = cls.Descricao
            txtEmbalagem.Text = cls.Embalagem
            setComboValue(cboTipo, cls.Tipo)
            setComboValue(cboIDCategoria, cls.IDCategoria)
            setCheckValue(cboIDLinha, cls.IDLinha)
            chkBonificacao.Checked = cls.Bonificacao
            trEmbalagem.Visible = (cls.Tipo <> "P")
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

            Dim strImagePath As String = "~/imagens/fotos/"
            imgRotatorLoja.onClientClick = "fncImageClick"
            Dim strImages() As String = cls.ListarFotosProduto.Split(",")
            For i As Integer = 0 To strImages.GetUpperBound(0)

                If strImages(i).Trim() <> "" Then
                    If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                        imgRotatorLoja.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=200&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                    Else
                        imgRotatorLoja.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                    End If
                End If

            Next

            BindTransacao()
            BindTabelasPreco()
            BindFamilias()

        End Sub

        Protected Sub Deflate()
            cls.Descricao = txtDescricao.Text
            cls.Embalagem = txtEmbalagem.Text
            cls.Tipo = cboTipo.SelectedValue
            cls.IDCategoria = cboIDCategoria.SelectedValue
            cls.IDLinha = cboIDLinha.SelectedValue
            cls.Bonificacao = chkBonificacao.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Dim dicTransacao As New Dictionary(Of String, Integer) '1=Normal, 2=Bonificado

            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                If VerificaPermissao(SECAO, ACAO_ALTERARTRANSACAO) Then
                    For Each item As RepeaterItem In rptTransacao.Items()
                        If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                            Dim txtTransacao As TextBox = CType(item.FindControl("txtTransacao"), TextBox)
                            Dim hidIDTipoPedido As HiddenField = CType(item.FindControl("hidIDTipoPedido"), HiddenField)

                            If hidIDTipoPedido.Value = 1 Or hidIDTipoPedido.Value = 2 Then
                                dicTransacao.Add(hidIDTipoPedido.Value, CInt("0" & txtTransacao.Text))
                            Else
                                cls.GravaTransacao(hidIDTipoPedido.Value, CInt("0" & txtTransacao.Text))
                            End If
                        End If
                    Next

                    'Transação não pode ser igual
                    If dicTransacao.Item("1") = dicTransacao.Item("2") Then
                        Inflate()
                        dicTransacao.Clear()
                        cls.AddBrokenRuleTransacao("A transação não pode ser igual para o Tipo de Pedido 'Normal' e 'Bonificado'!")
                        lstErros.DataSource = cls.BrokenRules
                        lstErros.DataBind()
                        Exit Sub
                    Else
                        For i As Integer = 1 To 2
                            cls.GravaTransacao(i, dicTransacao.Item(i))
                        Next
                    End If

                End If
                Inflate()
                MostraGravado("~/Cadastros/Produto.aspx?idproduto=" & cls.IDProduto)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub



        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SECAO, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Produtos.aspx")
            End If
        End Sub


        Protected Sub cboTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
            trEmbalagem.Visible = (cboTipo.SelectedValue <> "P")
        End Sub

        Protected Sub rptTransacao_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptTransacao.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim txtTransacao As TextBox = CType(e.Item.FindControl("txtTransacao"), TextBox)
                txtTransacao.Enabled = VerificaPermissao(SECAO, ACAO_ALTERARTRANSACAO)
            End If
        End Sub

        Protected Sub grdTabelaProduto_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdTabelaProduto.RowEditing
            grdTabelaProduto.EditIndex = e.NewEditIndex
            BindTabelasPreco()
        End Sub

        Protected Sub grdTabelaProduto_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

            Dim index As Integer = grdTabelaProduto.EditIndex
            Dim row As GridViewRow = grdTabelaProduto.Rows(index)
            Dim vIdTabela As String = grdTabelaProduto.DataKeys(e.RowIndex).Value.ToString()
            Dim intQuantidadeMinima As Integer = 0
            Dim txtQuantidadeMinima As TextBox = row.FindControl("txtQuantidadeMinima")
            If Not txtQuantidadeMinima Is Nothing Then

                If txtQuantidadeMinima.Text <> "" Then
                    intQuantidadeMinima = txtQuantidadeMinima.Text
                    Dim clsTab As New clsTabela
                    clsTab.GravaTabelaProduto(ViewState(VW_IDPRODUTO), vIdTabela, intQuantidadeMinima)
                    clsTab = Nothing
                    grdTabelaProduto.EditIndex = -1

                End If

            End If

            BindTabelasPreco()

        End Sub

        Protected Sub grdTabelaProduto_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
            grdTabelaProduto.EditIndex = -1
            BindTabelasPreco()
        End Sub

    End Class

End Namespace


