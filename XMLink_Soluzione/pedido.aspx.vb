Public Class pedido
    Inherits XMProtectedPage
    Protected WithEvents dtgItens As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAprovar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblNumero As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected cls As clsPedido
    Protected WithEvents lblDataEmissao As System.Web.UI.WebControls.Label
    Protected WithEvents lblCliente As System.Web.UI.WebControls.Label
    Protected WithEvents lblVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblCondicao As System.Web.UI.WebControls.Label
    Protected WithEvents lblForma As System.Web.UI.WebControls.Label
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubTotal As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
    Protected WithEvents lblDesconto As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescontoTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents lblObservacao As System.Web.UI.WebControls.Label
    Protected WithEvents rowObservacao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblLatitude As System.Web.UI.WebControls.Label
    Protected WithEvents lblLongitude As System.Web.UI.WebControls.Label
    Protected WithEvents rowPosicao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblCampanha As System.Web.UI.WebControls.Label
    Protected WithEvents lblCampanhaSeq As System.Web.UI.WebControls.Label
    Protected WithEvents globe As System.Web.UI.WebControls.Image
    Protected WithEvents rowMostraMapa As System.Web.UI.HtmlControls.HtmlTableRow
    Protected sIDPedido As String
    Protected WithEvents latCli As HtmlInputHidden
    Protected WithEvents lonCli As HtmlInputHidden
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
            rowPosicao.Visible = False
            rowMostraMapa.Visible = False
            sIDPedido = Request("IDPedido")
            ViewState("IDPedido") = sIDPedido
            cls.IDPedido = sIDPedido

            Dim clsCliente As clsClientes = New clsClientes(Me)
            clsCliente.Load(cls.IDCliente)
            latCli.Value = clsCliente.Latitude
            lonCli.Value = clsCliente.Longitude

            Inflate()
            BindGrid()
            btnAprovar.Enabled = CheckPermission("Detalhes do Pedido", "Aprovar Pedido")
            btnCancelar.Enabled = CheckPermission("Detalhes do Pedido", "Cancelar Pedido")
        Else
            sIDPedido = ViewState("IDPedido")
            cls.IDPedido = sIDPedido
        End If
    End Sub

    Protected Sub BindGrid()
        dtgItens.DataSource = cls.ListItensPedido()
        dtgItens.DataBind()
    End Sub

    Protected Sub Inflate()
        lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
        lblCondicao.Text = cls.Condicao
        lblCodigo.Text = cls.Codigo
        lblDataEmissao.Text = cls.DataEmissao
        lblDataEntrega.Text = CDate(cls.DataEntrega).ToString("dd/MM/yyyy")
        If cls.Descontos > 0 Then
            lblDescontoTitulo.Text = "Desconto:"
            lblDesconto.Text = cls.Descontos.ToString("R$ 0.00") & " (" & cls.Desconto.ToString("0.00%") & ")"
        Else
            lblDesconto.Text = CDec(cls.Descontos * -1).ToString("R$ 0.00") & " (" & CDec(cls.Desconto * -1).ToString("0.00%") & ")"
            lblDescontoTitulo.Text = "Acrescimo:"
        End If
        lblForma.Text = cls.FormaPagamento
        lblNumero.Text = cls.NumeroPedido
        lblStatus.Text = cls.StatusPedido
        lblSubTotal.Text = cls.SubTotal.ToString("R$ 0.00")
        lblTotal.Text = cls.Total.ToString("R$ 0.00")
        lblVendedor.Text = cls.IDVendedor & " - " & cls.Vendedor
        lblObservacao.Text = cls.Observacao
        rowObservacao.Visible = (cls.Observacao <> "")
        rowPosicao.Visible = (cls.Latitude <> 0 Or cls.Longitude <> 0)
        rowMostraMapa.Visible = (cls.Latitude <> 0 Or cls.Longitude <> 0)
        lblLatitude.Text = cls.Latitude
        lblLongitude.Text = cls.Longitude
        If cls.Campanha.Length > 0 Then
            lblCampanha.Text = cls.Campanha
            lblCampanhaSeq.Text = cls.CampanhaSeq
        Else
            lblCampanha.Text = "(sem campanha)"
            lblCampanhaSeq.Text = "(nenhuma)"
        End If
        btnAprovar.Visible = CheckPermission("Detalhes do Pedido", "Aprovar Pedido")
        btnCancelar.Visible = CheckPermission("Detalhes do Pedido", "Cancelar Pedido")
        If cls.IdStatusPedido = cls._StatusPedido.EmTransito Then
            btnAprovar.Enabled = True
            btnCancelar.Enabled = True
        Else
            btnAprovar.Enabled = False
            btnCancelar.Enabled = False
        End If
    End Sub

    Private Sub btnAprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprovar.Click
        Response.Redirect("pedidoalterar.aspx?idPedido=" & Server.UrlEncode(sIDPedido) & "&Tipo=A")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("pedidoalterar.aspx?idPedido=" & Server.UrlEncode(sIDPedido) & "&Tipo=C")
    End Sub
End Class
