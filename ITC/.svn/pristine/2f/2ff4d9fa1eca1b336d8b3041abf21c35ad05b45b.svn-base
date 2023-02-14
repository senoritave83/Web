<%@ Page  ValidateRequest="false" Language="vb" AutoEventWireup="false" Codebehind="EventosCadDet.aspx.vb"  Inherits="ITC.EventosCadDet"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Cursos/Eventos</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastros</legend>
    				
    				<label>Título<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqTitulo" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator></label>
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtTitulo" MaxLength="100" Width="400"></asp:TextBox>
					<br />
					
					<label>Data Inicial<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqDataInicial" ControlToValidate="txtDataInicial"></asp:RequiredFieldValidator></label>
					<asp:TextBox Width="100" Runat="server" ID="txtDataInicial" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" style="cursor:pointer;" MaxLength="10"></asp:TextBox>
					<br />
					
					<label>Data Final<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqDataFinal" ControlToValidate="txtDataFinal"></asp:RequiredFieldValidator></label>
					<asp:TextBox Width="100" Runat="server" ID="txtDataFinal" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" style="cursor:pointer;" MaxLength="10"></asp:TextBox>
					<br />
					
					<label>Descrição do Evento<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqDescricaoEvento" ControlToValidate="txtDescricaoEvento"></asp:RequiredFieldValidator></label>
					<asp:TextBox TextMode="MultiLine" Columns="100" Rows="20" CssClass="f8" Runat="server" ID="txtDescricaoEvento" MaxLength="500" Width="100%"></asp:TextBox>
					<br />
				</fieldset>
								
				<table>
					<tr>
						<td>
							<asp:Button Runat=server ID="btnIncluir" Text="Incluir"></asp:Button>		
						</td>
						<td>
							<asp:Button Runat=server ID="btnApagar" Text="Apagar"></asp:Button>		
						</td>
						<td>
							<asp:Button Runat=server ID="btnGravar" Text="Gravar"></asp:Button>		
						</td>
						<td>
							<input type=button value=Voltar onclick='location.href="eventoscad.aspx"'/>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>