<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControleVendObr.aspx.vb"  ValidateRequest="False" Inherits="ITC.ControleVendObr"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form runat="Server" id="frm">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Atribuições de Vendedores para Obras</h3>
				<br />
				
				<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#999999">
					<tr>
						<td width="20%" colspan="5" align="middle">
							<asp:label Runat=server CssClass="f9" ForeColor=#FFFFFF ID="Label4"><strong>Pesquisar</strong></asp:Label>
						</td>
					</tr>
				</table>
				<br />
				
				<table width="100%" border="0" bgcolor=#FFFFFF >
					<tr>
						<td align="right" width=10%>
							<asp:label Runat=server CssClass="f9" ID="Label1">Obra</asp:Label>
						</td>
						<td align="left" width="60%" colspan="2">
							<asp:TextBox CssClass="f8" ID="txtObra" Runat="server" MaxLength="100" Width="80%"></asp:TextBox>
						</td>
						<td  align="middle" width="20%">
							<input type=button Runat="server" ID="btnProcurar" value="Pesquisar"/>
						</td>
					</tr>
				</table>
				<br />
				
				<table align="center" cellspacing=0 cellpadding=0 width=100% border=1 bordercolor=#003C6E id=tblResult runat=server>
					<tr>
						<td align="center">
							<asp:DataGrid CssClass="f9" id="dtgFollowUP" runat="server" AllowPaging="True" AllowSorting="True" PageSize="12" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
							<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
							<FooterStyle BackColor=#ffffff ForeColor=#ffffff></FooterStyle>
							<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
							<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=25>
										<ItemTemplate>
											<a href="ControleVendObrDet.aspx?idobra=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<b>Obra</b>" ItemStyle-Width=100%>
										<ItemTemplate>
											<a href="ControleVendObrDet.aspx?idobra=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "PROJETO")%></asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Visible=False HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<br>
				<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao>

			</form>
			<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
		</div>
	</body>
</HTML>
