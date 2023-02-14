<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="MensagemDias.aspx.vb" Inherits="Pages.Cadastros.export.MensagemDias" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
        	<asp:BoundField HeaderText="IDMensagemDia" DataField="IDMensagemDia" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Mensagem" DataField="Mensagem" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Data Inicial" DataField="DataInicio" ItemStyle-CssClass="xl26" />
        	<asp:BoundField HeaderText="Data Final" DataField="DataDim" ItemStyle-CssClass="xl26" />
			<asp:BoundField HeaderText="IDSegmento" DataField="IDCategoria" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Segmento" DataField="Categoria" ItemStyle-CssClass="xl28" />
        </Columns>
    </asp:GridView>    
</asp:Content>

