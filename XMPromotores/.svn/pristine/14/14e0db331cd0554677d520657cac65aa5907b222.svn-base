<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="Pages.Cadastros.Usuarios" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/FiltroSuperior.ascx" tagname="FiltroSuperior" tagprefix="uc1" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
		        <div class='FiltroItem'>Cargo<br>
		            <asp:DropDownList runat="server" ID="cboIDCargo" DataTextField="Cargo" DataValueField="IDCargo" AutoPostBack='true' />
		        </div>
			    <uc1:FiltroSuperior ID="FiltroSuperior1" runat="server" />
		        <div class='FiltroItem'>Status<br>
		            <asp:DropDownList runat="server" ID="cboStatus" AutoPostBack='true'>
		                <asp:ListItem Value='2' Enabled='true'>Ativos</asp:ListItem>
		                <asp:ListItem Value='1'>Inativos</asp:ListItem>
		                <asp:ListItem Value='8'>Todos</asp:ListItem>
		            </asp:DropDownList>
		        </div>
				<div class='FiltroLetras'>
					<xm:Letras ID="Letras1" runat="server" />
				</div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDUsuario" DataNavigateUrlFormatString="Usuario.aspx?IDUsuario={0}" DataTextField="Usuario" HeaderText="Usu&aacute;rio" SortExpression="Usuario"  />
						<asp:BoundField HeaderText="Login" DataField="login" SortExpression="login" />
                        <asp:BoundField HeaderText="Cargo" DataField="cargo" SortExpression="cargo" />
                        <asp:BoundField HeaderText="Superior" DataField="superior" SortExpression="superior" />
                        <asp:TemplateField HeaderText='Status' SortExpression='Ativo'>
                            <ItemTemplate>
                                <%#IIf(Eval("Ativo") = 1, "Ativo", "Inativo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Usuarios com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
				</div>
                <xm:Paginate ID="Paginate1" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Usuario.aspx?idusuario=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Usuario.Exportar, true %>' />
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

