Imports Classes
Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptResPOPDet
    Inherits XMWebPage

    Dim rpt As clsReports

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Try

                ViewState("cli") = Request("cli")
                ViewState("loj") = Request("loj")
                ViewState("shop") = Request("shop")
                ViewState("tiploj") = Request("tiploj")
                ViewState("reg") = Request("regs")
                ViewState("sta") = Request("sta")
                ViewState("est") = Request("est")
                ViewState("pertxt") = Request("pertxt") & ""
                ViewState("per") = Request("per")

                Dim p_Temp As Object = Split(ViewState("per"), "||", , CompareMethod.Text)
                ViewState("pi") = p_Temp(0)
                ViewState("pn") = p_Temp(1)

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
        rptResult = rpt.getRelatorioResumoPOP(Me.User.IDEmpresa, _
                                                ViewState("cli"), ViewState("loj"), ViewState("shop"), _
                                                ViewState("tiploj"), ViewState("reg"), ViewState("sta"), _
                                                ViewState("est"), ViewState("pi"), ViewState("pn"))

        If rptResult.Sucess Then

            Dim ds As DataSet = rptResult.Header
            Dim i As Integer = 0
            Dim sb As New System.Text.StringBuilder

            '*****************************
            'RELATÓRIO POP
            '*****************************

            sb.AppendFormat("<table>{0}", Environment.NewLine)
            sb.AppendFormat("<tr>{0}", Environment.NewLine)
            sb.AppendFormat("    <td>")
            sb.AppendFormat("       <table class=TabelaPOP border=0 cellpadding=1 cellspacing=0 width='100%'>")
            sb.AppendFormat("           <tr>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaLojas >&nbsp;</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaLojas width='100'>Total</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaNone width='30'>&nbsp;</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaLojas width='100'>Presença</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaNone width='100' style='color:#99CC00;background:#99CC00;'>&nbsp;</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=TituloColunaNone width='30'>&nbsp;</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=LinhaItem style='border:none;text-align:right;' width='100'>Período&nbsp;</td>{0}", Environment.NewLine)
            sb.AppendFormat("               <td class=LinhaItem style='border:none;'>" & ViewState("pi") & " Até " & ViewState("pn") & "</td>{0}", Environment.NewLine)
            sb.AppendFormat("           </tr>{0}", Environment.NewLine)

            For i = 0 To ds.Tables(0).Rows.Count - 1

                sb.AppendFormat("       <tr>{0}", Environment.NewLine)
                sb.AppendFormat("           <td class=TabelaPOPItem>" & ds.Tables(0).Rows(i).Item("pgr_Resposta_chr") & "</td>{0}", Environment.NewLine)
                sb.AppendFormat("           <td class=TabelaPOPValue>" & ds.Tables(0).Rows(i).Item("Result") & "</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("               <td class=TituloColunaNone>&nbsp;</td>{0}", Environment.NewLine)
                sb.AppendFormat("       </tr>{0}", Environment.NewLine)

            Next

            sb.AppendFormat("           </table>{0}", Environment.NewLine)
            sb.AppendFormat("       </td>")
            sb.AppendFormat("   </tr>{0}", Environment.NewLine)
            sb.AppendFormat("<table>{0}", Environment.NewLine)

            sb.AppendFormat("<br>{0}", Environment.NewLine)

            sb.AppendFormat("<table id='tblResult' border=0 cellpadding=5 cellspacing=0 style='border-bottom:.5pt solid black;'>{0}", Environment.NewLine)

            sb.AppendFormat("<tr height=33 style='height:24.75pt'>{0}", Environment.NewLine)
            sb.AppendFormat("  <td height=33 class=TituloColunaLojas style='width:250px;height:24.75pt'>Loja</td>{0}", Environment.NewLine)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                sb.AppendFormat("  <td class=TituloColunaItens >" & ds.Tables(0).Rows(i).Item("pgr_Resposta_chr") & "</td>{0}", Environment.NewLine)
            Next
            sb.AppendFormat("  <td class=TituloColunaItens style='width:50;height:24.75pt'>Total por Loja</td>{0}", Environment.NewLine)
            sb.AppendFormat("</tr>{0}", Environment.NewLine)

            Dim p_IdLoja As Integer = 0, p_TotalLoja As Integer = 0, p_TotalGeral As Integer = 0

            For i = 0 To ds.Tables(1).Rows.Count - 1

                'DADOS DO RELATÓRIO

                Dim p_Row As DataRow = ds.Tables(1).Rows(i)

                If p_IdLoja <> p_Row("loj_Loja_int_PK") Then

                    If p_IdLoja > 0 Then

                        sb.AppendFormat(" <td class=LinhaItem style='width:100;'>" & p_TotalLoja & "</td>{0}", Environment.NewLine)
                        sb.AppendFormat("</tr>{0}", Environment.NewLine)

                    End If

                    p_TotalLoja = 0

                    sb.AppendFormat("<tr height=17 style='height:12.75pt'>{0}", Environment.NewLine)
                    sb.AppendFormat("  <td height=17 class=LinhaLoja style='text-align:left;'>" & p_Row("loj_Loja_chr") & "</td>{0}", Environment.NewLine)

                End If

                p_IdLoja = p_Row("loj_Loja_int_PK")
                p_TotalLoja = p_TotalLoja + p_Row("Result")
                p_TotalGeral = p_TotalGeral + p_Row("Result")

                If p_Row("Result") = 0 Then
                    sb.AppendFormat("  <td class=LinhaItem style='width:100'>&nbsp;</td>{0}", Environment.NewLine)
                Else
                    sb.AppendFormat("  <td class=LinhaItem style='width:100;color:#99CC00;background:#99CC00;'>&nbsp;</td>{0}", Environment.NewLine)
                End If

            Next

            sb.AppendFormat("  <td class=LinhaItem style='width:100;'>" & p_TotalLoja & "</td>{0}", Environment.NewLine)
            sb.AppendFormat("</tr>{0}", Environment.NewLine)

            sb.AppendFormat("</table>{0}", Environment.NewLine)

            ds.Dispose()
            ds = Nothing

            ltReport.Text = sb.ToString

        Else

            NaoEncontrado()

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
