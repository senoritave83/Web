<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="status_det.aspx.vb" Inherits="Relatorios_status" title="Pedidos por Status" %>

<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' />
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updRep">
        <ContentTemplate>
	        <uc1:Filtro ID="Filtro1" runat="server" ShowDias='false' ShowGerenteVendas='false' ShowVendedor='false' ShowMapa='false'
                    ShowStatus='false' ShowCodigoCliente="false" ShowNomeCliente="false" ShowStatusVisita="false" 
                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	        <asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter='true' SkinID='GridRelatorios'>
	            <HeaderStyle HorizontalAlign='Center' />
                <RowStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
		        <Columns>
			        <asp:BoundField HeaderText="Status" DataField='Status' FooterText='Total' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left"/>
			        <asp:TemplateField HeaderText="Quantidade">
			            <ItemTemplate>
			                <%#FormatNumber(Soma.Add(Eval("Quantidade"), "Quantidade"), 0)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatNumber(Soma.Item("Quantidade").Sum, 0)%>
			            </FooterTemplate>
			        </asp:TemplateField>
			        <asp:TemplateField HeaderText="Total">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("Total"), "Total"), 2)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatCurrency(Soma.Item("Total").Sum, 2)%>
			            </FooterTemplate>
			        </asp:TemplateField>
			        <asp:TemplateField HeaderText="Média">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("Media"), "Media"), 2)%>
			            </ItemTemplate>
			        </asp:TemplateField>
		        </Columns>
                <EmptyDataTemplate>
                    Não há registros com o filtro selecionado!
                </EmptyDataTemplate>
	        </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

