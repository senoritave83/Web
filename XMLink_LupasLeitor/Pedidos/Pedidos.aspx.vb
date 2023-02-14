
Imports Classes
Imports VM.xPort
Imports System.IO
Imports System.Drawing
Imports System.Data
Imports System.Data.Common

Namespace Pages.Pedidos

    Partial Public Class Pedidos
        Inherits XMWebPage
        Dim cls As clsPedido
        Dim intRegistroInicial As Integer = 0, intRegistroFinal As Integer = 0
        Const ACAO_VISUALIZAR_TODOS As String = "Visualizar Todos os Pedidos"
        Private Total As Double


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then

                Dim sta As New clsStatus
                cboIDStatus.DataSource = sta.Listar
                cboIDStatus.DataBind()
                cboIDStatus.Items.Insert(0, New ListItem("TODOS", "0"))
                setComboValue(cboIDStatus, 3)
                sta = Nothing

                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("TODOS", 0))
                ven = Nothing

                Dim frm As New clsFormaPagamento
                cboIDFormaPagto.DataSource = frm.Listar
                cboIDFormaPagto.DataBind()
                cboIDFormaPagto.Items.Insert(0, New ListItem("TODOS", 0))
                frm = Nothing

                txtDataEmissaoInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
                txtDataEmissaoFinal.Text = Now.ToString("dd/MM/yyyy")

                Me.RecuperaFiltro(Paginate1, txtFiltro, cboIDVendedor, txtCliente, cboIDStatus, txtDataEmissaoInicial, txtDataEmissaoFinal, cboIDTipoPedido)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult
            If VerificaPermissao(SecaoAtual, ACAO_VISUALIZAR_TODOS) Then
                ret = cls.Listar(txtFiltro.Text, cboIDVendedor.SelectedValue, txtCliente.Text, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, cboIDStatus.SelectedValue, cboIDTipoPedido.SelectedValue, cboIDFormaPagto.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            Else
                ret = cls.Listar(txtFiltro.Text, cboIDVendedor.SelectedValue, txtCliente.Text, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, cboIDStatus.SelectedValue, cboIDTipoPedido.SelectedValue, cboIDFormaPagto.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE, User.IDUser)
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

            Me.GravaFiltro(Paginate1, txtFiltro, cboIDVendedor, txtCliente, cboIDStatus, txtDataEmissaoInicial, txtDataEmissaoFinal, cboIDTipoPedido)
        End Sub

        Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

            If e.Row.RowType = ListItemType.AlternatingItem OrElse e.Row.RowType = ListItemType.Item Then
                Me.Total = DirectCast(e.Row.DataItem, DbDataRecord).Item("TotalGeral")
                If intRegistroInicial = 0 Then
                    intRegistroInicial = e.Row.DataItem("Registros")
                End If
                intRegistroFinal = e.Row.DataItem("Registros")
            ElseIf e.Row.RowType = ListItemType.Footer Then
                DirectCast(e.Row.FindControl("lblValorTotal"), Label).Text = Me.Total.ToString("C2")
            End If

            GridView1.ShowFooter = (Paginate1.PageCount = Paginate1.CurrentPage)

        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()

            'If GridView1.Rows.Count > 0 Then
            '    divBotoes.Visible = True
            'Else
            '    divBotoes.Visible = False
            'End If
        End Sub

        Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

            Me.RecuperaFiltro(Paginate1, txtFiltro, cboIDVendedor, txtCliente, cboIDStatus, txtDataEmissaoInicial, txtDataEmissaoFinal, cboIDTipoPedido)

            Dim loXPort As VM.xPort.DS2XL
            Dim exportStream As MemoryStream
            Dim bytearray() As Byte
            Dim dsExcel As DataSet
            Dim rpt As New clsRelatorio()
            If VerificaPermissao(SecaoAtual, ACAO_VISUALIZAR_TODOS) Then
                dsExcel = rpt.GetExportarPedidos(txtFiltro.Text, cboIDVendedor.SelectedValue, txtCliente.Text, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, cboIDStatus.SelectedValue, cboIDTipoPedido.SelectedValue)
            Else
                dsExcel = rpt.GetExportarPedidos(txtFiltro.Text, cboIDVendedor.SelectedValue, txtCliente.Text, txtDataEmissaoInicial.Text, txtDataEmissaoFinal.Text, cboIDStatus.SelectedValue, cboIDTipoPedido.SelectedValue, User.IDUser)
            End If

            If Not dsExcel Is Nothing Then

                loXPort = New DS2XL()
                setStyle(loXPort, dsExcel.Tables(0))

                exportStream = loXPort.ExportToStream(dsExcel, xpOutputFormat.Excel8, True)
                bytearray = exportStream.ToArray
                exportStream.Flush()
                exportStream.Close()

                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=Exportar_Pedidos_" & Now().ToString("yyyyMMdd-hhmmss") & ".xls")
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
            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts_NumeroPedido", p_DataTable.TableName, 1, 1, 10000)
            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts_NomeVendedor", p_DataTable.TableName, 2, 2, 10000)
            SetColumnWidth(p_XPort.ColWidths, "AllColumnWidhts_Cliente", p_DataTable.TableName, 3, 3, 10000)

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

