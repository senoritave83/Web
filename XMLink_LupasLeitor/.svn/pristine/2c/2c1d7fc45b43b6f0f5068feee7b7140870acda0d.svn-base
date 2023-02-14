<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="Precos_det.aspx.vb" Inherits="Relatorios_Precos_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Tabela de Pre&ccedil;os <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="C&oacute;digo" DataField='Codigo' SortExpression='Codigo' />
			<asp:BoundField HeaderText="Produto" DataField='Produto' SortExpression='Produto' />
			<asp:BoundField HeaderText="Pre&ccedil;o" DataField='Preco' DataFormatString='{0:n}' SortExpression='Preco' />
		</Columns>
        <EmptyDataTemplate>
            N&atilde;o h&aacute; produtos para tabela de pre&ccedil;o!
        </EmptyDataTemplate>
	</asp:GridView>
</asp:Content>

