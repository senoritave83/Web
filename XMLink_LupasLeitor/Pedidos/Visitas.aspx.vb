
Imports Classes
Imports VM.xPort
Imports System.IO
Imports System.Drawing
Imports System.Data

Namespace Pages.Visita

    Partial Public Class Visitas

        Inherits XMWebPage
        Dim cls As clsVisita
        Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todas as Visitas"
        Dim intRegistroInicial As Integer = 0, intRegistroFinal As Integer = 0
        Private Total As Double

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsVisita()

            If Not Page.IsPostBack Then

                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                'Bind Combos
                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("TODOS", 0))
                ven = Nothing

                Dim tjf As New clsTipoJustificativa
                cboIDJustificativa.DataSource = tjf.Listar
                cboIDJustificativa.DataBind()
                cboIDJustificativa.Items.Insert(0, New ListItem("SEM JUSTIFICATIVA", 0))
                cboIDJustificativa.Items.Insert(0, New ListItem("TODOS", -1))
                tjf = Nothing

                txtDataFinal.Text = FormatDateTime(Now, 2)
                txtDataInicial.Text = FormatDateTime(Now.AddDays(-10), 2)


                Me.RecuperaFiltro(txtFiltro, Paginate1, cboIDVendedor, cboIDJustificativa, txtDataFinal, txtDataInicial)

                BindGrid()

            End If

        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult
            If VerificaPermissao(SecaoAtual, ACAO_VISUALIZAR_TODOS) Then
                ret = cls.Listar(ViewState("Filtro"), cboIDVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            Else
                ret = cls.Listar(ViewState("Filtro"), cboIDVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE, User.IDUser)
            End If

            GridView1.DataSource = ret.Data
            GridView1.DataBind()

            hidQtdeReg.Value = ret.RecordCount
            Paginate1.QtdRegistros1 = "Mostrando registros " & intRegistroInicial & " até " & intRegistroFinal
            Paginate1.QtdRegistros2 = ret.RecordCount
            Paginate1.ShowQtdRegistros = GridView1.Rows.Count <> 0
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Paginate1, cboIDVendedor, cboIDJustificativa, txtDataFinal, txtDataInicial)

        End Sub

        Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

            If e.Row.RowType = ListItemType.AlternatingItem OrElse e.Row.RowType = ListItemType.Item Then
                If intRegistroInicial = 0 Then
                    intRegistroInicial = e.Row.DataItem("Registros")
                End If
                intRegistroFinal = e.Row.DataItem("Registros")
            End If

        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindGrid()
        End Sub

        Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

            Me.GravaFiltro(txtFiltro, Paginate1, cboIDVendedor, cboIDJustificativa, txtDataFinal, txtDataInicial)

            Dim loXPort As VM.xPort.DS2XL
            Dim exportStream As MemoryStream
            Dim bytearray() As Byte
            Dim dsExcel As DataSet
            Dim rpt As New clsRelatorio()
            If VerificaPermissao(SecaoAtual, ACAO_VISUALIZAR_TODOS) Then
                dsExcel = rpt.GetExportarVisitas(txtFiltro.Text, cboIDVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue)
            Else
                dsExcel = rpt.GetExportarVisitas(txtFiltro.Text, cboIDVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue, User.IDUser)
            End If

            If Not dsExcel Is Nothing Then

                loXPort = New DS2XL()
                setStyle(loXPort, dsExcel.Tables(0))

                exportStream = loXPort.ExportToStream(dsExcel, xpOutputFormat.Excel8, True)
                bytearray = exportStream.ToArray
                exportStream.Flush()
                exportStream.Close()

                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=Exportar_Visitas_" & Now().ToString("yyyyMMdd-hhmmss") & ".xls")
                Response.AddHeader("Content-Length", bytearray.Length.ToString())
                Response.ContentType = "Application/xls"
                Response.BinaryWrite(bytearray)
                Response.Flush()
                Response.Close()

                loXPort = Nothing
                dsExcel = Nothing

                Response.End()

            End If

        End Sub

        ''' <summary>
        ''' Função que formata o layout da Planilha Excel
        ''' </summary>
        Private Sub setStyle(ByVal p_XPort As VM.xPort.DS2XL, ByVal p_DataTable As System.Data.DataTable)

            Dim headerStyle As VM.xPort.Style
            Dim contentStyle As VM.xPort.Style
            'Dim footerStyle As VM.xPort.Style
            Dim customFont As System.Drawing.Font

            'Define style for the header. 
            headerStyle = New VM.xPort.Style("HeaderStyle", p_DataTable.TableName, -1, 0, -1, p_DataTable.Columns.Count - 1)

            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts", p_DataTable.TableName, 0, p_DataTable.Columns.Count - 1, 4500)
            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts_Cliente", p_DataTable.TableName, 1, 1, 10000)
            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts_Vendedor", p_DataTable.TableName, 2, 2, 10000)

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
                .WrapText = False
            End With
            p_XPort.Styles.Add(headerStyle)

            contentStyle = New Style("ContentStyle", p_DataTable.TableName, 0, 0, p_DataTable.Rows.Count - 1, p_DataTable.Columns.Count - 1)
            With contentStyle
                customFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular)
                contentStyle.Font = customFont
                contentStyle.HorizontalAlignment = Style.xpHAlignment.Left
                contentStyle.VerticalAlignment = Style.xpVAlignment.Center
                contentStyle.WrapText = False
                contentStyle.ForeColor = Color.Navy
            End With
            p_XPort.Styles.Add(contentStyle)

        End Sub

        Private Sub SetColumnWidth(ByVal widths As ColWidthCollection, _
                                    ByVal styleName As String, _
                                    ByVal dataTableName As String, _
                                    ByVal startCol As Integer, _
                                    ByVal endCol As Integer, _
                                    ByVal width As Integer)

            Dim customColumnWidth As ColWidth
            customColumnWidth = New ColWidth(styleName, dataTableName, startCol, endCol, width)
            widths.Add(customColumnWidth)

        End Sub

#Region "Sorting"


        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            If SortExpression = e.SortExpression Then
                If SortDirection = WebControls.SortDirection.Ascending Then
                    SortDirection = WebControls.SortDirection.Descending
                Else
                    SortDirection = WebControls.SortDirection.Ascending
                End If
            Else
                SortExpression = e.SortExpression
                SortDirection = WebControls.SortDirection.Ascending
            End If
        End Sub

        Protected Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                ViewState("SortExpression") = value
            End Set
        End Property

        Protected Property SortDirection() As SortDirection
            Get
                If ViewState("SortDirection") Is Nothing Then
                    Return WebControls.SortDirection.Ascending
                Else
                    Return ViewState("SortDirection")
                End If
            End Get
            Set(ByVal value As SortDirection)
                ViewState("SortDirection") = value
            End Set
        End Property

#End Region

    End Class

End Namespace

