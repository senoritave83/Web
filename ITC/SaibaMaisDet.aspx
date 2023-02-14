<%@ Page  ValidateRequest="false" Language="vb" AutoEventWireup="false" Codebehind="SaibaMaisDet.aspx.vb" Inherits="ITC.SaibaMaisDet"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
		<script>
					function checkSize()
				{
				var i = document.frmCad.txtDescricao.value.length;
				if (i < 120)
					{
					spSize.innerHTML = 120 - i;
					return true;
					}
				else
					{
					spSize.innerHTML = 0;
					if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39  && event.keyCode != 38  && event.keyCode != 37  && event.keyCode != 40)
						return false;
					}
				}
			function Trim()
				{if(document.frmCad.txtDescricao.value.length > 120){
					document.frmCad.txtDescricao.value = document.frmCad.txtDescricao.value.substring(0, 120);}}
		</script>
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de "Saiba Mais"</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastro</legend>
    				
    				<b>Nome da Imagem</b> (ex.Casinha.jpg)<br><asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="reqImagem" ControlToValidate="txtImagem" Display="Dynamic"></asp:RequiredFieldValidator>
    				<asp:textbox CssClass="inputG" Runat="server" ID="lblImagem" Width="500"></asp:textbox><br>
    				<input type="file" runat="Server" id="txtImagem" size="80" NAME="txtImagem"/>
					<br /><br>
					<b>Link de Redirecionamento </b> (URL) &nbsp;&nbsp;
					<asp:TextBox CssClass="inputG" Runat="server" ID="txtLink" MaxLength="100" Width="400"></asp:TextBox>
					<br /><br>
					<b>Ativo</b> <asp:CheckBox Runat=server ID=chkAtivo></asp:CheckBox>
					<br><br>
					<b>Texto</b> <br>(max.120 caracteres)<asp:RequiredFieldValidator ErrorMessage="*" CssClass="inputG" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator></label>
					<asp:TextBox TextMode="MultiLine" onKeyDown='return checkSize();' onBlur='Trim();' Columns="3" Rows="4" CssClass="f8" Runat="server" ID="txtDescricao" MaxLength="120" Width="100%"></asp:TextBox>
					<br />
					Caracteres Restantes: <asp:label Runat="server" CssClass="content_text" id='spSize'>120</asp:label>
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
							<input type=button value=Voltar onclick='location.href="SaibaMais.aspx"'/>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>