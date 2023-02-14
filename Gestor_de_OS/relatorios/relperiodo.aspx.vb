Imports Xceed.Chart.GraphicsCore
Imports Xceed.Chart.Standard
Imports Xceed.Chart.Core
Imports System.Drawing
Imports VM.xPort
Imports System.IO

Partial Class relatorios_relperiodo
    Inherits XMReportPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False
    Protected strDataInicial As String = ""
    Protected strDataFinal As String = ""
    
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If cboTipoGrafico.SelectedValue = "Linhas" Then
            trMensagem.Visible = True
        Else
            trMensagem.Visible = False
        End If

        cls = New clsRelatorio()

        If Not IsPostBack Then
            txtDataFinal.Text = FormatDateTime(Now, DateFormat.ShortDate)
            txtDataInicial.Text = FormatDateTime(Now.AddMonths(-1), DateFormat.ShortDate)
        End If
        intTotal = 0
        blnTotal = False

        Dim ds As DataSet = Nothing

        If cboTipoGrafico.SelectedValue = "Tabular" Then

            ds = cls.GetReport_Periodo(txtDataInicial.Text, txtDataFinal.Text)

            grdRelatorio.DataSource = ds
            grdRelatorio.DataBind()
            grdRelatorio.Visible = True
            chartEOL.Visible = False

            strDataInicial = txtDataInicial.Text
            strDataFinal = txtDataFinal.Text

            btnExportar.Visible = True

        Else

            If cboTipoGrafico.SelectedValue = "Linhas" Then
                ds = cls.GetReport_Periodo_Linha(txtDataInicial.Text, txtDataFinal.Text)

                strDataInicial = txtDataInicial.Text
                strDataFinal = txtDataFinal.Text
            Else
                ds = cls.GetReport_Periodo(txtDataInicial.Text, txtDataFinal.Text)

                strDataInicial = txtDataInicial.Text
                strDataFinal = txtDataFinal.Text
            End If

            btnExportar.Visible = False
            grdRelatorio.Visible = False
            chartEOL.Visible = True

            If ds.Tables.Count > 0 Then
                chartEOL.Visible = ds.Tables(0).Rows.Count > 0
            End If

            MakeChart(ds, cboTipoGrafico.SelectedItem.Value, chartEOL, "O.S. por Período")

        End If

        Dim strScript As String = "<scrip" & "t type='text/javascript'>" & vbCrLf
        strScript &= "          function printReport(){" & vbCrLf
        strScript &= "            var win = window.open('relperiodo_prn.aspx?tp=" & cboTipoGrafico.SelectedItem.Value & _
                                                                    "&di=" & txtDataInicial.Text & _
                                                                    "&df=" & txtDataFinal.Text & "','IMPRIMIR_RELATORIO_PERIODO','width=950, height=600,status=no,scrollbars=yes,toolbar=no,top=20,left=20');" & vbCrLf
        strScript &= "            win.focus();" & vbCrLf
        strScript &= "}" & vbCrLf
        strScript &= "</scri" & "pt>"

        ltScript.Text = strScript


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

    Private Sub setStyle(ByVal p_XPort As VM.xPort.DS2XL, ByVal p_DataTable As System.Data.DataTable)

        Dim headerStyle As VM.xPort.Style
        Dim contentStyle As VM.xPort.Style
        Dim footerStyle As VM.xPort.Style
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

        footerStyle = New Style("footerStyle", p_DataTable.TableName, p_DataTable.Rows.Count - 1, 0, p_DataTable.Rows.Count - 1, p_DataTable.Columns.Count - 1)
        With footerStyle
            customFont = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
            footerStyle.Font = customFont
            footerStyle.HorizontalAlignment = Style.xpHAlignment.Left
            footerStyle.VerticalAlignment = Style.xpVAlignment.Center
            footerStyle.WrapText = True
            footerStyle.ForeColor = Color.Navy
        End With
        p_XPort.Styles.Add(footerStyle)

    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportar.Click

        Dim loXPort As VM.xPort.DS2XL
        Dim exportStream As MemoryStream
        Dim bytearray() As Byte
        cls = New clsRelatorio()
        Dim dsExcel As DataSet = cls.GetReport_Periodo(strDataInicial, strDataFinal)

        If Not dsExcel Is Nothing Then

            Dim row As DataRow = dsExcel.Tables(0).NewRow()
            row(0) = "Total"

            Dim i As Integer = 0
            Dim intTotal As Integer = 0
            For i = 0 To dsExcel.Tables(0).Rows.Count - 1
                intTotal += dsExcel.Tables(0).Rows(i).Item(1)
            Next

            row(1) = intTotal

            dsExcel.Tables(0).Rows.Add()
            dsExcel.Tables(0).Rows.Add(row)

            loXPort = New DS2XL()
            setStyle(loXPort, dsExcel.Tables(0))

            exportStream = loXPort.ExportToStream(dsExcel, xpOutputFormat.XLSX, True)
            bytearray = exportStream.ToArray
            exportStream.Flush()
            exportStream.Close()

            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=Relatorio_OS_por_Periodo_" & Now().ToString("yyyyMMdd-hhmmss") & ".xlsx")
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
