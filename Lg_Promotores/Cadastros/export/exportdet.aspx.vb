Imports System
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports Ionic.Utils.Zip
Imports VM.xPort

Partial Class Cadastros_export_exportdet
    Inherits XMWebPage

    Protected cls As clsExportacao

    Private Const VW_CATEGORIA As String = "cat"
    Private Const VW_SUBCATEGORIA As String = "sub"
    Private Const VW_PRODUTO As String = "prd"
    Private Const VW_LIDER As String = "lid"
    Private Const VW_COORDENADOR As String = "crd"
    Private Const VW_PROMOTOR As String = "pro"
    Private Const VW_CLIENTE As String = "cli"
    Private Const VW_LOJA As String = "loj"
    Private Const VW_SHOPPING As String = "shop"
    Private Const VW_TIPOLOJA As String = "tiploj"
    Private Const VW_REGIAO As String = "regiao"
    Private Const VW_STATUS As String = "sta"
    Private Const VW_JUSTIFICATIVA As String = "jus"
    Private Const VW_PERIODO_INICIAL As String = "pi"
    Private Const VW_PERIODO_FINAL As String = "pf"
    Private Const VW_UF As String = "est"
    Private Const VW_TABELAS As String = "tab"

    'Private Const VW_TIPOPESQUISA As String = "tippes"
    'Private Const VW_PERIODO_TEXTO As String = "pertxt"
    'Private Const VW_PERIODO As String = "per"

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    cls = New clsExportacao

    '    ViewState(VW_CATEGORIA) = Request(VW_CATEGORIA) & ""
    '    ViewState(VW_SUBCATEGORIA) = Request(VW_SUBCATEGORIA) & ""
    '    ViewState(VW_PRODUTO) = Request(VW_PRODUTO) & ""
    '    ViewState(VW_COORDENADOR) = Request(VW_COORDENADOR) & ""
    '    ViewState(VW_LIDER) = Request(VW_LIDER) & ""
    '    ViewState(VW_PROMOTOR) = Request(VW_PROMOTOR) & ""
    '    ViewState(VW_CLIENTE) = Request(VW_CLIENTE) & ""
    '    ViewState(VW_LOJA) = Request(VW_LOJA) & ""
    '    ViewState(VW_SHOPPING) = Request(VW_SHOPPING) & ""
    '    ViewState(VW_TIPOLOJA) = Request(VW_TIPOLOJA) & ""
    '    ViewState(VW_REGIAO) = Request(VW_REGIAO) & ""
    '    ViewState(VW_STATUS) = Request(VW_STATUS)
    '    'ViewState(VW_TIPOPESQUISA) = Request(VW_TIPOPESQUISA) & ""
    '    ViewState(VW_UF) = Request(VW_UF) & ""
    '    'ViewState(VW_PERIODO_TEXTO) = Request(VW_PERIODO_TEXTO) & ""
    '    'ViewState(VW_PERIODO) = Request(VW_PERIODO) & ""
    '    ViewState(VW_JUSTIFICATIVA) = Request(VW_JUSTIFICATIVA) & ""
    '    ViewState(VW_TABELAS) = CInt("0" & Request(VW_TABELAS))

    '    'Dim p_Temp As Object = Split(ViewState(VW_PERIODO), "||", , CompareMethod.Text)
    '    ViewState(VW_PERIODO_INICIAL) = Request(VW_PERIODO_INICIAL) & ""
    '    ViewState(VW_PERIODO_FINAL) = Request(VW_PERIODO_FINAL) & ""

    '    'saveExcelSheet()


    '    Dim dsExcel As DataSet = cls.ExportarDados(ViewState(VW_CLIENTE), ViewState(VW_LOJA), ViewState(VW_COORDENADOR), ViewState(VW_LIDER), ViewState(VW_PROMOTOR), _
    '                            ViewState(VW_CATEGORIA), ViewState(VW_SUBCATEGORIA), ViewState(VW_PRODUTO), ViewState(VW_UF), ViewState(VW_TIPOLOJA), ViewState(VW_REGIAO), _
    '                            ViewState(VW_STATUS), ViewState(VW_JUSTIFICATIVA), ViewState(VW_TABELAS), ViewState(VW_PERIODO_INICIAL), ViewState(VW_PERIODO_FINAL), ViewState(VW_SHOPPING), DataClass.enReturnType.DataSet)

    '    SaveDataSetIntoBinaryExcel(dsExcel)

    '    'grdExportar.DataSource = cls.ExportarDados(ViewState(VW_CLIENTE), ViewState(VW_LOJA), ViewState(VW_COORDENADOR), ViewState(VW_LIDER), ViewState(VW_PROMOTOR), _
    '    '                        ViewState(VW_CATEGORIA), ViewState(VW_SUBCATEGORIA), ViewState(VW_PRODUTO), ViewState(VW_UF), ViewState(VW_TIPOLOJA), ViewState(VW_REGIAO), _
    '    '                        ViewState(VW_STATUS), ViewState(VW_JUSTIFICATIVA), ViewState(VW_TABELAS), ViewState(VW_PERIODO_INICIAL), ViewState(VW_PERIODO_FINAL), ViewState(VW_SHOPPING))
    '    'grdExportar.DataBind()


    '    'Response.AddHeader("Last-Modified", Now().ToString)
    '    'Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
    '    'Response.ContentType = "application/vnd.ms-excel"

    'End Sub

    'Private Sub SaveDataSetIntoBinaryExcel()

    '    Dim loXPort As VM.xPort.DS2XL
    '    Dim lcExportFile As String
    '    Dim loFileInfo As FileInfo

    '    Dim dsExcel As DataSet = cls.ExportarDados(ViewState(VW_CLIENTE), ViewState(VW_LOJA), ViewState(VW_COORDENADOR), ViewState(VW_LIDER), ViewState(VW_PROMOTOR), _
    '                    ViewState(VW_CATEGORIA), ViewState(VW_SUBCATEGORIA), ViewState(VW_PRODUTO), ViewState(VW_UF), ViewState(VW_TIPOLOJA), ViewState(VW_REGIAO), _
    '                    ViewState(VW_STATUS), ViewState(VW_JUSTIFICATIVA), ViewState(VW_TABELAS), ViewState(VW_PERIODO_INICIAL), ViewState(VW_PERIODO_FINAL), ViewState(VW_SHOPPING), DataClass.enReturnType.DataSet)

    '    If Not loDataSet Is Nothing Then

    '        loXPort = New DS2XL()

    '        setStyle(loXPort, loDataSet.Tables(0))

    '        'Generate temporary file name
    '        Dim p_FileName As String = "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".xls"
    '        lcExportFile = System.IO.Path.GetTempPath & p_FileName
    '        loXPort.Export(loDataSet, lcExportFile, xpOutputFormat.Excel8, True, True)

    '        loFileInfo = New FileInfo(lcExportFile)

    '        If loFileInfo.Exists AndAlso Response.IsClientConnected Then
    '            'Write Excel content into the Response

    '            Dim zipFileName As String = "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".zip"
    '            Dim zip As ZipFile

    '            Response.Clear()
    '            Response.ClearHeaders()
    '            Response.AddHeader("content-disposition", "attachment; filename=" & zipFileName)
    '            Response.ContentType = "application/x-zip-compressed"
    '            Response.AddHeader("last-modified", Now().ToString)

    '            zip = New ZipFile(Response.OutputStream)
    '            zip.AddFile(lcExportFile, "")
    '            zip.Save()
    '            zip.Dispose()
    '            zip = Nothing

    '        End If

    '        loXPort = Nothing
    '        loDataSet = Nothing

    '    End If

    'End Sub

    'Private Sub setStyle(ByVal p_XPort As VM.xPort.DS2XL, ByVal p_DataTable As System.Data.DataTable)


    '    Dim headerStyle As VM.xPort.Style
    '    Dim contentStyle As VM.xPort.Style
    '    Dim customFont As System.Drawing.Font

    '    'Define style for the header. 
    '    headerStyle = New VM.xPort.Style("HeaderStyle", p_DataTable.TableName, -1, 0, -1, p_DataTable.Columns.Count - 1)

    '    'Create font that will be used to format header text.
    '    customFont = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
    '    With headerStyle
    '        .Font = customFont
    '        .HorizontalAlignment = Style.xpHAlignment.Center
    '        .VerticalAlignment = Style.xpVAlignment.Center
    '        .TopBorderLine = Style.xpBorderLineStyle.Double
    '        .TopBorderColor = Color.Beige
    '        .BottomBorderLine = Style.xpBorderLineStyle.Double
    '        .BottomBorderColor = Color.Beige
    '        .LeftBorderLine = Style.xpBorderLineStyle.Thin
    '        .LeftBorderColor = Color.Beige
    '        .RightBorderLine = Style.xpBorderLineStyle.Thin
    '        .RightBorderColor = Color.Beige
    '        .BackgroundColor = Color.FromArgb(0, 184, 204, 228)
    '        .UnderlineStyle = Style.xpUnderlineStyle.Double
    '    End With
    '    p_XPort.Styles.Add(headerStyle)

    '    contentStyle = New Style("ContentStyle", p_DataTable.TableName, 0, 0, p_DataTable.Rows.Count - 1, p_DataTable.Columns.Count - 1)
    '    With contentStyle
    '        customFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular)
    '        contentStyle.Font = customFont
    '        contentStyle.HorizontalAlignment = Style.xpHAlignment.Left
    '        contentStyle.VerticalAlignment = Style.xpVAlignment.Center
    '        contentStyle.WrapText = True
    '        contentStyle.ForeColor = Color.Navy
    '    End With
    '    p_XPort.Styles.Add(contentStyle)

    'End Sub

    ''Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    ''    Dim st As New IO.StringWriter
    ''    Dim wr As New UI.Html32TextWriter(st)
    ''    MyBase.Render(wr)

    ''    Dim zipFileName As String = "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".zip"
    ''    Dim zip As ZipFile

    ''    Response.Clear()
    ''    Response.ClearHeaders()
    ''    Response.AddHeader("content-disposition", "attachment; filename=" & zipFileName)
    ''    Response.ContentType = "application/x-zip-compressed"
    ''    Response.AddHeader("last-modified", Now().ToString)

    ''    zip = New ZipFile(Response.OutputStream)
    ''    zip.AddStringAsFile(st.ToString(), "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".xls", "")
    ''    zip.Save()
    ''    zip.Dispose()
    ''    zip = Nothing

    ''End Sub

    ''    private void Page_Load(object sender, System.EventArgs e)
    ''{
    ''BindDataGrid(); 
    ''} 
    ''private void BindDataGrid() {
    ''cnn = new SqlConnection("Initial Catalog=Northwind;Data Source=localhost;uid=sa;pwd=");
    ''sql = new SqlCommand("select * from products",cnn);
    ''cnn.Open();
    ''SqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection); 
    ''DataGrid1.DataSource = reader;
    ''DataGrid1.DataBind();
    ''reader.Close();

    ''}

    'Private Sub exportDataToExcel()

    'End Sub

    ''private void ExportDataGridToExcel() { 
    ''SpreadsheetClass xlsheet = new SpreadsheetClass();
    ''cnn.Open();
    ''SqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
    ''int numcols = reader.FieldCount; 
    ''int row=1; 
    ''// lets create the header row from the column names in the reader.... 
    ''for(int j=0;j<reader.FieldCount;j++)
    ''{
    ''xlsheet.ActiveSheet.Cells[row, j+1] = reader.GetName(j).ToString(); 
    ''}
    ''row++; // start data at row 2 
    ''// dump our data into the sheet...
    ''while (reader.Read()) {
    ''for (int i=0;i<numcols;i++) 
    ''{ 
    ''xlsheet.ActiveSheet.Cells[row,i+1] = reader.GetValue(i).ToString();
    ''}
    ''row++;
    ''} 
    ''reader.Close();

    ''// use this just to get a unique filename... 
    ''string xlFileName=System.DateTime.Now.Ticks.ToString() +".xls";
    ''// save it off to the filesystem...
    ''xlsheet.Export(Server.MapPath(".")+"\\"+xlFileName,
    ''     OWC10.SheetExportActionEnum.ssExportActionNone,
    ''        OWC10.SheetExportFormat.ssExportHTML);
    ''// set content header so browser knows you'r sending Excel workbook...
    ''Response.ContentType="application/x-msexcel" ;
    ''// stream it on out!
    ''Response.WriteFile(Server.MapPath(".")+"\\"+xlFileName);
    ''// clean up old files...
    ''RemoveFiles(Server.MapPath("."));
    ''}

    ''private void ViewInExcel_Click(object sender, System.EventArgs e)
    ''{ 
    ''ExportDataGridToExcel(); 
    ''}

    ''private void RemoveFiles(string strPath)
    ''{ 
    ''System.IO.DirectoryInfo di = new DirectoryInfo(strPath);
    ''FileInfo[] fiArr = di.GetFiles();
    ''foreach (FileInfo fi in fiArr)
    ''{ 
    ''if(fi.Extension.ToString() ==".txt" || fi.Extension.ToString()==".csv" || fi.Extension.ToString()==".xls")
    ''{
    ''// if file is older than 2 minutes, we'll clean it up
    ''TimeSpan min = new TimeSpan(0,0,0,2,0);
    ''if(fi.CreationTime < DateTime.Now.Subtract(min))
    ''{
    ''fi.Delete();
    ''}
    ''}
    ''}
    ''}



End Class
