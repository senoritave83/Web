<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Parametros.aspx.vb" Inherits="Pages.Cadastros.Parametros" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
	        <div class='trField cb'>
		        <div class='tdFieldHeader cb fl'>
			        Fator de Pre&ccedil;o Sugerido:
		        </div>
		        <div class='tdField fl'>
					<asp:TextBox Runat="server" MaxLength=8 ID="txtFatorSug" CssClass="Caixa" Width="100" onclick="Limpa();"/>
					<asp:RequiredFieldValidator Display='Dynamic' Runat="server" ID="Requiredfieldvalidator3" ControlToValidate='txtFatorSug' Text="*" ErrorMessage='Por favor informe o fator de pre&ccedil;o sugerido!'></asp:RequiredFieldValidator>
					<asp:CompareValidator Display='Dynamic' runat="server" id="Comparevalidator3" ControlToValidate="txtFatorSug" Type=Double Text="*" Operator="DataTypeCheck" ErrorMessage='Fator de pre&ccedil;o sugerido inv&aacute;lido!' />
		        </div>
	        </div>
	        <div class='trField cb'>
		        <div class='tdFieldHeader cb fl'>
			        Fator de Pre&ccedil;o M&aacute;ximo:
		        </div>
		        <div class='tdField fl'>
					<asp:TextBox Runat="server" MaxLength=8 ID="txtFatorMax" CssClass="Caixa" Width="100" />
					<asp:RequiredFieldValidator Display='Dynamic' Runat="server" ID="valtxtDescricao" ControlToValidate='txtFatorMax' Text="*" ErrorMessage='Por favor informe o fator de pre&ccedil;o m&aacute;ximo'></asp:RequiredFieldValidator>
					<asp:CompareValidator Display='Dynamic' runat="server" id="Comparevalidator2" ControlToValidate="txtFatorMax" Type=Double Operator="DataTypeCheck" Text='*' ErrorMessage='Fator de pre&ccedil;o m&aacute;ximo inv&aacute;lido!' />
		        </div>
	        </div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
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

