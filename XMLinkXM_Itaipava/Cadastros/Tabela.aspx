<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Tabela.aspx.vb" Inherits="Pages.Cadastros.Tabela" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trTabela' visible='<%$Settings: visible, Tabela.Tabela, true %>' >
				<div class='tdFieldHeader cb fl'>
					Tabela:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTabela' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTabela' Enabled='<%$Settings: Required, Tabela.Tabela, true %>' Display='None' ErrorMessage='Tabela &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTabela' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Tabela.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trBonificacao' visible='<%$Settings: visible, Tabela.Bonificacao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Bonifica&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkBonificacao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Tabela.AprovacaoManual, true %>' >
				<div class='tdFieldHeader cb fl'>
					Aprova&ccedil;&atilde;o Manual:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat='server' ID='chkAprovacaoManual' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, Tabela.Especial, true %>' >
				<div class='tdFieldHeader cb fl'>
					Tabela Especial:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat='server' ID='chkEspecial' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trAtivo' visible='<%$Settings: visible, Tabela.Ativo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Ativo:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkAtivo' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Tabelas.aspx'" />
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

