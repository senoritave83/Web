'Imports RSService
'Imports RSService.ReportingService2005
Imports System.Configuration.ConfigurationManager

Partial Class Relatorios_ReportList
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim strPath As String = ""
            strPath = AppSettings("reportspath")
            'strPath = SettingsExpression.GetProperty("reportspath", "", "")
            XMReportDataSource1.ReportPath = strPath

        End If
    End Sub

    Protected Sub XMReportDataSource1_onBindItem(ByVal c As XMSistemas.Web.UI.WebControls.ReportControls.RSService.CatalogItem, ByRef Cancel As Boolean) Handles XMReportDataSource1.onBindItem

        If Me.VerificaPermissao("Relatórios", c.Name) = False Then
            Cancel = True
        End If

    End Sub

End Class
