<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, Produto.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='40' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Produto.Codigo, true %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCodigoOriginal' visible='<%$Settings: visible, Produto.CodigoOriginal, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cod. Original:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigoOriginal' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigoOriginal' Enabled='<%$Settings: Required, Produto.CodigoOriginal, true %>' Display='None' ErrorMessage='CodigoOriginal &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigoOriginal' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescricao' visible='<%$Settings: visible, Produto.Descricao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Descri&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='120' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Enabled='<%$Settings: Required, Produto.Descricao, true %>' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trIDCategoria' visible='<%$Settings: visible, Produto.Categoria, true %>' >
				<div class='tdFieldHeader cb fl'>
					Categoria:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
					<asp:CompareValidator runat="server"  ID="valCompIDCategoria" Display="None" ErrorMessage="Categoria inv&aacute;lida" ControlToValidate="cboIDCategoria" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDCategoria' Display='None' ErrorMessage='Categoria &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDCategoria' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trEstoque' visible='<%$Settings: visible, Produto.Estoque, true %>' >
				<div class='tdFieldHeader cb fl'>
					Estoque:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEstoque' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEstoque' Enabled='<%$Settings: Required, Produto.Estoque, true %>' Display='None' ErrorMessage='Estoque &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEstoque' />
					<asp:CompareValidator runat='server'  ID='valCompEstoque' Display='None' ErrorMessage='Estoque inv&aacute;lida' ControlToValidate='txtEstoque' Operator='DataTypeCheck' Type='Integer' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trPrecoUnitario' visible='<%$Settings: visible, Produto.PrecoUnitario, true %>' >
				<div class='tdFieldHeader cb fl'>
					Pre&ccedil;o Unit&aacute;rio:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoUnitario' />
					<asp:RequiredFieldValidator runat='server' ID='valReqPrecoUnitario' Enabled='<%$Settings: Required, Produto.PrecoUnitario, true %>' Display='None' ErrorMessage='PrecoUnitario &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrecoUnitario' />
					<asp:CompareValidator runat='server'  ID='valCompPrecoUnitario' Display='None' ErrorMessage='PrecoUnitario inv&aacute;lida' ControlToValidate='txtPrecoUnitario' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescontoMax' visible='<%$Settings: visible, Produto.DescontoMax, true %>' >
				<div class='tdFieldHeader cb fl'>
					Desconto M&aacute;x.:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescontoMax' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescontoMax' Enabled='<%$Settings: Required, Produto.DescontoMax, true %>' Display='None' ErrorMessage='Desconto M&aacute;x. &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescontoMax' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Produto.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField cb' runat='server' id='trProdutoAtivo' visible='<%$Settings: visible, Produto.ProdutoAtivo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Ativo:
				</div>
				<div class='tdField fl'>
					<asp:checkbox runat='server' ID='chkProdAtivo' />
				</div>
			</div>
		</div>
	</div>
    <div class='EditArea'>
		<div class='divEditArea'>
	        <div class='ListArea'>
	            <div class='divHeader'><b>Listagem de Preços por Estado</b></div>
                <asp:DataList RepeatColumns=3 ID="rptPrecoEstado" Runat="server" SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='UF'>
                    <ItemTemplate>
                        <asp:Label runat='server' ID='lblEstado' Text='<%# Eval("uf") %>'></asp:Label>
                        <asp:TextBox onBlur="formatValue(this);" runat='server' ID="txtPreco" Text='<%# GetPreco(Eval("preco"))%>'></asp:TextBox>                
                    </ItemTemplate>
                </asp:DataList>
             </div>
        </div>
    </div>	
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' visible="false" />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Produto.aspx?idproduto=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Produtos.aspx'" />
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
		    <li runat="server" visible="false">
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

