<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="produtos_det.aspx.vb" Inherits="Relatorios_produtos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:Repeater runat='server' ID='grdRelatorio'>
	    <HeaderTemplate>
            <div class="scrollTableContainer">
            <table class="dataTable" cellspacing="0" cellpadding="4" border="0" style="border-style:None;width:100%;border-collapse:collapse;">
                <thead>
		            <tr class="GridHeader" align="left">
			            <th scope="col">C&#243;digo</th><th scope="col">Descri&#231;&#227;o</th><th scope="col">Qtd. Vendida</th><th scope="col">Qtd. por Dia</th>
		            </tr>
		        </thead>
		        <tbody>
	    </HeaderTemplate>
	    <ItemTemplate>
            <tr style="background-color:White;">
                <td><%#Eval("CodigoProduto")%></td><td><%#Eval("DescricaoProduto")%></td><td>
                <%#FormatNumber(Soma.Add(Eval("Qtd_Vendida"), "Vendida"), 0)%>
                </td><td><%# FormatNumber(Eval("Media_dia"), 1)%></td>
			 </tr>	    
	    </ItemTemplate>
	    <FooterTemplate>
		        </tbody>
		        <tfoot>
                    <tr class="GridHeader">
        	    		<td>Total</td><td>&nbsp;</td><td>
		    	        <%#FormatNumber(Soma.Item("Vendida").Sum, 0)%>
		    	        </td><td>&nbsp;</td>
			        </tr>
		        </tfoot>
	            </table>
	            </div>
		    </FooterTemplate>
	</asp:Repeater>
</asp:Content>

