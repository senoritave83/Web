<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContatosObras.aspx.vb"  ValidateRequest="False" Inherits="ITC.ContatosObras"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmCad" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Contato</h3>
				<br>
				<input type="hidden" runat="server" id="hdIdEmpresa">
				<table id="tblObrasDet" runat="server" width="100%" Bgcolor="#efefef">
					<tr>
						<td Width="60%">
							<asp:Label ID="lblNome" Runat="server" CssClass="f8">Nome</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
						</td>
						<td nowrap>
							<asp:Label ID="Label2" Runat="server" CssClass="f8">Telefones</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD" MaxLength="2"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td nowrap>
							&nbsp;<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo1" MaxLength="50" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label1" Runat="server" CssClass="f8">Cargo</asp:Label>
							<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboCargo" MaxLength="50" />
						</td>
						<td nowrap>
							<asp:Label ID="Label3" Runat="server" CssClass="f8"></asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDFax" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtFax" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td nowrap>
							&nbsp;<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo2" MaxLength="50" />
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label4" Runat="server" CssClass="f8">E-Mail</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" MaxLength="50" ReadOnly="True"></asp:TextBox>
						</td>
						<td nowrap>
							<asp:Label ID="Label6" Runat="server" CssClass="f8"></asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD2" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone2" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td nowrap>
							&nbsp;<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo3" MaxLength="50" />
						</td>
					</tr>
					<tr>
						<td Width="100%" colspan="3">
							<asp:Label ID="Label5" Runat="server" CssClass="f8">Nome Fantasia da Empresa</asp:Label><asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="lblFantasia"></asp:RequiredFieldValidator>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="lblFantasia" name="lblFantasia" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Button ID="btnVoltar" Runat="server" Text="Voltar"></asp:Button>
						</td>
					</tr>
				</table>
				<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
			</div>
		</form>
	</body>
</HTML>
