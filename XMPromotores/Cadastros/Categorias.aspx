<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="Pages.Cadastros.Categorias" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro'/>
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
				<asp:GridView runat='server' id='GridView1' DataKeyNames="IDCategoria" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns='false' AllowSorting="true" CellPadding="1" CellSpacing="1">
					<columns>
						<asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFields="IDCategoria"  SortExpression="Categoria" DataNavigateUrlFormatString="Categoria.aspx?IDCategoria={0}" DataTextField="Categoria" HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>'  />
						<asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Criado" DataField="Criado" SortExpression="Criado"  />
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Status" DataField="Status" SortExpression="Status"  />
                        <asp:TemplateField HeaderText="Ordem" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <table width="100">
                                    <tr><td>
                                    <%#Eval("Ordem")%></td><td>
                                        <asp:LinkButton ID="lnkUp" runat="server"
                                            CommandName="UP" 
                                            CommandArgument='<%# Eval("IdCategoria") %>'>
                                            <asp:Image ID="imgUp" ImageUrl="~/imagens/up_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td><td>
                                        <asp:LinkButton ID="lnkDown" runat="server"
                                            CommandName="DOWN" 
                                            CommandArgument='<%# Eval("IdCategoria") %>'>
                                            <asp:Image ID="imgDown" ImageUrl="~/imagens/down_peq.png" ToolTip="" runat="server" /></asp:LinkButton>   
                                    </td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
                            <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, Categoria.EmptyRow, "N&atilde;o h&aacute; segmentos com o filtro selecionado!"%>' />							    
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Categoria.aspx?idcategoria=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='categorias.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Categoria.Exportar, false %>' />
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

