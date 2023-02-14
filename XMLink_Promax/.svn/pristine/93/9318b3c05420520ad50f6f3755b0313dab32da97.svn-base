<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="TipoBrinde.aspx.vb" Inherits="Pages.Cadastros.TipoBrinde" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, TipoBrinde.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='10' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, TipoBrinde.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTipoBrinde' visible='<%$Settings: visible, TipoBrinde.TipoBrinde, true %>' >
				<div class='tdFieldHeader cb fl'>
					Brinde:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTipoBrinde' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoBrinde' Enabled='<%$Settings: Required, TipoBrinde.TipoBrinde, false %>' Display='None' ErrorMessage='TipoBrinde &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoBrinde' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='TipoBrinde.aspx?idtipobrinde=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='TipoBrindes.aspx'" />
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

