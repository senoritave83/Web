<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Fornecedores.aspx.vb" Inherits="Pages.Cadastros.Fornecedores" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro'/>
        </div> 
        <div class='FiltroLetras'>
	        <xm:Letras ID="Letras1" runat="server" />
        </div>        
        <div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting="true" CellPadding="2" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDFornecedor" DataNavigateUrlFormatString="Fornecedor.aspx?IDFornecedor={0}" DataTextField="Fornecedor" HeaderText='<%$Settings: Caption, Fornecedor, "Marca"%>' SortExpression="Fornecedor"  />
						<asp:BoundField HeaderText="Criado" DataField="Criado" SortExpression="Criado" />
						<asp:CheckBoxField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
                            <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, Fornecedor.EmptyRow, "N&atilde;o h&aacute; marcas com o filtro selecionado!"%>' />							    
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Fornecedor.aspx?idfornecedor=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Fornecedores.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Fornecedor.Exportar, false %>' />
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

