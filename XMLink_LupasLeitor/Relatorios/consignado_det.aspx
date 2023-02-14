<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="consignado_det.aspx.vb" Inherits="Relatorios_consignado_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Consignado de Clientes <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
<asp:Repeater runat='server' id='rptFechamento'>
	<ItemTemplate>
        <div Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin;margin-bottom:10px;padding: 10px 10px 10px 20px;">
            <table width='96%>
                <tr width='100%> 
                    <td width='40%'>
                        Cliente: <strong ><font Style="font-size:12px;"><%# Eval("Cliente")%></font></strong>
                    </td>
                    <td width='40%'>
                        Nome Fantasia: <strong ><font Style="font-size:12px;"><%# Eval("NomeFantasia")%></font></strong>
                    </td>
                    <td width='20%'>
                        C&oacute;digo: <strong ><font Style="font-size:12px;"><%# Eval("Codigo")%></font></strong>
                    </td>
                </tr>
                <tr valign="top"> 
                    <td colspan='3'>
	                    <asp:GridView Runat="server" Width="100%" DataSource='<%# GridConsignado(Eval("IDCliente")) %>' AutoGenerateColumns="False">
	                        <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
			                    <asp:BoundField HeaderText="C&oacute;digo" DataField='Codigo' />
			                    <asp:BoundField HeaderText="Produto" DataField='Produto' />
			                    <asp:BoundField HeaderText="Estoque" DataField='Estoque' />
		                    </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; produtos para este Cliente!
                            </EmptyDataTemplate>
	                    </asp:GridView>
                    </td>
                </tr> 
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
