<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Coordenador.aspx.vb" Inherits="Pages.Cadastros.Coordenador" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, Coordenador.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Coordenador.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCoordenador' visible='<%$Settings: visible, Coordenador.Coordenador, true %>' >
				<div class='tdFieldHeader cb fl'>
					Coordenador:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCoordenador' MaxLength='60' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCoordenador' Enabled='<%$Settings: Required, Coordenador.Coordenador, false %>' Display='None' ErrorMessage='Coordenador &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCoordenador' />
				</div>
                <div class='trField cb' runat='server'  id='trStatus'>
                  <div class='tdFieldHeader cb fl'>
					Status:
				   </div>
                 <div>
                  <asp:RadioButtonList runat="server" ID="rdStatus" RepeatDirection="Horizontal" Width="170">
                        <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                </div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Coordenador.aspx?idcoordenador=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Coordenadores.aspx'" />
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

