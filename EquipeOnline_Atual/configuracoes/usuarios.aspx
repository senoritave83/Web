<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="usuarios.aspx.vb" Inherits="configuracoes_usuarios" title="Equipe Online" %>
<%@ Register src="../include/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center" style="padding-left:30px;">
        <tr class='Header1'> 
            <td>
                <strong><input type="checkbox" name="checkbox" value="checkbox" onclick='selectAll(this.form.chkSelected, this.checked);'> Selecionar Todos</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt=""/></td>
        </tr>                
	    <tr>
		    <td valign="top" align="center">
		        <asp:GridView runat="server" ID='grdUsuarios' Width='100%' AutoGenerateColumns='false' AllowSorting="True" CssClass="GridView">
    		        <HeaderStyle CssClass='Header2'/>
    		        <RowStyle CssClass="griditem" />
					<Columns>
						<asp:TemplateField ItemStyle-Width="20" HeaderText="">
							<ItemTemplate>
								<input type="checkbox" name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "usu_Usuario_int_PK")%>' />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:HyperLinkField ItemStyle-CssClass="griditem" ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='left' DataTextField='usu_Usuario_chr' DataNavigateUrlFields='usu_Usuario_int_PK' DataNavigateUrlFormatString='usuariodet.aspx?idusuario={0}' HeaderText='Operador' ItemStyle-Width="70%" SortExpression='Operador' />
						<asp:BoundField ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='left' HeaderText='Tipo' DataField='usu_Tipo_chr' SortExpression='Tipo' />
					</Columns>
		        </asp:GridView>
			</td>
		</tr>
        <tr>
            <td>
                <uc1:Paginate ID="Paginate1" runat="server" />
            </td>
        </tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
        </tr>							
	</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton ImageUrl="../images/buttons/btn_voltar.png" id="btnVoltar" runat="server" CssClass="botao_voltar"></asp:ImageButton>
	<asp:ImageButton ImageUrl="../images/buttons/btn_excluir.png" id="btnExcluir" runat="server" CssClass="botao_exclui_grupos"></asp:ImageButton>
    <asp:ImageButton ImageUrl="../images/buttons/btn_adicionar.png" id="btnAdicionar" runat="server" CssClass="botao"></asp:ImageButton>	
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b>Adicionar:</b> Adicione um novo Operador/Administrador à lista de Operadores e Administradores.
    <br />
	<b>Excluir:</b> Exclua um ou mais operadores  selecionados pela caixa de sele&ccedil;&atilde;o.
</asp:Content>

