<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="produtos_det.aspx.vb" Inherits="Relatorios_produtos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Código" DataField='CodigoProduto' SortExpression='Codigo' />
			<asp:BoundField HeaderText="Descrição" DataField='DescricaoProduto' SortExpression='Descricao' />
			<asp:BoundField HeaderText="Estoque" DataField='Estoque' SortExpression='Estoque' />
			<asp:BoundField HeaderText="Qtd. Vendida" DataField='Qtd_Vendida' SortExpression='Vendida' />
			<asp:BoundField HeaderText="Qtd. por Dia" DataField='Media_dia' DataFormatString='{0:0.0}' SortExpression='Media' />
			<asp:BoundField HeaderText="Prev. Estoque" DataFormatString='{0:0.0}' DataField='Dias_Coberto' SortExpression='Coberto' />
		</Columns>
	</asp:GridView>
</asp:Content>

