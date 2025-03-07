<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PesquisaTabelasFases.aspx.vb"  ValidateRequest="False" Inherits="ITC.PesquisaTabelasFases"%>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form id="frmCad" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
					<h3>Fases/Est�gios</h3>
					<br />	
					<asp:DataGrid id="dtgEstagios" runat="server" BorderColor="#999999" BorderWidth="0" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" width="100%">
						<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
						<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
						<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
						<Columns>
							<asp:TemplateColumn HeaderStyle-Width="10%" ItemStyle-VerticalAlign=Middle ItemStyle-Height=40 HeaderStyle-Font-Bold=True HeaderText="Fase">
								<ItemTemplate>
									<font Color="#000000" face="verdana" Size="2">
										<%# DataBinder.Eval(Container.DataItem, "DESCRICAOFASE")%>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Width="20%" ItemStyle-VerticalAlign=Middle ItemStyle-Height=40 HeaderStyle-Font-Bold=True HeaderText="Est�gio">
								<ItemTemplate>
									<font Color="#000000" face="verdana" Size="2">
										<%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTAGIO")%>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Width="70%" ItemStyle-VerticalAlign=Middle ItemStyle-Height=40 HeaderStyle-Font-Bold=True HeaderText="Descri��o do Est�gio">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "OBSERVACAO")%>
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