<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Condicao.aspx.vb" Inherits="Pages.Cadastros.Condicao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCondicao' visible='<%$Settings: visible, Condicao.Condicao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Condi&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCondicao' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCondicao' Enabled='<%$Settings: Required, Condicao.Condicao, true %>' Display='None' ErrorMessage='Condicao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCondicao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trValorMinimo' visible='<%$Settings: visible, Condicao.ValorMinimo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Valor M&iacute;nimo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtValorMinimo' />
					<asp:RequiredFieldValidator runat='server' ID='valReqValorMinimo' Enabled='<%$Settings: Required, Condicao.ValorMinimo, true %>' Display='None' ErrorMessage='Valor Mínimo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtValorMinimo' />
					<asp:CompareValidator runat='server'  ID='valCompValorMinimo' Display='None' ErrorMessage='ValorMinimo inv&aacute;lida' ControlToValidate='txtValorMinimo' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Condicao.AprovacaoManual, true %>' >
				<div class='tdFieldHeader cb fl'>
					Aprova&ccedil;&atilde;o Manual:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat='server' ID='chkAprovacaoManual' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, Condicao.SobrepoeLimiteCredito, true %>' >
				<div class='tdFieldHeader cb fl'>
					Sobrep&otilde;e limite de Cr&eacute;dito do cliente:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat='server' ID='chkSobrepoeLimiteCredito' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Condicao.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Condicao.aspx?idcondicao=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Condicoes.aspx'" />
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

