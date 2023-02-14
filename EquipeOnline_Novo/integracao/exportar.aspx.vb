
Partial Class integracao_exportar
    Inherits XMProtectedPage

    Protected Const VW_CLIENTE As String = "Cliente"
    Protected Const VW_RESPONSAVEL As String = "Responsavel"
    Protected Const VW_DATAINICIO As String = "DataInicio"
    Protected Const VW_DATAFINAL As String = "DataFinal"
    Protected Const VW_STATUS As String = "Status"


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            ViewState(VW_CLIENTE) = "" & Request(VW_CLIENTE)
            ViewState(VW_RESPONSAVEL) = "" & Request(VW_RESPONSAVEL)
            ViewState(VW_DATAINICIO) = "" & Request(VW_DATAINICIO)
            ViewState(VW_DATAFINAL) = "" & Request(VW_DATAFINAL)
            ViewState(VW_STATUS) = "" & Request(VW_STATUS)
        End If
    End Sub


    Private Sub Exportar()
        Dim strText, strSeparador As String
        If CInt("0" & Request("chkSeparador")) > 0 Then
            strSeparador = Chr(CInt("0" & Request("chkSeparador")))
        Else
            strSeparador = txtSeparador.Text
        End If
        Dim blnXML As Boolean = (cboFormato.SelectedItem.Value = "XML")
        Dim exp As New clsOrdemServico()
        strText = exp.ExportarOrdens(ViewState(VW_CLIENTE), ViewState(VW_RESPONSAVEL), ViewState(VW_DATAINICIO), ViewState(VW_DATAFINAL), ViewState(VW_STATUS), chkResposta.Checked, blnXML, strSeparador)
        Response.Clear()
        Response.AppendHeader("Content-Type", "text/html; charset=iso-8859-1")

        Response.AddHeader("Content-Disposition", "attachment; filename=ors_" & Now().ToString("yyyyMMdd-hhmmss") & IIf(blnXML, ".xml", ".txt"))
        'Response.AddHeader("Content-Length", strText.Length)
        If blnXML Then
            Response.ContentType = "text/xml"
        Else
            Response.ContentType = "text/plain"
        End If
        Response.Write(strText)
        Response.End()
        exp = Nothing
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

End Class
