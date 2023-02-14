<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelFEmp.aspx.vb" Inherits="ITC.RelFEmp"%>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
		<script language="javascript">	
			function showReport()
			{
				var p_URL = 'na=' + document.frmCad.txtNomeAssociado.value + 
							'&nv=' + document.frmCad.txtNomeVendedor.value + 
							'&ai=' + document.frmCad.txtAgeIni.value + 
							'&af=' + document.frmCad.txtAgeFin.value + 
							'&di=' + document.frmCad.txtDataIni.value + 
							'&df=' + document.frmCad.txtDataFin.value +
							'&ds=' + document.frmCad.txtDescricao.value +
							'&pr=' + document.frmCad.cboPrioridade[document.frmCad.cboPrioridade.selectedIndex].value;
							//alert(document.frmCad.cboPrioridade[document.frmCad.cboPrioridade.selectedIndex].value)
				var win = window.open('relfempdet.aspx?' + p_URL, 'RelFolEmp', 'width=800, height=600, top=100, left=100, scrollbars=1, toolbar=1');
			}
		</script>
	</HEAD>
	<body onload="vertical();horizontal();">
		<div id="Tudo"><uc1:top id="Top1" runat="server"></uc1:top>
			<h3>Relatório de SIG's - Empresas</h3>
			<form id="frmCad" runat="server">
				<div id="Relatorio-Form"><label>Nome da 
Empresa</label>
					<asp:textbox id="txtNomeAssociado" Width="350px" MaxLength="150" Runat="server" CssClass="inputG"></asp:textbox><br>
					<br class="clear">
					<label>Nome do Relator</label>
					<asp:textbox id="txtNomeVendedor" Width="350px" MaxLength="150" Runat="server" CssClass="inputG"></asp:textbox><br>
					<br class="clear">
					<label>Prioridade</label>
					<asp:DropDownList id="cboPrioridade" runat="server"></asp:DropDownList><br>
					<br class="clear">
					<label>Cadastrado de</label>
					<div class="FloatLeft">
						<p><asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataIni"
								onfocus="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)"
								Width="80px" MaxLength="10" Runat="server" CssClass="inputP"></asp:textbox><IMG style="MARGIN-TOP: 6px; MARGIN-LEFT: 3px; CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)"
								src="img/ico_calendario.jpg"></p>
					</div>
					<label class="ate">até</label>
					<div class="FloatLeft">
						<p><asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtDataFin"
								onfocus="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)"
								Width="80px" MaxLength="10" Runat="server" CssClass="inputP"></asp:textbox><IMG style="MARGIN-TOP: 6px; MARGIN-LEFT: 3px; CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)"
								src="img/ico_calendario.jpg"></p>
					</div>
					<br class="clear">
					<label>Agendamento de</label>
					<div class="FloatLeft"><asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtAgeIni"
							onfocus="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)"
							Width="80px" MaxLength="10" Runat="server" CssClass="inputP"></asp:textbox><IMG style="MARGIN-TOP: 6px; MARGIN-LEFT: 3px; CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)"
							src="img/ico_calendario.jpg"></div>
					<label class="ate">até</label>
					<div class="FloatLeft"><asp:textbox onblur="VerificaData(this);" onkeydown="FormataData(this, event);" id="txtAgeFin"
							onfocus="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)"
							Width="80px" MaxLength="10" Runat="server" CssClass="inputP"></asp:textbox><IMG style="MARGIN-TOP: 6px; MARGIN-LEFT: 3px; CURSOR: pointer" onclick="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)"
							src="img/ico_calendario.jpg"></div>
					<br>
					<br class="clear">
					<label>Contendo a 
Descrição</label>
					<asp:textbox id="txtDescricao" Width="350" MaxLength="100" Runat="server" CssClass="inputG"></asp:textbox><br>
					<br>
					<label>&nbsp;</label>
					<input type="button" onClick="javascript:showReport();" value="Gerar Relatório"></ASP:BUTTON>
				</div>
			</form>
			<br class="clear">
			<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape></div>
	</body>
</HTML>
