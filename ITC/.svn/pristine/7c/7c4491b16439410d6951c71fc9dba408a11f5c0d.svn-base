<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControleVendEmpDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.ControleVendEmpDet"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Botao" Src="Inc/Botao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form id="frmCad" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Atribuições de Vendedores para Empresas</h3>
				<br />

				<table cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor="#999999">
					<tr>
						<td width="20%" colspan="5" align="center">
							<asp:label Runat="server" CssClass="f9" ForeColor="#FFFFFF" ID="Label4">
								<strong>Informações</strong>
							</asp:label>
						</td>
					</tr>
				</table>
				<br />
									
				<table width="100%" border="0" bgcolor="#ffffff">
					<tr>
						<td width="150">
							<asp:label Runat="server" CssClass="f9" ID="Label6">
								<b>Empresa:</b></asp:label>
						</td>
						<td colspan="3">
							<asp:label Runat="server" CssClass="f9" Font-Bold="True" ID="lblNomeEmpresa"></asp:label>
						</td>
					</tr>
					<tr>
						<td width="150">
							<asp:Label Runat="server" CssClass="f9" ID="Label17">
								<b>Vendedor:</b></asp:Label>
						</td>
						<td colspan="3">
							<asp:DropDownList DataTextField="Vendedor" DataValueField="IdVendedor" CssClass="f8" id="cboIdVendedor"	runat="server"></asp:DropDownList>
						</td>
					</tr>
				</table>
				<br />
									
				</table>
				<table width="70%">
					<tr>
						<td width=10%>
							<input type=button id="btnGravar" runat="server" value=Gravar />
						</td>
						<td align="right">
							<input type=button value=Voltar Runat="server" ID="btnVoltar" />
						</td>
					</tr>
				</table>
					
			<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
