<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pesquisa.aspx.vb" Inherits="Visita_pesquisa" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2><asp:Literal runat='server' ID='ltrTitulo'></asp:Literal></h2>
        <asp:ScriptManager ID="ScriptManager1" runat='server' EnablePageMethods='true' />
        <div id='divFormularioProdutos'>
            <table>
                <xm:XMCrossRepeater ID="xmProdutos" runat="server" EnableViewState='false'>
                    <TopTemplates>
                        <xm:XMCrossRepeaterTopTemplate>
                            <TopLeftTemplate>
                                <thead>
                                <tr>
                                    <th>Nome</th>
                            </TopLeftTemplate>
                            <ColHeaderTemplate>
                                    <th scope="col">
                                        <%#Server.HtmlEncode(Container.DataItem.Item("Pergunta") & "")%>
                                    </th>
                            </ColHeaderTemplate>
                            <TopRightTemplate>
                                </tr>
                                </thead>
                                <tbody>
                            </TopRightTemplate>
                        </xm:XMCrossRepeaterTopTemplate>
                    </TopTemplates>
                    <RowTemplate>
                       <RowHeaderTemplate>
                            <tr id='<%# "tr_" & Container.dataItem.Item("IDReferencia")%>' acao='<%# Container.DataItem.Item("Acao") %>' valign='top' class='<%# iif(Container.DataItem.Row Mod 2 = 0, "trAlternate", "trNormal")%>' >
                                <td><%# Container.dataItem.Item("Nome") %></td>
                       </RowHeaderTemplate>
                       <ItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>
                                    <div id='<%# "divPergunta_" & Container.dataItem.Item("IDReferencia") & "_" & Container.dataItem.Item("IDPergunta")%>'>
                                        <asp:Literal runat='server' ID='ltrResposta'></asp:Literal>
                                           <%#Container.DataItem.Item("Respostas")%>
                                    </div>	                    
                                </td>
                       </ItemTemplate>
                       <EmptyItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>&nbsp;</td>
                       </EmptyItemTemplate>
                       <RowFooterTemplate>
                            </tr>
                       </RowFooterTemplate>
                    </RowTemplate>
                    <BottomTemplates>
                        <xm:XMCrossRepeaterBottomTemplate>
                            <BottomRightTemplate>
                                </tbody>
                            </BottomRightTemplate>
                        </xm:XMCrossRepeaterBottomTemplate>
                    </BottomTemplates>
                </xm:XMCrossRepeater>
            </table> 
            <xm:Paginate ID="Paginate1" runat="server" />
        </div> 
    </form>
</body>
</html>
