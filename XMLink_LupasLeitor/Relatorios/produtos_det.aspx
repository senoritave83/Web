<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="produtos_det.aspx.vb" Inherits="Relatorios_produtos" title="Untitled Page" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Velocidade de Vendas <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
    <asp:Repeater ID="rptCategorias" runat="server">
        <ItemTemplate>
            Categoria: <b><%#Eval("Categoria") %></b>

	        <asp:GridView Runat="server" DataSource='<%#getProdutos(Eval("IDCategoria"))%>' ShowFooter="true" Width="100%" AutoGenerateColumns="False">
	            <HeaderStyle HorizontalAlign='Left' />
		        <Columns>
			        <asp:BoundField HeaderText="Código" DataField='CodigoProduto' SortExpression='Codigo' FooterStyle-BackColor="#CAE1FF" />
			        <asp:BoundField HeaderText="Descrição" DataField='DescricaoProduto' SortExpression='Descricao' FooterText="Total" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black" />
                    <asp:TemplateField HeaderText="Estoque" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                        <ItemTemplate><%# Eval("Estoque")%></ItemTemplate>
                        <FooterTemplate><%# EstoqueTotal%></FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qtd. Vendida" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                        <ItemTemplate><%# Eval("Qtd_Vendida")%></ItemTemplate>
                        <FooterTemplate><%# QtdeVendidaTotal%></FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qtd. por Dia" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                        <ItemTemplate><%# FormatNumber(Eval("Media_dia"), 2)%></ItemTemplate>
                        <FooterTemplate><%# FormatNumber(QtdePorDiaTotal, 2)%></FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Prev. Estoque" FooterStyle-BackColor="#CAE1FF" FooterStyle-ForeColor="Black">
                        <ItemTemplate><%# FormatNumber(Eval("Dias_Coberto"), 1)%></ItemTemplate>
                        <FooterTemplate><%# FormatNumber(PrevEstoqueTotal, 1)%></FooterTemplate>
                    </asp:TemplateField>
		        </Columns>
                <EmptyDataTemplate>
                    N&atilde;o h&aacute; produtos para esta Categoria!
                </EmptyDataTemplate>
	        </asp:GridView>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

