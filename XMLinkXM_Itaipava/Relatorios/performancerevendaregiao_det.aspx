<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="performancerevendaregiao_det.aspx.vb" Inherits="Relatorios_performancerevendaregiao_det" %>

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
	        <uc1:Filtro ID="Filtro1" runat="server" ShowDias='false' ShowGerenteVendas='false' ShowSupervisor='false' ShowVendedor='false' ShowMapa='false' ShowStatus='false'
                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            
            <div id='divVoltar' style="background-color:Gray;height:15px;padding-left:5px;" runat='server' visible='false' >
                <asp:LinkButton ID="lnkVoltar" Font-Bold="true" ForeColor="White" Runat="server" >Voltar p/ Nível Anterior</asp:LinkButton>
            </div>
	        <asp:Repeater runat='server' ID='grdRelatorioRegionais' OnItemCommand="ItemCommandRegionais" >
	            <HeaderTemplate>
                    <div class="scrollTableContainer2">
                    <table class="dataTable" cellspacing="0" cellpadding="4">
                        <thead>
		                    <tr class="GridHeader" align="left">
			                    <th scope="col">&#160;<%# ViewState("Tipo") %></th><th scope="col">Performance </th><th align="center" scope="col"> Progr</th><th align="center" scope="col"> Real.</th><th align="center" scope="col"> Vendas</th><th align="center" scope="col"> Just.</th><th align="center" scope="col">Fora de Rota</th><th align="center" scope="col"> Total</th>
		                    </tr>
		                </thead>
		                <tbody>
	            </HeaderTemplate>
	            <ItemTemplate>
                    <tr style="background-color:White;">
			            <td style="white-space:nowrap;">
                            <asp:LinkButton CommandArgument='<%# Eval("IdRegional") %>' ID="lnkItem" Runat="server"><%#Eval("Regional") %></asp:LinkButton>
                            <asp:HyperLink ID='lnkIdRevenda' runat="server" Target="_blank" Visible="false"><%#Eval("Regional") %></asp:HyperLink>
                        </td>
			            <td style="height:20px;width:20%;">			        
                            <uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Previsto") %>'  Value='<%# Eval("Visitas") - Eval("Justificadas") %>' SecondValue='<%# Eval("Justificadas") %>' />		    
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Previsto"), "Previsto"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Visitas"), "Visitas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("ComVenda"), "ComVendas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Justificadas"), "Justificadas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("ForaRota"), "ForaRota"), 0)%>
                        </td><td align="right">
                            <%#FormatCurrency(Soma.Add(Eval("TotalPedidos"), "PedidosTotal"), 2)%>
                        </td>
                    </tr>	    
	            </ItemTemplate>
	            <AlternatingItemTemplate>
                    <tr style="background-color:#EFF3FB;">
			            <td style="white-space:nowrap;">
                            <asp:LinkButton CommandArgument='<%# Eval("IdRegional") %>' ID="lnkItem" Runat="server"><%#Eval("Regional") %></asp:LinkButton>
                            <asp:HyperLink ID='lnkIdRevenda' runat="server" Target="_blank" Visible="false"><%#Eval("Regional") %></asp:HyperLink>
                        </td>
			            <td style="height:20px;width:20%;">			        
                            <uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Previsto") %>'  Value='<%# Eval("Visitas") - Eval("Justificadas") %>' SecondValue='<%# Eval("Justificadas") %>' />		    
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Previsto"), "Previsto"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Visitas"), "Visitas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("ComVenda"), "ComVendas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("Justificadas"), "Justificadas"), 0)%>
                        </td><td align="center">
                            <%#FormatNumber(Soma.Add(Eval("ForaRota"), "ForaRota"), 0)%>
                        </td><td align="right">
                            <%#FormatCurrency(Soma.Add(Eval("TotalPedidos"), "PedidosTotal"), 2)%>
                        </td>
                    </tr>	    
	            </AlternatingItemTemplate>
	            <FooterTemplate>
		                </tbody>
		                <tfoot>
                            <tr align="center" class="GridHeader">
                                <td align="left">
                                </td><td align="center">
                                    Total
                                </td><td>
			                        <%#FormatNumber(Soma.Item("Previsto").Sum, 0)%>
			                    </td><td>
			                        <%#FormatNumber(Soma.Item("Visitas").Sum, 0)%>
			                    </td><td>
			                        <%#FormatNumber(Soma.Item("ComVendas").Sum, 0)%>
			                    </td><td>
			                        <%#FormatNumber(Soma.Item("Justificadas").Sum, 0)%>
			                    </td><td>
			                        <%#FormatNumber(Soma.Item("ForaRota").Sum, 0)%>
			                    </td><td align="right">
			                        <%#FormatCurrency(Soma.Item("PedidosTotal").Sum, 2)%>
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

