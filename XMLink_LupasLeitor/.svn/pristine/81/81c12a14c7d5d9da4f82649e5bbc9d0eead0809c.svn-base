<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PedidoEstoqueVendedores.aspx.vb" Inherits="Pages.Cadastros.PedidoEstoqueVendedores" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroLetras' style="width:100%;">
					<xm:Letras ID="Letras1" runat="server" />
				</div>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 


		        <div class='FiltroItem cb' style="width:400px;">Data<br>
                        <span style="float:left;margin-right:10px;">
						    <asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" />   
						    <asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						    <ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                        </span>
                        <span style="float:left">
                            at&eacute;
                        </span>
                        <span style="float:left;margin-left:10px;">
						    <asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" />
						    <ajaxToolkit:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						    <asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
                     </span>
		        </div>


		        <div class='FiltroItem' style="float:left">Numero<br>
						<asp:TextBox runat='server' ID='txtIDPedidoEstoqueVendedor' />
						<asp:CompareValidator runat='server'  ID='valCompIDPedidoEstoqueVendedor' Display='None' ErrorMessage='IDPedidoEstoqueVendedor inv&aacute;lida' ControlToValidate='txtIDPedidoEstoqueVendedor' Operator='DataTypeCheck' Type='Integer' />
		        </div>
		        <div class='FiltroItem'>Tipo<br>
		            <asp:DropDownList runat='server' ID='cboTipoPedido'>
		            	<asp:ListItem value="0">Todos</asp:ListItem>
                        <asp:ListItem value="1">Inclusão de Estoque</asp:ListItem>
                        <asp:ListItem value="2">Devolução de Estoque</asp:ListItem>
		            </asp:DropDownList>
		        </div>
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:DropDownList runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
		        </div>
		        <div class='FiltroItem'>Usuario<br>
		            <asp:DropDownList runat="server" ID="cboIDUsuario" DataTextField="Usuario" DataValueField="IDUsuario" />
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDPedidoEstoqueVendedor" DataNavigateUrlFormatString="pedidoestoquevendedor.aspx?idpev={0}" DataTextField="IDPedidoEstoqueVendedor" HeaderText="Numero" SortExpression="IDPedidoEstoqueVendedor"  />
						<asp:BoundField HeaderText="TipoPedido" DataField="TipoPedido" SortExpression="TipoPedido" />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
                        <asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="Status" />
						<asp:BoundField HeaderText="Usuario Responsavel" DataField="Usuario" SortExpression="Usuario" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; PedidoEstoqueVendedores com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <xm:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='pedidoestoquevendedor.aspx?idpev=0'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

