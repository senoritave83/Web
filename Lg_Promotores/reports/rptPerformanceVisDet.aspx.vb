Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptPerformanceVisDet

    Inherits XMWebPage
    Dim rpt As clsReports
    Dim blnAlternateLoja As Boolean = True
    Dim url As System.Web.UI.HtmlControls.HtmlAnchor

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Try

                ViewState("tp") = Request("tp") 'tipo da visualização

                ViewState("crd") = Request("crd")
                ViewState("lid") = Request("lid")
                ViewState("pro") = Request("p") 'id do promotor para ver o detalhe
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

                Dim clsProm As New clsPromotor()
                Dim clsLid As New clsLider()
                Dim clsCoord As New clsCoordenador()

                Try

                    clsProm.Load(ViewState("pro"))
                    lblPromotor.text = clsProm.Promotor

                    clsLid.Load(clsProm.IDLider)
                    lbllider.text = clsLid.Lider

                    clsCoord.Load(clsLid.IDCoordenador)
                    lblCoordenador.text = clsCoord.Coordenador

                Catch ex As Exception

                Finally

                    clsProm = Nothing
                    clsLid = Nothing
                    clsCoord = Nothing

                End Try

                Dim strLink As String = "&crd=" & Request("crd") & "&" & _
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
                urlBack.HRef = "rptPerformanceDet.aspx?" & strLink

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
        rptResult = rpt.getRelatorioPerformanceDet(ViewState("tp"), Me.User.IDEmpresa, _
                                                ViewState("cli"), ViewState("loj"), ViewState("shop"), _
                                                ViewState("crd"), ViewState("lid"), ViewState("pro"), _
                                                ViewState("tiploja"), ViewState("regiao"), ViewState("sta"), _
                                                ViewState("tippes"), ViewState("est"), _
                                                ViewState("pi"), ViewState("pn"))

        If rptResult.Sucess Then

            Dim Soma As New clsSomarizador

            Dim sb As New System.Text.StringBuilder

            '*****************************
            'RELATÓRIO DE PERFORMANCE
            '*****************************

            sb.AppendFormat("<table width='800' class='Relatorio' cellspacing='0'>{0}", Environment.NewLine)

            Dim sbTemp As New System.Text.StringBuilder()
            Dim dr As SqlClient.SqlDataReader = rptResult.Data

            Dim p_CodigoLoja As String = "", p_Rows As Integer = 0

            Dim p_IdLider As Integer = 0, p_NomeLider As String = "", p_NomeCoordenador As String = ""
            Dim p_PorcVis As Integer = 0, p_PorcProd As Integer = 0
            Dim blnHeader As Boolean = False

            Dim p_QuantReg As Integer = 0

            While dr.Read

                blnAlternateLoja = Not blnAlternateLoja

                Select Case ViewState("tp")
                    Case "1", "3", "5", "7"

                        If blnHeader = False Then

                            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
                            sb.AppendFormat("<td colspan='3'>Quantidade de Lojas - " & _
                                            IIf(ViewState("tp") = "1", "Previsão", IIf(ViewState("tp") = "3", "Realizado", IIf(ViewState("tp") = "5", "Abono", IIf(ViewState("tp") = "5", "Não Realizado", "")))) & _
                                            ": #QUANTREG#</td>{0}", Environment.NewLine)
                            sb.AppendFormat("</tr>{0}", Environment.NewLine)

                            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
                            sb.AppendFormat("<td width='200'>{1}</td>{0}", Environment.NewLine, SettingsExpression.GetProperty("nomebandeira", "Relatorios.DescricaoBandeira", "BANDEIRA"))
                            sb.AppendFormat("<td width='200'>Código da Loja</td>{0}", Environment.NewLine)
                            sb.AppendFormat("<td width='200'>Loja</td>{0}", Environment.NewLine)
                            sb.AppendFormat("</tr>{0}", Environment.NewLine)

                            blnHeader = Not blnHeader

                        End If

                        p_QuantReg += 1

                        sbTemp.AppendFormat("<tr {1}>{0}", Environment.NewLine, GetStyleLoja())
                        sbTemp.AppendFormat("<td class='Item'>" & dr.Item("cli_fantasia_chr") & "</td>{0}", Environment.NewLine)
                        sbTemp.AppendFormat("<td class='Item'>" & dr.Item("loj_codigo_chr") & "</td>{0}", Environment.NewLine)
                        sbTemp.AppendFormat("<td class='Item'>" & dr.Item("loj_loja_chr") & "</td>{0}", Environment.NewLine)
                        sbTemp.AppendFormat(" </tr>{0}", Environment.NewLine)

                    Case "2", "4", "6", "8"

                        If blnHeader = False Then

                            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
                            sb.AppendFormat("<td colspan='4'>Quantidade de Produtos - " & _
                                            IIf(ViewState("tp") = "2", "Previsão", IIf(ViewState("tp") = "4", "Realizado", IIf(ViewState("tp") = "6", "Abono", IIf(ViewState("tp") = "8", "Não Realizado", "")))) & _
                                            ": #QUANTREG#</td>{0}", Environment.NewLine)
                            sb.AppendFormat("</tr>{0}", Environment.NewLine)
                            sb.AppendFormat("<tr class='Titulo'>{0}", Environment.NewLine)
                            sb.AppendFormat("   <td width='200'>Loja</td>{0}", Environment.NewLine)
                            sb.AppendFormat("   <td width='200'>Segmento</td>{0}", Environment.NewLine)
                            sb.AppendFormat("   <td width='200'>Categoria</td>{0}", Environment.NewLine)
                            sb.AppendFormat("   <td width='200'>Produto</td>{0}", Environment.NewLine)
                            sb.AppendFormat("</tr>{0}", Environment.NewLine)

                            blnHeader = Not blnHeader

                        End If

                        If dr.Item("loj_codigo_chr") <> p_CodigoLoja And p_CodigoLoja <> "" Then

                            sb.Append(sbTemp.ToString().Replace("#ROWSPAN#", p_Rows))
                            sbTemp = New System.Text.StringBuilder()
                            p_Rows = 0

                        End If

                        p_QuantReg += 1
                        p_Rows += 1
                        p_CodigoLoja = dr.Item("loj_codigo_chr") & ""

                        sbTemp.AppendFormat("<tr>{0}", Environment.NewLine)
                        If p_Rows = 1 Then
                            sbTemp.AppendFormat("   <td class='ItemLeft' rowspan='#ROWSPAN#'>{1} " & dr.Item("cli_fantasia_chr") & "<br>" & _
                                                                      "Código " & dr.Item("loj_codigo_chr") & " - " & _
                                                                      dr.Item("loj_loja_chr") & "</td>{0}", Environment.NewLine, SettingsExpression.GetProperty("nomebandeira", "Relatorios.DescricaoBandeira", "BANDEIRA"))
                        End If
                        sbTemp.AppendFormat("   <td class='Item' {1}>" & dr.Item("cat_Categoria_chr") & "</td>{0}", Environment.NewLine, GetStyleLoja())
                        sbTemp.AppendFormat("   <td class='Item' {1}>" & dr.Item("sct_SubCategoria_chr") & "</td>{0}", Environment.NewLine, GetStyleLoja())
                        sbTemp.AppendFormat("   <td class='Item' {1}>" & dr.Item("prd_Descricao_chr") & "</td>{0}", Environment.NewLine, GetStyleLoja())
                        sbTemp.AppendFormat("</tr>{0}", Environment.NewLine)

                End Select

            End While

            sb.Append(sbTemp.ToString().Replace("#ROWSPAN#", p_Rows))
            sb.AppendFormat(" </table>{0}", Environment.NewLine)
            sb.Replace("#QUANTREG#", p_QuantReg)

            dr.Close()
            dr = Nothing

            ltReport.Text = sb.ToString

            sbTemp = Nothing
            sb = Nothing

        Else

            NaoEncontrado()

        End If

    End Sub

    Private Function GetStyleLoja() As String
        If blnAlternateLoja Then
            Return " class='ItemNome' style='background-color:#DDDDDD;' "
        Else
            Return " class='ItemNome' style='background-color:#DAD8C1;' "
        End If
    End Function

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
