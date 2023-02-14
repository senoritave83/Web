<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Lojas.aspx.vb" Inherits="Pages.Cadastros.Lojas" title="XM Promotores - Yes Mobile" %>
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
        <div class='FiltroItem'>
            <asp:Literal ID="ltrRevenda" runat="server" Text='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' /><br>
            <asp:DropDownList runat="server" ID="cboIDCliente" DataTextField="Fantasia" DataValueField="IDCliente" />
        </div>
        <div class='FiltroItem'>UF<br>
            <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
        </div>
        <div class='FiltroItem'>
            <asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' /><br>
            <asp:DropDownList runat="server" ID="cboIDTipoLoja" DataTextField="TipoLoja" DataValueField="IDTipoLoja" />
        </div>
        <div class='FiltroItem'>Loja de <br>
            <asp:DropDownList runat="server" ID="cboIDShopping" DataTextField="Shopping" DataValueField="IDShopping" />
        </div>
        <div class='FiltroItem'>Regi&atilde;o<br>
            <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" />
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
						<asp:HyperLinkField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" DataNavigateUrlFields="IDLoja" DataNavigateUrlFormatString="Loja.aspx?IDLoja={0}" DataTextField="Codigo" HeaderText="Codigo" SortExpression="Codigo"  />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Loja" DataField="Loja" SortExpression="Loja" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="CNPJ" DataField="CNPJ" SortExpression="CNPJ" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="UF" DataField="UF" SortExpression="UF" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Status" DataField="Status" SortExpression="Status" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' DataField="TipoLoja" SortExpression="TipoLoja" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Shopping" DataField="Shopping" SortExpression="Shopping" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Regi&atilde;o" DataField="Regiao" SortExpression="Regiao" />
					</columns>
                    <EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; lojas com o filtro selecionado!
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Loja.aspx?idloja=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Lojas.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Loja.Exportar, false %>' />
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

