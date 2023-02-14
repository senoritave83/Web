Imports Classes
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports Xceed.Chart.GraphicsCore
Imports Xceed.Chart.Standard
Imports Xceed.Chart.Core
Imports System.Collections.Generic

Partial Class reports_rptTotalMostruariosDet
    Inherits XMReportPage

    Protected m_Chart As Xceed.Chart.Core.Chart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then


            Dim rep As New clsReports
            Dim dr As IDataReader
            dr = rep.getRelatorioMostruarioTotal(Request("rg") & "", Request("est") & "", Request("tp") & "", Request("sh") & "", Request("lj") & "", Request("ct") & "", Request("pi"), Request("pf"))

            Dim imageFrame As ImageFrame

            Try

                ' setup background and borders

                With ChartServerControl1

                    .Background.FillEffect.SetSolidColor(Color.White)
                    .Background.FrameType = FrameType.Standard
                    .Width = 820
                    .Height = 400

                    imageFrame = .Background.ImageFrame
                    imageFrame.SetPredefinedFrameStyle(PredefinedImageFrame.Rectangular)
                    imageFrame.FillEffect.SetSolidColor(Color.White)
                    imageFrame.BackgroundColor = Color.White

                    ' add a header label
                    Dim header As ChartLabel = ChartServerControl1.Labels.AddHeader("Total de Mostruários - Fast Shop")
                    header.TextProps.Backplane.Style = BackplaneStyle.Rectangle
                    header.TextProps.Backplane.FillEffect.SetSolidColor(Color.White)
                    header.TextProps.VertAlign = VertAlign.Top
                    header.TextProps.HorzAlign = HorzAlign.Center
                    header.VerticalMargin = 2

                    Dim legend As Xceed.Chart.Core.Legend = .Legends.GetAt(0)
                    legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Right)
                    legend.Backplane.FillEffect.SetTransparencyPercent(50)
                    legend.HorizontalMargin = 15

                    m_Chart = .Charts.GetAt(0)
                    m_Chart.Axis(StandardAxis.Depth).Visible = False
                    m_Chart.MarginMode = MarginMode.Stretch
                    m_Chart.Margins = New RectangleF(20, 20, 75, 50)
                    m_Chart.Width = 250
                    m_Chart.Height = 150

                    m_Chart.Axis(StandardAxis.PrimaryX).DimensionScale.AutoLabels = False
                    m_Chart.Axis(StandardAxis.PrimaryX).Labels.Clear()

                End With

                Dim m_IdFornecedor As Integer = 0
                Dim bln_MontaColunas As Boolean = True
                Dim m_Bar As BarSeries

                Do While dr.Read

                    If m_IdFornecedor <> dr("IdFornecedor") Then

                        m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), BarSeries)

                        If m_IdFornecedor > 0 Then
                            bln_MontaColunas = False
                        End If

                        With m_Bar

                            .Name = dr("Categoria")
                            .WidthPercent = 30
                            If m_Chart.Series.Count = 1 Then
                                .MultiBarMode = MultiBarMode.Series
                            Else
                                .MultiBarMode = MultiBarMode.Clustered
                            End If
                            .DataLabels.Format = "<value>"                            
                            .Shadow.Type = ShadowType.GaussianBlur
                            .Shadow.Offset = New PointF(3, 3)
                            .Shadow.Color = Color.FromArgb(30, 0, 0, 0)
                            .Shadow.FadeArea = 5
                            .Appearance.FillMode = AppearanceFillMode.Series
                            .Legend.Mode = SeriesLegendMode.Series

                            .BarFillEffect.SetSolidColor(GetColor(m_Chart.Series.Count))

                        End With

                    End If

                    m_IdFornecedor = dr("IdFornecedor")

                    m_Bar.Add(dr("Quantidade"))

                    If bln_MontaColunas Then
                        m_Chart.Axis(StandardAxis.PrimaryX).Labels.Add(dr("Loja"))
                    End If

                Loop

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End If

    End Sub

End Class
