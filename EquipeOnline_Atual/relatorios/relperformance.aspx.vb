Imports System.Drawing
Imports VM.xPort
Imports System.IO

Partial Class relatorios_relperformance
    Inherits XMProtectedPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()

        If Not IsPostBack Then
            txtDataFinal.Text = FormatDateTime(Now, DateFormat.ShortDate)
            txtDataInicial.Text = FormatDateTime(Now.AddMonths(-1), DateFormat.ShortDate)
        End If
        intTotal = 0
        blnTotal = False
        grdRelatorio.DataSource = cls.GetReport_Performance(txtDataInicial.Text, txtDataFinal.Text)
        grdRelatorio.DataBind()

        Dim strScript As String = "<scrip" & "t type='text/javascript'>" & vbCrLf
        strScript &= "          function printReport(){" & vbCrLf
        strScript &= "            var win = window.open('relperformance_prn.aspx?di=" & txtDataInicial.Text & _
                                                                    "&df=" & txtDataFinal.Text & "','IMPRIMIR_RELATORIO_PERFORMANCE','width=950, height=600,status=no,scrollbars=yes,toolbar=no,top=20,left=20');" & vbCrLf
        strScript &= "            win.focus();" & vbCrLf
        strScript &= "}" & vbCrLf
        strScript &= "</scri" & "pt>"

        ltScript.Text = strScript

    End Sub

    Protected Function GetPercentage(ByVal vTotal As Integer, ByVal vRealizadas As Integer) As Integer
        If vTotal = 0 Or vRealizadas = 0 Then
            Return 0
        Else
            Return ((vRealizadas * 85) / vTotal)
        End If
    End Function

    Protected Function GetPercentageExport(ByVal vTotal As Integer, ByVal vRealizadas As Integer) As Double
        If vTotal = 0 Or vRealizadas = 0 Then
            Return 0
        Else
            Return ((vRealizadas / vTotal))
        End If
    End Function

    Private Sub setStyle(ByVal p_XPort As VM.xPort.DS2XL, ByVal p_DataTable As System.Data.DataTable)

        Dim headerStyle As VM.xPort.Style
        Dim contentStyle As VM.xPort.Style
        Dim customFont As System.Drawing.Font

        'Define style for the header. 
        headerStyle = New VM.xPort.Style("HeaderStyle", p_DataTable.TableName, -1, 0, -1, p_DataTable.Columns.Count - 1)

        'Create font that will be used to format header text.
        customFont = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
        With headerStyle
            .Font = customFont
            .HorizontalAlignment = Style.xpHAlignment.Center
            .VerticalAlignment = Style.xpVAlignment.Center
            .TopBorderLine = Style.xpBorderLineStyle.Double
            .TopBorderColor = Color.Beige
            .BottomBorderLine = Style.xpBorderLineStyle.Double
            .BottomBorderColor = Color.Beige
            .LeftBorderLine = Style.xpBorderLineStyle.Thin
            .LeftBorderColor = Color.Beige
            .RightBorderLine = Style.xpBorderLineStyle.Thin
            .RightBorderColor = Color.Beige
            .BackgroundColor = Color.FromArgb(0, 184, 204, 228)
            .UnderlineStyle = Style.xpUnderlineStyle.Double
        End With
        p_XPort.Styles.Add(headerStyle)

        contentStyle = New Style("ContentStyle", p_DataTable.TableName, 0, 0, p_DataTable.Rows.Count - 1, p_DataTable.Columns.Count - 1)
        With contentStyle
            customFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular)
            contentStyle.Font = customFont
            contentStyle.HorizontalAlignment = Style.xpHAlignment.Left
            contentStyle.VerticalAlignment = Style.xpVAlignment.Center
            contentStyle.WrapText = True
            contentStyle.ForeColor = Color.Navy
        End With
        p_XPort.Styles.Add(contentStyle)

    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click

        Dim loXPort As VM.xPort.DS2XL
        Dim exportStream As MemoryStream
        Dim bytearray() As Byte
        cls = New clsRelatorio()
        Dim dsExcel As DataSet = cls.GetReport_Performance(txtDataInicial.Text, txtDataFinal.Text)

        If Not dsExcel Is Nothing Then

            dsExcel.Tables(0).Columns.Add("Performance")

            Dim i As Integer = 0
            For i = 0 To dsExcel.Tables(0).Rows.Count - 1
                dsExcel.Tables(0).Rows(i).Item(4) = FormatPercent(GetPercentageExport(dsExcel.Tables(0).Rows(i).Item(2), dsExcel.Tables(0).Rows(i).Item(3)))
            Next

            loXPort = New DS2XL()
            setStyle(loXPort, dsExcel.Tables(0))

            exportStream = loXPort.ExportToStream(dsExcel, xpOutputFormat.XLSX, True)
            bytearray = exportStream.ToArray
            exportStream.Flush()
            exportStream.Close()

            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=Relatorio_OS_Performance_" & Now().ToString("yyyyMMdd-hhmmss") & ".xlsx")
            Response.AddHeader("Content-Length", bytearray.Length.ToString())
            Response.ContentType = "Application/xlsx"
            Response.BinaryWrite(bytearray)
            Response.Flush()
            Response.Close()

            loXPort = Nothing
            dsExcel = Nothing

        End If

    End Sub

End Class
