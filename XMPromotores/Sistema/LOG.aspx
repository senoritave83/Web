<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="LOG.aspx.vb" Inherits="Pages.Cadastros.LOG" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoUser'>
						User:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtUser' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqUser' Display='None' ErrorMessage='User &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtUser' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoModulo'>
						Modulo:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtModulo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqModulo' Display='None' ErrorMessage='Modulo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtModulo' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoSecao'>
						Secao:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtSecao' MaxLength='255' />
					<asp:RequiredFieldValidator runat='server' ID='valReqSecao' Display='None' ErrorMessage='Secao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSecao' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoAcao'>
						Acao:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtAcao' MaxLength='2000' />
					<asp:RequiredFieldValidator runat='server' ID='valReqAcao' Display='None' ErrorMessage='Acao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtAcao' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoData'>
						Data:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtData' />
					<asp:RequiredFieldValidator runat='server' ID='valReqData' Display='None' ErrorMessage='Data &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtData' />
					<asp:CompareValidator runat='server'  ID='valCompData' Display='None' ErrorMessage='Data inv&aacute;lida' ControlToValidate='txtData' Operator='DataTypeCheck' Type='Date' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan=2>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='LOG.aspx'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='LOGs.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

