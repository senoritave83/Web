<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Clientes.aspx.vb" Inherits="Pages.Cadastros.Clientes" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' CssClass="formulario"/>
        </div> 
        <div class='FiltroLetras'>
			<xm:Letras ID="Letras1" runat="server" />
		</div>
        <div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea' style="margin-left:10px; margin-right:10px; width:79%\9;">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1" CssClass="tabelas" >
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDCliente" DataNavigateUrlFormatString="Cliente.aspx?IDCliente={0}" DataTextField="RazaoSocial" HeaderText="<%$Settings: Caption, Cliente.RazaoSocial, Raz&atilde;o Social%>" SortExpression='RazaoSocial'  />
						<asp:BoundField HeaderText='<%$Settings: Caption, Cliente.Fantasia, "Fantasia"%>' DataField="Fantasia" SortExpression='Fantasia' />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        <asp:Literal runat="server" Text='<%$Settings: Caption, Cliente.EmptyRow, "N&atilde;o h&aacute; revendas com o filtro selecionado!"%>' />
					    </div>
					</EmptyDataTemplate>
					<PagerStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
				</asp:GridView>
                <xm:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cliente.aspx?idcliente=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Clientes.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Cliente.Exportar, false %>' />
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

