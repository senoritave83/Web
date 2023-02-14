<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdutosDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ProdutosDet" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#809eb7" cellspacing="0">
						<tr>
							<td width="100%">
								<uc1:Top id="Top1" runat="server"></uc1:Top>
							</td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr valign="top" height="100%">
				<td valign="top" align="middle">
					<form id="frmCad" runat="server">
						<img src="Imagens/TituloCadastroProdutos.jpg" border="0" width="413" height="33"><br>
						<br>
						<table width="70%" bgcolor="#efefef">
							<tr>
								<td align="middle" colspan="2" width="100%" bgcolor="#003c6e"><font color="#ffffff" class="f8"><B>DADOS 
											DO PRODUTO</B></font></td>
							</tr>
							<tr>
								<td valign="top" width="20%" nowrap><font class="f8">Descrição do Produto</font><asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="reqTitulo" ControlToValidate="txtProduto"></asp:RequiredFieldValidator></td>
								<td width="80%"><asp:TextBox CssClass="f8" Runat="server" ID="txtProduto" MaxLength="50" Width="400"></asp:TextBox></td>
							</tr>
						</table>
						<br>
						<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
					</form>
				</td>
			</tr>
			<tr>
				<td>
					<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
				</td>
			</tr>
		</table>
	</body>
</HTML>
