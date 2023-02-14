<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Propostas.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Propostas" %>
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
						<img src='imagens/TituloCadastroPropostas.jpg' border=0 width="443" height="40">
						<br>
						<div id="tblPropostas" runat=server>
							<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
								<tr>
									<td>
										<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
											<tr>
												<td width="20%" colspan="5" align="middle">
													<asp:label Runat=server CssClass="f8" ForeColor=#FFFFFF ID="Label4"><strong>PESQUISA DE PROPOSTAS</strong></asp:Label>
												</td>
											</tr>
										</table>
										<table width="100%" border="0" bgcolor=#FFFFFF>
											<tr>
												<td nowrap width=50%>
													<asp:label Runat=server CssClass="f8" ID="Label2">Número da Proposta</asp:Label><br>
													<asp:TextBox CssClass="f8"  ID="txtIDProposta" Style="width:100%" Runat="server" MaxLength="20"></asp:TextBox>
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
									<asp:DataGrid id="dtgProposta" CssClass="f8" runat="server" AllowPaging="True" OnPageIndexChanged="dtgProposta_doPaging" AllowSorting="True" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
									<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
									<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
									<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
									<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									<Columns>
										<asp:TemplateColumn ItemStyle-Width=25>
											<ItemTemplate>
												<a href="Proposta.aspx?IDProposta=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProposta"))%>"><img src='imagens/bolaverde.gif' border=0 width="25" height="25" ></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="Proposta" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
											<ItemTemplate>
												<a href="Proposta.aspx?IDProposta=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProposta"))%>"><asp:Label ID=lblIdProposta Runat=server ><%# DataBinder.Eval(Container.DataItem, "IdProposta")%></asp:Label></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="RazaoSocial" HeaderText="ASSOCIADO" HeaderStyle-Font-Bold=True></asp:BoundColumn>
										<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="CNPJ" HeaderText="CNPJ" HeaderStyle-Font-Bold=True></asp:BoundColumn>
										<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="StatusProposta" HeaderText="Status" HeaderStyle-Font-Bold=True></asp:BoundColumn>
									</Columns>
									</asp:DataGrid>
									</td>
								</tr>
							</table>
							<table cellspacing=0 cellpadding=0 width=90% border=0>
								<tr>
									<td align="right">
										<asp:ImageButton AlternateText="Cria uma Nova Proposta" ImageUrl='imagens/btn_proposta.png' runat='server' id="btnIncluir"></asp:ImageButton>
									</td>
									<td align="left">
										<asp:ImageButton AlternateText="Cria uma Proposta Em Renovação" ImageUrl='imagens/btn_renovacao.png' runat='server' id="btnIncluirRenovacao"></asp:ImageButton>
									</td>
								</tr>
							</table>
						</div>
						
						<br>
						<br>
						<table id="tblAssociado" runat="server" visible="false" cellspacing=0 cellpadding=0 width=90% >
							<tr>
								<td>
									<table cellspacing=0 cellpadding=0 width=100% border=1 bordercolor=#003C6E>
										<tr>
											<td>
												<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
													<tr>
														<td width="20%" colspan="5" align="middle">
															<asp:label Runat=server CssClass="f8" ForeColor=#FFFFFF ID="Label6"><strong>PESQUISA DE ASSOCIADO</strong></asp:Label>
														</td>
													</tr>
												</table>
												<table width="100%" border="0" bgcolor=#FFFFFF>
													<tr>
														<td nowrap width=50%>
															<asp:label Runat=server CssClass="f8" ID="Label7">Razão Social ou Fantasia</asp:Label><br>
															<asp:TextBox CssClass="f8" ID="txtRazaoFantasia" Runat="server" MaxLength="100" Width="100%"></asp:TextBox>
														</td>
														<td nowrap width=50%>
															<asp:label Runat=server CssClass="f8" ID="Label8">Código</asp:Label><br>
															<asp:TextBox CssClass="f8"  ID="txtCodigoAss" Style="width:100%" Runat="server" MaxLength="20"></asp:TextBox>
														</td>
														<td valign=middle align=center rowspan=2><asp:ImageButton BorderStyle=None ImageUrl="imagens/botaook.gif" CssClass=f8 ID="btnProcurarAssociado" Runat="server"></asp:ImageButton></td>
													</tr>
													<tr>
														
														<td >
															<asp:Label CssClass="f8" Runat="server" id="lblAssociados">Mostrar:&nbsp;</asp:Label><br>
															<uc1:ComboBox Style="width:100%"  EnableValidation="false" id="cboRegistrosAssociados" CssClass="f8" runat="server"></uc1:ComboBox>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br>
									<table cellspacing=0 cellpadding=0 width=100% border=1 bordercolor=#003C6E>
										<tr>
											<td>
											<asp:DataGrid id="dtgAssociados" CssClass="f8" runat="server" AllowPaging="True" OnPageIndexChanged="dtgAssociados_doPaging" AllowSorting="True" PageSize="10" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
											<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
											<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
											<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
											<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											<Columns>
												<asp:TemplateColumn ItemStyle-Width=25>
												</asp:TemplateColumn>
												<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="CÓDIGO ITC" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
													<ItemTemplate>
														<a href="Proposta.aspx?IdAssociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>&IR=<%# ViewState("IncluirRenovacao")%>"><asp:Label ID=lblCodigo Runat=server ><%# Right("000000" & DataBinder.Eval(Container.DataItem, "Codigo"), 6)%></asp:Label></a>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="RazaoSocial" HeaderText="ASSOCIADO" HeaderStyle-Font-Bold=True></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="CNPJ" HeaderText="CNPJ" HeaderStyle-Font-Bold=True></asp:BoundColumn>
											</Columns>
											</asp:DataGrid>
											</td>
										</tr>
									</table>
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
