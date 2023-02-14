<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContatoAssociados.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ContatosAssociados" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809eb7">
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
						<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">Contatos</font></b>
						<br>
						<br>
						<asp:table id="tblObrasDet" runat="server" width="80%" BorderWidth="0" BackColor="#EFEFEF">
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="3" CssClass="f8" ForeColor="#FFFFFF" Width="30%" Text="DADOS CADASTRAIS"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="2" Width="60%">
									<asp:Label ID="lblNome" Runat="server" CssClass="f8">Nome</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="97%" ID="txtNome" MaxLength="50"></asp:TextBox>
									<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
								</asp:TableCell>
								<asp:TableCell Width='40%'>
									<asp:Label ID="lblTelefone" Runat="server" CssClass="f8">(DDD) - Telefone</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
									<asp:Label ID="lblCargo" Runat="server" CssClass="f8">Cargo</asp:Label>
									<br>
									<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboCargo" MaxLength="50" />
								</asp:TableCell>
								<asp:TableCell>
									<asp:Label ID="lblFuncao" Runat="server" CssClass="f8">Função</asp:Label>
									<br>
									<uc1:ComboBox CssClass="f8" runat="server" Width="90%" ID="cboFuncao" MaxLength="50" />
								</asp:TableCell>
								<asp:TableCell>
									<asp:Label ID="lblFax" Runat="server" CssClass="f8">(DDD) - Fax</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDFax" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtFax" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Width="60%" ColumnSpan="2">
									<asp:Label ID="lblEmail" Runat="server" CssClass="f8">E-Mail</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="97%" ID="txtEmail" MaxLength="50"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Width='450px'>
									<asp:Label ID="lblCelular" Runat="server" CssClass="f8">(DDD) - Celular</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDCelular" MaxLength="2"></asp:TextBox> - 
									<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtCelular" MaxLength="20"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSkype" Runat="server" CssClass="f8">Endereço Skype</asp:Label>
									<br>
									<asp:TextBox CssClass="f8" runat="server" Width="50%" ID="txtSkype" MaxLength="30"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="3" HorizontalAlign=Right>
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
