<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="SubCategorias.aspx.vb" Inherits="Pages.Cadastros.SubCategorias" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroItem'><asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal><br>
		    <asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
		</div>
        <div class='FiltroItem'>Status<br>
            <asp:DropDownList runat="server" ID="drpIdStatus">
                <asp:ListItem Text="Todos" Value="2" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
            </asp:DropDownList>
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
				<asp:GridView runat='server' id='GridView1'  DataKeyNames="IDSubCategoria" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDSubCategoria" DataNavigateUrlFormatString="SubCategoria.aspx?IDSubCategoria={0}" DataTextField="SubCategoria" HeaderText='<%$Settings: Caption, SubCategoria, "Categoria"%>'  SortExpression='SubCategoria'  />
						<asp:BoundField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>' DataField="Categoria" SortExpression='Categoria' />
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Status" DataField="Status" SortExpression="Status"  />
						<asp:BoundField HeaderText="Criado" DataField="Criado" SortExpression='Criado' />
                        <asp:TemplateField HeaderText="Ordem" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <table width="100">
                                    <tr><td>
                                    <%#Eval("Ordem")%></td><td>
                                        <asp:LinkButton ID="lnkUp" runat="server"
                                            CommandName="UP" 
                                            CommandArgument='<%# Eval("IdSubCategoria") %>'>
                                            <asp:Image ID="imgUp" ImageUrl="~/imagens/up_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td><td>
                                        <asp:LinkButton ID="lnkDown" runat="server"
                                            CommandName="DOWN" 
                                            CommandArgument='<%# Eval("IdSubCategoria") %>'>
                                            <asp:Image ID="imgDown" ImageUrl="~/imagens/down_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
                            <asp:Literal ID="Literal2" runat="server" Text='<%$Settings: texto, SubCategoria.Mensagens.Mensagem4, "N&atilde;o h&aacute; categorias com o filtro selecionado!"%>'></asp:Literal>
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='SubCategoria.aspx?idsubcategoria=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='SubCategorias.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, SubCategoria.Exportar, false %>' />
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

