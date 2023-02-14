<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="Clientes.aspx.vb" Inherits="configuracoes_Clientes" title="Equipe Online" %>
<%@ Register src="../include/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">
    <tr class='Header1'> 
        <td>
            <strong><input type="checkbox" name="checkbox" value="checkbox" onclick='selectAll(this.form.chkSelected, this.checked);' /> Selecionar Todos</strong>
        </td>
    </tr>
    <tr> 
        <td class='Linha1'>
            <img src="../images/transpa.gif" height="1" alt=""/>
        </td>
    </tr>                
	<tr>
		<td>	
			<!-- INICIO CONTE&#65533;DO -->
			<asp:DataGrid ShowHeader="True" Runat="server" ID='dtgGrid' Width="100%" CssClass='GridView' AutoGenerateColumns="False" AllowSorting="True">
			    <HeaderStyle  CssClass='Header2' />				
				<ItemStyle HorizontalAlign="Left" />
				<Columns>
					<asp:TemplateColumn ItemStyle-Width="20">
						<ItemTemplate>
							<input type='checkbox' name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "cli_Cliente_int_PK")%>' />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Cliente" SortExpression='Cliente'>
						<ItemTemplate>
							<a href='clientesdet.aspx?idcliente=<%# DataBinder.Eval(Container.DataItem, "cli_Cliente_int_PK")%>&strTipo=<%# ViewState("_Tipo")%>&intCodigo=<%# ViewState("_Codigo")%>' class=cinza1 /><%# DataBinder.Eval(Container.DataItem, "cli_Cliente_chr")%></a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn ItemStyle-CssClass='cinza1' HeaderText="Criado em" DataFormatString='{0:d}' DataField='cli_Criado_dtm' SortExpression='Criado' />
				</Columns>
			</asp:DataGrid>
		</td>
	</tr>
    <tr>
        <td>
            <uc1:Paginate ID="Paginate1" runat="server" />
            <br />
        </td>
    </tr>
    <tr class='Footer1'> 
        <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
    </tr>							
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton runat="server" id="btnVoltar" CausesValidation="False" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar"></asp:ImageButton>    
    <asp:ImageButton Runat="server" ID="btnApagar" CausesValidation="False" ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao_exclui_grupos"></asp:ImageButton>
    <asp:ImageButton Runat="server" ID='btnNovo' ImageUrl="../images/buttons/btn_adicionar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b> Adicionar:</b> Adicione um novo cliente &eacute; Lista de Clientes.
    <br />
	<b>Excuir:</b> Exclua um ou mais clientes selecionados pela caixa de sele&ccedil;&atilde;o.
</asp:Content>