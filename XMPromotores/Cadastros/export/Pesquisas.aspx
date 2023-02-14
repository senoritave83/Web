<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Pesquisas.aspx.vb" Inherits="Pages.Cadastros.export.Pesquisas" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
            <asp:BoundField HeaderText="IDPesquisa" DataField="IDPesquisa" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Pesquisa" DataField="Pesquisa" ItemStyle-CssClass="xl28" />
			<asp:TemplateField HeaderText="Concorrente" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="xl28"><ItemTemplate><%#IIf(Eval("Concorrente") = 1, "Sim", IIf(Eval("Concorrente") = 2, "Todos", "N&atilde;o"))%></ItemTemplate></asp:TemplateField>
        	<asp:BoundField HeaderText="Criado" DataField="Criado" ItemStyle-CssClass="xl26" />
			<asp:TemplateField HeaderText="Ativa" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="xl28"><ItemTemplate><%#IIf(Eval("Ativo") = 1, "Sim", "N&atilde;o")%></ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>    
</asp:Content>

