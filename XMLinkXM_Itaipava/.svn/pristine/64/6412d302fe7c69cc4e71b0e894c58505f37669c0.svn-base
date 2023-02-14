<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="consolidado_det.aspx.vb" Inherits="Relatorios_consolidado_det" title="Relatório Volume de Vendas" %>

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
                  ShowVendedor="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	            <asp:Repeater runat='server' ID='grdRelatorio'>
	                <HeaderTemplate>
                        <div class="scrollTableContainer2">
                        <table class="dataTable" cellspacing="0" cellpadding="4" style="width:100%;border-collapse:collapse;">
                            <thead>
		                        <tr class="GridHeader" align="center">
			                        <th scope="col"><asp:linkbutton runat="server" ID="Produto" onclick='AllowSorting'>Cod. Produto</asp:linkbutton></th>
                                    <th scope="col" align="left"><asp:linkbutton runat="server" ID="Descricao" onclick='AllowSorting'>Descri&#231;&#227;o</asp:linkbutton></th>
                                    <th scope="col"><asp:linkbutton runat="server" ID="Bonificado" OnClick="AllowSorting">Qtd. Bonificada</asp:linkbutton></th>
                                    <th scope="col"><asp:linkbutton runat="server" ID="Vendido" onclick='AllowSorting'>Qtd. Vendida</asp:linkbutton></th>
                                    <th scope="col"><asp:linkbutton runat="server" ID="PrecoMedio" onclick='AllowSorting'>Preço Médio</asp:linkbutton></th>
                                    <th scope="col"><asp:linkbutton runat="server" ID="Positivacao" onclick='AllowSorting'>Positiva&#231;&#227;o</asp:linkbutton></th>
		                        </tr>
		                    </thead>
		                    <tbody>
	                </HeaderTemplate>
	                <ItemTemplate>
                        <tr style="background-color:White;" align="center">
			                <td>
			                    <%#Eval("Codigo")%>
			                </td><td align="left">
			                    <%#Eval("Descricao")%>
			                </td><td>
			                    <%#FormatNumber(Soma.Add(Eval("Qtd_Bonificada"), "Qtd_Bonificada"), 0)%>
			                </td><td>
			                    <%#FormatNumber(Soma.Add(Eval("Qtd_Vendida"), "Qtd_Vendida"), 0)%>
			                </td><td>
			                    <%#FormatCurrency(Eval("PrecoMedio"), 2)%>
			                </td><td>
			                    <%# Eval("Qtd_Clientes")%>
			                </td>
                        </tr>	    
	                </ItemTemplate>
	                <AlternatingItemTemplate>
                        <tr style="background-color:#EFF3FB;" align="center">
			                <td>
			                    <%#Eval("Codigo")%>
			                </td><td align="left">
			                    <%#Eval("Descricao")%>
			                </td><td>
			                    <%#FormatNumber(Soma.Add(Eval("Qtd_Bonificada"), "Qtd_Bonificada"), 0)%>
			                </td><td>
			                    <%#FormatNumber(Soma.Add(Eval("Qtd_Vendida"), "Qtd_Vendida"), 0)%>
			                </td><td>
			                    <%#FormatCurrency(Eval("PrecoMedio"), 2)%>
			                </td><td>
			                    <%# Eval("Qtd_Clientes")%>
			                </td>
                        </tr>	    
	                </AlternatingItemTemplate>
	                <FooterTemplate>
		                    </tbody>
		                    <tfoot>
                                <tr class="GridHeader" align="center">
                                    <td>&nbsp;</td>
                                    <td align="left">
                                        Total
                                    </td><td>
                                        <%#FormatNumber(Soma.Item("Qtd_Bonificada").Sum, 0)%>
                                    </td><td>
                                        <%#FormatNumber(Soma.Item("Qtd_Vendida").Sum, 0)%>
                                    </td><td>
                                        &nbsp;
                                    </td><td>
                                        &nbsp;
                                    </td>
			                    </tr>
		                    </tfoot>
	                        </table>
	                        </div>
		                </FooterTemplate>
	            </asp:Repeater>
                <div id='divEmpty' class='divEmptyRow' runat='server' visible='false' >
	                N&atilde;o h&aacute; registros com o filtro selecionado!
                </div>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

