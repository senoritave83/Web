Imports Microsoft.VisualBasic
Imports Xceed.Chart.GraphicsCore
Imports Xceed.Chart.Standard
Imports Xceed.Chart.Core
Imports Xceed.Chart.Utilities
Imports System.Drawing

Public Class XMReportPage

    Inherits XMProtectedPage
    'Protected m_Chart As Xceed.Chart.Core.Chart

    Public Sub New()
        Xceed.Chart.Server.Licenser.LicenseKey = "CHW42-YEW8B-LTYKP-2N2A"
    End Sub

    Protected Sub MakeChart(ByVal ds As DataSet, ByVal p_Tipo As String, ByVal chartEOL As Xceed.Chart.Server.ChartServerControl, ByVal vTitle As String)

        chartEOL.Settings.RenderDevice = RenderDevice.OpenGL
        chartEOL.Background.FillEffect.SetSolidColor(Color.White)

        chartEOL.Background.FrameType = FrameType.Standard
        chartEOL.Width = 733
        chartEOL.Height = 600

        Dim imageFrame As ImageFrame

        imageFrame = chartEOL.Background.ImageFrame
        imageFrame.SetPredefinedFrameStyle(PredefinedImageFrame.RoundedBorder)
        imageFrame.FillEffect.SetSolidColor(Color.White)
        imageFrame.BackgroundColor = Color.White
        imageFrame.LeftCornersWidth = 10

        'add a header label
        Dim header As ChartLabel = chartEOL.Labels.AddHeader(vTitle)
        header.TextProps.Backplane.Style = BackplaneStyle.Rectangle
        header.TextProps.Backplane.FillEffect.SetSolidColor(Color.White)
        header.TextProps.VertAlign = VertAlign.Top
        header.TextProps.HorzAlign = HorzAlign.Center
        header.VerticalMargin = 2

        Dim legend As Xceed.Chart.Core.Legend = chartEOL.Legends.GetAt(0)
        legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight)
        legend.Backplane.FillEffect.SetTransparencyPercent(50)
        legend.HorizontalMargin = 98
        legend.VertAlign = VertAlign.Bottom
        legend.Data.TextProps.Font = New System.Drawing.Font("Verdana", 7)

        Dim m_Chart As Xceed.Chart.Core.Chart = chartEOL.Charts.GetAt(0)
        m_Chart.MarginMode = MarginMode.Stretch
        m_Chart.Margins = New RectangleF(2, 8, 73, 80)
        m_Chart.Width = 800
        m_Chart.Height = 500

        If p_Tipo = "Barras" Then
            'makeBarChart(ds, chartEOL, vTitle)
            makeHorizontalBarChart(ds, m_Chart, vTitle)
        ElseIf p_Tipo = "Linhas" Then
            makeLineChart(ds, m_Chart, vTitle)
        ElseIf p_Tipo = "Pizza" Then
            makeExplodedPieChart(ds, m_Chart, vTitle)
        End If

        Dim imageMap As New Xceed.Chart.Server.HTMLImageMapResponse()
        chartEOL.ServerConfiguration.DefaultResponse = imageMap

    End Sub

    Private Sub makeBarChart(ByVal ds As DataSet, ByVal m_Chart As Chart, ByVal vTitle As String)

        Dim m_Series As Series = Nothing

        m_Series = CType(m_Chart.Series.Add(SeriesType.Bar), BarSeries)
        m_Series.Appearance.FillMode = AppearanceFillMode.Predefined
        m_Series.Legend.Mode = SeriesLegendMode.DataPoints
        m_Series.Legend.Format = "<label>"
        m_Series.DataLabels.Text.Font = New System.Drawing.Font("Verdana", 6)
        m_Series.DataLabels.Mode = DataLabelsMode.None
        m_Series.Interactivity.TooltipMode = SeriesTooltipMode.Formatted
        m_Series.Interactivity.TooltipFormat = "<label>: <value>"

        Dim i As Integer = 0

        For i = 0 To ds.Tables(0).Rows.Count - 1

            Dim fe As New Xceed.Chart.Standard.FillEffect
            fe.SetSolidColor(GetColor(i))

            Dim color As Color = GetColor(i + 2)

            CType(m_Series, BarSeries).BarFillEffect.SetSolidColor(color)
            m_Series.Add(ds.Tables(0).Rows(i).Item(1).ToString().Trim(), ds.Tables(0).Rows(i).Item(0).ToString().Trim(), fe)


        Next

    End Sub

    Private Sub makeLineChart(ByVal ds As DataSet, ByVal m_Chart As Chart, ByVal vTitle As String)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim strAtual As String = ""
        Dim m_Series As LineSeries = Nothing

        For i = 0 To ds.Tables(0).Rows.Count - 1


            If strAtual <> ds.Tables(0).Rows(i).Item(0).ToString().Trim() Then

                m_Series = m_Chart.Series.Add(SeriesType.Line)

                With m_Series

                    Dim p_Color As Color = GetColor(j)

                    .Appearance.FillMode = AppearanceFillMode.Series
                    .Legend.Mode = SeriesLegendMode.Series
                    .Legend.Format = "<label>"
                    .DataLabels.Text.Font = New System.Drawing.Font("Verdana", 36)
                    .DataLabels.Mode = DataLabelsMode.None

                    .Interactivity.TooltipMode = SeriesTooltipMode.DataPoints
                    .Interactivity.TooltipFormat = "<label>: <value>"

                    .Markers.Visible = True
                    .Markers.Style = PointStyle.Bar
                    .Markers.Height = 0.5
                    .Markers.Width = 0.5
                    .Markers.FillEffect = New FillEffect(p_Color)
                    .Markers.Border.Color = p_Color

                    .MultiLineMode = MultiLineMode.Series
                    .Name = ds.Tables(0).Rows(i).Item(0).ToString().Trim()

                    .LineFillEffect.SetSolidColor(p_Color)
                    .LineBorder.Color = p_Color
                    .LineBorder.Width = 2

                End With

                j += 1

            End If

            m_Series.Add(ds.Tables(0).Rows(i).Item(1).ToString().Trim())
            strAtual = ds.Tables(0).Rows(i).Item(0).ToString().Trim()

        Next

        With m_Chart

            .Axis(StandardAxis.PrimaryX).Labels.Clear()
            .Axis(StandardAxis.PrimaryX).DimensionScale.AutoLabels = False
            .Axis(StandardAxis.PrimaryX).SetPredefinedTextLayout(PredefinedTextLayout.Vertical)

            For i = 0 To ds.Tables(0).Rows.Count - 1

                Dim label As AxisLabel = m_Chart.Axis(StandardAxis.PrimaryX).CustomLabels.Add()
                label.Text = Format(ds.Tables(0).Rows(i).Item(2), "dd/MM/yyyy").ToString()
                label.TextProps.Orientation = 90
                label.Value = i
                label.Angle = 90
                label.Offset = -35
                label.LineProps.Width = 0

            Next

        End With

    End Sub

    Private Sub makePieChart(ByVal ds As DataSet, ByVal m_Chart As Chart, ByVal vTitle As String)

        Dim m_Series As Series = Nothing
        m_Series = CType(m_Chart.Series.Add(SeriesType.Pie), PieSeries)
        m_Series.Appearance.FillMode = AppearanceFillMode.Predefined
        m_Series.Legend.Mode = SeriesLegendMode.DataPoints
        m_Series.Legend.Format = "<label>"
        m_Series.DataLabels.Text.Font = New System.Drawing.Font("Verdana", 6)
        m_Series.DataLabels.Mode = DataLabelsMode.None
        m_Series.Interactivity.TooltipMode = SeriesTooltipMode.Formatted
        m_Series.Interactivity.TooltipFormat = "<label>: <value>"

        Dim i As Integer = 0

        For i = 0 To ds.Tables(0).Rows.Count - 1

            Dim fe As New Xceed.Chart.Standard.FillEffect
            fe.SetSolidColor(GetColor(i))

            Dim color As Color = GetColor(i + 2)

            CType(m_Series, PieSeries).PieFillEffect.SetSolidColor(color)
            m_Series.Add(ds.Tables(0).Rows(i).Item(1).ToString().Trim(), ds.Tables(0).Rows(i).Item(0).ToString().Trim(), fe)

        Next

    End Sub

    Private Sub makeExplodedPieChart(ByVal ds As DataSet, ByVal m_Chart As Chart, ByVal vTitle As String)

        Dim m_Pie As PieSeries = Nothing
        m_Pie = CType(m_Chart.Series.Add(SeriesType.Pie), PieSeries)
        m_Pie.Appearance.FillMode = AppearanceFillMode.DataPoints
        m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
        m_Pie.Legend.Format = "<label>"
        m_Pie.PieStyle = PieStyle.SmoothEdgePie
        m_Pie.LabelMode = PieLabelMode.Center

        Dim i As Integer = 0

        For i = 0 To ds.Tables(0).Rows.Count - 1

            m_Pie.AddPie(ds.Tables(0).Rows(i).Item(1).ToString().Trim(), 5, ds.Tables(0).Rows(i).Item(0).ToString().Trim(), New FillEffect(GetColor(i)))

        Next

    End Sub

    Private Sub makeHorizontalBarChart(ByVal ds As DataSet, ByVal m_Chart As Chart, ByVal vTitle As String)

        Dim m_Series As Series = Nothing

        m_Series = CType(m_Chart.Series.Add(SeriesType.Bar), BarSeries)
        m_Series.Appearance.FillMode = AppearanceFillMode.DataPoints
        m_Chart.PredefinedChartStyle = PredefinedChartStyle.HorizontalLeft
        m_Series.Legend.Mode = SeriesLegendMode.DataPoints
        m_Series.Legend.Format = "<label>"
        m_Series.DataLabels.Text.Font = New System.Drawing.Font("Verdana", 6)
        m_Series.DataLabels.Mode = SeriesLegendMode.DataPoints
        m_Series.Interactivity.TooltipMode = SeriesTooltipMode.Formatted
        m_Series.Interactivity.TooltipFormat = "<label>: <value>"

        Dim i As Integer = 0

        For i = 0 To ds.Tables(0).Rows.Count - 1

            m_Series.Add(ds.Tables(0).Rows(i).Item(1).ToString().Trim(), ds.Tables(0).Rows(i).Item(0).ToString().Trim(), New FillEffect(GetColor(i)))

        Next

    End Sub

    Protected Function GetColor(ByVal i As Integer) As Color
        Return ChartColors(i)
    End Function

    'Protected Function GetColor(ByVal i As Integer) As Color
    '    i -= 1
    '    Do While i > 14
    '        i -= 14
    '    Loop
    '    If i < 0 Then i = 0
    '    Return ChartColors(i)
    'End Function

    'Pie Chart Properties
    Protected ReadOnly Property ChartColors(ByVal iColor As Integer) As Color
        Get

            Dim retColor As Color = Nothing
            If iColor > 13 Then iColor = 0

            Select Case iColor
                Case 0
                    retColor = ColorTranslator.FromHtml("#E2001A")
                Case 1
                    retColor = ColorTranslator.FromHtml("#E75113")
                Case 2
                    retColor = ColorTranslator.FromHtml("#F08A00")
                Case 3
                    retColor = ColorTranslator.FromHtml("#FABB00")
                Case 4
                    retColor = ColorTranslator.FromHtml("#FFED00")
                Case 5
                    retColor = ColorTranslator.FromHtml("#D4D700")
                Case 6
                    retColor = ColorTranslator.FromHtml("#009036")
                Case 7
                    retColor = ColorTranslator.FromHtml("#7BC6BC")
                Case 8
                    retColor = ColorTranslator.FromHtml("#009DD1")
                Case 9
                    retColor = ColorTranslator.FromHtml("#4F4794")
                Case 10
                    retColor = ColorTranslator.FromHtml("#622181")
                Case 11
                    retColor = ColorTranslator.FromHtml("#B6085A")
                Case 12
                    retColor = ColorTranslator.FromHtml("#D4145A")
                Case 13
                    retColor = ColorTranslator.FromHtml("#C69C6D")
            End Select

            Return retColor

        End Get
    End Property

End Class