Imports Classes
Imports System.Data.SqlClient
Imports System.Data
Imports Ionic.Utils.Zip

Partial Class reports_exportardet
    Inherits XMWebPage
    Protected cls As clsExportacao
    Protected m_intLinha As Integer = 0


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
    Private Const VW_TIPOPESQUISA As String = "tippes"
    Private Const VW_UF As String = "est"
    Private Const VW_PERIODO_TEXTO As String = "pertxt"
    Private Const VW_PERIODO As String = "per"
    Private Const VW_PERIODO_INICIAL As String = "pi"
    Private Const VW_PERIODO_FINAL As String = "pf"
    Private Const VW_JUSTIFICATIVA As String = "jus"
    Private Const VW_TABELAS As String = "tab"
    Private Const VW_FIELDS As String = "cam"




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsExportacao

        If Not Page.IsPostBack Then

            ViewState(VW_CATEGORIA) = Request(VW_CATEGORIA) & ""
            ViewState(VW_SUBCATEGORIA) = Request(VW_SUBCATEGORIA) & ""
            ViewState(VW_PRODUTO) = Request(VW_PRODUTO) & ""
            ViewState(VW_COORDENADOR) = Request(VW_COORDENADOR) & ""
            ViewState(VW_LIDER) = Request(VW_LIDER) & ""
            ViewState(VW_PROMOTOR) = Request(VW_PROMOTOR) & ""
            ViewState(VW_CLIENTE) = Request(VW_CLIENTE) & ""
            ViewState(VW_LOJA) = Request(VW_LOJA) & ""
            ViewState(VW_SHOPPING) = Request(VW_SHOPPING) & ""
            ViewState(VW_TIPOLOJA) = Request(VW_TIPOLOJA) & ""
            ViewState(VW_REGIAO) = Request(VW_REGIAO) & ""
            ViewState(VW_STATUS) = Request(VW_STATUS)
            ViewState(VW_TIPOPESQUISA) = Request(VW_TIPOPESQUISA) & ""
            ViewState(VW_UF) = Request(VW_UF) & ""
            ViewState(VW_PERIODO_TEXTO) = Request(VW_PERIODO_TEXTO) & ""
            ViewState(VW_PERIODO) = Request(VW_PERIODO) & ""
            ViewState(VW_JUSTIFICATIVA) = Request(VW_JUSTIFICATIVA) & ""
            ViewState(VW_TABELAS) = CInt("0" & Request(VW_TABELAS)) & ""
            ViewState(VW_FIELDS) = Request(VW_FIELDS)

            Dim p_Temp As Object = Split(ViewState(VW_PERIODO), "||", , CompareMethod.Text)
            ViewState(VW_PERIODO_INICIAL) = p_Temp(0)
            ViewState(VW_PERIODO_FINAL) = p_Temp(1)

        End If

        'Try

        ExportarDados()

        'Catch ex As System.Exception

        '    Dim sb As New System.Text.StringBuilder

        '    sb.Append("<table border=0 align='center' cellspacing='0'>")
        '    sb.Append("<tr><td class='Mensagem'><b>Erro : " & ex.Message & "</b><br />Linha:" & m_intLinha & "</td></tr>")
        '    sb.Append("</table>")

        '    sb.Append("</body>")
        '    sb.Append("</html>")

        '    Response.Clear()
        '    Response.ClearHeaders()
        '    Response.AddHeader("Content-Length", sb.Length)
        '    Response.AddHeader("Last-Modified", Now().ToString)
        '    Response.Write(sb.ToString)

        'Finally

        '    cls = Nothing

        'End Try


    End Sub

    Protected Sub ExportarDados()

        Dim dr As IDataReader = cls.ExportarDados(ViewState(VW_CLIENTE), ViewState(VW_LOJA), ViewState(VW_COORDENADOR), ViewState(VW_LIDER), ViewState(VW_PROMOTOR), _
                                ViewState(VW_CATEGORIA), ViewState(VW_SUBCATEGORIA), ViewState(VW_PRODUTO), ViewState(VW_UF), ViewState(VW_TIPOLOJA), ViewState(VW_REGIAO), _
                                ViewState(VW_STATUS), ViewState(VW_JUSTIFICATIVA), ViewState(VW_TABELAS), ViewState(VW_PERIODO_INICIAL), ViewState(VW_PERIODO_FINAL), ViewState(VW_SHOPPING), ViewState(VW_FIELDS))

        'grdExportar.DataSource = rs
        'grdExportar.DataBind()

        m_intLinha = 0

        Dim strOutput As New StringBuilder()
        strOutput.AppendFormat("<html xmlns:v=""urn:schemas-microsoft-com:vml""{0}", Environment.NewLine)
        strOutput.AppendFormat("xmlns:o=""urn:schemas-microsoft-com:office:office""{0}", Environment.NewLine)
        strOutput.AppendFormat("xmlns:x=""urn:schemas-microsoft-com:office:excel""{0}", Environment.NewLine)
        strOutput.AppendFormat("xmlns=""http://www.w3.org/TR/REC-html40"">{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}", Environment.NewLine)
        strOutput.AppendFormat("<head>{0}", Environment.NewLine)
        strOutput.AppendFormat("<meta http-equiv=Content-Type content=""text/html; charset=UTF-8"">{0}", Environment.NewLine)
        strOutput.AppendFormat("<meta name=ProgId content=Excel.Sheet>{0}", Environment.NewLine)
        strOutput.AppendFormat("<meta name=Generator content=""Microsoft Excel 11"">{0}", Environment.NewLine)
        strOutput.AppendFormat("<!--[if !mso]>{0}", Environment.NewLine)
        strOutput.AppendFormat("<style>{0}", Environment.NewLine)
        strOutput.AppendFormat("v\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
        strOutput.AppendFormat("o\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
        strOutput.AppendFormat("x\:* {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
        strOutput.AppendFormat(".shape {{behavior:url(#default#VML);}}{0}", Environment.NewLine)
        strOutput.AppendFormat("</style>{0}", Environment.NewLine)
        strOutput.AppendFormat("<![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <o:DocumentProperties>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:Author>Usuario</o:Author>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:LastAuthor>Usuario</o:LastAuthor>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:Created>2008-10-16T18:41:34Z</o:Created>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:LastSaved>2008-10-16T18:50:41Z</o:LastSaved>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:Version>11.5606</o:Version>{0}", Environment.NewLine)
        strOutput.AppendFormat(" </o:DocumentProperties>{0}", Environment.NewLine)
        strOutput.AppendFormat("</xml><![endif]-->{0}", Environment.NewLine)
        strOutput.AppendFormat("<style>{0}", Environment.NewLine)
        strOutput.AppendFormat("<!--table{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-displayed-decimal-separator:""\,"";{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-displayed-thousand-separator:""\."";}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("@page{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{margin:.98in .79in .98in .79in;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-header-margin:.49in;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-footer-margin:.49in;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("tr{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-height-source:auto;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("col{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-width-source:auto;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("br{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-data-placement:same-cell;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".style0{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-number-format:General;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-align:general;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}vertical-align:bottom;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:nowrap;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-rotate:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-background-source:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:windowtext;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-size:10.0pt;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-weight:400;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-style:normal;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-decoration:none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Arial;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-generic-font-family:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}border:none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-protection:locked visible;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-style-name:Normal;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-style-id:0;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("td{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}padding:0px;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-ignore:padding;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:windowtext;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-size:10.0pt;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-weight:400;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-style:normal;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-decoration:none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Arial;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-generic-font-family:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:General;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-align:general;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}vertical-align:bottom;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}border:none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-background-source:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-protection:locked visible;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:nowrap;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-rotate:0;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl24{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-align:center;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:#3366FF;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl25{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:#333333;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl25N{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:#333333;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl26{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:#333333;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:""General Date"";{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl27{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:0;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl28{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-weight:700;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}text-align:center;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}vertical-align:middle;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:#3366FF;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat(".xl29{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}{{mso-style-parent:style0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}color:#333333;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}font-family:Verdana, sans-serif;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-font-charset:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-number-format:0;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}background:white;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}mso-pattern:auto none;{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("{0}white-space:normal;}}{1}", ControlChars.Tab, Environment.NewLine)
        strOutput.AppendFormat("-->{0}", Environment.NewLine)
        strOutput.AppendFormat("</style>{0}", Environment.NewLine)
        strOutput.AppendFormat("<!--[if gte mso 9]><xml>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <x:ExcelWorkbook>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <x:ExcelWorksheets>{0}", Environment.NewLine)
        strOutput.AppendFormat("   <x:ExcelWorksheet>{0}", Environment.NewLine)
        strOutput.AppendFormat("    <x:Name>Exportação de Dados</x:Name>{0}", Environment.NewLine)
        strOutput.AppendFormat("    <x:WorksheetOptions>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:Print>{0}", Environment.NewLine)
        strOutput.AppendFormat("      <x:ValidPrinterInfo/>{0}", Environment.NewLine)
        strOutput.AppendFormat("      <x:PaperSizeIndex>9</x:PaperSizeIndex>{0}", Environment.NewLine)
        strOutput.AppendFormat("      <x:HorizontalResolution>600</x:HorizontalResolution>{0}", Environment.NewLine)
        strOutput.AppendFormat("      <x:VerticalResolution>600</x:VerticalResolution>{0}", Environment.NewLine)
        strOutput.AppendFormat("     </x:Print>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:CodeName>Exportação de Dados</x:CodeName>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:Selected/>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:Panes>{0}", Environment.NewLine)
        strOutput.AppendFormat("      <x:Pane>{0}", Environment.NewLine)
        strOutput.AppendFormat("       <x:Number>1</x:Number>{0}", Environment.NewLine)
        strOutput.AppendFormat("       <x:ActiveRow>1</x:ActiveRow>{0}", Environment.NewLine)
        strOutput.AppendFormat("       <x:ActiveCol>1</x:ActiveCol>{0}", Environment.NewLine)
        strOutput.AppendFormat("      </x:Pane>{0}", Environment.NewLine)
        strOutput.AppendFormat("     </x:Panes>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:ProtectContents>False</x:ProtectContents>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:ProtectObjects>False</x:ProtectObjects>{0}", Environment.NewLine)
        strOutput.AppendFormat("     <x:ProtectScenarios>False</x:ProtectScenarios>{0}", Environment.NewLine)
        strOutput.AppendFormat("    </x:WorksheetOptions>{0}", Environment.NewLine)
        strOutput.AppendFormat("   </x:ExcelWorksheet>{0}", Environment.NewLine)
        strOutput.AppendFormat("  </x:ExcelWorksheets>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <x:WindowHeight>13170</x:WindowHeight>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <x:WindowWidth>15180</x:WindowWidth>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <x:WindowTopX>120</x:WindowTopX>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <x:WindowTopY>45</x:WindowTopY>{0}", Environment.NewLine)
        strOutput.AppendFormat(" </x:ExcelWorkbook>{0}", Environment.NewLine)
        strOutput.AppendFormat("</xml><![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <o:shapedefaults v:ext=""edit"" spidmax=""1027""/>{0}", Environment.NewLine)
        strOutput.AppendFormat("</xml><![endif]--><!--[if gte mso 9]><xml>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <o:shapelayout v:ext=""edit"">{0}", Environment.NewLine)
        strOutput.AppendFormat("  <o:idmap v:ext=""edit"" data=""1""/>{0}", Environment.NewLine)
        strOutput.AppendFormat(" </o:shapelayout></xml><![endif]-->{0}", Environment.NewLine)
        strOutput.AppendFormat("</head>{0}", Environment.NewLine)
        strOutput.AppendFormat("{0}", Environment.NewLine)
        strOutput.AppendFormat("<body link=blue vlink=purple>{0}", Environment.NewLine)
        strOutput.AppendFormat("<table x:str border=0 cellpadding=0 cellspacing=0 width=9142 style='border-collapse:{0}", Environment.NewLine)
        strOutput.AppendFormat(" collapse;table-layout:fixed;width:6863pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=66 style='mso-width-source:userset;mso-width-alt:2413;width:50pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=180 style='mso-width-source:userset;mso-width-alt:6582;width:135pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=100 style='mso-width-source:userset;mso-width-alt:3657;width:75pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=144 style='mso-width-source:userset;mso-width-alt:5266;width:108pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col class=xl27 width=104 style='mso-width-source:userset;mso-width-alt:3803;{0}", Environment.NewLine)
        strOutput.AppendFormat(" width:78pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=227 style='mso-width-source:userset;mso-width-alt:8301;width:170pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=107 style='mso-width-source:userset;mso-width-alt:3913;width:80pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=154 style='mso-width-source:userset;mso-width-alt:5632;width:116pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=128 style='mso-width-source:userset;mso-width-alt:4681;width:96pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=100 style='mso-width-source:userset;mso-width-alt:3657;width:75pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=68 style='mso-width-source:userset;mso-width-alt:2486;width:51pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=78 style='mso-width-source:userset;mso-width-alt:2852;width:59pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=108 style='mso-width-source:userset;mso-width-alt:3949;width:81pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=92 style='mso-width-source:userset;mso-width-alt:3364;width:69pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=112 style='mso-width-source:userset;mso-width-alt:4096;width:84pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=101 style='mso-width-source:userset;mso-width-alt:3693;width:76pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=76 style='mso-width-source:userset;mso-width-alt:2779;width:57pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=89 style='mso-width-source:userset;mso-width-alt:3254;width:67pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=97 style='mso-width-source:userset;mso-width-alt:3547;width:73pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=160 style='mso-width-source:userset;mso-width-alt:5851;width:120pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=99 style='mso-width-source:userset;mso-width-alt:3620;width:74pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=97 style='mso-width-source:userset;mso-width-alt:3547;width:73pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=173 style='mso-width-source:userset;mso-width-alt:6326;width:130pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=148 style='mso-width-source:userset;mso-width-alt:5412;width:111pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=129 style='mso-width-source:userset;mso-width-alt:4717;width:97pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=147 style='mso-width-source:userset;mso-width-alt:5376;width:110pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=115 style='mso-width-source:userset;mso-width-alt:4205;width:86pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=157 style='mso-width-source:userset;mso-width-alt:5741;width:118pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=145 style='mso-width-source:userset;mso-width-alt:5302;width:109pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=192 style='mso-width-source:userset;mso-width-alt:7021;width:144pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=132 style='mso-width-source:userset;mso-width-alt:4827;width:99pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=115 style='mso-width-source:userset;mso-width-alt:4205;width:86pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=138 style='mso-width-source:userset;mso-width-alt:5046;width:104pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=106 style='mso-width-source:userset;mso-width-alt:3876;width:80pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=146 style='mso-width-source:userset;mso-width-alt:5339;width:110pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=150 style='mso-width-source:userset;mso-width-alt:5485;width:113pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=139 style='mso-width-source:userset;mso-width-alt:5083;width:104pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=114 style='mso-width-source:userset;mso-width-alt:4169;width:86pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=277 style='mso-width-source:userset;mso-width-alt:10130;width:208pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=131 style='mso-width-source:userset;mso-width-alt:4790;width:98pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=153 style='mso-width-source:userset;mso-width-alt:5595;width:115pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=128 style='mso-width-source:userset;mso-width-alt:4681;width:96pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=172 style='mso-width-source:userset;mso-width-alt:6290;width:129pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=110 style='mso-width-source:userset;mso-width-alt:4022;width:83pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=128 span=3 style='mso-width-source:userset;mso-width-alt:4681;{0}", Environment.NewLine)
        strOutput.AppendFormat(" width:96pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=150 style='mso-width-source:userset;mso-width-alt:5485;width:113pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=98 style='mso-width-source:userset;mso-width-alt:3584;width:74pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=184 style='mso-width-source:userset;mso-width-alt:6729;width:138pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <col width=282 style='mso-width-source:userset;mso-width-alt:10313;width:212pt'>{0}", Environment.NewLine)
        If ViewState(VW_TABELAS) = 1 Then
            strOutput.AppendFormat(" <col width=155 style='mso-width-source:userset;mso-width-alt:5668;width:116pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=222 style='mso-width-source:userset;mso-width-alt:8118;width:167pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=80 style='mso-width-source:userset;mso-width-alt:2925;width:60pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=108 style='mso-width-source:userset;mso-width-alt:3949;width:81pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=92 style='mso-width-source:userset;mso-width-alt:3364;width:69pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=171 style='mso-width-source:userset;mso-width-alt:6253;width:128pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=176 style='mso-width-source:userset;mso-width-alt:6436;width:132pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=184 style='mso-width-source:userset;mso-width-alt:6729;width:138pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=203 style='mso-width-source:userset;mso-width-alt:7424;width:152pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=160 style='mso-width-source:userset;mso-width-alt:5851;width:120pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=255 style='mso-width-source:userset;mso-width-alt:9325;width:191pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=178 style='mso-width-source:userset;mso-width-alt:6509;width:134pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=153 style='mso-width-source:userset;mso-width-alt:5595;width:115pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=203 style='mso-width-source:userset;mso-width-alt:7424;width:152pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat(" <col width=282 span=191 style='mso-width-source:userset;mso-width-alt:10313;width:212pt'>{0}", Environment.NewLine)
            For x As Integer = 65 To dr.FieldCount - 1
                strOutput.AppendFormat(" <col width=282 span=191 style='mso-width-source:userset;mso-width-alt:10313;width:212pt'>{0}", Environment.NewLine)
            Next
        Else
            For x As Integer = 50 To dr.FieldCount - 1
                strOutput.AppendFormat(" <col width=282 span=191 style='mso-width-source:userset;mso-width-alt:10313;width:212pt'>{0}", Environment.NewLine)
            Next
        End If

        strOutput.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td height=17 class=xl24 width=66 style='height:12.75pt;width:50pt'>IDVisita</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=180 style='width:135pt'>Loja</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=100 style='width:75pt'>Loja_Codigo</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=144 style='width:108pt'>Loja_CNPJ</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl28 width=104 style='width:78pt'>Loja_IE</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=227 style='width:170pt'>Loja_Endereco</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=107 style='width:80pt'>Loja_Numero</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=154 style='width:116pt'>Loja_Complemento</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=128 style='width:96pt'>Loja_Bairro</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=100 style='width:75pt'>Loja_Cidade</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=68 style='width:51pt'>Loja_UF</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=78 style='width:59pt'>Loja_Cep</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=108 style='width:81pt'>Loja_Contato</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=92 style='width:69pt'>Loja_Cargo</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=112 style='width:84pt'>Loja_Telefone</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=101 style='width:76pt'>Loja_Celular</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=76 style='width:57pt'>Loja_Fax</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=89 style='width:67pt'>Loja_Email</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=97 style='width:73pt'>TipoLoja</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=160 style='width:120pt'>Shopping</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=99 style='width:74pt'>Loja_Regiao</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=97 style='width:73pt'>Loja_Status</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=173 style='width:130pt'>Bandeira_RazaoSocial</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=148 style='width:111pt'>Bandeira_Fantasia</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=129 style='width:97pt'>PromotorCodigo</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=147 style='width:110pt'>Promotor</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=115 style='width:86pt'>Promotor_CPF</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=157 style='width:118pt'>Promotor_Endereco</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=145 style='width:109pt'>Promotor_Numero</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=192 style='width:144pt'>Promotor_Complemento</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=132 style='width:99pt'>Promotor_Bairro</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=115 style='width:86pt'>Promotor_Cep</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=138 style='width:104pt'>Promotor_Cidade</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=106 style='width:80pt'>Promotor_UF</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=146 style='width:110pt'>Promotor_Contato</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=150 style='width:113pt'>Promotor_Telefone</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=139 style='width:104pt'>Promotor_Celular</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=114 style='width:86pt'>Promotor_Fax</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=277 style='width:208pt'>Promotor_Email</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=131 style='width:98pt'>Promotor_Cargo</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=153 style='width:115pt'>Promotor_Empresa</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=128 style='width:96pt'>Promotor_Teste</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=172 style='width:129pt'>Lider</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=172 style='width:129pt'>IDLider</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=110 style='width:83pt'>Coordenador</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=110 style='width:83pt'>IDCoordenador</td>{0}", Environment.NewLine)
        ' strOutput.AppendFormat("  <td class=xl24 width=128 style='width:96pt'>DataInicio</td>{0}", Environment.NewLine)
        ' strOutput.AppendFormat("  <td class=xl24 width=128 style='width:96pt'>DataFinalizacao</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=128 style='width:96pt'>Data</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=150 style='width:113pt'>NumProdutosVisita</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=98 style='width:74pt'>Justificativa</td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td class=xl24 width=184 style='width:138pt'>NumProdutosColetados</td>{0}", Environment.NewLine)

        If ViewState(VW_TABELAS) = 1 Then

            strOutput.AppendFormat("  <td class=xl24 width=282 style='width:212pt'>Produto_Codigo</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=155 style='width:116pt'>Produto_Descricao</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=222 style='width:167pt'>Produto_DescricaoResumida</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=80 style='width:60pt'>Categoria</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=108 style='width:81pt'>SubCategoria</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=92 style='width:69pt'>Fornecedor</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=171 style='width:128pt'>Produto_PrecoMinimo</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=176 style='width:132pt'>Produto_PrecoMaximo</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=184 style='width:138pt'>Produto_PrecoSugerido</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=203 style='width:152pt'>ProdutoVisita_Encontrado</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=160 style='width:120pt'>ProdutoVisita_Preco</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=255 style='width:191pt'>ProdutoVisita_VisualizouEstoque</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=178 style='width:134pt'>ProdutoVisita_Estoque</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=153 style='width:115pt'>ProdutoVisita_Data</td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td class=xl24 width=203 style='width:152pt'>ProdutoVisita_Pesquisado</td>{0}", Environment.NewLine)

            For x As Integer = 65 To dr.FieldCount - 1

                strOutput.AppendFormat("  <td class=xl24 width=203 style='width:152pt'>" & dr.GetName(x) & "</td>{0}", Environment.NewLine)

            Next

        Else

            For x As Integer = 50 To dr.FieldCount - 1

                strOutput.AppendFormat("  <td class=xl24 width=203 style='width:152pt'>" & dr.GetName(x) & "</td>{0}", Environment.NewLine)

            Next

        End If

        strOutput.AppendFormat(" </tr>{0}", Environment.NewLine)




        'IDVisita    Loja                                                                                                                                                                                                     Loja_Codigo          Loja_CNPJ            Loja_IE              Loja_Endereco                                                                                        Loja_Numero          Loja_Complemento               Loja_Bairro                                        Loja_Cidade                                                                                          Loja_UF Loja_Cep  Loja_Contato                                       Loja_Cargo                     Loja_Telefone                  Loja_Celular                   Loja_Fax             Loja_Email                                                                                           TipoLoja                                           Shopping                                                                                             Loja_Regiao                                        Loja_Status Bandeira_RazaoSocial                                                                                 Bandeira_Fantasia                                                                                    PromotorCodigo       Promotor                                                                                             Promotor_CPF         Promotor_Endereco                                                                                    Promotor_Numero                                    Promotor_Complemento Promotor_Bairro                                    Promotor_Cep                                       Promotor_Cidade                                    Promotor_UF Promotor_Contato                                                                                     Promotor_Telefone              Promotor_Celular               Promotor_Fax                   Promotor_Email                                                                                                                                                                                                                                             Promotor_Cargo                                                                                       Promotor_Empresa                                                                                     Promotor_Teste Lider                                                                                                Coordenador                                                                                          DataInicio              DataFinalizacao         Data                    NumProdutosVisita Justificativa                                      NumProdutosColetados Produto_Codigo            Produto_Descricao                                            Produto_DescricaoResumida                                    Categoria                                          SubCategoria                                       Fornecedor                                         Produto_PrecoMinimo   Produto_PrecoMaximo   Produto_PrecoSugerido ProdutoVisita_Encontrado ProdutoVisita_Preco   ProdutoVisita_VisualizouEstoque ProdutoVisita_Estoque ProdutoVisita_Data      ProdutoVisita_Pesquisado
        Do While dr.Read

            m_intLinha += 1

            strOutput.AppendFormat(" <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td height=17 class=xl25 align=right width=66 style='height:12.75pt;{0}", Environment.NewLine)
            strOutput.AppendFormat("  width:50pt' x:num>{1}</td>{0}", Environment.NewLine, dr.GetInt32(dr.GetOrdinal("IDVisita")))
            strOutput.AppendFormat("  <td class=xl25 width=180 style='width:135pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja")) = False, dr.GetString(dr.GetOrdinal("Loja")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=100 style='width:75pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Codigo")) = False, dr.GetString(dr.GetOrdinal("Loja_Codigo")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=144 style='width:108pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_CNPJ")) = False, dr.GetString(dr.GetOrdinal("Loja_CNPJ")), ""))
            strOutput.AppendFormat("  <td class=xl29 align=right width=104 style='width:78pt' x:num=""{1}"">{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_IE")) = False, dr.GetString(dr.GetOrdinal("Loja_IE")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=227 style='width:170pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Endereco")) = False, dr.GetString(dr.GetOrdinal("Loja_Endereco")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=107 style='width:80pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Numero")) = False, dr.GetString(dr.GetOrdinal("Loja_Numero")), ""))
            If dr.IsDBNull(dr.GetOrdinal("Loja_Complemento")) Then
                strOutput.AppendFormat("  <td class=xl25 width=104 style='width:78pt'>&nbsp;</td>{0}", Environment.NewLine)
            Else
                strOutput.AppendFormat("  <td class=xl25 width=104 style='width:78pt'>{1}</td>{0}", Environment.NewLine, dr.GetString(dr.GetOrdinal("Loja_Complemento")))
            End If
            strOutput.AppendFormat("  <td class=xl25 width=128 style='width:96pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Bairro")) = False, dr.GetString(dr.GetOrdinal("Loja_Bairro")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=100 style='width:75pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Cidade")) = False, dr.GetString(dr.GetOrdinal("Loja_Cidade")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=68 style='width:51pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_UF")) = False, dr.GetString(dr.GetOrdinal("Loja_UF")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=78 style='width:59pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Cep")) = False, dr.GetString(dr.GetOrdinal("Loja_Cep")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=108 style='width:81pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Contato")) = False, dr.GetString(dr.GetOrdinal("Loja_Contato")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=92 style='width:69pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Cargo")) = False, dr.GetString(dr.GetOrdinal("Loja_Cargo")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=112 style='width:84pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Telefone")) = False, dr.GetString(dr.GetOrdinal("Loja_Telefone")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=112 style='width:84pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Celular")) = False, dr.GetString(dr.GetOrdinal("Loja_Celular")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=112 style='width:84pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Fax")) = False, dr.GetString(dr.GetOrdinal("Loja_Fax")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=112 style='width:84pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Email")) = False, dr.GetString(dr.GetOrdinal("Loja_Email")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=97 style='width:73pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("TipoLoja")) = False, dr.GetString(dr.GetOrdinal("TipoLoja")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=112 style='width:84pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Shopping")) = False, dr.GetString(dr.GetOrdinal("Shopping")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=99 style='width:74pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Regiao")) = False, dr.GetString(dr.GetOrdinal("Loja_Regiao")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=97 style='width:73pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Loja_Status")) = False, dr.GetString(dr.GetOrdinal("Loja_Status")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=173 style='width:130pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Bandeira_RazaoSocial")) = False, dr.GetString(dr.GetOrdinal("Bandeira_RazaoSocial")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=148 style='width:111pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Bandeira_Fantasia")) = False, dr.GetString(dr.GetOrdinal("Bandeira_Fantasia")), ""))
            strOutput.AppendFormat("  <td class=xl25N align=right width=129 style='width:97pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("PromotorCodigo")) = False, dr.GetString(dr.GetOrdinal("PromotorCodigo")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=147 style='width:110pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor")) = False, dr.GetString(dr.GetOrdinal("Promotor")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=115 style='width:86pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_CPF")) = False, dr.GetString(dr.GetOrdinal("Promotor_CPF")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=157 style='width:118pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Endereco")) = False, dr.GetString(dr.GetOrdinal("Promotor_Endereco")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=145 style='width:109pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Numero")) = False, dr.GetString(dr.GetOrdinal("Promotor_Numero")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=192 style='width:144pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Complemento")) = False, dr.GetString(dr.GetOrdinal("Promotor_Complemento")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=132 style='width:99pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Bairro")) = False, dr.GetString(dr.GetOrdinal("Promotor_Bairro")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=115 style='width:86pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Cep")) = False, dr.GetString(dr.GetOrdinal("Promotor_Cep")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=138 style='width:104pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Cidade")) = False, dr.GetString(dr.GetOrdinal("Promotor_Cidade")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=106 style='width:80pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_UF")) = False, dr.GetString(dr.GetOrdinal("Promotor_UF")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=146 style='width:110pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Contato")) = False, dr.GetString(dr.GetOrdinal("Promotor_Contato")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=150 style='width:113pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Telefone")) = False, dr.GetString(dr.GetOrdinal("Promotor_Telefone")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=139 style='width:104pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Celular")) = False, dr.GetString(dr.GetOrdinal("Promotor_Celular")), ""))
            strOutput.AppendFormat("  <td class=xl25 align=right width=139 style='width:104pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Fax")) = False, dr.GetString(dr.GetOrdinal("Promotor_Fax")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=277 style='width:208pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Email")) = False, dr.GetString(dr.GetOrdinal("Promotor_Email")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=131 style='width:98pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Cargo")) = False, dr.IsDBNull(dr.GetOrdinal("Promotor_Cargo")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=153 style='width:115pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Empresa")) = False, dr.GetString(dr.GetOrdinal("Promotor_Empresa")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=128 style='width:96pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Promotor_Teste")) = False, dr.GetString(dr.GetOrdinal("Promotor_Teste")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=172 style='width:129pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Lider")) = False, dr.GetString(dr.GetOrdinal("Lider")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=172 style='width:129pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("IDLider")) = False, dr.GetString(dr.GetOrdinal("IDLider")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=110 style='width:83pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Coordenador")) = False, dr.GetString(dr.GetOrdinal("Coordenador")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=110 style='width:83pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("IDCoordenador")) = False, dr.GetString(dr.GetOrdinal("IDCoordenador")), ""))
            'strOutput.AppendFormat("  <td class=xl26 align=right width=128 style='width:96pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("DataInicio")) = False, dr.GetDateTime(dr.GetOrdinal("DataInicio")).ToString(), ""))
            '            strOutput.AppendFormat("  x:num=""39729.722916666666"">08/10/2008 17:21</td>{0}", Environment.NewLine)
            'strOutput.AppendFormat("  <td class=xl26 align=right width=128 style='width:96pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("DataFinalizacao")) = False, dr.GetDateTime(dr.GetOrdinal("DataFinalizacao")).ToString(), ""))
            strOutput.AppendFormat("  <td class=xl26 align=right width=128 style='width:96pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Data")) = False, dr.GetDateTime(dr.GetOrdinal("Data")).ToString(), ""))
            strOutput.AppendFormat("  <td class=xl25N align=right width=150 style='width:113pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("NumProdutosVisita")) = False, dr.GetInt32(dr.GetOrdinal("NumProdutosVisita")), ""))
            strOutput.AppendFormat("  <td class=xl25 width=98 style='width:74pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Justificativa")) = False, dr.GetString(dr.GetOrdinal("Justificativa")), ""))
            strOutput.AppendFormat("  <td class=xl25N align=right width=184 style='width:138pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("NumProdutosColetados")) = False, dr.GetInt32(dr.GetOrdinal("NumProdutosColetados")), ""))

            If ViewState(VW_TABELAS) = 1 Then

                strOutput.AppendFormat("  <td class=xl25 width=282 style='width:212pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_Codigo")) = False, dr.GetString(dr.GetOrdinal("Produto_Codigo")), ""))
                strOutput.AppendFormat("  <td class=xl25 width=155 style='width:116pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_Descricao")) = False, dr.GetString(dr.GetOrdinal("Produto_Descricao")), ""))
                strOutput.AppendFormat("  <td class=xl25 width=222 style='width:167pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_DescricaoResumida")) = False, dr.GetString(dr.GetOrdinal("Produto_DescricaoResumida")), ""))
                strOutput.AppendFormat("  <td class=xl25 width=80 style='width:60pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Categoria")) = False, dr.GetString(dr.GetOrdinal("Categoria")), ""))
                strOutput.AppendFormat("  <td class=xl25 width=108 style='width:81pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("SubCategoria")) = False, dr.GetString(dr.GetOrdinal("SubCategoria")), ""))
                strOutput.AppendFormat("  <td class=xl25 width=92 style='width:69pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Fornecedor")) = False, dr.GetString(dr.GetOrdinal("Fornecedor")), ""))
                strOutput.AppendFormat("  <td class=xl25N align=right width=171 style='width:128pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_PrecoMinimo")) = False, dr.GetDecimal(dr.GetOrdinal("Produto_PrecoMinimo")), ""))
                strOutput.AppendFormat("  <td class=xl25N align=right width=176 style='width:132pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_PrecoMaximo")) = False, dr.GetDecimal(dr.GetOrdinal("Produto_PrecoMaximo")), ""))
                If dr.IsDBNull(dr.GetOrdinal("Produto_PrecoSugerido")) Then
                    strOutput.AppendFormat("  <td class=xl25 width=104 style='width:78pt'>&nbsp;</td>{0}", Environment.NewLine)
                Else
                    strOutput.AppendFormat("  <td class=xl25 width=104 style='width:78pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("Produto_PrecoMaximo")) = False, dr.GetDecimal(dr.GetOrdinal("Produto_PrecoSugerido")), ""))
                End If
                strOutput.AppendFormat("  <td class=xl25N width=203 style='width:152pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("ProdutoVisita_Encontrado")) = False, dr.GetString(dr.GetOrdinal("ProdutoVisita_Encontrado")), ""))
                strOutput.AppendFormat("  <td class=xl25N align=right width=160 style='width:120pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("ProdutoVisita_Preco")) = False, dr.GetDecimal(dr.GetOrdinal("ProdutoVisita_Preco")), ""))
                strOutput.AppendFormat("  <td class=xl25N width=255 style='width:191pt'>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("ProdutoVisita_VisualizouEstoque")) = False, dr.GetString(dr.GetOrdinal("ProdutoVisita_VisualizouEstoque")), ""))
                strOutput.AppendFormat("  <td class=xl25N align=right width=178 style='width:134pt' x:num>{1}</td>{0}", Environment.NewLine, IIf(dr.IsDBNull(dr.GetOrdinal("ProdutoVisita_Estoque")) = False, dr.GetInt32(dr.GetOrdinal("ProdutoVisita_Estoque")), ""))
                strOutput.AppendFormat("  <td class=xl26 align=right width=153 style='width:115pt>{1}</td>{0}", Environment.NewLine, dr.GetDateTime(dr.GetOrdinal("ProdutoVisita_Data")))
                strOutput.AppendFormat("  <td class=xl25N width=203 style='width:152pt'>{1}</td>{0}", Environment.NewLine, dr.GetString(dr.GetOrdinal("ProdutoVisita_Pesquisado")))


                For x As Integer = 65 To dr.FieldCount - 1
                    Try
                        If dr.IsDBNull(x) Then
                            strOutput.AppendFormat("  <td class=xl25 width=203 style='width:152pt'>&nbsp;</td>{0}", Environment.NewLine)
                        Else
                            strOutput.AppendFormat("  <td class=xl25N width=203 style='width:152pt'>" & IIf(dr.IsDBNull(x) = False, dr.Item(x), "") & "</td>{0}", Environment.NewLine)
                        End If
                    Catch ex As Exception

                        Response.Write(ex.Message & " - " & x)

                    End Try
                Next


            Else

                For x As Integer = 50 To dr.FieldCount - 1
                    If dr.IsDBNull(x) Then
                        strOutput.AppendFormat("  <td class=xl25 width=203 style='width:152pt'>&nbsp;</td>{0}", Environment.NewLine)
                    Else
                        strOutput.AppendFormat("  <td class=xl25N width=203 style='width:152pt'>" & IIf(dr.IsDBNull(x) = False, dr.GetString(x), "") & "</td>{0}", Environment.NewLine)
                    End If
                Next

            End If

            strOutput.AppendFormat(" </tr>{0}", Environment.NewLine)

        Loop

        strOutput.AppendFormat(" <![if supportMisalignedColumns]>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <tr height=0 style='display:none'>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=66 style='width:50pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=180 style='width:135pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=100 style='width:75pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=144 style='width:108pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=104 style='width:78pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=227 style='width:170pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=107 style='width:80pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=154 style='width:116pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=128 style='width:96pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=100 style='width:75pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=68 style='width:51pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=78 style='width:59pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=108 style='width:81pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=92 style='width:69pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=112 style='width:84pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=101 style='width:76pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=76 style='width:57pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=89 style='width:67pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=97 style='width:73pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=160 style='width:120pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=99 style='width:74pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=97 style='width:73pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=173 style='width:130pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=148 style='width:111pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=129 style='width:97pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=147 style='width:110pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=115 style='width:86pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=157 style='width:118pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=145 style='width:109pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=192 style='width:144pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=132 style='width:99pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=115 style='width:86pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=138 style='width:104pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=106 style='width:80pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=146 style='width:110pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=150 style='width:113pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=139 style='width:104pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=114 style='width:86pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=277 style='width:208pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=131 style='width:98pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=153 style='width:115pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=128 style='width:96pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=172 style='width:129pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=110 style='width:83pt'></td>{0}", Environment.NewLine)
        'strOutput.AppendFormat("  <td width=128 style='width:96pt'></td>{0}", Environment.NewLine)
        'strOutput.AppendFormat("  <td width=128 style='width:96pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=128 style='width:96pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=150 style='width:113pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=98 style='width:74pt'></td>{0}", Environment.NewLine)
        strOutput.AppendFormat("  <td width=184 style='width:138pt'></td>{0}", Environment.NewLine)

        If ViewState(VW_TABELAS) = 1 Then

            strOutput.AppendFormat("  <td width=282 style='width:212pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=155 style='width:116pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=222 style='width:167pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=80 style='width:60pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=108 style='width:81pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=92 style='width:69pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=171 style='width:128pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=176 style='width:132pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=184 style='width:138pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=203 style='width:152pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=160 style='width:120pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=255 style='width:191pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=178 style='width:134pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=153 style='width:115pt'></td>{0}", Environment.NewLine)
            strOutput.AppendFormat("  <td width=203 style='width:152pt'></td>{0}", Environment.NewLine)

            For x As Integer = 65 To dr.FieldCount - 1
                strOutput.AppendFormat("  <td width=203 style='width:152pt'></td>{0}", Environment.NewLine)
            Next

        Else

            For x As Integer = 50 To dr.FieldCount - 1
                strOutput.AppendFormat("  <td width=203 style='width:152pt'></td>{0}", Environment.NewLine)
            Next

        End If

        strOutput.AppendFormat(" </tr>{0}", Environment.NewLine)
        strOutput.AppendFormat(" <![endif]>{0}", Environment.NewLine)
        strOutput.AppendFormat("</table>{0}", Environment.NewLine)
        strOutput.AppendFormat("</body>{0}", Environment.NewLine)
        strOutput.AppendFormat("</html>{0}", Environment.NewLine)

        Dim zipFileName As String = "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".zip"
        Dim zip As ZipFile

        Response.Clear()
        Response.ClearHeaders()
        Response.AddHeader("Content-Disposition", "attachment; filename=" & zipFileName)
        Response.ContentType = "application/x-zip-compressed"
        Response.AddHeader("Last-Modified", Now().ToString)


        zip = New ZipFile(Response.OutputStream)
        zip.AddStringAsFile(strOutput.ToString(), "EXPORTACAO_" & Now.ToString("ddMMyyyyhhmmss") & ".xls", "")
        zip.Save()
        zip.Dispose()
        zip = Nothing

        Response.End()

    End Sub
End Class
