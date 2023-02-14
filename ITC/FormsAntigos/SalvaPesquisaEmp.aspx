<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SalvaPesquisaEmp.aspx.vb"  ValidateRequest="False" Inherits="ITC.SalvarPesquisaEmp"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#F1F1F1">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="middle" width="95%">
					<form id="frmCad" action="ObrasDet.aspx" runat="server">
						<img src='imagens/TituloSalvandoPesquisa.jpg' border="0"><br>
						<br>
						<asp:table id="tblObrasDet" runat="server" width="80%" BorderWidth="0">
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell HorizontalAlign="Center" CssClass="f8" ForeColor="#FFFFFF" Width="30%" Text="Digite o nome que você deseja dar a sua pesquisa"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow BackColor="#EFEFEF">
								<asp:TableCell HorizontalAlign="center" Wrap="False">
									<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
									<br>
									<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="O nome da pesquisa é obrigatório" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell HorizontalAlign="center">
									<asp:Button CssClass="f8" Runat="server" ID="btnSalvarPesquisa" Text=" Salvar Agora..."></asp:Button>
								</asp:TableCell>
							</asp:TableRow>
						</asp:table><br>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
