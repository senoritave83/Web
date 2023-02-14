Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptPrecosDet
    Inherits XMWebPage
    Dim rpt As clsReports

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            ViewState("cl") = Request("cl")
            ViewState("lj") = Request("lj")
            ViewState("ct") = Request("ct")
            ViewState("pd") = Request("pd")
            ViewState("it") = Request("it")
            ViewState("est") = Request("est")
            ViewState("tip") = Request("tip")
            ViewState("reg") = Request("regs")
            ViewState("sta") = Request("sta")
            ViewState("pertxt") = Request("pertxt")
            ViewState("per") = Request("per")
            ViewState("sp") = Request("sp")

            Dim p_Temp As Object = Split(ViewState("per"), "||", , CompareMethod.Text)
            ViewState("pi") = p_Temp(0)
            ViewState("pn") = p_Temp(1)

        End If

        Try

            OpenReport()

        Catch ex As System.Exception

            Dim sb As New System.Text.StringBuilder

            sb.Append("<table border=0 align='center' cellspacing='0'>")
            sb.Append("<tr><td class='Mensagem'><b>Erro : " & ex.Message & "</b></td></tr>")
            sb.Append("</table>")

            sb.Append("</body>")
            sb.Append("</html>")

            Response.Clear()
            Response.ClearHeaders()
            Response.AddHeader("Content-Length", sb.Length)
            Response.AddHeader("Last-Modified", Now().ToString)
            Response.Write(sb.ToString)

        Finally

            rpt = Nothing

        End Try


    End Sub

    Private Sub OpenReport()

        Dim i, j As Integer
        Dim p_intTotalLojas, p_intTotalProdutos As Integer
        Dim strFormula As String
        rpt = New clsReports
        Dim rptResult As clsReports.RelatorioData = rpt.getRelatorioPrecos(Me.User.IDEmpresa, ViewState("cl"), ViewState("lj"), ViewState("est"), _
                                ViewState("ct"), ViewState("pd"), ViewState("it"), ViewState("tip"), ViewState("reg"), ViewState("sta"), _
                                ViewState("pi"), ViewState("pn"), ViewState("sp"))

        'Dim ds As DataSet = rpt.getRelatorioPrecos_Header(Me.User.IDEmpresa, ViewState("cl"), ViewState("lj"), ViewState("est"), _
        '                        ViewState("ct"), ViewState("pd"), ViewState("it"), ViewState("tip"), ViewState("reg"), ViewState("sta"), _
        '                        ViewState("pi"), ViewState("pn"), ViewState("sp"))

        If rptResult.Sucess Then

            Dim m_Produtos As String = "", m_Lojas As String = ""
            Dim ds As DataSet = rptResult.Header

            If ds.Tables.Count > 0 Then

                p_intTotalProdutos = ds.Tables(0).Rows.Count
                p_intTotalLojas = ds.Tables(1).Rows.Count
                If p_intTotalProdutos = 0 Then
                    NaoEncontrado()
                    Exit Sub
                End If

                Dim sb As New System.Text.StringBuilder

                sb.AppendFormat("<html xmlns:v=""urn:schemas-microsoft-com:vml""{0}", Environment.NewLine)
                sb.AppendFormat("xmlns:o=""urn:schemas-microsoft-com:office:office""{0}", Environment.NewLine)
                sb.AppendFormat("xmlns:x=""urn:schemas-microsoft-com:office:excel""{0}", Environment.NewLine)
                sb.AppendFormat("xmlns=""http://www.w3.org/TR/REC-html40"">{0}", Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)
                sb.AppendFormat("<head>{0}", Environment.NewLine)
                sb.AppendFormat("<meta http-equiv=Content-Type content=""text/html; charset=windows-1252"">{0}", Environment.NewLine)
                sb.AppendFormat("<meta name=ProgId content=Excel.Sheet>{0}", Environment.NewLine)
                sb.AppendFormat("<meta name=Generator content=""Microsoft Excel 11"">{0}", Environment.NewLine)
                sb.AppendFormat("<link rel=File-List{0}", Environment.NewLine)
                sb.AppendFormat("href=""RELATORIO_ANALISE_PRECOS_140920071047022_arquivos/filelist.xml"">{0}", Environment.NewLine)
                sb.AppendFormat("<link rel=Edit-Time-Data{0}", Environment.NewLine)
                sb.AppendFormat("href=""RELATORIO_ANALISE_PRECOS_140920071047022_arquivos/editdata.mso"">{0}", Environment.NewLine)
                sb.AppendFormat("<link rel=OLE-Object-Data{0}", Environment.NewLine)
                sb.AppendFormat("href=""RELATORIO_ANALISE_PRECOS_140920071047022_arquivos/oledata.mso"">{0}", Environment.NewLine)
                sb.AppendFormat("<!--[if !mso]>{0}", Environment.NewLine)
                sb.AppendFormat("<style>{0}", Environment.NewLine)
                sb.AppendFormat("v\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
                sb.AppendFormat("o\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
                sb.AppendFormat("x\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
                sb.AppendFormat(".shape {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
                sb.AppendFormat("</style>{0}", Environment.NewLine)
                sb.AppendFormat("<![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
                sb.AppendFormat(" <o:DocumentProperties>{0}", Environment.NewLine)
                sb.AppendFormat("  <o:LastAuthor>Marcelo</o:LastAuthor>{0}", Environment.NewLine)
                sb.AppendFormat("  <o:Created>2007-09-14T13:47:28Z</o:Created>{0}", Environment.NewLine)
                sb.AppendFormat("  <o:LastSaved>2007-09-14T14:04:00Z</o:LastSaved>{0}", Environment.NewLine)
                sb.AppendFormat("  <o:Company>XM Sistemas</o:Company>{0}", Environment.NewLine)
                sb.AppendFormat("  <o:Version>11.8132</o:Version>{0}", Environment.NewLine)
                sb.AppendFormat(" </o:DocumentProperties>{0}", Environment.NewLine)
                sb.AppendFormat("</xml><![endif]-->{0}", Environment.NewLine)
                sb.AppendFormat("<style>{0}", Environment.NewLine)
                sb.AppendFormat("<!--table{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-displayed-decimal-separator:""\,"";{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-displayed-thousand-separator:""\."";}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("@page{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{margin:.98in .79in .98in .79in;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-header-margin:.5in;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-footer-margin:.5in;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("tr{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-height-source:auto;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("col{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-width-source:auto;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("br{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-data-placement:same-cell;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".style0{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-number-format:General;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:general;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:bottom;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}white-space:nowrap;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-rotate:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-background-source:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}color:windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-size:10.0pt;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:400;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-style:normal;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-decoration:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-generic-font-family:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-protection:locked visible;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-style-name:Normal;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-style-id:0;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("td{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}padding:0px;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-ignore:padding;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}color:windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-size:10.0pt;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:400;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-style:normal;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-decoration:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-generic-font-family:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-number-format:General;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:general;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:bottom;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-background-source:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-protection:locked visible;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}white-space:nowrap;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-rotate:0;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl24{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:center;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl25{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-size:12.0pt;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:right;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl26{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-size:12.0pt;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:center;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}background:silver;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto none;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl27{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:center;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}white-space:normal;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-rotate:90;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl28{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-number-format:Standard;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:.5pt solid windowtext;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl29{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-number-format:Fixed;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:right;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:.5pt solid windowtext;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl30{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}background:silver;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto none;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl31{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}color:white;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:left;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}background:blue;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl32{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}color:white;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:left;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}background:#FF9900;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto none;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat(".xl33{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}color:white;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:left;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}background:fuchsia;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-pattern:auto none;}}{1}", ControlChars.Tab, Environment.NewLine)

                sb.AppendFormat(".xl44{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-number-format:""\#\,\#\#0"";{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)
                sb.AppendFormat("{0}border-top:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-right:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-bottom:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-left:none;}}", ControlChars.Tab)

                sb.AppendFormat(".xl48{0}", Environment.NewLine)
                sb.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}font-family:Arial, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}mso-number-format:""\#\,\#\#0"";{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}text-align:center;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-top:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-right:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-bottom:.5pt solid windowtext;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}border-left:none;{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
                sb.AppendFormat("-->{0}", Environment.NewLine)
                sb.AppendFormat("</style>{0}", Environment.NewLine)
                sb.AppendFormat("<!--[if gte mso 9]><xml>{0}", Environment.NewLine)
                sb.AppendFormat(" <x:ExcelWorkbook>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:ExcelWorksheets>{0}", Environment.NewLine)
                sb.AppendFormat("   <x:ExcelWorksheet>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Name>Relatorio de Precos</x:Name>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:WorksheetOptions>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:Print>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:ValidPrinterInfo/>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:HorizontalResolution>600</x:HorizontalResolution>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:VerticalResolution>600</x:VerticalResolution>{0}", Environment.NewLine)
                sb.AppendFormat("     </x:Print>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:Selected/>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:DoNotDisplayGridlines/>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:FreezePanes/>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:FrozenNoSplit/>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:SplitHorizontal>4</x:SplitHorizontal>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:TopRowBottomPane>4</x:TopRowBottomPane>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:SplitVertical>3</x:SplitVertical>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:LeftColumnRightPane>3</x:LeftColumnRightPane>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:ActivePane>0</x:ActivePane>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:Panes>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:Number>3</x:Number>{0}", Environment.NewLine)
                sb.AppendFormat("      </x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:Number>1</x:Number>{0}", Environment.NewLine)
                sb.AppendFormat("      </x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:Number>2</x:Number>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:ActiveRow>2</x:ActiveRow>{0}", Environment.NewLine)
                sb.AppendFormat("      </x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("      <x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:Number>0</x:Number>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:ActiveRow>20</x:ActiveRow>{0}", Environment.NewLine)
                sb.AppendFormat("       <x:ActiveCol>6</x:ActiveCol>{0}", Environment.NewLine)
                sb.AppendFormat("      </x:Pane>{0}", Environment.NewLine)
                sb.AppendFormat("     </x:Panes>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:ProtectContents>False</x:ProtectContents>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:ProtectObjects>False</x:ProtectObjects>{0}", Environment.NewLine)
                sb.AppendFormat("     <x:ProtectScenarios>False</x:ProtectScenarios>{0}", Environment.NewLine)
                sb.AppendFormat("    </x:WorksheetOptions>{0}", Environment.NewLine)
                sb.AppendFormat("   </x:ExcelWorksheet>{0}", Environment.NewLine)
                sb.AppendFormat("  </x:ExcelWorksheets>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:WindowHeight>6540</x:WindowHeight>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:WindowWidth>11340</x:WindowWidth>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:WindowTopX>360</x:WindowTopX>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:WindowTopY>15</x:WindowTopY>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:ProtectStructure>False</x:ProtectStructure>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:ProtectWindows>False</x:ProtectWindows>{0}", Environment.NewLine)
                sb.AppendFormat(" </x:ExcelWorkbook>{0}", Environment.NewLine)
                sb.AppendFormat(" <x:ExcelName>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:Name>_FilterDatabase</x:Name>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:Hidden/>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:SheetIndex>1</x:SheetIndex>{0}", Environment.NewLine)
                sb.AppendFormat("  <x:Formula>='Relatorio de Precos'!$A$4:$C$4</x:Formula>{0}", Environment.NewLine)
                sb.AppendFormat(" </x:ExcelName>{0}", Environment.NewLine)
                sb.AppendFormat("</xml><![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
                sb.AppendFormat(" <o:shapedefaults v:ext=""edit"" spidmax=""1033""/>{0}", Environment.NewLine)
                sb.AppendFormat("</xml><![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
                sb.AppendFormat(" <o:shapelayout v:ext=""edit"">{0}", Environment.NewLine)
                sb.AppendFormat("  <o:idmap v:ext=""edit"" data=""1""/>{0}", Environment.NewLine)
                sb.AppendFormat(" </o:shapelayout></xml><![endif]-->{0}", Environment.NewLine)
                sb.AppendFormat("</head>{0}", Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)
                sb.AppendFormat("<body link=blue vlink=purple>{0}", Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)

                sb.AppendFormat("<table x:str border=0 cellpadding=0 cellspacing=0 width=1024 style='border-collapse:{0}", Environment.NewLine)
                sb.AppendFormat(" collapse;table-layout:fixed;width:770pt'>{0}", Environment.NewLine)
                sb.AppendFormat(" <col width=229 style='mso-width-source:userset;mso-width-alt:8374;width:172pt'>{0}", Environment.NewLine)
                sb.AppendFormat(" <col width=236 style='mso-width-source:userset;mso-width-alt:8630;width:95pt'>{0}", Environment.NewLine)
                sb.AppendFormat(" <col width=40 style='mso-width-source:userset;mso-width-alt:1462;width:75pt'>{0}", Environment.NewLine)
                sb.AppendFormat(" <col width=106 style='mso-width-source:userset;mso-width-alt:3876;width:80pt'>{0}", Environment.NewLine)

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    sb.AppendFormat(" <col width=77 span=6 style='mso-width-source:userset;mso-width-alt:2816;{0}", Environment.NewLine)
                    sb.AppendFormat(" width:58pt'>{0}", Environment.NewLine)
                Next

                sb.AppendFormat(" <tr height=21 style='height:15.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan=3 height=21 class=xl26 width=505 style='height:15.75pt;{0}", Environment.NewLine)
                sb.AppendFormat("  width:379pt'><!--[if gte vml 1]><v:shapetype id=""_x0000_t201"" coordsize=""21600,21600""{0}", Environment.NewLine)
                sb.AppendFormat("   o:spt=""201"" path=""m,l,21600r21600,l21600,xe"">{0}", Environment.NewLine)
                sb.AppendFormat("   <v:stroke joinstyle=""miter""/>{0}", Environment.NewLine)
                sb.AppendFormat("   <v:path shadowok=""f"" o:extrusionok=""f"" strokeok=""f"" fillok=""f""{0}", Environment.NewLine)
                sb.AppendFormat("    o:connecttype=""rect""/>{0}", Environment.NewLine)
                sb.AppendFormat("   <o:lock v:ext=""edit"" shapetype=""t""/>{0}", Environment.NewLine)
                sb.AppendFormat("  </v:shapetype><v:shape id=""_x0000_s1026"" type=""#_x0000_t201"" style='position:absolute;{0}", Environment.NewLine)
                sb.AppendFormat("   margin-left:0;margin-top:0;width:131.25pt;height:12.75pt;z-index:1;{0}", Environment.NewLine)
                sb.AppendFormat("   visibility:hidden' o:insetmode=""auto"">{0}", Environment.NewLine)
                sb.AppendFormat("   <o:lock v:ext=""edit"" rotation=""t"" text=""t""/>{0}", Environment.NewLine)
                sb.AppendFormat("   <![if excel]><x:ClientData ObjectType=""Drop"">{0}", Environment.NewLine)
                sb.AppendFormat("    <x:MoveWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SizeWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:PrintObject>False</x:PrintObject>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:UIObj/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Val>0</x:Val>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Min>0</x:Min>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Max>0</x:Max>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Inc>1</x:Inc>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Page>10</x:Page>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Dx>16</x:Dx>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Sel>0</x:Sel>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SelType>Single</x:SelType>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:LCT>Normal</x:LCT>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropStyle>Simple</x:DropStyle>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropLines>8</x:DropLines>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:WidthMin>193</x:WidthMin>{0}", Environment.NewLine)
                sb.AppendFormat("   </x:ClientData>{0}", Environment.NewLine)
                sb.AppendFormat("   <![endif]></v:shape><v:shape id=""_x0000_s1025"" type=""#_x0000_t201"" style='position:absolute;{0}", Environment.NewLine)
                sb.AppendFormat("   margin-left:0;margin-top:0;width:131.25pt;height:12.75pt;z-index:2;{0}", Environment.NewLine)
                sb.AppendFormat("   visibility:hidden' o:insetmode=""auto"">{0}", Environment.NewLine)
                sb.AppendFormat("   <o:lock v:ext=""edit"" rotation=""t"" text=""t""/>{0}", Environment.NewLine)
                sb.AppendFormat("   <![if excel]><x:ClientData ObjectType=""Drop"">{0}", Environment.NewLine)
                sb.AppendFormat("    <x:MoveWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SizeWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:PrintObject>False</x:PrintObject>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:UIObj/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Val>0</x:Val>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Min>0</x:Min>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Max>0</x:Max>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Inc>1</x:Inc>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Page>10</x:Page>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Dx>16</x:Dx>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Sel>0</x:Sel>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SelType>Single</x:SelType>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:LCT>Normal</x:LCT>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropStyle>Simple</x:DropStyle>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropLines>8</x:DropLines>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:WidthMin>193</x:WidthMin>{0}", Environment.NewLine)
                sb.AppendFormat("   </x:ClientData>{0}", Environment.NewLine)
                sb.AppendFormat("   <![endif]></v:shape><v:shape id=""_x0000_s1027"" type=""#_x0000_t201"" style='position:absolute;{0}", Environment.NewLine)
                sb.AppendFormat("   margin-left:0;margin-top:0;width:131.25pt;height:12.75pt;z-index:3;{0}", Environment.NewLine)
                sb.AppendFormat("   visibility:hidden' o:insetmode=""auto"">{0}", Environment.NewLine)
                sb.AppendFormat("   <o:lock v:ext=""edit"" rotation=""t"" text=""t""/>{0}", Environment.NewLine)
                sb.AppendFormat("   <![if excel]><x:ClientData ObjectType=""Drop"">{0}", Environment.NewLine)
                sb.AppendFormat("    <x:MoveWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SizeWithCells/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:PrintObject>False</x:PrintObject>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:UIObj/>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Val>0</x:Val>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Min>0</x:Min>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Max>0</x:Max>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Inc>1</x:Inc>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Page>10</x:Page>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Dx>16</x:Dx>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:Sel>0</x:Sel>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:SelType>Single</x:SelType>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:LCT>Normal</x:LCT>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropStyle>Simple</x:DropStyle>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:DropLines>8</x:DropLines>{0}", Environment.NewLine)
                sb.AppendFormat("    <x:WidthMin>193</x:WidthMin>{0}", Environment.NewLine)
                sb.AppendFormat("   </x:ClientData>{0}", Environment.NewLine)
                sb.AppendFormat("   <![endif]></v:shape><![endif]-->RELATÓRIO DE PREÇOS</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td class=xl28 width=106 style='width:80pt'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan=2 rowspan=2 class=xl28 width=154 style='width:116pt'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan=2 rowspan=2 class=xl28 width=154 style='width:116pt'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan=2 rowspan=2 class=xl28 width=154 style='width:116pt'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>{0}", Environment.NewLine)

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan=3 height=17 class=xl24 style='height:12.75pt'>Per&iacute;odo{0}", Environment.NewLine)
                sb.AppendFormat("  selecionado: " & ViewState("pertxt") & "</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td></td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>{0}", Environment.NewLine)

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td height=17 colspan=10 style='height:12.75pt;mso-ignore:colspan'></td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>")

                'Response.AddHeader("Content-Length", sb.Length)
                Response.AddHeader("Last-Modified", Now().ToString)
                Response.AddHeader("Content-Disposition", "inline; filename=RELATORIO_ANALISE_PRECOS_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
                Response.ContentType = "application/vnd.ms-excel"
                Response.Write(sb.ToString())

                sb = New System.Text.StringBuilder

                '*********************
                'INICIO DO HEADER
                '*********************

                sb.AppendFormat(" <tr height=88 style='mso-height-source:userset;height:66.0pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td height=88 class=xl30 id=""_x0000_s1030"" x:autofilter=""all""{0}", Environment.NewLine)
                sb.AppendFormat("  x:autofilterrange=""$A$4:$C$4"" style='width:200pt;height:66.0pt'>{1}</td>{0}", Environment.NewLine, SettingsExpression.GetProperty("nomebandeira", "Relatorios.DescricaoBandeira", "BANDEIRA"))
                sb.AppendFormat("  <td class=xl30 id=""_x0000_s1031"" x:autofilter=""all"" style='width:200pt;border-left:none'>LOJA</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td class=xl30 id=""_x0000_s1032"" x:autofilter=""all"" style='border-left:none'>UF</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td></td>{0}", Environment.NewLine)
                '*********************
                'PRODUTOS
                '*********************
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    sb.AppendFormat("  <td class=xl27 width=77 style='width:58pt'>" & Server.HtmlEncode(ds.Tables(0).Rows(i).Item("PRD_DESCRICAO_CHR")) & "</td>{0}", Environment.NewLine)
                    If m_Produtos <> "" Then m_Produtos &= ","
                    m_Produtos &= ds.Tables(0).Rows(i).Item("prd_PRODUTO_INT_PK")
                Next
                sb.AppendFormat(" </tr>")


                For i = 0 To ds.Tables(1).Rows.Count - 1
                    If m_Lojas <> "" Then m_Lojas &= ","
                    m_Lojas &= ds.Tables(1).Rows(i).Item("LOJ_LOJA_INT_PK")
                Next

                sb.AppendFormat(" </tr>{0}", Environment.NewLine)

                'Dim dr As SqlClient.SqlDataReader = rpt.getRelatorioPrecosData(Me.User.IDEmpresa, m_Lojas, m_Produtos, ViewState("pi"), ViewState("pn"))
                Dim dr As SqlClient.SqlDataReader = rptResult.Data
                Dim blnRead As Boolean = dr.Read()
                Dim m_Preco As Decimal = 0

                For i = 0 To ds.Tables(1).Rows.Count - 1

                    sb.AppendFormat("<tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                    sb.AppendFormat("  <td height=17 class=xl28 style='height:12.75pt;border-top:none;align=left'>" & Server.HtmlEncode(ds.Tables(1).Rows(i).Item("CLI_FANTASIA_CHR")) & "</td>{0}", Environment.NewLine)
                    sb.AppendFormat("  <td class=xl28 style='border-top:none;border-left:none;align=left'>" & (ds.Tables(1).Rows(i).Item("LOJ_LOJA_CHR")) & "{0}", Environment.NewLine)
                    sb.AppendFormat("  </td>{0}", Environment.NewLine)
                    sb.AppendFormat("  <td class=xl28 style='border-top:none;border-left:none'>" & Server.HtmlEncode(ds.Tables(1).Rows(i).Item("loj_UF_chr")) & "</td>{0}", Environment.NewLine)
                    sb.AppendFormat("  <td></td>{0}", Environment.NewLine)

                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        m_Preco = 0
                        If blnRead Then
                            If ds.Tables(0).Rows(j).Item("prd_Produto_int_PK") = dr("prd_Produto_int_FK") And ds.Tables(1).Rows(i).Item("loj_loja_int_PK") = dr("loj_loja_int_PK") Then
                                m_Preco = dr("vsp_Preco_cur")
                                Do While ds.Tables(0).Rows(j).Item("prd_Produto_int_PK") = dr("prd_Produto_int_FK") And ds.Tables(1).Rows(i).Item("loj_loja_int_PK") = dr("loj_loja_int_PK")
                                    blnRead = dr.Read()
                                    If Not blnRead Then Exit Do
                                Loop
                            End If
                        End If
                        sb.AppendFormat("  <td class=xl28 align=right style='border-top:none;")
                        If m_Preco = 0 Then
                            sb.AppendFormat("'>&nbsp;")
                        Else
                            sb.AppendFormat("color:#000000' x:num=""" & excelExportFormatCells(m_Preco) & """ >" & FormatNumber(m_Preco, 2))
                        End If
                        sb.AppendFormat(vbCrLf & "</td>{0}", Environment.NewLine)
                    Next
                    sb.AppendFormat(" </tr>{0}", Environment.NewLine)
                    Response.Write(sb.ToString())
                    sb = New System.Text.StringBuilder

                Next

                dr.Close()
                dr = Nothing

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td height=17 colspan='" & p_intTotalProdutos & "' style='height:12.75pt;mso-ignore:colspan'></td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>")

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan='3' height=17 class=xl28 style='height:12.75pt'>M&aacute;XIMO</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td></td>{0}", Environment.NewLine)
                For j = 0 To p_intTotalProdutos - 1

                    strFormula = "=IF(SUM(" & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & ")&gt;0,SUBTOTAL(4," & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & "),0)"
                    sb.AppendFormat("  <td class=xl28 align=right {0}", Environment.NewLine)
                    sb.AppendFormat(" x:num=""0.00"" x:fmla=""" & strFormula & """>0</td>{0}", Environment.NewLine)

                Next
                sb.AppendFormat(" </tr>")

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan='3' height=17 class=xl28 style='height:12.75pt'>M&iacute;NIMO</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td></td>{0}", Environment.NewLine)
                For j = 0 To p_intTotalProdutos - 1

                    strFormula = "=IF(SUM(" & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & ")&gt;0,SUBTOTAL(5," & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & "),0)"
                    sb.AppendFormat("  <td class=xl28 align=right {0}", Environment.NewLine)
                    sb.AppendFormat(" x:num=""0.00"" x:fmla=""" & strFormula & """>0</td>{0}", Environment.NewLine)

                Next
                sb.AppendFormat(" </tr>")

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan='3' height=17 class=xl28 style='height:12.75pt'>MÉDIO</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td></td>{0}", Environment.NewLine)
                For j = 0 To p_intTotalProdutos - 1

                    strFormula = "=IF(SUM(" & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & ")&gt;0,SUBTOTAL(1," & retornaCelula(j + 5) & "5:" & retornaCelula(j + 5) & (p_intTotalLojas + 4) & "),0)"
                    sb.AppendFormat("  <td class=xl28 align=right {0}", Environment.NewLine)
                    sb.AppendFormat(" x:num=""0.00"" x:fmla=""" & strFormula & """>0</td>{0}", Environment.NewLine)

                Next
                sb.AppendFormat(" </tr>")

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan='2' height=17 class=xl28 style='height:12.75pt;border-top:none'>Total de{0}", Environment.NewLine)
                sb.AppendFormat("  Lojas Selecionadas</td>{0}", Environment.NewLine)
                strFormula = "=SUBTOTAL(3,B5:B" & p_intTotalLojas + 4 & ")"
                sb.AppendFormat("  <td class=xl44 align=right style='border-top:none;border-left:none' x:num{0}", Environment.NewLine)
                sb.AppendFormat("  x:fmla=""" & strFormula & """>0</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td class=xl48 style='border-top:none;border-left:none'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>{0}", Environment.NewLine)

                sb.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                sb.AppendFormat("  <td colspan='2' height=17 class=xl28 style='height:12.75pt;border-top:none'>Total de{0}", Environment.NewLine)
                sb.AppendFormat("  Lojas</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td class=xl44 align=right style='border-top:none;border-left:none' x:num{0}", Environment.NewLine)
                sb.AppendFormat(" >" & p_intTotalLojas & "</td>{0}", Environment.NewLine)
                sb.AppendFormat("  <td class=xl48 style='border-top:none;border-left:none'>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat(" </tr>{0}", Environment.NewLine)

                sb.AppendFormat("</table>{0}", Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)
                sb.AppendFormat("</body>{0}", Environment.NewLine)
                sb.AppendFormat("{0}", Environment.NewLine)
                sb.AppendFormat("</html>")

                Response.Write(sb.ToString)

            Else

                NaoEncontrado()

            End If

        End If

    End Sub

    Private Sub NaoEncontrado()

        Dim sb As New System.Text.StringBuilder

        sb.Append("<html>" & vbCrLf)
        sb.Append("<head><title>Relat&oacute;rio de An&aacute;lise de Preços</title></head>" & vbCrLf)
        sb.Append("<style>" & vbCrLf)
        sb.Append(".Titulo" & vbCrLf)
        sb.Append("{FONT-WEIGHT: normal; FONT-SIZE: 16pt; COLOR: #444444; " & vbCrLf)
        sb.Append("FONT-STYLE: normal; font-family: Verdana, Arial, Helvetica, sans-serif;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(".SubTitulo" & vbCrLf)
        sb.Append("{FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #444444; " & vbCrLf)
        sb.Append("FONT-STYLE: normal; font-family: Verdana, Arial, Helvetica, sans-serif;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(".Mensagem" & vbCrLf)
        sb.Append("{FONT-WEIGHT: normal; FONT-SIZE: 11pt; COLOR: #444444; " & vbCrLf)
        sb.Append("FONT-STYLE: normal; font-family: Verdana, Arial, Helvetica, sans-serif;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append("</style>" & vbCrLf)

        sb.Append("<body><form name='frm' id='frm'>")
        sb.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0' bgcolor=#ffffff>")
        sb.Append("<tr>")
        sb.Append("<td nowrap width=200><img src='../imagens/img_logo.gif' alt='' border='0'></td>")
        sb.Append("<td nowrap class=Titulo align=left>Relat&oacute;rio de An&aacute;lise de Preços</td>")
        sb.Append("</tr>")
        sb.Append("<tr>")
        sb.Append("<td nowrap colspan=2 class=SubTitulo align=left>Per&iacute;odo selecionado: " & ViewState("pertxt") & "</td>")
        sb.Append("</tr>")
        sb.Append("</table><br><br><br><br>")

        sb.Append("<table border=0 align='center' cellspacing='0'>")
        sb.Append("<tr><td class='Mensagem'><b>N&atilde;o foram localizadas informaç&otilde;es de acordo com o filtro selecionado</b></td></tr>")
        sb.Append("</table>")

        sb.Append("</body>")
        sb.Append("</html>")

        Response.Clear()
        Response.ClearHeaders()
        Response.AddHeader("Content-Length", sb.Length)
        Response.AddHeader("Last-Modified", Now().ToString)
        Response.Write(sb.ToString)

    End Sub


End Class
