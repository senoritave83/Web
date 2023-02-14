Imports System.Configuration.ConfigurationManager
Imports Classes

Namespace Pages.Visita

    Partial Public Class Visita
        Inherits XMWebPage
        Dim cls As clsVisita
        Protected Const VW_IDVISITA As String = "IDVisita"
        Protected Const VW_IDLOJA As String = "IDLOJA"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                cls.Load(ViewState(VW_IDVISITA))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)

                carregaCategorias()

                Dim tjf As New clsTipoJustificativa
                cboIDTipoJustificativa.DataSource = tjf.Listar
                cboIDTipoJustificativa.DataBind()
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("Selecione", -1))

                Dim blnAltera As Boolean = SettingsExpression.GetProperty("alterar", "Visita.Loja", False)
                If blnAltera Then
                    Dim loj As New clsLoja
                    cboIDLoja.DataSource = loj.Listar
                    cboIDLoja.DataBind()
                    cboIDLoja.Items.Insert(0, New ListItem("Selecione..", 0))
                    lblLoja.Visible = False
                Else
                    lblLoja.Text = cls.Loja
                    cboIDLoja.Visible = False
                    valReqIDLoja.Enabled = False
                End If

                Dim pro As New clsPromotor
                cboIDPromotor.DataSource = pro.Listar
                cboIDPromotor.DataBind()
                cboIDPromotor.Items.Insert(0, New ListItem("Selecione..", 0))

                Inflate()

                BindPerguntas()
                BindEventos()

            Else
                cls.Load(ViewState(VW_IDVISITA))

            End If
        End Sub

        Protected Sub Inflate()
            lblDataRoteiro.Text = cls.Data
            lblDataEnvio.Text = cls.DataEmissao
            Dim clsLoj As New clsLoja
            With clsLoj
                .Load(cls.IDLoja)
                lblEndereco.Text = .Endereco & _
                                    IIf(.Complemento <> "", " - Complemento: " & .Complemento, "") & _
                                    IIf(.Bairro <> "", " - Bairro: " & .Bairro, "") & _
                                    IIf(.Cidade <> "", " - Cidade: " & .Cidade, "") & _
                                    IIf(.UF <> "", " - UF: " & .UF, "")
            End With
            clsLoj = Nothing
            ViewState(VW_IDLOJA) = cls.IDLoja
            'lblPromotor.Text = cls.Promotor
            If cls.Responsavel <> "" Then
                lblResponsavel.Text = cls.Responsavel
                lblTextoResponsavel.Text = "Preenchido por:"
            End If
            lblDataInicio.Text = cls.DataInicio
            lblDataFinalizacao.Text = cls.DataFinalizacao
            lblStatus.Text = cls.Status
            lblTotalProdutos.Text = cls.NumProdutosVisita
            lblProdutoPesquisados.Text = cls.ProdutosColetados
            If cls.NumProdutosVisita > 0 Then
                lblProdutoPesquisados.Text &= " (" & FormatPercent(cls.ProdutosColetados / cls.NumProdutosVisita, 2) & ")"
            End If

            grdSumario.DataSource = cls.getSumario
            grdSumario.DataBind()

            grdSumario.Visible = grdSumario.Rows.Count > 0

            setComboValue(cboIDTipoJustificativa, cls.IDTipoJustificativa)
            cboIDTipoJustificativa.Enabled = ((cls.IDStatus And 4) = 0)

            locDadosLocalizacaoInicial.Latitude = cls.LatitudeInicial
            locDadosLocalizacaoInicial.Longitude = cls.LongitudeInicial

            locDadosLocalizacaoFinal.Latitude = cls.LatitudeFinal
            locDadosLocalizacaoFinal.Longitude = cls.LongitudeFinal

            locDadosLocalizacaoLoja.Latitude = cls.LatitudeLoja
            locDadosLocalizacaoLoja.Longitude = cls.LongitudeLoja

            locDadosLocalizacaoLoja.IDEmpresa = User.IDEmpresa
            locDadosLocalizacaoLoja.IDVisita = cls.IDVisita
            locDadosLocalizacaoLoja.TipoMapa = 0 'Loja

            locDadosLocalizacaoInicial.IDEmpresa = User.IDEmpresa
            locDadosLocalizacaoInicial.IDVisita = cls.IDVisita
            locDadosLocalizacaoInicial.TipoMapa = 1 'Inicio da Visita

            locDadosLocalizacaoFinal.IDEmpresa = User.IDEmpresa
            locDadosLocalizacaoFinal.IDVisita = cls.IDVisita
            locDadosLocalizacaoFinal.TipoMapa = 2 'Fim da Visita

            cboIDStatusVisita.SelectedValue = cls.StatusVisita
            cboIDPromotor.SelectedValue = cls.IDPromotor
            cboIDLoja.SelectedValue = cls.IDLoja
            cboTeste.SelectedValue = cls.Teste


            BindProdutos()

            '-----------------------------------------------
            'VERIFICA SE EXIBE OU NÃO OS DADOS DE MOTIVO
            'DE USO DO FORMULÁRIO ON-LINE
            'MARCELO R. 25/08/2010
            '-----------------------------------------------
            lblMotivoUsoFormTit.Visible = cls.IdMotivoUsoForm > 0
            lblMotivoUsoForm.Visible = cls.IdMotivoUsoForm > 0
            lblMotivoUsoForm.Text = cls.MotivoUsoForm

        End Sub


#Region "Grid Produtos"

        Protected Function FiltrarPor() As clsVisitaProduto.enFiltroPesquisada
            If cboFiltrarPor.SelectedValue = 0 Then
                Return clsVisitaProduto.enFiltroPesquisada.ProdutosNaoPesquisados
            ElseIf cboFiltrarPor.SelectedValue = 1 Then
                Return clsVisitaProduto.enFiltroPesquisada.ProdutosPesquisados
            Else
                Return clsVisitaProduto.enFiltroPesquisada.TodosProdutos
            End If
        End Function

        Public Sub BindProdutos()
            Dim vsp As New clsVisitaProduto
            Dim ret As IPaginaResult = vsp.Listar(cls.IDVisita, FiltrarPor(), pagProdutos.Filtro, getComboValue(cboSegmento), getComboValue(cboCategoria), pagProdutos.SortExpression, pagProdutos.SortDirection, pagProdutos.CurrentPage, PAGESIZE)
            dtgProdutos.DataSource = ret.Data
            dtgProdutos.DataBind()
            pagProdutos.DataSource = ret
            pagProdutos.DataBind()
            ret = Nothing
        End Sub

        Private Sub carregaCategorias()

            Dim clsCat As clsCategoria
            clsCat = New clsCategoria
            cboSegmento.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
            cboSegmento.DataBind()
            cboSegmento.Items.Insert(0, New ListItem("TODOS", "0"))
            clsCat = Nothing

        End Sub

        Private Sub carregaSubCategorias()

            cboCategoria.Items.Clear()

            Dim p_Categorias As String = getComboValues(cboSegmento)

            Dim clsSubCat As clsSubCategoria
            clsSubCat = New clsSubCategoria
            cboCategoria.DataSource = clsSubCat.Listar(p_Categorias, DataClass.enReturnType.DataReader)
            cboCategoria.DataBind()
            cboCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
            clsSubCat = Nothing

        End Sub

        Private Sub pagProdutos_OnPageChanged() Handles pagProdutos.OnPageChanged
            BindProdutos()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            pagProdutos.CurrentPage = 0
            pagProdutos.Filtro = txtFiltro.Text
            BindProdutos()
        End Sub

        Private Sub dtgProdutos_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgProdutos.Sorted
            BindProdutos()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            pagProdutos.CurrentPage = 0
            pagProdutos.Filtro = txtFiltro.Text
            BindProdutos()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dtgProdutos.Sorting
            pagProdutos.SortExpression = e.SortExpression
        End Sub
        
#End Region

        Protected Sub BindPerguntas()
            dtgPerguntas.DataSource = cls.ListarPerguntasLoja()
            dtgPerguntas.DataBind()
        End Sub

        Protected Sub BindEventos()
            grdEventosLoja.DataSource = cls.ListarEventosLoja
            grdEventosLoja.DataBind()
        End Sub

        Protected Sub Deflate()
            cls.IDTipoJustificativa = cboIDTipoJustificativa.SelectedValue
            If cboIDLoja.Visible = False Then
                cls.IDLoja = ViewState(VW_IDLOJA)
            Else
                cls.IDLoja = cboIDLoja.SelectedValue
            End If
            cls.IDPromotor = cboIDPromotor.SelectedValue
            cls.StatusVisita = cboIDStatusVisita.SelectedValue
            cls.Teste = cboTeste.SelectedValue

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Visita/Visita.aspx?idvisita=" & cls.IDVisita)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Protected Function isEncontrado(ByVal value As Object) As Boolean
            If IsDBNull(value) Then
                Return False
            Else
                Return CBool(value)
            End If
        End Function

        Protected Function Encontrado(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                If value = True Then
                    Return "Sim"
                Else
                    Return "Não"
                End If
            End If
        End Function

        Protected Function GetPreco(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                Return FormatCurrency(value, 2)
            End If
        End Function

        Protected Function GetNullable(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                Return value
            End If
        End Function


        Protected Sub cboSegmento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSegmento.SelectedIndexChanged
            carregaSubCategorias()
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

                        If strImages(i).Trim() <> "" Then
                            If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                                img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                            Else
                                img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                            End If
                        End If
                        'img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                    Next
                    img.Visible = True
                    e.Row.Cells(1).Controls.Add(img)
                Else
                    e.Row.Cells(1).Text = e.Row.DataItem("Resposta")
                End If

            End If
        End Sub
    End Class

End Namespace

