Public MustInherit Class Bloco4

    Inherits System.Web.UI.UserControl
    Protected WithEvents imgIndice As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents lblDescricaoIndice As System.Web.UI.WebControls.Label

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

        Dim ind As New Indices(1)
        imgIndice.Src = "../imagensindices/" & ind.NomeImagem
        lblDescricaoIndice.Text = ind.Descricao
        ind = Nothing

    End Sub

End Class
