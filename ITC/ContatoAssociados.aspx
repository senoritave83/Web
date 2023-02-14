<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContatoAssociados.aspx.vb"  ValidateRequest="False" Inherits="ITC.ContatosAssociados"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmCad" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Contato</h3>
				<br>
				<table id="tblObrasDet" runat="server" width="100%" bgcolor="#efefef">
					<tr>
						<td align="center" colspan="2" class="f8"><h3>Dados Gerais</h3>
						</td>
					</tr>
					<tr>
						<td colspan="2" Width="70%">
							<asp:Label ID="lblNome" Runat="server" CssClass="f8">Nome</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
						</td>
						<td Width='450'>
							<asp:Label ID="lblTelefone" Runat="server" CssClass="f8">(DDD) - Telefone</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDD" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtTelefone" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="lblCargo" Runat="server" CssClass="f8">Cargo</asp:Label>
							<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="80%" ID="cboCargo" MaxLength="50" />
						</td>
						<td>
							<asp:Label ID="lblFuncao" Runat="server" CssClass="f8">Função</asp:Label>
							<br>
							<uc1:ComboBox CssClass="f8" runat="server" Width="80%" ID="cboFuncao" MaxLength="50" />
						</td>
						<td>
							<asp:Label ID="lblFax" Runat="server" CssClass="f8">(DDD) - Fax</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDFax" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtFax" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td Width="100%" colspan="2">
							<asp:Label ID="lblEmail" Runat="server" CssClass="f8">E-Mail</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" MaxLength="50" ReadOnly="True"></asp:TextBox>
						</td>
						<td Width='450'>
							<asp:Label ID="lblCelular" Runat="server" CssClass="f8">(DDD) - Celular</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="30px" ID="txtDDDCelular" MaxLength="2" ReadOnly="True"></asp:TextBox>
							-
							<asp:TextBox CssClass="f8" runat="server" Width="150px" ID="txtCelular" MaxLength="20" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSkype" Runat="server" CssClass="f8">Endereço Skype</asp:Label>
							<br>
							<asp:TextBox CssClass="f8" runat="server" Width="50%" ID="txtSkype" MaxLength="30" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
					<tr>
						<td colspan="2" align="right">
							<asp:Button ID="btnVoltar" Runat="server" Text="Voltar"></asp:Button>
						</td>
					</tr>
				</table>
				<br class="clear">
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
