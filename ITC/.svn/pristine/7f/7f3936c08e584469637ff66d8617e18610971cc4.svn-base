<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CUB.aspx.vb"  ValidateRequest="False" Inherits="ITC.CUB"%>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#809eb7" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle">
						<img src="Imagens/TituloCUB.jpg" border="0"><br><br>
						<asp:DataGrid CssClass="f10" id="dtgCUB" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="96%">
							<HeaderStyle BackColor="#809eb7" HorizontalAlign=Center Font-Bold=True ForeColor=#FFFFFF></HeaderStyle>
							<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Data">
									<ItemTemplate>
										<asp:Label ID=lblData Runat=server ><%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "Data")), 4)%></asp:Label> </a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descrição">
									<ItemTemplate>
										<a href="CUBDet.aspx?IdCUB=<%# DataBinder.Eval(Container.DataItem, "IdCUB")%>"><asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "Titulo")%></asp:Label> </a>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
