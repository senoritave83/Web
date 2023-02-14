<%@ Control Language="vb" AutoEventWireup="false" Codebehind="titulo.ascx.vb" Inherits="xmlinkwm.titulo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:PlaceHolder Runat='server' ID='plhTitulo' Visible='True'>
	<TABLE cellSpacing="1" cellPadding="1" width="730" height="100%">
		<TR height="10" vAlign="middle">
			<TD><IMG id="imgImagem" border="0" Visible="False" runat="server">
			</TD>
			<TD width="100%">
				<asp:Label id="lblTitulo" Runat="server" CssClass="TextHeader"></asp:Label><BR>
				<IMG src="imagens/npixel.gif" width="100%" height="1"><BR>
				<asp:Label id="lblDescricao" Runat="server" CssClass="DescHeader"></asp:Label></TD>
		</TR>
	</TABLE>
</asp:PlaceHolder>
