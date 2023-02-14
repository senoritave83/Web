<%@ Page Language="VB" AutoEventWireup="false" CodeFile="exportacaorpt.aspx.vb" Inherits="Integracao_exportacaorpt" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pedidos</title>
    <style>
        #trPrintHeader
        {
            background-color:#6699cc;
            color:White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id='MainArea' >
        <table width='100%'>
            <tr id='trPrintHeader' runat='server' style="display:none;">
                <td>
		            <asp:Button cssclass='Botao' id='btnConfirmar' runat="server" Text='Confirmar Impressão' />
		            <asp:Label ID='lblMsgImpressao' Visible='False' runat="server" 
                        Text='Pedidos impressos com sucesso!' Font-Size="Larger" />
		            <asp:Label ID='lblMsgSemPedidos' Visible='False' runat="server" 
                        Text='Não há pedidos para serem impressos!' Font-Size="Larger" />
                </td>
            </tr>
            <tr>
                <td width="100%" class='MainContent'>
        <asp:Repeater runat='server' ID='rptPedidos' EnableViewState='false'>
            <ItemTemplate>
                <div class='EditArea' style='page-break-inside:avoid;page-break-after:auto;'>

                    <div class='divEditArea' style="width:100%">
                        <div class='divHeader'>&nbsp;</div>
                        <div class='trField fl' style="width:49%" runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        N&uacute;mero do Pedido:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat='server' ID='lblNumeroPedido' Font-Bold='true' Text='<%# Eval("NumeroPedido") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%"  runat='server'  id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Status:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat='server' ID='lblStatus' Font-Bold='true' Text='<%# Eval("StatusPedido") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:100%" runat='server'  id='trCliente' visible='<%$Settings: visible, Visita.Cliente, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Cliente:
	                        </div>
	                        <div class='tdField fl'>
		                        <%# Eval("CodigoCliente") %> - <%# Eval("Cliente") %> 
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server'  id='trCnpj' visible='<%$Settings: visible, Cliente.Cnpj, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Cnpj:
	                        </div>
	                        <div class='tdField fl'>
		                        <%# Eval("CnpjCliente") %>
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server'  id='trUf' visible='<%$Settings: visible, Cliente.Uf, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Uf:
	                        </div>
	                        <div class='tdField fl'>
		                        <%# Eval("UfCliente") %>
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%"  runat='server' id='trVendedor' visible='<%$Settings: visible, Pedido.Vendedor, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Vendedor:
	                        </div>
	                        <div class='tdField fl'>
		                        <%#Eval("CodigoVendedor")%> - <%# Eval("Vendedor") %>
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server'  id='trDataEmissao' >
	                        <div class='tdFieldHeader fl'>
		                        Data de Emiss&atilde;o:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat='server' ID='lblDataEmissao' Text='<%# Eval("DataEmissao") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%"  runat='server' id='trDataEntrega' visible='<%$Settings: visible, Pedido.DataEntrega, true %>' >
	                        <div class='tdFieldHeader fl'>
		                        Data de Entrega:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat='server' ID='lblDataEntrega' Text='<%# FormatDateTime(Eval("DataEntrega"),2) %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%"  runat='server'  id='trIDCondicao' visible='<%$Settings: visible, Pedido.Condicao, false %>' >
	                        <div class='tdFieldHeader fl'>
		                        Condi&ccedil;&atilde;o de Pagto:
	                        </div>
	                        <div class='tdField fl'>
		                         <asp:Label runat='server' ID='lblCondicao' Text='<%# Eval("Condicao") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server'  id='trDesconto' visible='<%$Settings: visible, Pedido.Desconto, false %>' >
	                        <div class='tdFieldHeader fl'>
		                        Desconto:
	                        </div>
	                        <div class='tdField fl'>
		                         <asp:Label runat='server' ID='lblDesconto' Text='<%# Eval("Desconto") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server' id='trSituacaoPedido' visible='<%$Settings: visible, Pedido.SituacaoPedido, false %>' >
	                        <div class='tdFieldHeader fl'>
		                        Situa&ccedil;&atilde;o:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat="server" ID="lblSituacao" Text='<%# Eval("SituacaoPedido") %>' />
	                        </div>
                        </div>		
                        <div class='trField fl' style="width:49%" runat='server'  id='trIDVisita' visible='<%$Settings: visible, Pedido.IDVisita, false %>' >
	                        <div class='tdFieldHeader fl'>
		                        Visita:
	                        </div>
	                        <div class='tdField fl'>
		                        <asp:Label runat="server" ID="lblVisita" Text='<%# Eval("IDVisita") %>' />
	                        </div>
                        </div>
                        <div class='trField fl' style="width:49%" runat='server'  id='trlocalizacao' visible='<%$Settings: visible, Pedido.Localizacao, false %>' >
	                        <div class='tdFieldHeader fl'>
		                        Localiza&ccedil&atilde;o:
	                        </div>
	                        <div class='tdField fl'>
		                        <uc1:Localizacao ID="Localizacao1" runat="server" Latitude='<%#Eval("Latitude")%>' Longitude='<%#Eval("Longitude")%>' />
	                        </div>
                        </div>		
                        Itens do Pedido
                        <div class='ListArea'>
                            <asp:GridView runat='server' ID='grdItens' Width='100%' AutoGenerateColumns='false' SkinID='GridInterno'  DataSource='<%# Me.GetItensPedido(Eval("IDPedido").ToString()) %>'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
                                    <asp:BoundField DataField='CodigoOriginal' HeaderText='C&oacute;digo' />
                                    <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
                                    <asp:TemplateField HeaderText="Pre&ccedil;o Unit&aacute;rio" visible='<%$Settings: visible, Pedido.PrecoUnitario, false %>'>
	                                    <ItemTemplate>
		                                    <font class="TextDefault">
			                                    <%#FormatCurrency(Eval("VALORUNITARIO").ToString(), 2)%>
		                                    </font>
	                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Desconto" visible='<%$Settings: visible, Pedido.ItemDesconto, true %>'>
	                                    <ItemTemplate>
		                                    <font class="TextDefault">
			                                    <%#FormatNumber(Eval("Desconto"), 2)%>
		                                    </font>
	                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-Width="80" visible='<%$Settings: visible, Pedido.ItemTotal, false %>'>
	                                    <ItemTemplate>
		                                    <font class="TextDefault">
			                                    <%#FormatCurrency(Eval("Total"), 2)%>
		                                    </font>
	                                    </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div> 	
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
                </td>
            </tr>
        </table>
    </div> 
    </form>
    <asp:Literal runat='server' id='ltrScript'>
        <script type='text/javascript'>
            <!-- FUNCAO -->
        </script>
    </asp:Literal>
</body>
</html>
