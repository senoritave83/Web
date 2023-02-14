<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="historico_visitas_det.aspx.vb" Inherits="Relatorios_historico_visitas" title="Histórico de Visitas ao Cliente" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
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
	        <uc1:Filtro ID="Filtro1" runat="server" ShowCodigoCliente="true" ShowNomeCliente="true" ShowStatusVisita="true"
                    ShowDataInicial="true" ShowDataFinal="true" ShowSupervisor="false" ShowVendedor="true"
                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	            <asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter='true' SkinID='GridRelatorios'>
	                <HeaderStyle HorizontalAlign='Center' />
                    <RowStyle HorizontalAlign='Center' />
		            <Columns>
                        <asp:BoundField HeaderText="Cod. Cliente&nbsp;" DataField='IDCliente' />
			            <asp:BoundField HeaderText="Cliente" DataField='Cliente' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left'/>
                        <asp:BoundField HeaderText="Início da Visita&nbsp;" DataField='DataInicio' />
                        <asp:BoundField HeaderText="Fim da Visita&nbsp;" DataField='DataFim' />
                        <asp:BoundField HeaderText="Duração da Visita" DataField='DuracaoVisita' />
                        <asp:BoundField HeaderText="Status da Visita" DataField='StatusVisita' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left'/>
                        <asp:BoundField HeaderText="Vendedor" DataField='Vendedor' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left'/>
		            </Columns>
                    <EmptyDataTemplate>                   
                        Não há registros com o filtro selecionado!
                    </EmptyDataTemplate>
	            </asp:GridView>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
