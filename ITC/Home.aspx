<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserData" Src="Inc/UserData.ascx" %>
<%@ Page Language="vb" autoeventwireup="false" codebehind="Home.aspx.vb" validaterequest="False" Inherits="ITC.Home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<uc1:top id="Top1" runat="server"></uc1:top>
			<p class="BemVindo">Bem Vindo ao sistema ITC</p>
			<div class="Caixa-Home">
				<h3>Dica da Semana</h3>
				<ul>
					<iframe src="http://www.itc.etc.br/extrasitc/testedica.aspx" frameborder="0" width="230" height="230" scrolling="no"
						allowtransparency></iframe>

				</ul>
			</div>
			
			<div class="Caixa-Home">
				<h3>Saiba Mais</h3>
				<ul>
					<asp:DataGrid CssClass="Lista" id="dtgSaibaMais" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines=Horizontal AutoGenerateColumns="False" width="100%">
						<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
						<Columns>
							<asp:TemplateColumn>
								<ItemTemplate>
									<a href=<%# Microsoft.VisualBasic.IIF(isDbNull(DataBinder.Eval(Container.DataItem, "sbm_link_chr")), "#", DataBinder.Eval(Container.DataItem, "sbm_link_chr"))%>><img src="imagens/saibamais/<%# DataBinder.Eval(Container.DataItem, "sbm_imagem_chr")%>" class="FloatLeft" style="MARGIN:2px" width=100 height=80/>
									<%# DataBinder.Eval(Container.DataItem, "sbm_texto_chr")%></a>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
					</asp:DataGrid>
				</ul>
			</div>
			
			<table>
				<tr></tr>
				<tr></tr>
				<tr></tr>
				<tr>
					<td>
						<h3>Análise Mensal</h3>
						<asp:DataGrid CssClass="Lista" id="dtgAnalise" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines=Horizontal AutoGenerateColumns="False" width="100%">
							<Columns>
								<asp:TemplateColumn ItemStyle-HorizontalAlign=Center>
									<ItemTemplate>
										<a href="<%# Microsoft.VisualBasic.IIF(isDbNull(DataBinder.Eval(Container.DataItem, "anm_link_chr")), "#", DataBinder.Eval(Container.DataItem, "anm_link_chr"))%>"><img src="imagens/analise/<%# DataBinder.Eval(Container.DataItem, "anm_imagem_chr")%>" width=216 height=254 /></a>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
			
			<br class="clear">
			<uc1:Rodape id="Rodap1" runat="server"></uc1:Rodape>
		</div>
	</body>
</HTML>
