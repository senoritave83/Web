Public Class RelatorioEmpresas

    Inherits XMWebPage

    Private pesq As New clsPesquisas
    Private strItens As String = ""
    Private MaxPage As Integer
    Protected WithEvents CodigoHTML As Literal

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
            ViewState("Empresas") = Page.Request("O")
            Viewstate("Tipo") = CInt(0 & Page.Request("T"))
            ViewState("Ordenacao") = CInt(0 & Page.Request("Q"))

            If Viewstate("Pagina") <= 0 Then
                Viewstate("Pagina") = 1
            End If
            If ViewState("Tipo") = 2 Then
                Dim obj As Object = Split(ViewState("Empresas"), ",")
                strItens = obj(ViewState("Pagina") - 1)
                MaxPage = UBound(obj) + 1
            Else
                strItens = ViewState("Empresas")
            End If
            Pesquisar()
        End If
    End Sub

    Private Function Pesquisar()


        'strHTML = "<table width=700 cellspacing=0 border=1 bordercolor=#000000>")
        'sb.Append("     <tr>")
        'sb.Append("			<td width=100%>")


        Dim blnQuebra As Boolean = False
        Dim sb As New System.Text.StringBuilder
        Dim ds As DataSet = pesq.RelatorioEmpresas(strItens, ViewState("Ordenacao"), Usuario.IdEmpresa)
        Dim i As Integer
        If ds.Tables.Count > 0 Then

            sb.Append("	<div id='Tudo'>")

            For i = 0 To ds.Tables(0).Rows.Count - 1

                'If Viewstate("Tipo") > 1 And i < ds.Tables(0).Rows.Count - 1 Then sb.Append("<p STYLE='page-break-after: always'>" & vbCrLf) 'QUEBRA DE PÁGINA

                If i Mod 3 = 0 Then

                    If blnQuebra Then sb.Append("<p style='page-break-after: always' name='pHide'>" & vbCrLf) 'QUEBRA DE PÁGINA

                    sb.Append("		<div style='height:50px;width:679px;margin:0 0 5px 33px'>")
                    sb.Append("         <img alt='' src='img/topo_empresa.jpg' border='0'>")
                    sb.Append("		    <p>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</p>")
                    sb.Append("     </div>")

                End If

                sb.Append("     <div style='padding:0 0 0 33px;'>")
                sb.Append("         <h4 style='width:250px'><strong>" & ds.Tables(0).Rows(i).Item("FANTASIA") & "</strong></h4>")
                sb.Append("         <h4 style='width:428px'><strong>Ultima atualização em:</strong>" & ds.Tables(0).Rows(i).Item("ATUALIZACAO") & " &nbsp; &nbsp; &nbsp;<strong>Revisão: " & ds.Tables(0).Rows(i).Item("REVISAO") & "</strong></h4>")
                sb.Append("	        <br class='clear' />")
                sb.Append("     </div>")


                sb.Append("	    <div class='relatorio_tit' style='line-height:20px;width:678px;'><div class='FloatLeft'>Dados da Empresa &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</div><div class='FonteStatusSIG'>" & ds.Tables(0).Rows(i).Item("STATUSSIG") & "</div>")
                sb.Append("     <div class='FloatRight'><input class='bt_relatorio_result' type='button' value='Novo SIG' onclick=""window.open('followupempresadetmini.aspx?idempresa=" & CryptographyEncoded(ds.Tables(0).Rows(i).Item("CODIGO")) & "', 'Pagina', 'STATUS=NO, TOOLBAR=NO, LOCATION=NO, DIRECTORIES=NO, RESISABLE=NO, SCROLLBARS=YES, TOP=10, LEFT=10, WIDTH=775, HEIGHT=355');"" >&nbsp;</div></div>")
                sb.Append("     <div class='relatorio' style='width:678px'>")

                sb.Append("           <cite class='meio' style='border:none;'><strong>Razão Social:</strong> " & ds.Tables(0).Rows(i).Item("RAZAOSOCIAL") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Endereço:</strong> " & ds.Tables(0).Rows(i).Item("ENDERECO") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Bairro:</strong> " & ds.Tables(0).Rows(i).Item("COMPLEMENTO") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Cidade:</strong> " & ds.Tables(0).Rows(i).Item("CIDADE") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Estado:</strong>  " & ds.Tables(0).Rows(i).Item("ESTADO") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>CEP:</strong> " & ds.Tables(0).Rows(i).Item("CEP") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>CNPJ:</strong> " & ds.Tables(0).Rows(i).Item("CNPJ") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Atividade:</strong> " & ds.Tables(0).Rows(i).Item("DESCRICAOATIVIDADE") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>E-Mail:</strong> " & IIf(ds.Tables(0).Rows(i).Item("EMAIL") <> "", "<A HREF='mailto:" & ds.Tables(0).Rows(i).Item("EMAIL") & "'>" & ds.Tables(0).Rows(i).Item("EMAIL") & "</a>", "") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Site:</strong> " & IIf(ds.Tables(0).Rows(i).Item("WEBSITE") <> "", "<A TARGET='" & ds.Tables(0).Rows(i).Item("WEBSITE") & "' HREF='" & ds.Tables(0).Rows(i).Item("WEBSITE") & "'>" & ds.Tables(0).Rows(i).Item("WEBSITE") & "</a>", "") & "</a></cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>E-Mail Secundário:</strong> " & IIf(ds.Tables(0).Rows(i).Item("EMAIL2") <> "", "<A HREF='mailto:" & ds.Tables(0).Rows(i).Item("EMAIL2") & "'>" & ds.Tables(0).Rows(i).Item("EMAIL2") & "</a>", "") & "</cite>")
                sb.Append("           <cite class='meio' style='border:none;'><strong>Endereço Skype:</strong> " & ds.Tables(0).Rows(i).Item("SKYPE") & "</cite>")

                Dim ds2 As DataSet = pesq.RelatorioContatosEmpresas(ds.Tables(0).Rows(i).Item("CODIGO"))
                Dim j As Integer
                If ds2.Tables.Count > 0 Then

                    If ds2.Tables(0).Rows.Count > 0 Then

                        sb.Append("				<table>")

                        For j = 0 To ds2.Tables(0).Rows.Count - 1
                            sb.Append("     	<tr><td nowrap style='padding-left:8px;width:260px' align=left nowrap><font><b> " & ds2.Tables(0).Rows(j).Item("DESCRICAOCARGO") & "</b>: " & ds2.Tables(0).Rows(j).Item("NOMECONTATO") & "</font></td><td  nowrap style='width:380px' align=left nowrap><font class='f8Rel'   >")
                            If ds2.Tables(0).Rows(j).Item("TipoTelefone1") > 0 Then
                                If (ds2.Tables(0).Rows(j).Item("DDD").Trim() & "") <> "" And (ds2.Tables(0).Rows(j).Item("TELEFONE").Trim() & "") <> "" Then
                                    Select Case ds2.Tables(0).Rows(j).Item("TipoTelefone1")
                                        Case 1
                                            sb.Append("<b>Tel.:</b>")
                                        Case 2
                                            sb.Append("&nbsp;<b>Cel.:</b>")
                                        Case 3
                                            sb.Append("&nbsp;<b>Fax:</b>")
                                        Case 4
                                            sb.Append("&nbsp;<b>PABX:</b>")
                                        Case 5
                                            sb.Append("&nbsp;<b>Obra:</b>")
                                    End Select
                                    sb.Append("(" & ds2.Tables(0).Rows(j).Item("DDD").Trim() & ") " & ds2.Tables(0).Rows(j).Item("TELEFONE").Trim())
                                Else
                                    sb.Append("&nbsp;")
                                End If
                            Else
                                sb.Append("&nbsp;")
                            End If
                            If ds2.Tables(0).Rows(j).Item("TipoTelefone2") > 0 Then
                                If (ds2.Tables(0).Rows(j).Item("DDDFAX").Trim() & "") <> "" And (ds2.Tables(0).Rows(j).Item("FAX").Trim() & "") <> "" Then
                                    Select Case ds2.Tables(0).Rows(j).Item("TipoTelefone2")
                                        Case 1
                                            sb.Append("<b>Tel.:</b>")
                                        Case 2
                                            sb.Append("&nbsp;<b>Cel.:</b>")
                                        Case 3
                                            sb.Append("&nbsp;<b>Fax:</b>")
                                        Case 4
                                            sb.Append("&nbsp;<b>PABX:</b>")
                                        Case 5
                                            sb.Append("&nbsp;<b>Obra:</b>")
                                    End Select
                                    sb.Append("(" & ds2.Tables(0).Rows(j).Item("DDDFAX").Trim() & ") " & ds2.Tables(0).Rows(j).Item("FAX").Trim() & "")
                                Else
                                    sb.Append("&nbsp;")
                                End If
                                If (ds2.Tables(0).Rows(j).Item("DDD2") & "").Trim() <> "" And (ds2.Tables(0).Rows(j).Item("TELEFONE2") & "").Trim() <> "" Then
                                    sb.Append("(" & ds2.Tables(0).Rows(j).Item("DDD2").Trim() & ") " & ds2.Tables(0).Rows(j).Item("TELEFONE2").Trim())
                                End If
                            Else
                                sb.Append("&nbsp;")
                            End If
                            sb.Append("<a class='f8Rel' href='mailto:" & ds2.Tables(0).Rows(j).Item("EMAIL") & "'><font class='f8Rel' > " & ds2.Tables(0).Rows(j).Item("EMAIL") & "</font></a>")
                            sb.Append(" </font></td></tr>")
                            'sb.Append("								<tr><td colspan=3 nowrap align=left nowrap><font class='f8Rel'   ><b>E-Mail:</b> " & ds2.Tables(0).Rows(j).Item("EMail") & "</font></td></tr>")
                        Next

                        sb.Append("	</table>")

                        sb.Append("</div>")
                    End If

                End If

                If i Mod 3 = 2 Then

                    sb.Append("   <div class='RodapeRelatorio'>")
                    sb.Append("    	<p style='text-align: center;'>www.itc.etc.br  - E-mail: itc@itc.etc.br<br>")
                    sb.Append("        Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>")
                    sb.Append("    </div>")

                    If blnQuebra Then sb.Append("</p>")
                    blnQuebra = True

                End If

            Next

            If i Mod 3 <> 0 Then

                sb.Append("   <div class='RodapeRelatorio'>")
                sb.Append("    	<p style='text-align: center;'>www.itc.etc.br  - E-mail: itc@itc.etc.br<br>")
                sb.Append("        Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>")
                sb.Append("    </div>")

                If blnQuebra Then sb.Append("</p>")

            End If

            sb.Append("</div>")

        End If


        If Viewstate("Tipo") = 2 Then
            sb.Append("				<div align=center>")
            If Viewstate("Pagina") > 1 Then
                sb.Append("		        <a href='RelatorioEmpresas.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Empresas") & "&P=" & Viewstate("Pagina") - 1 & "'><b>Anterior</b>&nbsp;&nbsp;</a>")
            Else
                sb.Append("				<b>Anterior</b>&nbsp;&nbsp;")
            End If
            If Viewstate("Pagina") < MaxPage Then
                sb.Append("			    <a href='RelatorioEmpresas.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Empresas") & "&P=" & Viewstate("Pagina") + 1 & "'><b>Próxima</b>&nbsp;&nbsp;</a>")
            Else
                sb.Append("				<b>Próxima</b>&nbsp;&nbsp;")
            End If
            sb.Append("				</div>")
        End If

        'sb.Append("</p>")

        CodigoHTML.Text = sb.ToString

    End Function

End Class
