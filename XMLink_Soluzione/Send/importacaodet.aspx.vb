Public Class importacaodet
    Inherits XMWebPage
    Protected WithEvents file1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected strFiles As String
    Protected cls As clsImportacao

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


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log("Processando pagina")
        cls = New clsImportacao(Me)
        Dim f, s As String
        Dim file As HttpPostedFile
        Log("Verificando Arquivos")
        For Each f In Request.Files.AllKeys
            file = Request.Files(f)
            Log(file.FileName)
            file.SaveAs(cls.GetPath() & Request("file"))
            Log("Arquivo salvo")
            Response.Write("File:" & file.FileName)
            Log("Finalizando Request" & vbCrLf)
            Response.End()
            Exit For
        Next f
        Log("Fim")
    End Sub
End Class
