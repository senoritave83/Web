<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MudaSenha.aspx.vb" Inherits="xmlinkwm.MudaSenha" %>
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
					<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">Cadastro 
							de senha</font></b>&nbsp;
					<br>
					<font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="2">Por 
						favor preencha os dados abaixo:</font></B>
					<br>
					<br>
					<table style="WIDTH: 626px; HEIGHT: 120px" width="626" bgColor="#f7f7d8" border="0">
						<tr>
							<td style="WIDTH: 116px" noWrap align="right"><font face="Verdana" size="2"><b>Nome: </b>
								</font>
							</td>
							<td style="WIDTH: 179px" noWrap align="left" width="179"><asp:label id="lblNome" Runat="server" Font-Size="10" Font-Name="verdana"></asp:label></td>
							<td noWrap align="right"><font face="Verdana" size="2"><b>Login: </b></font>
							</td>
							<td noWrap align="left" width="50%"><asp:label id="lblLogin" Runat="server" Font-Size="10" Font-Name="verdana"></asp:label></td>
						</tr>
						<tr runat="server" id="rowOldSenha">
							<td style="WIDTH: 116px" align="right"><font face="Verdana" size="2"><b> Senha: </b></font>
							</td>
							<td colspan="3" style="WIDTH: 194px" align="left"><asp:textbox id="TxtOldSenha" Width="128" Runat="server" TextMode="Password"></asp:textbox></td>
						</tr>
						<tr runat="server" id="rowsenha">
							<td style="WIDTH: 116px" align="right"><font face="Verdana" size="2"><b>Nova Senha: </b>
								</font>
							</td>
							<td style="WIDTH: 179px" align="left"><asp:textbox id="txtSenha" Width="128" Runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="req1" Runat="server" ControlToValidate="txtSenha" ErrorMessage="*"></asp:requiredfieldvalidator></td>
							<td noWrap align="right"><font face="Verdana" size="2"><b>Confirme a nova senha: </b></font>
							</td>
							<td align="left"><asp:textbox id="txtSenhaConf" Width="128" Runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" Runat="server" ControlToValidate="txtSenhaConf" ErrorMessage="*"></asp:requiredfieldvalidator></td>
						</tr>
						<tr>
							<td align="middle" colSpan="4"><asp:comparevalidator id="comp1" Runat="server" ControlToValidate="txtSenha" ErrorMessage="*" ControlToCompare="txtSenhaConf"></asp:comparevalidator></td>
						</tr>
						<tr>
							<td align="middle" colSpan="4"><asp:button id="btnAlterarSenha" Runat="server" Text="Gravar senha"></asp:button></td>
						</tr>
					</table>
					<br>
					<asp:label id="lblMensagem" Runat="server" Font-Size="10" Font-Name="verdana" Font-Bold="True" ForeColor="#FF0000"></asp:label><br>
					<asp:literal id="ltjava" Runat="server"></asp:literal><br>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body>
</html> 
