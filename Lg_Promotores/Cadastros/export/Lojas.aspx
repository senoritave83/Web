<%@ Page Language="VB" MasterPageFile="~/Cadastros/export/export.master" AutoEventWireup="false" CodeFile="Lojas.aspx.vb" Inherits="Pages.Cadastros.export.Lojas" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
			<asp:BoundField HeaderText="IDRevenda" DataField="IDCliente" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="Revenda" DataField="Cliente" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText="IDLoja" DataField="IDLoja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Loja" DataField="Loja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="RazaoSocial" DataField="RazaoSocial" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="CNPJ" DataField="CNPJ" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="IE" DataField="IE" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Filial" DataField="Filial" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Endereco" DataField="Endereco" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Numero" DataField="Numero" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Complemento" DataField="Complemento" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Bairro" DataField="Bairro" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Cidade" DataField="Cidade" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="UF" DataField="UF" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Cep" DataField="Cep" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Contato" DataField="Contato" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Cargo" DataField="Cargo" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Telefone" DataField="Telefone" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Celular" DataField="Celular" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Fax" DataField="Fax" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' DataField="TipoLoja" ItemStyle-CssClass="xl28" />            
        	<asp:BoundField HeaderText="Shopping" DataField="Shopping" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="Regiao" DataField="Regiao" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="ClassificacaoConsumo" DataField="Classificação de Consumo" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="ClassificacaoLoja" DataField="Classificação de Loja" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="Segmento" DataField="Segmento" ItemStyle-CssClass="xl28" />
			<asp:BoundField HeaderText="Operadora" DataField="Operadora" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Tamanho" DataField="Tamanho da Loja" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="TamanhoEletronicos" DataField="Tamanho da Seção de Eletro-eletrônicos" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="GerenteConta" DataField="Gerente da Conta" ItemStyle-CssClass="xl28" />
            <asp:BoundField HeaderText='<%$ Settings: caption, Loja.TipoCliente, "Tipo de Cliente" %>' DataField="Tipo de Cliente" ItemStyle-CssClass="xl28" Visible='<%$ Settings: visible, Loja.TipoCliente, false %>' />
        </Columns>
    </asp:GridView>    
</asp:Content>

