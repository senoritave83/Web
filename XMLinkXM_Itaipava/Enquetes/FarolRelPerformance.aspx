<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FarolRelPerformance.aspx.vb" Inherits="Enquetes_FarolRelPerformance" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<%@ Register assembly="XMCrossRepeater" namespace="XMSistemas.Web.UI.WebControls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasEmpresas="false" ShowPesquisas="1" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
	        <div class='ListArea'>
                <div class="scrollTableContainer2">
                        <table class="DataTable2" cellspacing="0" cellpadding="4" style="width:100%;border-collapse:collapse;text-align:center;">
                        <asp:GridView runat="server" ID="grdFarolDesempenhoEnquetes" AutoGenerateColumns="false" AllowSorting="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="Supervisor" HeaderText="Supervisor"/>
                        <asp:BoundField DataField="Vendedor" HeaderText="Vendedor"/>
                        <asp:BoundField DataField="Total" HeaderText="Total"/>
                        <asp:BoundField DataField="Realizadas" HeaderText="Realizadas"/>
                        <asp:BoundField DataField="Justificadas" HeaderText="Justificadas"/>
                    </Columns>
                </asp:GridView>
                        </table> 
                    </div> 
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>	
</asp:Content>

