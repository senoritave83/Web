<%@ Page Title="" Language="VB" MasterPageFile="~/Cadastros/export/export.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="roteiros_export_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
			<asp:BoundField HeaderText="Roteiro" DataField="IDRoteiro" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Codigo do Promotor" DataField="CodigoPromotor" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Promotor" DataField="Promotor" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Codigo da Loja" DataField="CodigoLoja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Loja" DataField="Loja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="CNPJ" DataField="CnpjLoja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Pesquisar" DataField="Pesquisar" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Dia(s) do Roteiro" DataField="Dia" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Mês(es) do Roteiro" DataField="Mes" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Dia(s) da Semana" DataField="DiaSemana" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Semana(s) do Mês" DataField="SemanaMes" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Roteiro Ativo" DataField="Ativo" ItemStyle-CssClass="xl28" />
        </Columns>
    </asp:GridView>    
</asp:Content>

