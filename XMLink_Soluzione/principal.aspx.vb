Public Class principal
    Inherits XMProtectedPage
    Protected WithEvents ltrMessage As System.Web.UI.WebControls.Literal
    Protected WithEvents btnResumo As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnRecados As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVendedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboStatus As ComboBox
    Protected WithEvents frmGrid As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected clsPed As clsPedido

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
        clsPed = New clsPedido(Me)
        If Not Page.IsPostBack Then
            ViewState("Desc") = True
            If Usuario.IDVendedor > 0 Then
                txtVendedor.Enabled = False
                txtVendedor.Text = Me.Usuario.Nome
            End If
            Dim clsSta As New clsStatus(Me)
            cboStatus.DataSource = clsSta.Listar
            cboStatus.DataBind()
            clsSta = Nothing
            cboStatus.Value = 3
            ViewState("IDStatus") = 3
            btnRecados.Visible = CheckPermission("Recado Digital", "Enviar Recado Digital")
            btnResumo.Visible = CheckPermission("Acesso do Sistema", "Visualizar Resumo de Pedidos")
            BindGrid()
        End If

    End Sub

    Public Sub BindGrid()
        frmGrid.Attributes.Add("src", "lista.aspx?cliente=" & txtCliente.Text & "&vendedor=" & txtVendedor.Text & "&idstatus=" & cboStatus.Value & "&tm=" & Now())
    End Sub

    Private Sub btFiltrar_Click(sender As Object, e As System.EventArgs) Handles btFiltrar.Click
        BindGrid()
    End Sub

    'N�O FUNCIONA
    'Private Sub cboStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
    '    ViewState("IDStatus") = cboStatus.Value
    'End Sub

End Class
