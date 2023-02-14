<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SubSenha.aspx.vb"  ValidateRequest="False" Inherits="ITC.SubSenha" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<HTML>
	<HEAD>
		<title>::: ITC :::</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Inc/menu.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#f7f7d8">
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
						<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">Controle 
								de Sub-Senhas</font></b>
						<br>
						<br>
						<asp:table id="tblObrasDet" runat="server" BorderWidth="0" width="80%">
							<asp:TableRow BackColor="#f7f7d8">
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="4" Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="CADASTRO PRINCIPAL"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Código"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblCodigoCadastroPrincipal" Runat="server" Font-Bold="True" Font-Name="verdana" Font-Size="10"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Nome"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblNomeCadastroPrincipal" Runat="server" Font-Bold="True" Font-Name="verdana" Font-Size="10"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Empresa"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblEmpresaCadastroPrincipal" Runat="server" Font-Bold="True" Font-Name="verdana" Font-Size="10"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="4">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow BackColor="#f7f7d8">
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="4" Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="DADOS DO SUB-CADASTRO"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Código"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblCodigo" Runat="server" Font-Bold="True" Font-Name="verdana" Font-Size="10"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Nome"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:TextBox Font-Name="verdana" Font-Size="10" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
									<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="30%" Text="Login"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left">
									<asp:TextBox Font-Name="verdana" Font-Size="10" runat="server" Width="90%" ID="txtLogin" MaxLength="20"></asp:TextBox>
									<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="4">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="4">
									<uc1:barrabotoes id="BarraBotoes" runat="server"></uc1:barrabotoes>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="4">&nbsp;</asp:TableCell>
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
