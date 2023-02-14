<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="retorno_reposicao_det.aspx.vb" Inherits="Relatorios_retorno_reposicao_det" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Retorno e Reposição <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Vendedor" DataField='Vendedor' />
            <asp:BoundField HeaderText="Cliente" DataField='Cliente' />
			<asp:BoundField HeaderText="A&ccedil;&atilde;o" DataField='Acao' />
			<asp:BoundField HeaderText="Produto" DataField='Produto' />
			<asp:BoundField HeaderText="Qtde" DataField='Qtde' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Data" DataField='Data' />
		</Columns>
        <EmptyDataTemplate>
            N&atilde;o h&aacute; vendas para este Relat&oacute;rio!
        </EmptyDataTemplate>
	</asp:GridView>
</asp:Content>
