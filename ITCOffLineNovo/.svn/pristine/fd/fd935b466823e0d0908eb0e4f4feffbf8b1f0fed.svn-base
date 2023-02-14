Imports ITCOffLine
Imports System.Data

Public Class Propostas

    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    Protected WithEvents dtgProposta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtIDPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIdProposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigoAss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As Button
    Protected WithEvents btnProcurarAssociado As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnIncluirRenovacao As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnIncluir As System.Web.UI.WebControls.ImageButton
    Protected WithEvents tblPropostas As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tblAssociado As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents cboRegistros As ComboBox
    Protected WithEvents cboRegistrosAssociados As ComboBox
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Associados As New clsAssociados(0)
    Private Proposta As New clsProposta
    Private ds As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            If CheckPermission("Cadastro de Propostas", "VISUALIZAR") = False Then
                Response.Redirect("home.aspx")
            End If

            ViewState("grdPropostas") = Request("grdPropostas")
            If ViewState("grdPropostas") = "false" Then
                tblPropostas.Visible = False
                tblAssociado.Visible = True
                ViewState("IncluirRenovacao") = 0
                BindAssociados()
            End If

            With cboRegistros
                .AddItem("0", "TODOS OS RESULTADOS")
                .AddItem("10", "10 RESULTADOS")
                .AddItem("25", "25 RESULTADOS")
                .AddItem("50", "50 RESULTADOS")
                .AddItem("100", "100 RESULTADOS")
                .Value = 10
            End With

            With cboRegistrosAssociados
                .AddItem("0", "TODOS OS RESULTADOS")
                .AddItem("10", "10 RESULTADOS")
                .AddItem("25", "25 RESULTADOS")
                .AddItem("50", "50 RESULTADOS")
                .AddItem("100", "100 RESULTADOS")
                .Value = 10
            End With

            BindDataGrid()
        End If
    End Sub

    '********************************************************
    'utilizada para dar um bind dos dados no grid
    '********************************************************
    Private Sub BindDataGrid()
        Dim p_Codigo As Integer = IIf(IsNumeric(txtIdProposta.Text), txtIdProposta.Text, 0)
        ds = Proposta.ListaProposta(p_Codigo, txtRazaoSocial.Text, txtCNPJ.Text, cboRegistros.Value)
        dtgProposta.DataSource = ds
        dtgProposta.DataBind()
    End Sub

    Private Sub BindAssociados()
        Dim p_CodigoAssociado As Integer = IIf(IsNumeric(txtCodigoAss.Text), txtCodigoAss.Text, 0)
        Dim Associados As New clsAssociados
        ds = Associados.List(p_CodigoAssociado, txtRazaoFantasia.Text, "", cboRegistrosAssociados.Value)
        dtgAssociados.DataSource = ds
        dtgAssociados.DataBind()
    End Sub

    Public Sub dtgProposta_doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgProposta.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Proposta = Nothing
    End Sub

    Public Sub dtgAssociados_doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgAssociados.CurrentPageIndex = e.NewPageIndex
        BindAssociados()
        Associados = Nothing
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        dtgProposta.CurrentPageIndex = 0
        BindDataGrid()
    End Sub

    Private Sub btnProcurarAssociado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnProcurarAssociado.Click
        'tblPedido.Visible = False
        'tblObservacao.Visible = False
        BindAssociados()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIncluir.Click
        tblPropostas.Visible = False
        tblAssociado.Visible = True
        ViewState("IncluirRenovacao") = 0
        BindAssociados()
    End Sub

    Private Sub btnIncluirRenovacao_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIncluirRenovacao.Click
        tblPropostas.Visible = False
        tblAssociado.Visible = True
        ViewState("IncluirRenovacao") = 1
        BindAssociados()
    End Sub
End Class
