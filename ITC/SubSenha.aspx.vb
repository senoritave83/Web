Public Class SubSenha

    Inherits XMWebPage

    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblNomeCadastroPrincipal As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigoCadastroPrincipal As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpresaCadastroPrincipal As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents BarraBotoes As BarraBotoes

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

            Dim objIdUsuario, objIdEmpresa, objIdUsuarioSubSenha As Object

            objIdUsuario = DeCryptography(Page.Request("Codigo"))
            If IsNumeric(objIdUsuario) Then
                ViewState("IdUsuario") = objIdUsuario
            Else
                ViewState("IdUsuario") = 0
            End If

            objIdEmpresa = DeCryptography(Page.Request("IdEmpresa"))
            If IsNumeric(objIdEmpresa) Then
                ViewState("IdEmpresa") = objIdEmpresa
            Else
                ViewState("IdEmpresa") = 0
            End If

            objIdUsuarioSubSenha = DeCryptography(Page.Request("ISS"))
            If IsNumeric(objIdUsuarioSubSenha) Then
                ViewState("IdUsuarioSubSenha") = objIdUsuarioSubSenha
            Else
                ViewState("IdUsuarioSubSenha") = 0
            End If

            Usuarios = New clsUsuario
            ViewState("IdUsuarioMaster") = Usuarios.IDUsuario
            ViewState("NomeUsuarioMaster") = Usuarios.Usuario
            ViewState("Empresa") = Usuarios.NomeEmpresa
            ViewState("IdEmpresa") = Usuarios.IdEmpresa

            Usuarios = New clsUsuario(ViewState("IdUsuarioSubSenha"), ViewState("IdEmpresa"))
            Inflate()

        Else

            Usuarios = New clsUsuario(ViewState("IdUsuarioSubSenha"), ViewState("IdEmpresa"))

        End If

    End Sub

    Sub Inflate()

        lblCodigoCadastroPrincipal.Text = ViewState("IdUsuarioMaster")
        lblNomeCadastroPrincipal.Text = ViewState("NomeUsuarioMaster")
        lblEmpresaCadastroPrincipal.Text = ViewState("Empresa")

        ViewState("IdUsuarioSubSenha") = Usuarios.IDUsuario
        lblCodigo.Text = ViewState("IdUsuarioSubSenha")
        txtNome.Text = Usuarios.Usuario
        txtLogin.Text = Usuarios.Login

    End Sub

    Sub Deflate()

        Usuarios.IDUsuarioMaster = ViewState("IdUsuarioMaster")
        Usuarios.IdEmpresa = ViewState("IdEmpresa")
        Usuarios.Usuario = txtNome.Text
        Usuarios.Login = txtLogin.Text

    End Sub

    Private Sub BarraBotoes_Gravar() Handles BarraBotoes.Atualizar

        Deflate()
        Usuarios.UpdateSubCadastro()
        Page.Response.Redirect("SubSenha.aspx?Codigo=" & ViewState("IdUsuarioMaster") & "&iss=" & Usuarios.IDUsuario)

    End Sub

    Private Sub BarraBotoes_Voltar() Handles BarraBotoes.Voltar

        Page.Response.Redirect("UsuariosDet.aspx?Codigo=" & ViewState("IdUsuarioMaster"))

    End Sub

End Class
