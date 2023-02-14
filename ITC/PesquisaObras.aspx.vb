Imports System.Data
Imports ITC

Public Class PesquisaObras

    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    Protected WithEvents Checkbox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dtlFases As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlSegmentos As System.Web.UI.WebControls.DataList
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents btnTeste As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents UpdatePanel1 As System.Web.UI.UpdatePanel
    Protected WithEvents btnGravarLink As Button
    Protected WithEvents hidLink As HtmlInputHidden
    Protected WithEvents hidAuth As HtmlInputHidden
    Protected WithEvents ltScript As Literal

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtlPesquisaTipos As System.Web.UI.WebControls.DataList

    Protected WithEvents dtlEstadosNo As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosNr As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosSl As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosSd As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosCo As System.Web.UI.WebControls.DataList

    Protected WithEvents Selecao As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Topo As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tdPesquisador As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdcboPesquisador As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents Resultados As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dtgResultados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSalvarPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents btnNovaPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents btnNovaPesquisa2 As System.Web.UI.WebControls.Button
    Protected WithEvents cboPesquisasSalvas As ComboBox
    Protected WithEvents cboPesquisador As ComboBox
    Protected WithEvents cboMostrar As ComboBox
    Protected WithEvents cboStatusSIG As ComboBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.Button
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnExportar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagemTopo As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagemTopo2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents btnExcluirPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents dtlEstagios As System.Web.UI.WebControls.DataList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents cboCidade As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdEstado As DropDownList
    Protected WithEvents txtCepDe As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCepAte As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TipoRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rdFormaEnvioLinkOut As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents rdFormaEnvioLinkLot As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents cboOrdenar As ComboBox
    Protected WithEvents cboFatorAreaConstruida As ComboBox
    Protected WithEvents cboFatorValor As ComboBox
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1234 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents txtInicioObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTerminoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAreaConstruida As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdMolidade As ComboBox
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodigoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescricaoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumeroRevisao As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents txtEmpresaParticipante As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents BarraNavegacao1 As BarraNavegacao
    Protected WithEvents Barranavegacao2 As BarraNavegacao
    Protected WithEvents tblSalvar As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnSalvarAgora As System.Web.UI.WebControls.Button
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboChecagemNrRevisao As ComboBox
    Protected WithEvents hidCidade As HtmlInputHidden

    Protected WithEvents hddOrdem As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdFases As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdEstagios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdTipos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdEstados As System.Web.UI.HtmlControls.HtmlInputHidden

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Pesq As clsPesquisas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then


            Dim Est As New clsEstados
            With cboIdEstado
                .CssClass = "f8"
                .DataSource = Est.ListEstados(0)
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
                .Items.Insert(0, "Selecione...")
                .SelectedIndex = 0

            End With

            'cboCidade.AddItem(0, "")
            'cboCidade.Enabled = False
            'cboCidade.EnableValidation = False
            'cboIdEstado.EnableValidation = False

            Pesq = New clsPesquisas
            ViewState("IdPesquisa") = CInt(0 & Page.Request("IdPesquisa"))




            '--------------------------------------------------------------
            'INFORMAÇÕES SOBRE A PESQUISA
            '--------------------------------------------------------------

            With cboPesquisasSalvas
                .CssClass = "f8"
                .EnableValidation = False
                .AutoPostBack = True
                .DataSource = Pesq.List(Usuario.IDUsuario)
                .DataTextField = "NOMEPESQUISA"
                .DataValueField = "IDUSUARIOPESQUISA"
                .DataBind()
                .Value = ViewState("IdPesquisa")
                If .Count = 0 Then
                    .AddItem(0, "NÃO EXISTEM PESQUISAS SALVAS")
                End If
            End With

            With cboOrdenar
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(2, "NOME DA OBRA")
                .AddItem(1, "CÓDIGO DO ITC")
                .AddItem(3, "ENDEREÇO")
                .AddItem(4, "NOME FANTASIA DA EMPRESA")
                .AddItem(5, "CIDADE")
            End With

            With cboChecagemNrRevisao
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(1, "MAIOR QUE")
                .AddItem(2, "MENOR QUE")
            End With

            With cboFatorAreaConstruida
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(1, "MAIOR QUE")
                .AddItem(2, "MENOR QUE")
            End With

            With cboFatorValor
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(1, "MAIOR QUE")
                .AddItem(2, "MENOR QUE")
            End With

            Dim Pq As New clsPesquisadores
            With cboPesquisador
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f"
                .DataSource = Pq.List(0)
                .DataTextField = "SIGLAPESQUISADOR"
                .DataValueField = "IDPESQUISADOR"
                .DataBind()
            End With
            Pq = Nothing


            Dim Foll As New FollowUp
            With cboStatusSIG
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(0, "Selecione...")
                .DataSource = Foll.ListStatusSIG()
                .DataTextField = "DescricaoStatusSIG"
                .DataValueField = "IdStatusSIG"
                .DataBind()
            End With


            'VERIFICA SE USUÁRIO É INTERNO E REMOVE CAMPO "PESQUISADOR" DA SEARCH
            tdPesquisador.Visible = (Me.Usuario.IdEmpresa = -1)
            tdcboPesquisador.Visible = (Me.Usuario.IdEmpresa = -1)

            Dim Moda As New clsModalidades
            With cboIdMolidade
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Moda.ListModalidades
                .DataTextField = "DescricaoModalidade"
                .DataValueField = "IdModalidade"
                .DataBind()
            End With
            Moda = Nothing

            With cboMostrar
                .AddItem(0, "TODOS OS REGISTROS")
                .AddItem(10, "10 REGISTROS")
                .AddItem(25, "25 REGISTROS")
                .AddItem(50, "50 REGISTROS")
                .AddItem(100, "100 REGISTROS")
                .Value = 0
            End With

            'lblMensagemTopo.Text = "Selecione todos os itens desejados em sua pesquisa e clique no botão PESQUISAR."

            Resultados.Visible = False
            tblSalvar.Visible = False

            BindGrids()
            Inflate()
            Pesq = Nothing

        End If

        If ViewState("IdPesquisa") > 0 Then
            btnExcluirPesquisa.Enabled = True
        Else
            btnExcluirPesquisa.Enabled = False
        End If


        'If cboCidade.Value <> 0 Then
        '    cboCidade.Disabled = False
        'End If

        btnPesquisar.Attributes.Add("onClick", "setCheckedItens();")
        btnSalvarPesquisa.Attributes.Add("onClick", "setCheckedItens();")
        btnGravarLink.Attributes.Add("onClick", "if(XM_ITC_GetLink()==false){return false};")

        hidAuth.Value = Me.Usuario.AuthGuid




    End Sub

    Private Sub Inflate()
        Dim ds As DataSet = Pesq.DadosPesquisa(ViewState("IdPesquisa"), Usuario.IDUsuario, clsPesquisas.TipoPesquisa.PesquisaObra)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim db_Null As DBNull
            With ds.Tables(0).Rows(0)
                txtAreaConstruida.Text = .Item("AREACONSTRUIDA")
                txtBairro.Text = .Item("BAIRRO")
                txtCepDe.Text = .Item("CEPINICIAL")
                txtCepAte.Text = .Item("CEPFINAL")
                XMSetListItemValue(cboIdEstado, .Item("IDESTADO"))
                CarregaCidades(XMGetListItemText(cboIdEstado))
                XMSetListItemValue(cboCidade, .Item("CIDADE"))
                txtCodigoObra.Text = .Item("CODIGOITC")
                txtDescricaoObra.Text = .Item("DESCRICAO")
                txtEmpresaParticipante.Text = .Item("EMPRESAPARTIC")
                txtEndereco.Text = .Item("ENDERECO")
                If .Item("INICIOOBRA").ToString() = "" Then
                    txtInicioObra.Text = ""
                Else
                    txtInicioObra.Text = .Item("INICIOOBRA")
                End If
                If .Item("TERMINOOBRA").ToString() = "" Then
                    txtTerminoObra.Text = ""
                Else
                    txtTerminoObra.Text = .Item("TERMINOOBRA")
                End If
                txtNomeObra.Text = .Item("NOMEOBRA")
                txtNumeroRevisao.Text = .Item("NRDAREVISAO")
                txtValor.Text = .Item("VALOR")
                cboFatorAreaConstruida.Value = .Item("CHECAGEMAREA")
                cboFatorValor.Value = .Item("CHECAGEMVALOR")
                cboIdMolidade.Value = .Item("IDMODALIDADE")
                cboPesquisador.Value = .Item("IDPESQUISADOR")
                cboChecagemNrRevisao.Value = .Item("CHECAGEMNRREVISAO")
                ViewState("NomePesquisa") = .Item("NomePesquisa")


            End With
        Else
            txtAreaConstruida.Text = ""
            txtBairro.Text = ""
            txtCepDe.Text = ""
            txtCepAte.Text = ""
            XMSetListItemValue(cboCidade, 0)
            txtCodigoObra.Text = ""
            txtDataInicio.Text = ""
            txtDataFim.Text = ""
            txtDescricaoObra.Text = ""
            txtEmpresaParticipante.Text = ""
            txtEndereco.Text = ""
            txtInicioObra.Text = ""
            txtTerminoObra.Text = ""
            txtNomeObra.Text = ""
            txtNumeroRevisao.Text = ""
            txtValor.Text = ""
            cboFatorAreaConstruida.Value = 0
            cboFatorValor.Value = 0
            cboIdMolidade.Value = 0
            cboPesquisador.Value = 0
            ViewState("NomePesquisa") = ""
            cboChecagemNrRevisao.Value = 0
            XMSetListItemValue(cboIdEstado, 0)
        End If
    End Sub

    Private Sub BindGrids()

        Dim dsNO As DataSet = Pesq.ListEstadosObrasNO(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        Dim i As Integer
        For i = 0 To dsNO.Tables(0).Rows.Count - 1
            If dsNO.Tables(0).Rows(i).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next

        Dim dsNR As DataSet = Pesq.ListEstadosObrasNR(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        Dim iA As Integer
        For iA = 0 To dsNR.Tables(0).Rows.Count - 1
            If dsNR.Tables(0).Rows(iA).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next

        Dim dsSL As DataSet = Pesq.ListEstadosObrasSL(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        Dim iB As Integer
        For iB = 0 To dsSL.Tables(0).Rows.Count - 1
            If dsSL.Tables(0).Rows(iB).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next

        Dim dsCO As DataSet = Pesq.ListEstadosObrasCO(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        Dim iE As Integer
        For iE = 0 To dsCO.Tables(0).Rows.Count - 1
            If dsCO.Tables(0).Rows(iE).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next

        Dim dsSD As DataSet = Pesq.ListEstadosObrasSD(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        Dim iC As Integer
        For iC = 0 To dsSD.Tables(0).Rows.Count - 1
            If dsSD.Tables(0).Rows(iC).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next
        'dtgPesquisaRegioes.DataBind()

        dtlSegmentos.DataSource = Pesq.ListSegmentos(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlSegmentos.DataBind()

        dtlFases.DataSource = Pesq.ListFases(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlFases.DataBind()

        'NORTE
        dtlEstadosNo.DataSource = Pesq.ListEstadosObrasNO(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosNo.DataBind()

        'NORDESTE
        dtlEstadosNr.DataSource = Pesq.ListEstadosObrasNR(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosNr.DataBind()

        'SUL
        dtlEstadosSl.DataSource = Pesq.ListEstadosObrasSL(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosSl.DataBind()

        'SUDESTE
        dtlEstadosSd.DataSource = Pesq.ListEstadosObrasSD(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosSd.DataBind()

        'CENTRO-OESTE
        dtlEstadosCo.DataSource = Pesq.ListEstadosObrasCO(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosCo.DataBind()

    End Sub

    Public Function ListaTipos(ByVal p_IdSegmento As Integer)

        Dim ds As DataSet = Pesq.ListTipos(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa, p_IdSegmento)
        Return ds

    End Function

    Public Function ListaEstagios(ByVal p_IdFase As Integer) As DataSet

        Dim Est As New clsEstagios
        Dim ds As DataSet = Est.ListTabela(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa, p_IdFase)
        Est = Nothing

        Return ds

    End Function

    Private Function Pesquisar()

        ViewState("Ordenacao") = cboOrdenar.Value
        hddOrdem.Value = ViewState("Ordenacao")
        hidCidade.Value = Request("cboCidade")

        Dim strMensagem As String = ""
        If Usuario.IdEmpresa > 0 Then
            If Not IsDate(txtDataInicio.Text) Then
                txtDataInicio.Text = ""
            Else
                If txtDataInicio.Text < CDate(Day(Usuario.DataInicioPlano) & "/" & Month(Usuario.DataInicioPlano) & "/" & Year(Usuario.DataInicioPlano)) Then
                    txtDataInicio.Text = Usuario.DataInicioPlano.ToString("dd/MM/yyyy")
                    strMensagem = "A data inicial não pode ser inferior a " & Usuario.DataInicioPlano.ToString("dd/MM/yyyy")
                    Exit Function
                End If
            End If
        End If
        If strMensagem.Trim <> "" Then
            lblMensagemTopo.ForeColor = System.Drawing.Color.Red
            lblMensagemTopo.Font.Bold = True
            lblMensagemTopo.Text = strMensagem
            Exit Function
        End If
        If Not IsDate(txtDataFim.Text) Then
            txtDataFim.Text = ""
        End If
        ChecarItens()
        Pesq = New clsPesquisas
        Selecao.Visible = False
        Resultados.Visible = True

        'Checagem de botão "exportar" - definida por usuário
        btnExportar.Visible = False
        If CheckPermission("Exportar Pesquisa Obras", "VISUALIZAR") Then
            btnExportar.Attributes.Add("onClick", "javascript:XM_ITC_Exportar();")
            btnExportar.Visible = True
        End If

        BindGrid()

    End Function

    Public Function getPostBack() As String

        Return Page.GetPostBackEventReference(btnTeste, "")

    End Function

    Private Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        Pesquisar()

    End Sub

    Private Sub BindGrid()

        Dim ds As DataSet
        Dim iCount As Integer = 0

        Try

            ds = Pesq.Pesquisar(ViewState("Tipos"), ViewState("Regioes"), ViewState("Estados"), ViewState("Fases"), txtDataInicio.Text, txtDataFim.Text, Usuario.IDUsuario, txtNomeObra.Text, cboOrdenar.Value, Usuario.IdEmpresa, txtCodigoObra.Text, txtEndereco.Text, txtBairro.Text, cboCidade.SelectedItem.Value, txtDescricaoObra.Text, txtCepDe.Text, txtCepAte.Text, txtNumeroRevisao.Text, txtInicioObra.Text, txtTerminoObra.Text, cboPesquisador.Value, txtAreaConstruida.Text, cboFatorAreaConstruida.Value, txtValor.Text, cboFatorValor.Value, txtEmpresaParticipante.Text, cboIdMolidade.Value, ViewState("Estagios"), cboIdEstado.SelectedValue, cboChecagemNrRevisao.Value, ViewState("GSP"), cboMostrar.Value, cboStatusSIG.Value)

            iCount = ds.Tables(0).Rows.Count
            dtgResultados.DataSource = ds
            dtgResultados.DataBind()
            With dtgResultados
                If iCount > 0 Then
                    Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de " & .PageCount
                    strTexto &= " - " & iCount & " registro" & IIf(iCount = 0, "", "s") & " retornado" & IIf(iCount = 0, "", "s")
                    BarraNavegacao1.SetDescription(strTexto)
                Else
                    BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
                End If
            End With

            If ds.Tables(0).Rows.Count > 0 Then
                lblMensagemTopo.Text = "FORAM LOCALIZADAS " & ds.Tables(0).Rows.Count & " OBRAS"
            Else
                lblMensagemTopo.Text = "A PESQUISA NÃO LOCALIZOU NENHUMA OBRA COM OS CRITÉRIOS SELECIONADOS"
            End If
            lblMensagemTopo2.Visible = False

        Catch ex As Exception

            lblMensagemTopo.Text = "ERRO AO BUSCAR DADOS - (" & ex.Message & ")"

        End Try


    End Sub

    Private Sub ChecarItens()

        'ViewState("Estados") = fncGetCheckedItems(dtlEstadosNo, "chkEstadosNO")
        'ViewState("Estados") += fncGetCheckedItems(dtlEstadosNr, "chkEstadosNR")
        'ViewState("Estados") += fncGetCheckedItems(dtlEstadosSl, "chkEstadosSL")
        'ViewState("Estados") += fncGetCheckedItems(dtlEstadosSd, "chkEstadosSD")
        'ViewState("Estados") += fncGetCheckedItems(dtlEstadosCo, "chkEstadosCO")

        ViewState("Estagios") = hdEstagios.Value
        ViewState("Fases") = hdFases.Value
        ViewState("Estados") = hdEstados.Value

        ViewState("Tipos") = hdTipos.Value 'fncGetCheckedItems(dtlPesquisaTipos, "chkTipos")
        ViewState("Regioes") = ""

    End Sub

    Private Function fncGetCheckedItems(ByRef p_Obj As Object, ByVal p_CheckBoxName As String) As String

        Dim p_Return As String = "", i As Integer
        For i = 0 To p_Obj.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = p_Obj.Items(i).FindControl(p_CheckBoxName)
            If CurrentCheckBox.Checked Then
                If p_Return.Trim <> "" Then
                    p_Return += ","
                End If
                p_Return += p_Obj.DataKeys.Item(p_Obj.Items(i).ItemIndex).ToString()
            End If
        Next

        Return p_Return

    End Function

    Private Sub btnSalvarPesquisa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvarPesquisa.Click
        ChecarItens()
        If ViewState("IdPesquisa") > 0 Then
            Pesq = New clsPesquisas
            Dim strPagina As String = "PesquisaObras.aspx?IdPesquisa=" & Pesq.SalvarPesquisa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Tipos"), ViewState("Regioes"), ViewState("Estados"), ViewState("Fases"), ViewState("Estagios"), ViewState("NomePesquisa"), txtCodigoObra.Text, txtEndereco.Text, txtBairro.Text, cboCidade.SelectedItem.Value, txtDescricaoObra.Text, txtCepDe.Text, txtCepAte.Text, txtNumeroRevisao.Text, txtInicioObra.Text, txtTerminoObra.Text, cboPesquisador.Value, txtAreaConstruida.Text, cboFatorAreaConstruida.Value, txtValor.Text, cboFatorValor.Value, txtEmpresaParticipante.Text, cboIdMolidade.Value, txtNomeObra.Text, cboChecagemNrRevisao.Value, cboIdEstado.SelectedItem.Text)
            Response.Redirect(strPagina)
        Else
            Resultados.Visible = False
            Selecao.Visible = False
            Topo.Visible = True
            ViewState("IdCidadeTemp") = Request("cboCidade")
            tblSalvar.Visible = True
        End If
    End Sub

    Private Sub btnNovaPesquisa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaPesquisa.Click
        Page.Response.Redirect("PesquisaObras.aspx")
    End Sub
    Private Sub btnNovaPesquisa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaPesquisa2.Click
        Page.Response.Redirect("PesquisaObras.aspx")
    End Sub

    Private Sub cboPesquisasSalvas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPesquisasSalvas.SelectedIndexChanged
        ViewState("IdPesquisa") = cboPesquisasSalvas.Value

        'ViewState("IdPesquisa") = cboPesquisasSalvas.Value
        Response.Redirect("pesquisaobras.aspx?idpesquisa=" & ViewState("IdPesquisa"))

        'ViewState("NomePesquisa") = cboPesquisasSalvas.Text
        'Pesq = New clsPesquisas
        'BindGrids()
        'Inflate()
        'Pesq = Nothing
        'If ViewState("IdPesquisa") > 0 Then
        '    btnExcluirPesquisa.Enabled = True
        'Else
        '    btnExcluirPesquisa.Enabled = False
        'End If
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgResultados.CurrentPageIndex = e.NewPageIndex
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    'Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImprimir.Click

    '    Dim strResultados As String = "", i As Integer = 0

    '    For i = 0 To dtgResultados.Items.Count - 1
    '        Dim CurrentCheckBox As CheckBox = dtgResultados.Items(i).FindControl("chkItemResultado")
    '        If CurrentCheckBox.Checked Then
    '            If strResultados.Trim <> "" Then
    '                strResultados += ","
    '            End If
    '            strResultados += dtgResultados.DataKeys.Item(dtgResultados.Items(i).ItemIndex).ToString()
    '        End If
    '    Next

    '    Dim strJavaScript As String = ""
    '    strJavaScript += "<SCRIPT LANGUAGE='JAVASCRIPT'>window.open('RelatorioObras.aspx?T=" & TipoRelatorio.SelectedItem.Value & "&O=" & strResultados & "', 'RelatorioObras', 'fullscreen=no,toolbar=yes,status=no,menubar=no,scrollbars=yes,resizable=yes,directories=no,location=no,width=800,height=600,left=0,top=0');</SCRIPT>"
    '    Response.Write(strJavaScript)

    'End Sub

    'Private Sub btnImprimirResumo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImprimirResumo.Click

    '    Dim strResultados As String = "", i As Integer = 0

    '    For i = 0 To dtgResultados.Items.Count - 1
    '        Dim CurrentCheckBox As CheckBox = dtgResultados.Items(i).FindControl("chkItemResultado")
    '        If CurrentCheckBox.Checked Then
    '            If strResultados.Trim <> "" Then
    '                strResultados += ","
    '            End If
    '            strResultados += dtgResultados.DataKeys.Item(dtgResultados.Items(i).ItemIndex).ToString()
    '        End If
    '    Next

    '    Dim strJavaScript As String = ""
    '    strJavaScript += "<SCRIPT LANGUAGE='JAVASCRIPT'>window.open('RelatorioObrasResumo.aspx?O=" & strResultados & "', 'RelatorioObras', 'fullscreen=no,toolbar=yes,status=no,menubar=no,scrollbars=yes,resizable=yes,directories=no,location=no,width=800,height=600,left=0,top=0');</SCRIPT>"
    '    Response.Write(strJavaScript)

    'End Sub

    Private Sub btnExcluirPesquisa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcluirPesquisa.Click
        Pesq = New clsPesquisas
        Pesq.ExcluirPesquisaObras(ViewState("IdPesquisa"), Usuario.IDUsuario)
        Pesq = Nothing
        Page.Response.Redirect("PesquisaObras.aspx")
    End Sub

    'Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click

    '    Dim strResultados As String = "", i As Integer = 0

    '    For i = 0 To dtgResultados.Items.Count - 1
    '        Dim CurrentCheckBox As CheckBox = dtgResultados.Items(i).FindControl("chkItemResultado")
    '        If CurrentCheckBox.Checked Then
    '            If strResultados.Trim <> "" Then
    '                strResultados += ","
    '            End If
    '            strResultados += dtgResultados.DataKeys.Item(dtgResultados.Items(i).ItemIndex).ToString()
    '        End If
    '    Next
    '    If strResultados.Length > 0 Then
    '        Response.Redirect("RelatorioObraExportar.aspx?O=" & strResultados)
    '    End If

    'End Sub

    Private Sub BarraNavegacao2_NextReg() Handles Barranavegacao2.NextReg
        If (dtgResultados.CurrentPageIndex < (dtgResultados.PageCount - 1)) Then
            dtgResultados.CurrentPageIndex += 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao2_LastReg() Handles Barranavegacao2.LastReg
        dtgResultados.CurrentPageIndex = (dtgResultados.PageCount - 1)
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao2_FirstReg() Handles Barranavegacao2.FirstReg
        dtgResultados.CurrentPageIndex = 0
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao1.NextReg
        If (dtgResultados.CurrentPageIndex < (dtgResultados.PageCount - 1)) Then
            dtgResultados.CurrentPageIndex += 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao1.LastReg
        dtgResultados.CurrentPageIndex = (dtgResultados.PageCount - 1)
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao1.FirstReg
        dtgResultados.CurrentPageIndex = 0
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao1.PreviousReg
        If (dtgResultados.CurrentPageIndex > 0) Then
            dtgResultados.CurrentPageIndex -= 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

    Private Sub btnSalvarAgora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvarAgora.Click

        Dim p_IdCidadeTemp As String = ViewState("IdCidadeTemp")
        ViewState("IdCidadeTemp") = Nothing

        ChecarItens()
        Pesq = New clsPesquisas
        Page.Response.Redirect("PesquisaObras.aspx?IdPesquisa=" & Pesq.SalvarPesquisa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Tipos"), ViewState("Regioes"), ViewState("Estados"), ViewState("Fases"), ViewState("Estagios"), txtNome.Text, txtCodigoObra.Text, txtEndereco.Text, txtBairro.Text, p_IdCidadeTemp, txtDescricaoObra.Text, txtCepDe.Text, txtCepAte.Text, txtNumeroRevisao.Text, txtInicioObra.Text, txtTerminoObra.Text, cboPesquisador.Value, txtAreaConstruida.Text, cboFatorAreaConstruida.Value, txtValor.Text, cboFatorValor.Value, txtEmpresaParticipante.Text, cboIdMolidade.Value, txtNomeObra.Text, cboChecagemNrRevisao.Value, cboIdEstado.SelectedItem.Text))
        Pesq = Nothing
    End Sub

    Private Sub CarregaCidades(ByVal Estado As String)

        If Estado = "Selecione..." Then
            XMSetListItemValue(cboCidade, 0)
            Exit Sub
        End If

        cboCidade.Items.Clear()

        Dim Cid As New clsCidades
        With cboCidade
            .CssClass = "f8"
            .DataSource = Cid.ListCidades(Estado)
            .DataTextField = "CIDADE"
            .DataValueField = "IDCIDADE"
            .DataBind()
            Cid = Nothing
        End With

    End Sub

    Private Sub VerificaCidade()



    End Sub

    Private Sub dtgResultados_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResultados.ItemDataBound

        With e.Item
            Dim rv As DataRow
            If .ItemType = ListItemType.AlternatingItem OrElse .ItemType = ListItemType.Item OrElse .ItemType = ListItemType.EditItem Then
                rv = CType(.DataItem, DataRowView).Row
                ' Change color
                If Not IsDBNull(rv("IdSegmento")) Then
                    Select Case rv("IdSegmento")
                        Case 1
                            .CssClass = "Industrial"
                        Case 2
                            .CssClass = "Comercial"
                        Case 3
                            .CssClass = "Residencial"
                    End Select
                End If
            End If
        End With

    End Sub

    Private Sub btnGravarLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravarLink.Click

        If Pesq Is Nothing Then Pesq = New clsPesquisas

        Dim xml As New XMLConfig
        Dim p_Guid As String = Pesq.setReportGuid(Me.Usuario.IdEmpresa, hidLink.Value).ToString()
        Dim p_Host As String = xml.GetValue("EnderecoLinkRelatorio", False)
        Dim strBody As String = Server.UrlEncode(p_Host & "relatorioobras.aspx?gd=" & Server.UrlEncode(p_Guid))

        Dim strScript As String = "<scr" & "ipt lang" & "uage='java" & "script'>" & vbCrLf
        If rdFormaEnvioLinkOut.Checked Then
            strScript &= "document.location.href = 'mail" & "to:?subject=ITC.Net - Relatorio de Obras&body=" & strBody & "%0D%0ASe este link estiver inativo para Click, copie e cole no seu navegador." & "';" & vbCrLf
        Else
            strScript &= "document.location.href = 'mail" & "to:?subject=ITC.Net - Relatorio de Obras?body=" & strBody & "%0D%0ASe este link estiver inativo para Click, copie e cole no seu navegador." & "';" & vbCrLf
        End If

        'strScript &= "window.history.go(-1);" & vbCrLf
        strScript &= "</scr" & "ipt>" & vbCrLf

        ltScript.Text = strScript

        Pesq = Nothing
        xml = Nothing

    End Sub


    Public Sub cboIdEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdEstado.SelectedIndexChanged
        CarregaCidades(cboIdEstado.SelectedItem.Text)

    End Sub

    Private Sub btnTeste_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTeste.ServerClick

        Pesquisar()

    End Sub
End Class
