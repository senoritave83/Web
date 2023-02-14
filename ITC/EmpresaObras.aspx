<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresaObras.aspx.vb"  ValidateRequest="False" Inherits="ITC.EmpresaObras" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="Form1" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Contato</h3>
				<br>
				<asp:TextBox Width="0" Runat="server" ID="txtIdEmpresa" Visible="False"></asp:TextBox>
				<input type="hidden" id="IdObra" runat="server">
				<table id="tblObrasDet" runat="server" width="100%" bgcolor="#efefef">
					<tr>
						<td Width="30%" align="right" nowrap>
							<asp:Label ID="Label4" Runat="server" CssClass="f8">Nome Fantasia da Empresa:&nbsp;</asp:Label>
						</td>
						<td Width="50%" align="left" nowrap colspan="2">
							<asp:Label ID="lblFantasia" Runat="server" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td Width="30%" align="right" nowrap>
							<asp:Label ID="lblNome" Runat="server" CssClass="f8">Razão Social da Empresa:&nbsp;</asp:Label>
						</td>
						<td Width="70%" align="left" nowrap colspan="3">
							<asp:Label Runat="server" ID="lblRazaoSocial" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td Width="30%" align="right" nowrap>
							<asp:Label ID="Label1" Runat="server" CssClass="f8">Endereço:&nbsp;</asp:Label>
						</td>
						<td Width="70%" align="left" nowrap colspan="3">
							<asp:Label Runat="server" ID="lblEndereco" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td align="right" nowrap Width="30%">
							<asp:Label ID="Label2" Runat="server" CssClass="f8">Cidade:&nbsp;</asp:Label>
						</td>
						<td align="left" nowrap Width="30%">
							<asp:Label Runat="server" ID="lblCidade" CssClass="f8"></asp:Label>
						</td>
						<td align="right" nowrap>
							<asp:Label ID="Label3" Runat="server" CssClass="f8">UF:&nbsp;</asp:Label>
						</td>
						<td align="left" nowrap Width="40%">
							<asp:Label Runat="server" ID="lblUF" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td Width="30%" align="right" nowrap>
							<asp:Label ID="Label5" Runat="server" CssClass="f8">Modalidade:&nbsp;</asp:Label>
						</td>
						<td Width="70%" align="left" nowrap colspan="3">
							<uc1:ComboBox cssClass="f8" id="cboModalidade" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td colspan="4" align="right">
							<asp:Button ID="btnVoltar" Runat="server" Text="Voltar"></asp:Button>
						</td>
					</tr>
				</table>
				<uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
