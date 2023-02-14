<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Frequencias.aspx.vb" Inherits="Pages.Cadastros.export.Frequencias" title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
        	<asp:BoundField HeaderText="Frequencia" DataField="Frequencia" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Criado" DataField="Criado" ItemStyle-CssClass="xl26" />
        </Columns>
    </asp:GridView>    
</asp:Content>

