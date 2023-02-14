<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserData" Src="Inc/UserData.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelatorioEmpExportar.aspx.vb"  ValidateRequest="False" Inherits="ITC.RelatorioEmpExportar"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tbl1" cellSpacing="0" width="100%" bgColor="#F1F1F1">
				<tr>
					<td width="80%"><uc1:top id="Top1" runat="server"></uc1:top></td>
				</tr>
				<tr>
					<td width="80%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
			</table>
			<table height="350" width="100%">
				<tr>
					<td height="100">&nbsp;</td>
				</tr>
				<tr>
					<td valign="top" align="middle">
						<font class="f8" color="red">Exportação efetuada com sucesso</font><br>
						<a href="javaascript:window.close();" class="f8"><font color="#000000" class="f8">Clique 
								aqui para fechar</font></a>
					</td>
				</tr>
			</table>
			<uc1:Rodape runat="server" id="Rodape1"></uc1:Rodape>
		</form>
	</body>
</HTML>
