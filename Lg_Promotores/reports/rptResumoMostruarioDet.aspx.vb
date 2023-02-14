Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptResumoMostruarioDet
    Inherits XMWebPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim rep As New clsReports
            Dim dr As IDataReader
            dr = rep.getRelatorioMostruarioResumo(Request("rg") & "", Request("est") & "", Request("tp") & "", Request("sh") & "", Request("lj") & "", Request("pi"), Request("pf"))

            Dim strRelatorio As New StringBuilder()

            Dim blnStart As Boolean = True
            Dim blnFirst As Boolean = True
            Dim strSubCategoria As String = ""
            Dim strFornecedor As String = ""
            Dim strFirstDate As String = ""

            Dim intTableSize As Integer


            Dim intColunas As Integer, intCol As Integer, intTotalColunas As Integer, strRegiao As String
            intCol = 1
            intTotalColunas = 0
            strRegiao = ""

            Dim intFornecedores As Integer
            If dr.Read() Then
                intColunas = dr.GetInt32(0) + 1
                strRegiao = dr.GetString(1)
            End If

            intTableSize = (intColunas * 80) + 300

            dr.NextResult()




            

            Dim strHeader1 As New StringBuilder
            Dim strHeader2 As New StringBuilder

            strHeader1.AppendFormat("            <table cellpadding='0' cellspacing='0' style='width:{1}pt'>{0}", Environment.NewLine, intTableSize)
            strHeader1.AppendFormat("             <tr height=60>{0}", Environment.NewLine)
            'strHeader1.AppendFormat("              <td height=60 class=xl50>teste</td>{0}", Environment.NewLine)
            'strHeader1.AppendFormat("              <td class=xl51>&nbsp;</td>{0}", Environment.NewLine)
            strHeader1.AppendFormat("              <td colspan='2' class=xl50>Regional: " & strRegiao & "</td>{0}", Environment.NewLine)


            strHeader2.AppendFormat("             <tr>{0}", Environment.NewLine)
            strHeader2.AppendFormat("              <td class=xl36 style='height:33.0pt'>Categoria</td>{0}", Environment.NewLine)
            strHeader2.AppendFormat("              <td class=xl36>Empresa</td>{0}", Environment.NewLine)

            Do While dr.Read
                intFornecedores = dr.GetInt32(dr.GetOrdinal("Fornecedores"))
                If blnStart Then
                    If (strFornecedor <> dr.GetString(dr.GetOrdinal("Fornecedor")) And strFornecedor <> "") Or (strSubCategoria <> dr.GetString(dr.GetOrdinal("SubCategoria")) And strSubCategoria <> "") Then
                        strHeader1.AppendFormat("             </tr>{0}", Environment.NewLine)
                        strHeader2.AppendFormat("             </tr>{0}", Environment.NewLine)
                        strHeader1.Append(strHeader2.ToString())
                        blnStart = False
                    Else
                        If strFirstDate = "" Then strFirstDate = FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2)
                        strHeader2.AppendFormat("              <td class=xl67 periodo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "'>" & dr.GetString(dr.GetOrdinal("Pergunta")) & "</td>{0}", Environment.NewLine)
                        If intCol = intColunas - 1 Then
                            strHeader1.AppendFormat("              <td colspan=" & intColunas & " class=xl104 periodo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "' >" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "<br /><a href='javascript:detalhar(""" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & """)'>detalhar</a></td>{0}", Environment.NewLine)
                            strHeader1.AppendFormat("              <td class=xl104 resumo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "' onclick='SetVisible(""" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & """)'>" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "</td>{0}", Environment.NewLine)
                            strHeader2.AppendFormat("              <td class=xl67 2periodo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "'>TOTAL MOSTRUÁRIOS</td>{0}", Environment.NewLine)
                        End If
                    End If
                End If
                If strSubCategoria <> dr.GetString(dr.GetOrdinal("SubCategoria")) Then

                    If Not blnStart Then
                        strRelatorio.AppendFormat("             </tr>{0}", Environment.NewLine)
                        strRelatorio.AppendFormat("             <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                        strRelatorio.AppendFormat("              <td height=17 class='xl52' width=178 style='height:12.75pt;{0}", Environment.NewLine)
                        strRelatorio.AppendFormat("              width:133pt' colspan='{1}'>&nbsp;</td>{0}", Environment.NewLine, intTotalColunas + 5)
                        strRelatorio.AppendFormat("             </tr>{0}", Environment.NewLine)
                    End If
                    strRelatorio.AppendFormat("             <tr height='17' style='height:12.75pt'>{0}", Environment.NewLine)

                    strSubCategoria = dr.GetString(dr.GetOrdinal("SubCategoria"))
                    strRelatorio.AppendFormat("              <td rowspan='" & intFornecedores & "' height=51 class=xl52 width=83 style='height:38.25pt;width:62pt'>" & strSubCategoria & "</td>{0}", Environment.NewLine)

                    strFornecedor = dr.GetString(dr.GetOrdinal("Fornecedor"))
                    strRelatorio.AppendFormat("              <td class=xl52 width=95 style='width:71pt'>" & strFornecedor & "</td>{0}", Environment.NewLine)
                ElseIf strFornecedor <> dr.GetString(dr.GetOrdinal("Fornecedor")) Then
                    strFornecedor = dr.GetString(dr.GetOrdinal("Fornecedor"))
                    strRelatorio.AppendFormat("             <tr height='17' style='height:12.75pt'>{0}", Environment.NewLine)
                    strRelatorio.AppendFormat("              <td class=xl52 width=95 style='width:71pt'>" & strFornecedor & "</td>{0}", Environment.NewLine)
                End If
                strRelatorio.AppendFormat("              <td class='xl52' periodo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "'>" & dr.GetInt32(dr.GetOrdinal("Quantidade")) & "</td>{0}", Environment.NewLine)
                intCol += 1
                intTotalColunas += 1
                If intCol = intColunas Then
                    strRelatorio.AppendFormat("              <td class='xl52' 2periodo='" & FormatDateTime(dr.GetDateTime(dr.GetOrdinal("fim")), 2) & "'>" & dr.GetInt32(dr.GetOrdinal("Total")) & "</td>{0}", Environment.NewLine)
                    intCol = 1
                    intTotalColunas += 1
                End If

            Loop
            strRelatorio.AppendFormat("             </tr>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("             <tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("              <td height=17 class=xl52 width=178 style='height:12.75pt;{0}", Environment.NewLine)
            strRelatorio.AppendFormat("              width:133pt' colspan='{1}'>&nbsp;</td>{0}", Environment.NewLine, intTotalColunas)
            strRelatorio.AppendFormat("             </tr>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("            </table>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("            <table cellpadding='0' cellspacing='0' style='width:{1}pt'>{0}", Environment.NewLine, intTableSize)
            strRelatorio.AppendFormat("            <tr height=20px>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("                <td>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("                    <div id='MainFooter'>&copy;{0} XM Sistemas Distribu&iacute;dos Ltda. Todos os ", Year(Now))
            strRelatorio.AppendFormat("direitos reservados.</div>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("                </td>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("            </tr>{0}", Environment.NewLine)
            strRelatorio.AppendFormat("        </table>{0}", Environment.NewLine)

            ltrRelatorio.Text = strHeader1.ToString & strRelatorio.ToString & "<script>SetVisible('" & strFirstDate & "')</script>"
        End If
    End Sub
End Class
