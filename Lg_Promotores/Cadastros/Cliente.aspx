<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="Pages.Cadastros.Cliente" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Literal runat='server' Text='<%$Settings: Caption, Cliente.RazaoSocial, "Raz&atilde;o Social"%>' />:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtRazaoSocial' />
					<asp:RequiredFieldValidator runat='server' ID='valReqRazaoSocial' Display='None' ErrorMessage='<%$Settings: RequiredMessage, Cliente.RazaoSocial, "Raz&atilde;o Social é um campo obrigat&oacute;rio!"%>' ControlToValidate='txtRazaoSocial' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Literal ID="Literal1" runat='server' Text='<%$Settings: Caption, Cliente.Fantasia, "Fantasia"%>' />:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtFantasia' />
					<asp:RequiredFieldValidator runat='server' ID='valReqFantasia' Display='None' ErrorMessage='<%$Settings: RequiredMessage, Cliente.Fantasia, "Fantasia é um campo obrigat&oacute;rio!"%>' ControlToValidate='txtFantasia' />
				</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cliente.aspx?idcliente=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Clientes.aspx'" />
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

