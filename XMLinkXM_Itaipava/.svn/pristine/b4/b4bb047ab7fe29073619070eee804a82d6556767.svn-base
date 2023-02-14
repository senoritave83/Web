Imports Classes
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization
Imports System.Web.UI.DataVisualization.Charting

Partial Class Relatorios_status_det_graf
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Private Sub GerarGrafico()

        Dim rep As New clsRelatorio
        Dim ds As SqlDataReader = rep.GetRelatorioStatus(Filtro1.IDEmpresa, Filtro1.IDSupervisor, Filtro1.DataInicial, Filtro1.DataFinal)
        Dim i As Integer = 0
        Dim blnDados As Boolean = False
        Dim title As New Title("Pedidos por Status")
        title.Font = New Font("Verdana", 16, FontStyle.Bold)
        Chart1.Titles.Add(title)

        'With Chart1.ChartAreas(0).AxisX
        '    .IsLabelAutoFit = True
        '    .LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90
        '    .LabelStyle.Enabled = True
        'End With

        Dim chSeries As Series

        chSeries = New Series("Status")
        With chSeries
            .SmartLabelStyle.Enabled = False
            .ChartType = DataVisualization.Charting.SeriesChartType.Pie
            .Color = Color.Green
            .ChartArea = "ChartArea1"
            Do While ds.Read
                blnDados = True
                .Points.AddY(ds(1))
                .Points(.Points.Count - 1).Label = "#VALY (#PERCENT)"
                .Points(.Points.Count - 1).LegendText = ds(0)
            Loop
        End With
        Chart1.Series.Add(chSeries)

        Chart1.Legends(0).Docking = Docking.Bottom
        Chart1.Legends(0).Alignment = StringAlignment.Center

        If blnDados = False Then
            Chart1.Visible = False
            Chart1 = Nothing
            lblPeriodoData.Text = "Não existem dados de acordo com o período solicitado"
        Else
            Chart1.Visible = True
            lblPeriodoData.Text = ""
        End If

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir
        GerarGrafico()
    End Sub

End Class
