<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="TipoVendedor.aspx.vb" Inherits="Pages.Cadastros.TipoVendedor" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trTipoVendedor' visible='<%$Settings: visible, TipoVendedor.TipoVendedor, true %>' >
				<div class='tdFieldHeader cb fl'>
					Tipo Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTipoVendedor' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoVendedor' Enabled='<%$Settings: Required, TipoVendedor.TipoVendedor, true %>' Display='None' ErrorMessage='Tipo Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoVendedor' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trFuso' visible='<%$Settings: visible, TipoVendedor.Fuso, true %>' >
				<div class='tdFieldHeader cb fl'>
					Fuso:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtFuso' />
					<asp:RequiredFieldValidator runat='server' ID='valReqFuso' Enabled='<%$Settings: Required, TipoVendedor.Fuso, true %>' Display='None' ErrorMessage='Fuso &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFuso' />
					<asp:CompareValidator runat='server'  ID='valCompFuso' Display='None' ErrorMessage='Fuso inv&aacute;lida' ControlToValidate='txtFuso' Operator='DataTypeCheck' Type='Integer' />
                    <asp:CompareValidator runat='server'  ID='CompareValidator1' Display='None' ErrorMessage='Fuso precisa ser maior ou igual a zero' ControlToValidate='txtFuso' Operator='GreaterThanEqual' ValueToCompare='0' Type='Integer' />
                    <asp:CompareValidator runat='server'  ID='CompareValidator2' Display='None' ErrorMessage='Fuso precisa ser menor ou igual a doze' ControlToValidate='txtFuso' Operator='LessThanEqual' ValueToCompare='12' Type='Integer' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='TipoVendedor.aspx?idtipovendedor=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='TipoVendedores.aspx'" />
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

