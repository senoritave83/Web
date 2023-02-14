<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControleAssociadosAcesso.aspx.vb"  ValidateRequest="False" Inherits="ITC.ControleAssociadosAcesso"%>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<div id="Tudo">
			<form id="frmCad" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Controle de Associados</h3>
				<fieldset>
					<legend>Filtro de 
Cadastros</legend>
					<table>
						<tr>
							<td><label>Associado</label>
								<asp:textbox id="txtAssociado" Runat="server" Width="250" MaxLength="50" CssClass="inputG"></asp:textbox></td>
							<td><label>Status</label>
								<asp:DropDownList id="cboStatus" runat="server" DataValueField="IdStatus" DataTextField="DescricaoStatus"></asp:DropDownList></td>
						</tr>
					</table>
					
					<br>
					<label>Data Inicial</label>
					<asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataInicio"
						onfocus="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)"
						Runat="server" Width="100" MaxLength="10" CssClass="inputP"></asp:textbox>
					<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)"
						src="img/ico_calendario.jpg" MaxLength="10">
					<br>
					<label>Data Final</label>
					<asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataFim"
						onfocus="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)"
						Runat="server" Width="100" MaxLength="10" CssClass="inputP"></asp:textbox>
					<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)"
						src="img/ico_calendario.jpg" MaxLength="10">
					<br>
					<br>
					<label>&nbsp;</label>
					<table>
						<tr>
							<td><asp:button id="btnPesquisar" runat="server" Text="Pesquisar"></asp:button></td>
							<td><asp:button id="btnNovaPesquisa" runat="server" Text="Nova Pesquisa"></asp:button></td>
							<td><label>Ordenar por:</label>
							</td>
							<td><uc1:combobox id="cboOrdenar" runat="server"></uc1:combobox></td>
						</tr>
					</table>
				</fieldset>
				<table id="tblResultados" width="100%" runat="server">
					<tr>
						<td width="100%" colSpan="2" align="center"><asp:datagrid id="dtgResultados" runat="server" width="100%" AutoGenerateColumns="False" GridLines="none"
								CellPadding="3" BackColor="White" BorderWidth="0" BorderStyle="Outset" BorderColor="#999999" AllowSorting="True" OnPageIndexChanged="doPaging"
								AllowPaging="True" PageSize="15">
								<HeaderStyle BackColor="#999999" ForeColor="#FFFFFF"></HeaderStyle>
								<FooterStyle BackColor="#ffffff" ForeColor="#FFFFFF"></FooterStyle>
								<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<b>Associado</b>">
										<ItemTemplate>
											<font Color="#000000" face="verdana" Size="2">
												<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
											</font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<b>Nome do Usuário</b>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "NOMEUSUARIO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="20%" HeaderText="<b>Dias sem Acesso</B>">
										<ItemTemplate>
											<%# Iif(DataBinder.Eval(Container.DataItem, "DATAACESSO")=0, "Nunca acessou o site", DataBinder.Eval(Container.DataItem, "DATAACESSO") & " Dias")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" PageButtonCount="10" ForeColor="white" BackColor="#999999"
									Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
				</table>
				<table id="tblNav" width="100%" runat="server">
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="nav" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>
			</form>
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape></div>
	</body>
</HTML>
