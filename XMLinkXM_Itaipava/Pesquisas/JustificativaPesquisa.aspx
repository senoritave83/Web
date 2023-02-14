<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="JustificativaPesquisa.aspx.vb" Inherits="Pages.Pesquisas.JustificativaPesquisa" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trJustificativa' visible='<%$Settings: visible, JustificativaPesquisa.Justificativa, true %>' >
				<div class='tdFieldHeader cb fl'>
					Justificativa:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtJustificativa' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqJustificativa' Enabled='<%$Settings: Required, JustificativaPesquisa.Justificativa, true %>' Display='None' ErrorMessage='Justificativa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtJustificativa' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='trReincidencia' visible='<%$Settings: visible, JustificativaPesquisa.Reincidencia, true %>' >
				<div class='tdFieldHeader cb fl'>
					Reincid&ecirc;ncia:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat="server" ID="chkReicidencia" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, JustificativaPesquisa.Criado, true %>' >
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
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao'   Enabled='<%$Settings: Required, Pesquisas.JustificativaPesquisa, true  %>'/>
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' Enabled='<%$Settings: Required, Pesquisas.JustificativaPesquisa, true  %>' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='JustificativaPesquisa.aspx?idjustificativa=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='JustificativaPesquisas.aspx'" />
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

