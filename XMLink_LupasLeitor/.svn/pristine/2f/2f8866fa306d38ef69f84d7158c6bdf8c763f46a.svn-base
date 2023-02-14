Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.Configuration.ConfigurationManager

Partial Class Relatorios_RelatorioDet
    Inherits XMWebPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim defaultExportFormat As String = AppSettings("DefaultExportFormat")
            Dim c As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL"))
            ReportViewer1.ServerReport.ReportPath = System.Web.HttpUtility.HtmlDecode(Request("reportpath")) '& IIf(defaultExportFormat <> ".rdl", "?rs:Command=Render&" & defaultExportFormat, "")

            Dim params As New List(Of ReportParameter)
            Dim col As XMSistemas.Web.UI.WebControls.ReportControls.XMParameterValues = c.GetParametersValues(Server.HtmlDecode(Request("parameters")))
            For Each key As String In col.Keys
                params.Add(New ReportParameter(key, col.Item(key).ToArray(), True))
            Next
            ReportViewer1.ServerReport.SetParameters(params)

            '****************************************************
            'ALTERAÇÃO EFETUADA POR MARCELO R
            'EM 13/11/2012 PARA EXIBIR O RELATÓRIO DIRETO EM EXCEL
            '****************************************************
            Dim mimeType As String
            Dim encoding As String
            Dim streams As String()
            Dim extension As String
            Dim warnings As Microsoft.Reporting.WebForms.Warning()
            Dim bytes As Byte() = ReportViewer1.ServerReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streams, warnings)

            Response.Buffer = True
            Response.Clear()
            Response.ContentType = mimeType
            Response.AppendHeader("content-Disposition", "inline:filename=teste." & extension)
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.End()
            '****************************************************

            'ReportViewer1.Visible = True

        End If

    End Sub

End Class
