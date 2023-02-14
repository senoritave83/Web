<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="Pages.Cadastros.Cliente" title="Untitled Page" %>
<%@ Register src="../controls/txtDescontoMaximo.ascx" tagname="txtDescontoMaximo" tagprefix="uc3" %>
<%@ Register src="../controls/txtCorrecao.ascx" tagname="txtCorrecao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server' id='trCodigo' style='width:250px' visible='<%$Settings: visible, Cliente.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl' style='width:100px'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Cliente.Codigo, false %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField' runat='server' style='width:350px'  id='trCNPJ' visible='<%$Settings: visible, Cliente.CNPJ, true %>' >
				<div class='tdFieldHeader fl' style='width:210px'>
					CNPJ:
				</div>
				<div class='tdField fl' style='width:130px'>
					<asp:TextBox runat='server' ID='txtCNPJ' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCNPJ' Enabled='<%$Settings: Required, Cliente.CNPJ, false %>' Display='None' ErrorMessage='CNPJ &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server' style='width:600px;'  id='trCliente' visible='<%$Settings: visible, Cliente.Cliente, true %>' >
				<div class='tdFieldHeader fl'>
					Cliente:
				</div>
				<div class='tdField fl' style='width:460px;'>
					<asp:TextBox runat='server' ID='txtCliente' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCliente' Enabled='<%$Settings: Required, Cliente.Cliente, true %>' Display='None' ErrorMessage='Cliente &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCliente' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server' style='width:600px;'   id='trEndereco' visible='<%$Settings: visible, Cliente.Endereco, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o:
				</div>
				<div class='tdField fl' style='width:460px;'>
					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='150' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Cliente.Endereco, false %>' Display='None' ErrorMessage='Endere&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server'  id='trReferencia' style='width:350px;' visible='<%$Settings: visible, Cliente.Referencia, true %>' >
				<div class='tdFieldHeader fl'>
					Refer&ecirc;ncia:
				</div>
				<div class='tdField fl' style='width:200px;'>
					<asp:TextBox runat='server' ID='txtReferencia' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqReferencia' Enabled='<%$Settings: Required, Cliente.Referencia, false %>' Display='None' ErrorMessage='Refer&ecirc;ncia &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtReferencia' />
				</div>
			</div>
			<div class='trField' runat='server' style='width:250px;' id='trBairro' visible='<%$Settings: visible, Cliente.Bairro, true %>' >
				<div class='tdFieldHeader fl' style='width:70px;' >
					Bairro:
				</div>
				<div class='tdField fl' style='width:170px;'>
					<asp:TextBox runat='server' ID='txtBairro' MaxLength='30' />
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Cliente.Bairro, false %>' Display='None' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server'  id='trCidade' style='width:320px' visible='<%$Settings: visible, Cliente.Cidade, true %>' >
				<div class='tdFieldHeader fl'>
					Cidade:
				</div>
				<div class='tdField fl' style='width:180px'>
					<asp:TextBox runat='server' ID='txtCidade' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCidade' Enabled='<%$Settings: Required, Cliente.Cidade, false %>' Display='None' ErrorMessage='Cidade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trCEP' style='width:160px;' visible='<%$Settings: visible, Cliente.CEP, true %>' >
				<div class='tdFieldHeader fl' style='width:50px'>
					CEP:
				</div>
				<div class='tdField fl' style='width:100px'>
					<asp:TextBox runat='server' ID='txtCEP' MaxLength='10' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCEP' Enabled='<%$Settings: Required, Cliente.CEP, false %>' Display='None' ErrorMessage='CEP &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCEP' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trUF' style='width:120px;' visible='<%$Settings: visible, Cliente.UF, true %>' >
				<div class='tdFieldHeader fl' style='width:50px'>
					UF:
				</div>
				<div class='tdField fl' style='width:60px'>
					<asp:TextBox runat='server' ID='txtUF' MaxLength='2' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server'  id='trTelefone' style='width:250px;' visible='<%$Settings: visible, Cliente.Telefone, true %>' >
				<div class='tdFieldHeader fl'>
					Telefone:
				</div>
				<div class='tdField fl' style='width:100px;'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Enabled='<%$Settings: Required, Cliente.Telefone, false %>' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trContato' visible='<%$Settings: visible, Cliente.Contato, true %>' >
				<div class='tdFieldHeader fl'>
					Contato:
				</div>
				<div class='tdField fl' style='width:210px;'>
					<asp:TextBox runat='server' ID='txtContato' MaxLength='30' />
					<asp:RequiredFieldValidator runat='server' ID='valReqContato' Enabled='<%$Settings: Required, Cliente.Contato, false %>' Display='None' ErrorMessage='Contato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContato' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCorrecao' visible='<%$Settings: visible, Condicao.Correcao, true %>' >
				<div class='tdFieldHeader fl'>
					Tabela de Preço:
				</div>
				<div class='tdField fl'>
					<uc1:txtCorrecao ID='txtCorrecao' runat="server" Required="<%$Settings: Required, Condicao.Correcao, false %>" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescontoMax' visible='<%$Settings: visible, Cliente.DescontoMax, true %>' >
				<div class='tdFieldHeader fl'>
					Desconto M&aacute;x.:
				</div>
				<div class='tdField fl'>
					<uc3:txtDescontoMaximo ID='txtDescontoMax' runat="server" Required="<%$Settings: Required, Cliente.DescontoMax, false %>" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trLimiteCredito' visible='<%$Settings: visible, Cliente.LimiteCredito, true %>' >
				<div class='tdFieldHeader fl'>
					Limite de Cr&eacute;dito:
				</div>
				<div class='tdField fl' style='width:100px;'>
					<asp:TextBox runat='server' ID='txtLimiteCredito' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLimiteCredito' Enabled='<%$Settings: Required, Cliente.LimiteCredito, false %>' Display='None' ErrorMessage='LimiteCredito &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLimiteCredito' />
					<asp:CompareValidator runat='server'  ID='valCompLimiteCredito' Display='None' ErrorMessage='LimiteCredito inv&aacute;lida' ControlToValidate='txtLimiteCredito' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trObservacao' style='width:600px;' visible='<%$Settings: visible, Cliente.Observacao, true %>' >
				<div class='tdFieldHeader fl'>
					observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl' style='width:460px;'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' TextMode='MultiLine' Rows='5' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Cliente.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Cliente.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<br class='cb' />
		</div>
	</div>
    
    <asp:PlaceHolder runat='server' ID='plhLinhaNegocio'>
        <div id='divClientesLinhaNegocio'>
            <asp:GridView runat='server' ID='grdLinhaNegocio' DataKeyNames='IDLinhaNegocio' AutoGenerateColumns='false'>
                <HeaderStyle HorizontalAlign='Left' />
                <Columns>  
                    <asp:BoundField HeaderText='Linha de Negócio' DataField='LinhaNegocio' />
                    <asp:ButtonField  CommandName='RetirarLinhaNegocio' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                </Columns>
                <EmptyDataTemplate>
                    <div class='GridHeader'>&nbsp;</div>					    
	                <div class='divEmptyRow'>
                        Não há Linha de Negócio cadastrada para esse cliente!
	                </div>
                </EmptyDataTemplate>
            </asp:GridView>
            Adicionar Linha de Negócio:
            <asp:DropDownList ID='cboLinhaNegocio' runat="server" DataTextField="LinhaNegocio" DataValueField="IdLinhaNegocio"/>
            <asp:CompareValidator runat='server' ID='valCompLinhaNegocio' ErrorMessage='*' ControlToValidate='cboLinhaNegocio' Operator='GreaterThan' ValueToCompare='0' ValidationGroup='AddLinhaNegocio' ></asp:CompareValidator>
            <asp:Button runat='server' ID='btnAddLinhaNegocio' Text='Adicionar' ValidationGroup='AddLinhaNegocio' />
        </div> 
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder runat='server' ID='plhVendedores'>
        <div id='divVendedoresRoteiro'>
            <asp:GridView runat='server' ID='grdVendedores' DataKeyNames='IDVendedor' AutoGenerateColumns='false'>
                <HeaderStyle HorizontalAlign='Left' />
                <Columns>  
                    <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                    <asp:BoundField HeaderText='Vendedor' DataField='Vendedor' />
                    <asp:ButtonField  CommandName='RetirarVendedor' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                </Columns>
                <EmptyDataTemplate>
                    <div class='GridHeader'>&nbsp;</div>					    
	                <div class='divEmptyRow'>
                        Não há vendedores cadastrados para esse cliente!
	                </div>
                </EmptyDataTemplate>
            </asp:GridView>
            Adicionar Vendedor:
            <asp:DropDownList runat='server' ID='cboNovoVendedor' DataTextField='Vendedor' DataValueField='IDVendedor'></asp:DropDownList>
            <asp:CompareValidator runat='server' ID='valCompVendedor' ErrorMessage='*' ControlToValidate='cboNovoVendedor' Operator='GreaterThan' ValueToCompare='0' ValidationGroup='AddNovoVendedor' ></asp:CompareValidator>
            <asp:Button runat='server' ID='btnAdicionarVendedor' Text='Adicionar' ValidationGroup='AddNovoVendedor' />
        </div> 
    </asp:PlaceHolder>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cliente.aspx?idcliente=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Clientes.aspx'" />
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

