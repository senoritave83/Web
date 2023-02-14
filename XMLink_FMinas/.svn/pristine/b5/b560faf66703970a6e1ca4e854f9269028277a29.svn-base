<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Regra.aspx.vb" Inherits="Pages.Cadastros.Regra" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trDescontoMax' visible='<%$Settings: visible, Regra.DescontoMax, true %>' >
				<div class='tdFieldHeader cb fl'>
					Desconto M&aacute;x.:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescontoMax' />%
					<asp:RequiredFieldValidator runat='server' ID='valReqDescontoMax' Enabled='<%$Settings: Required, Regra.DescontoMax, true %>' Display='None' ErrorMessage='Desconto M&aacute;x. &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescontoMax' />
					<asp:CompareValidator runat='server' ID='CompareValidator1' Display='None' ErrorMessage='Desconto M&aacute;x. inv&aacute;lido!' ControlToValidate='txtDescontoMax' Type='Double' Operator='DataTypeCheck'  />
					<asp:CompareValidator runat='server' ID='CompareValidator2' Display='None' ErrorMessage='Desconto M&aacute;x. N&atilde;o pode ser superior a 100%!' ControlToValidate='txtDescontoMax' Type='Double' Operator="LessThanEqual" ValueToCompare='100'  />
					<asp:CompareValidator runat='server' ID='CompareValidator4' Display='None' ErrorMessage='Desconto M&aacute;x. N&atilde;o pode ser inferior a 0%!' ControlToValidate='txtDescontoMax' Type='Double' Operator="GreaterThanEqual" ValueToCompare='0'  />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trIDResponsavel' visible='<%$Settings: visible, Regra.Responsavel, true %>' >
				<div class='tdFieldHeader cb fl'>
					Editado por:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblResponsavel' ></asp:Label>
					(<asp:Label runat='server' ID='lblData' ></asp:Label>)
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='../controle/default.aspx'" />
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
		    <li>
		        <asp:Localize runat='server' ID='Localize1'>
			        O desconto m&aacute;ximo n&atilde;o pode ser superior a 100% ou inferior a 0%.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

