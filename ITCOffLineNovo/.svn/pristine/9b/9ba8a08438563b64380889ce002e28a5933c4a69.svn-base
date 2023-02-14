Imports ITCOffLine
Imports System.Data

Public Class Pedidos
    Inherits XMWebPage
    Protected WithEvents dtgPedidos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Private Associados As New clsAssociados(0)
    Private Pedidos As New clsPedidos(0)
    Protected WithEvents txtIDPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As Button
    Protected WithEvents cboRegistros As ComboBox
    Private ds As DataSet

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
            With cboRegistros
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
        Dim p_Codigo As Integer = IIf(IsNumeric(txtIDPedido.Text), txtIDPedido.Text, 0)
        ds = Pedidos.ListaPedido(p_Codigo, txtRazaoSocial.Text, txtCNPJ.Text, cboRegistros.Value)
        dtgPedidos.DataSource = ds
        dtgPedidos.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgPedidos.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Pedidos = Nothing
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        dtgPedidos.CurrentPageIndex = 0
        BindDataGrid()
    End Sub

End Class
