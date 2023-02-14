<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Visita.aspx.vb" Inherits="Pages.Visita.Visita" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField' style='width:250px'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDCliente'>
						Cliente:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:Label runat='server' ID='lblCliente' />
				</td>
				<td class='tdFieldHeader2'>
				    <asp:Label runat='server' ID='lblTextoIDVendedor'>
						Vendedor:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:Label runat='server' ID='lblVendedor' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoData'>
						In&iacute;cio:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:Label runat='server' ID='lblData' />
				</td>
				<td class='tdFieldHeader2'>
				    <asp:Label runat='server' ID='lblTextoIDTipoJustificativa'>
						Justificativa:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDTipoJustificativa" DataTextField="TipoJustificativa" DataValueField="IDTipoJustificativa" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDTipoJustificativa' Display='None' ErrorMessage='TipoJustificativa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDTipoJustificativa' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan=4>&nbsp;</td>
			</tr>
		</table>
	</div>
	<div id='AreaPedidos'>
	    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
	    <div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDPedido" DataNavigateUrlFormatString="Pedido.aspx?IDPedido={0}" DataTextField="NumeroPedido" HeaderText="N&uacute;mero" SortExpression="NumeroPedido"  />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Data de Emiss&atilde;o" DataField="DataEmissao" SortExpression="DataEmissao" />
						<asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
						<asp:BoundField HeaderText="Tipo" DataField="TipoPedido" SortExpression="TipoPedido" />
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
			</ContentTemplate>
            <Triggers>
                
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Visitas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

