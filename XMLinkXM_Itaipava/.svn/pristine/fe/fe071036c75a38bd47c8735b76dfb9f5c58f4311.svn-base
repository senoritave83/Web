<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="sistema_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<br />
    <br />
<div class="container-default">
    <asp:Repeater runat='server' ID='rptItens' DataSourceID='SiteMapDataSource1'>
        <ItemTemplate>
            <div id="Div1" style="width:40%; width:40%\9; height:100px; float:left; padding-left:70px; padding-top:30px; " runat='server' visible='<%# VerificaPermissao(Container.DataItem.Item("Secao"), "Visualizar") %>' >
                <table>
                    <tr>
						<td valign="middle"><A href="<%#Eval("url") %>"><img id="Img1" src='<%#Container.DataItem.item("imgCZ") %>' runat='server' border='0' /></A>
						</td>
						<td valign="middle">
							<A class="TextDefaultBold" href="<%#Eval("url") %>"><%#Eval("title") %></A><br>
							<font class="TextDefault"><%# Eval("Description") %></font>
						</td>
					</tr> 
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>    
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" StartFromCurrentNode='true' ShowStartingNode='false' />
</asp:Content>

