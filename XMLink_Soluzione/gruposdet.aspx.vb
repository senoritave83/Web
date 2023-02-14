Imports System.Data.SqlClient

Public Class gruposdet
    Inherits XMProtectedPage
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDGrupo As Integer
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected cls As clsGrupos
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
        cls = New clsGrupos(Me)
        If Not Page.IsPostBack Then
            intIDGrupo = CLng("0" & Request("IDGrupo"))
            ViewState("IDGrupo") = intIDGrupo
            cls.Load(intIDGrupo)
            Inflate()
        Else
            intIDGrupo = CLng("0" & ViewState("IDGrupo"))
            cls.Load(intIDGrupo)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
        End With
        If intIDGrupo = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Grupos", "Alterar Grupo"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Grupos", "Adicionar Grupo"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Grupos", "Apagar Grupo") And intIDGrupo > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Grupos", "Alterar Grupo"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Grupos.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDGrupo = 0 And CheckPermission("Cadastro de Grupos", "Adicionar Grupo") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDGrupo > 0 And CheckPermission("Cadastro de Grupos", "Alterar Grupo") = False Then
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
        MostraGravado("Grupos.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Gruposdet.aspx?idGrupo=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Grupos.aspx")
    End Sub

End Class
