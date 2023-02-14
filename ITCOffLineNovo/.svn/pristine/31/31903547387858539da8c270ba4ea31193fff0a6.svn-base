<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdutosAssociados.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ProdutosAssociados" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="450" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#809eb7" cellspacing="0">
						<tr>
							<td width="100%">
								<uc1:Top id="Top1" runat="server"></uc1:Top>
							</td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td valign="top" align="middle">
					<form id="frmCad" runat="server">
						<img src='imagens/TituloProdutosAssociado.jpg' border="0" width="443" height="40">
						<br>
						<uc1:BarraBotoes id="Barra1" runat="server"></uc1:BarraBotoes>
						<br>
						<asp:CheckBoxList BorderStyle=Outset BorderWidth="1" Width="96%" CssClass="f8" RepeatDirection="Vertical" Runat="server" RepeatColumns="3" ID="chkProdutos"></asp:CheckBoxList>
						<br>
						<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
