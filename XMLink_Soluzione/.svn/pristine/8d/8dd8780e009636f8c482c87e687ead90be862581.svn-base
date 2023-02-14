<%@ Page Language="vb" AutoEventWireup="false" Codebehind="gravado.aspx.vb" Inherits="xmlinkwm.gravado" %>
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
					<table width="50%" bgcolor="DimGray">
						<tr class='fundo'>
							<td>
								<table width="100%" cellpadding="3" cellspacing="0">
									<tr>
										<td width="31" valign="top"><img src='imagens/info.gif'></td>
										<td align="center">
											<b><font Class="titulo">Dados gravados com sucesso!</font></b>
										</td>
										<td width="31">&nbsp;</td>
									</tr>
									<tr>
										<td colspan="3" align="center">
											<asp:Button Runat="server" ID="btnVoltar" Text=' OK ' CssClass="Botao" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<script>
												setTimeout('window.location.href="<%Response.Write(Viewstate("Volta"))%>";', 2000);
					</script>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 
