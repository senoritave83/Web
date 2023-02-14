<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="UF.aspx.vb" Inherits="Pages.Cadastros.UF" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trUF'>
				<div class='tdFieldHeader cb fl'>
					UF:
				</div>
				<div class='tdField fl'>
                    <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
				</div>
            </div>
            <div class='trField cb' runat='server'  id='trDesconto'>
                <div class='tdFieldHeader cb fl'>
				    Desconto (%):
			    </div>
                <div class='tdField fl'>
                    <asp:TextBox runat='server' ID='txtDesconto' Width='29%' MaxLength='5' />
                    <asp:RangeValidator Display=Dynamic runat='server' MinimumValue='0' MaximumValue='100' Type='Integer' ErrorMessage='Insira um valor entre 0 e 100' ControlToValidate='txtDesconto'></asp:RangeValidator>
                    <asp:RequiredFieldValidator Display=Dynamic ID="RangeValidator1" runat='server' ErrorMessage='Insira um valor entre 0 e 100' ControlToValidate='txtDesconto'></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class='trField cb' runat='server'  id='trCriado' >
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
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='UF.aspx?uf=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='UFs.aspx'" />
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

