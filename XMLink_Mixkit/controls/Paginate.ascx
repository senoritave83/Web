<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Paginate.ascx.vb" Inherits="Controls.Paginate" %>
<table width="100%" class='PaginateControl'>
	<tr class="GridItem" align="right">
		<td colspan="6">
			<asp:LinkButton ID="lnkFirst" Runat="server">Primeiro</asp:LinkButton>
			<asp:LinkButton ID="lnkPrevious" Runat="server">Anterior</asp:LinkButton>
			&nbsp;
			<asp:Literal runat='server' ID='ltrTexto' />
			&nbsp;
			<asp:LinkButton ID="lnkNext" Runat="server">Pr&oacute;ximo</asp:LinkButton>
			<asp:LinkButton ID="lnkUltima" Runat="server">&Uacute;ltima</asp:LinkButton>
		</td>
	</tr>
</table>
