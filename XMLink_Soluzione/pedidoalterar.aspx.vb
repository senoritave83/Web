Public Class pedidoalterar
    Inherits XMProtectedPage
    Protected WithEvents lblNumero As System.Web.UI.WebControls.Label
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataEmissao As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSim As System.Web.UI.WebControls.Button
    Protected WithEvents btnNao As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents trMotivo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dtgMotivos As DataGrid
    Protected cls As clsPedido
    Protected sIDPedido As String
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
        cls = New clsPedido(Me)
        If Not Page.IsPostBack Then
            sIDPedido = Request("IDPedido")
            ViewState("IDPedido") = sIDPedido
            ViewState("Tipo") = Request("Tipo")
            cls.IDPedido = sIDPedido
            Inflate()
            BindMotivos()
        Else
            sIDPedido = ViewState("IDPedido")
            cls.IDPedido = sIDPedido
        End If
    End Sub

    Private Sub BindMotivos()
        dtgMotivos.DataSource = cls.ListMotivos()
        dtgMotivos.DataBind()
    End Sub

    Private Sub Inflate()
        lblNumero.Text = cls.NumeroPedido
        lblDataEmissao.Text = cls.DataEmissao
        lblStatus.Text = cls.StatusPedido
        trMotivo.Visible = False
        If ViewState("Tipo") = "A" Then
            lblMensagem.Text = "Confirma a aprovação do pedido " & cls.NumeroPedido & "?"
        ElseIf ViewState("Tipo") = "C" Then
            lblMensagem.Text = "Deseja realmente cancelar o pedido " & cls.NumeroPedido & "?"
            trMotivo.Visible = True
        End If
    End Sub

    Private Sub btnNao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNao.Click
        Response.Redirect("pedido.aspx?idpedido=" & Server.UrlEncode(sIDPedido))
    End Sub

    Private Sub btnSim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSim.Click
        If ViewState("Tipo") = "A" Then
            cls.AprovaPedido()
        ElseIf ViewState("Tipo") = "C" Then
            cls.ReprovaPedido(txtMotivo.Text)
        End If
        Response.Redirect("pedido.aspx?idpedido=" & Server.UrlEncode(sIDPedido))
    End Sub
End Class
