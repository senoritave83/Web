Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace XMSISTEMAS.CHARTS

    '*********************************************************************
    '
    ' BarGraph Class
    '
    ' This class uses GDI+ to render Bar Chart.
    '
    '*********************************************************************

    Public Class BarGraph
        Inherits Chart
        Private _graphLegendSpacer As Single = 15.0F
        Private _labelFontSize As Integer = 7
        Private _legendFontSize As Integer = 7
        Private _legendRectangleSize As Single = 10.0F
        Private _spacer As Single = 5.0F

        ' Overall related members
        Private _backColor As Color
        Private _fontFamily As String
        Private _longestTickValue As String = String.Empty ' Used to calculate max value width
        Private _maxTickValueWidth As Single ' Used to calculate left offset of bar graph
        Private _totalHeight As Single
        Private _totalWidth As Single

        ' Graph related members
        Private _barWidth As Single
        Private _bottomBuffer As Single ' Space from bottom to x axis
        Private _displayBarData As Boolean
        Private _fontColor As Color
        Private _graphHeight As Single
        Private _graphWidth As Single
        Private _maxValue As Single = 0.0F ' = final tick value * tick count
        Private _scaleFactor As Single ' = _maxValue / _graphHeight
        Private _spaceBtwBars As Single ' For now same as _barWidth
        Private _topBuffer As Single ' Space from top to the top of y axis
        Private _xOrigin As Single ' x position where graph starts drawing
        Private _yOrigin As Single ' y position where graph starts drawing
        Private _yLabel As String
        Private _yTickCount As Integer
        Private _yTickValue As Single ' Value for each tick = _maxValue/_yTickCount
        ' Legend related members
        Private _displayLegend As Boolean
        Private _legendWidth As Single
        Private _longestLabel As String = String.Empty ' Used to calculate legend width
        Private _maxLabelWidth As Single = 0.0F

        Public Property FontFamily() As String
            Get
                Return _fontFamily
            End Get
            Set(ByVal Value As String)
                _fontFamily = Value
            End Set
        End Property

        Public WriteOnly Property BackgroundColor() As Color
            Set(ByVal Value As Color)
                _backColor = Value
            End Set
        End Property

        Public WriteOnly Property BottomBuffer() As Integer
            Set(ByVal Value As Integer)
                _bottomBuffer = Convert.ToSingle(Value)
            End Set
        End Property

        Public WriteOnly Property FontColor() As Color
            Set(ByVal Value As Color)
                _fontColor = Value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return Convert.ToInt32(_totalHeight)
            End Get
            Set(ByVal Value As Integer)
                _totalHeight = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property Width() As Integer
            Get
                Return Convert.ToInt32(_totalWidth)
            End Get
            Set(ByVal Value As Integer)
                _totalWidth = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property ShowLegend() As Boolean
            Get
                Return _displayLegend
            End Get
            Set(ByVal Value As Boolean)
                _displayLegend = Value
            End Set
        End Property

        Public Property ShowData() As Boolean
            Get
                Return _displayBarData
            End Get
            Set(ByVal Value As Boolean)
                _displayBarData = Value
            End Set
        End Property

        Public WriteOnly Property TopBuffer() As Integer
            Set(ByVal Value As Integer)
                _topBuffer = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property VerticalLabel() As String
            Get
                Return _yLabel
            End Get
            Set(ByVal Value As String)
                _yLabel = Value
            End Set
        End Property

        Public Property VerticalTickCount() As Integer
            Get
                Return _yTickCount
            End Get
            Set(ByVal Value As Integer)
                _yTickCount = Value
            End Set
        End Property

        Public Sub New()
            AssignDefaultSettings()
        End Sub 'New

        Public Sub New(ByVal bgColor As Color)
            AssignDefaultSettings()
            BackgroundColor = bgColor
        End Sub 'New

        '*********************************************************************
        '
        ' This method collects all data points and calculate all the necessary dimensions 
        ' to draw the bar graph.  It is the method called before invoking the Draw() method.
        ' labels is the x values.
        ' values is the y values.
        '
        '*********************************************************************

        Public Overloads Sub CollectDataPoints(ByVal labels() As String, ByVal values() As String)
            If labels.Length = values.Length Then
                Dim i As Integer
                For i = 0 To labels.Length - 1
                    Dim temp As Single = Convert.ToSingle(values(i))
                    Dim shortLbl As String = "" 'MakeShortLabel(labels(i))

                    ' For now put 0.0 for start position and sweep size
                    DataPoints.Add(New ChartItem(shortLbl, labels(i), temp, 0.0F, 0.0F, GetColor(i)))

                    ' Find max value from data; this is only temporary _maxValue
                    If _maxValue < temp Then
                        _maxValue = temp
                    End If
                    ' Find the longest description
                    If _displayLegend Then
                        Dim currentLbl As String = labels(i) + " (" + shortLbl + ")"
                        Dim currentWidth As Single = CalculateImgFontWidth(currentLbl, _legendFontSize, FontFamily)
                        If _maxLabelWidth < currentWidth Then
                            _longestLabel = currentLbl
                            _maxLabelWidth = currentWidth
                        End If
                    End If
                Next i

                CalculateTickAndMax()
                CalculateGraphDimension()
                CalculateBarWidth(DataPoints.Count, _graphWidth)
                CalculateSweepValues()
            Else
                Throw New Exception("X data count is different from Y data count")
            End If
        End Sub 'CollectDataPoints

        '*********************************************************************
        '
        ' Same as above; called when user doesn't care about the x values
        '
        '*********************************************************************

        Public Overloads Sub CollectDataPoints(ByVal values() As String)
            Dim labels As String() = values
            CollectDataPoints(labels, values)
        End Sub 'CollectDataPoints

        '*********************************************************************
        '
        ' This method returns a bar graph bitmap to the calling function.  It is called after 
        ' all dimensions and data points are calculated.
        '
        '*********************************************************************

        Public Overrides Function Draw() As Bitmap
            Dim height As Integer = Convert.ToInt32(_totalHeight)
            Dim width As Integer = Convert.ToInt32(_totalWidth)

            Dim bmp As New Bitmap(width, height)
            Dim graph As Graphics = Nothing

            Try
                graph = Graphics.FromImage(bmp)
                graph.CompositingQuality = CompositingQuality.HighQuality
                graph.SmoothingMode = SmoothingMode.AntiAlias

                ' Set the background: need to draw one pixel larger than the bitmap to cover all area
                graph.FillRectangle(New SolidBrush(_backColor), -1, -1, bmp.Width + 1, bmp.Height + 1)

                DrawVerticalLabelArea(graph)
                DrawBars(graph)
                DrawXLabelArea(graph)
                If _displayLegend Then
                    DrawLegend(graph)
                End If

            Finally
                If Not (graph Is Nothing) Then
                    graph.Dispose()
                End If
            End Try

            Return bmp
        End Function 'Draw

        '*********************************************************************
        '
        ' This method draws all the bars for the graph.
        '
        '*********************************************************************

        Private Sub DrawBars(ByVal graph As Graphics)
            Dim brsFont As SolidBrush = Nothing
            Dim valFont As Font = Nothing
            Dim sfFormat As StringFormat = Nothing

            Try
                brsFont = New SolidBrush(_fontColor)
                valFont = New Font(_fontFamily, _labelFontSize)
                sfFormat = New StringFormat()
                sfFormat.Alignment = StringAlignment.Center
                Dim i As Integer = 0

                ' Draw bars and the value above each bar
                Dim item As ChartItem
                For Each item In DataPoints
                    Dim barBrush As SolidBrush = Nothing
                    Try
                        barBrush = New SolidBrush(item.ItemColor)
                        Dim itemY As Single = _yOrigin + _graphHeight - item.SweepSize

                        ' When drawing, all position is relative to (_xOrigin, _yOrigin)
                        graph.FillRectangle(barBrush, _xOrigin + item.StartPos, itemY, _barWidth, item.SweepSize)

                        ' Draw data value
                        If _displayBarData Then
                            Dim startX As Single = _xOrigin + i * (_barWidth + _spaceBtwBars) ' This draws the value on center of the bar
                            Dim startY As Single = itemY - 2.0F - valFont.Height ' Positioned on top of each bar by 2 pixels
                            Dim recVal As New RectangleF(startX, startY, _barWidth + _spaceBtwBars, valFont.Height)
                            graph.DrawString(item.Value.ToString("#,###.##"), valFont, brsFont, recVal, sfFormat)
                        End If
                        i += 1
                    Finally
                        If Not (barBrush Is Nothing) Then
                            barBrush.Dispose()
                        End If
                    End Try
                Next item
            Finally
                If Not (brsFont Is Nothing) Then
                    brsFont.Dispose()
                End If
                If Not (valFont Is Nothing) Then
                    valFont.Dispose()
                End If
                If Not (sfFormat Is Nothing) Then
                    sfFormat.Dispose()
                End If
            End Try
        End Sub 'DrawBars

        '*********************************************************************
        '
        ' This method draws the y label, tick marks, tick values, and the y axis.
        '
        '*********************************************************************

        Private Sub DrawVerticalLabelArea(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As Pen = Nothing
            Dim sfVLabel As StringFormat = Nothing

            Try
                lblFont = New Font(_fontFamily, _labelFontSize)
                brs = New SolidBrush(_fontColor)
                lblFormat = New StringFormat()
                pen = New Pen(_fontColor)
                sfVLabel = New StringFormat()

                lblFormat.Alignment = StringAlignment.Near

                ' Draw vertical label at the top of y-axis and place it in the middle top of y-axis
                Dim recVLabel As New RectangleF(0.0F, _yOrigin - 2 * _spacer - lblFont.Height, _xOrigin * 2, lblFont.Height)
                sfVLabel.Alignment = StringAlignment.Center
                graph.DrawString(_yLabel, lblFont, brs, recVLabel, sfVLabel)

                ' Draw all tick values and tick marks
                Dim i As Integer
                For i = 0 To _yTickCount - 1
                    Dim currentY As Single = _topBuffer + i * _yTickValue / _scaleFactor ' Position for tick mark
                    Dim labelY As Single = currentY - lblFont.Height / 2 ' Place label in the middle of tick
                    Dim lblRec As New RectangleF(_spacer, labelY, _maxTickValueWidth, lblFont.Height)
                    Dim currentTick As Single = _maxValue - i * _yTickValue ' Calculate tick value from top to bottom
                    graph.DrawString(currentTick.ToString("#,###.##"), lblFont, brs, lblRec, lblFormat) ' Draw tick value  
                    graph.DrawLine(pen, _xOrigin, currentY, _xOrigin - 4.0F, currentY) ' Draw tick mark
                Next i

                ' Draw y axis
                graph.DrawLine(pen, _xOrigin, _yOrigin, _xOrigin, _yOrigin + _graphHeight)
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
                If Not (sfVLabel Is Nothing) Then
                    sfVLabel.Dispose()
                End If
            End Try
        End Sub 'DrawVerticalLabelArea

        '*********************************************************************
        '
        ' This method draws x axis and all x labels
        '
        '*********************************************************************

        Private Sub DrawXLabelArea(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As Pen = Nothing

            Try
                lblFont = New Font(_fontFamily, _labelFontSize)
                brs = New SolidBrush(_fontColor)
                lblFormat = New StringFormat()
                pen = New Pen(_fontColor)

                lblFormat.Alignment = StringAlignment.Center

                ' Draw x axis
                graph.DrawLine(pen, _xOrigin, _yOrigin + _graphHeight, _xOrigin + _graphWidth, _yOrigin + _graphHeight)

                Dim currentX As Single
                Dim currentY As Single = _yOrigin + _graphHeight + 2.0F ' All x labels are drawn 2 pixels below x-axis
                Dim labelWidth As Single = _barWidth + _spaceBtwBars ' Fits exactly below the bar
                Dim i As Integer = 0

                ' Draw x labels
                Dim item As ChartItem
                For Each item In DataPoints
                    currentX = _xOrigin + i * labelWidth
                    Dim recLbl As New RectangleF(currentX, currentY, labelWidth, lblFont.Height)
                    Dim lblString As String = IIf(_displayLegend, item.Label, item.Description)
                    graph.DrawString(lblString, lblFont, brs, recLbl, lblFormat)
                    i += 1
                Next item
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
            End Try
        End Sub 'DrawXLabelArea

        '*********************************************************************
        '
        ' This method determines where to place the legend box.
        ' It draws the legend border, legend description, and legend color code.
        '
        '*********************************************************************

        Private Sub DrawLegend(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As Pen = Nothing

            Try
                lblFont = New Font(_fontFamily, _legendFontSize)
                brs = New SolidBrush(_fontColor)
                lblFormat = New StringFormat()
                pen = New Pen(_fontColor)
                lblFormat.Alignment = StringAlignment.Near

                ' Calculate Legend drawing start point
                Dim startX As Single = _xOrigin + _graphWidth + _graphLegendSpacer
                Dim startY As Single = _yOrigin

                Dim xColorCode As Single = startX + _spacer
                Dim xLegendText As Single = xColorCode + _legendRectangleSize + _spacer
                Dim legendHeight As Single = 0.0F
                Dim i As Integer
                For i = 0 To DataPoints.Count - 1
                    Dim point As ChartItem = DataPoints(i)
                    Dim [text] As String = point.Description '+ " (" + point.Label + ")"
                    Dim currentY As Single = startY + _spacer + i * (lblFont.Height + _spacer)
                    legendHeight += lblFont.Height + _spacer

                    ' Draw legend description
                    graph.DrawString([text], lblFont, brs, xLegendText, currentY, lblFormat)

                    ' Draw color code
                    graph.FillRectangle(New SolidBrush(DataPoints(i).ItemColor), xColorCode, currentY + 3.0F, _legendRectangleSize, _legendRectangleSize)
                Next i

                ' Draw legend border
                graph.DrawRectangle(pen, startX, startY, _legendWidth, legendHeight + _spacer)
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
            End Try
        End Sub 'DrawLegend

        '*********************************************************************
        '
        ' This method calculates all measurement aspects of the bar graph from the given data points
        '
        '*********************************************************************

        Private Sub CalculateGraphDimension()
            FindLongestTickValue()

            ' Need to add another character for spacing; this is not used for drawing, just for calculation
            _longestTickValue += "0"
            _maxTickValueWidth = CalculateImgFontWidth(_longestTickValue, _labelFontSize, FontFamily)
            Dim leftOffset As Single = _spacer + _maxTickValueWidth
            Dim rtOffset As Single = 0.0F

            If _displayLegend Then
                _legendWidth = _spacer + _legendRectangleSize + _spacer + _maxLabelWidth + _spacer
                rtOffset = _graphLegendSpacer + _legendWidth + _spacer
            Else
                rtOffset = _spacer ' Make graph in the middle
            End If
            _graphHeight = _totalHeight - _topBuffer - _bottomBuffer ' Buffer spaces are used to print labels
            _graphWidth = _totalWidth - leftOffset - rtOffset
            _xOrigin = leftOffset
            _yOrigin = _topBuffer

            ' Once the correct _maxValue is determined, then calculate _scaleFactor
            _scaleFactor = _maxValue / _graphHeight
        End Sub 'CalculateGraphDimension

        '*********************************************************************
        '
        ' This method determines the longest tick value from the given data points.
        ' The result is needed to calculate the correct graph dimension.
        '
        '*********************************************************************

        Private Sub FindLongestTickValue()
            Dim currentTick As Single
            Dim tickString As String
            Dim i As Integer
            For i = 0 To _yTickCount - 1
                currentTick = _maxValue - i * _yTickValue
                tickString = currentTick.ToString("#,###.##")
                If _longestTickValue.Length < tickString.Length Then
                    _longestTickValue = tickString
                End If
            Next i
        End Sub 'FindLongestTickValue

        '*********************************************************************
        '
        ' This method calculates the image width in pixel for a given text
        '
        '*********************************************************************

        Private Function CalculateImgFontWidth(ByVal [text] As String, ByVal size As Integer, ByVal family As String) As Single
            Dim bmp As Bitmap = Nothing
            Dim graph As Graphics = Nothing
            Dim font As Font = Nothing

            Try
                font = New Font(family, size)

                ' Calculate the size of the string.
                bmp = New Bitmap(1, 1, PixelFormat.Format32bppArgb)
                graph = Graphics.FromImage(bmp)
                Dim oSize As SizeF = graph.MeasureString([text], font)

                Return oSize.Width
            Finally
                If Not (graph Is Nothing) Then
                    graph.Dispose()
                End If
                If Not (bmp Is Nothing) Then
                    bmp.Dispose()
                End If
                If Not (font Is Nothing) Then
                    font.Dispose()
                End If
            End Try
        End Function 'CalculateImgFontWidth

        '*********************************************************************
        '
        ' This method creates abbreviation from long description; used for making legend
        '
        '*********************************************************************

        Private Function MakeShortLabel(ByVal [text] As String) As String
            Dim label As String = [text]
            Return label.Substring(label.Length - 5)
            If [text].Length > 2 Then
                Dim midPostition As Integer = Convert.ToInt32(Math.Floor(([text].Length / 2)))
                label = [text].Substring(0, 1) + [text].Substring(midPostition, 1) + [text].Substring([text].Length - 1, 1)
            End If
            Return label
        End Function 'MakeShortLabel

        '*********************************************************************
        '
        ' This method calculates the max value and each tick mark value for the bar graph.
        '
        '*********************************************************************

        Private Sub CalculateTickAndMax()
            Dim tempMax As Single = 0.0F

            ' Give graph some head room first about 10% of current max
            _maxValue *= 1.1F

            If _maxValue <> 0.0F Then
                ' Find a rounded value nearest to the current max value
                ' Calculate this max first to give enough space to draw value on each bar
                Dim exp As Double = Convert.ToDouble(Math.Floor(Math.Log10(_maxValue)))
                tempMax = Convert.ToSingle((Math.Ceiling((_maxValue / Math.Pow(10, exp))) * Math.Pow(10, exp)))
            Else
                tempMax = 1.0F
            End If
            ' Once max value is calculated, tick value can be determined; tick value should be a whole number
            _yTickValue = tempMax / _yTickCount
            Dim expTick As Double = Convert.ToDouble(Math.Floor(Math.Log10(_yTickValue)))
            _yTickValue = Convert.ToSingle((Math.Ceiling((_yTickValue / Math.Pow(10, expTick))) * Math.Pow(10, expTick)))

            ' Re-calculate the max value with the new tick value
            _maxValue = _yTickValue * _yTickCount
        End Sub 'CalculateTickAndMax

        '*********************************************************************
        '
        ' This method calculates the height for each bar in the graph
        '
        '*********************************************************************

        Private Sub CalculateSweepValues()
            ' Called when all values and scale factor are known
            ' All values calculated here are relative from (_xOrigin, _yOrigin)
            Dim i As Integer = 0
            Dim item As ChartItem
            For Each item In DataPoints
                ' This implementation does not support negative value
                If item.Value >= 0 Then
                    item.SweepSize = item.Value / _scaleFactor
                End If
                ' (_spaceBtwBars/2) makes half white space for the first bar
                item.StartPos = _spaceBtwBars / 2 + i * (_barWidth + _spaceBtwBars)
                i += 1
            Next item
        End Sub 'CalculateSweepValues

        '*********************************************************************
        '
        ' This method calculates the width for each bar in the graph
        '
        '*********************************************************************

        Private Sub CalculateBarWidth(ByVal dataCount As Integer, ByVal barGraphWidth As Single)
            ' White space between each bar is the same as bar width itself
            _barWidth = barGraphWidth / (dataCount * 2) ' Each bar has 1 white space 
            _spaceBtwBars = _barWidth
        End Sub 'CalculateBarWidth

        '*********************************************************************
        '
        ' This method assigns default value to the bar graph properties and is only 
        ' called from BarGraph constructors
        '
        '*********************************************************************

        Private Sub AssignDefaultSettings()
            ' default values
            _totalWidth = 700.0F
            _totalHeight = 450.0F
            _fontFamily = "Verdana"
            _backColor = Color.White
            _fontColor = Color.Black
            _topBuffer = 30.0F
            _bottomBuffer = 30.0F
            _yTickCount = 2
            _displayLegend = False
            _displayBarData = False
        End Sub 'AssignDefaultSettings
    End Class 'BarGraph

    Public MustInherit Class Chart
        Private _colorLimit As Integer = 12

        Private _color As Color() = {Color.Chocolate, Color.YellowGreen, Color.Olive, Color.DarkKhaki, Color.Sienna, Color.PaleGoldenrod, Color.Peru, Color.Tan, Color.Khaki, Color.DarkGoldenrod, Color.Maroon, Color.OliveDrab}

        ' Represent collection of all data points for the chart
        Private _dataPoints As New ChartItemsCollection()

        ' The implementation of this method is provided by derived classes
        Public MustOverride Function Draw() As Bitmap

        Public Property DataPoints() As ChartItemsCollection
            Get
                Return _dataPoints
            End Get
            Set(ByVal Value As ChartItemsCollection)
                _dataPoints = Value
            End Set
        End Property

        Public Sub SetColor(ByVal index As Integer, ByVal NewColor As Color)
            If index < _colorLimit Then
                _color(index) = NewColor
            Else
                Throw New Exception("Color Limit is " + _colorLimit)
            End If
        End Sub 'SetColor

        Public Function GetColor(ByVal index As Integer) As Color
            If index < _colorLimit Then
                Return _color(index)
            Else
                Throw New Exception("Color Limit is " + _colorLimit)
            End If
        End Function 'GetColor
    End Class 'Chart

    Public Class ChartItem
        Private _label As String
        Private _description As String
        Private _value As Single
        Private _color As Color
        Private _startPos As Single
        Private _sweepSize As Single

        Private Sub New()
        End Sub 'New

        Public Sub New(ByVal label As String, ByVal desc As String, ByVal data As Single, ByVal start As Single, ByVal sweep As Single, ByVal clr As Color)
            _label = label
            _description = desc
            _value = data
            _startPos = start
            _sweepSize = sweep
            _color = clr
        End Sub 'New

        Public Property Label() As String
            Get
                Return _label
            End Get
            Set(ByVal Value As String)
                _label = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property Value() As Single
            Get
                Return _value
            End Get
            Set(ByVal Value As Single)
                _value = Value
            End Set
        End Property

        Public Property ItemColor() As Color
            Get
                Return _color
            End Get
            Set(ByVal Value As Color)
                _color = Value
            End Set
        End Property

        Public Property StartPos() As Single
            Get
                Return _startPos
            End Get
            Set(ByVal Value As Single)
                _startPos = Value
            End Set
        End Property

        Public Property SweepSize() As Single
            Get
                Return _sweepSize
            End Get
            Set(ByVal Value As Single)
                _sweepSize = Value
            End Set
        End Property
    End Class 'ChartItem

    '*********************************************************************
    '
    ' Custom Collection for ChartItems
    '
    '*********************************************************************

    Public Class ChartItemsCollection
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As ChartItem
            Get
                Return CType(List(index), ChartItem)
            End Get
            Set(ByVal Value As ChartItem)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As ChartItem) As Integer
            Return List.Add(value)
        End Function 'Add

        Public Function IndexOf(ByVal value As ChartItem) As Integer
            Return List.IndexOf(value)
        End Function 'IndexOf

        Public Function Contains(ByVal value As ChartItem) As Boolean
            Return List.Contains(value)
        End Function 'Contains

        Public Sub Remove(ByVal value As ChartItem)
            List.Remove(value)
        End Sub 'Remove
    End Class 'ChartItemsCollection

End Namespace
