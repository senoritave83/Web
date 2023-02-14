Imports ITCOffLine
Imports System.Data

Public Class Empresa
    Inherits XMWebPage
    Protected WithEvents dtgEmpresas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents cboOrdernar As ComboBox
    Protected WithEvents cboStatus As ComboBox
    Private Empresas As New clsEmpresas(0)
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As Button
    Protected WithEvents Barra As BarraBotoes2
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
            With cboOrdernar
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(1, "Razão Social")
                .AddItem(2, "Fantasia")
                .AddItem(3, "Endereço")
                .AddItem(4, "Estado")
                .EnableValidation = False
            End With

            With cboStatus
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(3, "TODOS")
                .AddItem(0, "INATIVO")
                .AddItem(1, "ATIVO")
                .AddItem(2, "PENDENTE")
            End With

        End If

        Barra.AtivarBotoes(Barra.Botoes_Ativos.Incluir)

    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("empresasdet.aspx")
    End Sub

    '********************************************************
    'utilizada para dar um bind dos dados no grid
    '********************************************************
    Private Sub BindDataGrid()
        ds = Empresas.List(txtFantasia.Text, txtRazaoSocial.Text, txtDataInicial.Text, txtDataFinal.Text, cboOrdernar.Value, cboStatus.Value)
        dtgEmpresas.DataSource = ds
        dtgEmpresas.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgEmpresas.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Empresas = Nothing
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        BindDataGrid()
    End Sub

End Class
