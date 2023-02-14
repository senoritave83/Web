<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Motorista.aspx.vb" Inherits="Pages.Cadastros.Motorista" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trMotorista' visible='<%$Settings: visible, Motorista.Motorista, true %>' >
				<div class='tdFieldHeader cb fl'>
					Motorista:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtMotorista' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqMotorista' Enabled='<%$Settings: Required, Motorista.Motorista, false %>' Display='None' ErrorMessage='Motorista &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMotorista' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Motorista.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trAtivo' visible='<%$Settings: visible, Motorista.Ativo, true %>' >
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
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Motoristas.aspx'" />
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
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

