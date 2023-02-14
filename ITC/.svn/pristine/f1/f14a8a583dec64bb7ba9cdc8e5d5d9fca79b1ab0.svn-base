Public Class SaibaMais
    Inherits XMWebPage
    Protected WithEvents dtgSaibaMais As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAddSaibaMais As Button

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

            Dim SaibaMais As clsSaibaMais
            SaibaMais = New clsSaibaMais

            dtgSaibaMais.DataSource = SaibaMais.ListTodas()
            dtgSaibaMais.DataBind()

            IIf(CheckPermission("Cadastro de SaibaMais", "Adicionar"), btnAddSaibaMais.Visible = True, btnAddSaibaMais.Visible = False)

        End If

    End Sub

    Private Sub btnAddSaibaMaisClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSaibaMais.Click

        Response.Redirect("SaibaMaisDet.aspx?idSaibaMais=0")

    End Sub
End Class
