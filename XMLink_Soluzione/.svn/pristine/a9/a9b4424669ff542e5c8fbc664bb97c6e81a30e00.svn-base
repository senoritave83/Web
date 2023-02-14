Public Class exportacaodet
    Inherits XMProtectedPage

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
        'Put user code to initialize the page here
        Dim strText As String
        Dim imp As New clsImportacao(Me)
        strText = imp.ExportarArquivo(CInt("0" & Request("IDTipo")))
        Response.Clear()
        Response.AddHeader("Content-Disposition", "attachment; filename=ped_" & Now().ToString("yyyyMMdd-hhmmss") & ".txt")
        Response.AddHeader("Content-Length", strText.Length)
        Response.ContentType = "application/octet-stream"
        Response.Write(strText)
        Response.End()
        imp = Nothing
    End Sub

End Class
