<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FormaPagamento.aspx.vb" Inherits="Pages.Cadastros.FormaPagamento" title="Untitled Page" %>
<%@ Register src="../controls/txtCorrecao.ascx" tagname="txtCorrecao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, FormaPagamento.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, FormaPagamento.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trFormaPagamento' visible='<%$Settings: visible, FormaPagamento.FormaPagamento, true %>' >
				<div class='tdFieldHeader fl'>
					FormaPagamento:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtFormaPagamento' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqFormaPagamento' Enabled='<%$Settings: Required, FormaPagamento.FormaPagamento, false %>' Display='None' ErrorMessage='FormaPagamento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFormaPagamento' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCorrecao' visible='<%$Settings: visible, FormaPagamento.Correcao, true %>' >
				<div class='tdFieldHeader fl'>
					Corre&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<uc1:txtCorrecao ID='txtCorrecao' runat="server" Required="<%$Settings: Required, FormaPagamento.Correcao, false %>" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, FormaPagamento.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<br class='cb' />
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='FormaPagamento.aspx?idformapagamento=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='FormaPagamentos.aspx'" />
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

