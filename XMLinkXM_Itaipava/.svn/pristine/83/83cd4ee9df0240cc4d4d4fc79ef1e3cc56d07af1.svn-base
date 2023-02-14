<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ProdutoPesquisa.aspx.vb" Inherits="Pages.Pesquisas.ProdutoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
            <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, ProdutoPesquisa.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, ProdutoPesquisa.ProdutoPesquisa, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trProdutoPesquisa' visible='<%$Settings: visible, ProdutoPesquisa.ProdutoPesquisa, true %>' >
				<div class='tdFieldHeader cb fl'>
					Descrição do Produto:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtProdutoPesquisa' MaxLength='50' Width="250" />
					<asp:RequiredFieldValidator runat='server' ID='valReqProdutoPesquisa' Enabled='<%$Settings: Required, ProdutoPesquisa.ProdutoPesquisa, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtProdutoPesquisa' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='Div5' visible='<%$Settings: visible, ProdutoPesquisa.ProdutoPesquisa, true %>' >
				<div class='tdFieldHeader cb fl'>
					Categoria de Pesquisa:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboCategoriaPesquisa" DataTextField="Categoria" DataValueField="IdCategoriaPesquisa"></asp:DropDownList>
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
			<div class='trField cb' runat='server'  id='Div3' visible='<%$Settings: visible, ProdutoPesquisa.PrecoPontaMinimo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Preço Ponta - Mínimo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoPontaMinimo' MaxLength='50' autocomplete="off" onKeyPress="return(MascaraMoeda(this,'.',',',event))" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Enabled='<%$Settings: Required, ProdutoPesquisa.PrecoPontaMinimo, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtProdutoPesquisa' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div4' visible='<%$Settings: visible, ProdutoPesquisa.PrecoPontaMaximo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Preço Ponta - Máximo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoPontaMaximo' MaxLength='50' autocomplete="off" onKeyPress="return(MascaraMoeda(this,'.',',',event))" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, ProdutoPesquisa.PrecoPontaMaximo, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtProdutoPesquisa' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='Div6' visible='<%$Settings: visible, ProdutoPesquisa.PrecoVarejoMinimo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Preço Varejo - Mínimo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoVarejoMinimo' MaxLength='50' autocomplete="off" onKeyPress="return(MascaraMoeda(this,'.',',',event))" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator4' Enabled='<%$Settings: Required, ProdutoPesquisa.PrecoVarejoMinimo, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtProdutoPesquisa' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div7' visible='<%$Settings: visible, ProdutoPesquisa.PrecoVarejoMaximo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Preço Varejo - Máximo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoVarejoMaximo' MaxLength='50' autocomplete="off" onKeyPress="return(MascaraMoeda(this,'.',',',event))" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator5' Enabled='<%$Settings: Required, ProdutoPesquisa.PrecoVarejoMaximo, true %>' Display='None' ErrorMessage='ProdutoPesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtProdutoPesquisa' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, ProdutoPesquisa.Criado, true %>' >
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='produtopesquisa.aspx?idprodutopesquisa=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='produtopesquisas.aspx'" />
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

