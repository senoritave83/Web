﻿<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedidos.aspx.vb" Inherits="Pages.Pedidos.Pedidos" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem'>Filtro<br>
		            <asp:TextBox runat='server' ID='txtFiltro' />
		        </div>
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:TextBox runat='server' ID='txtVendedor' />
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
						<asp:CompareValidator runat='server' SkinID='Data' ID='valCompDataEmissaoInicial' Display='None' ErrorMessage='DataEmissao inicial inv&aacute;lida' ControlToValidate='txtDataEmissaoInicial' Operator='DataTypeCheck' Type='Date' />
		        		até
						<asp:TextBox runat='server' ID='txtDataEmissaoFinal' MaxLength="10" Width='75px' />
						<asp:CompareValidator runat='server' SkinID='Data'  ID='valCompDataEmissaoFinal' Display='None' ErrorMessage='DataEmissao final inv&aacute;lida' ControlToValidate='txtDataEmissaoFinal' Operator='DataTypeCheck' Type='Date' />
		            </div>
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='500' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="updFiltro" DisplayAfter='500' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image2" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDPedido" DataNavigateUrlFormatString="Pedido.aspx?IDPedido={0}" DataTextField="NumeroPedido" HeaderText="Número" SortExpression="NumeroPedido"  />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Data de Emissao" DataField="DataEmissao" SortExpression="DataEmissao" />
						<asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
						<asp:BoundField HeaderText="Valor" DataField="Total" SortExpression="Total" DataFormatString='{0:C}' />
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
                <xm:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
</asp:Content>

