<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="Pages.Cadastros.Categorias" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro'/>
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting="true">
					<columns>
						<asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFields="IDCategoria"  SortExpression="Categoria" DataNavigateUrlFormatString="Categoria.aspx?IDCategoria={0}" DataTextField="Categoria" HeaderText="Segmento"  />
						<asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Criado" DataField="Criado" SortExpression="Criado"  />
						<asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Ordem" DataField="Ordem"  SortExpression="Ordem" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
                            <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, Categoria.EmptyRow, "N&atilde;o h&aacute; segmentos com o filtro selecionado!"%>' />							    
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

