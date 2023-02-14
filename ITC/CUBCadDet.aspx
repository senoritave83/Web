<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CUBCadDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.CUBCadDet"%>
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
				<h3>Cadastro de Informativo</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastro</legend>
    				
    				<label>Título<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="reqTitulo" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator></label>
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtTitulo" MaxLength="100" Width="400"></asp:TextBox>
					<br />

					<label>Data<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="reqData" ControlToValidate="txtData"></asp:RequiredFieldValidator></label>
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtData" MaxLength="10" Width="100" onfocus="displayCalendar(document.forms[0].txtData,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtData,'dd/mm/yyyy',this)" />	<img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtData,'dd/mm/yyyy',this)"></asp:TextBox>
					<br />
					
					<label>Descrição<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate="txtReportagem"></asp:RequiredFieldValidator></label>
					<asp:TextBox TextMode="MultiLine" Columns="100" Rows="40" CssClass="f8" Runat="server" ID="txtReportagem" MaxLength="8000" Width="100%"></asp:TextBox>
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
							<input type=button value=Voltar onclick='location.href="cubcad.aspx"'/>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>