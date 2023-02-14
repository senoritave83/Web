<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="status_det.aspx.vb" Inherits="Relatorios_status" title="Untitled Page" %>

<asp:Content ID="Head" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Relat&oacute;rio de Pedidos por Status <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Status" DataField='Status' />
			<asp:BoundField HeaderText="Quantidade" DataField='Quantidade' />
			<asp:BoundField HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
			<asp:BoundField HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
		</Columns>
        <EmptyDataTemplate>
            N&atilde;o h&aacute; pedidos para este Relat&oacute;rio!
        </EmptyDataTemplate>
	</asp:GridView>
</asp:Content>

