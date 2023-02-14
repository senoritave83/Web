Public Class RelatorioAssociados
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected WithEvents CodigoHTML As System.Web.UI.WebControls.Literal
    Private pesq As New clsPesquisas
    Private strItens As String = ""
    Private MaxPage As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Viewstate("Pagina") = CInt(0 & Page.Request("P"))
            ViewState("Associados") = Page.Request("O")
            Viewstate("Tipo") = CInt(0 & Page.Request("T"))
            Viewstate("Ord") = CInt(0 & Page.Request("OR"))

            If Viewstate("Pagina") <= 0 Then
                Viewstate("Pagina") = 1
            End If

            If Viewstate("Ord") <= 0 Then
                Viewstate("Ord") = 1
            End If

            If ViewState("Tipo") = 2 Then
                Dim obj As Object = Split(ViewState("Associados"), ",")
                strItens = obj(ViewState("Pagina") - 1)
                MaxPage = UBound(obj) + 1
            Else
                strItens = ViewState("Associados")
            End If

            Pesquisar()

        End If

    End Sub

    Private Function Pesquisar()

        Dim sbHtml As New System.Text.StringBuilder

        If Viewstate("Tipo") = 2 Then
            sbHtml.Append("				<table width='96%' border='0'>")
            sbHtml.Append("					<tr>")
            If Viewstate("Pagina") > 1 Then
                sbHtml.Append("					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") - 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></a></td>")
            Else
                sbHtml.Append("					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></td>")
            End If
            If Viewstate("Pagina") < MaxPage Then
                sbHtml.Append("					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") + 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></a></td>")
            Else
                sbHtml.Append("					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></td>")
            End If
            sbHtml.Append("					</tr>")
            sbHtml.Append("				</table>")
        End If

        Dim ds As DataSet = pesq.RelatorioAssociados(strItens, Viewstate("Ord"))
        Dim i As Integer
        If ds.Tables.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1

                sbHtml.Append("<p id='pHide" & i & "' " & IIf(i < ds.Tables(0).Rows.Count - 1, "STYLE='page-break-after: always'", "") & "  name='pHide'>" & vbCrLf)   'quebra de página

                'TÍTULO
                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td align='left'>&nbsp;</td>" & vbCrLf)
                sbHtml.Append("						<td width=100% align='center'><img src='img/logonewitc.png' border=0></td>" & vbCrLf)
                sbHtml.Append("						<td align='left'><img src='imagens/botaoDesativar.gif' onclick='fncXMHide(""pHide" & i & """)' onmousemove='this.style.cursor=""hand"";' border=0 id='btnHide" & i & "'></td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)
                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td align='left'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</font></td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'><tr><td bgcolor='#D86C00' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>ASSOCIADO</b></font></td></tr></table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td width=100% align='left' valign=top>" & vbCrLf)
                sbHtml.Append("							<table width=100%>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Nome Fantasia:</b> " & ds.Tables(0).Rows(i).Item("FANTASIA") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Razão Social:</b> " & ds.Tables(0).Rows(i).Item("RAZAOSOCIAL") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Vendedor:</b> " & ds.Tables(0).Rows(i).Item("VENDEDOR") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Módulo:</b> " & ds.Tables(0).Rows(i).Item("MODULO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Status:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAOSTATUS") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Tipo Pessoa:</b> " & ds.Tables(0).Rows(i).Item("TIPOPESSOA") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Ativação:</b> " & ds.Tables(0).Rows(i).Item("DATAATIVACAO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Forma Pagto:</b> " & ds.Tables(0).Rows(i).Item("FORMAPAGAMENTO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Ramo:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAORAMO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Atividade:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAOATIVIDADERAMO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Posição:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAOPOSICAO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CNPJ / CPF:</b> " & ds.Tables(0).Rows(i).Item("CNPJ") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>IE / RG :</b> " & ds.Tables(0).Rows(i).Item("INSCRICAOESTADUAL") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Nº Func.:</b> " & ds.Tables(0).Rows(i).Item("NUMFUNC") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Site:</b> " & ds.Tables(0).Rows(i).Item("WEBSITE") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-Mail:</b> " & ds.Tables(0).Rows(i).Item("EMAIL") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Endereço Skype:</b> " & ds.Tables(0).Rows(i).Item("SKYPE") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Início do Plano:</b> " & ds.Tables(0).Rows(i).Item("DTM_DATAINICIOPLANO") & "</font>&nbsp;<font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Fim do Plano:</b> " & ds.Tables(0).Rows(i).Item("DTMDATAFIMPLANO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Forma Pagto:</b> " & ds.Tables(0).Rows(i).Item("FORMAPAGAMENTO") & "</font>&nbsp;</td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Observações:</b> " & ds.Tables(0).Rows(i).Item("OBSERVACOES") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("							</table>" & vbCrLf)
                sbHtml.Append("						</td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'><tr><td bgcolor='#003C6E' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>ENDEREÇO DE ENTREGA</b></font></td></tr></table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td width=50% align='left' valign=top>" & vbCrLf)
                sbHtml.Append("							<table width=100%>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=2><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Endereço:</b> " & ds.Tables(0).Rows(i).Item("ENDERECO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Bairro:</b> " & ds.Tables(0).Rows(i).Item("COMPLEMENTO") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CEP:</b> " & ds.Tables(0).Rows(i).Item("CEP") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cidade:</b> " & ds.Tables(0).Rows(i).Item("CIDADE") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>UF:</b> " & ds.Tables(0).Rows(i).Item("UF") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("							</table>" & vbCrLf)
                sbHtml.Append("						</td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'><tr><td bgcolor='#003C6E' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>ENDEREÇO DE COBRANÇA</b></font></td></tr></table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td width=50% align='left' valign=top>" & vbCrLf)
                sbHtml.Append("							<table width=100%>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=2><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Endereço:</b> " & ds.Tables(0).Rows(i).Item("ENDERECOCOBRANCA") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Bairro:</b> " & ds.Tables(0).Rows(i).Item("COMPLEMENTOCOBRANCA") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CEP:</b> " & ds.Tables(0).Rows(i).Item("CEPCOBRANCA") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cidade:</b> " & ds.Tables(0).Rows(i).Item("CIDADECOBRANCA") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>UF:</b> " & ds.Tables(0).Rows(i).Item("UFCOBRANCA") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("							</table>" & vbCrLf)
                sbHtml.Append("						</td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'><tr><td bgcolor='#003C6E' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>ENDEREÇO DE FATURAMENTO</b></font></td></tr></table>" & vbCrLf)

                sbHtml.Append("				<table width='100%' border='0'>" & vbCrLf)
                sbHtml.Append("					<tr>" & vbCrLf)
                sbHtml.Append("						<td width=50% align='left' valign=top>" & vbCrLf)
                sbHtml.Append("							<table width=100%>" & vbCrLf)
                sbHtml.Append("								<tr><td colspan=2><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Endereço:</b> " & ds.Tables(0).Rows(i).Item("ENDERECOFATURAMENTO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Bairro:</b> " & ds.Tables(0).Rows(i).Item("COMPLEMENTOFATURAMENTO") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CEP:</b> " & ds.Tables(0).Rows(i).Item("CEPFATURAMENTO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cidade:</b> " & ds.Tables(0).Rows(i).Item("CIDADEFATURAMENTO") & "</font></td><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>UF:</b> " & ds.Tables(0).Rows(i).Item("UFFATURAMENTO") & "</font></td></tr>" & vbCrLf)
                sbHtml.Append("							</table>" & vbCrLf)
                sbHtml.Append("						</td>" & vbCrLf)
                sbHtml.Append("					</tr>" & vbCrLf)
                sbHtml.Append("				</table>" & vbCrLf)

                Dim ds2 As DataSet = pesq.RelatorioContatosAssociados(ds.Tables(0).Rows(i).Item("CODIGO"))
                Dim j As Integer

                If ds2.Tables.Count > 0 Then

                    If ds2.Tables(0).Rows.Count > 0 Then

                        sbHtml.Append("				<table width='100%' align=center border='0'>")
                        sbHtml.Append("				    <tr><td bgcolor='#003C6E' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>CONTATOS DO ASSOCIADO</b></font></td></tr>")
                        sbHtml.Append("				</table>")

                        sbHtml.Append("<table width='100%' border='0'>" & vbCrLf)
                        sbHtml.Append("<tr>" & vbCrLf)
                        sbHtml.Append("<td width=100% align='left' valign=top>" & vbCrLf)
                        sbHtml.Append("<table width=100% border=0>" & vbCrLf)

                        For j = 0 To ds2.Tables(0).Rows.Count - 1
                            sbHtml.Append("<tr>")
                            sbHtml.Append("<td width=100% colspan=4 align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b> " & ds2.Tables(0).Rows(j).Item("DESCRICAOCARGO") & ":  " & ds2.Tables(0).Rows(j).Item("NOMECONTATO") & "</b></font></td>")
                            sbHtml.Append("<tr>")
                            sbHtml.Append("<td width=20% align=left nowrap><font class='f8Rel' face='verdana' style='font-size: 8pt'>")
                            sbHtml.Append("<b>Telefone:</b>")
                            If (ds2.Tables(0).Rows(j).Item("DDD") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("TELEFONE") & "").Trim() <> "" Then
                                sbHtml.Append("(" & ds2.Tables(0).Rows(j).Item("DDD").Trim() & ") " & ds2.Tables(0).Rows(j).Item("TELEFONE").Trim())
                            Else
                                sbHtml.Append("&nbsp;")
                            End If
                            sbHtml.Append("</font></td>")
                            sbHtml.Append("<td width=20% ><font class='f8Rel' face='verdana'  style='font-size: 8pt'>")
                            sbHtml.Append("<b>Fax:</b>")
                            If (ds2.Tables(0).Rows(j).Item("DDDFAX") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("FAX") & "").Trim() <> "" Then
                                sbHtml.Append("(" & ds2.Tables(0).Rows(j).Item("DDDFAX").Trim() & ") " & ds2.Tables(0).Rows(j).Item("FAX").Trim() & "&nbsp;&nbsp;")
                            Else
                                sbHtml.Append("&nbsp;")
                            End If
                            sbHtml.Append("</font></td>")
                            sbHtml.Append("<td width=20% ><font class='f8Rel' face='verdana'  style='font-size: 8pt'>")
                            sbHtml.Append("<b>Celular:</b>")
                            If (ds2.Tables(0).Rows(j).Item("DDDCELULAR") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("CELULAR") & "").Trim() <> "" Then
                                sbHtml.Append("(" & ds2.Tables(0).Rows(j).Item("DDDCELULAR").Trim() & ") " & ds2.Tables(0).Rows(j).Item("CELULAR").Trim() & "&nbsp;&nbsp;")
                            Else
                                sbHtml.Append("&nbsp;")
                            End If
                            sbHtml.Append("</font></td>")
                            sbHtml.Append("<td width=20% align=left nowrap><font class='f8Rel' face='verdana' style='font-size: 8pt'><b>E-mail:</b></font>")
                            sbHtml.Append("<a class=f8Rel face='verdana' style='font-size: 8pt' href='mailto:" & ds2.Tables(0).Rows(j).Item("EMAIL") & "'>")
                            sbHtml.Append("<font class='f8Rel' face='verdana' style='font-size: 8pt'> " & ds2.Tables(0).Rows(j).Item("EMAIL") & "</font></a>")
                            sbHtml.Append("</td>")
                            sbHtml.Append("<td width=20% align=left nowrap><font class='f8Rel' face='verdana' style='font-size: 8pt'><b>Skype:</b></font>")
                            sbHtml.Append("<font class='f8Rel' face='verdana' style='font-size: 8pt'> " & ds2.Tables(0).Rows(j).Item("SKYPE") & "</font></a>")
                            sbHtml.Append("</td></tr>" & vbCrLf)

                        Next

                        sbHtml.Append("							</table>" & vbCrLf)
                        sbHtml.Append("						</td>" & vbCrLf)
                        sbHtml.Append("					</tr>" & vbCrLf)
                        sbHtml.Append("				</table>" & vbCrLf)

                    End If

                End If

                sbHtml.Append("				<table width='100%' border='0'>")
                sbHtml.Append("					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>")
                sbHtml.Append("				</table>")
                sbHtml.Append("				<table width='100%' border='0'>")
                sbHtml.Append("					<tr><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>www.itc.etc.br</b></font></td><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-mail: itc@itc.etc.br</b></font></td></tr>")
                sbHtml.Append("				</table>")
                sbHtml.Append("				<table width='96%' border='0'>")
                sbHtml.Append("					<tr><td align='middle' width='100%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</b></font></td></tr>")
                sbHtml.Append("				</table>")

                sbHtml.Append("</p>")

            Next

            sbHtml.Append("<script language='javascript'>" & vbCrLf)
            sbHtml.Append("     var countDiv = " & i & ";" & vbCrLf)
            sbHtml.Append("     function fncXMHide(p)" & vbCrLf)
            sbHtml.Append("     {" & vbCrLf)
            sbHtml.Append("         obj = document.getElementById(p);" & vbCrLf)
            sbHtml.Append("         obj.style.display = 'none';" & vbCrLf)
            sbHtml.Append("         //faz o loop através dos objetos da pagina para " & vbCrLf)
            sbHtml.Append("         //mudar o style das tag's <p>" & vbCrLf)
            sbHtml.Append("         var j = 0, i = 0, y = 0;" & vbCrLf)
            sbHtml.Append("         while(j < countDiv)" & vbCrLf)
            sbHtml.Append("         {" & vbCrLf)
            sbHtml.Append("             var e = document.getElementById('pHide' + j);" & vbCrLf)
            sbHtml.Append("             i = i + (e.style.display != 'none' ? 1 : 0);" & vbCrLf)
            sbHtml.Append("             j += 1;" & vbCrLf)
            sbHtml.Append("         }" & vbCrLf)
            sbHtml.Append("         j = 0;" & vbCrLf)
            sbHtml.Append("         while(j < countDiv)" & vbCrLf)
            sbHtml.Append("         {" & vbCrLf)
            sbHtml.Append("             var e = document.getElementById('pHide' + j);" & vbCrLf)
            'sbHtml.Append("             alert((e.style.display != 'none'));" & vbCrLf)
            sbHtml.Append("             if (e.style.display != 'none')" & vbCrLf)
            sbHtml.Append("             {" & vbCrLf)
            'sbHtml.Append("                 alert(y + ' - ' + (i -1));" & vbCrLf)
            sbHtml.Append("                 if( y < (i - 1))" & vbCrLf)
            sbHtml.Append("                     e.style.pageBreakAfter = 'always';" & vbCrLf)
            sbHtml.Append("                 else e.style.pageBreakAfter = '';" & vbCrLf)
            sbHtml.Append("                 y += 1;" & vbCrLf)
            sbHtml.Append("             }" & vbCrLf)
            sbHtml.Append("             else e.style.pageBreakAfter = '';" & vbCrLf)
            'sbHtml.Append("             alert('Page Break ' + e.style.pageBreakAfter);" & vbCrLf)
            sbHtml.Append("             j += 1;" & vbCrLf)
            sbHtml.Append("         }" & vbCrLf)
            sbHtml.Append("     }" & vbCrLf)
            sbHtml.Append("</script>" & vbCrLf)

        End If

        If Viewstate("Tipo") = 2 Then
            sbHtml.Append("				<table width='96%' border='0'>")
            sbHtml.Append("					<tr>")
            If Viewstate("Pagina") > 1 Then
                sbHtml.Append("					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") - 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></a></td>")
            Else
                sbHtml.Append("					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></td>")
            End If
            If Viewstate("Pagina") < MaxPage Then
                sbHtml.Append("					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") + 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></a></td>")
            Else
                sbHtml.Append("					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></td>")
            End If
            sbHtml.Append("					</tr>")
            sbHtml.Append("				</table>")

        End If

        CodigoHTML.Text = sbHtml.ToString()

    End Function

End Class