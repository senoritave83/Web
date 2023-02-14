<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="pedidos_det.aspx.vb" Inherits="Relatorios_pedidos_det" Title="Relatório Listagem de Pedidos" %>

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
	        <uc1:Filtro ID="Filtro1" runat="server" ShowCodigoCliente="false" ShowNomeCliente="false" ShowStatusVisita="false" ShowStatus="true" ShowDataInicial="true"
                    ShowDataFinal="false" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true" StatusClass='FiltroItem'
                    VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <asp:Repeater ID="rptPedidos_det" runat="server">
                <ItemTemplate>
                    <div class='EditArea'>
		                <div class='divEditArea' style="height:auto;">
		                    <div class='divHeader'>&nbsp;Nº do Pedido:  <b><%# Eval("NumeroPedido")%></b></div>
		                  <div style="float:left;">
			                <div class='trField cb' runat='server' id="trIDVendedor"  >
				                <div class='tdFieldHeader cb fl' style="text-align:left;">
					                Vendedor:
				                </div>
				                <div class='tdField fl'>
					                <%# Eval("Vendedor")%>
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='trIDCliente' >
				                <div class='tdFieldHeader cb fl' style="text-align:left;">
					                Cliente:
				                </div>
				                <div class='tdField fl'>
					                <%# Eval("Cliente")%>
				                </div>
			                </div>                            
			                <div class='trField cb' runat='server'  id='trIDPrazo' >
				                <div class='tdFieldHeader cb fl' style="text-align:left;">
					                Forma de Pagto:
				                </div>
				                <div class='tdField fl'>
					                <%# Eval("Prazo")%>
				                </div>
			                </div>			                
			                <div class='trField cb' runat='server'  id='trTotalPedido' >
				                <div class='tdFieldHeader cb fl' style="text-align:left; ">
					                Total do Pedido:
				                </div>
				                <div class='tdField fl'>
					                <%#FormatCurrency(Eval("TotalPedido"))%>
				                </div>
			                </div>
			          </div>      
			                <br style="clear:both;">   
			                <span>&nbsp;</span>                         
                            <div>    
                            	<div style="padding:3px 0px 3px 10px; background-color:#A4D3EE; color:#898989;">                     
                                    <h2>Itens do Pedido</h2>	
                                </div>     		                    
                                <div>
	                                <asp:GridView runat='server' ID='grdItens' DataSource='<%# ListItensPedido(Eval("IDPedido")) %>' SkinID='GridRelatorios' AutoGenerateColumns='false' >
	                                    <HeaderStyle HorizontalAlign='Center' />
                                        <RowStyle HorizontalAlign="Center" />
			                            <Columns>
			                                <asp:BoundField DataField='Tabela' HeaderText='Tabela' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign="Left"/>
			                                <asp:BoundField DataField='Codigo' HeaderText='C&oacute;d. do Produto' />
			                                <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o do Produto' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign="Left" />
			                                <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			                                <asp:TemplateField HeaderText="Valor Unit&aacute;rio">
				                                <ItemTemplate>
					                                <font class="TextDefault">
						                                <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					                                </font>
				                                </ItemTemplate>
			                                </asp:TemplateField>
			                                <asp:TemplateField HeaderText="Valor Total" ItemStyle-Width="80">
				                                <ItemTemplate>
					                                <font class="TextDefault">
						                                <%#FormatCurrency(Eval("Total"), 2)%>
					                                </font>
				                                </ItemTemplate>
			                                </asp:TemplateField>
		                                </Columns>
	                                </asp:GridView>
                                </div>
                            </div>
			            </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>                
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>

