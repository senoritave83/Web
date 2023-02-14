<%@ Page Language="vb" AutoEventWireup="false" Codebehind="recados.aspx.vb" Inherits="xmlinkwm.recados" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<HTML>
<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
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
				<form id="Form1" method="post" runat="server">
					<script>
													function checkSize()
														{
														var i = document.Form1.txtMensagem.value.length;
														if (i < 120)
															{
															spSize.innerHTML = 120 - i;
															return true;
															}
														else
															{
															spSize.innerHTML = 0;
															if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39  && event.keyCode != 38  && event.keyCode != 37  && event.keyCode != 40)
																return false;
															}
														}
													function Trim()
														{if(document.Form1.txtMensagem.value.length > 120){
															document.Form1.txtMensagem.value = document.Form1.txtMensagem.value.substring(0, 120);}}
					</script>
					<table height="100%" width="730">
						<tr vAlign="center" height="60">
							<td>
								<uc1:titulo id="Titulo1" runat="server" Titulo="Histórico de Recados Enviados" Descricao="Envie mensagens de Texto informativas para os seus funcionários – Sem possibilidade de respostas" imagem="imagens/recados.gif"></uc1:titulo>
							</td>
						</tr>
						<tr vAlign="top" height="100%">
							<td>
								<table height="100%" cellPadding="1" width="100%" bgColor="dimgray">
									<tr vAlign="top" bgColor="white">
										<td><asp:datagrid id="dtgGrid" AllowPaging="True" PageSize="10" OnPageIndexChanged="DataGrid_Page" AllowCustomPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%" Runat="server">
												<HeaderStyle ForeColor="White" CssClass='Header' />
												<ItemStyle CssClass="GridItem" />
												<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
												<Columns>
													<asp:BoundColumn DataField='rec_Enviado_dtm' HeaderText='Enviado' DataFormatString='{0:d}' ItemStyle-Width="60" />
													<asp:BoundColumn DataField='rec_Destinatario_chr' HeaderText='Destinatário' ItemStyle-Width="140" />
													<asp:BoundColumn DataField='rec_Recado_chr' HeaderText='Mensagem' />
													<asp:BoundColumn DataField='usu_Usuario_chr' HeaderText='Enviado por' ItemStyle-Width="140" />
												</Columns>
											</asp:datagrid></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr vAlign="top">
							<td>
								<table cellPadding="1" width="100%">
									<tr vAlign="top" bgColor="white">
										<td>
											<table width="100%" border="0">
												<tr height="40">
													<td><font class="TextDefault">Selecione o Responsável ou Grupo</font><br>
														<asp:dropdownlist id="cboDestinatario" runat="server" AutoPostBack="True" DataTextField="NOME" DataValueField="IDDEST"></asp:dropdownlist>
														<img src='imagens/help.gif' alt='Responsável ou Grupo que irá receber o Recado Digital' align="absBottom">
													</td>
												</tr>
												<tr vAlign="top" bgColor="white" height="100%">
													<td><font class="TextDefault">Mensagem</font><br>
														<asp:textbox id="txtMensagem" TextMode="MultiLine" Runat="server" Width="100%" Rows="8" onKeyDown='return checkSize();' onBlur='Trim();'></asp:textbox></td>
												</tr>
												<tr>
													<td colspan="3">
														<font class="TextDefault" style='COLOR:gray'>Caracteres disponíveis: <i>
																<span id='spSize'>120</span></i></font>
													</td>
												</tr>
											</table>
											<table width="100%">
												<tr>
													<td class="TextDefault"><b class="TextDefault"><i>Limite Máximo: 120 caracteres.</i></b>
														<asp:label id="lblMensagem" Runat="server" CssClass="TextDefault" Visible="False">Não foi possível enviar o recado!</asp:label></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td height="60"><asp:literal id="ltrMessage" Runat="server"></asp:literal><br>
								<table width="100%" class='fundo'>
									<tr>
										<td align=left width="50%"></td>
										<td align="middle" width="25%"><asp:button id="btnEnviar" Runat="server" Text="Enviar" Width="80%" CssClass="Botao"></asp:button></td>
										<td align="middle" width="25%"><input class="Botao" style="WIDTH: 80%" onclick='location.href="principal.aspx";' type="button" value="Voltar"></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td valign="top">
								<ul class='TextDefault'>
									<li>
										<b><asp:Literal id="btnEnviarEmail" Runat="server"></asp:Literal></b>
									</li>
									<br>
									<li>
										<b>Envio de Recado Digital:</b> Envia pequenas observações diretamente para um 
										responsável ou Grupo. Os Recados Digitais não aceitam respostas.
									</li>
								</ul>
							</td>
						</tr>
					</table>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 
