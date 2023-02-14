<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TiposdeObras.aspx.vb"  ValidateRequest="False" Inherits="ITC.TiposdeObras"%>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#F1F1F1" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#F1F1F1"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="center">
						<img src='imagens/titulotiposobras.jpg' border="0">
						<asp:DataGrid CssClass="f8" id="dtgTiposObras" runat="server" BorderColor="#999999" BorderWidth="1" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" width="95%">
							<HeaderStyle ForeColor="#FFFFFF" BackColor="#003C6E"></HeaderStyle>
							<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-Width="40%" HeaderText="TIPO DE OBRA">
									<ItemTemplate>
										<font Color="#000000" face="verdana" Size="2">
											<%# DataBinder.Eval(Container.DataItem, "DescricaoTipo")%>
										</font>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="60%" HeaderText="SUB-TIPOS">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "DescricaoSubTipo")%>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
						<br>
					</td>
				</tr>
			</table>
		</form>
		<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape>
	</body>
</HTML>
