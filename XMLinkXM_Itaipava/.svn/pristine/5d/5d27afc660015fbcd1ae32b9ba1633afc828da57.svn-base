<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="acomppositivacao_det.aspx.vb" Inherits="Relatorios_acomppositivacao" title="Eficiência de Visitas" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' />
        <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </ProgressTemplate>
        </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updRep">
     <ContentTemplate>
	    <uc1:Filtro ID="Filtro1" runat="server" ShowDataInicial="true" ShowDataFinal="true" ShowGerenteVendas="true" ShowSupervisor="true"
            ShowVendedor="false" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
        <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter='true' SkinID='GridRelatorios'>
	            <HeaderStyle HorizontalAlign='Center' />
                <RowStyle HorizontalAlign='Center' />
		        <Columns>
		            <asp:BoundField HeaderText="Codigo&nbsp;" DataField='CodigoRevenda' />
			        <asp:BoundField HeaderText="Revenda" DataField='Revenda' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left' />
			        <asp:BoundField HeaderText="Previsto" DataField='Previsto' />
			        <asp:BoundField HeaderText="Realizadas" DataField='Realizadas' />
                    <asp:BoundField HeaderText="Fora de Rota" DataField='ForaRota' />
                    <asp:BoundField HeaderText="Diferença" DataField='Diferenca' />
                    <asp:BoundField HeaderText="Positivação" DataField='ComVenda' />
                    <asp:BoundField HeaderText="Justificativa" DataField='Justificativa' />
                    <asp:BoundField DataFormatString="{0:#,##0.00}" HeaderText="% Positivação" DataField='PorcPositivacao' />
                    <asp:BoundField DataFormatString="{0:#,##0.00}" HeaderText="% Justificativa" DataField='PorcJustificativa' />
		        </Columns>
                <EmptyDataTemplate>
                    Não há registros com o filtro selecionado!
                </EmptyDataTemplate>
	        </asp:GridView>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

