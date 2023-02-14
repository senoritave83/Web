Imports ITCOffLine

'************************************************************
'Classe gerada por XM .NET Class Creator - 15/1/2003 11:47:40
'************************************************************

Public Class Obras
    Inherits XMWebPage
    Protected WithEvents dtgObras As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtCodigoITC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents cboOrdernar As ComboBox
    Protected WithEvents cboStatus As ComboBox

    'Protected WithEvents Barra As BarraBotoes2
    Private Obras As New clsObras()
    Protected WithEvents btnProcurar As Button
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
                .AddItem(1, "Código do ITC")
                .AddItem(2, "Razão Social da Empresa")
                .AddItem(3, "Nome Fantasia da Empresa")
                .AddItem(4, "Nome da Obra")
                .AddItem(5, "Endereço")
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

        Barra.AtivarBotoes(BarraBotoes2.Botoes_Ativos.Incluir)

    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("ObrasDet.aspx?Codigo=0")
    End Sub

    '********************************************************
    'utilizada para dar um bind dos dados no grid
    '********************************************************
    Private Sub BindDataGrid()
        ds = Obras.ListInicial(txtCodigoITC.Text, txtRazaoSocial.Text, txtDataInicio.Text, txtDataFim.Text, cboOrdernar.Value, cboStatus.Value)
        dtgObras.DataSource = ds
        dtgObras.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgObras.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Obras = Nothing
    End Sub

    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        BindDataGrid()
    End Sub

End Class
