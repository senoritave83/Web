<%@ Page Language="vb" AutoEventWireup="false" Codebehind="visita.aspx.vb" Inherits="xmlinkwm.visita"%>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<HTML>
	<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
	<script language='javascript'>
	
		function ___GetForm()
		{
			var theform;
			if (window.navigator.appName.toLowerCase().indexOf("microsoft") > -1) {
				theform = document.frmCad;
			}
			else {
				theform = document.forms["frmCad"];
			}

			return theform;

		}
		function ___DelImages()
		{
		
			var p_Images = '';
			for (var i=0;i<___GetForm().elements.length;i++)
			{
				var e = ___GetForm().elements[i];
				var strId = e.id;
				if (e.type=='checkbox' && strId == 'chkSelImages')
				{
						if(e.checked == true)
							p_Images += e.arquivo + '\n';
						
				}
			}
			if(p_Images != '')
			{
				if(confirm('Os arquivo abaixo foram selecionados:\n' + p_Images + '\nConfirma a exclusão ?')==true)
					return true
			}
			return false;		
		}
		function ___XMMOUSEOVER(src) {
			if (!src.contains(event.fromElement))
				src.style.cursor = 'hand';
		} 
		function ___XMMOUSEOUT(src) 
		{
			if (!src.contains(event.toElement)) 
				src.style.cursor = 'default';
		}
		function ___XMOPENWINDOW(___IMAGE)
		{
			var win = window.open(___IMAGE, 'FOTO_PROJETO', 'width=1000, height=800, scrollbars=yes')
		}
		</script>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<!-- #INCLUDE FILE='inc/inc_top.ascx' -->
		<table width="100%" cellpadding="0" cellspacing="0" height="100%">
			<tr>
				<td>
					<uc1:inc_menu id="Inc_menu1" runat="server"></uc1:inc_menu>
				</td>
				<td class='BackgrStripes' rowspan="2">&nbsp;</td>
			</tr>
			<tr height="100%">
				<td width="750" valign="top" align="middle">
					<!-- INICIO CONTEUDO -->
						<script language='javascript'>

							function fncAbreMapa()
							{
								var posCli = "";
								if (document.getElementById('latCli').value != 0 && document.getElementById('latCli').value != '')
									posCli = "&lat2=" + document.getElementById('latCli').value + "&lon2=" + document.getElementById('lonCli').value;
								
								var wh = window.open("http://www.xmwap.com.br/xmlinkwm/mapa.aspx?lat=<%=lblLatitudeInicio.Text%>&lon=<%=lblLongitudeInicio.Text%>" + posCli, "mapa", "width=600, height=300, toolbars=no")	;
								wh.focus();
							}
							
						</script>
						<form id="Form1" method="post" runat="server">
							<table height="100%" width="730">
								<tr vAlign="center">
									<td height="60">
										<uc1:titulo id="Titulo1" runat="server" Titulo="Detalhes da Visita" Descricao="Visualize as visitas enviadas para o XMLink pelos seus vendedores" imagem="imagens/pedidos.gif"></uc1:titulo>
									</td>
								</tr>
								<tr vAlign="top">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray">
											<tr>
												<td>
													<table width=100% height=40 cellpadding=0 cellspacing=0>
														<tr>
															<td>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=40>
																	<tr class='fundo'>
																		<td height="40">
																			<font face=Verdana size='2'><b>
																			Visita nº:<asp:Label Runat="server" ID='lblNumero'></asp:Label>
																			</b></font>
																		</td>
																		<td align="right" class='TextDefault' width=30%>
																			Data da Visita: <br><asp:Label Runat="server" ID="lblDataVisita" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																</table> 
															</td>
														</tr>
														<tr>
															<td>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=100%>
																	<tr>
																		<td class=TextDefault>
																			Data de Início: <br><asp:Label Runat="server" ID="lblDataInicio" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Data de Fim: <asp:Label Runat="server" ID="lblDataFinal" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td class=TextDefault>
																			Cliente: <asp:Label Runat="server" ID="lblCliente" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Vendedor: <asp:Label Runat="server" ID="lblVendedor" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id="rowPosicaoInicial">
																		<td class=TextDefault>
																			Latitude Inicio: <asp:Label Runat="server" ID="lblLatitudeInicio" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Longitude Inicio: <asp:Label Runat="server" ID="lblLongitudeInicio" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id="rowPosicaoFinal">																		
																		<td class=TextDefault>
																			Latitude Final: <asp:Label Runat="server" ID="lblLatitudeFinal" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>																	
																		<td class=TextDefault>
																			Longitude Final: <asp:Label Runat="server" ID="lblLongitudeFinal" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id="rowMostraMapa">
																		<td class='TextDefault'>
																			<input type='button' name='InputAbreMapa' value='Ver localização no mapa' onclick='fncAbreMapa()' style='WIDTH:152px' class="Botao">
																			<asp:Image Runat=server ImageUrl="imagens\Gobe1.png" ID="globe"></asp:Image>
																		</td>
																		<td class='TextDefault'>
																			<input type='button' name='InputAbreMapa' value='Ver localização no mapa' onclick='fncAbreMapa()' style='WIDTH:152px' class="Botao">
																			<asp:Image Runat=server ImageUrl="imagens\Gobe1.png" ID="Image1"></asp:Image>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table> 
												
													
												</td>
											</tr>
										</table>
										<br>
										<span class=TextHeader>Relação de Fotos</SPAN><BR>
										<asp:datalist RepeatColumns="6" RepeatDirection="Horizontal" DataKeyField="vcf_Arquivo_chr" ID="rptImages" runat="server">
											<HeaderTemplate></HeaderTemplate>
											<ItemTemplate>
												<table width='150' height='130'>
												<tr>
													<td>
														<table width=100 height='130'>
															<tr><td width=100 height=100><img onmouseover="___XMMOUSEOVER(this);" onmouseout="___XMMOUSEOUT(this)" onclick="___XMOPENWINDOW('foto.aspx?img=<%# DataBinder.Eval(Container.DataItem, "vcf_Arquivo_chr")%>');" src='fotosthumb.aspx?width=100&filename=<%# DataBinder.Eval(Container.DataItem, "vcf_Arquivo_chr")%>' border='0' alt=''></td></tr>
															<tr><td Class="TextDefault"><%# DataBinder.Eval(Container.DataItem, "vcf_Classificacao_chr")%></td></tr>
														</table>
													</td>
												</tr>
												</table>
											</ItemTemplate>
											<FooterTemplate></FooterTemplate>
										</asp:datalist>
									</td>
								</tr>
								<tr valign="top">
									<td height="60">
										<table width="100%" class='fundo'>
											<tr>
												<td>&nbsp;</td>
												<td>&nbsp;</td>
												<td>&nbsp;</td>
												<td width="25%">
													<input type="button" class="Botao" value=" Voltar " onclick='location.href="visitas.aspx"'>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</form>
					<!-- FIM CONTEUDO -->
				</td>
			</tr>
		</table>
		<input type="hidden" runat="server" id="latCli" value="" NAME="latCli"/>
		<input type="hidden" runat="server" id="lonCli" value="" NAME="lonCli"/>
		<!-- HTML Alterado-->
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
