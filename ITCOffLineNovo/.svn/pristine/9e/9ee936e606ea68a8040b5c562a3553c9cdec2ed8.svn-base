Imports ITCOffLine

Public Class UsuariosDet

    Inherits XMWebPage

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPermissoesGestor As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lblArea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblGestor As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblGestorCbo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Especifico As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As TextBox
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnNovaSubSenha As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnRedefinirSenha As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPermissoes As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnGravar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPermissaoGestor As ImageButton
    Protected WithEvents ltJavaScriptAlteraSenha As System.Web.UI.WebControls.Literal
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents cboTipoUsuario As ComboBox
    Protected WithEvents cboIdSituacao As ComboBox
    Protected WithEvents cboIdCargo As ComboBox
    Protected WithEvents cboGestor As ComboBox
    Protected WithEvents cboArea As ComboBox
    Protected WithEvents lblMensagem As Label

    Private Usuarios As clsUsuario

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

            Dim p_IdAssociado As Integer = 0
            Dim objIdAssociado As Object = DeCryptography(Page.Request("IdAssociado"))
            If IsNumeric(objIdAssociado) Then
                p_IdAssociado = objIdAssociado
            End If
            ViewState("IdAssociado") = p_IdAssociado

            Dim p_IdUsuario As Integer = 0
            Dim objIdUsuario As Object = DeCryptography(Page.Request("Codigo"))
            If IsNumeric(objIdUsuario) Then
                p_IdUsuario = objIdUsuario
            Else
                p_IdUsuario = 0
            End If
            ViewState("IdUsuario") = p_IdUsuario

            With cboTipoUsuario
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(0, "Selecione...")
                .AddItem(1, "Usuário Master")
                .AddItem(2, "Sub-Usuário")
                .AddItem(3, "Vendedor")
                .AddItem(4, "Gestor")
            End With

            With cboIdSituacao
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(1, "Ativo")
                .AddItem(0, "Inativo")
            End With

            Dim Cargos As New clsCargos(Me)
            With cboIdCargo
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Cargos.List
                .DataTextField = "DESCRICAOCARGO"
                .DataValueField = "IDCARGO"
                .DataBind()
            End With

            Usuarios = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
            Inflate()

            BindGrid()

            'btnGravar.Visible = (CheckPermission("Usuário de Associado", "Atualizar Permissões") And ViewState("IdUsuario") <> 0)

        Else

            Usuarios = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))

        End If

    End Sub

    Private Sub Inflate()

        With Usuarios
            txtNome.Text = .Usuario
            txtLogin.Text = .Login
            txtEmpresa.Text = .NomeEmpresa
            txtEmail.Text = .Email
            cboTipoUsuario.Value = .IdTipoUsuario
            cboIdSituacao.Value = .IdSituacao
            setaCombosAreaGestor()
            cboGestor.Value = .IdGestor
            cboIdCargo.Value = .IDCargo
        End With


        If ViewState("IdUsuario") > 0 Then
            Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Usuários", "Incluir Usuário"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Usuários", "Gravar Usuário"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Usuários", "Apagar Usuário"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            btnPermissoes.Enabled = CheckPermission("Cadastro de Usuários", "Cadastrar Permissões")
        Else
            Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Usuários", "Gravar Usuário"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            btnPermissoes.Enabled = False
        End If

    End Sub

    Private Sub Deflate()

        With Usuarios
            .Usuario = txtNome.Text
            .Login = txtLogin.Text
            .NomeEmpresa = txtEmpresa.Text
            .Email = txtEmail.Text
            .IdEmpresa = ViewState("IdAssociado")
            .IdSituacao = cboIdSituacao.Value
            .IdTipoUsuario = cboTipoUsuario.Value
            .IdGestor = cboGestor.Value
            .IDCargo = cboIdCargo.Value
        End With

    End Sub

    Private Sub BindGrid()
        dtgGrid.DataSource = Usuarios.ListPermissoes(ViewState("IdUsuario"))
        dtgGrid.DataBind()
    End Sub

    Private Function AlteraSenha(ByVal p_IdUsuario As Integer)

        Return Usuarios.AlterarSenha(p_IdUsuario)

    End Function

    Private Function AlteraSenha(ByVal p_IdUsuario As Integer, ByVal Senha As String)

        Return Usuarios.AlterarSenha(p_IdUsuario, Senha)

    End Function

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("usuariosdet.aspx?codigo=" & CryptographyEncoded("0") & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar

        Usuarios = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
        Deflate()
        Dim intRetorno As Integer = Usuarios.Update()
        Select Case intRetorno
            Case 1
                Gravado("usuariosdet.aspx?codigo=" & CryptographyEncoded(Usuarios.IDUsuario) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))
            Case 2
                lblMensagem.Text = "Ocorreram erros na gravação Se o problema persistir, entre em contato com o administrador do sistema"
            Case 3
                lblMensagem.Text = "O usuário já existe."
        End Select

        Usuarios = Nothing

    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub btnNovaSubSenha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovaSubSenha.Click
        Page.Response.Redirect("subsenha.aspx?codigo=" & CryptographyEncoded(ViewState("IdUsuario")) & "&idempresa=" & CryptographyEncoded(ViewState("IdAssociado")) & "&iss=0")
    End Sub

    Private Sub btnPermissoes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPermissoes.Click
        Page.Response.Redirect("usuariopermissao.aspx?codigo=" & CryptographyEncoded(ViewState("IdUsuario")) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub BarraBotoes_Excluir() Handles Barra.Excluir
        Usuarios.ApagarUsuarioAssociado(ViewState("IdAssociado"), ViewState("IdUsuario"))
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub


    Private Sub btnRedefinirSenha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRedefinirSenha.Click
        Try
            AlteraSenha(ViewState("IdUsuario"), "itc")
            Dim strJava As String = ""
            strJava += "<script language=javascript>" & vbCrLf
            strJava += "alert('Senha redefinida com sucesso ');" & vbCrLf
            strJava += "document.location.href='usuariosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdUsuario")) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")) & "';" & vbCrLf
            strJava += "</script>" & vbCrLf
            ltJavaScriptAlteraSenha.Text = strJava

        Catch ex As Exception

            Dim strJava As String = ""
            strJava += "<script language=javascript>" & vbCrLf
            strJava += "alert('Não foi possível alterar a senha ?');" & vbCrLf
            strJava += "document.location.href='usuariosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdUsuario")) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")) & "';" & vbCrLf
            strJava += "</script>" & vbCrLf
            ltJavaScriptAlteraSenha.Text = strJava

        End Try

    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGravar.Click
        Dim strPermissoes As String = ""
        Dim i As Integer
        For i = 0 To dtgGrid.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtgGrid.Items(i).FindControl("chkPermissao")
            If CurrentCheckBox.Checked Then
                If strPermissoes.Trim <> "" Then
                    strPermissoes += ","
                End If
                strPermissoes += dtgGrid.DataKeys.Item(dtgGrid.Items(i).ItemIndex).ToString()
            End If
        Next
        Usuarios = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
        Usuarios.SavePermissoes(strPermissoes, ViewState("IdUsuario"))
        BindGrid()
        Usuarios = Nothing
    End Sub

    Private Sub cboTipoUsuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoUsuario.SelectedIndexChanged

        setaCombosAreaGestor()

    End Sub

    Private Sub setaCombosAreaGestor()

        If cboTipoUsuario.Value = clsUsuario.TipoUsuario.Gestor Then

            Especifico.Visible = False
            lblGestor.Visible = False
            lblGestorCbo.Visible = False

            btnPermissaoGestor.Visible = True

        ElseIf cboTipoUsuario.Value = clsUsuario.TipoUsuario.SubUsuario Or _
        cboTipoUsuario.Value = clsUsuario.TipoUsuario.Vendedor Then

            Especifico.Visible = True
            btnPermissaoGestor.Visible = False

            lblGestor.Visible = True
            lblGestorCbo.Visible = True

            With cboGestor
                .EnableValidation = False
                .DataTextField = "NomeGestor"
                .DataValueField = "IdGestor"
                .DataSource = Usuarios.SelecionaGestores(ViewState("IdAssociado"), ViewState("IdUsuario"))
                .DataBind()
            End With

        ElseIf cboTipoUsuario.Value = clsUsuario.TipoUsuario.Master Or cboTipoUsuario.Value = 0 Then

            Especifico.Visible = False

        End If

    End Sub

    Private Sub btnPermissaoGestor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPermissaoGestor.Click

        Page.Response.Redirect("PermissaoRegiaoGestor.aspx?IdAssociado=" & CryptographyEncoded(ViewState("IdAssociado")) & "&IdGestor=" & CryptographyEncoded(ViewState("IdUsuario")))

    End Sub
End Class
