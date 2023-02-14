Imports ITCOffLine
Imports System.Data

Public Class Associados
    Inherits XMWebPage
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Private Associados As New clsAssociados(0)
    Protected WithEvents txtCodigoITC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As Button
    Protected WithEvents Barra As BarraBotoes2
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
            Barra.AtivarBotoes(Barra.Botoes_Ativos.Incluir)
            With cboRegistros
                .AddItem("0", "TODOS OS RESULTADOS")
                .AddItem("10", "10 RESULTADOS")
                .AddItem("25", "25 RESULTADOS")
                .AddItem("50", "50 RESULTADOS")
                .AddItem("100", "100 RESULTADOS")
                .Value = 10
            End With
        End If
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("associadosdet.aspx")
    End Sub

    '********************************************************
    'utilizada para dar um bind dos dados no grid
    '********************************************************
    Private Sub BindDataGrid()
        Dim p_Codigo As Integer = IIf(IsNumeric(txtCodigoITC.Text), txtCodigoITC.Text, 0)
        ds = Associados.List(p_Codigo, txtRazaoSocial.Text, txtCNPJ.Text, cboRegistros.Value)
        dtgAssociados.DataSource = ds
        dtgAssociados.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgAssociados.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Associados = Nothing
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        BindDataGrid()
    End Sub

End Class
