<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Fornecedor.aspx.vb" Inherits="Pages.Cadastros.Fornecedor" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					<asp:Literal runat="Server" Text='<%$Settings: Caption, Fornecedor, "Fornecedor"%>'></asp:Literal>:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtFornecedor' MaxLength='50' CssClass="formulario" Width="289px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqFornecedor' Display='None' ControlToValidate='txtFornecedor' />
				</td>
			</tr>
			<tr class='trField' style="text-align:left;">
				<td class='tdFieldHeader'>
					Cliente:
				</td>
				<td>
					<asp:CheckBox runat='server' ID='chkConcorrente' />
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
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Fornecedor.aspx?idfornecedor=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Fornecedores.aspx'" />
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

