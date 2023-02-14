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
    Protected WithEvents cboOrdernar As ComboBox
    Protected WithEvents cboStatus As ComboBox
    Protected WithEvents nav As BarraNavegacao
    Protected WithEvents btnProcurar As System.Web.UI.WebControls.Button
    Protected WithEvents tblNav As HtmlTable

    Private Obras As New clsObras
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

            tblNav.Visible = False

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

    Private Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        BindDataGrid()
        tblNav.Visible = True
    End Sub

    Private Sub nav_NextReg() Handles nav.NextReg
        If (dtgObras.CurrentPageIndex < (dtgObras.PageCount - 1)) Then
            dtgObras.CurrentPageIndex += 1
        End If

        BindDataGrid()

    End Sub

    Private Sub nav_LastReg() Handles nav.LastReg
        dtgObras.CurrentPageIndex = (dtgObras.PageCount - 1)

        BindDataGrid()

    End Sub

    Private Sub nav_FirstReg() Handles nav.FirstReg
        dtgObras.CurrentPageIndex = 0

        BindDataGrid()

    End Sub

    Private Sub nav_PreviousReg() Handles nav.PreviousReg
        If (dtgObras.CurrentPageIndex > 0) Then
            dtgObras.CurrentPageIndex -= 1
        End If

        BindDataGrid()

    End Sub
End Class
