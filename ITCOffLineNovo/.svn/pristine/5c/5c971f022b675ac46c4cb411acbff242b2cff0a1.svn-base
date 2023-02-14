<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ObrasVersoes.aspx.vb" Inherits="ITCOffLine.ObrasVersoes"%>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="450" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#809EB7" cellspacing="0">
						<tr>
							<td width="100%">
								<uc1:Top id="Top1" runat="server"></uc1:Top>
							</td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td valign="top" align="middle">
					<form id="frmCad" runat="server">
						<img src='imagens/TituloCadastroObras.jpg' border=0 width="294" height="40">
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<asp:DataGrid ItemStyle-Wrap=False CssClass=f8 id="dtgObrasVersoes" runat="server" BorderColor="#999999" BorderStyle=NotSet BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
									<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
									<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
									<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
									<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									<Columns>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="Versão" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<a href="obrasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "obv_codigoobra_int"))%>&Vers=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "obv_versao_int"))%>"><asp:Label ID="Label8" Runat=server Font-Bold=True><%# DataBinder.Eval(Container.DataItem, "obv_versao_int")%>ªVersão</asp:Label></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Data de Alteração" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "publicacao")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Realizada Por" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "obv_usuario_chr")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
						<table>
							<tr>
								<td>
									<asp:Button Runat=server Text="Voltar" ID="btnVoltar"></asp:Button>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
