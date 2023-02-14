<%@ Page Language="vb" AutoEventWireup="false" Codebehind="gravado.aspx.vb"  ValidateRequest="False" Inherits="ITC.gravado1"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body alink=#ffffff vlink=#ffffff link=#ffffff>
		<form id="frmGravado" runat="server">
			<div id="Tudo">
			
			
				<table align=center>
					<tr>
						<td>
							<h4 align=center>Dados gravados com sucesso!&nbsp;&nbsp;</h4>
						</td>
					</tr>
					<tr>
						<td align=center bgcolor=#cccccc>
							<p align=center><b><asp:LinkButton Runat=server ID="btnVoltar"><font color="#000000">Clique aqui para ser redirecionado.</font></asp:LinkButton></b></p>
						</td>
					</tr>
				</table>

			</div>
		</form>
	</body>
</HTML>
