<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MudaSenha.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.MudaSenha" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#f7f7d8">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="middle">
					<form id="frmCad" runat="server">
						<table id="tblDados" runat="server">
							<tr>
								<td><center>
										<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">BEM 
												VINDO AO SISTEMA ITC</font></b>
										<br>
										<font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="2">Por 
											favor, nesse momento você precisa alterar sua senha para continuar utilizando o 
											sistema.</font></B></center>
									<br>
									<br>
									<table style="WIDTH: 626px; HEIGHT: 120px" width="626" bgColor="#f7f7d8" border="0">
										<tr>
											<td style="WIDTH: 84px" noWrap align="right"><font class="f8"><b>Nome: </b></font>
											</td>
											<td style="WIDTH: 194px" noWrap align="left" width="194"><asp:label id="lblNome" Runat="server" CssClass="f8"></asp:label></td>
											<td noWrap align="right"><font class="f8"><b>Login: </b></font>
											</td>
											<td noWrap align="left" width="50%"><asp:label id="lblLogin" Runat="server" CssClass="f8"></asp:label></td>
										</tr>
										<tr>
											<td style="WIDTH: 84px" align="right"><font class="f8"><b>Senha: </b></font>
											</td>
											<td style="WIDTH: 194px" align="left"><asp:textbox id="txtSenha" MaxLength=10 Width="128" Runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="req1" Runat="server" ControlToValidate="txtSenha" CssClass="f8" ErrorMessage="*"></asp:requiredfieldvalidator></td>
											<td noWrap align="right"><font class="f8"><b>Confirmar Senha: </b></font>
											</td>
											<td align="left"><asp:textbox id="txtSenhaConf" Width="128" MaxLength=10 Runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" Runat="server" ControlToValidate="txtSenhaConf" CssClass="f8" ErrorMessage="*"></asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td align="middle" colSpan="4"><asp:comparevalidator CssClass="f8" id="comp1" Operator="Equal" Display="Static" Runat="server" ControlToValidate="txtSenhaConf" ErrorMessage="As senhas não conferem" ControlToCompare="txtSenha"></asp:comparevalidator></td>
										</tr>
										<tr>
											<td align="middle" colSpan="4"><asp:button CssClass="f8" id="btnAlterarSenha" Runat="server" Text="Alterar Senha"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>
						<asp:label id="lblMensagem" Runat="server" Font-Size="10" Font-Name="verdana" Font-Bold="True" ForeColor="#FF0000"></asp:label><br>
						<asp:literal id="ltjava" Runat="server"></asp:literal><br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:rodape Id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
