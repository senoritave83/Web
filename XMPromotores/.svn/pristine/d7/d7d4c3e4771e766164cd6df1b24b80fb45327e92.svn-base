Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.Configuration.ConfigurationManager

Partial Class RelatorioMobDet

    Inherits Page

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then


            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL"))
            ReportViewer1.ServerReport.ReportPath = System.Web.HttpUtility.HtmlDecode(Request("reportpath"))

            If Request("parameters") <> "" Then
                Dim c As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
                Dim params As New List(Of ReportParameter)
                Dim col As XMSistemas.Web.UI.WebControls.ReportControls.XMParameterValues = c.GetParametersValues(Server.HtmlDecode(Request("parameters")))
                For Each key As String In col.Keys
                    params.Add(New ReportParameter(key, col.Item(key).ToArray(), True))
                Next
                ReportViewer1.ServerReport.SetParameters(params)
            End If
            ReportViewer1.Visible = True

        End If

    End Sub





End Class
