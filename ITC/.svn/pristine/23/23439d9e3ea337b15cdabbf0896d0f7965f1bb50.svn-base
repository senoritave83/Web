<%@ Page  ValidateRequest="false" Language="vb" AutoEventWireup="false" Codebehind="DicasDet.aspx.vb" Inherits="ITC.DicasDet"%>
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
				<h3>Cadastro de Dica</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastro</legend>
    				
    				<label>Título<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqTitulo" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator></label>
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtTitulo" MaxLength="100" Width="400"></asp:TextBox>
					<br />
					
					<!--<label>Status</label>-->
					<asp:Label Visible=False CssClass="inputG" Runat="server" ID="lblStatus"></asp:Label>
					<br />
					
					<label>Dica<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate="txtReportagem"></asp:RequiredFieldValidator></label>
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
							<input type=button value=Voltar onclick='location.href="dicas.aspx"'/>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>