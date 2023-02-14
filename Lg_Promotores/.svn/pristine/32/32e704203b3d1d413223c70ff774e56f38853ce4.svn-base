Imports Classes
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports Xceed.Chart.GraphicsCore
Imports Xceed.Chart.Standard
Imports Xceed.Chart.Core
Imports System.Collections.Generic

Partial Class reports_rptTotalMostruariosLDet
    Inherits XMReportPage
    Protected m_Chart As Xceed.Chart.Core.Chart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '    If Not Page.IsPostBack Then


        '        Dim rep As New clsReports
        '        Dim dr As IDataReader
        '        dr = rep.getRelatorioMostruarioTotalLinhas(Request("rg") & "", Request("es") & "", Request("tp") & "", Request("sh") & "", Request("lj") & "", Request("ct") & "", Request("pi"), Request("pf"))

        '        Dim imageFrame As ImageFrame

        '        Try

        '            ' setup background and borders

        '            With ChartServerControl1

        '                .Background.FillEffect.SetSolidColor(Color.White)
        '                .Background.FrameType = FrameType.Standard
        '                .Width = 820
        '                .Height = 400

        '                imageFrame = .Background.ImageFrame
        '                imageFrame.SetPredefinedFrameStyle(PredefinedImageFrame.Rectangular)
        '                imageFrame.FillEffect.SetSolidColor(Color.White)
        '                imageFrame.BackgroundColor = Color.White

        '                ' add a header label
        '                Dim header As ChartLabel = ChartServerControl1.Labels.AddHeader("Total de Mostruários - Fast Shop")
        '                header.TextProps.Backplane.Style = BackplaneStyle.Rectangle
        '                header.TextProps.Backplane.FillEffect.SetSolidColor(Color.White)
        '                header.TextProps.VertAlign = VertAlign.Top
        '                header.TextProps.HorzAlign = HorzAlign.Center
        '                header.VerticalMargin = 2

        '                Dim legend As Xceed.Chart.Core.Legend = .Legends.GetAt(0)
        '                legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right)
        '                legend.Backplane.FillEffect.SetTransparencyPercent(50)
        '                legend.HorizontalMargin = 15

        '                m_Chart = .Charts.GetAt(0)
        '                m_Chart.Axis(StandardAxis.Depth).Visible = False
        '                m_Chart.MarginMode = MarginMode.Stretch
        '                m_Chart.Margins = New RectangleF(20, 20, 75, 50)
        '                m_Chart.Width = 250
        '                m_Chart.Height = 150

        '                m_Chart.Axis(StandardAxis.PrimaryX).DimensionScale.AutoLabels = False
        '                m_Chart.Axis(StandardAxis.PrimaryX).Labels.Clear()

        '            End With

        '            Dim m_IdFornecedor As Integer = 0
        '            Dim bln_MontaColunas As Boolean = True
        '            Dim m_Bar As BarSeries

        '            Do While dr.Read

        '                If m_IdFornecedor <> dr("IdFornecedor") Then

        '                    m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), BarSeries)

        '                    If m_IdFornecedor > 0 Then
        '                        bln_MontaColunas = False
        '                    End If

        '                    With m_Bar

        '                        .Name = dr("Categoria")
        '                        .WidthPercent = 30
        '                        If m_Chart.Series.Count = 1 Then
        '                            .MultiBarMode = MultiBarMode.Series
        '                        Else
        '                            .MultiBarMode = MultiBarMode.Clustered
        '                        End If
        '                        .DataLabels.Format = "<value>"
        '                        .Shadow.Type = ShadowType.GaussianBlur
        '                        .Shadow.Offset = New PointF(3, 3)
        '                        .Shadow.Color = Color.FromArgb(30, 0, 0, 0)
        '                        .Shadow.FadeArea = 5
        '                        .Appearance.FillMode = AppearanceFillMode.Series
        '                        .Legend.Mode = SeriesLegendMode.Series

        '                        Select Case m_Chart.Series.Count
        '                            Case 1
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Red)
        '                            Case 2
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Blue)
        '                            Case 3
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Yellow)

        '                            Case 4
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Gray)
        '                            Case 5
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Brown)
        '                            Case 6
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Orchid)
        '                            Case 7
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.DarkSeaGreen)
        '                            Case 8
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Indigo)
        '                            Case 9
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.Black)
        '                            Case 10
        '                                .BarFillEffect.SetSolidColor(Drawing.Color.FloralWhite)
        '                        End Select

        '                    End With

        '                End If

        '                m_IdFornecedor = dr("IdFornecedor")

        '                m_Bar.Add(dr("Quantidade"))

        '                If bln_MontaColunas Then
        '                    m_Chart.Axis(StandardAxis.PrimaryX).Labels.Add(dr("Loja"))
        '                End If

        '            Loop

        '        Catch ex As Exception
        '            Response.Write(ex.Message)
        '        End Try

        '    End If

        'End Sub

        Dim rep As New clsReports
        Dim dr As IDataReader
        dr = rep.getRelatorioMostruarioTotalLinhas(Request("rg") & "", Request("es") & "", Request("tp") & "", Request("sh") & "", Request("lj") & "", Request("ct") & "", Request("pi"), Request("pf"))

        ChartServerControl1.Settings.RenderDevice = RenderDevice.OpenGL
        ChartServerControl1.Background.FillEffect.SetSolidColor(Color.White)
        ChartServerControl1.Background.FrameType = FrameType.Standard
        ChartServerControl1.Width = 820
        ChartServerControl1.Height = 400

        m_Chart = ChartServerControl1.Charts.GetAt(0)
        m_Chart.View.SetPredefinedProjection(PredefinedProjection.Orthogonal)
        m_Chart.MarginMode = MarginMode.Stretch
        m_Chart.Margins = New RectangleF(23, 12, 70, 80)
        m_Chart.Depth = 10

        'm_Chart.LightModel.EnableLighting = True
        'm_Chart.LightModel.SetPredefinedScheme(LightScheme.ShinyTopLeft)

        ' add a header text and modify the text properties
        Dim header1 As ChartLabel = ChartServerControl1.Labels.AddHeader("Total Mostruários - Fast Shop")
        header1.TextProps.Backplane.Visible = False
        header1.TextProps.HorzAlign = HorzAlign.Left
        header1.TextProps.VertAlign = VertAlign.Top
        header1.TextProps.FillEffect.SetSolidColor(Color.Black)
        header1.TextProps.Shadow.Type = ShadowType.None
        header1.HorizontalMargin = 2
        header1.VerticalMargin = 2

        Dim legend As Xceed.Chart.Core.Legend = ChartServerControl1.Legends.GetAt(0)
        legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right)
        legend.Backplane.FillEffect.SetTransparencyPercent(50)
        legend.HorizontalMargin = 15

        Dim imageFrame As ImageFrame = ChartServerControl1.Background.ImageFrame

        imageFrame.SetPredefinedFrameStyle(PredefinedImageFrame.Thin)
        imageFrame.FillEffect.SetSolidColor(Color.White)
        imageFrame.BackgroundColor = Color.White

        Dim m_IdFornecedor As Integer = 0
        Dim bln_MontaColunas As Boolean = True
        Dim m_Line As LineSeries

        Do While dr.Read

            If m_IdFornecedor <> dr("IdFornecedor") Then

                m_Line = CType(m_Chart.Series.Add(SeriesType.Line), LineSeries)

                If m_IdFornecedor > 0 Then
                    bln_MontaColunas = False
                End If

                With m_Line

                    .Name = dr("SubCategoria")
                    .MultiLineMode = MultiLineMode.Series
                    .LineStyle = LineSeriesStyle.Line
                    .DataLabels.Mode = DataLabelsMode.Every
                    .Legend.Mode = SeriesLegendMode.Series
                    .LineBorder.Color = GetColor(m_Chart.Series.Count)
                    .LineFillEffect.SetSolidColor(GetColor(m_Chart.Series.Count))
                    .DepthPercent = 10

                End With

            End If

            m_IdFornecedor = dr("IdFornecedor")

            m_Line.Add(dr("Quantidade"))

            If bln_MontaColunas Then
                m_Chart.Axis(StandardAxis.PrimaryX).Labels.Add(dr("Inicio").ToString)
            End If

        Loop

    End Sub


End Class
