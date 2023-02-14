<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="SegmentacaoPDV.aspx.vb" Inherits="Enquetes_SegmentacaoPDV" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasEmpresas="false" ShowPesquisas="0" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
	        <div class='ListArea'>
                <div class="scrollTableContainer2">
                    <asp:GridView runat="server" ID="grdSegmentacaoPDV" AutoGenerateColumns="false" AllowSorting="true">
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Vendedor" HeaderText="Vendedor"  SortExpression="Vendedor"  />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente"  SortExpression="Cliente"  />
                            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data"  />
                            <asp:BoundField DataField="Pergunta" HeaderText="Segmentação" SortExpression="Resposta"  />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo"  />
                            <asp:BoundField DataField="ClasseSocial" HeaderText="Classe Social" SortExpression="Codigo"  />
                        </Columns>
                    </asp:GridView>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>		
</asp:Content>

