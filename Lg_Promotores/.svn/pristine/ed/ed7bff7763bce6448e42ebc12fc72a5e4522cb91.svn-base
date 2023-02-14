<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Produtos.aspx.vb" Inherits="Pages.Cadastros.Produtos" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <asp:UpdatePanel runat='server' ID='updSegmentos'>
            <ContentTemplate>
                <div class='FiltroItem'>Segmento<br>
                    <asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" AutoPostBack='true' />
                </div>
                <div class='FiltroItem'>Categoria<br>
                    <asp:DropDownList runat="server" ID="cboIDSubCategoria" DataTextField="SubCategoria" DataValueField="IDSubCategoria" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class='FiltroItem'>Marca<br>
            <asp:DropDownList runat="server" ID="cboIDFornecedor" DataTextField="Fornecedor" DataValueField="IDFornecedor" />
        </div>
        <div class='FiltroItem'>Status<br>
            <asp:RadioButtonList runat="server" ID="rdStatusProduto" RepeatDirection="Vertical">
                <asp:ListItem Text="Todos" Selected="True" Value="2"></asp:ListItem>
                <asp:ListItem Text="Em Linha" Value="1" ></asp:ListItem>
                <asp:ListItem Text="Fora de Linha" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
		<div class='FiltroLetras'>
			<uc2:Letras ID="Letras1" runat="server" />
		</div>
		<div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDProduto" DataNavigateUrlFormatString="Produto.aspx?IDProduto={0}" DataTextField="Codigo" HeaderText="Codigo" SortExpression="Codigo"  />
						<asp:BoundField HeaderText="Segmento" DataField="Categoria" SortExpression="Categoria" />
						<asp:BoundField HeaderText="Categoria" DataField="SubCategoria" SortExpression="SubCategoria" />
						<asp:BoundField HeaderText="Descri&ccedil;&atilde;o" DataField="Descricao" SortExpression="Descricao" />
						<asp:BoundField HeaderText="Marca" DataField="Fornecedor" SortExpression="Fornecedor" />
                        <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
                        <asp:BoundField HeaderText="Pesquisa" DataField="StatusPesquisa" SortExpression="StatusPesquisa" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Produtos cadastradas!
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Produto.aspx?idproduto=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Produtos.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" />
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

