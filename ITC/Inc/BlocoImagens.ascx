<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BlocoImagens.ascx.vb" Inherits="ITC.BlocoImagens" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%">
	<tr>
		<td align="middle" width="49%" valign="top">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td colspan="3">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD class="titulo_menu" noWrap width="30%" bgColor="#003c6e" align="middle" rowSpan="2">&nbsp;CURSOS 
										E EVENTOS
									</TD>
									<TD vAlign="top" bgColor="#003c6e" rowSpan="2"><IMG src="imagens/canto_bn2.gif">
									</TD>
									<TD width="100%" bgColor="#ffffff" height="3">&nbsp;
									</TD>
								</TR>
								<TR>
									<TD width="100%" bgColor="#003c6e" height="3"></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="3" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" valign="top" bgcolor="#ffffff"><table width="100%" height="100%" cellpadding="0" cellspacing="5" border="0">
							<tr>
								<td valign="top" align="middle" class="f8">
									<asp:DataList CssClass="f8" ID="dtlEventos" Width="100%" BorderStyle="None" Runat="server" RepeatColumns="1" RepeatDirection="Vertical">
										<ItemStyle Font-Bold="True" BackColor="#FFFFFF"></ItemStyle>
										<AlternatingItemStyle Font-Bold="True" BackColor="#EFEFEF"></AlternatingItemStyle>
										<ItemTemplate>
											<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataInicial")), 4)%>
											a
											<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataFinal")), 4)%>
											<br>
											<%# DataBinder.Eval(Container.DataItem, "NomeEvento")%>
										</ItemTemplate>
									</asp:DataList><br>
								</td>
							</tr>
							<tr>
								<td align="right">
									<a href='Eventos.aspx'><font class="f8">Veja mais eventos...</font></a>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
		<td align="middle" width="2%" valign="top" nowrap>
		</td>
		<td align="middle" width="49%" valign="top">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td colspan="3">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD class="titulo_menu" noWrap width="30%" bgColor="#003c6e" align="middle" rowSpan="2">&nbsp;ÍNDICES 
										DO ITC
									</TD>
									<TD vAlign="top" bgColor="#003c6e" rowSpan="2"><IMG src="imagens/canto_bn2.gif">
									</TD>
									<TD width="100%" bgColor="#ffffff" height="3">&nbsp;
									</TD>
								</TR>
								<TR>
									<TD width="100%" bgColor="#003c6e" height="3"></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="3" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" valign="top" bgcolor="#ffffff"><table width="100%" height="100%" cellpadding="0" cellspacing="5" border="0">
							<tr>
								<td valign="top" class="f8">
									<table width="100%" align="center">
										<tr>
											<td align="middle"><img runat="server" id="imgIndice" width="266" height="147" src='imagens/grafico.jpg'></td>
										</tr>
										<tr>
											<td align="middle"><asp:Label ID="lblDescricaoIndice" Runat="server" CssClass="F8">1000 Obras no Brasil desde agosto de 2002</asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
