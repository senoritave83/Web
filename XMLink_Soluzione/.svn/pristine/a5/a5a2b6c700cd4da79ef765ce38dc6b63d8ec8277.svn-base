<%@ Page Language="vb" AutoEventWireup="false" Codebehind="exportacao.aspx.vb" Inherits="xmlinkwm.exportacao"%>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
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
						<table height="100%" width="730">
							<tr vAlign="middle" height="60">
								<td>
									<uc1:titulo id="Titulo1" runat="server" Titulo="Exportação de dados" Descricao="Exporte os dados dos pedidos enviados pelos seus vendedores ao XMLink" imagem="imagens/exportar.gif"></uc1:titulo>
								</td>
							</tr>
							<tr vAlign="top" height="100%">
								<td>
									<table width="100%" class='fundo'>
										<tr>
											<td width=25%>
												<input class='Botao' type="button" name='btnExportar' id='btnExportar' runat=server onclick='window.open("exportacaodet.aspx", "Exportacao", "fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=no,resizable=no,directories=no,location=no,width=400,height=250");' value='Gerar Arquivo' title='Exportar os Pedidos armazenados no XMLink'>
											</td>
											<td>&nbsp;</td>
											<td align="middle" width="25%">
												<input class="Botao" onclick='location.href="configuracoes.aspx";' type="button" value="Voltar" title='Voltar para a tela de configurações'>
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
		<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
