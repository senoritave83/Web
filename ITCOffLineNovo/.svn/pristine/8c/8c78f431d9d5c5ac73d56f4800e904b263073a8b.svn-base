<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Usuarios.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Usuarios" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="450" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#f7f7d8" cellspacing="0">
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
						<b><font face="Verdana, Arial, Helvetica, sans-serif" color="#000000" size="3">CADASTRO 
								DE USUÁRIOS</font></b>
						<br>
						<br>
						<table width="96%" border="0" bgcolor="#f7f7d8">
							<tr>
								<td width="20%" colspan="5" align="middle">
									<font face="Verdana" size="2"><b>FILTROS</b></font>
								</td>
							</tr>
						</table>
						<table width="96%" border="0" bgcolor="#f7f7d8">
							<tr>
								<td align="right">
									<font face="Verdana" size="2"><b>Nome</b></font>
								</td>
								<td align="left">
									<asp:TextBox Font-Name="verdana" Font-Size="10" ID="txtNome" Runat="server" MaxLength="50" Width="374px"></asp:TextBox>
								</td>
								<td align="right">
									<font face="Verdana" size="2"><b>Login</b></font>
								</td>
								<td align="left">
									<asp:TextBox Font-Name="verdana" Font-Size="10" ID="txtLogin" Runat="server" MaxLength="20"></asp:TextBox>
								</td>
								<td align="left">
									<asp:Button ID="btnProcurar" Runat="server" Text="Procurar"></asp:Button>
								</td>
							</tr>
						</table>
						<br>
						<asp:DataGrid id="dtgUsuarios" runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="8" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="96%">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" Font-Name="verdana" Font-Size="10" ForeColor="#000000" BackColor="#f7f7d8"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#f7f7d8"></FooterStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-Font-Bold=True ItemStyle-Font-Name=verdana ItemStyle-Font-Size=10  HeaderStyle-Width=40% HeaderText="Nome">
									<ItemTemplate>
										<a href="UsuariosDet.aspx?Codigo=<%# DataBinder.Eval(Container.DataItem, "USU_USUARIO_INT_PK")%>"><asp:Label ID=lblCodigo Runat=server Font-Bold=True ForeColor=#000000 Font-Size=10><%# DataBinder.Eval(Container.DataItem, "USU_USUARIO_CHR")%></asp:Label> </a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-Font-Bold=True ItemStyle-Font-Name=verdana ItemStyle-Font-Size=10 HeaderStyle-Width=40%   HeaderText="Empresa">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "RAZAOSOCIAL")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-Font-Bold=True ItemStyle-Font-Name=verdana ItemStyle-Font-Size=10 HeaderStyle-Width=20%   HeaderText="Login">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "USU_LOGIN_CHR")%>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
						<br>
						<br>
						<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
