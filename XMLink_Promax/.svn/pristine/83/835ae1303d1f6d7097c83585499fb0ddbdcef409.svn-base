<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="vendedor_det.aspx.vb" Inherits="Relatorios_vendedor" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio2' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Vendedor" DataField='Vendedor' />
			<asp:BoundField HeaderText="Quantidade" DataField='Quantidade' />
			<asp:BoundField HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
			<asp:BoundField HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
		</Columns>
	</asp:GridView>
    <asp:Repeater runat='server' ID='grdRelatorio'>
        <HeaderTemplate>
            <div class="scrollTableContainer">
            	<table class="dataTable" cellspacing="0" cellpadding="4" border="0" id="ctl00_cphRelatorio_grdRelatorio" style="border-style:None;width:100%;border-collapse:collapse;">
            	    <thead>
		                <tr class="GridHeader" align="left" valign='top'>
			                <th scope="col">Vendedor</th>
			                <th scope="col">Quantidade</th>
			                <th scope="col">Total</th>
			                <th scope="col">M&eacute;dia</th>
		                </tr>
            	    </thead>
            	    <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                <tr style="background-color:#EFF3FB;">
			        <td><%# Eval("Vendedor") %></td>
			        <td><%#FormatNumber(Soma.Add(Eval("Quantidade"), "Quantidade"), 0)%></td>
			        <td><%#FormatNumber(Soma.Add(Eval("Total"), "Total"), 0)%></td>
			        <td><%#FormatNumber(Eval("Media"), 2)%></td>
		        </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
                <tr style="background-color:White;">
			        <td><%# Eval("Vendedor") %></td>
			        <td><%#FormatNumber(Soma.Add(Eval("Quantidade"), "Quantidade"), 0)%></td>
			        <td><%#FormatNumber(Soma.Add(Eval("Total"), "Total"), 0)%></td>
			        <td><%#FormatNumber(Eval("Media"), 2)%></td>
		        </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
        	    </tbody>
        	    <tfoot>
                        <tr class="GridHeader">
			                <td>Total</td>
			                <td><%#FormatNumber(Soma.Item("Quantidade").Sum, 0)%></td>
			                <td><%#FormatNumber(Soma.Item("Total").Sum, 0)%></td>
			                <td>&nbsp;</td>
		                </tr>
        	    </tfoot>
            </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
	
</asp:Content>

