<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CadastreSuaObra.aspx.vb"  ValidateRequest="False" Inherits="ITC.CadastreSuaObra"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
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
						<img src="Imagens/TituloCadastreObra.jpg" border="0"><br>
						<br>
						<font class="f10">Preencha os dados de sua obra e receba uma oportunidade de 
							negócios: </font>
						<br>
						<br>
						<table width="90%" id="tblMensagem" runat="server">
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
						<table width="90%" id="tblDadosEmail" runat="server">
							<tr>
								<td nowrap width="20%">
									<asp:RequiredFieldValidator ID="reqNome" Runat="server" CssClass="f10" ControlToValidate="txtNome" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Nome</font>
								</td>
								<td>
									<asp:TextBox Runat="server" ID="txtNome" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RequiredFieldValidator ID="reqEmpresa" Runat="server" CssClass="f8" ControlToValidate="txtEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Empresa</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEmpresa" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td nowrap>
									<asp:RequiredFieldValidator ID="reqEndereco" Runat="server" CssClass="f8" ControlToValidate="txtEndereco" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Endereço 
										da Obra</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEndereco" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RequiredFieldValidator ID="reqCidade" Runat="server" CssClass="f8" ControlToValidate="txtCidade" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Cidade</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtCidade" CssClass="f8" Width="200" MaxLength="50"></asp:TextBox>
									&nbsp;<font class="f10">Estado</font>&nbsp;<uc1:ComboBox id="cboEstados" runat="server"></uc1:ComboBox>
								</td>
							</tr>
							<tr>
								<td nowrap>
									<asp:RequiredFieldValidator ID="reqEstagio" Runat="server" CssClass="f8" ControlToValidate="txtEstagio" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Estágio 
										Atual da Obra</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEstagio" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RequiredFieldValidator ID="reqTelefone" Runat="server" CssClass="f8" ControlToValidate="txtTelefone" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">Telefone</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtTelefone" CssClass="f8" Width="100" MaxLength="13"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" Runat="server" CssClass="f8" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator><font class="f10">E-Mail</font>
								</td>
								<td nowrap>
									<asp:TextBox Runat="server" ID="txtEmail" CssClass="f8" Width="400" MaxLength="100"></asp:TextBox><asp:RegularExpressionValidator id="regEMail" runat="server" ErrorMessage="*" CssClass="f8" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
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
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
