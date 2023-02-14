<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelFObr.aspx.vb" Inherits="ITC.RelFObr" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
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
				var win = window.open('relfobrdet.aspx?' + p_URL, 'RelFolObr', 'width=800, height=600, top=100, left=100, scrollbars=1, toolbar=1');
			}
			function VerificarSel()
			{
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name = 'chkIdFollowUp') && (e.type=='checkbox'))
							{
								if (e.checked) return true;
							}
					}
				return false;
			}	
		</script>
	</head>
	
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
		
			<uc1:top id="Top1" runat="server"></uc1:top>
			
			<h3>Relatório de SIG's - Obras</h3>
    
			<form id="frmCad" runat="server">
				<div id="Relatorio-Form">
									
					<label>Nome da Obra</label>
					<asp:TextBox CssClass="inputG" ID="txtNomeAssociado" Runat="server" MaxLength="150" Width="350px"></asp:TextBox>
					<br /><br class="clear" />
			        
					<label>Nome do Relator</label>
					<asp:TextBox CssClass="inputG" ID="txtNomeVendedor" Runat="server" MaxLength="150" Width="350px"></asp:TextBox>
					<br /><br class="clear" />
					
					<label>Prioridade</label>
					<asp:DropDownList id="cboPrioridade" runat="server"></asp:DropDownList><br>
					<br class="clear">
			        
			        <label>Cadastrado de</label>
					<div class='FloatLeft'><p><asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" onfocus="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)" CssClass="inputP" ID="txtDataIni" Runat="server" MaxLength="10" Width="80px"></asp:TextBox><img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataIni,'dd/mm/yyyy',this)" style="cursor:pointer;margin-top:6px;margin-left:3px;" ></p></div>
				    
					<label class="ate">até</label>
					<div class='FloatLeft'><p><asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" onfocus="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)" CssClass="inputP" ID="txtDataFin" Runat="server" MaxLength="10" Width="80px"></asp:TextBox><img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFin,'dd/mm/yyyy',this)" style="cursor:pointer;margin-top:6px;margin-left:3px;"></p></div> 
					<br class="clear" />
			        
					<label>Agendamento de</label>
					<div class='FloatLeft'><asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" onfocus="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)" CssClass="inputP" ID="txtAgeIni" Runat="server" MaxLength="10" Width="80px"></asp:TextBox><img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtAgeIni,'dd/mm/yyyy',this)" style="cursor:pointer;margin-top:6px;margin-left:3px;"></div> 
			        
					<label class="ate">até</label>
					<div class='FloatLeft'><asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" onfocus="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)" CssClass="inputP" ID="txtAgeFin" Runat="server" MaxLength="10" Width="80px"></asp:TextBox><img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtAgeFin,'dd/mm/yyyy',this)" style="cursor:pointer;margin-top:6px;margin-left:3px;"></div> 
					<br /><br class="clear" />
			        
					<label>Contendo a Descrição</label>
					<asp:TextBox CssClass="inputG" ID="txtDescricao" Runat="server" MaxLength="100" Width="350"></asp:TextBox>
					<br /><br />
					<label>&nbsp;</label>
    				<input type=button onClick="javascript:showReport();" value="Gerar Relatório"></asp:Button>
				
				</div>
			</form>
			<br class="clear" />
   			
			<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
			
		</div>
	</body>
</HTML>