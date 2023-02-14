Public Class resumo
    Inherits XMProtectedPage
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm

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
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Dim cls As New clsPedido(Me)
            Dim ds As DataSet = cls.ListResumo
            dtgGrid.DataSource = ds.Tables(0)
            dtgGrid.DataBind()
            Dim intCount As Integer = ds.Tables(1).Rows(0).Item(0)
            If intCount = 0 Then
                lblMessage.Text = "Não há pedidos."
            ElseIf intCount = 1 Then
                lblMessage.Text = "Você tem <b>1</b> pedido."
            Else
                lblMessage.Text = "Você tem <b>" & intCount & "</b> pedidos."
            End If
        End If
    End Sub

End Class
