Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.Configuration.ConfigurationManager
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Xml

Partial Class _Default
    Inherits XMWebPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not Page.IsPostBack Then
            ReportChart()
        End If

    End Sub

    Protected Sub ReportChart()


        'EXEMPLO DE ESTRUTURA DO XML RESPONS�VEL 
        'PELO RELAT�RIO NA P�GINA HOME/DEFAULT.ASPX
        'DENTRO DO ARQUIVO SETTINGS.XML
        'ALTERA��O FEITA PARA SUPORTAR M�LTIPLOS RELAT�RIOS
        'AUTOR: MARCELO R
        'DATA : 17/08/2011
        '<ReportViewer visible="true">
        '  <Relatorios>
        '    <Relatorio Nome="Relat�rio Home" NomeTela="Pre�o M�dio de Produtos por Regi�o"></Relatorio>
        '    <Relatorio Nome="Relat�rio Home Abastecimento" NomeTela="Abastecimento de Produtos por Regi�o"></Relatorio>
        '  </Relatorios>
        '</ReportViewer> 

        Dim ndReportViewerNode As XmlNode = SettingsExpression.GetXMLNodeProperty("ReportViewer")

        If Not ndReportViewerNode Is Nothing Then

            Dim blnVisible As Boolean = False
            Dim strVisible As String
            Try
                strVisible = ndReportViewerNode.Attributes("visible").Value
            Catch ex As Exception

            End Try


            For Each xmlChild As XmlNode In ndReportViewerNode.FirstChild.ChildNodes
                If Not xmlChild Is Nothing Then

                    Dim strNomeRelatorio As String = ""
                    Dim strNomeTela As String = ""
                    Dim strMostraNaHome As String = ""

                    Try
                        strNomeRelatorio = xmlChild.Attributes("Nome").Value
                    Catch ex As Exception
                        strNomeRelatorio = ""
                    End Try

                    Try
                        strNomeTela = xmlChild.Attributes("NomeTela").Value
                    Catch ex As Exception
                        strNomeTela = ""
                    End Try

                    Try
                        strMostraNaHome = xmlChild.Attributes("MostrarHome").Value
                    Catch ex As Exception
                        strMostraNaHome = ""
                    End Try

                    If strNomeTela = "" Then strNomeTela = strNomeRelatorio

                    If strMostraNaHome.ToUpper = "TRUE" Then
                        If strNomeRelatorio <> "" And strNomeTela <> "" Then
                            rdlGrafico.Items.Add(New ListItem(strNomeTela, strNomeRelatorio))
                        End If
                    End If

                End If
            Next

            If rdlGrafico.Items.Count > 0 Then
                rdlGrafico.SelectedIndex = 0
                If strVisible = "true" And rdlGrafico.Items.Count > 1 Then
                    rdlGrafico.Visible = True
                End If

            Else

                strVisible = "False"

            End If

            ReportViewer1.Visible = strVisible

            'ShowReport()

        End If


    End Sub

    'Protected Sub ShowReport()

    '    Dim rdlGradicoSelecionado As String = rdlGrafico.SelectedItem.Value
    '    If rdlGradicoSelecionado = False Then
    '        Dim strReportName As String = rdlGrafico.SelectedItem.Value

    '        If ReportViewer1.Visible = True Then

    '            Dim c As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
    '            Dim cred As New ReportServerCredentials("Administrator", "!@SR2009#$1781xm", "XMSISTEMAS")
    '            Dim strPath As String = "/"
    '            strPath = SettingsExpression.GetProperty("reportspath", "", "")
    '            If strPath.EndsWith("/") = False Then strPath &= "/"

    '            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
    '            ReportViewer1.ServerReport.ReportServerCredentials = cred
    '            ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL")) 'New Uri(ht tp://xmsistemas4.dominiotemporarioidc.com/ReportServer")
    '            ReportViewer1.ServerReport.ReportPath = System.Web.HttpUtility.HtmlDecode(strPath & strReportName)
    '            ReportViewer1.ShowToolBar = False

    '        End If
    '    End If

    'End Sub

    '    Protected Sub rdlGrafico_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlGrafico.SelectedIndexChanged
    '        ShowReport()
    '        'Dim strReportName As String = ""
    '        'If rdlGrafico.SelectedValue = 0 Then
    '        '    strReportName = SettingsExpression.GetProperty("relatoriopreco", "Default.ReportViewer", "")
    '        'ElseIf rdlGrafico.SelectedValue = 1 Then
    '        '    strReportName = SettingsExpression.GetProperty("relatorioAbastecimento", "Default.ReportViewer", "")
    '        'End If

    '        'Dim strReportViewer As String = SettingsExpression.GetProperty("visible", "Default.ReportViewer", False)
    '    End Sub
End Class

Public Class ReportServerCredentials
    Implements IReportServerCredentials

    Private _userName As String
    Private _password As String
    Private _domain As String

    Public Sub New(ByVal userName As String, ByVal password As String, ByVal domain As String)
        _userName = userName
        _password = password
        _domain = domain
    End Sub

    Public ReadOnly Property ImpersonationUser() As System.Security.Principal.WindowsIdentity Implements Microsoft.Reporting.WebForms.IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials() As ICredentials Implements Microsoft.Reporting.WebForms.IReportServerCredentials.NetworkCredentials
        Get
            Return New NetworkCredential(_userName, _password, _domain)
        End Get
    End Property

    Public Function GetFormsCredentials(ByRef authCookie As System.Net.Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements Microsoft.Reporting.WebForms.IReportServerCredentials.GetFormsCredentials
        userName = _userName
        password = _password
        authority = _domain
        Return Nothing
    End Function
End Class


