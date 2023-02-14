<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="Roteiros_Default" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<%@ Register src="../controls/FiltroSuperior.ascx" tagname="FiltroSuperior" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br />
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroItem'>Tipo de usuário<br />
            <asp:DropDownList runat='server' ID='cboTeste'>
	            <asp:ListItem value="2">Todos</asp:ListItem>
	            <asp:ListItem value="0">Normal</asp:ListItem>
	            <asp:ListItem value="1">Teste</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:UpdatePanel runat='server' ID='updCoordenador' CssClass="FiltroItem" style="width:255px; display:inline;">
            <ContentTemplate>
                <uc1:FiltroSuperior ID="FiltroSuperior1" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class='FiltroItem'>UF<br>
            <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
					    <asp:TemplateField HeaderText="Usuário" SortExpression="Promotor">
					        <ItemTemplate>
					            <a href="promotor_roteiro.aspx?idpromotor=<%#Eval("IDUsuario")%>"><%#Eval("Usuario")%></a>
					        </ItemTemplate>
					    </asp:TemplateField>
						<asp:BoundField HeaderText="Login" DataField="Login" SortExpression="Login" />
						<asp:BoundField HeaderText="CPF" DataField="CPF" SortExpression="CPF" />
						<asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
						<asp:BoundField HeaderText="Tipo" DataField="Teste" SortExpression="Teste" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; usuários cadastrados!
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
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='../cadastros/default.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Promotor.Exportar, false %>' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>


