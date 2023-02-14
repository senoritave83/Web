Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.Configuration.ConfigurationManager
Imports System.Xml

Partial Class reports_RelatorioDet
    Inherits XMWebPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim c As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL"))
            Dim strReportPath As String = System.Web.HttpUtility.HtmlDecode(Request("reportpath") & "")
            ReportViewer1.ServerReport.ReportPath = System.Web.HttpUtility.HtmlDecode(strReportPath)
            ReportViewer1.ServerReport.ReportServerCredentials = New CustomReportCredentials()

            Dim params As New List(Of ReportParameter)
            Dim col As XMSistemas.Web.UI.WebControls.ReportControls.XMParameterValues = c.GetParametersValues(Server.HtmlDecode(Request("parameters")))
            For Each key As String In col.Keys
                params.Add(New ReportParameter(key, col.Item(key).ToArray(), True))
            Next
            ReportViewer1.ServerReport.SetParameters(params)

            Dim ndReportViewerNode As XmlNode = SettingsExpression.GetXMLNodeProperty("ReportViewer")
            Dim blnExcel As Boolean = False, strReport As String = ""
            strReport = StrReverse(StrReverse(strReportPath).Substring(0, StrReverse(strReportPath).IndexOf("/")))

            For Each xmlItem As XmlNode In ndReportViewerNode("Relatorios").ChildNodes
                Dim strReportName As String = xmlItem.Attributes("Nome").Value
                If strReportName.Trim() = strReport.Trim() Then
                    For Each xmlAt As XmlAttribute In xmlItem.Attributes
                        If xmlAt.Name = "MostrarRelatorioEm" Then
                            If xmlAt.Value = "EXCEL" Then
                                blnExcel = True
                            End If
                        End If
                    Next
                End If
            Next

            If blnExcel Then

                ReportViewer1.Visible = False

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

            Else

                ReportViewer1.Visible = True

            End If



        End If

    End Sub

    'Public Function GetReportCredentials() As Microsoft.Reporting.WebForms.IReportServerCredentials

    '    Dim auth As System.Collections.Specialized.NameValueCollection = GetSection("XMReportControl/Authentication")
    '    If Not auth Is Nothing Then
    '        If auth.Count = 3 Then
    '            Dim crd As New Microsoft.Reporting.WebForms.(auth.Item("username"), auth.Item("password"), auth.Item("domain"))
    '            Return crd
    '        End If
    '    End If
    '    Return Net.CredentialCache.DefaultNetworkCredentials

    'End Function


    
End Class

Public Class CustomReportCredentials

    Implements Microsoft.Reporting.WebForms.IReportServerCredentials

    Private _UserName As String
    Private _PassWord As String
    Private _DomainName As String

    Public Sub New()

        Dim auth As System.Collections.Specialized.NameValueCollection = GetSection("XMReportControl/Authentication")
        If Not auth Is Nothing Then
            If auth.Count = 3 Then
                _UserName = auth.Item("username")
                _PassWord = auth.Item("password")
                _DomainName = auth.Item("domain")
            End If
        End If
    End Sub

    Public Function GetFormsCredentials(ByRef authCookie As System.Net.Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements Microsoft.Reporting.WebForms.IReportServerCredentials.GetFormsCredentials

        authCookie = Nothing
        userName = Nothing
        password = Nothing
        authority = Nothing

        Return False

    End Function

    Public ReadOnly Property ImpersonationUser As System.Security.Principal.WindowsIdentity Implements Microsoft.Reporting.WebForms.IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials As System.Net.ICredentials Implements Microsoft.Reporting.WebForms.IReportServerCredentials.NetworkCredentials
        Get
            Return New System.Net.NetworkCredential(_UserName, _PassWord, _DomainName)
        End Get
    End Property

End Class
