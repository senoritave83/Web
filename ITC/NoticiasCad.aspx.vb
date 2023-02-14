
Public Class NoticiasCad

    Inherits XMWebPage
    Protected WithEvents dtgNoticias As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnIncluir As Button

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

            Dim noticia As Noticia
            noticia = New Noticia()

            dtgNoticias.DataSource = noticia.UltimasNoticias(15)
            dtgNoticias.DataBind()

            IIf(CheckPermission("Cadastro de Noticias", "Adicionar"), btnIncluir.Visible = True, btnIncluir.Visible = False)

        End If

    End Sub

    Private Sub btnIncluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIncluir.Click

        Response.Redirect("noticiascaddet.aspx?idnoticia=0")

    End Sub
End Class
