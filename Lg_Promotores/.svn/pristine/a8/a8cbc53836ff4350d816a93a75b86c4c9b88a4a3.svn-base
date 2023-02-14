Imports System.Data

Partial Class reports_rptMostruariodet
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindRelatorio()
        End If
    End Sub


    Protected Sub BindRelatorio()
        Dim rep As New clsReports
        Dim ret As clsReports.RelatorioData

        Dim dtsLojas As DataSet
        Dim dtsProdutos As DataSet
        Dim drData As IDataReader


        Dim intIDLoja As Integer = 0
        '        Dim intIDProduto As Integer = 0
        Dim intIDPergunta As Integer = 0
        '        Dim intIDSubCategoria As Integer = 0
        Dim intIDCategoria As Integer = 0
        '       Dim intIDFornecedor As Integer = 0
        Dim strFornecedor As String = ""
        Dim intCountLojas As Integer = 0
        Dim intCountPerguntas As Integer = 0
        Dim intTemp As Integer = 0
        Dim blnFirstProduto As Boolean = True
        Dim Soma As New clsSomarizador

        Dim intTableSize As Integer

        Dim intIDLastFornecedor As Integer = 0
        Dim intIDCurrentFornecedor As Integer = 0

        Dim intIDLastSubCategoria As Integer = 0
        Dim intIDCurrentSubCategoria As Integer = 0

        Dim intIDLastProduto As Integer = 0
        Dim intIDCurrentProduto As Integer = 0

        Dim intIDLastPergunta As Integer = 0
        Dim intIDCurrentPergunta As Integer = 0

        ret = rep.getRelatorioMostruario(Request("rg") & "", Request("es") & "", Request("tp") & "", Request("sh") & "", Request("lj") & "", Request("periodo"))

        If ret.Sucess Then
            dtsLojas = ret.Header
            dtsProdutos = ret.Side
            drData = ret.Data


            intCountPerguntas = dtsLojas.Tables(0).Rows(0).Item("Perguntas")
            intTableSize = ((dtsLojas.Tables(0).Rows.Count + intCountPerguntas) * 80) + 300

            Dim strRelatorio As New StringBuilder
            Dim blnRead As Boolean = drData.Read()

            With strRelatorio
                .AppendFormat("    <table x:str border=0 cellpadding=0 cellspacing=0 style='border-collapse:{0}", Environment.NewLine)
                .AppendFormat("     collapse;table-layout:fixed;width:{1}pt'>{0}", Environment.NewLine, intTableSize)
                .AppendFormat("     <tr class=xl146 height=85 style='height:63.75pt'>{0}", Environment.NewLine)
                .AppendFormat("      <td height=85 class=xl27 style='height:63.75pt'>&nbsp;</td>{0}", Environment.NewLine)
                .AppendFormat("      <td class=xl28>&nbsp;</td>{0}", Environment.NewLine)
                .AppendFormat("      <td class=xl28>&nbsp;</td>{0}", Environment.NewLine)

                For i As Integer = 0 To dtsLojas.Tables(0).Rows.Count - 1
                    If intIDLoja <> dtsLojas.Tables(0).Rows(i).Item("IDLoja") Then
                        .AppendFormat("           <td class=xl178 colspan='" & dtsLojas.Tables(0).Rows(i).Item("Perguntas") & "'>" & dtsLojas.Tables(0).Rows(i).Item("Loja") & "</td>{0}", Environment.NewLine)
                        intIDLoja = dtsLojas.Tables(0).Rows(i).Item("IDLoja")
                        intCountLojas += 1
                    End If
                Next

                intIDLoja = 0
                For i As Integer = 0 To dtsLojas.Tables(0).Rows.Count - 1
                    If intIDLoja = 0 Then
                        intIDLoja = dtsLojas.Tables(0).Rows(i).Item("IDLoja")
                    End If
                    If intIDLoja = dtsLojas.Tables(0).Rows(i).Item("IDLoja") Then
                        .AppendFormat("      <td class=xl177 >Total " & dtsLojas.Tables(0).Rows(i).Item("Pergunta") & "</td>{0}", Environment.NewLine)
                    Else
                        Exit For
                    End If
                Next
                .AppendFormat("      </tr>{0}", Environment.NewLine)

                'LINHA COM AS PERGUNTAS
                .AppendFormat("     <tr height=68 style='height:51.0pt'>{0}", Environment.NewLine)
                .AppendFormat("      <td height=68 class=xl34 style='height:51.0pt'>Categoria</td>{0}", Environment.NewLine)
                .AppendFormat("      <td class=xl34>Empresa</td>{0}", Environment.NewLine)
                .AppendFormat("      <td class=xl34>Produto</td>{0}", Environment.NewLine)
                For i As Integer = 0 To dtsLojas.Tables(0).Rows.Count - 1
                    .AppendFormat("      <td class='xl163'>" & dtsLojas.Tables(0).Rows(i).Item("Pergunta") & "</td>{0}", Environment.NewLine)
                Next
                For i As Integer = 1 To dtsLojas.Tables(0).Rows(i).Item("Perguntas")
                    .AppendFormat("      <td class='xl101'>&nbsp;</td>{0}", Environment.NewLine)
                Next
                .AppendFormat("      </tr>{0}", Environment.NewLine)



                'LINHA DE DADOS
                For i As Integer = 0 To dtsProdutos.Tables(0).Rows.Count - 1

                    intIDCurrentSubCategoria = dtsProdutos.Tables(0).Rows(i).Item("IDSubCategoria")
                    intIDCurrentFornecedor = dtsProdutos.Tables(0).Rows(i).Item("IDFornecedor")
                    intIDCurrentProduto = dtsProdutos.Tables(0).Rows(i).Item("IDProduto")

                    If (intIDLastFornecedor <> intIDCurrentFornecedor Or intIDLastSubCategoria <> intIDCurrentSubCategoria) Then
                        blnFirstProduto = True
                    End If



                    'INICIO SOMARIZADOR
                    If (intIDLastFornecedor <> intIDCurrentFornecedor Or intIDLastSubCategoria <> intIDCurrentSubCategoria) And intIDLastSubCategoria > 0 Then

                        .AppendFormat("     <tr class=xl33 height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                        .AppendFormat("      <td class=xl37 colspan='2'>" & strFornecedor & " Total</td>{0}", Environment.NewLine)

                        intTemp = 0
                        For j As Integer = 0 To dtsLojas.Tables(0).Rows.Count - 1
                            Dim strValor As String = intIDLastSubCategoria & "_" & intIDLastFornecedor & "_" & dtsLojas.Tables(0).Rows(j).Item("IDLoja") & "_" & dtsLojas.Tables(0).Rows(j).Item("IDPergunta")
                            strValor = Soma.Total(strValor)
                            If strValor = "" Then strValor = "0"
                            'If intIDLoja <> dtsLojas.Tables(0).Rows(j).Item("IDLoja") Then
                            If intTemp = 1 Then
                                .AppendFormat("      <td class='xl40'>{1}</td>{0}", Environment.NewLine, strValor)
                            Else
                                .AppendFormat("      <td class='xl41'>{1}</td>{0}", Environment.NewLine, strValor)
                            End If
                            'End If
                        Next

                        For j As Integer = 0 To intCountPerguntas - 1
                            Dim strValor As String = intIDLastSubCategoria & "_" & intIDLastFornecedor & "_" & dtsLojas.Tables(0).Rows(j).Item("IDPergunta")
                            strValor = Soma.Total(strValor)
                            If strValor = "" Then strValor = "0"
                            If intTemp = 1 Then
                                .AppendFormat("      <td class='xl40'>{1}</td>{0}", Environment.NewLine, strValor)
                            Else
                                .AppendFormat("      <td class='xl41'>{1}</td>{0}", Environment.NewLine, strValor)
                            End If
                        Next

                        .AppendFormat("     </tr>{0}", Environment.NewLine)
                    End If
                    'FIM SOMARIZADOR


                    'INICIO SEPARADOR 
                    If intIDLastSubCategoria <> 0 And intIDLastSubCategoria <> intIDCurrentSubCategoria Then
                        .AppendFormat("     <tr class=xl33 height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                        .AppendFormat("      <td height=17 class=xl24 style='height:12.75pt'>&nbsp;</td>{0}", Environment.NewLine)
                        .AppendFormat("      <td class=xl25>&nbsp;</td>{0}", Environment.NewLine)
                        .AppendFormat("      <td class=xl25>&nbsp;</td>{0}", Environment.NewLine)

                        For j As Integer = 0 To intCountLojas - 1
                            .AppendFormat("      <td class=xl30>&nbsp;</td>{0}", Environment.NewLine)
                            .AppendFormat("      <td class=xl31>&nbsp;</td>{0}", Environment.NewLine)
                            .AppendFormat("      <td class=xl31>&nbsp;</td>{0}", Environment.NewLine)
                            .AppendFormat("      <td class=xl31>&nbsp;</td>{0}", Environment.NewLine)
                        Next
                        For j As Integer = 0 To intCountPerguntas - 2
                            .AppendFormat("      <td class=xl30>&nbsp;</td>{0}", Environment.NewLine)
                        Next
                        .AppendFormat("      <td class=xl44>&nbsp;</td>{0}", Environment.NewLine)
                        .AppendFormat("     </tr>{0}", Environment.NewLine)

                    End If
                    'FIM SEPARADOR 

                    .AppendFormat("     <tr class=xl33 height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                    If intIDLastSubCategoria <> intIDCurrentSubCategoria Then
                        .AppendFormat("      <td height='17' rowspan='{2}' class=xl24 style='height:12.75pt'>{1}</td>{0}", Environment.NewLine, dtsProdutos.Tables(0).Rows(i).Item("SubCategoria"), dtsProdutos.Tables(0).Rows(i).Item("NSubCategorias") + dtsProdutos.Tables(0).Rows(i).Item("NFornecedores"))
                    End If
                    If intIDLastFornecedor <> intIDCurrentFornecedor Or intIDLastSubCategoria <> intIDCurrentSubCategoria Then
                        .AppendFormat("      <td class=xl24 rowspan='{2}'>{1}</td>{0}", Environment.NewLine, dtsProdutos.Tables(0).Rows(i).Item("Fornecedor"), dtsProdutos.Tables(0).Rows(i).Item("NProdutos"))
                    End If
                    .AppendFormat("      <td class=xl24>{1}</td>{0}", Environment.NewLine, dtsProdutos.Tables(0).Rows(i).Item("Descricao"))

                    '                    intIDSubCategoria = dtsProdutos.Tables(0).Rows(i).Item("IDSubCategoria")
                    'intIDFornecedor = dtsProdutos.Tables(0).Rows(i).Item("IDFornecedor")
                    strFornecedor = dtsProdutos.Tables(0).Rows(i).Item("Fornecedor")

                    'PEGA DADOS DO DATAREADER

                    intTemp = 0
                    For j As Integer = 0 To dtsLojas.Tables(0).Rows.Count - 1
                        Dim strValor As String = "&nbsp;"

                        If intIDLoja <> dtsLojas.Tables(0).Rows(j).Item("IDLoja") Then
                            intTemp = 0
                        End If
                        intTemp += 1

                        intIDLoja = dtsLojas.Tables(0).Rows(j).Item("IDLoja")
                        intIDPergunta = dtsLojas.Tables(0).Rows(j).Item("IDPergunta")

                        Dim strClass As String = IIf(intTemp = 1, "xl32", "xl33")

                        If blnFirstProduto Then
                            strClass = IIf(intTemp = 1, "xl30", "xl31")
                        End If

                        If blnRead Then

                            If intIDCurrentProduto = drData.GetInt32(drData.GetOrdinal("IDProduto")) And intIDLoja = drData.GetInt32(drData.GetOrdinal("IDLoja")) And intIDPergunta = drData.GetInt32(drData.GetOrdinal("IDPergunta")) Then
                                strValor = CStr(drData.GetInt32(drData.GetOrdinal("Quantidade")))
                                Soma.Add(drData.GetInt32(drData.GetOrdinal("Quantidade")), intIDCurrentSubCategoria & "_" & intIDCurrentFornecedor & "_" & intIDLoja & "_" & intIDPergunta)
                                Soma.Add(drData.GetInt32(drData.GetOrdinal("Quantidade")), intIDCurrentSubCategoria & "_" & intIDCurrentFornecedor & "_" & intIDPergunta)
                                Soma.Add(drData.GetInt32(drData.GetOrdinal("Quantidade")), intIDCurrentProduto & "_" & intIDPergunta)
                                Do While intIDCurrentProduto = drData.GetInt32(drData.GetOrdinal("IDProduto")) And intIDLoja = drData.GetInt32(drData.GetOrdinal("IDLoja")) And intIDPergunta = drData.GetInt32(drData.GetOrdinal("IDPergunta"))
                                    blnRead = drData.Read()
                                    If Not blnRead Then Exit Do
                                Loop
                            End If
                        End If
                        .AppendFormat("      <td class='{2}'>{1}</td>{0}", Environment.NewLine, strValor, strClass)

                        'sb.AppendFormat("  <td class=xl28 align=right style='border-top:none;")
                        'If m_Preco = 0 Then
                        '    sb.AppendFormat("'>&nbsp;")
                        'Else
                        '    sb.AppendFormat("color:#000000' x:num=""" & excelExportFormatCells(m_Preco) & """ >" & FormatNumber(m_Preco, 2))
                        'End If
                        'sb.AppendFormat(vbCrLf & "</td>{0}", Environment.NewLine)
                    Next

                    For j As Integer = 0 To intCountPerguntas - 1
                        Dim strValor As String = intIDCurrentProduto & "_" & dtsLojas.Tables(0).Rows(j).Item("IDPergunta")
                        strValor = Soma.Total(strValor)
                        If strValor = "" Then strValor = "0"
                        .AppendFormat("      <td class='xl30'>{1}</td>{0}", Environment.NewLine, strValor)
                    Next
        
                    .AppendFormat("     </tr>{0}", Environment.NewLine)

                    intIDLastFornecedor = intIDCurrentFornecedor
                    intIDLastSubCategoria = intIDCurrentSubCategoria
                    intIDLastProduto = intIDCurrentProduto

                    blnFirstProduto = False

                Next

                .AppendFormat("    </table>{0}", Environment.NewLine)


                .AppendFormat("        <table style='width:{1}pt'>{0}", Environment.NewLine, intTableSize)
                .AppendFormat("            <tr height=20px>{0}", Environment.NewLine)
                .AppendFormat("                <td>{0}", Environment.NewLine)
                .AppendFormat("                    <div id='MainFooter'>&copy;<%=Year(Now)%> XM Sistemas Distribu&iacute;dos Ltda. ")
                .AppendFormat("Todos os direitos reservados.</div>{0}", Environment.NewLine)
                .AppendFormat("                </td>{0}", Environment.NewLine)
                .AppendFormat("            </tr>{0}", Environment.NewLine)
                .AppendFormat("        </table>{0}", Environment.NewLine)


                ltrRelatorio.Text = .ToString()
            End With


        End If



    End Sub
End Class
