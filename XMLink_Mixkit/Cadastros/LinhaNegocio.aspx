<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="LinhaNegocio.aspx.vb" Inherits="Pages.Cadastros.LinhaNegocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trLinhaNegocio' visible='<%$Settings: visible, LinhaNegocio.LinhaNegocio, true %>' >
				<div class='tdFieldHeader fl'>
					Linha de Negócio:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLinhaNegocio' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLinhaNegocio' Enabled='<%$Settings: Required, LinhaNegocio.LinhaNegocio, false %>' Display='None' ErrorMessage='Linha de Negócio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLinhaNegocio' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, LinhaNegocio.Criado, true %>' >
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='LinhaNegocio.aspx?idcategoria=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='LinhasNegocio.aspx'" />
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

