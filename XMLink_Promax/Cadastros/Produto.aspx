<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' id='ScriptManager1'></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField' runat='server'  id='trCodigo' visible='<%$Settings: visible, Produto.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='40' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Produto.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField' style="width:100%" runat='server'  id='trDescricao' visible='<%$Settings: visible, Produto.Descricao, true %>' >
				<div class='tdFieldHeader fl'>
					Descricao:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='120' style="width:400px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Enabled='<%$Settings: Required, Produto.Descricao, false %>' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField' runat='server'  id='trContrato' visible='<%$Settings: visible, Produto.Contrato, true %>' >
				<div class='tdFieldHeader fl'>
					Contrato:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtContrato' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqContrato' Enabled='<%$Settings: Required, Produto.Contrato, false %>' Display='None' ErrorMessage='Contrato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContrato' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trEstoque' visible='<%$Settings: visible, Produto.Estoque, true %>' >
				<div class='tdFieldHeader fl'>
					Estoque:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEstoque' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEstoque' Enabled='<%$Settings: Required, Produto.Estoque, false %>' Display='None' ErrorMessage='Estoque &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEstoque' />
					<asp:CompareValidator runat='server'  ID='valCompEstoque' Display='None' ErrorMessage='Estoque inv&aacute;lida' ControlToValidate='txtEstoque' Operator='DataTypeCheck' Type='Integer' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField' runat='server'  id='trIPI' visible='<%$Settings: visible, Produto.IPI, true %>' >
				<div class='tdFieldHeader fl'>
					IPI:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtIPI' />
					<asp:RequiredFieldValidator runat='server' ID='valReqIPI' Enabled='<%$Settings: Required, Produto.IPI, false %>' Display='None' ErrorMessage='IPI &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtIPI' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trCriado' visible='<%$Settings: visible, Produto.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
		</div>
	</div>
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlPrecos'>
            <ContentTemplate>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdPrecos' SkinID='GridInterno' AutoGenerateColumns='false' Width='100%'>
                        <HeaderStyle HorizontalAlign='Left' />
                        <Columns>
                            <asp:BoundField DataField='LISTAPRECO' HeaderText='Lista' />
                            <asp:BoundField DataField='PRECOUNITARIO' HeaderText='Pre&ccedil;o unit&aacute;rio' DataFormatString='{0:c}' />
                            <asp:BoundField DataField='DESCONTOMAX' HeaderText='Desconto M&aacute;x.' DataFormatString='{0:F2}' />
                        </Columns>
                    </asp:GridView>
                </div> 
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>	
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
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

