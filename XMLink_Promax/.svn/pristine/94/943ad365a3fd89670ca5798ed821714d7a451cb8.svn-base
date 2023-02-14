<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="Pages.Cadastros.Cliente" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' ></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, Cliente.Codigo, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Cliente.Codigo, true %>' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField fr' runat='server' id='trCNPJ' visible='<%$Settings: visible, Cliente.CNPJ, false %>' >
				<div class='tdFieldHeader fl'>
					CNPJ:
				</div>
				<div class='tdField'>
					<asp:TextBox runat='server' ID='txtCNPJ' Width='110px' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCNPJ' Enabled='<%$Settings: Required, Cliente.CNPJ, false %>' Display='None' ErrorMessage='CNPJ &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCliente' visible='<%$Settings: visible, Cliente.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCliente' MaxLength='60' width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCliente' Enabled='<%$Settings: Required, Cliente.Cliente, true %>' Display='None' ErrorMessage='Cliente &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCliente' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Cliente.Vendedor, true %>' >
				<div class='tdFieldHeader cb fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
                    <asp:DropDownList runat='server' ID='cboIDVendedor' DataTextField='Vendedor' DataValueField='IDVendedor' /> 
                    <asp:CompareValidator runat='server' ID='CompareValidator1' ErrorMessage='Por favor selecione o vendedor!' ControlToValidate='cboIDVendedor' Operator='GreaterThan' ValueToCompare='0' ValidationGroup='AdicionarVendedor' ></asp:CompareValidator>
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Cliente.Cliente, true %>' Display='None' ErrorMessage='Cliente &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDVendedor' />
				</div>
			</div>
			<div class='trField fl' runat='server'  style="width:280px;" id='Div2' visible='<%$Settings: visible, Cliente.Status, true %>' >
				<div class='tdFieldHeader fl'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblStatus' />
				</div>
			</div>
			<div class='trField fl' runat='server'  style="width:280px;" id='Div3' visible='<%$Settings: visible, Cliente.ListaPreco, true %>' >
				<div class='tdFieldHeader fl'>
					Lista de Pre&ccedil;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtListaPreco'></asp:TextBox>
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' runat='server'  style="width:280px;" id='trCriado' visible='<%$Settings: visible, Cliente.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField fl cb' runat='server'  id='trObservacao' visible='<%$Settings: visible, Cliente.Observacao, true %>' >
				<div class='tdFieldHeader fl'>
					observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' TextMode='MultiLine' Rows='5' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Cliente.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>
		</div>
	</div>
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlEnderecos'>
            <ContentTemplate>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdEnderecos' SkinID='GridInterno' AutoGenerateColumns='false' Width='100%'>
                        <HeaderStyle HorizontalAlign='Left' />
                        <Columns>
                            <asp:BoundField DataField='Descricao' HeaderText='Endere&ccedil;o' />
                            <asp:BoundField DataField='CNPJ' HeaderText='CNPJ' />
                            <asp:BoundField DataField='Tipo' HeaderText='Tipo' />
                        </Columns>
                    </asp:GridView>
                </div> 
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>	
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

