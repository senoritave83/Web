<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="status_det.aspx.vb" Inherits="Relatorios_status" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter='true'>
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Status" DataField='Status' FooterText='Total' />
			<asp:TemplateField HeaderText="Quantidade">
			    <ItemTemplate>
			        <%#FormatNumber(Soma.Add(Eval("Quantidade"), "Quantidade"), 0)%>
			    </ItemTemplate>
			    <FooterTemplate>
			        <%#FormatNumber(Soma.Item("Quantidade").Sum, 0)%>
			    </FooterTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Total">
			    <ItemTemplate>
			        <%#FormatCurrency(Soma.Add(Eval("Total"), "Total"), 2)%>
			    </ItemTemplate>
			    <FooterTemplate>
			        <%#FormatCurrency(Soma.Item("Total").Sum, 2)%>
			    </FooterTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Média">
			    <ItemTemplate>
			        <%#FormatCurrency(Soma.Add(Eval("Media"), "Media"), 2)%>
			    </ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>

