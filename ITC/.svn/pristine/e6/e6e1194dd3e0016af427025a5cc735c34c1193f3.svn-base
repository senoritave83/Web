<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowUpAssocDetMini.aspx.vb" Inherits="ITC.FollowUpAssocDetMini"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<div id="Tudo" runat="server">
			<form id="frmCad" runat="server">
				<h3>Cadastro de SIG - Associados</h3>
				<fieldset style="PADDING-BOTTOM:0px; PADDING-LEFT:90px; PADDING-RIGHT:0px; PADDING-TOP:0px">
					<legend>Cadastro de Follow-Up</legend>
					<label>Associado:</label>
					<p style="MARGIN:6px 0px -6px"><asp:Label Runat="server" ID="lblEmpresa"></asp:Label></p>
					<br>
					<label>Data:</label>
					<p style="MARGIN:6px 0px -6px"><asp:Label Runat="server" ID="lblData"></asp:Label></p>
					<br>
					<table >
						<tr>
							<td>
								<label>Agendar Para:</label>
								<asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataAgenda"
								onfocus="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)"
								Runat="server" CssClass="inputP" Width="73" MaxLength="10"></asp:textbox>
								<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)"
								src="img/ico_calendario.jpg" MaxLength="10">
							</td>
							<td>
								<label>Prioridade:</label>
								<p style="MARGIN: 6px 0px 6px"><uc1:ComboBox id="cboPrioridade" runat="server"></uc1:ComboBox>
							</td>
						</tr>
					</table>
					<br>
					<label>Descrição:</label>
					<asp:TextBox TextMode="MultiLine" Rows="5" Columns="100" Runat="server" ID="txtDescricao" CssClass="textP"
						MaxLength="1000" onChange="checkMessageLength(this, true)" onKeyUp="checkMessageLength(this, true)"></asp:TextBox>
					<br>
					<br>
					<label>&nbsp;</label>
					<asp:Button Runat="server" ID="BotaoAtualizar" Text="Gravar"></asp:Button>
					<asp:Button Runat="server" ID="btnNovoFollowup" Text="Novo"></asp:Button>
					<asp:Button Runat="server" ID="BotaoVoltar" Text="Fechar"></asp:Button>
					<input type="hidden" runat="server" id="hdItemExcluir" NAME="hdItemExcluir">
				</fieldset>
				<br>
				<a href="#" id="lnkRegistros" runat="server">
					<h3>Exibir/Esconder Registros Anteriores</h3>
				</a>
				<div id="divRegistros" runat="server" visible="false">
					<asp:DataGrid CssClass="f9" id="dtlFollowUP" runat="server" AllowPaging="True" AllowSorting="True"
						PageSize="10" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none"
						AutoGenerateColumns="False" width="100%">
						<HeaderStyle CssClass="Tit"></HeaderStyle>
						<FooterStyle BackColor="#003C6E" ForeColor="#FFFFFF"></FooterStyle>
						<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
						<SelectedItemStyle BackColor="#0000ff"></SelectedItemStyle>
						<PagerStyle HorizontalAlign="Center" PageButtonCount="15" ForeColor="Black" BackColor="#999999"
							Mode="NumericPages"></PagerStyle>
						<Columns>
							<asp:TemplateColumn ItemStyle-Width="50%" HeaderText="<b>Descrição</b>">
								<ItemTemplate>
									<font class="f8">
										<%# DataBinder.Eval(Container.DataItem, "DESCRICAO")%>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20%" HeaderText="<b>Relator</b>">
								<ItemTemplate>
									<font class="f8">
										<%# DataBinder.Eval(Container.DataItem, "RELATOR")%>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="15%" HeaderText="<b>Data</b>">
								<ItemTemplate>
									<font class="f8">
										<%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "Data")), 4) & " " & Right("00" & Hour(DataBinder.Eval(Container.DataItem, "Data")), 2) & ":" & Right("00" & Minute(DataBinder.Eval(Container.DataItem, "Data")), 2)%>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="15%" HeaderText="<b>Agendamento</b>">
								<ItemTemplate>
									<font class="f8">
										<%# DataBinder.Eval(Container.DataItem, "DataAgenda") %>
									</font>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
					</asp:DataGrid>
				</div>
			</form>
			<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape>
		</div>
		<div id="Falha" visible="false" runat="server">
			<label>Erro: Você não tem permissão para cadastrar SIG's neste associado.</label>
		</div>
	</body>
</HTML>
