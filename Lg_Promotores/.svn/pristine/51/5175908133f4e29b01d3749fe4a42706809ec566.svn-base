<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TipoEvento.aspx.vb" Inherits="Pages.Cadastros.Cadastros_TipoEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class='EditArea'>
		<table id='tblEditArea' border='1'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
        </table>
        <table id='tblEditArea' width="600" style="width:600px;" border='0'>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Tipo de Evento
				</td>
				<td class='tdField' colspan='3'>
					<asp:TextBox runat='server' ID='txtTipoEvento' MaxLength='50' Width="400" />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoEvento' Display='None' ErrorMessage='Tipo de Evento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoEvento' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Contexto
				</td>
				<td class='tdField' colspan='3'>
					<asp:DropDownList runat="server" ID="drpIdContexto">
                        <asp:ListItem Text="Selecione..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Durante Visita" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fora da Visita" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Qualquer momento" Value="3"></asp:ListItem>
                    </asp:DropDownList>
					<asp:CompareValidator runat='server' ID='compValidator1' Display='None' ErrorMessage='Contexto &eacute; um campo obrigat&oacute;rio!' ControlToValidate='drpIdContexto' ValueToCompare="0" Operator="GreaterThan"></asp:CompareValidator>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Evento Instantâneo
				</td>
				<td class='tdField' width="100" style="width:100px;">
					<asp:CheckBox runat='server' ID='chkInstantaneo' />
				</td>
				<td class='tdFieldHeader'>
					Requer posição GPS
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkPosicao' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Permite Observação
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkPermiteObs' />
				</td>
				<td class='tdFieldHeader'>
					É exclusivo ?
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkExclusivo' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					É único ?
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkUnico' />
				</td>
				<td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Ativo:
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkAtivo' />
				</td>
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='tipoevento.aspx?idTipoEvento=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='tiposevento.aspx'" />
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

