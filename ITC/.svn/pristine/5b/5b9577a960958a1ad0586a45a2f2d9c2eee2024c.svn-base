Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class XMChartGenerator

    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim bgColor As Color
        Dim xValues, yValues, height, width
        Dim strTitulo As String = Page.Request("Titulo")
        Dim boolPrint As Boolean
        Dim StockBitMap As Bitmap
        Dim memStream As New MemoryStream()
        Dim bar As XMSISTEMAS.CHARTS.BarGraph

        xValues = Page.Request("xValues")
        yValues = Page.Request("yValues")
        height = Page.Request("height")
        width = Page.Request("width")

        If Not IsNumeric(width) Then width = 100
        If Not IsNumeric(height) Then height = 100

        boolPrint = True
        If boolPrint Then
            bgColor = Color.White
        Else
            bgColor = Color.FromArgb(255, 253, 244)
        End If

        bar = New XMSISTEMAS.CHARTS.BarGraph(bgColor)

        bar.VerticalLabel = ""
        bar.VerticalTickCount = 10
        bar.ShowLegend = True
        bar.ShowData = True
        bar.Height = height
        bar.Width = width

        bar.CollectDataPoints(xValues.Split("|".ToCharArray()), yValues.Split("|".ToCharArray()))
        StockBitMap = bar.Draw()
        StockBitMap.Save(memStream, ImageFormat.Png)
        memStream.WriteTo(Response.OutputStream)

    End Sub

End Class
