<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AssociadosTiposRegioes.aspx.vb"  ValidateRequest="False" Inherits="ITC.AssociadosTiposRegioes"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmDica" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Dados da Assinatura</h3>
				<br>
				<table id="tblObrasDet" runat="server" width="100%">
					<tr>
						<td align="left" ColumnSpan="4">
							<asp:Label ID="lblRazaoSocial" Runat="server" CssClass="f8"></asp:Label>
						</td>
					</tr>
				</table>
				<table width="100%">
					<tr>
						<td align="center" ColumnSpan="6" Width="100%" valign="top">
							<asp:DataGrid CssClass="f8" id="dtgTiposRegioes" runat="server" BorderColor="#999999" BorderStyle="Solid"
								BorderWidth="1" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
								width="100%" EnableViewState="false">
								<HeaderStyle BackColor="#999999" ForeColor="#FFFFFF" Font-Bold="True"></HeaderStyle>
								<FooterStyle BackColor="#003C6E" ForeColor="#FFFFFF"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Tipos de Obras">
										<ItemTemplate>
											<%# "<font color='" & iif(DataBinder.Eval(Container.DataItem, "IdTipo")=3, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=4, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=5, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=6, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=7, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=9, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=19, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=22, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=37, "#FF0000","#00000"))))))))) & "'>" & DataBinder.Eval(Container.DataItem, "DESCRICAOTIPO") & "</font>"%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<table align="center">
					<tr>
						<td width="100%" align="center">
							<asp:button CssClass="f8" ID="btnVoltar" Runat="server" Text="Voltar"></asp:button>
						</td>
					</tr>
				</table>
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
