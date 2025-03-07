Imports System.Configuration.ConfigurationManager
Imports Classes

Namespace Pages.Visita

    Partial Public Class Visita
        Inherits XMWebPage
        Protected cls As clsVisita
        Protected Const VW_IDVISITA As String = "IDVisita"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then

                ViewState(VW_IDVISITA) = CInt("0" & Request("IDVisita"))
                If Not cls.Load(ViewState(VW_IDVISITA)) Then
                    Response.Redirect("visitas.aspx")
                End If
                btnGravar.Enabled = VerificaPermissao(Secao, ACAO_EDITAR)

                carregaCategorias()

                Dim tjf As New clsTipoJustificativa
                cboIDTipoJustificativa.DataSource = tjf.Listar
                cboIDTipoJustificativa.DataBind()
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("Selecione", -1))

                ViewState("blnAltera") = Convert.ToBoolean(SettingsExpression.GetProperty("alterar", "Visita.Loja", False))
                If ViewState("blnAltera") Then
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

                Dim pro As New clsUsuario
                cboIDPromotor.DataSource = pro.ListarUsuariosVisita
                cboIDPromotor.DataBind()
                cboIDPromotor.Items.Insert(0, New ListItem("Selecione..", 0))

                Inflate()

                BindGrids()

            Else

                cls.Load(ViewState(VW_IDVISITA))

            End If
        End Sub

        Private Sub BindGrids()

            BindPerguntas()
            BindPerguntasSegmento()
            BindPerguntasCategoria()
            BindPerguntasAmostragem()

            BindEventos()
            BindTarefas()
            BindPesquisas()

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

            cboIDStatusVisita.SelectedValue = cls.StatusVisita
            cboIDPromotor.SelectedValue = cls.IDPromotor
            cboIDLoja.SelectedValue = cls.IDLoja
            cboTeste.SelectedValue = cls.Teste

            BindProdutos()

            '-----------------------------------------------
            'VERIFICA SE EXIBE OU N�O OS DADOS DE MOTIVO
            'DE USO DO FORMUL�RIO ON-LINE
            'MARCELO R. 25/08/2010
            '-----------------------------------------------
            lblMotivoUsoFormTit.Visible = cls.IdMotivoUsoForm > 0
            lblMotivoUsoForm.Visible = cls.IdMotivoUsoForm > 0
            lblMotivoUsoForm.Text = cls.MotivoUsoForm

        End Sub

        'Protected Sub BindCategorias()
        '    'rptEntidades.DataSource = cls.ListarCategoriasVisita(cboSegmento.SelectedValue)
        '    'rptEntidades.DataBind()
        'End Sub

        'Protected Sub BindRespostasEntidade(ByVal vEntidade As Geral.enTipoEntidade)
        '    'rptEntidades.DataSource = cls.ListarRespostasEntidade(vEntidade, ViewState(VW_IDVISITA))
        '    'rptEntidades.DataBind()
        'End Sub


        Protected Sub BindPesquisas()
            grdPesquisas.DataSource = cls.ListarPesquisas()
            grdPesquisas.DataBind()
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
            'BindCategorias()
        End Sub

        Private Sub dtgProdutos_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgProdutos.Sorted
            BindProdutos()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            pagProdutos.CurrentPage = 0
            pagProdutos.Filtro = txtFiltro.Text
            BindProdutos()
            'BindCategorias()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dtgProdutos.Sorting
            pagProdutos.SortExpression = e.SortExpression
        End Sub
        
#End Region

        Protected Function BindSubCategorias(ByVal vIDCategoria As Integer) As Data.IDataReader
            Return cls.ListarSubCategoriasVisita(vIDCategoria, cboCategoria.SelectedValue, DataClass.enReturnType.DataReader)
        End Function

        Protected Function BindProdutos(ByVal vIDSubCategoria As Integer) As Data.IDataReader
            Dim vsp As New clsVisitaProduto
            Return vsp.Listar(cls.IDVisita, clsVisitaProduto.enFiltroPesquisada.TodosProdutos, "", 0, vIDSubCategoria, "", False, 0, 10, DataClass.enReturnType.DataReader).Data
            'Return cls.ListarProdutosVisita(vIDSubCategoria, DataClass.enReturnType.DataReader)
        End Function


        Protected Sub BindPerguntas()
            dtgPerguntas.DataSource = cls.ListarPerguntasEntidade(enTipoEntidade.Loja)
            dtgPerguntas.DataBind()
        End Sub

        Protected Sub BindPerguntasSegmento()
            dtgPerguntasSegmento.DataSource = cls.ListarPerguntasEntidade(enTipoEntidade.Categoria)
            dtgPerguntasSegmento.DataBind()
        End Sub


        Protected Sub BindPerguntasAmostragem()
            grdPerguntasAmostragem.DataSource = cls.ListarPerguntasEntidade(enTipoEntidade.Pesquisa)
            grdPerguntasAmostragem.DataBind()
        End Sub


        Protected Sub BindPerguntasCategoria()
            dtgPerguntasCategoria.DataSource = cls.ListarPerguntasEntidade(enTipoEntidade.SubCategoria)
            dtgPerguntasCategoria.DataBind()
        End Sub

        Protected Sub BindEventos()
            grdEventosLoja.DataSource = cls.ListarEventosLoja
            grdEventosLoja.DataBind()
        End Sub

        Protected Sub BindTarefas()
            grdTarefas.DataSource = cls.ListarTarefasLoja
            grdTarefas.DataBind()
        End Sub

        Protected Sub Deflate()
            cls.IDTipoJustificativa = cboIDTipoJustificativa.SelectedValue
            If ViewState("blnAltera") Then
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

        Protected Function Estoque(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                If value = True Then
                    Return "Sim"
                Else
                    Return "N�o"
                End If
            End If
        End Function

        Protected Function Encontrado(ByVal value As Object) As String
            If IsDBNull(value) Then
                Return ""
            Else
                If value = True Then
                    Return "Sim"
                Else
                    Return "N�o"
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
                Dim img As inccontrols.ImageRotator = e.Row.FindControl("imgRotatorLoja")
                If e.Row.DataItem("TipoCampo") = 2 Then
                    If Not img Is Nothing Then
                        Dim strImagePath As String = "~/imagens/fotos/"
                        img.onClientClick = "fncImageClick"
                        Dim strImages() As String = Split(e.Row.DataItem("Resposta") & "", ",")
                        For i As Integer = 0 To strImages.GetUpperBound(0)

                            If strImages(i).Trim() <> "" Then
                                If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                                Else
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                                End If
                            End If
                        Next
                    End If
                ElseIf e.Row.DataItem("TipoCampo") = 1 Then
                    Dim strNumero As String = e.Row.DataItem("Resposta") & ""
                    If IsNumeric(strNumero) Then
                        strNumero = CInt(strNumero)
                    End If
                    e.Row.Cells(1).Text = strNumero
                    img.Visible = False
                Else
                    e.Row.Cells(1).Text = e.Row.DataItem("Resposta") & ""
                    img.Visible = False
                End If

            End If
        End Sub

        Protected Sub dtgPerguntasSegmento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dtgPerguntasSegmento.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim s As String = ""
                Dim img As inccontrols.ImageRotator = e.Row.FindControl("imgRotatorSegmento")
                If e.Row.DataItem("TipoCampo") = 2 Then
                    If Not img Is Nothing Then
                        Dim strImagePath As String = "~/imagens/fotos/"
                        img.onClientClick = "fncImageClick"
                        Dim strImages() As String = Split(e.Row.DataItem("Resposta") & "", ",")
                        For i As Integer = 0 To strImages.GetUpperBound(0)

                            If strImages(i).Trim() <> "" Then
                                If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                                Else
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                                End If
                            End If
                        Next
                    End If
                ElseIf e.Row.DataItem("TipoCampo") = 1 Then
                    Dim strNumero As String = e.Row.DataItem("Resposta") & ""
                    If IsNumeric(strNumero) Then
                        strNumero = CInt(strNumero)
                    End If
                    e.Row.Cells(2).Text = strNumero
                    img.Visible = False
                Else
                    e.Row.Cells(2).Text = e.Row.DataItem("Resposta") & ""
                    img.Visible = False
                End If

            End If
        End Sub


        Protected Sub dtgPerguntasCategoria_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dtgPerguntasCategoria.RowDataBound
          If e.Row.RowType = DataControlRowType.DataRow Then
                Dim s As String = ""
                Dim img As inccontrols.ImageRotator = e.Row.FindControl("imgRotatorCategoria")
                If e.Row.DataItem("TipoCampo") = 2 Then
                    If Not img Is Nothing Then
                        Dim strImagePath As String = "~/imagens/fotos/"
                        img.onClientClick = "fncImageClick"
                        Dim strImages() As String = Split(e.Row.DataItem("Resposta") & "", ",")
                        For i As Integer = 0 To strImages.GetUpperBound(0)

                            If strImages(i).Trim() <> "" Then
                                If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                                Else
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                                End If
                            End If
                        Next
                    End If
                ElseIf e.Row.DataItem("TipoCampo") = 1 Then
                    Dim strNumero As String = e.Row.DataItem("Resposta") & ""
                    If IsNumeric(strNumero) Then
                        strNumero = CInt(strNumero)
                    End If
                    e.Row.Cells(2).Text = strNumero
                    img.Visible = False
                Else
                    e.Row.Cells(2).Text = e.Row.DataItem("Resposta") & ""
                    img.Visible = False
                End If

            End If
        End Sub

        Protected Sub grdPerguntasAmostragem_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPerguntasAmostragem.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim s As String = ""
                Dim img As inccontrols.ImageRotator = e.Row.FindControl("imgRotatorAmostragem")
                If e.Row.DataItem("TipoCampo") = 2 Then
                    If Not img Is Nothing Then
                        Dim strImagePath As String = "~/imagens/fotos/"
                        img.onClientClick = "fncImageClick"
                        Dim strImages() As String = Split(e.Row.DataItem("Resposta") & "", ",")
                        For i As Integer = 0 To strImages.GetUpperBound(0)

                            If strImages(i).Trim() <> "" Then
                                If XMSistemas.XMVirtualFile.VirtualFile.FileExists(strImagePath & strImages(i).Trim()) Then
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(strImagePath & strImages(i).Trim()), ResolveClientUrl("~/thumbnail.ashx?width=100&filename=" & Server.UrlEncode(strImagePath & strImages(i).Trim())))
                                Else
                                    img.Images.Add(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"), XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl("~/imagens/noimage.png"))
                                End If
                            End If
                        Next
                    End If
                ElseIf e.Row.DataItem("TipoCampo") = 1 Then
                    Dim strNumero As String = e.Row.DataItem("Resposta") & ""
                    If IsNumeric(strNumero) Then
                        strNumero = CInt(strNumero)
                    End If
                    e.Row.Cells(1).Text = strNumero
                    img.Visible = False
                Else
                    e.Row.Cells(1).Text = e.Row.DataItem("Resposta") & ""
                    img.Visible = False
                End If

            End If
        End Sub

    End Class

End Namespace

