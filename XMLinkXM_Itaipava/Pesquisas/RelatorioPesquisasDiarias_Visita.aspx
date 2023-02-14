<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPesquisasDiarias_Visita.aspx.vb" Inherits="Pesquisas_RelatorioPesquisasDiarias_Visita" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class='EditArea'>
        <div class='divEditArea'>
	        <div class='divHeader'>&nbsp;Visita: <asp:Label runat='server' ID='lnkVisita'>0</asp:Label></div>
	        <div class='trField cb' runat='server'  id='trIDCliente' visible='<%$Settings: visible, Visita.IDCliente, true %>' >
		        <div class='tdFieldHeader cb fl'>
			        Cliente:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat="server" ID="lblCliente" />
		        </div>
	        </div>
	        <div class='trField fr' runat='server' style="width:40%" id='trIDVendedor' visible='<%$Settings: visible, Visita.IDVendedor, true %>' >
		        <div class='tdFieldHeader fl'>
			        Vendedor:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat="server" ID="lblVendedor" />
		        </div>
	        </div>
	        <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Visita.Endereco, true %>' >
		        <div class='tdFieldHeader cb fl'>
			        Endere&ccedil;o Cliente:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat="server" ID="lblEndereco" />
		        </div>
	        </div>
	        <div class='trField cb' runat='server'  id='trData' visible='<%$Settings: visible, Visita.Data, true %>' >
		        <div class='tdFieldHeader cb fl'>
			        Data da Visita:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label  runat='server' ID='lblData' />
		        </div>
	        </div>
	        <div class='trField fr' runat='server' style="width:40%" id='trIDJustificativa' visible='<%$Settings: visible, Visita.IDJustificativa, true %>' >
		        <div class='tdFieldHeader fl'>
			        Status:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat='server' ID='lblStatus'></asp:Label>
		        </div>
	        </div>
	        <div class='trField cb' runat='server'  id='trInicio' visible='<%$Settings: visible, Visita.Inicio, true %>' >
		        <div class='tdFieldHeader cb fl'>
			        In&iacute;cio da Visita:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat='server' ID='lblInicio' />
		        </div>
	        </div>
	        <div class='trField cb' runat='server'  id='trTermino' visible='<%$Settings: visible, Visita.Termino, true %>' >
		        <div class='tdFieldHeader cb fl'>
			        Termino da Visita:
		        </div>
		        <div class='tdField fl'>
			        <asp:Label runat='server' ID='lblTermino' />
		        </div>
	        </div>
        </div>
       </div>
        <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </ProgressTemplate>
        </asp:UpdateProgress> 
		<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView runat='server' id='grdRelatorioPesquisasVisita' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDVisita'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
                        <asp:BoundField HeaderText="Marca" DataField="Marca" SortExpression="Marca" ItemStyle-Wrap='false' />
						<asp:BoundField HeaderText="Produto" DataField="ProdutoPesquisa" SortExpression="ProdutoPesquisa" />
						<asp:BoundField HeaderText="Volume" DataField="Volume" SortExpression="Volume" />
                        <asp:BoundField HeaderText="Preço Ponta" DataField="PrecoPonta" SortExpression="PrecoPonta" />
                        <asp:BoundField HeaderText="Preço Varejo" DataField="PrecoVarejo" SortExpression="PrecoVarejo" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow' >
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; itens para essa pesquisa!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat="server" id="btnVoltar" CssClass="Botao" Text=" Voltar " />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

