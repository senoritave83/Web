Imports Classes

Partial Class formulario_visita
    Inherits XMWebPage

    Protected cls As clsFormVisita


    Protected Sub BindMotivoUsoForm()
        With drpMotivoUsoForm
            .Items.Clear()
            .DataSource = cls.ListarMotivosUsoForm
            .DataBind()
            .Items.Insert(0, New ListItem("Selecione o motivo...", "0"))
        End With
    End Sub

    Protected Sub BindPerguntaLoja()
        pnlPerguntasLoja.Visible = cls.LojaPerguntas > 0
        If cls.LojaPerguntas > 0 Then
            lblPerguntasLoja.Text = "Perguntas na loja " & cls.LojaPerguntas & " / " & cls.LojaPerguntasRespondidas & "" & IIf(cls.LojaPerguntas = cls.LojaPerguntasRespondidas, "(OK)", "")
        End If
        grdPerguntasLoja.DataSource = cls.ListarPerguntasLoja()
        grdPerguntasLoja.DataBind()
    End Sub

    Protected Sub BindItensLoja()
        'grdItens.DataSource = cls.Listar
        grdCategorias.DataSource = cls.ListarCategorias()
        grdCategorias.DataBind()

        If CInt("0" & ViewState("IDCATEGORIA")) > 0 Then

            grdCategorias.Visible = False
            pnlCategorias.Visible = True

            grdFornecedores.DataSource = cls.ListarMarcas(CInt("0" & ViewState("IDCATEGORIA")))
            grdFornecedores.DataBind()
            If CInt("0" & ViewState("IDFORNECEDOR")) > 0 Then
                grdFornecedores.Visible = False
                pnlFornecedores.Visible = True

                grdProdutos.DataSource = cls.ListarProdutos(CInt("0" & ViewState("IDCATEGORIA")), CInt("0" & ViewState("IDFORNECEDOR")))
                grdProdutos.DataBind()
                'If CInt("0" & ViewState("IDPRODUTO")) > 0 Then
                '    grdProdutos.Visible = False
                '    pnlProduto.Visible = True
                '    lblAtual.Text = "Produto"
                'Else
                '    grdProdutos.Visible = True
                '    pnlProduto.Visible = False
                'End If
                lblAtual.Text = "Produtos"
                lnkVoltarCat.Visible = True
                lnkVoltarFornecedor.Visible = True
            Else
                grdFornecedores.Visible = True
                pnlFornecedores.Visible = False
                lblAtual.Text = "Marca"
                lnkVoltarCat.Visible = True
                lnkVoltarFornecedor.Visible = False
            End If

        Else
            grdCategorias.Visible = True
            pnlCategorias.Visible = False
            lblAtual.Text = "Segmento"
            lnkVoltarCat.Visible = False
            lnkVoltarFornecedor.Visible = False
        End If

        btnEditar.Attributes("onclick") = "fncAbrirEdicao(" & CInt("0" & ViewState("IDCATEGORIA")) & ", 0, " & CInt("0" & ViewState("IDFORNECEDOR")) & ");"

    End Sub





    Protected Sub grdCategorias_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdCategorias.RowCommand
        If e.CommandName = "Abrir" Then
            Dim cat As New clsCategoria
            cat.Load(grdCategorias.DataKeys(e.CommandArgument).Value)
            lblCategoria.Text = cat.Categoria
            ViewState("IDCATEGORIA") = cat.IDCategoria
            cat = Nothing
            BindItensLoja()
        End If
    End Sub

    Protected Sub grdFornecedores_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdFornecedores.RowCommand
        If e.CommandName = "Abrir" Then
            Dim frn As New clsFornecedor
            frn.Load(grdFornecedores.DataKeys(e.CommandArgument).Value)
            lblFornecedor.Text = frn.Fornecedor
            ViewState("IDFORNECEDOR") = frn.IDFornecedor
            frn = Nothing
            BindItensLoja()
        End If
    End Sub


    Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
        If e.CommandName = "Abrir" Then
            Response.Redirect("produto.aspx?idvisita=" & ViewState("IDVISITA") & "&idproduto=" & grdProdutos.DataKeys(e.CommandArgument).Value)
        End If
    End Sub

    Protected Sub lnkVoltarCat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVoltarCat.Click
        ViewState("IDPRODUTO") = 0
        ViewState("IDFORNECEDOR") = 0
        ViewState("IDCATEGORIA") = 0
        BindItensLoja()
    End Sub

    Protected Sub lnkVoltarFornecedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVoltarFornecedor.Click
        ViewState("IDPRODUTO") = 0
        ViewState("IDFORNECEDOR") = 0
        BindItensLoja()
    End Sub

    'Protected Sub lnkVoltarProduto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVoltarProduto.Click
    '    ViewState("IDPRODUTO") = 0
    '    BindItensLoja()
    'End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita
        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = CInt("0" & Request("IDVisita"))
            ViewState("IDPRODUTO") = CInt("0" & Request("idproduto"))
            ViewState("IDCATEGORIA") = CInt("0" & Request("cat"))
            ViewState("IDFORNECEDOR") = CInt("0" & Request("for"))
        End If
        cls.Load(ViewState("IDVISITA"))

        If cls.IDVisita = 0 Then
            Response.Redirect("default.aspx")
        End If

        If Not Page.IsPostBack Then
            lblPromotor.Text = cls.Promotor
            lblLoja.Text = cls.Loja
            lblData.Text = cls.Data

            If ViewState("IDPRODUTO") > 0 Then
                Dim prd As New clsProduto
                prd.Load(ViewState("IDPRODUTO"))
                ViewState("IDCATEGORIA") = prd.IDCategoria
                ViewState("IDFORNECEDOR") = prd.IDFornecedor
            End If

            BindPerguntaLoja()
            BindItensLoja()
            BindMotivoUsoForm()

        End If

    End Sub

    Protected Sub grdPerguntasLoja_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerguntasLoja.RowCommand
        If e.CommandName = "Abrir" Then
            Response.Redirect("perguntaloja.aspx?idvisita=" & ViewState("IDVISITA") & "&idpergunta=" & grdPerguntasLoja.DataKeys(e.CommandArgument).Value)
        End If
    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        btnFinalizar.Visible = False
        tblMotivoUsoForm.Visible = True
    End Sub

    Protected Sub btnConfirmarFinalizacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmarFinalizacao.Click

        cls.IdMotivoUsoForm = drpMotivoUsoForm.SelectedItem.Value
        cls.Update()

        If cls.VisitaCompleta Then
            Response.Redirect("finalizar.aspx?idvisita=" & ViewState("IDVISITA"))
        Else
            Response.Redirect("justificar.aspx?idvisita=" & ViewState("IDVISITA"))
        End If

    End Sub
End Class
