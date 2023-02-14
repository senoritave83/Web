<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="MensagemDia.aspx.vb" Inherits="Pages.Cadastros.MensagemDia" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

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
				    <asp:Label runat='server' ID='lblTextoMensagem'>
						Mensagem:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtMensagem' MaxLength='255' Width='100%' TextMode='MultiLine' Rows='2' />
					<asp:RequiredFieldValidator runat='server' ID='valReqMensagem' Display='None' ErrorMessage='Mensagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMensagem' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataInicio'>
						Data Inicial:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDataInicio' />
					<asp:CompareValidator runat='server'  ID='valCompDataInicio' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicio' Operator='DataTypeCheck' Type='Date' />
                    <ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicio" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataDim'>
						Data Final:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDataDim' />
					<asp:CompareValidator runat='server'  ID='valCompDataDim' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataDim' Operator='DataTypeCheck' Type='Date' />
                    <ajaxToolkit:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataDim" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MensagemDia.aspx?idmensagemdia=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='MensagemDias.aspx'" />
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

