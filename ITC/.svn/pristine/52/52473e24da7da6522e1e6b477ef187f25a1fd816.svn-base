<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Eventos.aspx.vb"  ValidateRequest="False" Inherits="ITC.Eventos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#809eb7" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle"> <br>
						<img src="Imagens/TituloEventos.jpg" border="0"><br>
						<br>
						<asp:DataList Runat="server" CssClass="f10" ID="dtlEventos" RepeatColumns="1" RepeatDirection="Horizontal" ItemStyle-Width="33%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<table width="100%">
									<tr>
										<td bgcolor="#FF9933">
											<font class="f10" color="#FFFFFF"><b>
													<%# DataBinder.Eval(Container.DataItem, "NomeEvento")%>
												</b></font>
										</td>
									</tr>
									<tr>
										<td>
											<font class="f10"><b>
													<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataInicial")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataInicial")), 4)%>
													a
													<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DataFinal")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DataFinal")), 4)%>
												</b></font>
										</td>
									</tr>
									<tr>
										<td>
											<font class="f10">
												<%# DataBinder.Eval(Container.DataItem, "DescricaoEvento")%>
											</font>
										</td>
									</tr>
								</table>
								<br>
							</ItemTemplate>
						</asp:DataList>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
