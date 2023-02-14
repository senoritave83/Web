
Public Class RelatorioObraExportar
    Inherits XMWebPage
    Protected WithEvents Link As System.Web.UI.WebControls.HyperLink

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


        Dim Pesq As New clsPesquisas
        ViewState("Obras") = Page.Request("O")

        Dim ds As DataSet = Pesq.RelatorioObraExportar(ViewState("Obras"))
        Dim strText As String = ""

        Dim i As Integer = 0
        If Not ds Is Nothing Then

            If ds.Tables.Count > 0 Then
                strText = ds.Tables(0).Rows(0).Item(0) & vbCrLf
            End If
            If ds.Tables.Count > 1 Then
                'strText &= ds.Tables(1).Rows(0).Item(0)
                Dim dr As DataRow
                Dim iRow As Integer = 0, iRows As Integer = ds.Tables(0).Rows.Count
                For Each dr In ds.Tables(1).Rows
                    strText &= dr(0) & vbCrLf
                Next
            End If

            Response.Clear()
            Response.ContentType = "text/plain"
            Response.AppendHeader("Content-Disposition", "attachment; filename=ITCOBRAS_" & Now().ToString("yyyyMMdd") & ".txt")

            Dim ms As New System.IO.MemoryStream
            Dim sr As New System.IO.StreamWriter(ms, System.Text.Encoding.Default)
            sr.Write(strText)
            sr.Flush()
            Response.OutputStream.Write(ms.GetBuffer, 0, ms.GetBuffer.Length)
            Response.OutputStream.Flush()
            Response.OutputStream.Close()

            ms = Nothing
            sr = Nothing

            Response.End()

        End If

        ds = Nothing
        Pesq = Nothing

    End Sub

End Class
