Imports Microsoft.Reporting.WebForms
Imports System.Collections.Generic
Imports System.Configuration.ConfigurationManager
Imports XMSistemas.Web.UI.WebControls.ReportControls

Partial Class RelatorioMobDet

    Inherits Page

    Public Property PossuiPeriodoDatas() As Boolean
        Get
            If ViewState("PossuiPeriodoDatas") Is Nothing Then
                Return False
            End If
            Return ViewState("PossuiPeriodoDatas")
        End Get
        Set(ByVal value As Boolean)
            ViewState("PossuiPeriodoDatas") = value
        End Set
    End Property

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim fgPeriodo As Byte = 0

        If Not Page.IsPostBack Then

            divFiltro.Visible = True
            'divResult.Visible = False

            Dim p_IdEmpresa As String = Request("IdEmpresa") & ""
            If p_IdEmpresa = "" Then p_IdEmpresa = 0
            Dim p_IdUsuario As String = Request("IdUsuario") & ""
            If p_IdUsuario = "" Then p_IdUsuario = 0

            ViewState("REPORTPATH") = System.Web.HttpUtility.HtmlDecode(Request("reportpath"))

            ViewState("IDUSUARIO") = p_IdUsuario
            ViewState("IDEMPRESA") = p_IdEmpresa
            ViewState("IDPERIODO") = 1

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
            ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL"))
            ReportViewer1.ServerReport.ReportPath = ViewState("REPORTPATH")

            Dim params As New List(Of ReportParameter)
            params.Add(New ReportParameter("IDEMPRESA", ViewState("IDEMPRESA").ToString(), True))
            params.Add(New ReportParameter("IDUSUARIO", ViewState("IDUSUARIO").ToString(), True))
            'params.Add(New ReportParameter("PERIODO", ViewState("IDPERIODO").ToString(), True))
            ReportViewer1.ServerReport.SetParameters(params)

            ReportViewer1.Visible = True

            'XMReportFilters1.FixedParameters.Add("IDEMPRESA", p_IdEmpresa)
            'XMReportFilters1.FixedParameters.Add("IDUSUARIO", p_IdUsuario)

            'XMReportFilters1.ReportPath = System.Web.HttpUtility.HtmlDecode(Request("reportpath"))
            'XMReportFilters1.ReportServerURL = AppSettings("ReportServerURL")


            'For Each prm In XMReportFilters1.Parameters

            '    If prm.Name = "PERIODO" Then fgPeriodo += 1
            '    If prm.Name = "DATAINICIAL" Then fgPeriodo += 2
            '    If prm.Name = "DATAFINAL" Then fgPeriodo += 4

            'Next

            'PossuiPeriodoDatas = (fgPeriodo = 7)

            'If PossuiPeriodoDatas Then

            '    XMReportFilters1.Parameters.Insert(0, New XMSistemas.Web.UI.WebControls.ReportControls.XMReportParameter("TipoDatas", "Tipo de Datas", enControlType.dropdown, False, True, False, RSService.ParameterTypeEnum.Integer))
            '    XMReportFilters1.Parameters("TipoDatas").EnableAutoPostBack = True

            '    XMReportFilters1.Parameters("DATAINICIAL").Value = ""
            '    XMReportFilters1.Parameters("DATAFINAL").Value = ""

            'End If

            'bindReport()

        End If



    End Sub

    'Protected Sub XMReportFilters1_OnFilterChanged(ByVal source As Object, ByVal args As XMSistemas.Web.UI.WebControls.ReportControls.XMReportBase.XMFilterArgs) Handles XMReportFilters1.OnFilterChanged
    '    If PossuiPeriodoDatas Then
    '        If args.Filter.ToUpper = "TIPODATAS" Then
    '            XMReportFilters1.Parameters("PERIODO").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 2)
    '            XMReportFilters1.Parameters("DATAINICIAL").Value = ""
    '            XMReportFilters1.Parameters("DATAFINAL").Value = ""
    '            XMReportFilters1.Parameters("DATAINICIAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
    '            XMReportFilters1.Parameters("DATAFINAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
    '        ElseIf args.Filter.ToUpper = "DATAINICIAL" Then
    '            If Not IsDate(XMReportFilters1.Parameters("DATAINICIAL").Value) Then
    '                XMReportFilters1.Parameters("DATAINICIAL").Value = ""
    '            End If
    '        ElseIf args.Filter.ToUpper = "DATAFINAL" Then
    '            If Not IsDate(XMReportFilters1.Parameters("DATAFINAL").Value) Then
    '                XMReportFilters1.Parameters("DATAFINAL").Value = ""
    '            End If
    '        End If
    '    End If
    'End Sub

    'Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
    '    'If Not Page.IsPostBack Then
    '    '    If PossuiPeriodoDatas Then
    '    '        Dim li As New ListItem("Entre Datas", "1")
    '    '        If XMReportFilters1.Parameters("TipoDatas").Value = "" Then
    '    '            li.Selected = True
    '    '            XMReportFilters1.Parameters("TipoDatas").Value = "1"
    '    '            XMReportFilters1.Parameters("PERIODO").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 2)
    '    '            XMReportFilters1.Parameters("DATAINICIAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
    '    '            XMReportFilters1.Parameters("DATAFINAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
    '    '        End If
    '    '        XMReportFilters1.Parameters("TipoDatas").Itens.Add(li)
    '    '        XMReportFilters1.Parameters("TipoDatas").Itens.Add(New ListItem("Por Período", "2"))
    '    '    End If
    '    'End If
    'End Sub

    'Protected Sub btnVisualizar_Click(sender As Object, e As System.EventArgs) Handles btnVisualizar.Click

    '    bindReport()

    'End Sub

    Sub bindReport()

        Dim defaultExportFormat As String = AppSettings("DefaultExportFormat")
        Dim c As New XMSistemas.Web.UI.WebControls.ReportControls.XMReportXMLHelper
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote
        ReportViewer1.ServerReport.ReportServerUrl = New Uri(AppSettings("ReportServerURL"))
        ReportViewer1.ServerReport.ReportPath = ViewState("REPORTPATH")

        Dim params As New List(Of ReportParameter)
        params.Add(New ReportParameter("IDEMPRESA", ViewState("IDEMPRESA").ToString(), True))
        params.Add(New ReportParameter("IDUSUARIO", ViewState("IDUSUARIO").ToString(), True))
        params.Add(New ReportParameter("PERIODO", ViewState("IDPERIODO").ToString(), True))
        ReportViewer1.ServerReport.SetParameters(params)

        ReportViewer1.Visible = True

        'divFiltro.Visible = False
        'divResult.Visible = True

    End Sub

End Class
