<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Fornecedores.aspx.vb" Inherits="Pages.Cadastros.export.Fornecedores" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
        	<asp:BoundField HeaderText="IDFornecedor" DataField="IDFornecedor" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Fornecedor" DataField="Fornecedor" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Criado" DataField="Criado" ItemStyle-CssClass="xl26" />
        	<asp:TemplateField HeaderText="Concorrente" ItemStyle-CssClass="xl28">
        	    <ItemTemplate>
        	        <%# IIf(Eval("Concorrente"), "sim", "n&atilde;o")%>
        	    </ItemTemplate>
        	</asp:TemplateField>
        </Columns>
    </asp:GridView>    
</asp:Content>

