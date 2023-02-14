<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowUpEmpresaDetMini.aspx.vb" Inherits="ITC.FollowUpEmpresaDetMini"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body>
		<div id="Tudo" runat="server">
			<form id="frmCad" runat="server">
				<h3>Cadastro de SIG - Empresa</h3>
				<fieldset style="PADDING-BOTTOM: 0px; PADDING-LEFT: 90px; PADDING-RIGHT: 90px; PADDING-TOP: 0px">
					<legend>Cadastro de Follow-Up</legend>
					<label>Empresa:</label>
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
			</form>
			<uc1:rodape id="Rodape" runat="server"></uc1:rodape>
            <br class="clear">
        </div>
	</body>
</HTML>
