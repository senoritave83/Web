Imports System.Data.SqlClient

Public Class RelatorioObrasDEMO

    Inherits System.Web.UI.Page

    Protected WithEvents CodigoHTML As System.Web.UI.WebControls.Literal
    Private pesq As New clsPesquisas()
    Private strItens As String = ""
    Private MaxPage As Integer

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Viewstate("Pagina") = CInt(0 & Page.Request("P"))
            ViewState("Obras") = Page.Request("O")
            Viewstate("Tipo") = CInt(0 & Page.Request("T"))
            If Viewstate("Pagina") <= 0 Then
                Viewstate("Pagina") = 1
            End If
            If ViewState("Tipo") = 2 Then
                Dim obj As Object = Split(ViewState("Obras"), ",")
                strItens = obj(ViewState("Pagina") - 1)
                MaxPage = UBound(obj) + 1
            Else
                strItens = ViewState("Obras")
            End If
            Pesquisar()
        End If
    End Sub

    Private Function Pesquisar()

        Dim strHTML As String

        strHTML = "<table width=700 cellspacing=0 border=1 bordercolor=#000000>" & vbCrLf
        strHTML += "     <tr>" & vbCrLf
        strHTML += "			<td width=100%>" & vbCrLf
        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr>" & vbCrLf
        strHTML += "						<td align='left'><img src='imagens/logoitcrelatorio.jpg'></td>" & vbCrLf
        strHTML += "						<td width=100% align='center'><img src='imagens/TituloRelatorioObra.jpg' border=0></td>" & vbCrLf
        strHTML += "					</tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf
        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr>" & vbCrLf
        strHTML += "						<td align='left'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</font></td>" & vbCrLf
        strHTML += "					</tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf

        Dim ds As DataSet = pesq.RelatorioObras(strItens, 1)
        Dim i As Integer
        If ds.Tables.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1

                'TÍTULO
                strHTML += "				<table width='100%' border='0'><tr><td bgcolor='#D86C00' width=100% align='center'><font class='f8Rel' face='verdana' size='2' color='#ffffff'><b>DADOS DA OBRA</b></font></td></tr></table>" & vbCrLf

                strHTML += "				<table width='100%' border='0'>" & vbCrLf
                strHTML += "					<tr>" & vbCrLf
                strHTML += "						<td width=100% align='left' valign=top>" & vbCrLf
                strHTML += "							<table width=100%>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Código da Obra:</b> " & ds.Tables(0).Rows(i).Item("CODIGOANTIGO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Data:</b> " & ds.Tables(0).Rows(i).Item("PUBLICACAO") & "</font></td><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Revisão:</b> " & ds.Tables(0).Rows(i).Item("NRDAREVISAO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td colspan=3><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Nome do Projeto:</b> " & ds.Tables(0).Rows(i).Item("PROJETO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Endereço:</b> " & ds.Tables(0).Rows(i).Item("ENDERECO") & "</font></td><td colspan=2><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Bairro:</b> " & ds.Tables(0).Rows(i).Item("COMPLEMENTO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td width=60%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cidade:</b> " & ds.Tables(0).Rows(i).Item("CIDADE") & "</font></td><td width=20%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Estado:</b> " & ds.Tables(0).Rows(i).Item("ESTADO") & "</font></td><td width=20%><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CEP:</b> " & ds.Tables(0).Rows(i).Item("CEP") & "</font></td></tr>" & vbCrLf
                strHTML += "							</table>" & vbCrLf
                strHTML += "						</td>" & vbCrLf
                strHTML += "					</tr>" & vbCrLf
                strHTML += "				</table>" & vbCrLf

                strHTML += "				<table width='100%' border='0'>" & vbCrLf
                strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf
                strHTML += "				</table>" & vbCrLf

                strHTML += "				<table width='100%' border='0'>" & vbCrLf
                strHTML += "					<tr>" & vbCrLf
                strHTML += "						<td width=50% align='left' valign=top>" & vbCrLf
                strHTML += "							<table width=100%>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Tipo de Obra:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAOTIPO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Estágio Atual:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAOESTAGIO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Matéria Prima:</b> " & ds.Tables(0).Rows(i).Item("MATERIAPRIMA") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Início da Obra:</b> " & ds.Tables(0).Rows(i).Item("INICIO") & "</font></td></tr>" & vbCrLf
                strHTML += "							</table>" & vbCrLf
                strHTML += "						</td>" & vbCrLf
                strHTML += "						<td width=50% align='left' valign=top>" & vbCrLf
                strHTML += "							<table width=100%>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Capacidade de Produção:</b> " & ds.Tables(0).Rows(i).Item("CAPACIDADEDEPRODUCAO") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Área Construída m&#178;:</b> " & ds.Tables(0).Rows(i).Item("AREACONSTRUIDA") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Valor de Investimento (US$ 1.000):</b> " & ds.Tables(0).Rows(i).Item("VALOR") & "</font></td></tr>" & vbCrLf
                strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Término da Obra:</b> " & ds.Tables(0).Rows(i).Item("TERMINO") & "</font></td></tr>" & vbCrLf
                strHTML += "							</table>" & vbCrLf
                strHTML += "						</td>" & vbCrLf
                strHTML += "					</tr>" & vbCrLf
                If CStr((ds.Tables(0).Rows(i).Item("INICIOTERMINO") & "")).Trim() <> "" Then
                    strHTML += "					<tr>" & vbCrLf
                    strHTML += "						<td width=100% colspan=2 align='left' valign=top>" & vbCrLf
                    strHTML += "							<table width=100%>" & vbCrLf
                    strHTML += "								<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Início / Término:</b> " & ds.Tables(0).Rows(i).Item("INICIOTERMINO") & "</font></td></tr>" & vbCrLf
                    strHTML += "							</table>" & vbCrLf
                    strHTML += "						</td>" & vbCrLf
                    strHTML += "					</tr>" & vbCrLf
                End If
                strHTML += "				</table>" & vbCrLf

                strHTML += "				<table width='100%' border='0'>" & vbCrLf
                strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf
                strHTML += "				</table>" & vbCrLf

                strHTML += "				<table width=100%>" & vbCrLf
                strHTML += "					<tr><td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Descrição do Empreendimento:</b> " & ds.Tables(0).Rows(i).Item("DESCRICAO") & "</font></td></tr>" & vbCrLf
                strHTML += "				</table>" & vbCrLf

                Dim ds2 As DataSet = pesq.RelatorioContatosObras(ds.Tables(0).Rows(i).Item("CODIGO"))
                Dim j As Integer

                If ds2.Tables.Count > 0 Then

                    If ds2.Tables(0).Rows.Count > 0 Then

                        'strHTML += "				<table width='100%' border='0'><tr><td bgcolor='#003C6E' width=100% align='center'><font class='f8Rel' face='verdana' size='1' color='#ffffff'><b>CONTATOS NA OBRA</b></font></td></tr></table>" & vbCrLf
                        strHTML += "				<table width='80%' align=center border='0'>"
                        strHTML += "				    <tr><td bgcolor='#003C6E' width=80% align='center'><font class='f8Rel' face='verdana' size='1' color='#ffffff'><b>CONTATOS NA OBRA</b></font></td></tr>"
                        strHTML += "				</table>"

                        For j = 0 To ds2.Tables(0).Rows.Count - 1
                            strHTML += "				<table width='100%' border='0'>" & vbCrLf
                            strHTML += "					<tr>" & vbCrLf
                            strHTML += "						<td width=100% align='left' valign=top>" & vbCrLf
                            strHTML += "							<table width=100%>" & vbCrLf
                            strHTML += "								<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b> " & ds2.Tables(0).Rows(j).Item("DESCRICAOCARGO") & ":  " & ds2.Tables(0).Rows(j).Item("NOMECONTATO") & "</b></font></td><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Empresa:</b> " & ds2.Tables(0).Rows(j).Item("FANTASIA") & "</font></td></tr>" & vbCrLf
                            strHTML += "								<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>"
                            If ds2.Tables(0).Rows(j).Item("TIPOTELEFONE1") > 0 Then
                                If (ds2.Tables(0).Rows(j).Item("DDD") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("TELEFONE") & "").Trim() <> "" Then
                                    Select Case ds2.Tables(0).Rows(j).Item("TIPOTELEFONE1")
                                        Case 1
                                            strHTML += "<b>Telefone:</b>"
                                        Case 2
                                            strHTML += "<b>Celular:</b>"
                                        Case 3
                                            strHTML += "<b>Fax:</b>"
                                        Case 4
                                            strHTML += "<b>PABX:</b>"
                                        Case 5
                                            strHTML += "<b>Obra:</b>"
                                    End Select
                                    strHTML += "(" & ds2.Tables(0).Rows(j).Item("DDD").Trim() & ") " & ds2.Tables(0).Rows(j).Item("TELEFONE").Trim()
                                Else
                                    strHTML += "&nbsp;"
                                End If
                            Else
                                strHTML += "&nbsp;"
                            End If
                            strHTML += "</font></td><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>"
                            If ds2.Tables(0).Rows(j).Item("TIPOTELEFONE2") > 0 Then
                                If (ds2.Tables(0).Rows(j).Item("DDDFAX") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("FAX") & "").Trim() <> "" Then
                                    Select Case ds2.Tables(0).Rows(j).Item("TIPOTELEFONE2")
                                        Case 1
                                            strHTML += "<b>Telefone:</b>"
                                        Case 2
                                            strHTML += "<b>Celular:</b>"
                                        Case 3
                                            strHTML += "<b>Fax:</b>"
                                        Case 4
                                            strHTML += "<b>PABX:</b>"
                                        Case 5
                                            strHTML += "<b>Obra:</b>"
                                    End Select
                                    strHTML += "(" & ds2.Tables(0).Rows(j).Item("DDDFAX").Trim() & ") " & ds2.Tables(0).Rows(j).Item("FAX").Trim()
                                Else
                                    strHTML += "&nbsp;"
                                End If
                            Else
                                strHTML += "&nbsp;"
                            End If
                            strHTML += "</font></td></tr>" & vbCrLf
                            strHTML += "							</table>" & vbCrLf
                            strHTML += "						</td>" & vbCrLf
                            strHTML += "					</tr>" & vbCrLf
                            strHTML += "				</table>" & vbCrLf

                            If j = 3 Then Exit For 'apenas 3 empresas participantes

                        Next

                    End If

                End If

                Dim ds3 As DataSet = pesq.RelatorioEmpresasObras(ds.Tables(0).Rows(i).Item("CODIGO"))
                Dim l As Integer
                If ds3.Tables.Count > 0 Then

                    For l = 0 To ds3.Tables(0).Rows.Count - 1

                        If l = 0 Then

                            strHTML += "				<table width='80%' align=center border='0'>"
                            strHTML += "				    <tr><td bgcolor='#003C6E' width=80% align='center'><font class='f8Rel' face='verdana' size='1' color='#ffffff'><b>EMPRESAS PARTICIPANTES</b></font></td></tr>"
                            strHTML += "				</table>"

                        Else

                            strHTML += "				<table width='100%' border='0'>" & vbCrLf
                            strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf
                            strHTML += "				</table>" & vbCrLf

                        End If

                        strHTML += "				<table width='100%' border='0'>" & vbCrLf
                        strHTML += "					<tr>" & vbCrLf
                        strHTML += "						<td width=100% align='center'>" & vbCrLf
                        strHTML += "							<table width=100%>" & vbCrLf
                        strHTML += "								<tr><td width=100% align=left nowrap colspan=2><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b> " & ds3.Tables(0).Rows(l).Item("FANTASIA") & " - " & ds3.Tables(0).Rows(l).Item("DESCRICAOMODALIDADE") & "</b></font></td></tr>" & vbCrLf
                        strHTML += "								<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Atividade:</b> " & ds3.Tables(0).Rows(l).Item("DESCRICAOATIVIDADE") & "</font></td><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>CNPJ:</b> " & ds3.Tables(0).Rows(l).Item("CNPJ") & "</font></td></tr>" & vbCrLf
                        strHTML += "								<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Rua:</b> " & ds3.Tables(0).Rows(l).Item("ENDERECO") & "</font></td><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Site:</b> " & ds3.Tables(0).Rows(l).Item("SITE") & "</font></td></tr>" & vbCrLf
                        strHTML += "								<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cidade:</b> " & ds3.Tables(0).Rows(l).Item("Cidade") & " <b>Estado:</b> " & ds3.Tables(0).Rows(l).Item("Estado") & " <b>Cep:</b> " & ds3.Tables(0).Rows(l).Item("CEP") & "</font></td><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-mail:</b> " & ds3.Tables(0).Rows(l).Item("EMAIL") & "</font></td></tr>" & vbCrLf
                        strHTML += "							</table>" & vbCrLf

                        Dim ds4 As DataSet = pesq.RelatorioContatosEmpresas(ds3.Tables(0).Rows(l).Item("IDEMPRESA"))
                        Dim m As Integer
                        If ds4.Tables.Count > 0 Then

                            If ds4.Tables(0).Rows.Count > 0 Then
                                strHTML += "				<table width='100%' border='0'>" & vbCrLf
                                For m = 0 To ds4.Tables(0).Rows.Count - 1
                                    'If m = 0 Then
                                    'strHTML += "				<tr><td colspan=3 width=100%><table width='100%' border='0'><tr><td bgcolor='#FFFFFF' width=20%>&nbsp;</td><td bgcolor='#003C6E' width=60% align='center'><font class='f8Rel' face='verdana' size='1' color='#ffffff'><b>CONTATOS NA EMPRESA</b></font></td><td bgcolor='#FFFFFF' width=20%>&nbsp;</td></tr></table></td></tr>"
                                    'End If
                                    strHTML += "					<tr><td width=50% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>" & ds4.Tables(0).Rows(m).Item("DESCRICAOCARGO") & ":</b> " & ds4.Tables(0).Rows(m).Item("NOMECONTATO") & "</font></td><td width=25% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>"
                                    If (ds4.Tables(0).Rows(m).Item("DDD") & "").Trim() <> "" And (ds4.Tables(0).Rows(m).Item("TELEFONE") & "").Trim() <> "" Then
                                        strHTML += "<b>Telefone:</b> ( " & ds4.Tables(0).Rows(m).Item("DDD") & ") " & ds4.Tables(0).Rows(m).Item("TELEFONE")
                                    Else
                                        strHTML += "&nbsp;"
                                    End If
                                    strHTML += "</font></td><td width=25% align=left nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>"
                                    If (ds4.Tables(0).Rows(m).Item("DDDFAX") & "").Trim() <> "" And (ds4.Tables(0).Rows(m).Item("FAX") & "").Trim() <> "" Then
                                        strHTML += "<b>Fax:</b> ( " & ds4.Tables(0).Rows(m).Item("DDDFAX") & ") " & ds4.Tables(0).Rows(m).Item("FAX") & "</font></td></tr>" & vbCrLf
                                    Else
                                        strHTML += "&nbsp;"
                                    End If
                                    If m = 2 Then Exit For 'apenas 3 contatos por empresa participante
                                Next
                                strHTML += "				</table>" & vbCrLf
                            End If

                        End If

                        strHTML += "						</td>" & vbCrLf
                        strHTML += "					</tr>" & vbCrLf
                        strHTML += "				</table>" & vbCrLf

                        If l = 2 Then Exit For 'apenas 3 empresas participantes

                    Next

                End If

            Next
        End If

        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>"
        strHTML += "				</table>"
        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>www.itc.etc.br</b></font></td><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-mail: itc@itc.etc.br</b></font></td></tr>"
        strHTML += "				</table>"
        strHTML += "				<table width='96%' border='0'>"
        strHTML += "					<tr><td align='middle' width='100%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</b></font></td></tr>"
        strHTML += "				</table>"
        If Viewstate("Tipo") = 2 Then
            strHTML += "				<table width='96%' border='0'>"
            strHTML += "					<tr>"
            If Viewstate("Pagina") > 1 Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioObras.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Obras") & "&P=" & Viewstate("Pagina") - 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></td>"
            End If
            If Viewstate("Pagina") < MaxPage Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioObras.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Obras") & "&P=" & Viewstate("Pagina") + 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></td>"
            End If
            strHTML += "					</tr>"
            strHTML += "				</table>"
        End If
        strHTML += "			</td>"
        strHTML += "		</tr>"
        strHTML += "	</table>"

        CodigoHTML.Text = strHTML

    End Function

End Class
