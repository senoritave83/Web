<%@ Register TagPrefix="uc1" TagName="Menu" Src="inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/combobox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes2.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Grupo.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Grupos" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table id="tbl1" cellSpacing="0" width="100%" height='100%' border="0" class='TableSup' cellpadding="0">
			<tr height="100">
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809eb7">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr bgcolor='#ffffff' height="*">
				<td align="middle" valign="top">
					<form id="frmCad" runat="server" action="Grupo.aspx"><br>
						<img src="imagens/TituloCadastroGrupos.jpg" border="0" width="443" height="40">
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<asp:DataGrid id="dtgCargo" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
										<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
										<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
										<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn ItemStyle-Width=25>
												<ItemTemplate>
													<a href="grupodet.aspx?idgrupo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "idgrupo"))%>"><img src='imagens/bolaverde.gif' border=0 width="25" height="25" ></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="DESCRIÇÃO GRUPO" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<a href="grupodet.aspx?idgrupo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "idgrupo"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "descricaogrupo")%></asp:Label></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="" >
												<ItemTemplate>
													<%# iif(DataBinder.Eval(Container.DataItem, "AtualizarSite")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", "&nbsp;")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr valign="bottom" height="20">
				<td width="100%"><uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape></td>
			</tr>
		</table>
	</body>
</HTML>
