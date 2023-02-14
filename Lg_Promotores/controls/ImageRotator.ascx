<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ImageRotator.ascx.vb" Inherits="controls.ImageRotator" %>

<asp:Panel runat='server' ID='pnlControle' class='ImageRotator'>
    <asp:Image runat='server' ID='img' class='ImageRototorImg' ImageUrl="~/imagens/noimage.png" onMouseOver='getRotator(this.id).mouseOver();' onMouseOut='getRotator(this.id).mouseOut();' />
    <table class='ImageRotatorTable' cellpadding='0' cellspacing='0'>
        <tr>
            <td align="left" class='tdButton'><a href='javascript:fncNavigateImage("<%=img.ClientID %>", -1)'><img src="../imagens/player_rev.jpg" height='15' border='0' /></a></td>
            <td style='width:2px' class='tdSeparator'><img src="../imagens/pt.gif" /></td>
            <td align="left" class='tdButton'><a href='javascript:fncPlayPause("<%=img.ClientID %>");'><img src="../imagens/player_pause.jpg" height='15' id='<%=img.ClientID %>_btnplay' border='0' /></a></td>
            <td style='width:2px' class='tdSeparator'><img src="../imagens/pt.gif" /></td>
            <td align="center" class='tdCaption'>
                <span id='<%=img.ClientID %>_caption'></span>
            </td>
            <td style='width:2px' class='tdSeparator'><img src="../imagens/pt.gif" /></td>
            <td align="right" class='tdButton'><a href='javascript:fncNavigateImage("<%=img.ClientID %>", 1)'><img src="../imagens/player_fwd.jpg" height='15' border='0' /></a></td>
        </tr>
    </table>
    <script type='text/javascript'><asp:Literal runat="server" ID='ltrFunction'></asp:Literal></script>
</asp:Panel>
