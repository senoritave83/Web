<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedidos.aspx.vb" Inherits="Pages.Pedidos.Pedidos" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        function printReport() {
            var url = "Pedidos_prn.aspx?";
                url += "Filtro=" + document.getElementById('<%=txtFiltro.ClientID%>').value;
                url += "&IDVendedor=" + document.getElementById('<%=cboIDVendedor.ClientID%>').value;
                url += "&Cliente=" + document.getElementById('<%=txtCliente.ClientID%>').value;
                url += "&Inicio=" + document.getElementById('<%=txtDataEmissaoInicial.ClientID%>').value;
                url += "&Fim=" + document.getElementById('<%=txtDataEmissaoFinal.ClientID%>').value;
                url += "&Status=" + document.getElementById('<%=cboIDStatus.ClientID%>').value;
                url += "&Tipo=" + document.getElementById('<%=cboIDTipoPedido.ClientID%>').value;
                url += "&QtdRegistros=" + document.getElementById('<%=hidQtdeReg.ClientID%>').value;
                url += "&Secao=<%=SecaoAtual %>";

            window.open(url, 'IMPRIMIR_RELATORIO_PEDIDOS','width=850,height=650,status=no,scrollbars=yes,toolbar=no,top=20,left=20');
        }
    </script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem'>Filtro<br>
		            <asp:TextBox runat='server' ID='txtFiltro' />
		        </div>
		        <div class='FiltroItem' style="width:100px">Vendedor<br>
                    <asp:DropDownList runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
		        </div>
		        <div class='FiltroItem'>Cliente<br>
		            <asp:TextBox runat='server' ID='txtCliente' />
		        </div>
		        <div class='FiltroItem'>Status<br>
		            <asp:DropDownList runat="server" ID="cboIDStatus" DataTextField="Status" DataValueField="IDStatus" />
		        </div>
		        <div class='FiltroItem'>Data<br>
		            <div style="width:200px">
						<asp:TextBox runat='server' ID='txtDataEmissaoInicial' MaxLength="10" Width='75px' />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataEmissaoFinal' MaxLength="10" Width='75px' />
		            </div>
		        </div>
		        <div class='FiltroItem'>Tipo<br>
		            <asp:DropDownList runat="server" ID="cboIDTipoPedido">
		                <asp:ListItem Value='0'>Todos</asp:ListItem>
		                <asp:ListItem Value='1'>Pedidos Normais</asp:ListItem>
		                <asp:ListItem Value='2'>Consignados</asp:ListItem>
		            </asp:DropDownList>
		        </div>                
		        <div class='FiltroItem'>Forma de Pagto<br>
		            <asp:DropDownList runat="server" ID="cboIDFormaPagto" DataTextField="FormaPagamento" DataValueField="IDFormaPagamento" />
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' ShowFooter="false">
				    <HeaderStyle HorizontalAlign='Left' />
                    <RowStyle HorizontalAlign="Left" />
                    <FooterStyle HorizontalAlign="Left" Height="14" />
					<columns>
						<asp:HyperLinkField FooterText='Total Geral' DataNavigateUrlFields="IDPedido" DataNavigateUrlFormatString="Pedido.aspx?IDPedido={0}" DataTextField="NumeroPedido" HeaderText="N&uacute;mero" SortExpression="NumeroPedido"  />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Data de Emissao" DataField="DataEmissao" SortExpression="DataEmissao" />
						<asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
						<asp:BoundField HeaderText="Tipo" DataField="TipoPedido" SortExpression="TipoPedido" />
                        <asp:TemplateField HeaderText="Total do Pedido" SortExpression="TotalPedido">
			                <ItemTemplate>
                                <%#FormatCurrency(Eval("TotalPedido"), 2)%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <asp:Label id="lblValorTotal" runat="server"></asp:Label>
			                </FooterTemplate>
			            </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Pedidos com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <input type="hidden" id="hidQtdeReg" runat="server" />
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>
	</div>		
    <div id="divBotoes" runat="server" class='AreaBotoes' >
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='../controle/default.aspx'" />
		<asp:Button runat='server' ID='btnExportar' Text='Exportar' />
        <input type="button" onclick="javascript:printReport();" value="Imprimir" class='Botao' />
        <input type="button"  onclick="location.href='Email.aspx'" value="ENVIO DE CÓPIA DO PEDIDO"  class='Botao' style="width: 300 ;height:18 " />
	</div>
</asp:Content>

