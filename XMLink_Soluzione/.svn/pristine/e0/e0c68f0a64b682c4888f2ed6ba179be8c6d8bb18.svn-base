Public Class visitas
    Inherits XMProtectedPage
    Protected WithEvents ltrMessage As System.Web.UI.WebControls.Literal
    Protected WithEvents btnResumo As System.Web.UI.WebControls.Button
    Protected WithEvents btnHistorico As System.Web.UI.WebControls.Button
    Protected WithEvents btFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVendedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents frmGrid As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected clsVis As clsVisita

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

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsVis = New clsVisita(Me)
        If Not Page.IsPostBack Then
            If CheckPermission("Acesso do Sistema", "Visualizar Visitas") = False Then
                Response.Redirect("principal.aspx")
            End If

            txtDataInicio.Text = Now().AddDays(-30).ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now().ToString("dd/MM/yyyy")
            ViewState("Desc") = True
            If Usuario.IDVendedor > 0 Then
                txtVendedor.Enabled = False
                txtVendedor.Text = Me.Usuario.Nome
            End If
            BindGrid()
        End If

    End Sub

    Public Sub BindGrid()
        frmGrid.Attributes.Add("src", "listavisita.aspx?cliente=" & txtCliente.Text & "&vendedor=" & txtVendedor.Text & "&datainicio=" & Server.UrlEncode(txtDataInicio.Text) & "&datafinal=" & Server.UrlEncode(txtDataFinal.Text))
    End Sub

    Private Sub btFiltrar_Click(sender As Object, e As System.EventArgs) Handles btFiltrar.Click
        BindGrid()
    End Sub
End Class
