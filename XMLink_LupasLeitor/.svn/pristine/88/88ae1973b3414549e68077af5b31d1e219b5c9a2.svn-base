<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/Imprimir.master" AutoEventWireup="false" CodeFile="PedidoEstoqueVendedor_Print.aspx.vb" Inherits="Cadastros_PedidoEstoqueVendedor_Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
    <title>Movimentação de Estoque nº <%=ViewState(VW_IDPEDIDOESTOQUEVENDEDOR)%>&nbsp;<%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphRelatorio" Runat="Server">
<div class='EditArea' style="width:600px;padding-left:10px;">
	<table id='tblEditArea'>
		<tr class="trEditHeader">
			<td colspan='3'>
            	<asp:Label Runat="server" ID='lblTitulo' SkinID='XMTitulo.Titulo'>Movimentação de Estoque nº <%=ViewState(VW_IDPEDIDOESTOQUEVENDEDOR)%>&nbsp;<%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></asp:Label><br/>
            </td>
		</tr>
		<tr class='trEditSpace'>
			<td colspan='2'>&nbsp;</td>
            <td rowspan='6'>
                <img src="../imagens/Print.gif" alt='0' onmouseover="this.style.cursor='hand'" onclick="window.print();" />
            </td>
		</tr>
		<tr class='trField'>
			<td class='tdField'>
				<asp:Label runat='server' ID='lblTextoGrupo'>
					Tipo de Movimentação:
				</asp:Label> 
			</td>
			<td class='tdField'>
				<asp:Label runat="server" ID="lblTipo"></asp:Label>
			</td>
        </tr>
		<tr class='trField'>
            <td class='tdField'>
				<asp:Label runat='server' ID='Label5'>
					Status:
				</asp:Label> 
			</td>
			<td class='tdField'>
				<asp:Label runat="server" ID="lblStatus"></asp:Label>
			</td>
		</tr>
		<tr class='trField'>
			<td class='tdField'>
				<asp:Label runat='server' ID='lblTextoCriado'>
					Vendedor
				</asp:Label> 
			</td>
			<td class='tdField'>
				<asp:Label runat="server" ID="lblVendedor"></asp:Label>
			</td>
		</tr>
		<tr class='trField'>
			<td class='tdField'>
				<asp:Label runat='server' ID='Label2'>
					Responsável:
				</asp:Label> 
			</td>
            <td class='tdField'>
                <asp:Label runat='server' ID='lblUsuario'></asp:Label>
            </td>
        </tr>
        <tr class='trField'>
			<td class='tdField'>
				<asp:Label runat='server' ID='Label1'>
					Data:
				</asp:Label> 
			</td>
			<td class='tdField'>
                <asp:Label runat='server' ID='lblData'></asp:Label>
            </td>
        </tr>
		<tr class="trEditFooter">
			<td colspan=4>&nbsp;</td>
		</tr>
	</table>
</div>
<div class='ListArea' style="width:600px;padding-left:10px;">
    <table cellpadding=0 cellspacing=0 id='tblAdicionarProduto' runat="server" width="100%">
		<tr class="trEditHeader">
			<td>Produtos</td>
		</tr>
    </table>
	<asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField DataField='Codigo' ItemStyle-HorizontalAlign=Center HeaderStyle-HorizontalAlign=Center HeaderText='C&oacute;digo' />
            <asp:BoundField DataField='Categoria' ItemStyle-HorizontalAlign=Center HeaderStyle-HorizontalAlign=Center ItemStyle-Width="30%" HeaderText='Categoria' />
			<asp:BoundField DataField='DESCRICAO' ItemStyle-HorizontalAlign=Center HeaderStyle-HorizontalAlign=Center ItemStyle-Width="30%" HeaderText='Descri&ccedil;&atilde;o' />
            <asp:BoundField DataField='Quantidade' ItemStyle-HorizontalAlign=Right HeaderStyle-HorizontalAlign=Right HeaderText='Qtd.' />
        </Columns>
	</asp:GridView>
</div>
<br class="cb" />
<br class="cb" />
<br class="cb" />
<div style="width:600px;padding-left:10px;">
    <table id='Table1'>
	    <tr class='trField'>
		    <td class='tdField'>
			    <asp:Label runat='server' ID='Label4'>__________________________________________</asp:Label> 
		    </td>
            <td>&nbsp;&nbsp;</td>
		    <td class='tdField'>
			    <asp:Label runat='server' ID='Label3'>__________________________________________</asp:Label> 
		    </td>
        </tr>
	    <tr class='trField'>
		    <td class='tdField'>
			    <asp:Label runat='server' ID='Label6'>
				    Vendedor:
			    </asp:Label> 
		    </td>
            <td>&nbsp;&nbsp;</td>
		    <td class='tdField'>
			    <asp:Label runat='server' ID='Label7'>
				    Responsável:
			    </asp:Label> 
		    </td>
        </tr>
    </table>
</div>
</asp:Content>

