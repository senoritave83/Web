Public Class Permissaodet
    Inherits XMProtectedPage
    Protected WithEvents valMensagem As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents lstUsuarios As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lstSecoes As System.Web.UI.WebControls.DataList
    Protected WithEvents BarraBotoes1 As BarraBotoes
    Protected cls As clsPermissoes
    Protected intIDPermissao As Integer

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
        cls = New clsPermissoes(Me)
        If Not Page.IsPostBack Then
            intIDPermissao = CLng("0" & Request("IDPermissao"))
            ViewState("IDPermissao") = intIDPermissao
            cls.Load(intIDPermissao)
            CarregaUsuarios()
            BindGrid()
            Inflate()
        Else
            intIDPermissao = CLng("0" & ViewState("IDPermissao"))
            cls.Load(intIDPermissao)
        End If
    End Sub

    Private Sub BindGrid()
        lstSecoes.DataSource = cls.ListarSecoes
        lstSecoes.DataBind()
    End Sub

    Private Sub CarregaUsuarios()
        lstUsuarios.Items.Clear()
        Dim ds As DataSet
        ds = cls.ListarUsuarios
        Dim i As Integer
        Dim li As ListItem
        With ds.Tables(0).Rows
            For i = 0 To .Count - 1
                li = New ListItem(.Item(i).Item("usu_Usuario_chr"), .Item(i).Item("usu_Usuario_int_PK"))
                li.Selected = .Item(i).Item("selected")
                lstUsuarios.Items.Add(li)
            Next
        End With
    End Sub


    Protected Sub Inflate()
        With cls
            txtNome.Text = .Nome
        End With
        If intIDPermissao = 0 Then
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Permissões", "Alterar Permissão"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        Else
            BarraBotoes1.AtivarBotoes(IIf(CheckPermission("Cadastro de Permissões", "Adicionar Permissão"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Permissões", "Apagar Permissão") And intIDPermissao > 1, BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Cadastro de Permissões", "Alterar Permissão"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        End If
    End Sub

    Protected Sub Deflate()
        With cls
            .Nome = txtNome.Text
            .Usuarios.Clear()
            Dim i As Integer
            For i = 0 To lstUsuarios.Items.Count - 1
                If lstUsuarios.Items(i).Selected Then .Usuarios.Add(lstUsuarios.Items(i).Value)
            Next
            .Acoes = Request("chkAcoes")
        End With
    End Sub

    Private Sub BarraBotoes1_Excluir() Handles BarraBotoes1.Excluir
        cls.Delete()
        Response.Redirect("Permissoes.aspx")
    End Sub

    Protected Function ListarAcoes(ByVal vSecao As String) As DataSet
        Return cls.ListarPermissaoAcoes(vSecao)
    End Function

    Private Sub BarraBotoes1_Atualizar() Handles BarraBotoes1.Atualizar
        If intIDPermissao = 0 And CheckPermission("Cadastro de Permissões", "Adicionar Permissão") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If intIDPermissao > 0 And CheckPermission("Cadastro de Permissões", "Alterar Permissão") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        Deflate()
        Try
            cls.Update()
        Catch e As System.Data.SqlClient.SqlException
            If e.Number = 50000 Then
                ShowError(e.Message)
                Exit Sub
            Else
                Throw e
            End If
        End Try
        MostraGravado("Permissoes.aspx")
    End Sub

    Private Sub BarraBotoes1_Incluir() Handles BarraBotoes1.Incluir
        Response.Redirect("Permissaodet.aspx?idPermissao=0")
    End Sub

    Private Sub BarraBotoes1_Voltar() Handles BarraBotoes1.Voltar
        Response.Redirect("Permissoes.aspx")
    End Sub


End Class
