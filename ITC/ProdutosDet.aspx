<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdutosDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.ProdutosDet"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmCad" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Produtos</h3>
				<br class="clear">
				<fieldset>
					<legend>Dados do Produto</legend>
					<label>Descrição do Produto<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="reqTitulo" ControlToValidate="txtProduto"></asp:RequiredFieldValidator></label>
					<asp:TextBox CssClass="InputG" Runat="server" ID="txtProduto" MaxLength="50" Width="400"></asp:TextBox>
					<br>
					<br>
				</fieldset>
				<table>
					<tr>
						<td>
							<asp:Button Runat="server" ID="btnIncluir" Text="Incluir" Visible="False"></asp:Button>
						</td>
						<td>
							<asp:Button Runat="server" ID="btnGravar" Text="Gravar" Visible="False"></asp:Button>
						</td>
						<td>
							<input type="button" value="Voltar" onclick='location.href="produtos.aspx"'>
						</td>
					</tr>
				</table>
				<br class="clear">
		</form>
		<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape></DIV>
	</body>
</HTML>
