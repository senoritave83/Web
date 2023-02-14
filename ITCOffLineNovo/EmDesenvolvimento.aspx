<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmDesenvolvimento.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.EmDesenvolvimento" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" cellspacing="0">
			<tr>
				<td width="100%">
					<uc1:Top id="Top1" runat="server"></uc1:Top>
				</td>
			</tr>
			<tr height="100">
				<td>&nbsp;</td>
			</tr>
			<tr height="100%" valign="center">
				<td align="middle">
					<form id="frmCad" runat="server">
						<b><font Class="f8">Em desenvolvimento!</font></b>
						<br>
						<br>
						<input type=button ID='btnVoltar' value=' OK ' onclick="javascript:history.go(-1);" />
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
