Imports RSService
Imports RSService.ReportingService2005
Imports System.Configuration.ConfigurationManager

Partial Class reports_reportlist
    Inherits XMWebPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim strPath As String = ""
            strPath = SettingsExpression.GetProperty("reportspath", "", "")
            XMReportDataSource1.ReportPath = strPath

            'Dim rrs As New RSService.ReportingService2005
            'rrs.Url = AppSettings("RSService.reportservice2005") & "ReportService2005.asmx"
            'ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("RSService.reportservice2005"))
            'Try
            '    Dim strPath As String = ""
            '    strPath = SettingsExpression.GetProperty("reportspath", "", "")
            '    If strPath <> "" Then
            '        rrs.Credentials = System.Net.CredentialCache.DefaultCredentials
            '        Dim ct() As CatalogItem = rrs.ListChildren(strPath, True)
            '        cboReports.Items.Clear()
            '        cboReports.Items.Add(New ListItem("Selecione...", ""))
            '        For Each C As CatalogItem In ct
            '            cboReports.Items.Add(New ListItem(C.Name, C.Path))
            '        Next
            '    End If
            '    pnlNavigate.Visible = True
            '    pnlErro.Visible = False
            'Catch ex As Exception
            '    pnlNavigate.Visible = False
            '    pnlErro.Visible = True
            '    ltrSource.Text = "<!--" & ex.Message.Replace("-->", "--") & " -->"
            'End Try
        End If
    End Sub


    'Protected Sub cboReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReports.SelectedIndexChanged
    '    Mostrar()
    'End Sub

    Private Sub Mostrar()
        'If cboReports.SelectedValue = "" Then
        '    ReportViewer1.ServerReport.ReportPath = ""
        '    ReportViewer1.Visible = False
        'Else
        '    ReportViewer1.ServerReport.ReportPath = cboReports.SelectedValue
        '    Dim prms As Microsoft.Reporting.WebForms.ReportParameterInfoCollection = ReportViewer1.ServerReport.GetParameters()
        '    Dim prmsList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        '    For i As Integer = 0 To prms.Count - 1
        '        If prms(i).Name.ToUpper = "IDEMPRESA" Then
        '            prmsList.Add(New Microsoft.Reporting.WebForms.ReportParameter(prms(i).Name, User.IDEmpresa, False))
        '        ElseIf prms(i).Name.ToUpper = "IDUSUARIO" Then
        '            prmsList.Add(New Microsoft.Reporting.WebForms.ReportParameter(prms(i).Name, User.IDUser, False))
        '        End If
        '    Next
        '    If prmsList.Count > 0 Then ReportViewer1.ServerReport.SetParameters(prmsList.ToArray)
        '    ReportViewer1.Visible = True
        'End If
    End Sub

    Protected Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Mostrar()
    End Sub


    Protected Sub XMReportDataSource1_onBindItem(ByVal c As XMSistemas.Web.UI.WebControls.ReportControls.RSService.CatalogItem, ByRef Cancel As Boolean) Handles XMReportDataSource1.onBindItem

        If Me.VerificaPermissao("Relatórios", c.Name) = False Then
            Cancel = True
        End If

        'Dim s As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
        'Dim RET As XMSistemas.Web.UI.WebControls.ReportControls.XMParameterValues = s.GetParametersValues("")
        'Dim prmsList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        'For Each KEY As String In RET.Keys
        '    prmsList.Add(KEY, RET.Item(KEY))
        'Next

    End Sub

End Class
