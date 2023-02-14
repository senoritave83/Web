<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="MensagemDia.aspx.vb" Inherits="Pages.Cadastros.MensagemDia" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Mensagem:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtMensagem' MaxLength='255' TextMode='MultiLine' Rows='2' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqMensagem' Display='None' ErrorMessage='Mensagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMensagem' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Data de In&iacute;cio:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDataInicio' MaxLength='255' />
					<asp:CompareValidator runat='server'  ID='valCompDataInicio' Display='None' ErrorMessage='Data de &iacute;nicio inv&aacute;lida' ControlToValidate='txtDataInicio' Operator='DataTypeCheck' Type='Date' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Data Final:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDataDim' MaxLength='255' />
					<asp:CompareValidator runat='server'  ID='valCompDataDim' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataDim' Operator='DataTypeCheck' Type='Date' />
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
					Segmento:
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
				</td>
			</tr>			
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MensagemDia.aspx?idmensagemdia=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='MensagemDias.aspx'" />
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

