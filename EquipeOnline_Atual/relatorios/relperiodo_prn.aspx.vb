
Partial Class relatorios_relperiodo_prn
    Inherits XMReportPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False
    Protected strDataInicial As String = ""
    Protected strDataFinal As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()

        Dim strDataInicio As String = Request("di")
        Dim strDataFinal As String = Request("df")
        Dim strTipoGrafico As String = Request("tp")

        intTotal = 0
        blnTotal = False

        Dim ds As DataSet = Nothing

        If strTipoGrafico = "Tabular" Then

            ds = cls.GetReport_Periodo(strDataInicio, strDataFinal)

            grdRelatorio.DataSource = ds
            grdRelatorio.DataBind()
            grdRelatorio.Visible = True
            chartEOL.Visible = False


        Else

            If strTipoGrafico = "Linhas" Then
                ds = cls.GetReport_Periodo_Linha(strDataInicio, strDataFinal)

            Else
                ds = cls.GetReport_Periodo(strDataInicio, strDataFinal)

            End If

            grdRelatorio.Visible = False
            chartEOL.Visible = True

            If ds.Tables.Count > 0 Then
                chartEOL.Visible = ds.Tables(0).Rows.Count > 0
            End If

            MakeChart(ds, strTipoGrafico, chartEOL, "O.S. por Período")

        End If

        ltTitulo.Text = "Relat&oacute;rio de O.S. por Periodo de " & strDataInicio & " até " & strDataFinal

    End Sub

    Protected Sub grdRelatorio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRelatorio.DataBound
        If Not grdRelatorio.FooterRow Is Nothing And blnTotal Then
            On Error Resume Next
            grdRelatorio.FooterRow.Cells(0).Text = "Total"
            grdRelatorio.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            grdRelatorio.FooterRow.Cells(1).Text = intTotal
            grdRelatorio.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
        End If
    End Sub


    Protected Sub grdRelatorio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorio.RowDataBound
        If Not e.Row.DataItem Is Nothing Then
            Dim intTemp As Integer = 0
            Try
                intTemp = e.Row.DataItem("qtd")
                blnTotal = True
            Finally
                intTotal += intTemp
            End Try
        End If
    End Sub

End Class
