﻿<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="clientes.aspx.vb" Inherits="Roteiros_clientes" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
				<div class='FiltroLetras'>
					<uc2:Letras ID="Letras1" runat="server" />
				</div>
		        <div class='FiltroItem'>UF<br>
		            <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF">
                        <asp:ListItem Value=''>TODAS</asp:ListItem>
                        <asp:ListItem Value='AC'>AC</asp:ListItem>
                        <asp:ListItem Value='AL'>AL</asp:ListItem>
                        <asp:ListItem Value='AM'>AM</asp:ListItem>
                        <asp:ListItem Value='AP'>AP</asp:ListItem>
                        <asp:ListItem Value='BA'>BA</asp:ListItem>
                        <asp:ListItem Value='CE'>CE</asp:ListItem>
                        <asp:ListItem Value='DF'>DF</asp:ListItem>
                        <asp:ListItem Value='ES'>ES</asp:ListItem>
                        <asp:ListItem Value='GO'>GO</asp:ListItem>
                        <asp:ListItem Value='MA'>MA</asp:ListItem>
                        <asp:ListItem Value='MG'>MG</asp:ListItem>
                        <asp:ListItem Value='MS'>MS</asp:ListItem>
                        <asp:ListItem Value='MT'>MT</asp:ListItem>
                        <asp:ListItem Value='PA'>PA</asp:ListItem>
                        <asp:ListItem Value='PB'>PB</asp:ListItem>
                        <asp:ListItem Value='PE'>PE</asp:ListItem>
                        <asp:ListItem Value='PI'>PI</asp:ListItem>
                        <asp:ListItem Value='PR'>PR</asp:ListItem>
                        <asp:ListItem Value='RJ'>RJ</asp:ListItem>
                        <asp:ListItem Value='RN'>RN</asp:ListItem>
                        <asp:ListItem Value='RO'>RO</asp:ListItem>
                        <asp:ListItem Value='RR'>RR</asp:ListItem>
                        <asp:ListItem Value='RS'>RS</asp:ListItem>
                        <asp:ListItem Value='SC'>SC</asp:ListItem>
                        <asp:ListItem Value='SE'>SE</asp:ListItem>
                        <asp:ListItem Value='SP'>SP</asp:ListItem>
                        <asp:ListItem Value='TO'>TO</asp:ListItem>
   		            </asp:DropDownList>
		        </div>
                <div class='FiltroItem'>Referência<br>
                    <asp:DropDownList runat="server" ID="drpReferencia" DataTextField="Referencia" DataValueField="Referencia"></asp:DropDownList>
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
						<asp:HyperLinkField DataNavigateUrlFields="IDCliente" DataNavigateUrlFormatString="consignado.aspx?IDCliente={0}" DataTextField="Codigo" HeaderText="C&oacute;digo" SortExpression="Codigo"  />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
                        <asp:BoundField HeaderText="Nome Fantasia" DataField="NomeFantasia" SortExpression="NomeFantasia" />
						<asp:BoundField HeaderText="CNPJ" DataField="CNPJ" SortExpression="CNPJ" />
						<asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
                        <asp:BoundField HeaderText="Referência" DataField="REFERENCIA" SortExpression="REFERENCIA" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; clientes com o filtro selecionado!
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cliente.aspx?idcliente=0'" visible='false' />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
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

