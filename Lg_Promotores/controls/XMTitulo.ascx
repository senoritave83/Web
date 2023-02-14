<%@ Control Language="vb" AutoEventWireup="false" CodeFile="XMTitulo.ascx.vb" Inherits="Controls.XMTitulo" %>
<table width="100%" cellpadding="1" cellspacing="1" border=0>
	<tr valign="middle">
		<td>
			<asp:Image BorderStyle="None" runat="server" id='imgImagem' SkinID='XMTitulo.PageLogo' AlternateText=""  />
		</td>
		<td width="100%" id="pageDescription" runat="Server">
			<asp:Label Runat="server" ID='lblTitulo' SkinID='XMTitulo.Titulo'></asp:Label><br/>
			<img runat='server' src='~/imagens/pt.gif' id='imgLinha' alt='' /><br/>
			<asp:Label Runat="server" ID='lblDescricao' SkinID='XMTitulo.Descricao'></asp:Label>
		</td>
		<td align="right"><asp:Image alt='' runat="server" ImageUrl='~/imagens/xmpromotores.jpg' ID='imgLogo' SkinID='XMTitulo.Logo' /></td>
	</tr>
	<tr>
	    <td colspan='3' align='left' runat="Server" id="pageSiteMap" >
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Arial" Font-Size="0.6em" 
                SiteMapProvider="OpenXMLSiteMapProvider"
                PathSeparator=" : ">
                <PathSeparatorStyle Font-Bold="True" ForeColor="#507CD1" />
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#284E98" />
                <RootNodeStyle Font-Bold="True" ForeColor="#507CD1" />
            </asp:SiteMapPath>
	    </td>
	</tr>
</table>

