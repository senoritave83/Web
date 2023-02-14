<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="visitas_positivacao_det.aspx.vb" Inherits="Relatorios_visitas_positivacao_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Clientes Não Visitados <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">

<div id="divResumo" runat="server" Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin; margin-bottom:10px;padding: 10px 10px 10px 20px;width:100%;"> 
    <div style="height:30px">
         <table width='96%'>
            <tr width="100%" height="30px" valign="top"> 
                <td width='50%'>
                    <strong ><font Style="font-size:12px;">Resumo Geral</font></strong>
                </td>
                <td width='50%'>
                    Total de Clientes não visitados: <asp:Label runat="server" ID="lblTotalClientes" Font-Size="12px" Font-Bold="true" />
                </td>
            </tr>
        </table>
        
        
    </div>
    <asp:GridView ID="grdResumoGeral" Runat="server" Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle />
	    <Columns>
		    <asp:BoundField HeaderText="Cliente" DataField='CLIENTE' HeaderStyle-HorizontalAlign='left' />
            <asp:BoundField HeaderText="Nome Fantasia" DataField='NomeFantasia' HeaderStyle-HorizontalAlign='left' />
		    <asp:BoundField HeaderText="&Uacute;ltima Visita" DataField='ULTIMAVISITA' HeaderStyle-HorizontalAlign='left' />
            <asp:BoundField HeaderText="Vendedor" DataField='VENDEDOR' HeaderStyle-HorizontalAlign='left' />
	    </Columns>
        <EmptyDataTemplate>
            N&atilde;o h&aacute; clientes sem visitas!
        </EmptyDataTemplate>
    </asp:GridView>
</div>

<asp:Repeater runat='server' id='rptVisitasPositivacao'>
	<ItemTemplate>
        <div Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin;margin-bottom:10px;padding: 10px 10px 10px 20px;">
            <table width='96%'>
                <tr width="100%" height="30px" valign="top"> 
                    <td width='50%'>
                        Vendedor: <strong ><font Style="font-size:12px;"><%# Eval("Vendedor")%></font></strong>
                    </td>
                    <td width='50%'>
                        C&oacute;digo: <strong ><font Style="font-size:12px;"><%# Eval("CodigoVendedor")%></font></strong>
                    </td>
                </tr>
                <tr valign="top"> 
                    <td colspan='2'>
	                    <asp:GridView Runat="server" Width="100%" DataSource='<%# GridVisitasPositivacao(Eval("IDVendedor")) %>' AutoGenerateColumns="False">
	                        <HeaderStyle />
		                    <Columns>
			                    <asp:BoundField HeaderText="C&oacute;digo Cliente" DataField='CODCLIENTE' HeaderStyle-HorizontalAlign='left' ItemStyle-Width="20%"  />
			                    <asp:BoundField HeaderText="Cliente" DataField='CLIENTE' HeaderStyle-HorizontalAlign='left' ItemStyle-Width="30%"  />
                                <asp:BoundField HeaderText="Nome Fantasia" DataField='NomeFantasia' HeaderStyle-HorizontalAlign='left' ItemStyle-Width="30%"  />
			                    <asp:BoundField HeaderText="&Uacute;ltima Visita" DataField='ULTIMAVISITA' HeaderStyle-HorizontalAlign='left' ItemStyle-Width="20%"  />
		                    </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; clientes sem visitas para este Vendedor!
                            </EmptyDataTemplate>
	                    </asp:GridView>
                    </td>
                </tr> 
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
