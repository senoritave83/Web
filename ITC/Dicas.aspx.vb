Public Class Dicas
    Inherits XMWebPage
    Protected WithEvents dtgDica As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAddDica As Button

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

            Dim Dica As Dica
            Dica = New Dica()

            dtgDica.DataSource = Dica.List(0)
            dtgDica.DataBind()

            IIf(CheckPermission("Cadastro de Dica", "Adicionar"), btnAddDica.Visible = True, btnAddDica.Visible = False)

        End If

    End Sub

    Private Sub btnAddDica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDica.Click

        Response.Redirect("DicasDet.aspx?idDica=0")

    End Sub
End Class
