<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Embalagem.aspx.vb" Inherits="Pages.Pesquisas.Embalagem" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
            <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Embalagem.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Embalagem.Embalagem, true %>' Display='None' ErrorMessage='Embalagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trEmbalagem' visible='<%$Settings: visible, Embalagem.Embalagem, true %>' >
				<div class='tdFieldHeader cb fl'>
					Embalagem:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEmbalagem' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEmbalagem' Enabled='<%$Settings: Required, Embalagem.Embalagem, true %>' Display='None' ErrorMessage='Embalagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmbalagem' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, Marca.Marca, true %>' >
				<div class='tdFieldHeader cb fl'>
					Tipos de Pergunta:
				</div>
				<div class='tdField fl'>
					<asp:CheckBoxList runat="server" ID="chkTipoPergunta">
                        <asp:ListItem Text="Quantidade" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Volume" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Preço Ponta" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Preço Varejo" Value="8"></asp:ListItem>
                    </asp:CheckBoxList>
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Embalagem.Criado, true %>' >
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Embalagem.aspx?idembalagem=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Embalagens.aspx'" />
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

