Imports System.Data.SqlClient

Public Class formapagamentodet
    Inherits XMProtectedPage
    Protected WithEvents txtForma As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCorrecao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDFormaPagamento As Integer
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lstVendedor As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected cls As clsFormaPagamento


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
        cls = New clsFormaPagamento(Me)
        If Not Page.IsPostBack Then
            intIDFormaPagamento = CLng("0" & Request("IDFormaPagamento"))
            If intIDFormaPagamento = 0 Then
                tdCodigo.Visible = EditCodigos
            Else
                txtCodigo.Enabled = EditCodigos
            End If
            ViewState("IDFormaPagamento") = intIDFormaPagamento
            cls.Load(intIDFormaPagamento)
            Inflate()
        Else
            intIDFormaPagamento = CLng("0" & ViewState("IDFormaPagamento"))
            cls.Load(intIDFormaPagamento)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtForma.Text = .FormaPagamento
            txtCorrecao.Text = .Correcao
            txtCodigo.Text = .Codigo
        End With
        If intIDFormaPagamento = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Formas de Pagamento", "Alterar Forma de Pagamento"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Formas de Pagamento", "Adicionar Forma de Pagamento"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Formas de Pagamento", "Apagar Forma de Pagamento") And intIDFormaPagamento > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Formas de Pagamento", "Alterar Forma de Pagamento"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .FormaPagamento = txtForma.Text
            .Correcao = txtCorrecao.Text
            .Codigo = txtCodigo.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("formapagamento.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDFormaPagamento = 0 And CheckPermission("Cadastro de Formas de Pagamento", "Adicionar Forma de Pagamento") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDFormaPagamento > 0 And CheckPermission("Cadastro de Formas de Pagamento", "Alterar Forma de Pagamento") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDFormaPagamento, txtCodigo.Text, txtForma.Text) Then
            ShowMsg("A forma de pagamento já existe! Por favor verifique o código e o nome da forma de pagamento.")
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
        MostraGravado("formapagamento.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("formapagamentodet.aspx?idFormaPagamento=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("formapagamento.aspx")
    End Sub


End Class
