Public Class PesquisaTabelasFases

    Inherits XMWebPage

    Protected WithEvents lblMensagemTopo As System.Web.UI.WebControls.Label
    Protected WithEvents dtgEstagios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents BarraNavTiposObras As BarraNavegacao

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

            Dim Est As New clsEstagios()
            dtgEstagios.DataSource = Est.ListTabela()
            dtgEstagios.DataBind()
            Est = Nothing

        End If
    End Sub

End Class
