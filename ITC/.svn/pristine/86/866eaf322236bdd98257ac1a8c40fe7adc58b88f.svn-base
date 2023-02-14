Public Class Associados
    Inherits XMWebPage
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Private Associados As New clsAssociados(0)
    Protected WithEvents txtCodigoITC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProcurar As Button
    Protected WithEvents BarraNavegacao As BarraNavegacao
    Protected WithEvents tblNav As HtmlTable

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

        End If
    End Sub

    '********************************************************
    'utilizada para bindar dados no grid
    '********************************************************
    Private Sub BindDataGrid()
        Dim p_Codigo As Integer = IIf(IsNumeric(txtCodigoITC.Text), txtCodigoITC.Text, 0)
        ds = Associados.List(p_Codigo, txtRazaoSocial.Text, txtCNPJ.Text, 10) 'Registros no grid
        dtgAssociados.DataSource = ds
        dtgAssociados.DataBind()
    End Sub

    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgAssociados.CurrentPageIndex = e.NewPageIndex
        BindDataGrid()
        Associados = Nothing
    End Sub

    Private Sub BarraNavegacao_NextReg() Handles BarraNavegacao.NextReg
        If (dtgAssociados.CurrentPageIndex < (dtgAssociados.PageCount - 1)) Then
            dtgAssociados.CurrentPageIndex += 1
        End If
        BindDataGrid()
    End Sub

    Private Sub BarraNavegacao_LastReg() Handles BarraNavegacao.LastReg
        dtgAssociados.CurrentPageIndex = (dtgAssociados.PageCount - 1)
        BindDataGrid()
    End Sub

    Private Sub BarraNavegacao_FirstReg() Handles BarraNavegacao.FirstReg
        dtgAssociados.CurrentPageIndex = 0
        BindDataGrid()
    End Sub

    Private Sub BarraNavegacao_PreviousReg() Handles BarraNavegacao.PreviousReg
        If (dtgAssociados.CurrentPageIndex > 0) Then
            dtgAssociados.CurrentPageIndex -= 1
        End If
        BindDataGrid()
    End Sub

    Private Sub btnProcurar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        BindDataGrid()

        'tblNav.Visible = True

    End Sub
End Class
