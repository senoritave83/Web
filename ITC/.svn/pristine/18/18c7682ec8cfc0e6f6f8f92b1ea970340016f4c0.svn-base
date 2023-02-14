Public Class PesquisaAssociados
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCancInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCancFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox

    Protected WithEvents dtlProdutos As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlAtividade As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlPosicao As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlRamos As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlStatus As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlFormaPagto As System.Web.UI.WebControls.DataList

    Protected WithEvents btnNovaPesquisa As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNovaPesquisa2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.Image
    Protected WithEvents btnImprimirResumo As System.Web.UI.WebControls.Image

    Protected WithEvents cboOrdenar As ComboBox
    Protected WithEvents Ord As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Barranavegacao2 As BarraNavegacao
    Protected WithEvents BarraNavegacao1 As BarraNavegacao
    Protected WithEvents tblResultados As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblSelecao As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dtgResultados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMensagemTopo As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagemTopo2 As System.Web.UI.WebControls.Label
    Protected WithEvents cboVendedor As ComboBox
    Protected WithEvents cboIdEstado As System.Web.UI.WebControls.DropDownList

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

            tblResultados.Visible = False
            tblSelecao.Visible = True

            Pesq = New clsPesquisas()
            BindGrids()
            Pesq = Nothing

            Dim ven As New clsUsuario
            With cboVendedor
                .DataSource = ven.ListarVendedores(Me.Usuario.IdEmpresa)
                .DataTextField = "Vendedor"
                .DataValueField = "IDVENDEDOR"
                .DataBind()
            End With
            ven = Nothing

            Dim uf As New clsEstados
            With cboIdEstado
                .DataSource = uf.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With
            uf = Nothing
            cboIdEstado.Items.Insert(0, New ListItem("Selecione...", "0"))

        End If
    End Sub

    Private Sub BindGrids()

        dtlAtividade.DataSource = Pesq.ListAtividades()
        dtlAtividade.DataBind()

        dtlRamos.DataSource = Pesq.ListRamos
        dtlRamos.DataBind()

        dtlPosicao.DataSource = Pesq.ListPosicao
        dtlPosicao.DataBind()

        dtlProdutos.DataSource = Pesq.ListProdutos
        dtlProdutos.DataBind()

        dtlStatus.DataSource = Pesq.ListStatus
        dtlStatus.DataBind()

        dtlFormaPagto.DataSource = Pesq.ListFormaPagto
        dtlFormaPagto.DataBind()

        With cboOrdenar
            .AddItem(2, "CIDADE")
            .AddItem(3, "ESTADO")
            .AddItem(1, "FANTASIA")
            .AddItem(6, "RAZÃO SOCIAL")
            .AddItem(5, "MÓDULO")
            .AddItem(4, "STATUS")
            .Value = 1
        End With

    End Sub

    Private Sub BindGrid()

        tblSelecao.Visible = False
        tblResultados.Visible = True
        Ord.Value = cboOrdenar.Value

        Pesq = New clsPesquisas()
        Dim ds As DataSet = Pesq.PesquisarAssociados(ViewState("Atividade"), ViewState("Ramo"), ViewState("Posicao"), ViewState("Produto"), txtDataInicio.Text, txtDataFim.Text, txtFantasia.Text, txtRazaoSocial.Text, cboOrdenar.Value, ViewState("Status"), cboVendedor.Value, txtCancInicial.Text, txtCancFinal.Text, cboIdEstado.SelectedValue, ViewState("FormaPagto"))
        If ds.Tables(0).Rows.Count > 0 Then
            lblMensagemTopo.Text = "FORAM LOCALIZADOS " & ds.Tables(0).Rows.Count & " ASSOCIADOS"
        Else
            lblMensagemTopo.Text = "A PESQUISA NÃO LOCALIZOU NENHUM ASSOCIADO "
        End If
        lblMensagemTopo2.Text = ""
        Dim iCount As Integer = ds.Tables(0).Rows.Count
        dtgResultados.DataSource = ds
        dtgResultados.DataBind()
        With dtgResultados
            If iCount > 0 Then
                Dim strTexto As String = "Página " & (.CurrentPageIndex + 1) & " de " & .PageCount
                strTexto &= " - " & iCount & " registro" & IIf(iCount < 2, "", "s") & " retornado" & IIf(iCount < 2, "", "s")
                BarraNavegacao1.SetDescription(strTexto)
                Barranavegacao2.SetDescription(strTexto)
            Else
                BarraNavegacao1.SetDescription("Nenhum Registro Retornado")
                Barranavegacao2.SetDescription("Nenhum Registro Retornado")
            End If
        End With

        btnImprimir.Attributes.Add("onClick", "javascript:XM_ITC_Pesquisar();")
        btnImprimirResumo.Attributes.Add("onClick", "javascript:XM_ITC_PesquisarResumo();")

    End Sub

    Private Sub btnNovaPesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovaPesquisa.Click
        Response.Redirect("pesquisaassociados.aspx")
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPesquisar.Click

        Dim i As Integer
        Dim strProduto As String = ""
        Dim strPosicao As String = ""
        Dim strRamo As String = ""
        Dim strAtividade As String = ""



        ViewState("Atividade") = ""
        ViewState("Ramo") = ""
        ViewState("Posicao") = ""
        ViewState("Produto") = ""
        ViewState("Status") = ""
        ViewState("FormaPagto") = ""

        For i = 0 To dtlProdutos.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlProdutos.Items(i).FindControl("chkProdutos")
            If CurrentCheckBox.Checked Then
                If ViewState("Produto").Trim <> "" Then
                    ViewState("Produto") += ","
                End If
                ViewState("Produto") += dtlProdutos.DataKeys.Item(dtlProdutos.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtlPosicao.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlPosicao.Items(i).FindControl("chkPosicao")
            If CurrentCheckBox.Checked Then
                If ViewState("Posicao").Trim <> "" Then
                    ViewState("Posicao") += ","
                End If
                ViewState("Posicao") += dtlPosicao.DataKeys.Item(dtlPosicao.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtlRamos.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlRamos.Items(i).FindControl("chkRamo")
            If CurrentCheckBox.Checked Then
                If ViewState("Ramo").Trim <> "" Then
                    ViewState("Ramo") += ","
                End If
                ViewState("Ramo") += dtlRamos.DataKeys.Item(dtlRamos.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtlAtividade.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlAtividade.Items(i).FindControl("chkAtividade")
            If CurrentCheckBox.Checked Then
                If ViewState("Atividade").Trim <> "" Then
                    ViewState("Atividade") += ","
                End If
                ViewState("Atividade") += dtlAtividade.DataKeys.Item(dtlAtividade.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtlStatus.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlStatus.Items(i).FindControl("chkStatus")
            If CurrentCheckBox.Checked Then
                If ViewState("Status").Trim <> "" Then
                    ViewState("Status") += ","
                End If
                ViewState("Status") += dtlStatus.DataKeys.Item(dtlStatus.Items(i).ItemIndex).ToString()
            End If
        Next

        '*************************************
        'VERIFICANDO FORMA DE PAGTO
        '*************************************
        For i = 0 To dtlFormaPagto.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlFormaPagto.Items(i).FindControl("chkFormaPagto")
            If CurrentCheckBox.Checked Then
                If ViewState("FormaPagto").Trim <> "" Then
                    ViewState("FormaPagto") += ","
                End If
                ViewState("FormaPagto") += dtlFormaPagto.DataKeys.Item(dtlFormaPagto.Items(i).ItemIndex).ToString()
            End If
        Next

        BindGrid()

    End Sub

    Private Sub btnNovaPesquisa2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovaPesquisa2.Click
        Response.Redirect("pesquisaassociados.aspx")
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
