<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowUpAssocDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.FollowUpAssocDet"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<div id="Tudo">
			<uc1:top id="Top1" runat="server"></uc1:top>
			<form id="frmCad" runat="server">
				<h3>Cadastro de SIG - Associado</h3>
				<fieldset style="PADDING-BOTTOM:0px; PADDING-LEFT:90px; PADDING-RIGHT:0px; PADDING-TOP:0px">
					<legend>Cadastro de Follow-Up</legend>
					<label>Empresa:</label>
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
					<asp:Button Runat="server" ID="BotaoVoltar" Text="Voltar"></asp:Button>
					<input type="hidden" runat="server" id="hdItemExcluir" NAME="hdItemExcluir">
					<br>
					<br>
				</fieldset>
			</form>
			<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape>
			<br class="clear">
		</div>
	</body>
</HTML>
