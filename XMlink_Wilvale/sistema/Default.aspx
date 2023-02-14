<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="sistema_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Repeater runat='server' ID='rptItens' DataSourceID='SiteMapDataSource1'>
        <ItemTemplate>
            <div style="width:50%;float:left;" >
                <table>
                    <tr>
						<td valign=top><A href="<%#ResolveClientUrl(Eval("url")) %>"><img id="Img1" src='<%#Container.DataItem.item("img") %>' runat='server' border='0' /></A>
						</td>
						<td valign=top>
							<A class="TextDefaultBold" href="<%#ResolveClientUrl(Eval("url")) %>"><%#Eval("title") %></A><br>
							<font class="TextDefault"><%# Eval("Description") %></font>
						</td>
					</tr> 
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" StartFromCurrentNode='true' ShowStartingNode='false' />
</asp:Content>

