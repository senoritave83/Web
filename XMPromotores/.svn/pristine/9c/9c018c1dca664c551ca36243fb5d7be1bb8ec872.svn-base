<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Categoria.aspx.vb" Inherits="Pages.Cadastros.Categoria" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
    				<asp:Literal ID="Literal1" runat='server' Text='<%$Settings: Caption, Categoria, "Segmento"%>' />:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCategoria' CssClass="formulario" Width="180px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqCategoria' Display="None" ControlToValidate='txtCategoria' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Criado:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Status:
				</td>
				<td class='tdField'>
					<asp:RadioButtonList runat="server" ID="rdStatus" RepeatDirection="Horizontal" Width="170">
                        <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
				</td>
			</tr>
			<tr class='trField' runat="server" id="divOrdem">
				<td class='tdFieldHeader'>
					Ordem:
				</td>
				<td class='tdField'>
					<asp:label runat='server' ID='txtOrdem' CssClass="formulario" Width="109px" ></asp:label>
				</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Categoria.aspx?idcategoria=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Categorias.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

