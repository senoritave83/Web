<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControleAssociados.aspx.vb"  ValidateRequest="False" Inherits="ITC.ControleAssociados"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<div id="Tudo">
			<form id="Form1" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Monitoramento de Associados</h3>
				<fieldset>
					<legend>Filtro de Cadastros</legend>
					<label>Associado</label>
					<asp:TextBox CssClass="inputG" ID="txtAssociado" MaxLength="50" Width="250" Runat="server"></asp:TextBox>
					<br>
					<br>
					<label>Data Inicial</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10"
						Width="100" Runat="server" ID="txtDataInicio" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)"
						onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" />
					<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)"
						src="img/ico_calendario.jpg" MaxLength="10">
					<br>
					<label>Data Final</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10"
						Width="100" Runat="server" ID="txtDataFim" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)"
						onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" />
					<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)"
						src="img/ico_calendario.jpg" MaxLength="10">
					<br>
					<br>
					<label>&nbsp;</label>
					<asp:button Text="Pesquisar" id="btnPesquisar" runat="server" />
					<asp:button Text="Nova Pesquisa" id="btnNovaPesquisa" runat="server" />
				</fieldset>
				<table width="100%" runat="server" id="tblResultados">
					<tr>
						<td width="100%" colspan="2" align="center">
							<asp:DataGrid PageSize="15" CssClass="f8" id="dtgResultados" AllowPaging="true" OnPageIndexChanged="doPaging"
								runat="server" BorderColor="#999999" BorderStyle="Outset" BorderWidth="0" BackColor="White"
								CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor="#999999" ForeColor="#FFFFFF"></HeaderStyle>
								<FooterStyle BackColor="#ffffff" ForeColor="#FFFFFF"></FooterStyle>
								<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width="25" HeaderStyle-Font-Bold="True">
										<ItemTemplate>
											<a href='controleassociadosdet.aspx?idhistorico=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDHISTORICO"))%>'>
												<img src='img/ico_status_ok.gif' border="0"></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="20%" HeaderStyle-Font-Bold="True" HeaderText="Data do Acesso">
										<ItemTemplate>
											<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "DATAACESSO")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "DATAACESSO")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "DATAACESSO")), 4)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderStyle-Font-Bold="True" HeaderText="Associado">
										<ItemTemplate>
											<a href='controleassociadosdet.aspx?idhistorico=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDHISTORICO"))%>'>
												<font Color="#000000" face="verdana" Size="2">
													<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
												</font></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderStyle-Font-Bold="True" HeaderText="Nome do Usuário">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "NOMEUSUARIO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="20%" HeaderStyle-Font-Bold="True" HeaderText="IP Utilizado">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "IPACESSO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" PageButtonCount="10" ForeColor="white" BackColor="#999999"
									Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<table width="100%" id="tblNav" runat="server">
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="nav" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>
			</form>
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
	</body>
</HTML>
