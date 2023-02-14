<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="UsuarioAltSenha.aspx.vb" Inherits="Cadastros_UsuarioAltSenha" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class='EditArea'>
        <table id='tblEditArea'>
	        <tr class="trEditHeader">
		        <td colspan='6'>&nbsp;</td>
	        </tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Nome do Usu&aacute;rio:
				</td>
				<td colspan='3' class='tdField'>
					<asp:Label runat='server' ID='lblUsuario'></asp:Label>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Login:
				</td>
				<td colspan='3' class='tdField'>
					<asp:Label runat='server' ID='lblLogin'></asp:Label>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Senha:
				</td>
				<td class='tdField'>
					<asp:TextBox TextMode="Password" runat='server' ID='txtAlterarSenha' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator4' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtAlterarSenha' />
					<asp:CompareValidator ID="CompareValidator1" Display='None' ErrorMessage="Os campos Senha e Confirmar Senha devem ser iguais. Verifique..." runat="Server" ControlToValidate="txtAlterarSenha" ControlToCompare="txtAlterarSenhaConf" Operator="Equal"></asp:CompareValidator>
				</td>
				<td class='tdFieldHeader'>
					Confirmar senha:
				</td>
				<td class='tdField'>
					<asp:TextBox TextMode="Password" runat='server' ID='txtAlterarSenhaConf' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator5' Display='None' ErrorMessage='Confirmar Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtAlterarSenhaConf' />
				</td>
				<td class='tdFieldHeader'>
					Senha V&aacute;lida at&eacute;:
				</td>
				<td class='tdField' >
					<asp:TextBox runat='server' ID='txtValidSenha' onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10" />
					<asp:CompareValidator runat='server'  ID='valCompValidSenha' Display='None' ErrorMessage='Senha V&aacute;lida at&eacute; inv&aacute;lida' ControlToValidate='txtValidSenha' Operator='DataTypeCheck' Type='Date' />
				</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar Senha" CssClass='Botao' />
        <asp:Button CausesValidation="false" runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Confirmar Altera&ccedil;&atilde;o de Senha:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

