<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NoticiasCad.aspx.vb"  ValidateRequest="False" Inherits="ITC.NoticiasCad"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Notícias</h3>
				<br class=clear />
				<table cellspacing=0 cellpadding=0 width=100% border=1 bordercolor=#003C6E>
					<tr>
						<td>
							<asp:DataGrid id="dtgNoticias" CssClass="f8" runat="server" BorderColor="#FFFFFF" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<SelectedItemStyle BackColor=#0000ff></SelectedItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=25 HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="noticiascaddet.aspx?idnoticia=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdNoticia"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Data" HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<asp:Label ID=lblData Runat=server ><%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "Data")), 4)%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Descrição" HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="noticiascaddet.aspx?idnoticia=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdNoticia"))%>"><asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "Titulo")%></asp:Label> </a>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<br class=clear />
				<asp:Button ID=btnIncluir Runat=server Text=Incluir></asp:Button>
				<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape></div>
			</div>
		</form>
	</body>
</HTML>
