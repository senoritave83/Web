<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="MensagemGeral.aspx.vb" Inherits="Pages.Cadastros.MensagemGeral" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea' style='height:240px;'>
		    <div class='divHeader'>Dados da Mensagem</div>
			<div class='trField cb'>
				<div class='tdFieldHeader cb fl'>
					Título:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTitulo' MaxLength='255' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTitulo' Display='None' ErrorMessage='Titulo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTitulo' />
				</div>
			</div>
			<div class='trField cb'>
				<div class='tdFieldHeader cb fl'>
					Mensagem:
				</div>
				<div class='tdField fl' style='width:400px;'>
					<asp:TextBox runat='server' ID='txtMensagem' MaxLength='5000' TextMode='MultiLine' Rows='10' Width='100%' style='width:100%;' />
					<asp:RequiredFieldValidator runat='server' ID='valReqMensagem' Display='None' ErrorMessage='Mensagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMensagem' />
				</div>
			</div>
			<div class='trField cb'>
				<div class='tdFieldHeader cb fl'>
					Data:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblData' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MensagemGeral.aspx?idmensagemgeral=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='MensagemGerais.aspx'" />
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

