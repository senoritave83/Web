<%@ Control Language="vb" AutoEventWireup="false" CodeFile="XMTitulo.ascx.vb" Inherits="Controls.XMTitulo" %>
<table width="100%" cellpadding="1" cellspacing="1" border="0" runat="server" id="tblXMTitulo">
	<tr>
	    <td colspan='3' align='left' runat="Server" id="pageSiteMap" class="xmtitulo"  >
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"  
                SiteMapProvider="OpenXMLSiteMapProvider"
                PathSeparator=" : ">
                <CurrentNodeStyle Font-Bold="false" CssClass="current_pg" />
                <NodeStyle Font-Bold="false" CssClass="node_pg" />
                <PathSeparatorStyle  ForeColor="#000000" />
                <RootNodeStyle CssClass="root_pg" />
            </asp:SiteMapPath>
	    </td>	
	</tr>
	<tr valign="middle">
		<td style="padding-left:10px; padding-top:5px;">
			<asp:Image BorderStyle="None" runat="server" id='imgImagem' SkinID='XMTitulo.PageLogo' AlternateText=""  />
		</td>
		<td width="100%" id="pageDescription" runat="Server" style="padding:5px 0px 0px 8px;">
			<asp:Label Runat="server" ID='lblTitulo' SkinID='XMTitulo.Titulo' CssClass="Titulo_pg"></asp:Label><br/>
			<img runat='server' src="../imagens/pt.gif" id='imgLinha' alt='' /><br/>
			<asp:Label Runat="server" ID='lblDescricao' SkinID='XMTitulo.Descricao'></asp:Label>
		</td>	
	</tr>
</table>

