Imports Classes
Imports VM.xPort
Imports System.IO
Imports System.Drawing
Imports System.Data

Partial Class Relatorios_Exportar
    Inherits XMWebPage

    Dim ven As clsVendedor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ven = New clsVendedor
        If Not Page.IsPostBack Then
            'txtDataEmissaoInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
            'txtDataEmissaoFinal.Text = Now.ToString("dd/MM/yyyy")
            ViewState("Categorias") = "0"
            ViewState("Vendedores") = "0"
            BindVendedor()
            BindCliente(ViewState("Vendedores"))
            BindStatus()
            BindCategoria()
            BindProduto(ViewState("Categorias"))
        End If
    End Sub

    ''' <summary>
    ''' Função que carrega o ListBox com Vendedores ativos
    ''' </summary>
    Protected Sub BindVendedor()
        lstVendedores.DataSource = ven.Listar
        lstVendedores.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstVendedores.Items.Insert(0, it)
    End Sub

    ''' <summary>
    ''' Função que faz uma varredura no ListBox de Vendedores e Concatena os IDs Selecionados em um ViewState
    ''' </summary>
    Protected Sub lstVendedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendedores.SelectedIndexChanged
        ViewState("Vendedores") = ""
        For Each li As ListItem In lstVendedores.Items
            If li.Value = 0 And li.Selected Then
                ViewState("Vendedores") = "0,"
                Exit For
            Else
                If li.Selected Then
                    ViewState("Vendedores") += li.Value & ","
                End If
            End If
        Next
        ViewState("Vendedores") = Left(ViewState("Vendedores"), ViewState("Vendedores").Length - 1)
        BindCliente(ViewState("Vendedores"))
    End Sub

    ''' <summary>
    ''' Função que carrega o ListBox com Clientes ativos de acordo com os Vendedores selecionados
    ''' </summary>
    ''' <param name="p_Vendedores">Chave primária do Vendedor</param>
    Protected Sub BindCliente(ByVal p_Vendedores As String)
        lstClientes.DataSource = ven.ListarClientes(p_Vendedores)
        lstClientes.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstClientes.Items.Insert(0, it)
        ven = Nothing
    End Sub

    ''' <summary>
    ''' Função que faz uma varredura no ListBox de Clientes e Concatena os IDs Selecionados
    ''' </summary>
    ''' <returns>Variável String com os IDs dos Clientes</returns>
    Protected Function listClientes() As String
        Dim list As String = ""
        For Each li As ListItem In lstClientes.Items
            If li.Value = 0 And li.Selected Then
                list = "0,"
                Exit For
            Else
                If li.Selected Then
                    list += li.Value & ","
                End If
            End If
        Next
        list = Left(list, list.Length - 1)
        Return list
    End Function

    ''' <summary>
    ''' Função que carrega o ListBox com Status cadastrados no BD
    ''' </summary>
    Protected Sub BindStatus()
        Dim sta As New clsStatus
        lstStatus.DataSource = sta.Listar()
        lstStatus.DataBind()

        'Remove o Status apagado
        For i As Integer = 0 To lstStatus.Items.Count - 2
            If lstStatus.Items.Item(i).Value = 4 Then
                lstStatus.Items.RemoveAt(i)
            End If
        Next

        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstStatus.Items.Insert(0, it)
        sta = Nothing
    End Sub

    ''' <summary>
    ''' Função que faz uma varredura no ListBox de Status e Concatena os IDs Selecionados
    ''' </summary>
    ''' <returns>Variável String com os IDs dos Status</returns>
    Protected Function listStatus() As String
        Dim list As String = ""
        For Each li As ListItem In lstStatus.Items
            If li.Value = 0 And li.Selected Then
                list = "0,"
                Exit For
            Else
                If li.Selected Then
                    list += li.Value & ","
                End If
            End If
        Next
        list = Left(list, list.Length - 1)
        Return list
    End Function

    ''' <summary>
    ''' Função que carrega o ListBox com Categorias ativas
    ''' </summary>
    Protected Sub BindCategoria()
        Dim cat As New clsCategoria
        lstCategorias.DataSource = cat.Listar()
        lstCategorias.DataBind()
        Dim it As New ListItem("TODAS", "0")
        it.Selected = True
        lstCategorias.Items.Insert(0, it)
        cat = Nothing
    End Sub

    ''' <summary>
    ''' Função que faz uma varredura no ListBox de categorias e Concatena os IDs Selecionados em um ViewState
    ''' </summary>
    Protected Sub lstCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCategorias.SelectedIndexChanged
        ViewState("Categorias") = ""
        For Each li As ListItem In lstCategorias.Items
            If li.Value = 0 And li.Selected Then
                ViewState("Categorias") = "0,"
                Exit For
            Else
                If li.Selected Then
                    ViewState("Categorias") += li.Value & ","
                End If
            End If
        Next
        ViewState("Categorias") = Left(ViewState("Categorias"), ViewState("Categorias").Length - 1)
        BindProduto(ViewState("Categorias"))
    End Sub

    ''' <summary>
    ''' Função que carrega o ListBox com Produtos ativos de acordo com as Categorias selecionadas
    ''' </summary>
    ''' <param name="p_IDCategoria">Chave primária da Categoria</param>
    Protected Sub BindProduto(ByVal p_IDCategoria As String)
        Dim prd As New clsProduto
        lstProdutos.DataSource = prd.ListaProdutoCategoria(p_IDCategoria)
        lstProdutos.DataBind()
        Dim it As New ListItem("TODOS", "0")
        it.Selected = True
        lstProdutos.Items.Insert(0, it)
        prd = Nothing
    End Sub

    ''' <summary>
    ''' Função que faz uma varredura no ListBox de produtos e Concatena os IDs Selecionados
    ''' </summary>
    ''' <returns>Variável String com os IDs dos produtos</returns>
    Protected Function listProdutos() As String
        Dim list As String = ""
        For Each li As ListItem In lstProdutos.Items
            If li.Value = 0 And li.Selected Then
                list = "0,"
                Exit For
            Else
                If li.Selected Then
                    list += li.Value & ","
                End If
            End If
        Next
        list = Left(list, list.Length - 1)
        Return list
    End Function

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim loXPort As VM.xPort.DS2XL
        Dim exportStream As MemoryStream
        Dim bytearray() As Byte
        Dim exp As New clsRelatorio()
        Dim strDataInicial As String = Now.AddDays(-2).ToString("dd/MM/yyyy")
        Dim strDataFinal As String = Now.AddDays(2).ToString("dd/MM/yyyy")
        Dim dsExcel As DataSet = exp.GetExportarDados(strDataInicial, strDataFinal, cboIDTipoPedido.SelectedValue, ViewState("Vendedores"), listClientes(), listStatus(), ViewState("Categorias"), listProdutos())

        If Not dsExcel Is Nothing Then

            loXPort = New DS2XL()
            setStyle(loXPort, dsExcel.Tables(0))

            exportStream = loXPort.ExportToStream(dsExcel, xpOutputFormat.Excel8, True)
            bytearray = exportStream.ToArray
            exportStream.Flush()
            exportStream.Close()

            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=Exportar_Dados_" & Now().ToString("yyyyMMdd-hhmmss") & ".xls")
            Response.AddHeader("Content-Length", bytearray.Length.ToString())
            Response.ContentType = "Application/xls"
            Response.BinaryWrite(bytearray)
            Response.Flush()
            Response.Close()

            loXPort = Nothing
            dsExcel = Nothing

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

        'footerStyle = New Style("footerStyle", p_DataTable.TableName, p_DataTable.Rows.Count - 1, 0, p_DataTable.Rows.Count - 1, p_DataTable.Columns.Count - 1)
        'With footerStyle
        '    customFont = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
        '    footerStyle.Font = customFont
        '    footerStyle.HorizontalAlignment = Style.xpHAlignment.Left
        '    footerStyle.VerticalAlignment = Style.xpVAlignment.Center
        '    footerStyle.WrapText = True
        '    footerStyle.ForeColor = Color.Navy
        'End With
        'p_XPort.Styles.Add(footerStyle)

    End Sub
End Class
