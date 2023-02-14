Imports System.Data.SqlClient

Public Class categoriadet
    Inherits XMProtectedPage
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDCategoria As Integer
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected cls As clsCategoria

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
        cls = New clsCategoria(Me)
        If Not Page.IsPostBack Then
            intIDCategoria = CLng("0" & Request("IDCategoria"))
            If intIDCategoria = 0 Then
                tdCodigo.Visible = EditCodigos
            Else
                txtCodigo.Enabled = EditCodigos
            End If
            ViewState("IDCategoria") = intIDCategoria
            cls.Load(intIDCategoria)
            Inflate()
        Else
            intIDCategoria = CLng("0" & ViewState("IDCategoria"))
            cls.Load(intIDCategoria)
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            txtCodigo.Text = .Codigo
        End With
        If intIDCategoria = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Categorias", "Alterar Categoria"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Categorias", "Adicionar Categoria"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Categorias", "Apagar Categoria") And intIDCategoria > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Categorias", "Alterar Categoria"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Codigo = txtCodigo.Text
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Categorias.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDCategoria = 0 And CheckPermission("Cadastro de Categorias", "Adicionar Categoria") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDCategoria > 0 And CheckPermission("Cadastro de Categorias", "Alterar Categoria") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDCategoria, txtCodigo.Text, txtNome.Text) Then
            ShowMsg("A categoria já existe! Por favor verifique o código e o nome")
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
        MostraGravado("Categorias.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Categoriadet.aspx?idCategoria=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Categorias.aspx")
    End Sub


End Class
