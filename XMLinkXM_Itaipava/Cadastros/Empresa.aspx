<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Empresa.aspx.vb" Inherits="Pages.Cadastros.Empresa" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>						
			<div class='trField cb' runat='server'  id='trLatitude' visible='<%$Settings: visible, Empresa.Latitude, true %>' >
				<div class='tdFieldHeader cb fl'>
					Latitude:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLatitude' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLatitude' Enabled='<%$Settings: Required, Empresa.Latitude, false %>' Display='None' ErrorMessage='Latitude &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLatitude' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trLongitude' visible='<%$Settings: visible, Empresa.Longitude, true %>' >
				<div class='tdFieldHeader cb fl'>
					Longitude:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLongitude' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLongitude' Enabled='<%$Settings: Required, Empresa.Longitude, false %>' Display='None' ErrorMessage='Longitude &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLongitude' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trPermiteBonificacao' visible='<%$Settings: visible, Empresa.PermiteBonificacao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Permite Bonifica&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkPermiteBonificacao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trPermitePrecoLivre' visible='<%$Settings: visible, Empresa.PermitePrecoLivre, true %>' >
				<div class='tdFieldHeader cb fl'>
					Permite Pre&ccedil;o Livre:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkPermitePrecoLivre' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='trTransacaoVenda' visible='<%$Settings: visible, Empresa.TransacaoVenda, true %>' >
				<div class='tdFieldHeader cb fl'>
					Transa&ccedil;&atilde;o Venda:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat="server" ID="txtTransacaoVenda" />
	                <asp:CompareValidator runat='server' ID='valTransacaoVenda' ControlToValidate='txtTransacaoVenda' ErrorMessage='C�digo de transa��o de venda inv�lido' Operator='DataTypeCheck' Type='Integer'></asp:CompareValidator>
				</div>
			</div>
            <div class='trField cb' runat='server'  id='trTransacaoBonificacao' visible='<%$Settings: visible, Empresa.TransacaoBonificacao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Transa&ccedil;&atilde;o Bonifica&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat="server" ID="txtTransacaoBonificacao" />
	                <asp:CompareValidator runat='server' ID='valTransacaoBonificacao' ControlToValidate='txtTransacaoBonificacao' ErrorMessage='C�digo de transa��o de bonifica��o inv�lido' Operator='DataTypeCheck' Type='Integer'></asp:CompareValidator>
                    <asp:CompareValidator Runat="server" ID="valVendaBonificacao" ControlToValidate='txtTransacaoBonificacao' ErrorMessage='O Campo Transa&ccedil;&atilde;o Venda n�o pode ter o mesmo valor do campo Transa&ccedil;&atilde;o Bonifica&ccedil;&atilde;o!' Display="None" Type="String" Operator="NotEqual" ControlToCompare='txtTransacaoVenda' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='trPermiteForaRota' visible='<%$Settings: visible, Empresa.PermiteForaRota, true %>' >
				<div class='tdFieldHeader cb fl'>
					Permitir fora de rota:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkPermiteForaRota' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='trLimiteCredito' visible='<%$Settings: visible, Empresa.LimiteCredito, true %>' >
				<div class='tdFieldHeader cb fl'>
					Aplicar regra LIMITE DE CR&eacute;DITO do cliente:
					<asp:CheckBox runat='server' ID='chkLimiteCreditoCliente' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />        
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='../pedidos/default.aspx'" />
    </div>
    <div id='divErros'>        
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' Height="16px" 
            Width="90%" />
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

