<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Associar.aspx.vb"  ValidateRequest="False" Inherits="ITC.Associar"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td><uc1:top2 id="top" runat="server"></uc1:top2></td>
				</tr>
			</table>
			<table id="Table1" borderColor="#809eb7" cellpadding="0" cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle">
						<img src="Imagens/TituloAssociar.jpg" border="0"><br>
						<br>
						<br>
						<table width="95%" id="tblMensagem" runat="server">
							<tr>
								<td nowrap width="20%" align="middle">
									<asp:Label CssClass="f10" ForeColor="#FF0000" Runat="server" ID="lblMensagem">DADOS ENVIADOS COM SUCESSO</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Literal Runat="server" ID="ltGoBack"></asp:Literal>
								</td>
							</tr>
						</table>
						<table width="90%" id="tblDadosEmail" runat="server" border="0">
							<tr>
								<td colspan="2" width="100%">
									<font class="f10">Para se associar, preencha os dados abaixo que logo entraremos em 
										contato</font>
								</td>
							</tr>
							<tr>
								<td colspan="2" width="100%">
									&nbsp;
								</td>
							</tr>
							<tr>
								<td nowrap width="20%">
									<font class="f10">Nome</font><asp:RequiredFieldValidator ID="reqNome" Runat="server" CssClass="f8" ControlToValidate="txtNome" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td>
									<asp:TextBox Runat="server" ID="txtNome" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Empresa</font><asp:RequiredFieldValidator ID="reqEmpresa" Runat="server" CssClass="f8" ControlToValidate="txtEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEmpresa" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Atividade</font><asp:RequiredFieldValidator ID="reqAtividade" Runat="server" CssClass="f8" ControlToValidate="txtEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtAtividade" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Endere�o</font><asp:RequiredFieldValidator ID="reqEndereco" Runat="server" CssClass="f8" ControlToValidate="txtEndereco" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEndereco" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Cidade</font><asp:RequiredFieldValidator ID="reqCidade" Runat="server" CssClass="f8" ControlToValidate="txtCidade" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtCidade" CssClass="f8" Width="200" MaxLength="50"></asp:TextBox>
									&nbsp;<font class="f10">Estado</font>&nbsp;<uc1:ComboBox id="cboEstados" runat="server"></uc1:ComboBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Telefone</font><asp:RequiredFieldValidator ID="reqTelefone" Runat="server" CssClass="f8" ControlToValidate="txtTelefone" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtTelefone" CssClass="f8" Width="100" MaxLength="13"></asp:TextBox>&nbsp;<font class="f10">&nbsp;&nbsp;Fax</font>&nbsp;<asp:TextBox Runat="server" ID="txtFax" CssClass="f8" Width="100" MaxLength="13"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">E-Mail</font><asp:RequiredFieldValidator ID="Requiredfieldvalidator1" Runat="server" CssClass="f8" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEmail" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox><asp:RegularExpressionValidator id="regEMail" runat="server" ErrorMessage="*" CssClass="f8" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
								</td>
							</tr>
							<tr>
								<td>
									<font class="f10">Site</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtSite" CssClass="f8" Width="400" MaxLength="100">http://</asp:TextBox><asp:RegularExpressionValidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="*" CssClass="f8" ValidationExpression="http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ControlToValidate="txtSite"></asp:RegularExpressionValidator>
								</td>
							</tr>
						</table>
						<br>
						<br>
						<asp:ImageButton ImageUrl="imagens/botaoenviar.jpg" CausesValidation="True" Runat="server" id="ImageButton1"></asp:ImageButton>
						<br>
						<br>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodap�1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
