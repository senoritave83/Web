<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ObsPedido.aspx.vb" Inherits="Pages.Cadastros.ObsPedido" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, ObsPedido.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='10' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, ObsPedido.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescricao' visible='<%$Settings: visible, ObsPedido.Descricao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Descri&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='255' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Enabled='<%$Settings: Required, ObsPedido.Descricao, false %>' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trHabilitaBrinde' visible='<%$Settings: visible, ObsPedido.HabilitaBrinde, false %>' >
				<div class='tdFieldHeader cb fl'>
					Habilita Brinde:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat="server" ID='chkHabilitaBrinde' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, ObsPedido.Ativo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Ativo:
				</div>
				<div class='tdField fl'>
				    <asp:CheckBox runat="server" ID='chkAtivo' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='ObsPedido.aspx?idobspedido=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='ObsPedidos.aspx'" />
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

