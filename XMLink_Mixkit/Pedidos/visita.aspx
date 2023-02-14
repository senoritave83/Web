<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="visita.aspx.vb" Inherits="Pages.Pedidos.Visita" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trIDCliente' visible='<%$Settings: visible, Visita.IDCliente, true %>' >
				<div class='tdFieldHeader fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat="server" ID="lblCliente" />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trIDVendedor' visible='<%$Settings: visible, Visita.IDVendedor, true %>' >
				<div class='tdFieldHeader fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat="server" ID="lblVendedor" />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trData'  >
				<div class='tdFieldHeader fl'>
					Data da Visita:
				</div>
				<div class='tdField fl'>
					<asp:Label  runat='server' ID='lblData' />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trIDStatus' >
				<div class='tdFieldHeader fl'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblStatus'></asp:Label>
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trInicio' visible='<%$Settings: visible, Visita.Inicio, true %>' >
				<div class='tdFieldHeader fl'>
					In&iacute;cio da Visita:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblInicio' />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trLocalizacao' visible='<%$Settings: visible, Visita.Localizacao, true %>' >
				<div class='tdFieldHeader fl'>
					Localiza&ccedil;&atilde;o Inicial:
				</div>
				<div class='tdField fl'>
					<uc1:Localizacao ID="Localizacao1" runat="server" />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trTermino' visible='<%$Settings: visible, Visita.Termino, true %>' >
				<div class='tdFieldHeader fl'>
					Termino da Visita:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblTermino' />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='Div1' visible='<%$Settings: visible, Visita.Localizacao, true %>' >
				<div class='tdFieldHeader fl'>
					Localiza&ccedil;&atilde;o Final:
				</div>
				<div class='tdField fl'>
					<uc1:Localizacao ID="Localizacao2" runat="server" />
				</div>
			</div>
			<div class='trField fl' style="width:49%;" runat='server'  id='trJustificativa' >
				<div class='tdFieldHeader fl'>
					Justificativa:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblJustificativa'></asp:Label>
				</div>
			</div>
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='plhPedidos'>
        <br />
        <br />
	    Pedidos realizados
	    <asp:GridView runat='server' ID='grdPedidos' AutoGenerateColumns='false'>
	        <HeaderStyle HorizontalAlign='Left' />
	        <columns>
			    <asp:HyperLinkField DataNavigateUrlFields="IDPedido, IDVisita" DataNavigateUrlFormatString="Pedido.aspx?IDPedido={0}&idvisita={1}" DataTextField="NumeroPedido" HeaderText="N&uacute;mero" SortExpression="NumeroPedido"  />
			    <asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
			    <asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
			    <asp:BoundField HeaderText="Data de Emissao" DataField="DataEmissao" SortExpression="DataEmissao" />
			    <asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
			    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:C}' />
		    </columns>
	    </asp:GridView>
    </asp:PlaceHolder> 
    <div class='AreaBotoes'>
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='visitas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

