<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PermissaoRegiaoGestor.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.PermissaoRegiaoGestor" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="96%" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
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
			<tr>
				<td vAlign="top" align="middle" width="95%">
					<form id="frmCad" runat="server">
						<img src="imagens/TituloPermissaoGestor.jpg" border="0">
						<br>
						<br>
						<table id="Permissao" runat="server" width="96%" Border="0">
							<tr>
								<td class="f8" Width="10%" align=center >Gestor:
									<asp:Label ID="lblGestor" Runat="server" Font-Bold=True CssClass="f8"></asp:Label>
								</td>
							</tr>
						</table>
						<table id="Table1" runat="server" width="96%" Border="0">
							<tr>
								<td ColSpan="6">&nbsp;</td>
							</tr>
							<tr>
								<td Align="Center" ColSpan="6" Width="96%">
									<tr>
										<td align="center" colspan=6>
											<asp:datagrid CssClass="f8" id="dtgGrid" runat="server" AutoGenerateColumns="False" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999" width="30%" DataKeyField="idregiao">
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle ForeColor="White" BackColor="#003366"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<AlternatingItemStyle ForeColor="Black" BackColor="#FFFFFF"></AlternatingItemStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="Região" HeaderStyle-Font-Bold=True ItemStyle-Width="75%">
														<ItemTemplate>
															<font class=f8 color="<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "marcado")= 0, "#FF0000", "#000000") %>"><%# DataBinder.Eval(Container.DataItem, "descricaoregiao")%></font>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Habilitar" HeaderStyle-Font-Bold=True ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
														<ItemTemplate>
															<asp:CheckBox Runat="server" id="chkPermissao" Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "marcado")=1, true, false)%>'>
															</asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<br>
										</td>
									</tr>
									<tr>
										<td ColSpan="6" Align="center">
											<asp:ImageButton CssClass="f8" ID="btnVoltar" Runat="server"  ImageUrl="Imagens/botaovoltar.gif" BorderStyle=None></asp:ImageButton>
											<asp:ImageButton CssClass="f8" Runat="server" ID="btnSalvarPermissoes" ImageUrl="Imagens/BotaoSalvarPermissoes.gif" BorderStyle="None" />
										</td>
									</tr>
								</td>
							</tr>
						</table>
						<br>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
