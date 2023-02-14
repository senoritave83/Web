<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Lojas.aspx.vb" Inherits="Pages.Cadastros.Lojas" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroItem'>
            <asp:Literal ID="ltrRevenda" runat="server" Text='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' /><br>
            <asp:DropDownList runat="server" ID="cboIDCliente" DataTextField="Fantasia" DataValueField="IDCliente"/>
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
        <div class='FiltroItem'><asp:Literal ID="Literal1" runat="Server" Text='<%$Settings: Caption, Regiao, "Regi&atilde;o"%>'></asp:Literal><br>
            <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" />
        </div>
        <div class='FiltroItem'>Status<br>
            <asp:DropDownList runat="server" ID="cboIDStatus">
                <asp:ListItem Text="TODAS" Value="2" Selected="True" />
                <asp:ListItem Text="Ativa" Value="1" />
                <asp:ListItem Text="Inativa" Value="0" />
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting="true" CellPadding="1" CellSpacing="1">
					<columns>
						<asp:HyperLinkField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" DataNavigateUrlFields="IDLoja" DataNavigateUrlFormatString="Loja.aspx?IDLoja={0}" DataTextField="Codigo" HeaderText="Codigo" SortExpression="Codigo"  />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Loja" DataField="Loja" SortExpression="Loja" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="CNPJ" DataField="CNPJ" SortExpression="CNPJ" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="UF" DataField="UF" SortExpression="UF" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Status" DataField="Status" SortExpression="Status" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' DataField="TipoLoja" SortExpression="TipoLoja" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText="Local da Loja" DataField="Shopping" SortExpression="Shopping" />
						<asp:BoundField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderText='<%$Settings: Caption, Regiao, "Regi&atilde;o"%>' DataField="Regiao" SortExpression="Regiao" />
					</columns>
                    <EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; lojas com o filtro selecionado!
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

