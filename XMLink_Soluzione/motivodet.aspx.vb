Imports System.Data.SqlClient

Public Class motivodet
    Inherits XMProtectedPage
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDMotivo As Integer
    Protected cls As clsMotivo

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
        cls = New clsMotivo(Me)
        If Not Page.IsPostBack Then
            intIDMotivo = CLng("0" & Request("IDMotivo"))
            ViewState("IDMotivo") = intIDMotivo
            cls.Load(intIDMotivo)
            Inflate()
        Else
            intIDMotivo = CLng("0" & ViewState("IDMotivo"))
            cls.Load(intIDMotivo)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtMotivo.Text = .Motivo
        End With
        If intIDMotivo = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Motivos", "Alterar Motivo"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Motivos", "Adicionar Motivo"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Motivos", "Apagar Motivo") And intIDMotivo > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Motivos", "Alterar Motivo"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Motivo = txtMotivo.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("motivos.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDMotivo = 0 And CheckPermission("Cadastro de Motivos", "Adicionar Motivo") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDMotivo > 0 And CheckPermission("Cadastro de Motivos", "Alterar Motivo") = False Then
            ShowMsg("Permissão Negada")
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
        MostraGravado("motivos.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("motivodet.aspx?idmotivo=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("motivos.aspx")
    End Sub


End Class
