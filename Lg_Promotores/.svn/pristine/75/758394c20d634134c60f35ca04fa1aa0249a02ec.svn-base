<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="Pages.Cadastros.Usuarios" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' Width="500px" />
        </div> 
        <div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting="true">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDUsuario" DataNavigateUrlFormatString="Usuario.aspx?IDUsuario={0}" DataTextField="Usuario" HeaderText="Nome do Usu&aacute;rio" SortExpression="Usuario"  />
						<asp:BoundField HeaderText="Login" DataField="login" SortExpression="Login" />
						<asp:TemplateField HeaderText="Administrador" SortExpression="Administrador">
						    <ItemTemplate>
						        <img src="../imagens/<%# iif(Eval("Administrador") = "1", "Checked.gif", "NonChecked.gif") %>" alt="" />
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField HeaderText="Último Acesso" DataField="UltimoAcesso" SortExpression="UltimoAcesso" />
						<asp:BoundField HeaderText="Criado em " DataField="Criado" SortExpression="Criado" />
						<asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Usu&aacute;rios cadastrados!
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Usuario.aspx?idusuario=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='../home/default.aspx'" />
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

