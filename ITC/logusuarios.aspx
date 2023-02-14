<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="logusuarios.aspx.vb"  ValidateRequest="False" Inherits="ITC.logusuarios"%>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="450" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#F1F1F1" cellspacing="0">
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
						<img src='imagens/TituloLogUsuarios.jpg' border="0">
						<br>
						<table cellspacing="0" cellpadding="0" width="150" border="1" bordercolor="#003c6e">
							<tr>
								<td>
									<table cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor="#003c6e">
										<tr>
											<td width="20%" colspan="5" align="middle">
												<asp:label Runat="server" CssClass="f8" ForeColor="#FFFFFF" ID="Label4">
													<strong>FILTROS</strong></asp:label>
											</td>
										</tr>
									</table>
									<table width="100%" border="0" bgcolor="#ffffff">
										<tr>
											<td align="right" nowrap>
												<asp:label Runat="server" CssClass="f8" ID="Label2">Usuário</asp:label>
											</td>
											<td align="left" width="80%">
												<asp:TextBox CssClass="f8" ID="txtUsuario" Runat="server" MaxLength="20"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td align="right" nowrap>
												<asp:label Runat="server" CssClass="f8" ID="Label1">Data Inicial</asp:label>
											</td>
											<td align="left" width="80%">
												<asp:TextBox CssClass="f8" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" ID="txtDataInicial" Runat="server" MaxLength="10"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td align="right" nowrap>
												<asp:label Runat="server" CssClass="f8" ID="Label3">Data Final</asp:label>
											</td>
											<td align="left" width="80%">
												<asp:TextBox CssClass="f8" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" ID="txtDataFinal" Runat="server" MaxLength="10"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td colspan="2" align="middle" width="100%">
												<asp:ImageButton BorderStyle="None" ImageUrl="imagens/botaook.gif" CssClass="f8" ID="btnProcurar" Runat="server"></asp:ImageButton>
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
									<asp:DataGrid CssClass="f8" id="dtgLogUsuarios" runat="server" AllowPaging="true" AllowSorting="True" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
										<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
										<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
										<Columns>
											<asp:TemplateColumn ItemStyle-Width=25 HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<img src='imagens/bolaverde.gif' border=0 >
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="USUÁRIO" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "Usuario")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="DATA" HeaderText="DATA" HeaderStyle-Font-Bold="True"></asp:BoundColumn>
											<asp:BoundColumn DataField="ACAO" HeaderText="AÇÃO" HeaderStyle-Font-Bold="True"></asp:BoundColumn>
										</Columns>
										<PagerStyle Visible=False></PagerStyle>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
						<br><br>
						<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao><br>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
	</body>
</HTML>
