<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContatosObras.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ContatosObras" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
			function Procurar()
			{
				window.open('ProcurarEmpresaContato.aspx', 'ProcurarEmpresa', 'height=400, width=500, toolbar=no, left=200, top=200, scrollbars=yes')
			}
		</script>
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809EB7">
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
					<form id="frmCad" runat="server">
						<input type="hidden" runat="server" id="hdIdEmpresa"> <img src='imagens/TituloContatosObras.jpg' border="0" width="354" height="40">
						<asp:table id="tblObrasDet" runat="server" width="80%" BorderWidth="0" BackColor="#EFEFEF">
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell ForeColor="#FFFFFF" CssClass="f8" HorizontalAlign="Center" ColumnSpan="2" Width="30%" Text="DADOS CADASTRAIS"></asp:TableCell><asp:TableCell HorizontalAlign=center><asp:Button BorderStyle=None Text="Repetir Dados" CssClass="f8" ID="btnRepetir" Runat="server" CausesValidation="False"/></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Width="60%">
									<asp:Label ID="lblNome" Runat="server" CssClass="f8">Nome</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
									<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									<asp:Label ID="Label2" Runat="server" CssClass="f8">Telefones</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									&nbsp;<br><uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo1" MaxLength="50" />
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
									<asp:Label ID="Label1" Runat="server" CssClass="f8">Cargo</asp:Label>
									<br>
									<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboCargo" MaxLength="50" />
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									<asp:Label ID="Label3" Runat="server" CssClass="f8"></asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDFax" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtFax" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									&nbsp;<br><uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo2" MaxLength="50" />
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
									<asp:Label ID="Label4" Runat="server" CssClass="f8">E-Mail</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" MaxLength="50"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									<asp:Label ID="Label6" Runat="server" CssClass="f8"></asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD2" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone2" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Wrap="False">
									&nbsp;<br><uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboTipo3" MaxLength="50" />
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Width="100%" ColumnSpan="3">
									<asp:Label ID="Label5" Runat="server" CssClass="f8">Nome Fantasia da Empresa</asp:Label><asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="lblFantasia"></asp:RequiredFieldValidator>
									<br>
									<asp:TextBox CssClass="f8" ReadOnly="True" runat="server" Width="90%" ID="lblFantasia" name="lblFantasia"></asp:TextBox>&nbsp;<asp:HyperLink NavigateUrl="javascript:Procurar()" Runat="server" CssClass="f8" BackColor="#FFFFFF" ID="Hyperlink1">Procurar</asp:HyperLink>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
									<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
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
