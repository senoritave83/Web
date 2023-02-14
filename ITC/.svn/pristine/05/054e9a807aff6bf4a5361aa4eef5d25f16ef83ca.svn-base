<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuariosDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.UsuariosDet"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="Form1" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Usuários</h3>
				<br class="clear">
				<table width="100%" align="center" BorderWidth="0" bgcolor="#efefef">
					<tr bgcolor="#003c6e">
						<td align="center" colspan="2" Width="100%"><h3>Dados Cadastrais</h3>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Código</td>
						<td align="left">
							<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Nome</td>
						<td align="left">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Login</td>
						<td align="left">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtLogin" MaxLength="20" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Mail</td>
						<td align="left">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator4" Runat="server" ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Empresa</td>
						<td align="left" Width="60%">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmpresa" MaxLength="50" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtEmpresa"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Cargo</td>
						<td align="left" Width="60%">
							<uc1:ComboBox id="cboIdCargo" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Tipo de Usuário</td>
						<td align="left" Width="60%">
							<uc1:ComboBox id="cboTipoUsuario" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Situação</td>
						<td align="left" Width="60%">
							<uc1:ComboBox id="cboIdSituacao" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td colspan="2">&nbsp;</td>
					</tr>
					<tr>
						<td colspan="2" align="center">
							<table width="100%">
								<tr align="center">
									<td width="10%">
										&nbsp;
									</td>
									<td width="32%" align="center">
										<asp:Button CssClass="f8" ID="btnAlterarSenha" Runat="server" Text="Redefinir Senha"></asp:Button>
									</td>
									<td width="2%">&nbsp;</td>
									<td width="32%" align="center">
										<asp:Button CssClass="f8" ID="btnRedefinirSenha" Runat="server" Text="Renovar Senha"></asp:Button>
									</td>
									<td width="2%">&nbsp;</td>
									<td width="32%" align="center">
										<asp:Button CssClass="f8" ID="btnVoltar" Runat="server" text="Voltar"></asp:Button>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<br>
				<br>
		</form>
		</TD></TR></TABLE>
		<asp:Literal Runat="server" ID="ltJavaScriptAlteraSenha" Text=""></asp:Literal>
		<uc1:rodape id="Rodape" runat="server"></uc1:rodape></TABLE></DIV></FORM>
	</body>
</HTML>
