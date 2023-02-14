<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ControleUsuariosDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.ControleUsuariosDet"%>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form id="frmCad" runat="server">
				<uc1:top id="Top1" runat="server"></uc1:top>
				
				<h3>Detalhes do Usuário</h3>
				<fieldset>
    				<legend>Detalhes do Usuario</legend>
					
					<label>Nome do Utilizador</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblAssociado"></asp:Label></p>
					<br class=clear />
					
					<label>Usuário Utilizado</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblUsuario"></asp:Label></p>
					<br class=clear />
					
					<label>Último Acesso</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblUltimoAcesso"></asp:Label></p>					
					<br class=clear />
					
					<label>Data de Acesso Gravada</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblDataAcesso"></asp:Label></p>				
					<br class=clear />
					
					<label>IP Utilizado</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblIP"></asp:Label></p>				
					<br class=clear />
					
					<label>Detalhes do Browser Utilizado</label>
						<p style="margin:6px 0 -6px 0"><asp:Label CssClass="f8" runat="server" Width="90%" ID="lblBrowser"></asp:Label></p>				
					<br class=clear /><br class=clear />
							
					<asp:Button CssClass="f8" Runat="server" ID="btnBloquearAcesso" Text="Bloquear Acesso"></asp:Button>
					<asp:Button CssClass="f8" Runat="server" ID="btnVoltar" Text="Voltar"></asp:Button>
   				</fieldset>
   				
			</form>
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>