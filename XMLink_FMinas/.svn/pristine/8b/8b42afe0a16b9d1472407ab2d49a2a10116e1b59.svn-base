<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="MensagemDia.aspx.vb" Inherits="Pages.Cadastros.MensagemDia" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trMensagem' visible='<%$Settings: visible, MensagemDia.Mensagem, true %>' >
				<div class='tdFieldHeader cb fl'>
					Mensagem:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtMensagem' MaxLength='255' />
					<asp:RequiredFieldValidator runat='server' ID='valReqMensagem' Enabled='<%$Settings: Required, MensagemDia.Mensagem, true %>' Display='None' ErrorMessage='Mensagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMensagem' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDataInicio' visible='<%$Settings: visible, MensagemDia.DataInicio, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de In&iacute;cio:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDataInicio' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDataInicio' Enabled='<%$Settings: Required, MensagemDia.DataInicio, false %>' Display='None' ErrorMessage='Data de In&iacute;cio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDataInicio' />
					<cc1:CalendarExtender  ID="cal_txtDataInicio" runat="server" TargetControlID="txtDataInicio" PopupPosition="Right" PopupButtonID="imgCalendarInicial" Format="dd/MM/yyyy" />
					<asp:CompareValidator runat='server'  ID='valCompDataInicio' Display='None' ErrorMessage='Data inv&aacute;lida' ControlToValidate='txtDataInicio' Operator='DataTypeCheck' Type='Date' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDataDim' visible='<%$Settings: visible, MensagemDia.DataDim, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data Final:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDataDim' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDataDim' Enabled='<%$Settings: Required, MensagemDia.DataDim, false %>' Display='None' ErrorMessage='Data Final &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDataDim' />
					<cc1:CalendarExtender  ID="cal_txtDataDim" runat="server" TargetControlID="txtDataDim" PopupPosition="Right" PopupButtonID="imgCalendarInicial" Format="dd/MM/yyyy" />
					<asp:CompareValidator runat='server'  ID='valCompDataDim' Display='None' ErrorMessage='Data Final inv&aacute;lida' ControlToValidate='txtDataDim' Operator='DataTypeCheck' Type='Date' />
				</div>
			</div>
		</div>
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

