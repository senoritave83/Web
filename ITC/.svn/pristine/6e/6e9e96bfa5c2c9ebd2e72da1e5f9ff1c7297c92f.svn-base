<%@ Page ValidateRequest="false"  Language="vb" AutoEventWireup="false" Codebehind="IndicesITCCad.aspx.vb"  Inherits="ITC.IndicesITCCad"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
		<script language="javascript">
			function Procurar()
			{
				window.open('selecionaimagem.aspx', 'selecionaimagem', 'height=400, width=500, toolbar=no, left=200, top=200, scrollbars=yes')
			}
		</script>
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Índices</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Entrada de Cadastro</legend>
    				
    				<label>Nome da Imagem<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="reqTitulo" ControlToValidate="txtNomeArquivo"></asp:RequiredFieldValidator></label>
					<asp:TextBox Runat="server" ID="txtNomeArquivo" Width="100" size="100" CssClass="inputG"></asp:TextBox>
					<br />

					<label>Descrição<asp:RequiredFieldValidator ErrorMessage="*" CssClass="f8" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator></label>
					<asp:TextBox TextMode="MultiLine" Columns="100" Rows="40" CssClass="f8" Runat="server" ID="txtDescricao" MaxLength="500" Width="100%"></asp:TextBox>					
					<br />
				</fieldset>
								
				<table>
					<tr>
						<td>
							<asp:Button Runat=server ID="btnGravar" Text="Gravar"></asp:Button>		
						</td>
					</tr>
				</table>
			</form>
			
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>