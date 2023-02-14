<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Lideres.aspx.vb" Inherits="Pages.Cadastros.export.Lideres" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
            <asp:BoundField HeaderText="Lider" DataField="Lider" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="Coordenador" DataField="Coordenador" ItemStyle-CssClass="xl28" />
        </Columns>
    </asp:GridView>    
</asp:Content>

