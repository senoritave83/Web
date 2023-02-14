<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdutosAssociados.aspx.vb"  ValidateRequest="False" Inherits="ITC.ProdutosAssociados"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
		
			<uc1:top id="Top1" runat="server"></uc1:top>
		    
			<h3>Produtos do Associado</h3>
			<table>
				<tr>
					<td valign="top" align="middle">
						<form id="frmCad" runat="server">
							<br>
							<asp:CheckBoxList BorderStyle=Outset width="100%" CssClass="f8" RepeatDirection="Vertical" Runat="server" RepeatColumns="3" ID="chkProdutos"></asp:CheckBoxList>
							<br>
							<asp:Button Runat=server ID=btnVoltar Text=Voltar></asp:Button>
						</form>
					</td>
				</tr>
			</table>
			</form>
			<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape>
		</div>
	</body>
</HTML>