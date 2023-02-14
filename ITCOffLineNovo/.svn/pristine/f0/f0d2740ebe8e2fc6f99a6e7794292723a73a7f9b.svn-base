<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Pedidos.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Pedidos" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
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
						<img src='imagens/TituloCadastroPedidos.jpg' border=0 width="443" height="40">
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
										<tr>
											<td width="20%" colspan="5" align="middle">
												<asp:label Runat=server CssClass="f8" ForeColor=#FFFFFF ID="Label4"><strong>PESQUISA DE PEDIDOS</strong></asp:Label>
											</td>
										</tr>
									</table>
									<table width="100%" border="0" bgcolor=#FFFFFF>
										<tr>
											<td nowrap width=50%>
												<asp:label Runat=server CssClass="f8" ID="Label2">Código do Pedido</asp:Label><br>
												<asp:TextBox CssClass="f8"  ID="txtIDPedido" Style="width:100%" Runat="server" MaxLength="20"></asp:TextBox>
											</td>
											<td nowrap width=50%>
												<asp:label Runat=server CssClass="f8" ID="Label3">CNPJ</asp:label><br>
												<asp:TextBox ID="txtCNPJ" CssClass="f8" onKeyDown="FormataCNPJ(this, event);" MaxLength="18" Style="width:100%"  Runat="server"></asp:TextBox>
											</td>
											<td valign=middle align=center rowspan=2><asp:Button runat="server" ID="btnProcurar" Text="OK" CssClass="Botao" CausesValidation="false" /></asp:ImageButton></td>
										</tr>
										<tr>
											<td >
												<asp:label Runat=server CssClass="f8" ID="Label1">Razão Social ou Fantasia</asp:Label><br>
												<asp:TextBox CssClass="f8" ID="txtRazaoSocial" Runat="server" MaxLength="100" Width="100%"></asp:TextBox>
											</td>
											<td >
												<asp:Label CssClass="f8" Runat="server" id="Label5">Mostrar:&nbsp;</asp:Label><br>
												<uc1:ComboBox Style="width:100%"  EnableValidation="false" id="cboRegistros" CssClass="f8" runat="server"></uc1:ComboBox>
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
								<asp:DataGrid id="dtgPedidos" CssClass="f8" runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=25>
										<ItemTemplate>
											<a href="PedidosDet.aspx?IDPedido=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdPedido"))%>"><img src='imagens/bolaverde.gif' border=0 width="25" height="25" ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="PEDIDO" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="PedidosDet.aspx?IDPedido=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdPedido"))%>"><asp:Label ID=lblIdPedido Runat=server ><%# DataBinder.Eval(Container.DataItem, "NumeroPedido")%></asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="TipoPedido" HeaderText="TIPO DO PEDIDO" HeaderStyle-Font-Bold=True></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="RazaoSocial" HeaderText="EMPRESA" HeaderStyle-Font-Bold=True></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="CNPJ" HeaderText="CNPJ" HeaderStyle-Font-Bold=True></asp:BoundColumn>
								</Columns>
								</asp:DataGrid>
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
