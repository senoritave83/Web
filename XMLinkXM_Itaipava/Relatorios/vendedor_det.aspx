<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="vendedor_det.aspx.vb" Inherits="Relatorios_vendedor" title="Untitled Page" %>
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
	        <uc1:Filtro ID="Filtro1" runat="server" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                    ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <br />
            <asp:Repeater runat='server' ID='grdRelatorio'>
                <HeaderTemplate>
                    <div class="scrollTableContainer2">
            	        <table class="dataTable" cellspacing="0" cellpadding="4" border="0" id="ctl00_cphRelatorio_grdRelatorio" style="border-style:None;width:100%;border-collapse:collapse;">
            	            <thead>
		                        <tr class="GridHeader" align="left" valign='top'>
			                        <th scope="col" rowspan='2'>Vendedor</th><th scope="col" colspan='4' align='center'>Volume</th><th scope="col" rowspan='2'>Positivação</th><th scope="col" rowspan='2'>$</th>
		                        </tr>
		                        <tr class="GridHeader" align="left">
			                        <th scope="col">Latas</th><th scope="col">Garrafas</th><th scope="col">LongNeck</th><th scope="col">Total</th>
		                        </tr>
            	            </thead>
            	            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr style="background-color:#EFF3FB;">
			                <td><%# Eval("Vendedor") %></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Latas"), "Latas"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Garrafas"), "Garrafas"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("LongNeck"), "LongNeck"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("TotalItens"), "TotalItens"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Positivacao"), "Positivacao"), 0)%></td>
			                <td><%#FormatCurrency(Soma.Add(Eval("TotalPedidos"), "TotalPedidos"), 2)%></td>
		                </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                        <tr style="background-color:White;">
			                <td><%# Eval("Vendedor") %></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Latas"), "Latas"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Garrafas"), "Garrafas"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("LongNeck"), "LongNeck"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("TotalItens"), "TotalItens"), 0)%></td>
			                <td><%#FormatNumber(Soma.Add(Eval("Positivacao"), "Positivacao"), 0)%></td>
			                <td><%#FormatCurrency(Soma.Add(Eval("TotalPedidos"), "TotalPedidos"), 2)%></td>
		                </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
        	            </tbody>
        	            <tfoot>
                                <tr class="GridHeader">
			                        <td>Total</td>
			                        <td><%#FormatNumber(Soma.Item("Latas").Sum, 0)%></td>
			                        <td><%#FormatNumber(Soma.Item("Garrafas").Sum, 0)%></td>
			                        <td><%#FormatNumber(Soma.Item("LongNeck").Sum, 0)%></td>
			                        <td><%#FormatNumber(Soma.Item("TotalItens").Sum, 0)%></td>
			                        <td><%#FormatNumber(Soma.Item("Positivacao").Sum, 0)%></td>
			                        <td><%#FormatCurrency(Soma.Item("TotalPedidos").Sum, 2)%></td>
		                        </tr>
        	            </tfoot>
                    </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

