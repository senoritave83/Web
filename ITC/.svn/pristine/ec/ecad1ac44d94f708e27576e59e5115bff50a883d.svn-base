<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContatosEmpresas.aspx.vb"  ValidateRequest="False" Inherits="ITC.ContatosEmpresas"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmDica" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Contato</h3>
				<br>
				<table id="tblObrasDet" runat="server" width="100%" bgcolor="#efefef">
					<tr>
						<td CssClass="f8" Align="center" colspan="3" Width="30%"><h3>Dados Cadastrais</h3>
						</td>
					</tr>
					<tr>
						<td Width="60%">
							<asp:Label ID="lblNome" Runat="server" CssClass="f8">Nome</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50" ReadOnly="True"></asp:TextBox>
						</td>
						<td Wrap="False">
							<asp:Label ID="Label2" Runat="server" CssClass="f8">Telefones</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td Wrap="False">
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
						<td Wrap="False">
							<asp:Label ID="Label3" Runat="server" CssClass="f8"></asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDFax" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtFax" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td Wrap="False">
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
						<td Wrap="False">
							<asp:Label ID="Label5" Runat="server" CssClass="f8"></asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD2" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone2" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
						<td Wrap="False">
							&nbsp;<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo3" MaxLength="50" />
						</td>
					</tr>
					<tr>
						<td>
							&nbsp;
						</td>
					</tr>
				</table>
				<table width="100%">
					<tr>
						<td width="45%">
							&nbsp;
						</td>
						<td align="center">
							<asp:Button ID="btnVoltar" Runat="server" Text="Voltar"></asp:Button>
						</td>
					</tr>
				</table>
				<uc1:rodape id="Rodape" runat="server"></uc1:rodape>
			</div>
		</form>
	</body>
</HTML>
