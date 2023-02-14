<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedidos.aspx.vb" Inherits="Pages.Pedidos.Pedidos" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem'>Num Pedido<br>
		            <asp:TextBox runat='server' ID='txtFiltro' />
		        </div>
                <div class='FiltroItem'>Cliente<br>
		            <asp:TextBox runat='server' ID='txtCliente' Width="95%" />
		        </div>
                <div class='FiltroItem' runat='server' id='divGerenteVendas' style="padding-left:5px;">
                    Gerente de Vendas
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboGerenteVendas' DataTextField='GerenteVendas' DataValueField='IdGerenteVendas' width="80%"></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='divSupervisor' style="padding-left:5px;">
                    Supervisor
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboSupervisor' DataTextField='Supervisor' DataValueField='IDSupervisor' width="80%"></asp:DropDownList>
                </div>
                 <div class='FiltroItem' runat='server' id='divVendedor' style="padding-left:5px;">
                    Vendedor
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboVendedor' DataTextField='Vendedor' DataValueField='IdVendedor' width="80%"></asp:DropDownList>
                </div><br class='cb' />
		        <div class='FiltroItem'>Grupo<br>
		            <asp:DropDownList runat="server" ID="cboGrupo" DataTextField="Grupo" DataValueField="IDGrupo" width="80%" />
		        </div>
		        <div class='FiltroItem'>Status<br>
		            <asp:DropDownList runat="server" ID="cboIDStatus" DataTextField="Status" DataValueField="IDStatus" width="80%" />
		        </div>
		        <div class='FiltroItem' style="padding-left:5px;">Tipo<br>
		            <asp:DropDownList runat="server" ID="cboIDTipoPedido" DataTextField='TipoPedido' DataValueField='IDTipoPedido'>
		            </asp:DropDownList>
		        </div>
		        <div class='FiltroItem' style="padding-left:7px;">Data<br>
		            <div style="width:200px">
						<asp:TextBox runat='server' ID='txtDataEmissaoInicial' MaxLength="10" Width='75px' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataEmissaoInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server' SkinID='Data' ID='valCompDataEmissaoInicial' Display='None' ErrorMessage='DataEmissao inicial inv&aacute;lida' ControlToValidate='txtDataEmissaoInicial' Operator='DataTypeCheck' Type='Date' />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataEmissaoFinal' MaxLength="10" Width='75px' />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataEmissaoFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataFinal" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server' SkinID='Data'  ID='valCompDataEmissaoFinal' Display='None' ErrorMessage='DataEmissao final inv&aacute;lida' ControlToValidate='txtDataEmissaoFinal' Operator='DataTypeCheck' Type='Date' />
		            </div>
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
						<asp:TemplateField HeaderText="N&uacute;mero" SortExpression="NumeroPedido">
						    <ItemTemplate>
                                <asp:HiddenField ID="hdnIdPedido" runat="server" Value='<%# Eval("IDPedido") %>' />
						        <a href='Pedido.aspx?IDPedido=<%# EVal("IDPedido") %>'><%# Eval("NumeroPedido") %></a>
						        <img src="~/imagens/exclam.jpg" runat='server' visible='<%# IIF(Eval("Obs") = 1, true, false) %>' />
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Data de Emissao" DataField="DataEmissao" SortExpression="DataEmissao" />
						<asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
                        <asp:BoundField HeaderText="Motivo de Pedido Em Trânsito" DataField="MotivoPedidoEmTransito" SortExpression="Motivo" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
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
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
        <asp:UpdatePanel runat='server' ID='updAprovacao'>
            <ContentTemplate>
                <div style='float:right;Width:97px;'>
                    <asp:Button runat='server' ID='btnAprovarTodos' Text='Aprovar todos' />
                    <asp:PlaceHolder runat='server' ID='plhConfirmar' Visible='False'>
                        <asp:Label runat='server' ID='lblEntrarMotivo' Text='Digite o motivo' ForeColor='White' />
                        <asp:TextBox runat='server' ID='txtMotivo' TextMode='MultiLine' Rows='3' Width='300px'></asp:TextBox>
                        <asp:Button runat='server' ID='btnConfirmar' Text='Confirmar' />
                    </asp:PlaceHolder>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <script type='text/javascript'>
        
            function fncAprovados(vTotal, vAprovados)
            {
                if (vAprovados == 0 && vTotal == 0)
                    alert(unescape("N%E3o h%E1 pedidos pendentes entre os pedidos listados."))
                else if (vAprovados == 0)
                    alert(unescape("N%E3o h%E1 pedidos pendentes que podem ser aprovados entre os pedidos listados."))
                else     
                    alert("Foram aprovados automaticamente " + vAprovados + " de " + vTotal + " pedidos listados." );
                    
            }
        </script>
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

