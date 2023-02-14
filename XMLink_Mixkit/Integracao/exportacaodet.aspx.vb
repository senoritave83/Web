Imports System.Data
Imports Classes
Imports Ionic.Utils.Zip

Partial Class integracao_exportacaodet
    Inherits XMWebPage


    Protected Overrides Function CheckAccessAutorization(ByVal vSecao As String) As Boolean
        Return VerificaPermissao("Integração", "Exportar pedidos")
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

 
        Dim imp As clsIntegracao

        Try

            imp = New clsIntegracao()

            Dim dr As IDataReader
            dr = imp.ExportarPedido(0)

            Dim strFile As String = "EXPORTAR_" & Now().ToString("yyyyMMdd-hhmmss") & ".ZIP"

            'Cria arquivo ZIP no stream de resposta
            Dim zip As New ZipFile(Response.OutputStream)

            'Cria arquivo de Pedidos
            Dim fPed As New IO.MemoryStream
            Dim filePed As New IO.StreamWriter(fPed)

            Do While dr.Read
                filePed.WriteLine(dr.GetString(0))
            Loop
            filePed.Flush()
            zip.AddFileStream("PEDIDOS.TXT", "", fPed)

            'Grava resposta
            Response.Clear()
            Response.ClearHeaders()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & strFile)

            zip.Save()
            zip.Dispose()
            zip = Nothing

            fPed.Dispose()
            filePed.Dispose()


        Catch ex As System.Exception
            Throw ex
        Finally


        End Try

    End Sub

End Class
