<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MudaSenha.aspx.vb"  ValidateRequest="False" Inherits="ITC.MudaSenha"%>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();">
		<form id="frmCad" runat="server">
			<div id="Tudo">
	
				<uc1:top id="Top1" runat="server"></uc1:top>
				<br>
				<table id="tblDados" runat="server" width="100%">
					<tr>
						<td><center>
								<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="4">BEM 
										VINDO AO SISTEMA ITC</font></b>
								<br>
								<font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">Por 
									favor, nesse momento você precisa alterar sua senha para continuar utilizando o 
									sistema.</font></B></center>
							<br>
							<table style="WIDTH: 100%; HEIGHT: 120px" bgColor="#EBEBEB" border="0">
								<tr>
									<td style="WIDTH: 84px" noWrap align="right"><font class="f8"><br><b>Nome: </b></font>
									</td>
									<td style="WIDTH: 194px" noWrap align="left" width="194"><br><asp:label id="lblNome" Runat="server" CssClass="f8"></asp:label></td>
									<td noWrap align="right"><font class="f8"><br><b>Login: </b></font>
									</td>
									<td noWrap align="left" width="50%"><br><asp:label id="lblLogin" Runat="server" CssClass="f8"></asp:label></td>
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
				<asp:label id="lblMensagem" Runat="server" Font-Size="10" Font-Name="verdana" Font-Bold="True" ForeColor="#FF0000"></asp:label><br>
				<asp:literal id="ltjava" Runat="server"></asp:literal><br>
				<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape>
			</div> 
		</form>

		
	</body>
</HTML>
