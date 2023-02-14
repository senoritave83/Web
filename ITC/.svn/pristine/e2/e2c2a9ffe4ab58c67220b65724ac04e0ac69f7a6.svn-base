<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Bloco3.ascx.vb" Inherits="ITC.Bloco3" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table border="0" width="100%">
	<TR>
		<TD noWrap><SPAN class="hometitulo">Cursos e Eventos</SPAN></TD>
	</TR>
	<tr>
		<td>
			<asp:DataList ID="dtlEventos" Width="100%" BorderStyle="None" Runat="server" RepeatColumns="1" RepeatDirection="Vertical">
				<ItemTemplate>
					<img src="imagens/seta_azul.gif" border="0">&nbsp; <SPAN class="LinkGeral">
						<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataInicial")), 4)%>
						a
						<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataFinal")), 4)%>
						<br>
						<%# DataBinder.Eval(Container.DataItem, "NomeEvento").toUpper()%>
					</SPAN>
					<br>
					<br> 
				</ItemTemplate>
			</asp:DataList>
		</td>
	</tr>
	<tr>
		<TD align="right"><a href='eventos.aspx'><font size="1">MAIS EVENTOS...</font></a>&nbsp;<img src="imagens/seta_azul.gif" border="0"></TD>
	</tr>
</table>
