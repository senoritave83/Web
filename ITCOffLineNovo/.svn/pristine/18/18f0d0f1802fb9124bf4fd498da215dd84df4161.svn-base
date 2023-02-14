<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Produtos.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Produtos" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
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
							<td width="100%" ><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td valign="top" align="middle">
					<form id="frmCad" runat="server">
						<img src='imagens/TituloCadastroProdutos.jpg' border=0 width="413" height="33">
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
										<tr>
											<td width="20%" colspan="5" align="middle">
												<asp:label Runat=server CssClass="f8" ForeColor=#FFFFFF ID="Label4"><strong>FILTROS</strong></asp:Label>
											</td>
										</tr>
									</table>
									<table width="100%" border="0" bgcolor=#FFFFFF >
										<tr>
											<td align="right" nowrap>
												<asp:label Runat=server CssClass="f8" ID="Label1">Descrição do Produto</asp:Label>
											</td>
											<td align="left" width="60%" colspan="2">
												<asp:TextBox CssClass="f8" ID="txtProduto" Runat="server" MaxLength="100" Width="100%"></asp:TextBox>
											</td>
											<td  align="middle" width="20%">
												<asp:Button runat="server" ID="btnProcurar" Text="OK" CssClass="Botao" CausesValidation="false" /></asp:ImageButton>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<asp:DataGrid id="dtgProdutos" CssClass="f8" runat="server" AllowPaging=True PageSize=10 BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
										<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
										<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
										<Columns>
											<asp:TemplateColumn ItemStyle-Width=25 HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<a href="produtosdet.aspx?p=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProduto"))%>"><img src='imagens/bolaverde.gif' border=0 width="25" height="25" ></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-HorizontalAlign=Center HeaderText="DESCRIÇÃO DO PRODUTO" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<a href="produtosdet.aspx?p=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProduto"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "DescricaoProduto")%></asp:Label></a> 
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="" >
												<ItemTemplate>
													<%# iif(DataBinder.Eval(Container.DataItem, "AtualizarSite")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", "&nbsp;")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Visible=False ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
						<uc1:BarraNavegacao id="BarraNavegacao" runat="server"></uc1:BarraNavegacao>
						<br><br>
						<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
