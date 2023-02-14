<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProcurarEmpresa.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ProcurarEmpresa" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
			window.focus();
		</script>
		<table cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle" width="95%">
					<form id="frmCad" runat="server">
						<img src='imagens/TituloEmpresasParticipantes.jpg' border="0" width="384" height="40">
						<asp:table id="Table1" BackColor="#EFEFEF" runat="server" width="80%" BorderWidth="0">
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="4" CssClass="f8" ForeColor="#FFFFFF" Width="30%" Text="FILTRO"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Width="30%" HorizontalAlign="Right" Wrap="False">
									<asp:Label ID="Label5" Runat="server" CssClass="f8">Fantasia:</asp:Label>
								</asp:TableCell>
								<asp:TableCell Width="50%" HorizontalAlign="Left" Wrap="False" ColumnSpan="2">
									<asp:TextBox Width="90%" ID="txtBusca" Runat="server" CssClass="f8"></asp:TextBox>
								</asp:TableCell>
								<asp:TableCell Width="50%" HorizontalAlign="Left" Wrap="False">
									<asp:Button Runat="server" ID="btnProcurar" Text="Procurar" CssClass="f8"></asp:Button>
								</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<br>
						<br>
						<asp:table runat="server" width="90%" Height="250" id="Table2" BorderColor="black" BorderWidth="1">
							<asp:TableRow>
								<asp:TableCell Width="100%" HorizontalAlign="Center" Wrap="False" VerticalAlign="Top">
									<asp:DataGrid DataKeyField="Codigo" CssClass="f8" id="dtgEmpresas" runat="server" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" width="96%" OnItemCommand="SelItemProg">
										<HeaderStyle BackColor="#003C6E" ForeColor="#FFFFFF"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="<img src='imagens/unselect.jpg' width=20 height=20 border='0'>"></asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="FANTASIA">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "Fantasia")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="RAZÃO SOCIAL">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid>
								</asp:TableCell>
							</asp:TableRow>
						</asp:table><br>
						<br>
						<asp:Literal Runat="server" ID="Literal1" Text="" EnableViewState="False"></asp:Literal>
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
