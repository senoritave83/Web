Imports ITCOffLine

Public Class CartaAgradecimento

    Inherits XMWebPage
    'Protected WithEvents Tudo As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents lblAC As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents divRegistros As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    'Protected WithEvents Tudo As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents Falha As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents divRegistros As System.Web.UI.HtmlControls.HtmlGenericControl

    'Private Obras As clsObras

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

            'ViewState("IDUsuario") = Usuario.IDUsuario
            'ViewState("IDEmpresa") = Usuario.IdEmpresa

        End If

    End Sub
End Class

