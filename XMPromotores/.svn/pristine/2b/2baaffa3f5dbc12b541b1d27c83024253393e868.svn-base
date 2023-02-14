<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TipoJustificativa.aspx.vb" Inherits="Pages.Cadastros.TipoJustificativa" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Descri&ccedil;&atilde;o:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtTipoJustificativa' MaxLength='50' CssClass="formulario" Width="270px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoJustificativa' Display='None' ErrorMessage='Descri&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoJustificativa' />
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
					Abono:
				</td>
				<td class='tdField'>
					<asp:RadioButtonList runat="server" ID="rdAbono" RepeatColumns="1" CssClass='tblAbono' RepeatLayout='Flow'>
					    <asp:ListItem Text="N&atilde;o" Value="0" ></asp:ListItem>
					    <asp:ListItem Selected="True" Text="Sim" Value="1"></asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
			<tr class='trField' runat="server" visible='<%$Settings: visible, TipoJustificativa.AplicarRuptura, false %>'>
				<td class='tdFieldHeader'>
					Ruptura:
                </td>
                <td class='tdField'>
                    <asp:CheckBox runat="server" ID="chkAplicarRuptura" Text="Aplicar (Quando o Produto N&atilde;o for Pesquisado)" Checked="false" />
				</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='TipoJustificativa.aspx?idtipojustificativa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='TipoJustificativas.aspx'" />
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
				Abre para edi&ccedil;&atilde;o  um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

