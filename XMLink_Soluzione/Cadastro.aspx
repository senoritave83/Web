<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Cadastro.aspx.vb" Inherits="xmlinkwm.Cadastro" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<HTML>
<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
	<!-- #INCLUDE FILE='inc/inc_top.ascx' -->
	<table width="100%" cellpadding="0" cellspacing="0" height="100%">
		<tr>
			<td>
				<uc1:inc_menu id="Inc_menu1" runat="server"></uc1:inc_menu>
			</td>
			<td class='BackgrStripes' rowspan="2">&nbsp;</td>
		</tr>
		<tr height="100%">
			<td width="750" valign="top" align="middle">
				<!-- INICIO CONTEUDO -->
				<form id="Form1" method="post" runat="server">
					<asp:Panel ID="pnlCadastro" Runat="server">
						<TABLE class="TextDefault" cellSpacing="8" cellPadding="0" border="0">
							<TR>
								<TD vAlign="bottom" align="left">*Nome de sua Empresa:</TD>
								<TD vAlign="bottom" colSpan="2">
									<asp:TextBox id="txtEmpresa" runat="server" SIZE="45" maxlength="129"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator2" Runat="server" ControlToValidate="txtEmpresa" ErrorMessage="O nome da empresa é obrigatório" Display="None"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*Razao Social:</TD>
								<TD vAlign="bottom" colSpan="2">
									<asp:TextBox id="txtRazao" runat="server" MAXLENGTH="129"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" Runat="server" ControlToValidate="txtRazao" ErrorMessage="Razão Social da empresa é obrigatório" Display="None"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*CNPJ:</TD>
								<TD vAlign="bottom" colSpan="2">
									<asp:TextBox id="txtCNPJ" onkeydown="return fncOnlyInteger();" onblur="fncFormatText(this);" onfocus="fncCleanFormat(this);" runat="server" SIZE="40" maxlength="40"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidadtor1" Runat="server" ControlToValidate="txtCNPJ" ErrorMessage="CNPJ obrigatório" Display="None"></asp:RequiredFieldValidator>
									<asp:CustomValidator id="val_txtCNPJCPF_0" runat="server" ControlToValidate="txtCNPJ" ErrorMessage="CNPJ Inválido" Display="None" Enabled="False" ClientValidationFunction="ValidateCPF"></asp:CustomValidator></TD>
							</TR>
							<TR vAlign="top">
								<TD vAlign="bottom" align="left">*Código Magnus</TD>
								<TD vAlign="bottom" noWrap>
									<asp:TextBox id="txtCodigo" runat="server" SIZE="20" MAXLENGTH="20"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator3" Runat="server" ControlToValidate="txtCodigo" ErrorMessage="Por favor digite o código Magnus da sua empresa" Display="None"></asp:RequiredFieldValidator></TD>
								<TD>Veja sua fatura.</TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="3"><BR>
									<asp:Button id="btnAvancar" Runat="server" Text="Avançar"></asp:Button><IMG height="1" src="/Nii/Images/pt_BR/spacer.gif" width="20" border="0">
									<INPUT type="reset" value="Apagar as mudanças" name="btnCancel">
								</TD>
							</TR>
							<TR>
								<TD noWrap colSpan="3">*Informação necessária.<BR>
									<asp:ValidationSummary id="Validationsummary1" Runat="server"></asp:ValidationSummary>
									<asp:Label Runat="server" ID='lblChecagem' CssClass="TextDefault" Visible="False">Erro</asp:Label>
								</TD>
							</TR>
						</TABLE>
					</asp:Panel>
					<asp:Panel Runat="server" ID='pnlCadastro2' Visible="False">
						<TABLE class="TextDefault" cellSpacing="8" cellPadding="0" border="0">
							<TR>
								<TD vAlign="bottom" align="left">*Nome do usuário administrador:</TD>
								<TD vAlign="bottom">
									<asp:TextBox id="txtAdministrador" runat="server" MAXLENGTH="50"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator4" Runat="server" ControlToValidate="txtAdministrador" ErrorMessage="Por favor digitar o nome do usuário administrador" Display="None"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*login do usuário administrador:</TD>
								<TD vAlign="bottom">
									<asp:TextBox id="txtLogin" runat="server" maxlength="15"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator5" Runat="server" ControlToValidate="txtLogin" ErrorMessage="O login do usuário administrador é obrigatório" Display="None"></asp:RequiredFieldValidator></TD>
								<TD>Deve iniciar com uma letra e pode conter letras e números, mas sem espaços.</TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*Senha :</TD>
								<TD vAlign="bottom">
									<asp:TextBox id="txtPassword" Runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator6" Runat="server" ControlToValidate="txtPassword" ErrorMessage="A senha do usuário administrador é obrigatório" Display="None"></asp:RequiredFieldValidator></TD>
								<TD>A senha deve conter uma combinação de pelo menos 7 letras e números.
								</TD>
							</TR>
							<TR>
								<TD vAlign="bottom" noWrap align="left">Redigitar a senha:</TD>
								<TD vAlign="bottom">
									<asp:TextBox id="txtVerifyPassword" Runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
									<asp:CompareValidator id="Comparevalidator1" Runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="As senhas estão diferentes" Display="None" Operator="Equal" ControlToCompare="txtPassword"></asp:CompareValidator></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*Correio Eletrônico para envio de Informações:</TD>
								<TD vAlign="bottom" colSpan="2">
									<asp:TextBox id="txtEmail" runat="server" SIZE="45" MAXLENGTH="129"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator8" Runat="server" ControlToValidate="txtEmail" ErrorMessage="Por favor preencha o e-mail do usuário administrador" Display="None"></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="val_txtEmail_0" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail inválido" Display="None" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD vAlign="bottom" align="left">*Redigite Correio Eletrônico:</TD>
								<TD vAlign="bottom" colSpan="2">
									<asp:TextBox id="txtVerifyEmail" runat="server" SIZE="45" maxlength="129"></asp:TextBox>
									<asp:CompareValidator id="CompareValidator2" Runat="server" ControlToValidate="txtVerifyEmail" ErrorMessage="Os e-mails estão diferentes" Display="None" Operator="Equal" ControlToCompare="txtEmail"></asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="3"><BR>
									<asp:Button id="btnOk" Runat="server" Text="Ok"></asp:Button><IMG height="1" src="/Nii/Images/pt_BR/spacer.gif" width="20" border="0">
									<INPUT type="reset" value="Apagar as mudanças" name="btnCancel">
								</TD>
							</TR>
							<TR>
								<TD noWrap colSpan="3">*Informação necessária.<BR>
									<asp:ValidationSummary id="valSumary" Runat="server"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
					</asp:Panel>
					<asp:Panel ID='pnlMessage' Runat="server" Visible="False">
						<TABLE height="100%">
							<TR>
								<TD height="30%">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="TextDefault" vAlign="top">Não foi possível completar o cadastro.<BR>
									<BR>
									<asp:Label id="lblMessage" Runat="server" cssclass="TextDefault"></asp:Label></TD>
							</TR>
						</TABLE>
					</asp:Panel>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 