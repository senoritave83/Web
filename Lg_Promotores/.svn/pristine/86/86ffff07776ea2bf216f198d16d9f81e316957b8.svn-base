
Imports Classes

Namespace Pages.Visita

    Partial Public Class VisitaProduto
        Inherits XMWebPage
        Dim cls As clsVisitaProduto
        Protected Const VW_IDVISITA As String = "IDVisita"
        Protected Const VW_IDPRODUTO As String = "IDProduto"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsVisitaProduto()

            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDVISITA), ViewState(VW_IDPRODUTO))

                btnEditar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)

                Enabled = False

                Inflate()

                BindPerguntas()

            Else

                cls.Load(ViewState(VW_IDVISITA), ViewState(VW_IDPRODUTO))

            End If

            If cls.IDJustificativaRuptura <> 0 Then
                trJustificativaRuptura.Visible = True
            End If
        End Sub

        Protected Property Enabled() As Boolean
            Get
                Return cboEncontrado.Enabled
            End Get
            Set(ByVal value As Boolean)
                cboEncontrado.Enabled = value
                cboVisualizouEstoque.Enabled = value
                txtEstoque.Enabled = value
                txtPreco.Enabled = value
                cboPesquisado.Enabled = value
                btnGravar.Enabled = value And VerificaPermissao(SecaoAtual, ACAO_EDITAR)
            End Set
        End Property

        Protected Sub Inflate()

            Dim vis As New clsVisita()
            vis.Load(ViewState(VW_IDVISITA))
            lblLoja.Text = vis.Loja
            lblPromotor.Text = vis.Promotor
            vis = Nothing

            Dim prd As New clsProduto()
            Dim sct As New clsSubCategoria()
            Dim cat As New clsCategoria()

            Try

                prd.Load(cls.IDProduto)
                sct.Load(prd.IDSubCategoria)
                cat.Load(prd.IDCategoria)

                lblSegmento.Text = cat.Categoria
                lblCategoria.Text = sct.SubCategoria

            Catch ex As Exception

            Finally

                prd = Nothing
                sct = Nothing
                cat = Nothing

            End Try

            lblProduto.Text = cls.Produto
            lblJustificativaRuptura.Text = cls.JustificativaRuptura
            setComboValue(cboEncontrado, IIf(cls.Encontrado, 1, 0))
            txtPreco.Text = FormatNumber(cls.Preco, 2)
            setComboValue(cboVisualizouEstoque, cls.VisualizouEstoque)
            txtEstoque.Text = cls.Estoque
            setComboValue(cboPesquisado, IIf(cls.Pesquisado, 1, 0))

            ChecaRegra()

            'txtData.Text = cls.Data

        End Sub

        Protected Sub Deflate()
            cls.Encontrado = (cboEncontrado.SelectedValue = 1)
			cls.Preco = txtPreco.Text
            cls.VisualizouEstoque = cboVisualizouEstoque.SelectedValue
            cls.Estoque = txtEstoque.Text
            cls.Pesquisado = (cboPesquisado.SelectedValue = 1)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Dim strTexto As String = ""
            If cls.Encontrado <> (cboEncontrado.SelectedValue = 1) Then
                strTexto = "Alterar dados do produto """ & cls.Produto & """ (" & cls.IDProduto & ") na visita (" & cls.IDVisita & "), Registrado como produto " & IIf(cboEncontrado.SelectedValue = 1, "encontrado", "não encontrado")
            Else
                strTexto = "Alterar dados do produto """ & cls.Produto & """ (" & cls.IDProduto & ") na visita (" & cls.IDVisita & ")"
            End If
            Deflate()
            If cls.isValid Then
                Me.User.Log("Visitas", strTexto)
                cls.Update()
                Inflate()
                MostraGravado("~/Visita/VisitaProduto.aspx?idvisita=" & cls.IDVisita & "&idproduto=" & cls.IDProduto)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
            Enabled = True
        End Sub


#Region "Grid Perguntas"

        Public Sub BindPerguntas()
            Dim ret As IPaginaResult = cls.ListarPerguntasProduto(ViewState("Filtro"), SortExpression, SortDirection, pagPerguntas.CurrentPage, PAGESIZE)
            dtgPerguntas.DataSource = ret.Data
            dtgPerguntas.DataBind()
            pagPerguntas.DataSource = ret
            pagPerguntas.DataBind()
            ret = Nothing
        End Sub

        Private Sub pagProdutos_OnPageChanged() Handles pagPerguntas.OnPageChanged
            BindPerguntas()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            pagPerguntas.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindPerguntas()
        End Sub


        Private Sub dtgPerguntas_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgPerguntas.Sorted
            BindPerguntas()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            pagPerguntas.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindPerguntas()
        End Sub

        Protected Sub dtgPerguntas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dtgPerguntas.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim s As String = ""
                If e.Row.DataItem("TipoCampo") = 2 Then
                    Dim img As controls.ImageRotator
                    Dim strImagePath As String = "~/imagens/fotos/"
                    img = LoadControl("~/controls/imagerotator.ascx")
                    img.onClientClick = "fncImageClick"
                    Dim strImages() As String = Split(e.Row.DataItem("Resposta"), ",")
                    For i As Integer = 0 To strImages.GetUpperBound(0)
                        img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                    Next
                    img.Visible = True
                    e.Row.Cells(1).Controls.Add(img)
                Else
                    e.Row.Cells(1).Text = e.Row.DataItem("Resposta")
                End If

            End If
        End Sub


#Region "Sorting"


        Private Sub dtgPerguntas_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dtgPerguntas.Sorting
            If SortExpression = e.SortExpression Then
                If SortDirection = WebControls.SortDirection.Ascending Then
                    SortDirection = WebControls.SortDirection.Descending
                Else
                    SortDirection = WebControls.SortDirection.Ascending
                End If
            Else
                SortExpression = e.SortExpression
                SortDirection = WebControls.SortDirection.Ascending
            End If
        End Sub

        Protected Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                ViewState("SortExpression") = value
            End Set
        End Property

        Protected Property SortDirection() As SortDirection
            Get
                If ViewState("SortDirection") Is Nothing Then
                    Return WebControls.SortDirection.Ascending
                Else
                    Return ViewState("SortDirection")
                End If
            End Get
            Set(ByVal value As SortDirection)
                ViewState("SortDirection") = value
            End Set
        End Property

#End Region

#End Region

#Region "Regras do cadastro"

        Protected Sub ChecaRegra()
            lblHideEstoque.Visible = IIf(cboEncontrado.SelectedValue = 0, True, False)
            lblHidePreco.Visible = lblHideEstoque.Visible
            lblHideVisualizouEstoque.Visible = lblHideEstoque.Visible
            txtEstoque.Visible = Not lblHideEstoque.Visible
            txtPreco.Visible = Not lblHideEstoque.Visible
            cboVisualizouEstoque.Visible = Not lblHideEstoque.Visible
            plhPainel.Visible = IIf(cboPesquisado.SelectedValue = 1, True, False)
        End Sub

        Protected Sub cboEncontrado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEncontrado.SelectedIndexChanged
            ChecaRegra()
        End Sub

#End Region

        Protected Sub cboPesquisado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPesquisado.SelectedIndexChanged
            ChecaRegra()
        End Sub
    End Class

End Namespace

