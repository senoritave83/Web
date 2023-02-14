
Partial Class relatorios_relsla_prn
    Inherits XMReportPage
    Protected cls As clsRelatorio
    Protected intTotalAbaixo As Integer = 0
    Protected intTotalDentro As Integer = 0
    Protected intTotalFora As Integer = 0
    Protected blnTotal As Boolean = False
    Protected strDataInicial As String = ""
    Protected strDataFinal As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()

        intTotalAbaixo = 0
        intTotalDentro = 0
        intTotalFora = 0
        blnTotal = False

        Dim strDataInicio As String = Request("di")
        Dim strDataFinal As String = Request("df")
        'Dim strTipoGrafico As String = Request("tp")

        Dim ds As DataSet = Nothing

        'If strTipoGrafico = "Tabular" Then

        ds = cls.GetReport_SLA(strDataInicio, strDataFinal)

        grdRelatorio.DataSource = ds
        grdRelatorio.DataBind()
        grdRelatorio.Visible = True
        chartEOL.Visible = False


        'Else

        'If strTipoGrafico = "Linhas" Then
        '    ds = cls.GetReport_Responsavel_Linha(strDataInicio, strDataFinal)

        'Else
        '    ds = cls.GetReport_Responsavel(strDataInicio, strDataFinal)

        'End If

        'grdRelatorio.Visible = False
        'chartEOL.Visible = True

        'If ds.Tables.Count > 0 Then
        '    chartEOL.Visible = ds.Tables(0).Rows.Count > 0
        'End If

        'MakeChart(ds, strTipoGrafico, chartEOL, "O.S. por Rádios")

        'End If

        ltTitulo.Text = "Relat&oacute;rio de SLA de " & strDataInicio & " até " & strDataFinal
        '

    End Sub

    Protected Sub grdRelatorio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRelatorio.DataBound
        If Not grdRelatorio.FooterRow Is Nothing And blnTotal Then
            On Error Resume Next
            grdRelatorio.FooterRow.Cells(1).Text = "Totais"
            grdRelatorio.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            grdRelatorio.FooterRow.Cells(2).Text = intTotalAbaixo
            grdRelatorio.FooterRow.Cells(2).HorizontalAlign = HorizontalAlign.Left
            grdRelatorio.FooterRow.Cells(3).Text = intTotalDentro
            grdRelatorio.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Left
            grdRelatorio.FooterRow.Cells(4).Text = intTotalFora
            grdRelatorio.FooterRow.Cells(4).HorizontalAlign = HorizontalAlign.Left
        End If
    End Sub


    Protected Sub grdRelatorio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorio.RowDataBound
        If Not e.Row.DataItem Is Nothing Then
            Dim intTemp As Integer = 0
            Dim intTemp1 As Integer = 0
            Dim intTemp2 As Integer = 0
            Try
                intTemp = e.Row.DataItem("Abaixo50SLA")
                intTemp1 = e.Row.DataItem("DentroSLA")
                intTemp2 = e.Row.DataItem("ForaSLA")
                blnTotal = True
            Finally
                intTotalAbaixo += intTemp
                intTotalDentro += intTemp1
                intTotalFora += intTemp2
            End Try
        End If
    End Sub

End Class
