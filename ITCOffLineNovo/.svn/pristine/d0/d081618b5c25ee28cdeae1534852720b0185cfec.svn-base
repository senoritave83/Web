Imports ITCOffLine

Public Class FormularioPedido
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFantasia As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents lblCnpj As System.Web.UI.WebControls.Label
    Protected WithEvents lblIE As System.Web.UI.WebControls.Label
    Protected WithEvents lblRamo As System.Web.UI.WebControls.Label
    Protected WithEvents lblAtividade As System.Web.UI.WebControls.Label
    Protected WithEvents lblPrimeiroContrato As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelefone As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato As System.Web.UI.WebControls.Label
    Protected WithEvents lblFone As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmailContato As System.Web.UI.WebControls.Label
    Protected WithEvents lblCelular As System.Web.UI.WebControls.Label
    Protected WithEvents lblEnderecoEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblCepEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblBairroEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblCidadeEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblUfEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelefoneEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblFaxEntrega As System.Web.UI.WebControls.Label
    Protected WithEvents lblEnderecoCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblCepCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblBairroCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblCidadeCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblUfCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelefoneCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblFaxCobranca As System.Web.UI.WebControls.Label
    Protected WithEvents lblBairroFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblCidadeFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblUfFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelefoneFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblFaxFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSite As System.Web.UI.WebControls.Label
    Protected WithEvents lblFax As System.Web.UI.WebControls.Label
    Protected WithEvents lblCepFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblEnderecoFaturamento As System.Web.UI.WebControls.Label
    Protected WithEvents dtgPlanos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblVencimento As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalPedido As System.Web.UI.WebControls.Label
    Protected WithEvents lblPosicao As System.Web.UI.WebControls.Label
    Protected WithEvents lblVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataPedido As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumeroPedido As System.Web.UI.WebControls.Label
    Protected WithEvents lblProdutos As System.Web.UI.WebControls.Label
    Protected WithEvents lblObservacao As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private Pedidos As clsPedidos


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then

            ViewState("IdPedido") = Request("idpedido")
            If Request("email") = "1" Then ViewState("IdPedido") = Server.UrlDecode(ViewState("IdPedido"))
            ViewState("IdTipoPedido") = Request("idtipopedido")
            Inflate(DeCryptography(ViewState("IdPedido")))

        End If
    End Sub

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Private Sub Inflate(ByVal vIDPedido As Integer)

        Pedidos = New clsPedidos(vIDPedido)
        'Pedidos.ListFormularioPedido(vIDPedido)

        With Pedidos
            lblFantasia.Text = Server.HtmlEncode(.Fantasia)
            lblCodigo.Text = .Codigo
            lblRazaoSocial.Text = Server.HtmlEncode(.RazaoSocial)
            lblCnpj.Text = .CNPJ
            lblIE.Text = .InscricaoEstadual
            lblRamo.Text = Server.HtmlEncode(.Ramo)
            lblAtividade.Text = Server.HtmlEncode(.Atividade)
            lblPrimeiroContrato.Text = .PrimeiroContrato
            lblEmail.Text = Server.HtmlEncode(.EMail)
            lblTelefone.Text = .Telefone
            lblContato.Text = Server.HtmlEncode(.Contato)
            lblFone.Text = .Fone
            lblEmailContato.Text = Server.HtmlEncode(.EmailContato)
            lblCelular.Text = .Celular
            lblEnderecoEntrega.Text = Server.HtmlEncode(.Endereco)
            lblCepEntrega.Text = .CEP
            lblBairroEntrega.Text = Server.HtmlEncode(.Complemento)
            lblCidadeEntrega.Text = Server.HtmlEncode(.Cidade)
            lblUfEntrega.Text = Server.HtmlEncode(.UFEntrega)
            lblTelefoneEntrega.Text = .TelefoneEntrega
            lblFaxEntrega.Text = .FaxEntrega
            lblEnderecoCobranca.Text = Server.HtmlEncode(.EnderecoCobranca)
            lblCepCobranca.Text = .CEPCobranca
            lblBairroCobranca.Text = Server.HtmlEncode(.ComplementoCobranca)
            lblCidadeCobranca.Text = Server.HtmlEncode(.CidadeCobranca)
            lblUfCobranca.Text = Server.HtmlEncode(.UFCobranca)
            lblTelefoneCobranca.Text = .TelefoneCobranca
            lblFaxCobranca.Text = .FaxCobranca
            lblBairroFaturamento.Text = Server.HtmlEncode(.ComplementoFaturamento)
            lblCidadeFaturamento.Text = Server.HtmlEncode(.CidadeFaturamento)
            lblUfFaturamento.Text = Server.HtmlEncode(.UFFaturamento)
            lblTelefoneFaturamento.Text = .TelefoneFaturamento
            lblFaxFaturamento.Text = .FaxFaturamento
            lblSite.Text = Server.HtmlEncode(.WebSite)
            lblFax.Text = .Fax
            lblCepFaturamento.Text = .CEPFaturamento
            lblEnderecoFaturamento.Text = Server.HtmlEncode(.EnderecoFaturamento)
            If .PrimeiroVencimento <> "01/01/1900" Then
                lblVencimento.Text = .PrimeiroVencimento
            End If
            lblTotalPedido.Text = FormatNumber(.PedidoRS, 2)
            lblPosicao.Text = Server.HtmlEncode(.Posicao)
            lblObservacao.Text = Replace(Server.HtmlEncode(.Observacoes), vbCrLf, "</br>")
            lblVendedor.Text = Server.HtmlEncode(.Vendedor)
            lblDataPedido.Text = .DataPedido
            lblNumeroPedido.Text = .NumeroPedido
            lblProdutos.Text = Replace(Server.HtmlEncode(.Produtos), vbCrLf, "</br>")

            BindContatosPedido()
            BindPlanosPedidos()
        End With

    End Sub

    Private Sub BindContatosPedido()
        Dim clsPedidos As New clsContatoAssociados
        dtgContatos.DataSource = clsPedidos.ListContatosPedido(DeCryptography(ViewState("IdPedido")))
        dtgContatos.DataBind()
        clsPedidos = Nothing
    End Sub

    Private Sub BindPlanosPedidos()
        Dim Planos As New clsPedidoPlanos
        dtgPlanos.DataSource = Planos.ListPedidoItem(DeCryptography(ViewState("IdPedido")))
        dtgPlanos.DataBind()
        Planos = Nothing
    End Sub

End Class
