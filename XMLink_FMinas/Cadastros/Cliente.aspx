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
			<div class='trField fr' runat='server' id='trCNPJ' visible='<%$Settings: visible, Cliente.CNPJ, true %>' >
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
			<div class='trField cb fl' runat='server'  id='trEndereco' visible='<%$Settings: visible, Cliente.Endereco, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='80' Width='200px' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Cliente.Endereco, false %>' Display='None' ErrorMessage='Endere&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trReferencia' visible='<%$Settings: visible, Cliente.Referencia, true %>' >
				<div class='tdFieldHeader fl'>
					Refer&ecirc;ncia:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtReferencia' MaxLength='80' Width='200px' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Cliente.Referencia, false %>' Display='None' ErrorMessage='Refer&circ;ncia &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtReferencia' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trBairro' visible='<%$Settings: visible, Cliente.Bairro, true %>' >
				<div class='tdFieldHeader fl'>
					Bairro:
				</div>
				<div class='tdField'>
					<asp:TextBox runat='server' ID='txtBairro' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Cliente.Bairro, false %>' Display='None' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
				</div>
			</div>
			<div class='trField fl' runat='server'  id='trCidade' visible='<%$Settings: visible, Cliente.Cidade, true %>' >
				<div class='tdFieldHeader fl'>
					Cidade:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCidade' MaxLength='40' width='170px'/>
					<asp:RequiredFieldValidator runat='server' ID='valReqCidade' Enabled='<%$Settings: Required, Cliente.Cidade, false %>' Display='None' ErrorMessage='Cidade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trCEP' visible='<%$Settings: visible, Cliente.CEP, true %>' >
				<div class='tdFieldHeader fl' style="width:40px">
					CEP:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCEP' MaxLength='10' Width="65px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqCEP' Enabled='<%$Settings: Required, Cliente.CEP, false %>' Display='None' ErrorMessage='CEP &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCEP' />
				</div>
			</div>


			<div class='trField fr' runat='server'  id='trUF' visible='<%$Settings: visible, Cliente.UF, true %>' >
				<div class='tdFieldHeader fl' style="width:40px">
					UF:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
					<asp:CompareValidator runat="server"  ID="valCompUF" Display="None" ErrorMessage="UF inv&aacute;lida" ControlToValidate="cboUF" Operator="NotEqual" ValueToCompare="" />
				</div>
              </div>
			
            <div class='trField fr' runat='server'  id='trFil' visible='true' >
            <div class='tdFieldHeader fl' style="width:40px">
            Filial:
            </div>
            <div class='tdField fl'>
            <asp:DropDownList DataTextField="Filial" DataValueField="Filial" runat="server" ID="cboFilial" />
       
            </div>
            </div>


            <br class='cb' />
			<div class='trField cb fl' runat='server'  id='trTelefone' visible='<%$Settings: visible, Cliente.Telefone, true %>' >
				<div class='tdFieldHeader fl'>
					Telefone:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Enabled='<%$Settings: Required, Cliente.Telefone, false %>' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trContato' visible='<%$Settings: visible, Cliente.Contato, true %>' >
				<div class='tdFieldHeader fl' style="width:90px">
					Contato:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtContato' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqContato' Enabled='<%$Settings: Required, Cliente.Contato, false %>' Display='None' ErrorMessage='Contato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContato' />
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
			<div class='trField fl' runat='server'  style="width:280px;" id='trTabelaPreco' visible='<%$Settings: visible, Cliente.TabelaPreco, false %>' >
				<div class='tdFieldHeader fl'>
					Tabela de Pre&ccedil;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTabelaPreco' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTabelaPreco' Enabled='<%$Settings: Required, Cliente.TabelaPreco, false %>' Display='None' ErrorMessage='Tabela de Pre&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTabelaPreco' />
				</div>
			</div>
			<div class='trField fl' runat='server' style="width:280px;"  id='trDescontoMax' visible='<%$Settings: visible, Cliente.DescontoMax, true %>' >
				<div class='tdFieldHeader fl'>
					Desconto M&aacute;x.:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescontoMax' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescontoMax' Enabled='<%$Settings: Required, Cliente.DescontoMax, true %>' Display='None' ErrorMessage='Desconto M&aacute;x. &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescontoMax' />
				</div>
			</div>
			<div class='trField fl' runat='server' style="width:280px;" id='trLimiteCredito' visible='<%$Settings: visible, Cliente.LimiteCredito, false %>' >
				<div class='tdFieldHeader fl'>
					Limite de Cr&eacute;dito:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLimiteCredito' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLimiteCredito' Enabled='<%$Settings: Required, Cliente.LimiteCredito, false %>' Display='None' ErrorMessage='Limite de Cr&eacute;dito &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLimiteCredito' />
					<asp:CompareValidator runat='server'  ID='valCompLimiteCredito' Display='None' ErrorMessage='LimiteCredito inv&aacute;lida' ControlToValidate='txtLimiteCredito' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div class='trField fl' runat='server' style="width:280px;" id='trCondicao' visible='<%$Settings: visible, Cliente.Condicao, true %>' >
				<div class='tdFieldHeader fl'>
					Condi&ccedil&atilde;o de Pagamento:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList DataTextField="Condicao" DataValueField="IDCondicao" runat="server" ID="cboCondicao" />
				</div>
			</div>
            <div class='trField fl' runat='server' style="width:280px;" id='trBloqueio' visible='<%$Settings: visible, Cliente.Bloqueio, true %>' >
				<div class='tdFieldHeader fl'>
					Bloqueio:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList DataTextField="Bloqueio" DataValueField="IDBloqueio" runat="server" ID="cboBloqueio" />
				</div>
			</div>
			<div class='trField fl cb' runat='server'  id='trObservacao' visible='<%$Settings: visible, Cliente.Observacao, true %>' >
				<div class='tdFieldHeader fl'>
					Observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' TextMode='MultiLine' Rows='5' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Cliente.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>
		</div>
	</div>
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlVendedores'>
            <ContentTemplate>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdVendedores' AutoGenerateColumns='false' Width='100%'>
                        <Columns>
                            <asp:BoundField DataField='Vendedor' HeaderText='Vendedores autorizados' HeaderStyle-HorizontalAlign='Left' />
                            <asp:TemplateField ItemStyle-HorizontalAlign='Right'>
                                <ItemTemplate>
                                    <asp:LinkButton Visible='True' Runat='server' ID='btnExcluir' CommandName='Excluir' CommandArgument='<%# Eval("IDVendedor") %>' Text="<img src='../imagens/excluir.gif' border=0 alt='Retirar Vendedor'>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="TextDefault" width='100%' cellspacing="0" cellpadding="4" border="0" >
                                <tr class="GridHeader">
                                    <td>
                                    Vendedores autorizados
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Todos os vendedores
                                    </td>
                                </tr>
                               </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div> 
                <div id='AdicionarVendedor'>
                    <h4>Adicionar Vendedor</h4>
                    <asp:DropDownList runat='server' ID='cboIDVendedor' DataTextField='Vendedor' DataValueField='IDVendedor' /> 
                    <asp:Button runat='server' ID='btnAddVendedor' Text='Adicionar' ValidationGroup='AdicionarVendedor' />
                    <asp:CompareValidator runat='server' ID='CompareValidator1' ErrorMessage='Por favor selecione o vendedor!' ControlToValidate='cboIDVendedor' Operator='GreaterThan' ValueToCompare='0' ValidationGroup='AdicionarVendedor' ></asp:CompareValidator>
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

