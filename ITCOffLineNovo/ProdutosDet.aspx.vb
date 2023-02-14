Imports ITCOffLine

Public Class ProdutosDet

    Inherits XMWebPage
    Private Prod As clsProdutos

    Protected WithEvents txtProduto As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqTitulo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Barra As BarraBotoes2

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

            Dim objIdProduto As Object = DeCryptography(Request("p"))

            If IsNumeric(objIdProduto) Then
                ViewState("IdProduto") = objIdProduto
            Else
                ViewState("IdProduto") = 0
            End If

            Prod = New clsProdutos(ViewState("IdProduto"))
            Inflate()
            Prod = Nothing

            Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Produtos", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Produtos", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)

        End If

    End Sub

    Private Sub Inflate()
        txtProduto.Text = Prod.DescricaoProduto
    End Sub

    Private Sub Deflate()
        Prod.DescricaoProduto = txtProduto.Text
    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar

        Prod = New clsProdutos(ViewState("IdProduto"))
        Deflate()
        Prod.Update()
        Gravado("produtosdet.aspx?p=" & CryptographyEncoded(Prod.IdProduto))

    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("produtosdet.aspx")
    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("produtos.aspx")
    End Sub

End Class