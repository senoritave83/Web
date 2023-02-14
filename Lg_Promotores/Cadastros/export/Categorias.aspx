<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="Pages.Cadastros.export.Categorias" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
        	<asp:BoundField HeaderText="IDSegmento" DataField="IDCategoria" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Segmento" DataField="Categoria" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Criado" DataField="Criado" ItemStyle-CssClass="xl26" />
        	<asp:BoundField HeaderText="Ordem" DataField="Ordem" ItemStyle-CssClass="xl28" />
        </Columns>
    </asp:GridView>    
</asp:Content>

