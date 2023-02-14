<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PesquisaTabelaAtividadesEmpresa.aspx.vb"  ValidateRequest="False" Inherits="ITC.PesquisaTabelaAtividadesEmpresa"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form id="frmCad" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
					<h3>Atividades da Empresa</h3>
					<br />			
						<asp:DataGrid PageSize="10" CssClass="f8" id="dtgAtividadesEmpresa" runat="server" BorderColor="#ffffff" BorderWidth="0" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" width="100%">
							<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
							<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
							<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-Width="40%" ItemStyle-VerticalAlign=Middle ItemStyle-Height=45  HeaderStyle-Font-Bold=True HeaderText="Atividade">
									<ItemTemplate>
										<font Color="#000000" face="verdana" Size="2">
											<%# DataBinder.Eval(Container.DataItem, "DESCRICAOATIVIDADE")%>
										</font>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderStyle-Width="40%" HeaderStyle-Font-Bold=True HeaderText="Subatividades">
									<ItemTemplate>
										<font Color="#000000" face="verdana" Size="2">
											<%# DataBinder.Eval(Container.DataItem, "DESCRICAOSUBATIVIDADES")%>
										</font>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" PageButtonCount=10 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
				<uc1:Rodape runat="server" ID="Rodape1"></uc1:Rodape>
			</form>
		</div>
   </body>
</HTML>