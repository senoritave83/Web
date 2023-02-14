<%@ Page Language="VB" MasterPageFile="~/Principal.master"  AutoEventWireup="false" CodeFile="positivacao_det.aspx.vb" Inherits="Relatorios_positivacao_det" Title="Relatório de Positivação" %>

<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' />
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updRep">
        <ContentTemplate>
	        <uc1:Filtro ID="Filtro1" runat="server" ShowDias='true' ShowGerenteVendas='true' ShowVendedor='true' 
                    ShowMapa='false' ShowStatus='false' ShowCodigoCliente="false" ShowNomeCliente="false" 
                    ShowStatusVisita="false" StatusClass='FiltroItem' 
                    ShowDataInicial="false" ShowDataFinal="false"
                    VendedorClass="FiltroItem" DataInicialClass="FiltroItem"
                    ShowCategoriaProd="true" ShowProduto="true" />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	        <asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter="true" SkinID="GridRelatorios">
	            <HeaderStyle HorizontalAlign="Left" />
		        <Columns>
		            <asp:BoundField HeaderText="Codigo&nbsp;" DataField="IdCliente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
			        <asp:BoundField HeaderText="Cliente" DataField="Cliente" HeaderStyle-HorizontalAlign="Center" />
			        <asp:BoundField HeaderText="Pasta" DataField="Pasta" HeaderStyle-HorizontalAlign="Center" />
			        <asp:BoundField HeaderText="Vendedor" DataField="Vendedor" HeaderStyle-HorizontalAlign="Center" />
			        <asp:BoundField HeaderText="Último Pedido" DataField="UltimoPedido" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
			        <asp:BoundField HeaderText="Qtd Dias S/ Ped" DataField="DiasSemPedido" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
		        </Columns>
                <EmptyDataTemplate>
                    Não há registros com o filtro selecionado!
                </EmptyDataTemplate>
	        </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

