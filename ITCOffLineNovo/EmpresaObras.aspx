<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresaObras.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.EmpresaObras" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<asp:Literal Runat=server ID=ltHTML></asp:Literal>
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809eb7">
						<tr>
							<td width="100%"><uc1:Top id="Top1" runat="server"></uc1:Top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="middle" width="95%">
					<form id="frmCad" runat="server">
						<asp:TextBox Width="0" Runat="server" ID="txtIdEmpresa"></asp:TextBox>
						<input type="hidden" id="IdObra" runat="server"> <img src='imagens/TituloEmpresasParticipantes.jpg' border="0" width="384" height="40">
						<br>
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<asp:table id="tblObrasDet" BackColor="#EFEFEF" runat="server" width="100%" BorderWidth="0">
										<asp:TableRow BackColor="#003C6E">
											<asp:TableCell Font-Bold=True HorizontalAlign="Center" ColumnSpan="4" CssClass="f8" ForeColor="#FFFFFF" Width="30%" Text="DADOS CADASTRAIS"></asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell Width="30%" HorizontalAlign="Right" Wrap="False">
												<asp:Label ID="Label4" Runat="server" CssClass="f8">Nome Fantasia da Empresa:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell Width="50%" HorizontalAlign="Left" Wrap="False" ColumnSpan="2">
												<asp:Label ID="lblFantasia" Runat="server" CssClass="f8"></asp:Label>
											</asp:TableCell>
											<asp:TableCell Runat="server">
												<asp:HyperLink NavigateUrl="javascript:Procurar()" Runat="server" CssClass="f8" BackColor="#FFFFFF" ID="BotaoProcurar">Procurar</asp:HyperLink>
												<asp:CompareValidator Runat="server" ErrorMessage="*" CssClass="f8" ControlToValidate="txtIdEmpresa" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
												<asp:RequiredFieldValidator Runat="server" ErrorMessage="*" CssClass="f8" ControlToValidate="txtIdEmpresa"></asp:RequiredFieldValidator>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell Width="30%" HorizontalAlign="Right" Wrap="False">
												<asp:Label ID="lblNome" Runat="server" CssClass="f8">Razão Social da Empresa:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell Width="70%" HorizontalAlign="Left" Wrap="False" ColumnSpan="3">
												<asp:Label Runat="server" ID="lblRazaoSocial" CssClass="f8"></asp:Label>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell Width="30%" HorizontalAlign="Right" Wrap="False">
												<asp:Label ID="Label1" Runat="server" CssClass="f8">Endereço:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell Width="70%" HorizontalAlign="Left" Wrap="False" ColumnSpan="3">
												<asp:Label Runat="server" ID="lblEndereco" CssClass="f8"></asp:Label>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell HorizontalAlign="Right" Wrap="False" Width="30%">
												<asp:Label ID="Label2" Runat="server" CssClass="f8">Cidade:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Wrap="False" Width="30%">
												<asp:Label Runat="server" ID="lblCidade" CssClass="f8"></asp:Label>
											</asp:TableCell>
											<asp:TableCell HorizontalAlign="Right" Wrap="False">
												<asp:Label ID="Label3" Runat="server" CssClass="f8">UF:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Wrap="False" Width="40%">
												<asp:Label Runat="server" ID="lblUF" CssClass="f8"></asp:Label>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell Width="30%" HorizontalAlign="Right" Wrap="False">
												<asp:Label ID="Label5" Runat="server" CssClass="f8">Modalidade:&nbsp;</asp:Label>
											</asp:TableCell>
											<asp:TableCell Width="70%" HorizontalAlign="Left" Wrap="False" ColumnSpan="3">
												<uc1:ComboBox cssClass="f8" id="cboModalidade" runat="server"></uc1:ComboBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan="4" HorizontalAlign=Right>
												<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
											</asp:TableCell>
										</asp:TableRow>
									</asp:table>
								</td>
							</tr>
						</table>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
