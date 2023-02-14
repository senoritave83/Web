<%@ Page Language="vb" AutoEventWireup="false" Codebehind="esqueci.aspx.vb" Inherits="xmlinkwm.esqueci" %>
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
					<asp:Panel ID='pnlStart' Runat="server">
						<table width="730">
							<tr valign="middle" height="60">
								<td>
									<b class='TextHeader'>Recuperar senha</b>
								</td>
								<td align="right"><img src='imagens/e-dispatch_small.gif'></td>
							</tr>
						</table>
						<table width="730">
							<tr valign="top" height="100%">
								<TD class="TextDefault" align="right">Favor digitar o CNPJ da sua empresa:<BR>
									<asp:TextBox id="txtCNPJ" onkeydown="return fncOnlyInteger();" onblur="fncFormatText(this);" onfocus="fncCleanFormat(this);" runat="server" maxlength="14"></asp:TextBox>
									<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator1" Runat="server" ControlToValidate="txtCNPJ" ErrorMessage="CNPJ obrigatório" Display="None"></ASP:REQUIREDFIELDVALIDATOR>
									<ASP:CUSTOMVALIDATOR id="val_txtCNPJCPF_0" runat="server" ControlToValidate="txtCNPJ" ErrorMessage="CNPJ Inválido" Display="None" ClientValidationFunction="ValidateCPF"></ASP:CUSTOMVALIDATOR></TD>
								<TD vAlign="bottom">
									<asp:ImageButton id="btnOk" runat="server" ImageUrl="imagens/go.gif"></asp:ImageButton></TD>
							</tr>
						</table>
						<asp:ValidationSummary id="valSumary" Runat="server"></asp:ValidationSummary>
					</asp:Panel>
					<asp:Panel ID="pnlMessage" Runat="server" Visible="False">
						<table height="100%" width="730">
							<tr valign="middle">
								<td>
									<b class='TextHeader'>Recuperar senha</b>
								</td>
								<td align="right"><img src='imagens/e-dispatch_small.gif'></td>
							</tr>
							<TR vAlign="top">
								<TD class="TextDefault" align="right">
									<ASP:LABEL id="lblMessage" Runat="server" cssclass="TextDefault"></ASP:LABEL></TD>
							</TR>
						</table>
						<SCRIPT>
													setTimeout('window.location.href="default.aspx"', 2000);
						</SCRIPT>
					</asp:Panel>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 
