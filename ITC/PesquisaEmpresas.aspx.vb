Public Class PesquisaEmpresas

    Inherits XMWebPage

    Protected WithEvents lblMensagemTopo As System.Web.UI.WebControls.Label

    Protected WithEvents btnGravarLink As Button
    Protected WithEvents hidLink As HtmlInputHidden
    Protected WithEvents hidAuth As HtmlInputHidden
    Protected WithEvents ltScript As Literal

    Protected WithEvents dtgProdutos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgPesquisa As System.Web.UI.WebControls.DataGrid

    Protected WithEvents dtlAtividades As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosNo As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosNr As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosSl As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosSd As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstadosCo As System.Web.UI.WebControls.DataList

    Protected WithEvents tblResultados As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblSalvar As System.Web.UI.HtmlControls.HtmlTable

    Protected WithEvents Selecao As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Topo As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents PesquisaEmpresas As System.Web.UI.HtmlControls.HtmlGenericControl

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm

    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.Button
    Protected WithEvents btnSalvarPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents btnNovaPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents btnNovaPesquisa2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnExcluirPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnSalvarAgora As System.Web.UI.WebControls.Button
    Protected WithEvents btnTeste As System.Web.UI.HtmlControls.HtmlInputButton

    Protected WithEvents rdFormaEnvioLinkOut As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents rdFormaEnvioLinkLot As System.Web.UI.HtmlControls.HtmlInputRadioButton

    Protected WithEvents cboPesquisasSalvas As ComboBox
    Protected WithEvents cboOrdenar As ComboBox
    Protected WithEvents cboIdEstado As ComboBox
    Protected WithEvents cboCidade As ComboBox
    Protected WithEvents cboStatusSIG As ComboBox

    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCepDe As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCepAte As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox

    Protected WithEvents hddOrdem As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents BarraNavegacao1 As BarraNavegacao
    Protected WithEvents Barranavegacao2 As BarraNavegacao
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox

    Protected WithEvents hdAtividades As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdEstados As System.Web.UI.HtmlControls.HtmlInputHidden

    Private Pesq As clsPesquisas

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            tblResultados.Visible = True
            tblSalvar.Visible = False
            Topo.Visible = True

            ViewState("IdPesquisa") = CInt(0 & Page.Request("IdPesquisa"))
            Pesq = New clsPesquisas

            Dim Est As New clsEstados
            With cboIdEstado
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With

            cboCidade.AddItem(0, "")

            cboCidade.Enabled = False
            cboCidade.EnableValidation = False
            cboIdEstado.EnableValidation = False

            Inflate()

            With cboPesquisasSalvas

                .EnableValidation = False
                .AutoPostBack = True
                .DataSource = Pesq.ListEmpresas(Usuario.IDUsuario)
                .DataTextField = "NOMEPESQUISA"
                .DataValueField = "IDUSUARIOPESQUISA"
                .DataBind()
                .Value = ViewState("IdPesquisa")
                .CssClass = "f8"

                If .Count = 0 Then
                    .AddItem(0, "Selecione...")
                End If

            End With

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

            BindGrids()

            tblResultados.Visible = False

            With cboOrdenar
                .CssClass = "f8"
                .AddItem(1, "RAZÃO SOCIAL DA EMPRESA")
                .AddItem(2, "NOME FANTASIA DA EMPRESA")
                .AddItem(3, "ENDEREÇO")
                .AddItem(4, "ESTADO")
            End With

            lblMensagemTopo.Text = "<b>Selecione todos os itens desejados em sua pesquisa e clique no botão PESQUISAR.</b> <BR>Caso não selecione nenhum critério, retornarão as empresas disponíveis."

        End If

        If ViewState("IdPesquisa") > 0 Then
            btnExcluirPesquisa.Enabled = True
        Else
            btnExcluirPesquisa.Enabled = False
        End If

        hidAuth.Value = Me.Usuario.AuthGuid

        btnPesquisar.Attributes.Add("onClick", "setCheckedItens();")
        btnSalvarPesquisa.Attributes.Add("onClick", "setCheckedItens();")
        btnGravarLink.Attributes.Add("onClick", "if(XM_ITC_GetLink()==false){return false};")

        

    End Sub

    Private Sub Inflate()

        Dim ds As DataSet = Pesq.DadosPesquisa(ViewState("IdPesquisa"), Usuario.IDUsuario, clsPesquisas.TipoPesquisa.PesquisaEmpresa)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                txtCepDe.Text = .Item("CEPINICIAL")
                txtCepAte.Text = .Item("CEPFINAL")
                txtBairro.Text = .Item("BAIRRO")
                cboIdEstado.Value = .Item("IDESTADO")

                If cboIdEstado.Value <> 0 Then
                    CarregaCidades(cboIdEstado.Text)
                    cboCidade.Enabled = True
                    cboCidade.ValueString = .Item("CIDADE")
                End If

                txtCNPJ.Text = .Item("CNPJ")
                'txtDataFinal.Text = .Item("DATAFINAL")
                'txtDataInicial.Text = .Item("DATAINICIAL")
                txtEMail.Text = .Item("EMAIL")
                txtEndereco.Text = .Item("ENDERECO")
                txtFantasia.Text = .Item("FANTASIA")
                txtRazaoSocial.Text = .Item("RAZAOSOCIAL")
                txtSite.Text = .Item("Site")
                ViewState("NomePesquisa") = .Item("NOMEPESQUISA")
            End With
        Else
            txtCepDe.Text = ""
            txtCepAte.Text = ""
            txtBairro.Text = ""
            cboCidade.ValueString = ""
            txtCNPJ.Text = ""
            'txtDataFinal.Text = ""
            'txtDataInicial.Text = ""
            txtEMail.Text = ""
            txtEndereco.Text = ""
            txtFantasia.Text = ""
            txtRazaoSocial.Text = ""
            txtSite.Text = ""
            ViewState("NomePesquisa") = ""
            cboIdEstado.Value = 0
        End If

    End Sub

    Private Sub BindGrid()

        Pesq = New clsPesquisas
        Dim ds As DataSet = Pesq.PesquisarEmpresas(ViewState("Atividades"), ViewState("Estados"), txtRazaoSocial.Text, Usuario.IDUsuario, txtDataInicial.Text, txtDataFinal.Text, cboOrdenar.Value, Usuario.IdEmpresa, txtFantasia.Text, txtEndereco.Text, cboCidade.ValueString, txtCNPJ.Text, txtCepDe.Text, txtCepAte.Text, txtSite.Text, txtEMail.Text, txtBairro.Text, cboStatusSIG.Value)
        If ds.Tables(0).Rows.Count > 0 Then
            lblMensagemTopo.Text = "FORAM LOCALIZADAS " & ds.Tables(0).Rows.Count & " EMPRESAS"
        Else
            lblMensagemTopo.Text = "A PESQUISA NÃO LOCALIZOU NENHUMA EMPRESA "
        End If
        Dim iCount As Integer = ds.Tables(0).Rows.Count
        dtgProdutos.DataSource = ds
        dtgProdutos.DataBind()
        With dtgProdutos
            If iCount > 0 Then
                Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de " & .PageCount
                strTexto &= " - " & iCount & " registro" & IIf(iCount < 2, "", "s") & " retornado" & IIf(iCount < 2, "", "s")
                BarraNavegacao1.SetDescription(strTexto)
            Else
                BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
            End If
        End With

    End Sub

    Private Sub BindGrids()

        dtlAtividades.DataSource = Pesq.ListAtividades(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlAtividades.DataBind()

        'NORTE
        dtlEstadosNo.DataSource = Pesq.ListEstadosEmpresasNo(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosNo.DataBind()

        'NORDESTE
        dtlEstadosNr.DataSource = Pesq.ListEstadosEmpresasNr(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosNr.DataBind()

        'SUL
        dtlEstadosSl.DataSource = Pesq.ListEstadosEmpresasSl(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosSl.DataBind()

        'SUDESTE
        dtlEstadosSd.DataSource = Pesq.ListEstadosEmpresasSd(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosSd.DataBind()

        'CENTRO-OESTE
        dtlEstadosCo.DataSource = Pesq.ListEstadosEmpresasCo(Usuario.IDUsuario, ViewState("IdPesquisa"), Usuario.IdEmpresa)
        dtlEstadosCo.DataBind()

    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)

        dtgProdutos.CurrentPageIndex = e.NewPageIndex
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Function Pesquisar()

        ViewState("Ordenacao") = cboOrdenar.Value
        hddOrdem.Value = ViewState("Ordenacao")

        ChecarItens()
        Pesq = New clsPesquisas
        Selecao.Visible = False
        tblResultados.Visible = True
        BindGrid()

        If CheckPermission("Exportar Pesquisa Empresa", "VISUALIZAR") Then
            btnExportar.Attributes.Add("onClick", "javascript:XM_ITC_Exportar();")
            btnExportar.Visible = True
        Else
            btnExportar.Visible = False
        End If

    End Function

    Public Function getPostBack() As String

        Return Page.GetPostBackEventReference(btnTeste, "")

    End Function

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        Pesquisar()

    End Sub

    Private Sub ChecarItens()

        'ESTADOS
        Dim i As Integer
        Dim strEstados = "", strAtividades As String = ""

        ''NORTE
        'For i = 0 To dtlEstadosNo.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlEstadosNo.Items(i).FindControl("chkEstadosNo")
        '    If CurrentCheckBox.Checked Then
        '        If strEstados.Trim <> "" Then
        '            strEstados += ","
        '        End If
        '        strEstados += dtlEstadosNo.DataKeys.Item(dtlEstadosNo.Items(i).ItemIndex).ToString()
        '    End If
        'Next

        ''NORDESTE
        'For i = 0 To dtlEstadosNr.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlEstadosNr.Items(i).FindControl("chkEstadosNr")
        '    If CurrentCheckBox.Checked Then
        '        If strEstados.Trim <> "" Then
        '            strEstados += ","
        '        End If
        '        strEstados += dtlEstadosNr.DataKeys.Item(dtlEstadosNr.Items(i).ItemIndex).ToString()
        '    End If
        'Next

        ''SUL
        'For i = 0 To dtlEstadosSl.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlEstadosSl.Items(i).FindControl("chkEstadosSl")
        '    If CurrentCheckBox.Checked Then
        '        If strEstados.Trim <> "" Then
        '            strEstados += ","
        '        End If
        '        strEstados += dtlEstadosSl.DataKeys.Item(dtlEstadosSl.Items(i).ItemIndex).ToString()
        '    End If
        'Next

        ''SUDESTE
        'For i = 0 To dtlEstadosSd.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlEstadosSd.Items(i).FindControl("chkEstadosSd")
        '    If CurrentCheckBox.Checked Then
        '        If strEstados.Trim <> "" Then
        '            strEstados += ","
        '        End If
        '        strEstados += dtlEstadosSd.DataKeys.Item(dtlEstadosSd.Items(i).ItemIndex).ToString()
        '    End If
        'Next

        ''CENTRO-OESTE
        'For i = 0 To dtlEstadosCo.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlEstadosCo.Items(i).FindControl("chkEstadosCo")
        '    If CurrentCheckBox.Checked Then
        '        If strEstados.Trim <> "" Then
        '            strEstados += ","
        '        End If
        '        strEstados += dtlEstadosCo.DataKeys.Item(dtlEstadosCo.Items(i).ItemIndex).ToString()
        '    End If
        'Next

        'SETANDO RESULTADO FINAL EM VIEWSTATE
        ViewState("Estados") = hdEstados.Value


        'ATIVIDADES
        'For i = 0 To dtlAtividades.Items.Count - 1
        '    Dim CurrentCheckBox As CheckBox = dtlAtividades.Items(i).FindControl("chkAtividades")
        '    If CurrentCheckBox.Checked Then
        '        If strAtividades.Trim <> "" Then
        '            strAtividades += ","
        '        End If
        '        strAtividades += dtlAtividades.DataKeys.Item(dtlAtividades.Items(i).ItemIndex).ToString()
        '    End If
        'Next
        ViewState("Atividades") = hdAtividades.Value

    End Sub

    Private Sub btnNovaPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaPesquisa.Click
        Page.Response.Redirect("PesquisaEmpresas.aspx")
    End Sub

    Private Sub btnNovaPesquisa2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaPesquisa2.Click
        Page.Response.Redirect("PesquisaEmpresas.aspx")
    End Sub

    Private Sub cboPesquisasSalvas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPesquisasSalvas.SelectedIndexChanged

        ViewState("IdPesquisa") = cboPesquisasSalvas.Value
        Response.Redirect("pesquisaempresas.aspx?idpesquisa=" & ViewState("IdPesquisa"))

        'ViewState("NomePesquisa") = cboPesquisasSalvas.Text
        'Pesq = New clsPesquisas
        'Inflate()
        'BindGrids()
        'Pesq = Nothing
        'If ViewState("IdPesquisa") > 0 Then
        '    btnExcluirPesquisa.Enabled = True
        'Else
        '    btnExcluirPesquisa.Enabled = False
        'End If

    End Sub

    'Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnImprimir.Click

    '    Dim strResultados As String = "", i As Integer = 0

    '    For i = 0 To dtgProdutos.Items.Count - 1
    '        Dim CurrentCheckBox As CheckBox = dtgProdutos.Items(i).FindControl("chkItemResultado")
    '        If CurrentCheckBox.Checked Then
    '            If strResultados.Trim <> "" Then
    '                strResultados += ","
    '            End If
    '            strResultados += dtgProdutos.DataKeys.Item(dtgProdutos.Items(i).ItemIndex).ToString()
    '        End If
    '    Next

    '    Dim strJavaScript As String = ""
    '    strJavaScript += "<SCRIPT LANGUAGE='JAVASCRIPT'>window.open('RelatorioEmpresas.aspx?T=" & TipoRelatorio.SelectedItem.Value & "&O=" & strResultados & "', 'RelatorioObras', 'fullscreen=no,toolbar=yes,status=no,menubar=no,scrollbars=yes,resizable=yes,directories=no,location=no,width=800,height=600,left=0,top=0');</SCRIPT>"
    '    Response.Write(strJavaScript)

    'End Sub

    Private Sub btnSalvarPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarPesquisa.Click

        ChecarItens()

        If ViewState("IdPesquisa") > 0 Then
            Pesq = New clsPesquisas
            Dim strPagina As String = "PesquisaEmpresas.aspx?IdPesquisa=" & Pesq.SalvarPesquisaEmpresa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Estados"), ViewState("Atividades"), txtNome.Text, txtRazaoSocial.Text, txtFantasia.Text, txtEndereco.Text, cboCidade.ValueString, txtCNPJ.Text, txtCepDe.Text, txtCepAte.Text, txtSite.Text, txtEMail.Text, txtBairro.Text, cboIdEstado.Value)
            Response.Redirect(strPagina)
            'Pesq.SalvarPesquisaEmpresa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Estados"), ViewState("Atividades"), ViewState("NomePesquisa"), txtRazaoSocial.Text, txtFantasia.Text, txtEndereco.Text, cboCidade.ValueString, txtCNPJ.Text, txtCepDe.Text, txtCepAte.Text, txtSite.Text, txtEMail.Text, txtBairro.Text)
        Else
            Selecao.Visible = False
            PesquisaEmpresas.Visible = False
            tblResultados.Visible = False
            tblSalvar.Visible = True
        End If

    End Sub

    Private Sub btnExcluirPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirPesquisa.Click
        Pesq = New clsPesquisas
        Pesq.ExcluirPesquisaEmpresa(ViewState("IdPesquisa"), Usuario.IDUsuario)
        Pesq = Nothing
        Page.Response.Redirect("PesquisaEmpresas.aspx")
    End Sub

    Private Sub BarraNavegacao2_NextReg() Handles Barranavegacao2.NextReg

        If (dtgProdutos.CurrentPageIndex < (dtgProdutos.PageCount - 1)) Then
            dtgProdutos.CurrentPageIndex += 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao2_LastReg() Handles Barranavegacao2.LastReg

        dtgProdutos.CurrentPageIndex = (dtgProdutos.PageCount - 1)
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao2_FirstReg() Handles Barranavegacao2.FirstReg

        dtgProdutos.CurrentPageIndex = 0
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao2_PreviousReg() Handles Barranavegacao2.PreviousReg

        If (dtgProdutos.CurrentPageIndex > 0) Then
            dtgProdutos.CurrentPageIndex -= 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao1_NextReg() Handles BarraNavegacao1.NextReg

        If (dtgProdutos.CurrentPageIndex < (dtgProdutos.PageCount - 1)) Then
            dtgProdutos.CurrentPageIndex += 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao1_LastReg() Handles BarraNavegacao1.LastReg

        dtgProdutos.CurrentPageIndex = (dtgProdutos.PageCount - 1)
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao1_FirstReg() Handles BarraNavegacao1.FirstReg

        dtgProdutos.CurrentPageIndex = 0
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub BarraNavegacao1_PreviousReg() Handles BarraNavegacao1.PreviousReg

        If (dtgProdutos.CurrentPageIndex > 0) Then
            dtgProdutos.CurrentPageIndex -= 1
        End If
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing

    End Sub

    Private Sub btnSalvarAgora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvarAgora.Click

        Pesq = New clsPesquisas
        Page.Response.Redirect("PesquisaEmpresas.aspx?IdPesquisa=" & Pesq.SalvarPesquisaEmpresa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Estados"), ViewState("Atividades"), txtNome.Text, txtRazaoSocial.Text, txtFantasia.Text, txtEndereco.Text, cboCidade.ValueString, txtCNPJ.Text, txtCepDe.Text, txtCepAte.Text, txtSite.Text, txtEMail.Text, txtBairro.Text, cboIdEstado.Value))
        Pesq = Nothing

    End Sub

    Private Sub cboIdEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdEstado.SelectedIndexChanged

        CarregaCidades(cboIdEstado.Text)
        cboCidade.Enabled = True

    End Sub

    Private Sub CarregaCidades(ByVal Estado As String)

        cboCidade.Clear()

        Dim Cid As New clsCidades
        With cboCidade
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Cid.ListCidades(Estado)
            .DataTextField = "CIDADE"
            .DataValueField = "CIDADE"
            .DataBind()
            Cid = Nothing
        End With

    End Sub

    Private Sub btnGravarLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravarLink.Click

        If Pesq Is Nothing Then Pesq = New clsPesquisas

        Dim xml As New XMLConfig
        Dim p_Host As String = xml.GetValue("EnderecoLinkRelatorio", False)
        Dim p_Guid As String = Pesq.setReportGuid(Me.Usuario.IdEmpresa, hidLink.Value).ToString()
        Dim strBody As String = Server.UrlEncode(p_Host & "relatorioempresas.aspx?gd=" & Server.UrlEncode(p_Guid))

        Dim strScript As String = "<scr" & "ipt lang" & "uage='java" & "script'>" & vbCrLf
        If rdFormaEnvioLinkOut.Checked Then
            strScript &= "document.location.href = 'mail" & "to:?subject=ITC.Net - Relatorio de Empresas&body=" & strBody & "%0D%0ASe este link estiver inativo para Click, copie e cole no seu navegador." & "';" & vbCrLf
        Else
            strScript &= "document.location.href = 'mail" & "to:?subject=ITC.Net - Relatorio de Empresas?body=" & strBody & "%0D%0ASe este link estiver inativo para Click, copie e cole no seu navegador." & "';" & vbCrLf
        End If

        'strScript &= "window.history.go(-1);" & vbCrLf
        strScript &= "</scr" & "ipt>" & vbCrLf

        ltScript.Text = strScript

        Pesq = Nothing
        xml = Nothing

    End Sub

    Private Sub btnTeste_ServerClick(sender As Object, e As System.EventArgs) Handles btnTeste.ServerClick

        Pesquisar()

    End Sub

End Class
