Public Class UsuariosDet

    Inherits XMWebPage

    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAlterarSenha As Button
    Protected WithEvents btnRedefinirSenha As Button
    Protected WithEvents btnVoltar As Button
    Protected WithEvents ltJavaScriptAlteraSenha As System.Web.UI.WebControls.Literal
    Protected WithEvents cboTipoUsuario As ComboBox
    Protected WithEvents cboIdSituacao As ComboBox
    Protected WithEvents cboIdCargo As ComboBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator

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

            If ViewState("IdUsuario") > 0 Then
                btnAlterarSenha.Enabled = True
            Else
                btnAlterarSenha.Enabled = False
            End If

            With cboTipoUsuario
                .CssClass = "f8"
                .CssClassValidator = "f8"
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

        Else

            Usuarios = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))

        End If

        'Componentes desabilitados
        cboIdCargo.Enabled = False
        cboIdSituacao.Enabled = False
        cboTipoUsuario.Enabled = False

    End Sub

    Private Sub Inflate()

        With Usuarios
            txtNome.Text = .Usuario
            txtLogin.Text = .Login
            txtEmpresa.Text = .NomeEmpresa
            txtEmail.Text = .Email
            cboTipoUsuario.Value = .IdTipoUsuario
            cboIdSituacao.Value = .IdSituacao
            cboIdCargo.Value = .IDCargo
        End With

    End Sub

    Private Sub Deflate()

        With Usuarios
            .Usuario = txtNome.Text
            .Login = txtLogin.Text
            .Email = txtEmail.Text
            .NomeEmpresa = txtEmpresa.Text
            .IdEmpresa = ViewState("IdAssociado")
            .IdSituacao = cboIdSituacao.Value
            .IdTipoUsuario = cboTipoUsuario.Value
            .IDCargo = cboIdCargo.Value
        End With

    End Sub

    Private Function AlteraSenha(ByVal p_IdUsuario As Integer)

        Return Usuarios.AlterarSenha(p_IdUsuario)

    End Function

    Private Function AlteraSenha(ByVal p_IdUsuario As Integer, ByVal Senha As String)

        Return Usuarios.AlterarSenha(p_IdUsuario, Senha)

    End Function

    Private Sub btnAlterarSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterarSenha.Click

        Try

            AlteraSenha(ViewState("IdUsuario"))
            Dim strJava As String = ""
            strJava += "<script language=javascript>" & vbCrLf
            strJava += "alert('Senha alterada com sucesso. No próximo login o usuário deverá alterar sua senha.');" & vbCrLf
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

    Private Sub btnRedefinirSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRedefinirSenha.Click
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

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))

    End Sub
End Class
