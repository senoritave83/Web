Public Class Demonstracao2

    Inherits System.Web.UI.Page

    Protected WithEvents Checkbox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dtlFases As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstados As System.Web.UI.WebControls.DataList
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtlPesquisaTipos As System.Web.UI.WebControls.DataList
    Protected WithEvents dtgResultados As System.Web.UI.WebControls.DataGrid

    Protected WithEvents tblSelecao As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblTopo As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblResultados As System.Web.UI.HtmlControls.HtmlTable

    Protected WithEvents btnNovaPesquisa As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNovaPesquisa2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnImprimirResumo As System.Web.UI.WebControls.Image
    Protected WithEvents cboPesquisador As ComboBox
    Protected WithEvents cboMostrar As ComboBox
    Protected WithEvents cboStatusSIG As ComboBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblMensagemTopo As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagemTopo2 As System.Web.UI.WebControls.Label
    Protected WithEvents tblBotoesResultados As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dtlEstagios As System.Web.UI.WebControls.DataList
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCepDe As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCepAte As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TipoRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cboOrdenar As ComboBox
    Protected WithEvents cboFatorAreaConstruida As ComboBox
    Protected WithEvents cboFatorValor As ComboBox
    Protected WithEvents txtInicioObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTerminoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAreaConstruida As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdMolidade As ComboBox
    Protected WithEvents txtCodigoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescricaoObra As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumeroRevisao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmpresaParticipante As System.Web.UI.WebControls.TextBox
    Protected WithEvents BarraNavegacao1 As BarraNavegacao
    Protected WithEvents Barranavegacao2 As BarraNavegacao
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboChecagemNrRevisao As ComboBox

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

            Pesq = New clsPesquisas
            ViewState("IdPesquisa") = CInt(0 & Page.Request("IdPesquisa"))

            '--------------------------------------------------------------
            'INFORMAÇÕES SOBRE A PESQUISA
            '--------------------------------------------------------------

            With cboOrdenar
                .EnableValidation = False
                .CssClass = "f8"
                .AddItem(1, "CÓDIGO DO ITC")
                .AddItem(2, "NOME DA OBRA")
                .AddItem(3, "ENDEREÇO")
                .AddItem(4, "NOME FANTASIA DA EMPRESA")
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

            lblMensagemTopo.Text = "Selecione todos os itens desejados em sua pesquisa e clique no botão PESQUISAR."

            tblResultados.Visible = False
            BindGrids()
            Pesq = Nothing

        End If

    End Sub

    Private Sub BindGrids()

        Dim ds As DataSet = Pesq.ListEstados(1, ViewState("IdPesquisa"), -1)
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item("DESCRICAOESTADO") = "GRANDE SÃO PAULO" Then
                ViewState("GSP") = 1
                Exit For
            Else
                ViewState("GSP") = 0
            End If
        Next
        'dtgPesquisaRegioes.DataBind()

        dtlPesquisaTipos.DataSource = Pesq.ListTipos(1, ViewState("IdPesquisa"), -1)
        dtlPesquisaTipos.DataBind()

        dtlFases.DataSource = Pesq.ListFases(1, ViewState("IdPesquisa"), -1)
        dtlFases.DataBind()

        dtlEstados.DataSource = Pesq.ListEstados(1, ViewState("IdPesquisa"), -1)
        dtlEstados.DataBind()

        Dim Est As New clsEstagios
        dtlEstagios.DataSource = Est.ListTabela(1, ViewState("IdPesquisa"), -1)
        dtlEstagios.DataBind()
        Est = Nothing

    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPesquisar.Click

        Dim strMensagem As String = ""
        ChecarItens()
        Pesq = New clsPesquisas
        tblSelecao.Visible = False
        tblResultados.Visible = True
        btnImprimirResumo.Attributes.Add("onClick", "javascript:XM_ITC_Pesquisar();")
        BindGrid()

    End Sub

    Private Sub BindGrid()

        Dim ds As DataSet = Pesq.Pesquisar(ViewState("Tipos"), ViewState("Regioes"), ViewState("Estados"), ViewState("Fases"), txtDataInicio.Text, txtDataFim.Text, 1, txtNomeObra.Text, cboOrdenar.Value, -1, _
                                txtCodigoObra.Text, txtEndereco.Text, txtBairro.Text, txtCidade.Text, txtDescricaoObra.Text, txtCepDe.Text, txtCepAte.Text, txtNumeroRevisao.Text, txtInicioObra.Text, txtTerminoObra.Text, cboPesquisador.Value, txtAreaConstruida.Text, cboFatorAreaConstruida.Value, txtValor.Text, cboFatorValor.Value, txtEmpresaParticipante.Text, cboIdMolidade.Value, ViewState("Estagios"), cboChecagemNrRevisao.Value, ViewState("GSP"), cboMostrar.Value, cboStatusSIG.Value, True)

        Dim iCount As Integer = ds.Tables(0).Rows.Count
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

    End Sub

    Private Sub ChecarItens()

        ViewState("Estados") = fncGetCheckedItems(dtlEstados, "chkEstados")
        ViewState("Estagios") = fncGetCheckedItems(dtlEstagios, "chkEstagios")
        ViewState("Fases") = fncGetCheckedItems(dtlFases, "chkFases")
        ViewState("Tipos") = fncGetCheckedItems(dtlPesquisaTipos, "chkTipos")
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

    Private Sub btnNovaPesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovaPesquisa.Click
        Page.Response.Redirect("demonstracao2.aspx")
    End Sub
    Private Sub btnNovaPesquisa2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovaPesquisa2.Click
        Page.Response.Redirect("demonstracao2.aspx")
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgResultados.CurrentPageIndex = e.NewPageIndex
        Pesq = New clsPesquisas
        BindGrid()
        Pesq = Nothing
    End Sub

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

End Class
