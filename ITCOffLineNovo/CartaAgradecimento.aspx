<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CartaAgradecimento.aspx.vb" Inherits="ITCOffLine.CartaAgradecimento" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body>
		<div id="Tudo" runat="server">
			<form id="frmCad" runat="server">
				<div id="divRegistros" runat="server" visible="true">
					<asp:Label id="lblCodigo" runat="server">Código:</asp:Label>
					<asp:TextBox id="txtCodigo" runat="server"></asp:TextBox></div>
				<DIV runat="server" visible="true">
					<asp:Label id="lblAC" runat="server">A/C:</asp:Label>
					<asp:TextBox id="txtAC" runat="server"></asp:TextBox></DIV>
				<DIV runat="server" visible="true">
					<asp:Label id="lblEmail" runat="server">E-mail:</asp:Label>
					<asp:TextBox id="txtEmail" runat="server"></asp:TextBox></DIV>
				<DIV runat="server" visible="true">
					<asp:Button id="btnEnviar" runat="server" Text="Enviar"></asp:Button></DIV>
			</form>
		</div>
	</body>
</HTML>
