Imports System.Data.SqlClient

Public Class produtodet
    Inherits XMProtectedPage
    Protected WithEvents valtxtCodigo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents valtxtDescricao As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valComEstoque As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtEstoque As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtPrecoUnitario As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents cboCategoria As ComboBox
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDProduto As Integer
    Protected cls As clsProdutos

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
        cls = New clsProdutos(Me)
        If Not Page.IsPostBack Then
            Dim cat As New clsCategoria(Me)
            cboCategoria.DataSource = cat.Listar
            cboCategoria.DataBind()
            cat = Nothing

            intIDProduto = CLng("0" & Request("IDProduto"))
            ViewState("IDProduto") = intIDProduto
            cls.Load(intIDProduto)
            Inflate()
        Else
            intIDProduto = CLng("0" & ViewState("IDProduto"))
            cls.Load(intIDProduto)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtCodigo.Text = .Codigo
            txtDescricao.Text = .Descricao
            txtEstoque.Text = .Estoque
            txtPrecoUnitario.Text = .PrecoUnitario.ToString("#0.00")
            cboCategoria.Value = .IDCategoria
        End With
        If intIDProduto = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Produtos", "Alterar Produto"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Produtos", "Adicionar Produto"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Produtos", "Apagar Produto"), BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Produtos", "Alterar Produto"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Codigo = txtCodigo.Text
            .Descricao = txtDescricao.Text
            .Estoque = txtEstoque.Text
            .PrecoUnitario = txtPrecoUnitario.Text
            .IDCategoria = cboCategoria.Value
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Produtos.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDProduto = 0 And CheckPermission("Cadastro de Produtos", "Adicionar Produto") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDProduto > 0 And CheckPermission("Cadastro de Produtos", "Alterar Produto") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDProduto, txtCodigo.Text) Then
            ShowMsg("O Produto já existe!")
            Exit Sub
        End If
        Deflate()
        Try
            cls.Update()
        Catch e As SqlException
            If e.Number = 50000 Then
                ShowError(e.Message)
                Exit Sub
            Else
                Throw e
            End If
        End Try
        MostraGravado("Produtodet.aspx?idProduto=" & cls.IDProduto)
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Produtodet.aspx?idproduto=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Produtos.aspx")
    End Sub

End Class
