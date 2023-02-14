<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Bloco2.ascx.vb" Inherits="ITC.Bloco2" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%" border="0">
	<TR>
		<TD noWrap><SPAN class="hometitulo">Notícias</SPAN></TD>
	</TR>
	<TR>
		<TD>
			<asp:Literal ID="ltScrollable" Visible="False" Runat="server"></asp:Literal>
			<asp:DataGrid BorderStyle="None" BorderWidth="0" ShowHeader="False" BackColor="#FFFFFF" CssClass="f8" AutoGenerateColumns="False" id="dtgSubTipos" runat="server">
				<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText=''>
						<ItemTemplate>
							<table cellspacing="0" border="0">
								<tr>
									<td valign=top><img src="imagens/seta_azul.gif" border="0"></td>
									<td><a href='noticiasdet.aspx?idnoticia=<%# DataBinder.Eval(Container.DataItem, "IDNOTICIA")%>' ><font class="LinkGeral"><%# DataBinder.Eval(Container.DataItem, "TITULO").ToUpper()%></font></a></td>
								</tr>
							</table>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</TD>
	</TR>
	<tr>
		<TD align="right"><a href='noticias.aspx'><font size="1">MAIS NOTÍCIAS...</font></a>&nbsp;<img src="imagens/seta_azul.gif" border="0"></TD>
	</tr>
</table>
