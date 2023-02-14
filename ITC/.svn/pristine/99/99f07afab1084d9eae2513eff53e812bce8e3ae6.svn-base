<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowupObraDetMini.aspx.vb" Inherits="ITC.FollowUpObraDetMini"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body>
		<div id="Tudo" runat="server">
			<form id="frmCad" runat="server">
				<h3>Cadastro de SIG - Obra</h3>
				<fieldset style="PADDING-BOTTOM: 0px; PADDING-LEFT: 90px; PADDING-RIGHT: 90px; PADDING-TOP: 0px">
					<legend>Cadastro de Follow-Up</legend>
					<label>Obra:</label>
					<p style="MARGIN: 6px 0px -6px"><asp:label id="lblEmpresa" Runat="server"></asp:label></p>
					<br>
					<label>Data:</label>
					<p style="MARGIN: 6px 0px -6px"><asp:label id="lblData" Runat="server"></asp:label></p>
					<br>
					<table >
						<tr>
							<td nowrap>
								<label>Agendar Para:</label>
								<asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataAgenda"
								onfocus="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)"
								Runat="server" CssClass="inputP" Width="73" MaxLength="10"></asp:textbox>
								<IMG style="CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataAgenda,'dd/mm/yyyy',this)"
								src="img/ico_calendario.jpg" MaxLength="10">
							</td>
							<td nowrap>
								<label>Prioridade:</label>
								<p style="MARGIN: 6px 0px 6px"><uc1:ComboBox id="cboPrioridade" runat="server"></uc1:ComboBox></p>
							</td>
                            <td nowrap>
								<label>Status:</label>
								<p style="MARGIN: 6px 0px 6px"><uc1:ComboBox id="cboStatusSIG" runat="server"></uc1:ComboBox>
							</td>
						</tr>
					</table>
					<br>
					<label>Descrição:</label>
					<asp:textbox id="txtDescricao" onkeyup="checkMessageLength(this, true)" Runat="server" CssClass="textP"
						MaxLength="1000" onChange="checkMessageLength(this, true)" Columns="100" Rows="5" TextMode="MultiLine"></asp:textbox>
					<br>
					<br>
					<label>&nbsp;</label>
					<asp:button id="BotaoAtualizar" Runat="server" Text="Gravar"></asp:button>
					<asp:button id="btnNovoFollowup" Runat="server" Text="Novo"></asp:button>
					<asp:button id="BotaoVoltar" Runat="server" Text="Fechar"></asp:button>
					<input id="hdItemExcluir" type="hidden" name="hdItemExcluir" runat="server">
				</fieldset>
				<br>
				<A id="lnkRegistros" href="#" runat="server">
					<h3>Exibir/Esconder Registros Anteriores</h3>
				</A>
				<div id="divRegistros" runat="server" visible="false"><asp:datagrid id="dtlRegistros" runat="server" CssClass="f9" width="100%" AutoGenerateColumns="False"
						GridLines="none" CellPadding="3" BackColor="White" BorderStyle="None" BorderColor="#999999" PageSize="10" AllowSorting="True" AllowPaging="true">
						<HeaderStyle CssClass="Tit"></HeaderStyle>
						<FooterStyle BackColor="#003C6E" ForeColor="#FFFFFF"></FooterStyle>
						<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
						<SelectedItemStyle BackColor="#0000ff"></SelectedItemStyle>
						<PagerStyle HorizontalAlign="Center" PageButtonCount="15" ForeColor="Black" BackColor="#999999"
							Mode="NumericPages"></PagerStyle>
						<Columns>
							<asp:TemplateColumn ItemStyle-Width="45%" HeaderText="<b>Descrição</b>">
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
					</asp:datagrid></div>
			</form>
			<uc1:rodape id="Rodape" runat="server"></uc1:rodape></div>
		<div id="Falha" runat="server" visible="false"><label>Erro: Você não tem permissão para cadastrar SIG's nesta 
obra.</label>
		</div>
	</body>
</HTML>
