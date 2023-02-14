Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptPerformanceDet

    Inherits XMWebPage
    Dim rpt As clsReports
    Dim blnAlternateCoordenador As Boolean = True
    Dim blnAlternateLider As Boolean = True
    Dim strLinkDetalhe As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Try

                ViewState("crd") = Request("crd")
                ViewState("lid") = Request("lid")
                ViewState("pro") = Request("pro")
                ViewState("cli") = Request("cli")
                ViewState("loj") = Request("loj")
                ViewState("shop") = Request("shop")
                ViewState("tiploj") = Request("tiploj")
                ViewState("regiao") = Request("regiao")
                ViewState("sta") = Request("sta")
                ViewState("tippes") = Request("tippes")
                ViewState("est") = Request("est")
                ViewState("pertxt") = Request("pertxt") & ""
                ViewState("per") = Request("per")

                Dim p_Temp As Object = Split(ViewState("per"), "||", , CompareMethod.Text)
                ViewState("pi") = p_Temp(0)
                ViewState("pn") = p_Temp(1)

                strLinkDetalhe = "&crd=" & Request("crd") & "&" & _
                "lid=" & Request("lid") & "&" & _
                "pro=" & Request("pro") & "&" & _
                "cli=" & Request("cli") & "&" & _
                "loj=" & Request("loj") & "&" & _
                "shop=" & Request("shop") & "&" & _
                "tiploj=" & Request("tiploj") & "&" & _
                "regiao=" & Request("regiao") & "&" & _
                "sta=" & Request("sta") & "&" & _
                "tippes=" & Request("tippes") & "&" & _
                "est=" & Request("est") & "&" & _
                "pertxt=" & Request("pertxt") & "" & "&" & _
                "per=" & Request("per") & "&"

                OpenReport()

            Catch ex As System.Exception

                Dim sb As New System.Text.StringBuilder

                sb.Append("<table border=0 align='center' cellspacing='0'>")
                sb.Append("<tr><td class='Mensagem'><b>Erro : " & ex.Message & "</b></td></tr>")
                sb.Append("</table>")

                ltReport.Text = sb.ToString

            Finally

                rpt = Nothing

            End Try

        End If


    End Sub

    Private Sub OpenReport()

        Dim rptResult As clsReports.RelatorioData = Nothing

        rpt = New clsReports
        rptResult = rpt.getRelatorioPerformance(Me.User.IDEmpresa, _
                                                ViewState("cli"), ViewState("loj"), ViewState("shop"), _
                                                ViewState("crd"), ViewState("lid"), ViewState("pro"), _
                                                ViewState("tiploj"), ViewState("regiao"), ViewState("sta"), _
                                                ViewState("tippes"), ViewState("est"), _
                                                ViewState("pi"), ViewState("pn"))

        If rptResult.Sucess Then

            Dim Soma As New clsSomarizador

            Dim sb As New System.Text.StringBuilder

            '*****************************
            'RELATÓRIO DE PERFORMANCE
            '*****************************

            sb.AppendFormat("<table width='800' class='Relatorio' cellspacing='0'>{0}", Environment.NewLine)
            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
            sb.AppendFormat("<td rowspan='3' width='200'>Coordenador</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td rowspan='3' width='200'>Lider</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td rowspan='3' width='200'>Nome</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='10'>" & ViewState("pertxt") & "</td>{0}", Environment.NewLine)
            sb.AppendFormat("</tr>{0}", Environment.NewLine)
            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='2' width='100'>Previsão</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='2' width='100'>Realizado</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='2' width='100'>Abono</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='2' width='100'>Percentual (%)</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td colspan='2' width='100'>Não Realizado</td>{0}", Environment.NewLine)
            sb.AppendFormat("</tr>{0}", Environment.NewLine)
            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Lojas</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Reg</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Lojas</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Reg</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Lojas</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Reg</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Lojas</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Reg</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Lojas</td>{0}", Environment.NewLine)
            sb.AppendFormat("<td width='50'>Reg</td>{0}", Environment.NewLine)
            sb.AppendFormat("</tr>{0}", Environment.NewLine)

            Dim sbTemp As New System.Text.StringBuilder()
            Dim dr As SqlClient.SqlDataReader = rptResult.Data
            Dim p_IdLider As Integer = 0, p_NomeLider As String = "", p_NomeCoordenador As String = ""
            Dim p_PorcVis As Integer = 0, p_PorcProd As Integer = 0

            While dr.Read

                If dr.Item("lid_Lider_int_PK") <> p_IdLider And p_IdLider > 0 Then
                    TotalLider(sb, Soma, p_NomeLider)
                    blnAlternateLider = Not blnAlternateLider
                End If
                If dr.Item("crd_Coordenador_chr") <> p_NomeCoordenador And p_NomeCoordenador <> "" Then
                    TotalCoordenador(sb, Soma, p_NomeCoordenador)
                    blnAlternateCoordenador = Not blnAlternateCoordenador
                End If

                If dr.Item("Previsao_Quant_Pesquisas") > 0 Then
                    p_PorcVis = (dr.Item("Efetuado_Quant_Pesquisas") + dr.Item("Abono_Quant_Pesquisas")) / dr.Item("Previsao_Quant_Pesquisas") * 100
                Else
                    p_PorcVis = 0
                End If
                If dr.Item("Previsao_Quant_Produtos") > 0 Then
                    p_PorcProd = (dr.Item("Efetuado_Quant_Produtos") + dr.Item("Abono_Quant_Produtos")) / dr.Item("Previsao_Quant_Produtos") * 100
                Else
                    p_PorcProd = 0
                End If

                sbTemp.AppendFormat("<tr {1}>{0}", Environment.NewLine, GetStyleLider())
                If p_NomeCoordenador <> dr.Item("crd_Coordenador_chr") & "" Then
                    sbTemp.AppendFormat("<td {1} rowspan='" & (dr.Item("QtdCoordenador") + 1 + dr.Item("QtdLiderCoordenador")) & "'>" & Server.HtmlEncode(dr.Item("crd_Coordenador_chr")) & "</td>{0}", Environment.NewLine, GetStyleCoordenador())
                    sbTemp.AppendFormat("<td {1} rowspan='" & (dr.Item("QtdLider") + 1) & "'>" & Server.HtmlEncode(dr.Item("lid_Lider_chr")) & "</td>{0}", Environment.NewLine, GetStyleLider())
                ElseIf p_NomeLider <> dr.Item("lid_Lider_chr") & "" Then
                    sbTemp.AppendFormat("<td {1} rowspan='" & (dr.Item("QtdLider") + 1) & "'>" & Server.HtmlEncode(dr.Item("lid_Lider_chr")) & "</td>{0}", Environment.NewLine, GetStyleLider())
                End If
                sbTemp.AppendFormat("<td class='ItemNome'>" & Server.HtmlEncode(dr.Item("pro_Promotor_chr")) & "</td>{0}", Environment.NewLine)

                Dim p_QuantPesq As Integer = dr.Item("Previsao_Quant_Pesquisas")

                If p_QuantPesq > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=1&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Previsao_Quant_Pesquisas") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Previsao_Quant_Pesquisas") & "</td>{0}", Environment.NewLine)
                End If

                If p_QuantPesq > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=2&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Previsao_Quant_Produtos") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Previsao_Quant_Produtos") & "</td>{0}", Environment.NewLine)
                End If

                If dr.Item("Efetuado_Quant_Pesquisas") > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=3&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Efetuado_Quant_Pesquisas") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Efetuado_Quant_Pesquisas") & "</td>{0}", Environment.NewLine)
                End If

                If dr.Item("Efetuado_Quant_Produtos") > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=4&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Efetuado_Quant_Produtos") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Efetuado_Quant_Produtos") & "</td>{0}", Environment.NewLine)
                End If

                If dr.Item("Abono_Quant_Pesquisas") > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=5&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Abono_Quant_Pesquisas") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Abono_Quant_Pesquisas") & "</td>{0}", Environment.NewLine)
                End If

                If dr.Item("Abono_Quant_Produtos") > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=6&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Abono_Quant_Produtos") & "</a></td>{0}", Environment.NewLine)
                Else
                    sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Abono_Quant_Produtos") & "</td>{0}", Environment.NewLine)
                End If

                sbTemp.AppendFormat("<td class='Item'>" & p_PorcVis & "</td>{0}", Environment.NewLine)
                sbTemp.AppendFormat("<td class='Item'>" & p_PorcProd & "</td>{0}", Environment.NewLine)

                If (dr.Item("Previsao_Quant_Pesquisas") - dr.Item("Efetuado_Quant_Pesquisas") - dr.Item("Abono_Quant_Pesquisas")) > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=7&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Previsao_Quant_Pesquisas") - dr.Item("Efetuado_Quant_Pesquisas") - dr.Item("Abono_Quant_Pesquisas") & "</a></td>{0}", Environment.NewLine)
                Else
                    If (dr.Item("Previsao_Quant_Pesquisas") - dr.Item("Efetuado_Quant_Pesquisas") - dr.Item("Abono_Quant_Pesquisas")) < 0 Then
                        sbTemp.AppendFormat("<td class='Item'>" & 0 & "</td>{0}", Environment.NewLine)
                    Else
                        sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Previsao_Quant_Pesquisas") - dr.Item("Efetuado_Quant_Pesquisas") - dr.Item("Abono_Quant_Pesquisas") & "</td>{0}", Environment.NewLine)
                    End If
                End If

                If (dr.Item("Previsao_Quant_Produtos") - dr.Item("Efetuado_Quant_Produtos") - dr.Item("Abono_Quant_Produtos")) > 0 Then
                    sbTemp.AppendFormat("<td class='Item'><a href='rptPerformanceVisDet.aspx?tp=8&p=" & dr.Item("pro_Promotor_int_PK") & strLinkDetalhe & "' alt=''>" & dr.Item("Previsao_Quant_Produtos") - dr.Item("Efetuado_Quant_Produtos") - dr.Item("Abono_Quant_Produtos") & "</a></td>{0}", Environment.NewLine)
                Else
                    If dr.Item("Previsao_Quant_Produtos") - dr.Item("Efetuado_Quant_Produtos") - dr.Item("Abono_Quant_Produtos") < 0 Then
                        sbTemp.AppendFormat("<td class='Item'>" & 0 & "</td>{0}", Environment.NewLine)
                    Else
                        sbTemp.AppendFormat("<td class='Item'>" & dr.Item("Previsao_Quant_Produtos") - dr.Item("Efetuado_Quant_Produtos") - dr.Item("Abono_Quant_Produtos") & "</td>{0}", Environment.NewLine)
                    End If
                End If

                sbTemp.AppendFormat(" </tr>{0}", Environment.NewLine)

                sb.Append(sbTemp.ToString())
                sbTemp = New System.Text.StringBuilder()

                p_NomeLider = dr.Item("lid_Lider_chr") & ""
                p_NomeCoordenador = dr.Item("crd_Coordenador_chr") & ""
                p_IdLider = dr.Item("lid_Lider_int_PK")

                Soma.Add(dr.Item("Previsao_Quant_Pesquisas"), dr.Item("lid_Lider_chr") & "_Previsao_Quant_Pesquisas")
                Soma.Add(dr.Item("Previsao_Quant_Produtos"), dr.Item("lid_Lider_chr") & "_Previsao_Quant_Produtos")
                Soma.Add(dr.Item("Efetuado_Quant_Pesquisas"), dr.Item("lid_Lider_chr") & "_Efetuado_Quant_Pesquisas")
                Soma.Add(dr.Item("Efetuado_Quant_Produtos"), dr.Item("lid_Lider_chr") & "_Efetuado_Quant_Produtos")
                Soma.Add(dr.Item("Abono_Quant_Pesquisas"), dr.Item("lid_Lider_chr") & "_Abono_Quant_Pesquisas")
                Soma.Add(dr.Item("Abono_Quant_Produtos"), dr.Item("lid_Lider_chr") & "_Abono_Quant_Produtos")

                Soma.Add(dr.Item("Previsao_Quant_Pesquisas"), dr.Item("crd_Coordenador_chr") & "_Previsao_Quant_Pesquisas")
                Soma.Add(dr.Item("Previsao_Quant_Produtos"), dr.Item("crd_Coordenador_chr") & "_Previsao_Quant_Produtos")
                Soma.Add(dr.Item("Efetuado_Quant_Pesquisas"), dr.Item("crd_Coordenador_chr") & "_Efetuado_Quant_Pesquisas")
                Soma.Add(dr.Item("Efetuado_Quant_Produtos"), dr.Item("crd_Coordenador_chr") & "_Efetuado_Quant_Produtos")
                Soma.Add(dr.Item("Abono_Quant_Pesquisas"), dr.Item("crd_Coordenador_chr") & "_Abono_Quant_Pesquisas")
                Soma.Add(dr.Item("Abono_Quant_Produtos"), dr.Item("crd_Coordenador_chr") & "_Abono_Quant_Produtos")


                Soma.Add(dr.Item("Previsao_Quant_Pesquisas"), "Total_Previsao_Quant_Pesquisas")
                Soma.Add(dr.Item("Previsao_Quant_Produtos"), "Total_Previsao_Quant_Produtos")
                Soma.Add(dr.Item("Efetuado_Quant_Pesquisas"), "Total_Efetuado_Quant_Pesquisas")
                Soma.Add(dr.Item("Efetuado_Quant_Produtos"), "Total_Efetuado_Quant_Produtos")
                Soma.Add(dr.Item("Abono_Quant_Pesquisas"), "Total_Abono_Quant_Pesquisas")
                Soma.Add(dr.Item("Abono_Quant_Produtos"), "Total_Abono_Quant_Produtos")

            End While

            If p_NomeLider <> "" Then
                TotalLider(sb, Soma, p_NomeLider)
            End If
            If p_NomeCoordenador <> "" Then
                TotalCoordenador(sb, Soma, p_NomeCoordenador)
            End If
            TotalGeral(sb, Soma)

            sb.Append(sbTemp.ToString())
            sb.AppendFormat(" </table>{0}", Environment.NewLine)

            dr.Close()
            dr = Nothing

            ltReport.Text = sb.ToString

            sb = Nothing
            sbTemp = Nothing

        Else

            NaoEncontrado()

        End If

    End Sub

    Private Function GetStyleCoordenador() As String
        If blnAlternateCoordenador Then
            Return " class='ItemNome' style='background-color:#DDDDDD;' "
        Else
            Return " class='ItemNome' style='background-color:#DAD8C1;' "
        End If
    End Function

    Private Function GetStyleTotal() As String
        Return " class='ItemNome' style='background-color:#AAAAAA'"
    End Function

    Private Function GetStyleLider() As String
        If blnAlternateCoordenador Then
            If blnAlternateLider Then
                Return " class='ItemNome' style='background-color:#EAEAEA'"
            Else
                Return " class='ItemNome' style='background-color:#C3C3C3' "
            End If
        Else
            If blnAlternateLider Then
                Return " class='ItemNome' style='background-color:#C0BFAA'"
            Else
                Return " class='ItemNome' style='background-color:#E7E5CC' "
            End If
        End If
    End Function


    Private Sub TotalCoordenador(ByVal sb As StringBuilder, ByVal Soma As clsSomarizador, ByVal vKey As String)
        sb.AppendFormat("<tr{1}>{0}", Environment.NewLine, GetStyleCoordenador())
        sb.AppendFormat("<td class='ItemNomeNeg' colspan='2'>Total Coordenador</td>{0}", Environment.NewLine)
        Total(sb, Soma, vKey)
        sb.AppendFormat(" </tr>{0}", Environment.NewLine)
    End Sub

    Private Sub TotalGeral(ByVal sb As StringBuilder, ByVal Soma As clsSomarizador)
        sb.AppendFormat("<tr{1}>{0}", Environment.NewLine, GetStyleTotal())
        sb.AppendFormat("<td class='ItemNomeNeg' colspan='3'>Total Geral</td>{0}", Environment.NewLine)
        Total(sb, Soma, "Total")
        sb.AppendFormat(" </tr>{0}", Environment.NewLine)
    End Sub


    Private Sub TotalLider(ByVal sb As StringBuilder, ByVal Soma As clsSomarizador, ByVal vKey As String)
        sb.AppendFormat("<tr{1}>{0}", Environment.NewLine, GetStyleLider())
        sb.AppendFormat("<td class='ItemNomeNeg'>Total Lider</td>{0}", Environment.NewLine)
        Total(sb, Soma, vKey)
        sb.AppendFormat(" </tr>{0}", Environment.NewLine)
    End Sub

    Private Sub Total(ByVal sb As StringBuilder, ByVal Soma As clsSomarizador, ByVal vKey As String)

        Dim p_PrevisaoVis As Integer = 0, p_PrevisaoProd As Integer = 0
        Dim p_EfetuadoVis As Integer = 0, p_EfetuadoProd As Integer = 0
        Dim p_AbonoVis As Integer = 0, p_AbonoProd As Integer = 0
        Dim p_PorcVis As Integer = 0, p_PorcProd As Integer = 0

        p_PrevisaoVis = Soma.Total(vKey & "_Previsao_Quant_Pesquisas")
        p_PrevisaoProd = Soma.Total(vKey & "_Previsao_Quant_Produtos")
        p_EfetuadoVis = Soma.Total(vKey & "_Efetuado_Quant_Pesquisas")
        p_EfetuadoProd = Soma.Total(vKey & "_Efetuado_Quant_Produtos")
        p_AbonoVis = Soma.Total(vKey & "_Abono_Quant_Pesquisas")
        p_AbonoProd = Soma.Total(vKey & "_Abono_Quant_Produtos")

        If p_PrevisaoVis > 0 Then
            p_PorcVis = (p_EfetuadoVis + p_AbonoVis) / p_PrevisaoVis * 100
        Else
            p_PorcVis = 0
        End If
        If p_PrevisaoProd > 0 Then
            p_PorcProd = (p_EfetuadoProd + p_AbonoProd) / p_PrevisaoProd * 100
        Else
            p_PorcProd = 0
        End If

        sb.AppendFormat("<td class='ItemNeg'>" & p_PrevisaoVis & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_PrevisaoProd & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_EfetuadoVis & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_EfetuadoProd & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_AbonoVis & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_AbonoProd & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_PorcVis & "</td>{0}", Environment.NewLine)
        sb.AppendFormat("<td class='ItemNeg'>" & p_PorcProd & "</td>{0}", Environment.NewLine)

        If (p_PrevisaoVis - p_EfetuadoVis - p_AbonoVis) < 0 Then
            sb.AppendFormat("<td class='ItemNeg'>" & 0 & "</td>{0}", Environment.NewLine)
        Else
            sb.AppendFormat("<td class='ItemNeg'>" & (p_PrevisaoVis - p_EfetuadoVis - p_AbonoVis) & "</td>{0}", Environment.NewLine)
        End If

        If (p_PrevisaoProd - p_EfetuadoProd - p_AbonoProd) < 0 Then
            sb.AppendFormat("<td class='ItemNeg'>" & 0 & "</td>{0}", Environment.NewLine)
        Else
            sb.AppendFormat("<td class='ItemNeg'>" & (p_PrevisaoProd - p_EfetuadoProd - p_AbonoProd) & "</td>{0}", Environment.NewLine)
        End If

    End Sub

    Private Sub NaoEncontrado()

        Dim sb As New System.Text.StringBuilder

        sb.Append("<html>" & vbCrLf)
        sb.Append("<head><title>Relat&oacute;rio de Performance</title></head>" & vbCrLf)
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
        sb.Append("<td nowrap class=Titulo align=left>Relat&oacute;rio de Performance</td>")
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
