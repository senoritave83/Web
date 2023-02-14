Public Class AnaliseMensal
    Inherits XMWebPage
    Protected WithEvents dtgAnalise As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAddAnaliseMensal As Button

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

            Dim AnaliseMensal As clsAnaliseMensal
            AnaliseMensal = New clsAnaliseMensal

            dtgAnalise.DataSource = AnaliseMensal.ListTodas()
            dtgAnalise.DataBind()

            IIf(CheckPermission("Cadastro de Analise", "Adicionar"), btnAddAnaliseMensal.Visible = True, btnAddAnaliseMensal.Visible = False)

        End If

    End Sub

    Private Sub btnAddAnaliseMensalClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddAnaliseMensal.Click

        Response.Redirect("AnaliseMensalDet.aspx?IdAnalise=0")

    End Sub
End Class
