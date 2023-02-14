<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ImageRotator.ascx.vb" Inherits="inccontrols.ImageRotator" %>

<asp:Panel runat='server' ID='pnlControle' class='ImageRotator'>
    <asp:Image runat='server' ID='img' class='ImageRototorImg' ImageUrl="~/imagens/noimage.png" onMouseOver='getRotator(this.id).mouseOver();' onMouseOut='getRotator(this.id).mouseOut();' />
    <table class='ImageRotatorTable' cellpadding='0' cellspacing='0'>
        <tr>
            <td align="left" class='tdButton'><a href='javascript:fncNavigateImage("<%=img.ClientID %>", -1)'><img src="../imagens/player_rev.png" border='0'/></a></td>
            <td align="left" class='tdButton'><a href='javascript:fncPlayPause("<%=img.ClientID %>");'><img src="../imagens/player_pause.png"  id='<%=img.ClientID %>_btnplay' border='0' /></a></td>
            <td align="center" class='tdCaption'>
                <span id='<%=img.ClientID %>_caption'></span>
            </td>
            <td align="center" style="border-right:none\9;" class='tdButton'><a href='javascript:fncNavigateImage("<%=img.ClientID %>", 1)'><img src="../imagens/player_fwd.png"  border='0' /></a></td>
        </tr>
    </table>
    <script type='text/javascript'><asp:Literal runat="server" ID='ltrFunction'></asp:Literal></script>
</asp:Panel>
