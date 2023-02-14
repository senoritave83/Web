<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IndicesITC.aspx.vb"  ValidateRequest="False" Inherits="ITC.IndicesITC"%>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
				</tr>
				<tr>
					<td width="100%" bgcolor="#F1F1F1">
						<uc1:Login id="Login1" runat="server"></uc1:Login>
					</td>
				</tr>
			</table>
			<table id="Table1" borderColor="#F1F1F1" cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#edf0f2"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle">
						<img src="Imagens/TituloCadastroIndices.jpg" border="0">
						<table width="100%">
							<tr>
								<td width="2%">&nbsp;</td>
								<td width="96%" align="middle">
									<br>
									<asp:Image Runat="server" ID="imgIndice" BorderStyle=None></asp:Image>
									<br>
									<br>
									<asp:Label Runat="server" ID="lblDadosIndice" CssClass="f8"></asp:Label><br>
									<br>
								</td>
								<td width="2%">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
