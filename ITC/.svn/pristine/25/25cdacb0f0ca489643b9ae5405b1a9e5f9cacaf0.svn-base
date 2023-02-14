<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Dicas.aspx.vb"  ValidateRequest="False" Inherits="ITC.Dicas"%>
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
				<h3>Cadastro de Dicas</h3>
				<br class=clear />
				
				<table cellspacing=0 cellpadding=0 width=100%>
					<tr>
						<td>
							<asp:DataGrid CssClass="Lista" id="dtgDica" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines=Horizontal AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Título" HeaderStyle-Width=13% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="dicasdet.aspx?iddica=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdDica"))%>"><asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "Titulo").toUpper()%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Descrição" HeaderStyle-Width=77% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="dicasdet.aspx?iddica=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdDica"))%>"><asp:Label ID="Label2" Runat=server ><%# DataBinder.Eval(Container.DataItem, "Descricao").toUpper()%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status" HeaderStyle-Width=10% ItemStyle-HorizontalAlign=Center HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "Status")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td align="center" width="100%">
							<p align=center><asp:Button id="btnAddDica" Text="Incluir" Runat="server"></asp:Button></p>
						</td>
					</tr>
				</table>
							
   				<br class="clear" />
				    
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
