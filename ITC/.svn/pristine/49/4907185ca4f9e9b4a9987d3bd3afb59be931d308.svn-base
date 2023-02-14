<%

	'**************************************************************
	'PÁGINA 	RESPONSÁVEL POR GERAR OS E-MAILS
	'TIPOS: 	1 - RELAÇÃO DE FOLLOW-UP'S PARA O DIA
	'		2 - E-MAIL DE PERDA DO CADASTRO
	'		3 - E-MAIL DE ADIÇÃO DE CADASTRO
	'		4 - FOLLOW-UP'S COM X DIAS SEM CONTATO
	'**************************************************************

	Dim cn, cmd, rs	
	Dim p_DiasSemContato, p_IdVendedor, p_IdAssociado, p_IdObraEmpresaAssociado
	Dim p_conString, p_TipoCad
	
	p_conString = "PROVIDER=SQLOLEDB;Server=127.0.0.1;uid=itc2;pwd=@#zaq3469;database=itc;"

	Response.Clear
	Response.Expires = -1
	Response.ExpiresAbsolute = Now() - 1
	
	p_IdVendedor  = Request("IdVendedor") & ""
	p_IdAssociado = Request("IdAssociado") & ""

	If Request("Tipo") = 1 Then 
	
	Response.Charset="ISO-8859-1"
		
	%>
		<html xmlns="http://www.w3.org/1999/xhtml">
		<head>
		<title>.: ITC.NET :. </title>
		<link href="http://www.xmsistemas.com.br/itc/css/global.css" rel="stylesheet" type="text/css" />
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
		</head>

		<body onload="vertical();horizontal();"  topmargin="2" leftmargin="0">
		<table width="101%" height="100%" border="0" cellpadding="0" cellspacing="0" ID="Table1">
		<tr>
			<td align="center" valign="top">
			<table width="750" border="0" cellspacing="0" cellpadding="0" ID="Table2">
			<tr>
				<td>
				<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table3">
					<tr>
						<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
						<img src="imagens/LogoITCNET3D.png" border="0">
						</td></tr></table>
		<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table4">
			<tr>
				<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
					<div class="bgCinza" style="height:20px; padding:4px 0 0 0">
						<div style="height:20px; width:20px; text-align:center; padding:8px 0 0 0; float:left;"><img src="imagens/marcador_titulo.gif" /></div>
						<div class="titulo11" style="height:20px; padding:4px 0 0 0">Relação de Follow-UP's</div>
						<div class="bgCinza1" style="height:1px;"><img src="imagens/spacer.gif"></div>
					</div>
					<div style="padding:0px 0 0 0px; text-align:left;" class="texto10">
					<%
					Set cn = Server.CreateObject("Adodb.Connection")
					cn.Open p_conString
					
					Set rs = cn.Execute("SP_SE_JOB_FOLLOWUP_AGENDADOS " & p_IdAssociado & "," & p_IdVendedor)
					If Not rs.EOF Then
					%>
						<P class="texto10">Follow-UP's agendados para o dia <%=rs("DATAAGENDA")%></P>
					<%
					End If
					%>
					</div>
					<div style="text-align:center;" class="texto10">
						<form name="form" method="get" action="demonstracao_detalhes.asp" target="detObras" ID="Form1">
						<%						
							Set rs = cn.Execute("SP_SE_JOB_FOLLOWUP_AGENDADOS " & p_IdAssociado & "," & p_IdVendedor)
							If Not rs.EOF Then
						%>
						
						<table width="725" border="0" cellspacing="0" cellpadding="0" ID="Table5">
							<tr>
								<td width="65"><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
								<td width="200"><img src="imagens/spacer.gif" width="200" height="1" border="0"></td>
							</tr>
							<tr class="bgCinza">
								<td class="bgCinza" colspan=3><div class="titulo11" style="height:22px; padding:4px 0 0 0" align=center>FOLLOW-UP'S DE ASSOCIADOS<br></div></td>
                        
							<tr class="bgCinza">
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>NOME DO ASSOCIADO</div></td>
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>DATA</div></td>
							</tr>
							<%
							Do Until rs.EOF
							%>
							<tr class="bgCinza1"><td colspan="7" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
								<tr style="height:20px; padding:4px 0px 4px 0px">
									<td class="texto10"><B><%=rs("RAZAOSOCIAL")%></B></td>
									<td class="texto10"><%=rs("DATA")%></td>
								</tr><tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr><tr><td colspan=3><br></td></tr>
		
							
							
					<%
					rs.MoveNext
					Loop 
					%>
					
					</table>

										
					<%
					End If
					Set rs = rs.NextRecordset
					If Not rs.EOF Then
					%>
						
						<table width="725" border="0" cellspacing="0" cellpadding="0" class="texto10" ID="Table27">
							<tr>
								<td width="65"><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
								<td width="200"><img src="imagens/spacer.gif" width="200" height="1" border="0"></td>
							</tr>
							<tr class="bgCinza">
								<td class="bgCinza" colspan=3><div class="titulo11" style="height:22px; padding:4px 0 0 0">FOLLOW-UP'S DE OBRAS<br></div></td>
                                                        </tr>
							<tr class="bgCinza">
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>NOME DA OBRA</div></td>
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>DATA</div></td>
							</tr>
							<%
							Do Until rs.EOF
							%>
							<tr class="bgCinza1"><td colspan="7" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
								<tr style="height:20px; padding:4px 0px 4px 0px">
									<td class="texto10"><B><%=rs("PROJETO")%></B></td>
									<td class="texto10"><%=rs("DATA")%></td>
								</tr><tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr><tr><td colspan=3><br></td></tr>
							
							
					<%
					rs.MoveNext
					Loop 
					%>
					
					</table>					
					
					<%
					End If
					
					Set rs = rs.NextRecordset
					
					If Not rs.EOF Then
						%>
						
						<table width="725" border="0" cellspacing="0" cellpadding="0" class="texto10" ID="Table28">
							<tr>
								<td width="65"><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
								<td width="200"><img src="imagens/spacer.gif" width="200" height="1" border="0"></td>
							</tr>
							<tr class="bgCinza">
								<td class="bgCinza" colspan=3><div class="titulo11" style="height:22px; padding:4px 0 0 0">FOLLOW-UP'S DE EMPRESAS<br></div></td>
                                                        </tr>
							<tr class="bgCinza">
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>NOME DA EMPRESA</div></td>
								<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0" colspan=3>DATA</div></td>
							</tr>
							<%
							Do Until rs.EOF
							%>
							<tr class="bgCinza1"><td colspan="7" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
								<tr style="height:20px; padding:4px 0px 4px 0px">
									<td class="texto10"><B><%=rs("RAZAOSOCIAL")%></B></td>
									<td class="texto10"><%=rs("DATA")%></td>
								</tr><tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr><tr><td colspan=3><br></td></tr>
					<%
					rs.MoveNext
					Loop %>
					
					</table>					
					
					<%
					End If
						
						rs.Close
						Set rs = Nothing
						
						cn.Close
						Set cn = Nothing
							
					%>
							<tr><td colspan="2"><img src="imagens/spacer.gif" width="725" height="10" border="0"></td></tr>
							<tr style="height:20px; padding:4px 0px 4px 0px">
								<td colspan="2" align="center"><table width="400" border="0" cellpadding="0" cellspacing="0" class="contentTit1" ID="Table6">
				</table>
				</td>
							</tr>
						</table>
						</form>
					</div>
				</div></td>
			</tr>
			<tr>
				<td><TABLE width="750" cellpadding="0" cellspacing="0" border="0" align="center" class="texto10" ID="Table7">
			<TR>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
			</TR>
			<TR>
				<TD colspan=2 align="center">Copyright &copy; 2008 - ITC-Net - Todos os Direitos Reservados</TD>
			</TR>
		</TABLE></td>
			</tr>
			</table>
			</td>
		</tr>
		</table>
		</body>
		</html>
	<%
	ElseIf Request("Tipo") = 2 Then
	
		p_TipoCad				 = Request("TipoCad") '1-ASSOCIADO 2-EMPRESA 3-OBRA
		p_IdObraEmpresaAssociado = Request("IdOEA") 'ID DO ASSOCIADO, OBRA OU EMPRESA
	
	%>
		<html xmlns="http://www.w3.org/1999/xhtml">
		<head>
		<title>.: ITC.NET :. </title>
		<link href="http://www.xmsistemas.com.br/itc/css/global.css" rel="stylesheet" type="text/css" />
		</head>

		<body onload="vertical();horizontal();"  topmargin="2" leftmargin="0">
		<table width="101%" height="100%" border="0" cellpadding="0" cellspacing="0" ID="Table8">
		<tr>
			<td align="center" valign="top">
			<table width="750" border="0" cellspacing="0" cellpadding="0" ID="Table9">
			<tr>
				<td>
				<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table10">
					<tr>
						<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
						<img src="imagens/LogoITCNET3D.png" border="0">
						</td></tr></table>
		<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table11">
			<tr>
				<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
					<div class="bgCinza" style="height:20px; padding:4px 0 0 0">
						<div style="height:20px; width:20px; text-align:center; padding:8px 0 0 0; float:left;"><img src="imagens/marcador_titulo.gif" /></div>
						<div class="titulo11" style="height:20px; padding:4px 0 0 0">Relação de Follow-UP's</div>
						<div class="bgCinza1" style="height:1px;"><img src="imagens/spacer.gif"></div>
					</div>
					<div style="padding:0px 0 0 0px; text-align:left;" class="texto10">
						<%
						
						Set cn = Server.CreateObject("Adodb.Connection")
						cn.Open p_conString
						
						Select Case p_TipoCad
							Case "1" 'ASSOCIADOS
								
								Set rs = cn.Execute("SP_SE_ASSOCIADO " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro do associado <%=rs("RAZAOSOCIAL")%> foi alterado e não mais lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing

							Case "2" 'EMPRESAS
							
								Set rs = cn.Execute("SP_SE_EMPRESA " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro da empresa <%=rs("RAZAOSOCIAL")%> foi alterado e não mais lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing
								
							Case "3" 'OBRAS
							
								Set rs = cn.Execute("SP_SE_OBRA " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro da obra <%=rs("PROJETO")%> foi alterado e não mais lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing
								
						End Select
												
						cn.Close
						Set cn = Nothing
						
						%>
					</div>
						</table>
						</form>
					</div>
				</div></td>
			</tr>
			<tr>
				<td><TABLE width="750" cellpadding="0" cellspacing="0" border="0" align="center" class="texto10" ID="Table14">
			<TR>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
			</TR>
			<TR>
				<TD colspan=2 align="center">Copyright &copy; 2008 - ITC-Net - Todos os Direitos Reservados</TD>
			</TR>
		</TABLE></td>
			</tr>
			</table>
			</td>
		</tr>
		</table>
		</body>
		</html>	
	<%
	ElseIf Request("Tipo") = 3 Then
	%>
		<html xmlns="http://www.w3.org/1999/xhtml">
		<head>
		<title>.: ITC.NET :. </title>
		<link href="http://www.xmsistemas.com.br/itc/css/global.css" rel="stylesheet" type="text/css" />
		</head>

		<body onload="vertical();horizontal();"  topmargin="2" leftmargin="0">
		<table width="101%" height="100%" border="0" cellpadding="0" cellspacing="0" ID="Table12">
		<tr>
			<td align="center" valign="top">
			<table width="750" border="0" cellspacing="0" cellpadding="0" ID="Table13">
			<tr>
				<td>
				<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table15">
					<tr>
						<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
						<img src="imagens/LogoITCNET3D.png" border="0">
						</td></tr></table>
		<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table16">
			<tr>
				<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
					<div class="bgCinza" style="height:20px; padding:4px 0 0 0">
						<div style="height:20px; width:20px; text-align:center; padding:8px 0 0 0; float:left;"><img src="imagens/marcador_titulo.gif" /></div>
						<div class="titulo11" style="height:20px; padding:4px 0 0 0">Relação de Follow-UP's</div>
						<div class="bgCinza1" style="height:1px;"><img src="imagens/spacer.gif"></div>
					</div>
					<div style="padding:0px 0 0 0px; text-align:left;" class="texto10">
						<%
						
						Set cn = Server.CreateObject("Adodb.Connection")
						cn.Open p_conString
						
						Select Case p_TipoCad
							Case "1" 'ASSOCIADOS
								
								Set rs = cn.Execute("SP_SE_ASSOCIADO " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro do associado <%=rs("RAZAOSOCIAL")%> foi alterado e agora lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing

							Case "2" 'EMPRESAS
							
								Set rs = cn.Execute("SP_SE_EMPRESA " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro da empresa <%=rs("RAZAOSOCIAL")%> foi alterado e agora lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing
								
							Case "3" 'OBRAS
							
								Set rs = cn.Execute("SP_SE_OBRA " & p_IdObraEmpresaAssociado)
								If not rs.EOF Then
								%>
								<P class="texto10">O cadastro da obra <%=rs("PROJETO")%> foi alterado e agora lhe pertence</P>
								<%
								End If
								rs.Close
								Set rs = Nothing
								
						End Select
												
						cn.Close
						Set cn = Nothing
						
						%>
					</div>
						</table>
						</form>
					</div>
				</div></td>
			</tr>
			<tr>
				<td><TABLE width="750" cellpadding="0" cellspacing="0" border="0" align="center" class="texto10" ID="Table17">
			<TR>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
			</TR>
			<TR>
				<TD colspan=2 align="center">Copyright &copy; 2008 - ITC-Net - Todos os Direitos Reservados</TD>
			</TR>
		</TABLE></td>
			</tr>
			</table>
			</td>
		</tr>
		</table>
		</body>
		</html>	
	<%
	ElseIf Request("Tipo") = 4 Then 
	%>
		<html xmlns="http://www.w3.org/1999/xhtml">
		<head>
		<title>.: ITC.NET :. </title>
		<link href="http://www.xmsistemas.com.br/itc/css/global.css" rel="stylesheet" type="text/css" />
		</head>

		<body onload="vertical();horizontal();"  topmargin="2" leftmargin="0">
		<table width="101%" height="100%" border="0" cellpadding="0" cellspacing="0" ID="Table18">
		<tr>
			<td align="center" valign="top">
			<table width="750" border="0" cellspacing="0" cellpadding="0" ID="Table19">
			<tr>
				<td>
				<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table20">
					<tr>
						<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
						<img src="imagens/LogoITCNET3D.png" border="0">
						</td></tr></table>
		<TABLE width="750" cellpadding="0" cellspacing="1" border="0" align="center" ID="Table21">
			<tr>
				<td align="left" valign="top" class="texto10" style= "padding: 10px;" >
					<div class="bgCinza" style="height:20px; padding:4px 0 0 0">
						<div style="height:20px; width:20px; text-align:center; padding:8px 0 0 0; float:left;"><img src="imagens/marcador_titulo.gif" /></div>
						<div class="titulo11" style="height:20px; padding:4px 0 0 0">Relação de Follow-UP's</div>
						<div class="bgCinza1" style="height:1px;"><img src="imagens/spacer.gif"></div>
					</div>
					<div style="padding:0px 0 0 0px; text-align:left;" class="texto10">
						<P class="texto10">RELAÇÃO DE FOLLOW-UP'S COM 15 DIAS OU MAIS SEM CONTATO.</P>
					</div>
					<div style="text-align:center;" class="texto10">
						<form name="form" method="get" action="demonstracao_detalhes.asp" target="detObras" ID="Form2">
						
							<%
							Set cn = Server.CreateObject("Adodb.Connection")
							cn.Open p_conString
							
							Dim blnEmpresa, blnObra, blnAssociado
							blnEmpresa		= false
							blnObra			= false
							blnAssociado	= false
							
							Set rs = cn.Execute("SP_SE_JOB_FOLLOWUP_SEMCONTATO " & p_IdAssociado & "," & p_IdVendedor)
							
							if Not rs Is Nothing Then
								If Not rs.EOF Then
									%>
									<table width="725" border="0" cellspacing="0" cellpadding="0" class="texto10" ID="Table22">
										<tr>
											<td align=center colspan=3 height=20>&nbsp;</td>
										</tr>
										<tr>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
										</tr>
										<tr class="bgCinza">
											<td align=center colspan=3 class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">RELAÇÃO DE ASSOCIADOS</div></td>
										</tr>
										<tr class="bgCinza1"><td colspan="7" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr class="bgCinza">
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">NOME DO ASSOCIADO</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA AGENDA</div></td>
										</tr>
									<%
									Do Until rs.EOF
									%>
										<tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr style="height:20px; padding:4px 0px 4px 0px">
											<td class="texto10"><B><%=rs("RazaoSocial")%></B></td>
											<td class="texto10"><%=rs("Data")%></td>
											<td class="texto10"><%=rs("DataAgenda")%></td>
										</tr>
										<tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
									<%
										rs.MoveNext
									Loop
								End If
							End If
							
							Set rs = rs.NextRecordset
										
							if Not rs Is Nothing Then
								If Not rs.EOF Then
									%>
									<table width="725" border="0" cellspacing="0" cellpadding="0" class="texto10" ID="Table25">
										<tr>
											<td align=center colspan=4 height=20>&nbsp;</td>
										</tr>
										<tr>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
										</tr>
										<tr class="bgCinza">
											<td align=center colspan=4 class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">RELAÇÃO DE OBRAS</div></td>
										</tr>
										<tr class="bgCinza1"><td colspan="4" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr class="bgCinza">
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">CÓDIGO</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">NOME DA OBRA</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA AGENDA</div></td>
										</tr>
									<%
									Do Until rs.EOF
									%>
										<tr class="bgCinza1"><td colspan="4" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr style="height:20px; padding:4px 0px 4px 0px">
											<td class="texto10"><B><%=rs("CodigoAntigo")%></B></td>
											<td class="texto10"><B><%=rs("Projeto")%></B></td>
											<td class="texto10"><%=rs("Data")%></td>
											<td class="texto10"><%=rs("DataAgenda")%></td>
										</tr>
										<tr class="bgCinza1"><td colspan="4" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
									<%
										rs.MoveNext
									Loop
								End If
							End If
								
							Set rs = rs.NextRecordset
								
							if Not rs Is Nothing Then
								If Not rs.EOF Then
									%>
									<table width="725" border="0" cellspacing="0" cellpadding="0" class="texto10" ID="Table26">
										<tr>
											<td align=center colspan=3 height=20>&nbsp;</td>
										</tr>
										<tr>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
											<td><img src="imagens/spacer.gif" width="65" height="1" border="0"></td>
										</tr>
										<tr class="bgCinza">
											<td align=center colspan=3 class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">RELAÇÃO DE EMPRESAS</div></td>
										</tr>
										<tr class="bgCinza1"><td colspan="7" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr class="bgCinza">
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">NOME DA EMPRESA</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA</div></td>
											<td class="bgCinza"><div class="titulo11" style="height:20px; padding:4px 0 0 0">DATA AGENDA</div></td>
										</tr>
									<%
									Do Until rs.EOF
									%>
										<tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
										<tr style="height:20px; padding:4px 0px 4px 0px">
											<td class="texto10"><B><%=rs("RazaoSocial")%></B></td>
											<td class="texto10"><%=rs("Data")%></td>
											<td class="texto10"><%=rs("DataAgenda")%></td>
										</tr>
										<tr class="bgCinza1"><td colspan="3" class="bgCinza1" height="1"><img src="imagens/spacer.gif" width="725" height="1" border="0"></td></tr>
									<%
										rs.MoveNext
									Loop
								End If
							End If
							
							rs.Close							
							Set rs = Nothing
							
							cn.Close
							Set cn = Nothing
							
							%>
							<tr><td colspan="3"><img src="imagens/spacer.gif" width="725" height="10" border="0"></td></tr>
							<tr style="height:20px; padding:4px 0px 4px 0px">
								<td colspan="3" align="center"><table width="400" border="0" cellpadding="0" cellspacing="0" class="contentTit1" ID="Table23">
				</table></td>
							</tr>
						</table>
						</form>
					</div>
				</div></td>
			</tr>
			<tr>
				<td><TABLE width="750" cellpadding="0" cellspacing="0" border="0" align="center" class="texto10" ID="Table24">
			<TR>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
				<TD width="375"><IMG src="imagens/spacer.gif" width="375" height="5" border="0"></TD>
			</TR>
			<TR>
				<TD colspan=2 align="center">Copyright &copy; 2008 - ITC-Net - Todos os Direitos Reservados</TD>
			</TR>
		</TABLE></td>
			</tr>
			</table>
			</td>
		</tr>
		</table>
		</body>
		</html>
	<%
	End If
	%>
