<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="TipoLojas.aspx.vb" Inherits="Pages.Cadastros.export.TipoLojas" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
            <asp:BoundField HeaderText="IDTipoLoja" DataField="IDTipoLoja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="TipoLoja" DataField="TipoLoja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Criado" DataField="Criado" ItemStyle-CssClass="xl26" />
        </Columns>
    </asp:GridView>    
</asp:Content>

