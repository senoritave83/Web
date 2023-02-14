<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AnaliseMensalDet.aspx.vb" Inherits="ITC.AnaliseMensalDet"%>
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
				<h3>Cadastro de "Análise Mensal"</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastro</legend>
    				
    				<b>Nome da Imagem</b> (ex.BannerVertical.jpg)<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqImagem" ControlToValidate="txtImagem"></asp:RequiredFieldValidator>
					<asp:TextBox CssClass="inputG" Runat="server" ID="lblImagem" MaxLength="100" Width="400"></asp:TextBox><br>
					<input type="file" runat="Server" id="txtImagem" size="80" NAME="txtImagem"/>
					<br /><br>
					<b>Link para Direcionamento</b> (URL)&nbsp;&nbsp;
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtLink" MaxLength="100" Width="400"></asp:TextBox>
					<br /><br>
					<b>Ativo</b> <asp:CheckBox Runat=server ID=chkAtivo></asp:CheckBox>
					<br><br>
					<b>Texto</b> <br>(max.50 caracteres)<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator></label>
					<asp:TextBox TextMode="SingleLine" CssClass="f8" Runat="server" ID="txtDescricao" MaxLength="50" Width="100%"></asp:TextBox>
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
							<input type=button value=Voltar onclick='location.href="AnaliseMensal.aspx"'/>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>