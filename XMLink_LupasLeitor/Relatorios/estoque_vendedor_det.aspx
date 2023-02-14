<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="estoque_vendedor_det.aspx.vb" Inherits="Relatorios_estoque_vendedor_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Estoque do Vendedor <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
<asp:Repeater runat='server' id='rptEstoqueVend'>
	<ItemTemplate>
        <div Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin;margin-bottom:10px;padding: 10px 10px 10px 20px;">
            <table width='96%>
                <tr width='100%> 
                    <td width='50%'>
                        Vendedor: <strong ><font Style="font-size:12px;"><%# Eval("Vendedor")%></font></strong>
                    </td>
                    <td width='50%'>
                        C&oacute;digo: <strong ><font Style="font-size:12px;"><%# Eval("CodigoVendedor")%></font></strong>
                    </td>
                </tr>
                <tr valign="top"> 
                    <td colspan='2'>
	                    <asp:GridView Runat="server" Width="100%" DataSource='<%# GridEstoqueVend(Eval("IDVendedor")) %>' AutoGenerateColumns="False">
	                        <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
			                    <asp:BoundField HeaderText="C&oacute;digo Produto" DataField='Codigo' HeaderStyle-HorizontalAlign='left' />
			                    <asp:BoundField HeaderText="Produto" DataField='Produto' HeaderStyle-HorizontalAlign='left' />
			                    <asp:BoundField HeaderText="Estoque" DataField='Estoque' HeaderStyle-HorizontalAlign='left' />
		                    </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; produtos com este Vendedor!
                            </EmptyDataTemplate>
	                    </asp:GridView>
                    </td>
                </tr> 
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
