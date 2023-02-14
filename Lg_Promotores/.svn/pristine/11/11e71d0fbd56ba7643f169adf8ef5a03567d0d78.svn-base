Imports Classes
Imports System.Data


Partial Class formulario_produto
    Inherits XMWebPage
    Protected cls As clsFormVisita
    Protected prd As clsProduto

    Protected blnPreco As Boolean
    Protected blnEstoque As Boolean
    Protected blnPerguntas As Boolean

    Protected blnForward As Boolean = True

    Protected FormProduto As clsFormVisita.clsFormProduto


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita
        prd = New clsProduto
        FormProduto = New clsFormVisita.clsFormProduto

        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = Request("idvisita")
            ViewState("IDPRODUTO") = Request("idproduto")
        End If
        cls.Load(ViewState("IDVISITA"))
        prd.Load(ViewState("IDPRODUTO"))
        FormProduto.Load(ViewState("IDVISITA"), ViewState("IDPRODUTO"))

        blnPreco = (FormProduto.Acao And clsFormVisita.clsFormProduto.enAcao.Preco) > 0
        blnEstoque = (FormProduto.Acao And clsFormVisita.clsFormProduto.enAcao.Estoque) > 0
        blnPerguntas = (FormProduto.Acao And clsFormVisita.clsFormProduto.enAcao.Perguntas) > 0

        If Not Page.IsPostBack Then
            lblPromotor.Text = cls.Promotor
            lblLoja.Text = cls.Loja
            lblData.Text = cls.Data
            lblProduto.Text = prd.Descricao


            blnForward = True
            Carregar()
            MostraEtapa()
        End If

    End Sub

    Protected Property IDEtapa() As Integer
        Get
            Return CInt("0" & ViewState("IDETAPA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDETAPA") = value
        End Set
    End Property

    Protected Property IDCurrentPergunta() As Integer
        Get
            Return CInt("0" & ViewState("IDCURRENTPERGUNTA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDCURRENTPERGUNTA") = value
        End Set
    End Property


    Protected Function Valido() As Boolean
        If IDEtapa = 0 Then
            Return chkSim.Checked Or chkNao.Checked
        ElseIf IDEtapa = 1 Then
            If IsNumeric(txtPreco.Text) Then
                Dim temp As Decimal = CDec(txtPreco.Text)

                If (temp >= prd.PrecoMinimo And (temp <= prd.PrecoMaximo Or prd.PrecoMaximo = 0)) Then
                    Return True
                Else
                    lblValidate.Text = "Preço fora do intervalo!"
                    Return False
                End If
            Else
                lblValidate.Text = "Por favor informe o preço!"
                Return False
            End If
        ElseIf IDEtapa = 2 Then
            Return (chkVisualizouSim.Checked And IsNumeric(txtEstoque.Text)) Or (chkVisualizouSim.Checked = False)
        End If
        Return True
    End Function

    Protected Sub Gravar()
        If IDEtapa = 0 Then
            If chkSim.Checked Then
                FormProduto.Encontrado = True
            Else
                FormProduto.Encontrado = False
                FormProduto.Estoque = 0
                FormProduto.Preco = 0
                FormProduto.LimparRespostas()
            End If
        ElseIf IDEtapa = 1 Then
            FormProduto.Preco = CDec(txtPreco.Text)
        ElseIf IDEtapa = 2 Then
            If chkVisualizouSim.Checked Then
                FormProduto.VisualizouEstoque = clsFormVisita.clsFormProduto.Visualizou.Sim
                FormProduto.Estoque = txtEstoque.Text
            ElseIf chkVisualizouNao.Checked Then
                FormProduto.VisualizouEstoque = clsFormVisita.clsFormProduto.Visualizou.Nao
                FormProduto.Estoque = 0
            Else
                FormProduto.VisualizouEstoque = clsFormVisita.clsFormProduto.Visualizou.NaoPermitido
                FormProduto.Estoque = 0
            End If
        End If
        FormProduto.Update()

    End Sub

    Protected Sub Carregar()
        lblValidate.Text = ""
        If IDEtapa = 0 Then
            If FormProduto.Encontrado Then
                chkSim.Checked = True
            Else
                chkNao.Checked = True
            End If
        ElseIf IDEtapa = 1 Then
            lblPrecoSugerido.Text = FormatCurrency(prd.PrecoSugerido, 2)
            lblPrecoMin.Text = FormatCurrency(prd.PrecoMinimo, 2)
            lblPrecoMax.Text = FormatCurrency(prd.PrecoMaximo, 2)
            plhPrecoSugerido.Visible = (prd.PrecoSugerido <> 0)
            plhPrecoMinimo.Visible = (prd.PrecoMinimo <> 0)
            plhPrecoMaximo.Visible = (prd.PrecoMaximo <> 0)
            txtPreco.Text = FormatNumber(FormProduto.Preco, 2)
        ElseIf IDEtapa = 2 Then
            If FormProduto.VisualizouEstoque = clsFormVisita.clsFormProduto.Visualizou.Sim Then
                chkVisualizouSim.Checked = True
            ElseIf FormProduto.VisualizouEstoque = clsFormVisita.clsFormProduto.Visualizou.Nao Then
                chkVisualizouNao.Checked = True
            Else
                chkVisualizouNaoPermitido.Checked = True
            End If

            chkVisualizouNaoPermitido.Visible = (prd.IDFornecedor <> 1)

            pnlQtdEstoque.Visible = chkVisualizouSim.Checked
            txtEstoque.Text = FormProduto.Estoque
        End If
    End Sub


    Protected Sub Avancar()
        If Valido() Then
            Gravar()
            blnForward = True
            IDEtapa += 1
            Carregar()
            MostraEtapa()
        End If
    End Sub

    Protected Sub Voltar()
        blnForward = False
        IDEtapa -= 1
        If IDEtapa < 0 Then IDEtapa = 0
        Carregar()
        MostraEtapa()
        lblValidate.Text = ""
    End Sub

    Protected Sub Pular()
        If blnForward Then
            IDEtapa += 1
            Carregar()
            MostraEtapa()
        ElseIf IDEtapa > 0 Then
            IDEtapa -= 1
            Carregar()
            MostraEtapa()
        End If
    End Sub

    Protected Sub MostraEtapa()
        btnVoltar.Enabled = True
        pnlEncontrado.Visible = False
        pnlPreco.Visible = False
        pnlEstoque.Visible = False
        pnlPergunta.Visible = False

        btnProximaPerg.Visible = False
        btnAnteriorPerg.Visible = False
        btnVoltar.Visible = True
        btnAvancar.Visible = True

        If IDEtapa = 0 Then
            btnVoltar.Enabled = False
            pnlEncontrado.Visible = True
        ElseIf IDEtapa = 1 Then
            If blnPreco And FormProduto.Encontrado Then
                pnlPreco.Visible = True
            Else
                Pular()
            End If
        ElseIf IDEtapa = 2 Then
            If blnEstoque And FormProduto.Encontrado Then
                pnlEstoque.Visible = True
            Else
                Pular()
            End If
        ElseIf IDEtapa = 3 Then
            If blnPerguntas And FormProduto.Encontrado Then
                btnProximaPerg.Visible = True
                btnAnteriorPerg.Visible = True
                btnVoltar.Visible = False
                btnAvancar.Visible = False
                pnlPergunta.Visible = True
                ExibirPergunta()
            Else
                Pular()
            End If
        ElseIf IDEtapa > 3 Then
            Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA") & "&idproduto=" & ViewState("IDPRODUTO"))
        End If
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Voltar()
    End Sub

    Protected Sub btnVoltarVisita_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltarVisita.Click
        Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA") & "&idproduto=" & ViewState("IDPRODUTO"))
    End Sub

    Protected Sub btnAvancar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvancar.Click
        Avancar()
    End Sub

    Protected Sub chkVisualizouSim_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVisualizouSim.CheckedChanged
        pnlQtdEstoque.Visible = chkVisualizouSim.Checked
    End Sub

    Protected Sub chkVisualizouNaoPermitido_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVisualizouNaoPermitido.CheckedChanged
        pnlQtdEstoque.Visible = chkVisualizouSim.Checked
    End Sub

    Protected Sub chkVisualizouNao_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVisualizouNao.CheckedChanged
        pnlQtdEstoque.Visible = chkVisualizouSim.Checked
    End Sub

    Protected Property IndexPergunta() As Integer
        Get
            Return CInt("0" & ViewState("INDEXPERGUNTA"))
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Voltar()
            Else
                ViewState("INDEXPERGUNTA") = value
            End If
        End Set
    End Property

    Protected Sub ExibirPergunta()
        Dim dr As IDataReader
        dr = FormProduto.ListarPerguntas
        Dim iTemp As Integer = 0
        Dim blnEncontrado As Boolean = False
        Dim strRespostaSimples As String = ""
        Do While dr.Read
            If iTemp = IndexPergunta Then
                IDCurrentPergunta = dr.GetInt32(dr.GetOrdinal("IDPergunta"))
                If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                    strRespostaSimples = dr.GetString(dr.GetOrdinal("Resposta"))
                End If
                blnEncontrado = True
                Exit Do
            End If
            iTemp += 1
        Loop
        dr.Close()
        dr.Dispose()

        If Not blnEncontrado Then
            Pular()
        Else
            pergunta1.Mostrar(IDCurrentPergunta, FormProduto.ListarRespostas(IDCurrentPergunta), strRespostaSimples)
        End If
    End Sub


    Protected Sub btnAnteriorPerg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnteriorPerg.Click
        IndexPergunta -= 1
        ExibirPergunta()
    End Sub

    Protected Sub btnProximaPerg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProximaPerg.Click

        Dim colRespostas As Generic.List(Of String)
        colRespostas = pergunta1.GetRespostas()

        If colRespostas.Count > 0 Then
            lblValidate.Text = ""
            FormProduto.AdicionarRespostas(IDCurrentPergunta, colRespostas.ToArray())
            IndexPergunta += 1
            ExibirPergunta()
        Else
            lblValidate.Text = "Por favor informe a resposta!"
        End If
    End Sub

End Class
