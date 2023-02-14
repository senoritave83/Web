Imports Classes
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class reports_exportar
    Inherits XMReportPage
    Dim cls As clsExportacao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            carregaClientes()
            carregaCategorias()
            carregaShopping()
            carregaRegioes()
            carregaTipoLojas()
            carregaCoordenadores()
            carregaJustificativas()

            txtDataInicial.Text = Format(DateAdd("d", -6, Now), "dd/MM/yyyy")
            txtDataFinal.Text = Format(Now, "dd/MM/yyyy")

            Me.Root = updrptPrecos

            'Dim VW_PERIODO_TEXTO As String = "pertxt"
            'Dim VW_PERIODO As String = "per"
            'Dim VW_TIPOPESQUISA As String = "tippes"

            Me.ControlsNames(lstCampExp.ID) = "cam"

            Me.ControlsNames(txtDataInicial.ID) = "pi"
            Me.ControlsNames(txtDataFinal.ID) = "pf"

            Me.ControlsNames(lstClientes.ID) = "cli"
            Me.ControlsNames(lstLojas.ID) = "loj"

            Me.ControlsNames(lstLider.ID) = "lid"
            Me.ControlsNames(lstCoordenador.ID) = "crd"
            Me.ControlsNames(lstPromotor.ID) = "pro"

            Me.ControlsNames(lstProduto.ID) = "prd"
            Me.ControlsNames(lstSubCategoria.ID) = "sub"
            Me.ControlsNames(lstCategoria.ID) = "cat"

            Me.ControlsNames(chkEstado.ID) = "est"
            Me.ControlsNames(chkRegiao.ID) = "regiao"
            Me.ControlsNames(chkTipoLoja.ID) = "tiploj"
            Me.ControlsNames(lstShopping.ID) = "shop"
            Me.ControlsNames(lstJustificativa.ID) = "jus"
            Me.ControlsNames(rdStatus.ID) = "sta"
            Me.ControlsNames(rdTabela.ID) = "tab"

            Me.CarregaControles()

            CriaCampos(0)

        End If

    End Sub

    Private Sub CriaCampos(ByVal p_Tipo As Integer)

        With lstCampExp

            .Items.Clear()

            .Items.Add(New ListItem("ID da Visita", "1"))
            .Items.Add(New ListItem("Nome da Loja", "2"))
            .Items.Add(New ListItem("ID da Loja", "3"))
            .Items.Add(New ListItem("Código da Loja", "4"))
            .Items.Add(New ListItem("CNPJ da Loja", "5"))
            .Items.Add(New ListItem("IE da Loja", "6"))
            .Items.Add(New ListItem("Endereço da Loja", "7"))
            .Items.Add(New ListItem("Número da Loja", "8"))
            .Items.Add(New ListItem("Complemento da Loja", "9"))
            .Items.Add(New ListItem("Bairro da Loja", "10"))
            .Items.Add(New ListItem("Cidade da Loja", "11"))
            .Items.Add(New ListItem("UF da Loja", "12"))
            .Items.Add(New ListItem("CEP da Loja", "13"))
            .Items.Add(New ListItem("Contato da Loja", "14"))
            .Items.Add(New ListItem("Cargo do Contato da Loja", "15"))
            .Items.Add(New ListItem("Telefone da Loja", "16"))
            .Items.Add(New ListItem("Celular da Loja", "17"))
            .Items.Add(New ListItem("Fax da Loja", "18"))
            .Items.Add(New ListItem("Email da Loja", "19"))
            .Items.Add(New ListItem("Tipo de Loja", "20"))
            .Items.Add(New ListItem("Shopping", "21"))
            .Items.Add(New ListItem("Região da Loja", "22"))
            .Items.Add(New ListItem("Status da Loja", "23"))
            .Items.Add(New ListItem("Bandeira ID Cliente", "24"))
            .Items.Add(New ListItem("Bandeira Razão Social", "25"))
            .Items.Add(New ListItem("Bandeira Fantasia", "26"))
            .Items.Add(New ListItem("ID do Promotor", "27"))
            .Items.Add(New ListItem("Código do Promotor", "28"))
            .Items.Add(New ListItem("Nome do Promotor", "29"))
            .Items.Add(New ListItem("CPF do Promotor", "30"))
            .Items.Add(New ListItem("Endereço do Promotor", "31"))
            .Items.Add(New ListItem("Número do Promotor", "32"))
            .Items.Add(New ListItem("Complemento do Promotor", "33"))
            .Items.Add(New ListItem("Bairro do Promotor", "34"))
            .Items.Add(New ListItem("Cep do Promotor", "35"))
            .Items.Add(New ListItem("Cidade do Promotor", "36"))
            .Items.Add(New ListItem("UF do Promotor", "37"))
            .Items.Add(New ListItem("Contato do Promotor", "38"))
            .Items.Add(New ListItem("Telefone do Promotor", "39"))
            .Items.Add(New ListItem("Celular do Promotor", "40"))
            .Items.Add(New ListItem("Fax do Promotor", "41"))
            .Items.Add(New ListItem("Email do Promotor", "42"))
            .Items.Add(New ListItem("Cargo do Promotor", "43"))
            .Items.Add(New ListItem("Empresa do Promotor", "44"))
            .Items.Add(New ListItem("Promotor de Teste", "45"))
            .Items.Add(New ListItem("Líder do Promotor", "46"))
            .Items.Add(New ListItem("ID do Líder", "47"))
            .Items.Add(New ListItem("Coordenador do Promotor", "48"))
            .Items.Add(New ListItem("ID do Coordenador", "49"))
            .Items.Add(New ListItem("Data de Início da Visita", "76"))
            .Items.Add(New ListItem("Data de Finalização da Visita", "77"))
            .Items.Add(New ListItem("Data da Visita", "50"))
            .Items.Add(New ListItem("Data do Envio", "78"))
            .Items.Add(New ListItem("Número de Produtos por Visita", "51"))
            .Items.Add(New ListItem("Justificativa", "52"))
            .Items.Add(New ListItem("Número de Produtos Coletados", "53"))
            .Items.Add(New ListItem("Perguntas", "75"))

            If p_Tipo = 1 Then

                .Items.Add(New ListItem("ID do Produto", "54"))
                .Items.Add(New ListItem("Código do Produto", "55"))
                .Items.Add(New ListItem("Descrição do Produto", "56"))
                .Items.Add(New ListItem("Produto Descrição Resumida", "57"))
                .Items.Add(New ListItem("Categoria", "58"))
                .Items.Add(New ListItem("Sub Categoria", "59"))
                .Items.Add(New ListItem("Fornecedor", "60"))
                .Items.Add(New ListItem("Produto Preço Mínimo", "61"))
                .Items.Add(New ListItem("Produto Preço Máximo", "62"))
                .Items.Add(New ListItem("Produto Preço Sugerido", "63"))
                '.Items.Add(New ListItem("Resolução", "64"))
                '.Items.Add(New ListItem("Frequência", "65"))
                '.Items.Add(New ListItem("ScreenSize", "66"))
                '.Items.Add(New ListItem("Conversor", "67"))
                .Items.Add(New ListItem("Status do Comércio", "68"))
                .Items.Add(New ListItem("Produto Visita - Encontrado", "69"))
                .Items.Add(New ListItem("Produto Visita - Preço", "70"))
                .Items.Add(New ListItem("Produto Visita - Visualizou Estoque", "71"))
                .Items.Add(New ListItem("Produto Visita - Estoque", "72"))
                .Items.Add(New ListItem("Produto Visita - Data", "73"))
                .Items.Add(New ListItem("Produto Visita - Pesquisado", "74"))

                '*************************************************
                'OS CAMPOS ABAIXO NÃO FAZEM PARTE DO SISTEMA
                '*************************************************
                '.Items.Add(New ListItem("Loja Possui Balcão p/ Notebook?", "77"))
                '.Items.Add(New ListItem("Existe algum produto que tem na loja e não está na pesquisa?", "78"))
                '.Items.Add(New ListItem("Tem Cubo X- Metal  40 x 40 tem na loja?", "79"))
                '.Items.Add(New ListItem("Total de Monitores LG na Loja", "80"))
                '.Items.Add(New ListItem("Total de Net LG na Loja", "81"))
                '.Items.Add(New ListItem("Total de Net HP na loja", "82"))
                '.Items.Add(New ListItem("Total de Net SANSUNG na loja", "83"))
                '.Items.Add(New ListItem("Total de Net SONY na loja", "84"))
                '.Items.Add(New ListItem("Total de Monitores OUTROS na loja", "85"))
                '.Items.Add(New ListItem("Total de Monitores SANSUNG na loja", "86"))
                '.Items.Add(New ListItem("Total de Net ASUS na loja", "87"))
                '.Items.Add(New ListItem("Qtde produtos estão conectados a TV", "88"))
                '.Items.Add(New ListItem("Qtde produtos estão em outros lugares", "89"))
                '.Items.Add(New ListItem("Qtde produtos presentes na loja", "90"))


            End If

        End With

    End Sub

    Protected Sub carregaJustificativas()
        Dim just As New Classes.clsTipoJustificativa
        lstJustificativa.DataSource = just.Listar()
        lstJustificativa.DataBind()
        lstJustificativa.Items.Insert(0, New ListItem("COM JUSTIFICATIVA", "-1"))
        lstJustificativa.Items.Insert(0, New ListItem("SEM JUSTIFICATIVA", "-2"))
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstJustificativa.Items.Insert(0, it)

    End Sub

#Region "Filtro de Lojas"

    Protected Sub btnVisLojas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisLojas.Click
        carregaLojas()
    End Sub

    Private Sub carregaClientes()

        lstClientes.Items.Clear()
        lstLojas.Items.Clear()

        Dim clsCli As clsCliente
        clsCli = New clsCliente
        lstClientes.DataSource = clsCli.Listar(DataClass.enReturnType.DataReader)
        lstClientes.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstClientes.Items.Insert(0, it)
        clsCli = Nothing

    End Sub

    Private Sub carregaLojas()

        Dim p_Clientes As String = getComboValues(lstClientes)

        Dim clsLoj As clsLoja
        clsLoj = New clsLoja
        lstLojas.DataSource = clsLoj.Listar(p_Clientes, DataClass.enReturnType.DataReader)
        lstLojas.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstLojas.Items.Insert(0, it)
        clsLoj = Nothing

    End Sub

    Private Sub carregaShopping()

        Dim clsShop As clsShopping
        clsShop = New clsShopping
        lstShopping.DataSource = clsShop.Listar(DataClass.enReturnType.DataReader)
        lstShopping.DataBind()
        lstShopping.Items.Insert(0, New ListItem("Loja de Rua", "-1"))
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstShopping.Items.Insert(0, it)
        clsShop = Nothing

    End Sub

#End Region

#Region "Filtro de Promotores"


    Private Sub carregaCoordenadores()

        Dim clsCrd As clsCoordenador
        clsCrd = New clsCoordenador
        lstCoordenador.DataSource = clsCrd.Listar(DataClass.enReturnType.DataReader)
        lstCoordenador.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstCoordenador.Items.Insert(0, it)
        clsCrd = Nothing

        lstLider.Items.Clear()
        lstPromotor.Items.Clear()

    End Sub

    Private Sub carregaLideres()

        Dim p_Coordenadores As String = getComboValues(lstCoordenador)

        Dim clsLid As clsLider
        clsLid = New clsLider
        lstLider.DataSource = clsLid.Listar(p_Coordenadores, DataClass.enReturnType.DataReader)
        lstLider.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstLider.Items.Insert(0, it)
        clsLid = Nothing

        lstPromotor.Items.Clear()

    End Sub

    Private Sub carregaPromotores()

        Dim p_Lideres As String = getComboValues(lstLider)

        Dim clsPro As clsPromotor
        clsPro = New clsPromotor
        lstPromotor.DataSource = clsPro.Listar(p_Lideres, DataClass.enReturnType.DataReader)
        lstPromotor.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstPromotor.Items.Insert(0, it)
        clsPro = Nothing

    End Sub

    Protected Sub btnLideres_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLideres.Click
        carregaLideres()
    End Sub

    Protected Sub btnPromotores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPromotores.Click
        carregaPromotores()
    End Sub


#End Region

#Region "Filtro de Produtos"

    Protected Sub btnVisSubCat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisSubCat.Click
        carregaSubCategorias()
    End Sub

    Protected Sub btnVisProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisProd.Click
        carregaProdutos()
    End Sub


    Private Sub carregaCategorias()

        lstCategoria.Items.Clear()
        lstSubCategoria.Items.Clear()
        lstProduto.Items.Clear()

        Dim clsCat As clsCategoria
        clsCat = New clsCategoria
        lstCategoria.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
        lstCategoria.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstCategoria.Items.Insert(0, it)
        clsCat = Nothing

    End Sub

    Private Sub carregaSubCategorias()

        lstSubCategoria.Items.Clear()
        lstProduto.Items.Clear()

        Dim p_Categorias As String = getComboValues(lstCategoria)

        Dim clsSubCat As clsSubCategoria
        clsSubCat = New clsSubCategoria
        lstSubCategoria.DataSource = clsSubCat.Listar(p_Categorias, DataClass.enReturnType.DataReader)
        lstSubCategoria.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstSubCategoria.Items.Insert(0, it)
        clsSubCat = Nothing

    End Sub

    Private Sub carregaProdutos()

        Dim p_SubCategorias As String = getComboValues(lstSubCategoria)

        Dim clsProd As clsProduto
        clsProd = New clsProduto
        lstProduto.DataSource = clsProd.Listar(p_SubCategorias, DataClass.enReturnType.DataReader)
        lstProduto.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstProduto.Items.Insert(0, it)
        clsProd = Nothing

    End Sub

#End Region

#Region "Filtro adicionais"

    Private Sub carregaTipoLojas()

        Dim clsTipo As clsTipoLoja, strScript As String = "", i As Integer = 0

        ltScriptTipoLoja.Text = ""
        clsTipo = New clsTipoLoja

        Dim dr As SqlDataReader = clsTipo.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_TipoLoja() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkTipoLoja_" & i & ".checked==true) m_Value+='" & dr("IdTipoLoja") & ",';" & vbCrLf
            chkTipoLoja.Items.Add(New ListItem(dr("TipoLoja"), dr("IdTipoLoja")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "if (m_Value != '') m_Value = Left(m_Value, m_Value.length -1 );" & vbCrLf
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptTipoLoja.Text = strScript

        End If

        clsTipo = Nothing

    End Sub

    Private Sub carregaRegioes()

        Dim clsReg As clsRegiao, strScript As String = "", i As Integer = 0

        ltScriptRegiao.Text = ""
        clsReg = New clsRegiao

        Dim dr As SqlDataReader = clsReg.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_Regiao() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkRegiao_" & i & ".checked==true) m_Value+='" & dr("IdRegiao") & ",';" & vbCrLf
            chkRegiao.Items.Add(New ListItem(dr("Regiao"), dr("IdRegiao")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "if (m_Value != '') m_Value = Left(m_Value, m_Value.length -1 );" & vbCrLf
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptRegiao.Text = strScript

        End If

        clsReg = Nothing

    End Sub

#End Region


    Protected Sub btnBuildReport_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuildReport.Click

        Dim strPeriodoMinimoDatas As String = SettingsExpression.GetProperty("qtdemaximadias", "ExportarDados.Exportacao", "6")

        If txtDataInicial.Text = "" Or txtDataFinal.Text = "" Then

            ltDescricao.Text = "Informe corretamente o período de datas"

        ElseIf IsDate(txtDataInicial.Text) = False Or IsDate(txtDataFinal.Text) = False Then

            ltDescricao.Text = "Informe corretamente o período de datas"

        ElseIf CDate(txtDataInicial.Text) > CDate(txtDataFinal.Text) Then

            ltDescricao.Text = "A data inicial deve ser igual ou menor que a data final"

        ElseIf (strPeriodoMinimoDatas > 0 And DateDiff(DateInterval.Day, CDate(txtDataInicial.Text), CDate(txtDataFinal.Text)) > strPeriodoMinimoDatas) Then

            ltDescricao.Text = "A diferença entre as datas deve ser no máximo de 6 dias"

        Else

            ltDescricao.Text = ""
            Dim caminhoRelatorio As String = AppSettings("CaminhoRelatorios") & ""
            Dim strURL As String = MontaUrl() & "&sg=" & Request("sg") & "&="
            Dim clsRep As New clsReports
            Dim guid As String = clsRep.saveURLReport("Exportação de Visitas", strURL, Me.User.IDUser, caminhoRelatorio, "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss"), AppSettings("Key"))

            Me.User.Log("Exportação de Dados", "Id do Relatório = " & guid)

            Dim strScript As String = "<script language='javascript'>openReport('" & guid & "', 'ExportacaoDados');</script>"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), ":)@@@@MyPopUpScript", strScript, False)

        End If

    End Sub

    Protected Sub rdTabela_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTabela.SelectedIndexChanged
        CriaCampos(rdTabela.SelectedItem.Value)
    End Sub


End Class
