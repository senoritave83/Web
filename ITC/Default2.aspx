<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default2.aspx.vb" Inherits="ITC.Default2" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="inc/Login.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body >
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellpadding="0" border="1" height="100%" width=100%>
				<tr height="100%">
					<td align=center valign="top" width="50%" height="50%">
						<uc1:Login id="Login" runat="server"></uc1:Login>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
