<%@ Page Title="" Language="VB" MasterPageFile="~/Cadastros/export/export.master" AutoEventWireup="false" CodeFile="listaroteiros.aspx.vb" Inherits="Pages.Cadastros.roteiros.export.listaroteiros" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
        	<asp:BoundField HeaderText="IDPromotor" DataField="IDPromotor" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Promotor" DataField="Promotor" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Coordenador" DataField="Coordenador" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Lider" DataField="Lider" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Login" DataField="Login" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="CPF" DataField="CPF" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="UF" DataField="UF" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Regiao" DataField="Regiao" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Tipo" DataField="Teste" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-CssClass="xl28" />
        </Columns>
    </asp:GridView>    
</asp:Content>

