<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TipoTarefa.aspx.vb" Inherits="Pages.Cadastros.TipoTarefa" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<table id='tblEditArea' style="border:none;">
			<tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					<asp:Literal ID="ltrTipoTarefa" runat="server" Text='<%$ Settings: caption, Loja.TipoTarefa, "Tipo de Tarefa" %>' />:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtTipoTarefa' MaxLength='50' CssClass="formulario" Width="170px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoTarefa' Display='None' ErrorMessage='TipoTarefa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoTarefa' />
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
					Ativo:
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkAtivo' />
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='TipoTarefa.aspx?idTipoTarefa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='TipoTarefas.aspx'" />
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

