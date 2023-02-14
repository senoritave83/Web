<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EventosCad.aspx.vb"  ValidateRequest="False" Inherits="ITC.EventosCad"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmDica" runat="server">
			<div id="Tudo">
			
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Cursos/Eventos</h3>
				<br class=clear />
				<table cellspacing=0 cellpadding=0 width=100%>
					<tr>
						<td>
							<asp:DataGrid id="dtgEventos" CssClass="f8" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=25 HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="eventoscaddet.aspx?idevento=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdEvento"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Data Inicial" HeaderStyle-HorizontalAlign=Center ItemStyle-HorizontalAlign=Center  HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<asp:Label ID=lblData Runat=server ><%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataInicial")), 4)%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Data Final" HeaderStyle-HorizontalAlign=Center ItemStyle-HorizontalAlign=Center  HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<asp:Label ID="Label2" Runat=server ><%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataFinal")), 4)%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Descrição"  HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="eventoscaddet.aspx?idevento=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdEvento"))%>"><asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "NomeEvento")%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td align="left" width="100%">
							<p align=center><asp:Button id="btnAddEvento" Text="Incluir" Runat="server"></asp:Button></p>
						</td>
					</tr>
				</table>
							
   				<br class="clear" />
				    
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
