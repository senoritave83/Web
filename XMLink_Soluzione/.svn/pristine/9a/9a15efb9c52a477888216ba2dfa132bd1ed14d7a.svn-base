Imports System.Data.SqlClient

Public Class condicaodet
    Inherits XMProtectedPage
    Protected WithEvents txtCondicao As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCorrecao As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDCondicao As Integer
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lstVendedor As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected cls As clsCondicao


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
        cls = New clsCondicao(Me)
        If Not Page.IsPostBack Then
            intIDCondicao = CLng("0" & Request("IDCondicao"))
            If intIDCondicao = 0 Then
                tdCodigo.Visible = EditCodigos
            Else
                txtCodigo.Enabled = EditCodigos
            End If
            ViewState("IDCondicao") = intIDCondicao
            cls.Load(intIDCondicao)
            Inflate()
        Else
            intIDCondicao = CLng("0" & ViewState("IDCondicao"))
            cls.Load(intIDCondicao)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtCondicao.Text = .Condicao
            txtCorrecao.Text = .Correcao
            txtCodigo.Text = .Codigo
        End With
        If intIDCondicao = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Condições", "Alterar Condição"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Condições", "Adicionar Condição"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Condições", "Apagar Condição") And intIDCondicao > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Condições", "Alterar Condição"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Condicao = txtCondicao.Text
            .Correcao = txtCorrecao.Text
            .Codigo = txtCodigo.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Condicoes.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDCondicao = 0 And CheckPermission("Cadastro de Condições", "Adicionar Condição") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDCondicao > 0 And CheckPermission("Cadastro de Condições", "Alterar Condição") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDCondicao, txtCodigo.Text, txtCondicao.Text) Then
            ShowMsg("A condição de pagamento já existe! Por favor verifique o código e o nome da condição.")
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
        MostraGravado("Condicoes.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Condicaodet.aspx?idCondicao=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Condicoes.aspx")
    End Sub


End Class
