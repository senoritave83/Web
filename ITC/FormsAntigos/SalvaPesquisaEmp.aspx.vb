Public Class SalvarPesquisaEmp

    Inherits XMWebPage
    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents btnSalvarPesquisa As System.Web.UI.WebControls.Button
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox

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
            ViewState("IdPesquisa") = CInt(0 & Page.Request("IdPesquisa"))
            ViewState("Atividades") = Page.Request("A")
            ViewState("Estados") = Page.Request("E")
        End If
    End Sub



    'Private Sub btnSalvarPesquisa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvarPesquisa.Click

    '    Dim Pesq As New clsPesquisas()
    '    Response.Redirect("PesquisaEmpresas.aspx?IdPesquisa=" & Pesq.SalvarPesquisaEmpresa(ViewState("IdPesquisa"), Usuario.IDUsuario, ViewState("Estados"), ViewState("Atividades"), txtNome.Text, ViewState("")))

    'End Sub

End Class
