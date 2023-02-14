Imports System.Data.SqlClient

Public Class usuariodet
    Inherits XMProtectedPage
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected intIDUsuario As Integer
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkAdmin As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlAcesso As System.Web.UI.WebControls.Panel
    Protected WithEvents lstPermissoes As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents velReqNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents rowPermissoes As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lstGrupo As System.Web.UI.WebControls.CheckBoxList
    Protected cls As clsUsuario

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
        cls = New clsUsuario(Me)
        If Not Page.IsPostBack Then

            If Not CheckPermission("Cadastro de Usuarios", "Visualizar") Then Response.Redirect("Principal.aspx")

            intIDUsuario = CLng("0" & Request("IDUsuario"))
            ViewState("IDUsuario") = intIDUsuario
            cls.Load(intIDUsuario)
            CarregaPermissoes()
            btnLogin.Enabled = CheckPermission("Cadastro de Usuarios", "Editar Dados de Acesso")
            Inflate()
        Else
            intIDUsuario = CLng("0" & ViewState("IDUsuario"))
            cls.Load(intIDUsuario)
        End If
    End Sub

    Private Sub CarregaPermissoes()
        lstPermissoes.Items.Clear()
        Dim ds As DataSet
        ds = cls.ListarPermissoes
        Dim i As Integer
        Dim li As ListItem
        With ds.Tables(0).Rows
            For i = 0 To .Count - 1
                li = New ListItem(.Item(i).Item("per_Permissao_chr"), .Item(i).Item("per_Permissao_int_PK"))
                li.Selected = .Item(i).Item("selected")
                lstPermissoes.Items.Add(li)
            Next
        End With
    End Sub

    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
            chkAdmin.Checked = .Administrador
            txtLogin.Text = .Login
        End With
        If cls.IDVendedor = 0 Then
            If intIDUsuario = 0 Then
                BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Usuarios", "Alterar Usuario"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
            Else
                BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Usuarios", "Adicionar Usuario"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Usuarios", "Apagar Usuario") And intIDUsuario > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Usuarios", "Alterar Usuario"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
            End If
            rowPermissoes.Visible = CheckPermission("Cadastro de Usuarios", "Conceder Permissões")
        Else
            rowPermissoes.Visible = False
            BarraBotoes1.AtivarBotoes(BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Administrador = chkAdmin.Checked
            If pnlAcesso.Visible = True Then
                .Login = txtLogin.Text
            End If
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Usuarios.aspx")
    End Sub

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDUsuario = 0 And CheckPermission("Cadastro de Usuarios", "Adicionar Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDUsuario > 0 And CheckPermission("Cadastro de Usuarios", "Alterar Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If cls.Existe(intIDUsuario, txtNome.Text, txtLogin.Text, txtSenha.Text) Then
            ShowMsg("O login escolhido já existe! Favor escolher outro!")
            Exit Sub
        End If
        Deflate()
        Try
            cls.Update()
            If pnlAcesso.Visible = True And txtSenha.Text <> "" Then
                cls.AlteraSenha(txtSenha.Text)
                pnlAcesso.Visible = False
            End If
            If CheckPermission("Cadastro de Usuarios", "Conceder Permissões") Then
                cls.Permissoes.Clear()
                Dim i As Integer
                For i = 0 To lstPermissoes.Items.Count - 1
                    If lstPermissoes.Items(i).Selected Then cls.Permissoes.Add(lstPermissoes.Items(i).Value)
                Next
                cls.SavePermissoes()
            End If
        Catch e As SqlException
            If e.Number = 50000 Then
                ShowError(e.Message)
                Exit Sub
            Else
                Throw e
            End If
        End Try
        MostraGravado("Usuarios.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Usuariodet.aspx?idUsuario=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Usuarios.aspx")
    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        pnlAcesso.Visible = Not pnlAcesso.Visible
    End Sub
End Class
