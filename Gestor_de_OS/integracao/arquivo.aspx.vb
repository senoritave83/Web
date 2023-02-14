
Partial Class integracao_arquivo
    Inherits XMProtectedPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsIntegracao
        Dim strArquivo As String = "" & Request("file")
        Dim strText As String = ""
        If strArquivo.StartsWith(Identity.IDEmpresa & "_") And strArquivo.EndsWith(".txt") Then
            If IO.File.Exists(cls.GetPath() & strArquivo) Then
                Dim strFile As New IO.StreamReader(cls.GetPath() & strArquivo)
                strText = strFile.ReadToEnd()
                strFile.Close()

                Response.Clear()
                Response.AppendHeader("Content-Type", "text/html; charset=iso-8859-1")
                Response.AddHeader("Content-Disposition", "attachment; filename=" & strArquivo)
                'Response.AddHeader("Content-Length", strText.Length)
                Response.ContentType = "text/plain"
                Response.Write(strText)
                Response.End()

            End If
        End If
    End Sub
End Class
