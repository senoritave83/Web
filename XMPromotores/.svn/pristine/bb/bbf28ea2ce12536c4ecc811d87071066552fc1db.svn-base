<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Produtos.aspx.vb" Inherits="Pages.Cadastros.Produtos" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <asp:UpdatePanel runat='server' ID='updSegmentos' CssClass="FiltroItem" style="display:inline; width:260px;">
            <ContentTemplate>
                <div class='FiltroItem'><asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal><br>
                    <asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" AutoPostBack='true' CssClass="Select" />
                </div>
                <div class='FiltroItem'><asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal><br>
                    <asp:DropDownList runat="server" ID="cboIDSubCategoria" DataTextField="SubCategoria" DataValueField="IDSubCategoria" CssClass="Select" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class='FiltroItem'><asp:Literal ID="Literal3" runat="server" Text='<%$Settings: Caption, Fornecedor, "Marca"%>'></asp:Literal><br>
            <asp:DropDownList runat="server" ID="cboIDFornecedor" DataTextField="Fornecedor" DataValueField="IDFornecedor" CssClass="Select" />
        </div>
        <div>Status<br>
            <asp:RadioButtonList runat="server" ID="rdStatusProduto" RepeatDirection="Horizontal">
                <asp:ListItem Text="Todos" Selected="True" Value="2"></asp:ListItem>
                <asp:ListItem Text="Em Linha" Value="1" ></asp:ListItem>
                <asp:ListItem Text="Fora de Linha" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
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
				<asp:GridView runat='server' id='GridView1'  DataKeyNames="IDProduto" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDProduto" DataNavigateUrlFormatString="Produto.aspx?IDProduto={0}" DataTextField="Codigo" HeaderText="Codigo" SortExpression="Codigo"  />
						<asp:BoundField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>' DataField="Categoria" SortExpression="Categoria" />
						<asp:BoundField HeaderText='<%$Settings: Caption, SubCategoria, "Categoria"%>' DataField="SubCategoria" SortExpression="SubCategoria" />
						<asp:BoundField HeaderText="Descri&ccedil;&atilde;o" DataField="Descricao" SortExpression="Descricao" />
						<asp:BoundField HeaderText='<%$Settings: Caption, Fornecedor, "Marca"%>' DataField="Fornecedor" SortExpression="Fornecedor" />
                        <asp:BoundField HeaderText="Status" DataField="StatusComercio" SortExpression="StatusComercio" />
                        <asp:BoundField HeaderText="Pesquisa" DataField="StatusPesquisa" SortExpression="StatusPesquisa" />
                        <asp:TemplateField HeaderText="Ordem" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <table width="100">
                                    <tr><td>
                                    <%#Eval("Ordem")%></td><td>
                                        <asp:LinkButton ID="lnkUp" runat="server"
                                            CommandName="UP" 
                                            CommandArgument='<%# Eval("IdProduto") %>'>
                                            <asp:Image ID="imgUp" ImageUrl="~/imagens/up_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td><td>
                                        <asp:LinkButton ID="lnkDown" runat="server"
                                            CommandName="DOWN" 
                                            CommandArgument='<%# Eval("IdProduto") %>'>
                                            <asp:Image ID="imgDown" ImageUrl="~/imagens/down_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Produtos cadastrados!
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

