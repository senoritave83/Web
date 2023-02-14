<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="Fechamento_det.aspx.vb" Inherits="Relatorios_Fechamento_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
	<title>Relat&oacute;rio de Fechamento <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">

<div id='divResumoGeral' runat='server' Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin; margin-bottom:10px;padding: 10px 10px 10px 20px;">
    <table id="rel">
        <tr > 
            <td >
                <strong ><font Style="font-size:12px;">Resumo Geral</font></strong>
            </td>
        </tr>
        <tr Style="background-color:#6699cc;" align="center"> 
            <td class="col">
                <strong><font Style="font-size:12px;color:White;">Vendas por produto</font></strong>
            </td>
            <td class="col2">                        
                <strong ><font Style="font-size:12px;color:White;">Vendas por forma de Pagto</font></strong>
            </td>
        </tr>  
        <tr valign="top"> 
            <td class="col">
                <asp:Repeater runat='server' id='rptCategoriaProdutoResumo' >
	                <ItemTemplate>
	                    <asp:GridView Runat="server" ID='grdVendaResumo' ShowFooter='true' Width="100%" DataSource='<%# GridVendas(Eval("IDCategoria"),Request("ven"),"RESUMO") %>' AutoGenerateColumns="False">
	                        <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
                                <asp:BoundField HeaderText="Categoria" DataField='Categoria' FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                                <asp:BoundField HeaderText="Produto" DataField='Produto' FooterText="Total" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                                <asp:TemplateField HeaderText="Qtde" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                                    <ItemTemplate><%# Eval("QtdeProduto")%></ItemTemplate>
                                    <FooterTemplate><%#QtdeTotal %></FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total R$" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                                    <ItemTemplate><%# FormatNumber(Eval("TotalProduto"))%></ItemTemplate>
                                    <FooterTemplate><%#FormatNumber(ValorTotal) %></FooterTemplate>
                                </asp:TemplateField>
		                    </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; produtos para este resumo!
                            </EmptyDataTemplate>
	                    </asp:GridView>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td class="col2">
	            <asp:GridView Runat="server" ShowFooter="true" ID='grdPagtoResumo' Width="100%" DataSource='<%# GridPagamento(Request("ven"),"RESUMO") %>' AutoGenerateColumns="False">
	                <HeaderStyle HorizontalAlign='Left' />
		            <Columns>
			            <asp:BoundField HeaderText="Forma de Pagto" DataField='FormaPagto' FooterText="Total" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                        <asp:TemplateField HeaderText="Total R$" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                            <ItemTemplate><%# FormatNumber(Eval("TotalFormaPagto"))%></ItemTemplate>
                            <FooterTemplate><%# FormatNumber(ValorTotal)%></FooterTemplate>
                        </asp:TemplateField>
		            </Columns>
                    <EmptyDataTemplate>
                        N&atilde;o h&aacute; formas de pagamento para o resumo!
                    </EmptyDataTemplate>
	            </asp:GridView>
            </td>
        </tr> 
    </table>
</div>

<!--QUEBRA DE PÁGINA-->
<br style="page-break-before: always;" />

<asp:Repeater runat='server' id='rptFechamento'>
	<ItemTemplate>
        <div Style="background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin;margin-bottom:10px;padding: 10px 10px 10px 20px;">
            <table id="rel">
                <tr > 
                    <td>
                        Vendedor: <strong ><font Style="font-size:12px;"><%# Eval("Vendedor")%></font></strong>
                    </td>
                </tr>
                <tr Style="background-color:#6699cc;" align="center"> 
                    <td  class="col">
                        <strong ><font Style="font-size:12px;color:White;">Vendas por produto</font></strong>
                    </td>
                    <td class="col2" >                        
                        <strong ><font Style="font-size:12px;color:White;">Vendas por forma de Pagto</font></strong>
                    </td>
                </tr>  
                <tr valign="top"> 
                    <td class="col">
                        <asp:Repeater runat='server' id='rptCategoriaProduto' DataSource='<%# RptCategoriasProduto(Eval("IDVendedor")) %>'>
	                        <ItemTemplate>
	                            <asp:GridView Runat="server" ID='grdVendas' ShowFooter='true' Width="100%" DataSource='<%# GridVendas(Eval("IDCategoria"),Eval("IDVendedor"),"VENDEDOR") %>' AutoGenerateColumns="False">
	                                <HeaderStyle HorizontalAlign='Left' />
		                            <Columns>
                                        <asp:BoundField HeaderText="Categoria" DataField='Categoria' FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                                        <asp:BoundField HeaderText="Produto" DataField='Produto' FooterText="Total" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                                        <asp:TemplateField HeaderText="Qtde" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                                            <ItemTemplate><%# Eval("QtdeProduto")%></ItemTemplate>
                                            <FooterTemplate><%#QtdeTotal %></FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total R$" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                                            <ItemTemplate><%# FormatNumber(Eval("TotalProduto"))%></ItemTemplate>
                                            <FooterTemplate><%#FormatNumber(ValorTotal) %></FooterTemplate>
                                        </asp:TemplateField>
		                            </Columns>
                                    <EmptyDataTemplate>
                                        N&atilde;o h&aacute; produtos para este vendedor!
                                    </EmptyDataTemplate>
	                            </asp:GridView>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td class="col2">
	                    <asp:GridView Runat="server" ID='grdPagto' ShowFooter="true" Width="100%" DataSource='<%# GridPagamento(Eval("IDVendedor"),"VENDEDOR") %>' AutoGenerateColumns="False">
	                        <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
			                    <asp:BoundField HeaderText="Forma de Pagto" DataField='FormaPagto' FooterText="Total" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                                <asp:TemplateField HeaderText="Total R$" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                                    <ItemTemplate><%# FormatNumber(Eval("TotalFormaPagto"))%></ItemTemplate>
                                    <FooterTemplate><%# FormatNumber(ValorTotal)%></FooterTemplate>
                                </asp:TemplateField>
		                    </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; formas de pagamento para este vendedor!
                            </EmptyDataTemplate>
	                    </asp:GridView>
                    </td>
                </tr> 
            </table>
        </div>

        <!--QUEBRA DE PÁGINA-->
        <br style="page-break-before: always;" />
    </ItemTemplate>
</asp:Repeater>
<div runat="server" ID="divRptFechamentoEmpty" Visible="false" >
    <asp:Label runat="server" Text="N&atilde;o h&aacute; registros com o filtro selecionado!" />
</div>
</asp:Content>

