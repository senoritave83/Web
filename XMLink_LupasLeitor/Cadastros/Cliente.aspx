<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="Pages.Cadastros.Cliente" title="Untitled Page" %>
<%@ Register src="../controls/txtCorrecao.ascx" tagname="txtCorrecao" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCodigo'>
						C&oacute;digo:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCNPJ'>
						CNPJ:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCNPJ' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Display='None' ErrorMessage='CNPJ &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCliente'>
						Nome:
					</asp:Label> 
				</td>
				<td class='tdField' >
					<asp:TextBox runat='server' ID='txtCliente' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCliente' Display='None' ErrorMessage='Cliente &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCliente' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblNomeFantasia'>
						Nome Fantasia:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtNomeFantasia' MaxLength='100' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoEndereco'>
						Endere&ccedil;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='150' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoReferencia'>
						Refer&ecirc;ncia:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="drpReferencia" DataTextField="Referencia" DataValueField="Referencia"></asp:DropDownList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoBairro'>
						Bairro:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtBairro' MaxLength='30' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCidade'>
						Cidade:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCidade' MaxLength='50' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCEP'>
						CEP:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCEP' MaxLength='10' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoUF'>
						UF:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF">
                        <asp:ListItem Value=''></asp:ListItem>
                        <asp:ListItem Value='AC'>AC</asp:ListItem>
                        <asp:ListItem Value='AL'>AL</asp:ListItem>
                        <asp:ListItem Value='AM'>AM</asp:ListItem>
                        <asp:ListItem Value='AP'>AP</asp:ListItem>
                        <asp:ListItem Value='BA'>BA</asp:ListItem>
                        <asp:ListItem Value='CE'>CE</asp:ListItem>
                        <asp:ListItem Value='DF'>DF</asp:ListItem>
                        <asp:ListItem Value='ES'>ES</asp:ListItem>
                        <asp:ListItem Value='GO'>GO</asp:ListItem>
                        <asp:ListItem Value='MA'>MA</asp:ListItem>
                        <asp:ListItem Value='MG'>MG</asp:ListItem>
                        <asp:ListItem Value='MS'>MS</asp:ListItem>
                        <asp:ListItem Value='MT'>MT</asp:ListItem>
                        <asp:ListItem Value='PA'>PA</asp:ListItem>
                        <asp:ListItem Value='PB'>PB</asp:ListItem>
                        <asp:ListItem Value='PE'>PE</asp:ListItem>
                        <asp:ListItem Value='PI'>PI</asp:ListItem>
                        <asp:ListItem Value='PR'>PR</asp:ListItem>
                        <asp:ListItem Value='RJ'>RJ</asp:ListItem>
                        <asp:ListItem Value='RN'>RN</asp:ListItem>
                        <asp:ListItem Value='RO'>RO</asp:ListItem>
                        <asp:ListItem Value='RR'>RR</asp:ListItem>
                        <asp:ListItem Value='RS'>RS</asp:ListItem>
                        <asp:ListItem Value='SC'>SC</asp:ListItem>
                        <asp:ListItem Value='SE'>SE</asp:ListItem>
                        <asp:ListItem Value='SP'>SP</asp:ListItem>
                        <asp:ListItem Value='TO'>TO</asp:ListItem>
					</asp:DropDownList>
					<asp:CompareValidator runat="server"  ID="valCompUF" Display="None" ErrorMessage="UF inv&aacute;lida" ControlToValidate="cboUF" Operator="NotEqual" ValueToCompare="" />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoTelefone'>
						Telefone:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoContato'>
						Contato:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtContato' MaxLength='30' />
				</td>
                <tr  class='trField'>
                <td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoEmail'>
						Email:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='TxtEmail' MaxLength='50' />
				</td>
                </tr>

			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoTabelaPreco'>
						Corre&ccedil;&atilde;o de Pre&ccedil;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					 <uc1:txtCorrecao runat='server' ID='txttabelaPreco' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDescontoMax'>
						Desconto M&aacute;x.:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDescontoMax' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Desconto m&aacute;ximo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescontoMax' />
					<asp:CompareValidator runat='server' ID='valCompMinimo' Display='None' Operator='DataTypeCheck' Type='Double' ErrorMessage='Desconto m&aacute;ximo  inválido!' ControlToValidate='txtDescontoMax' />
					<asp:CompareValidator runat='server' ID='CompareValidator1' Display='None' Operator="GreaterThanEqual" Type='Double' ErrorMessage='Desconto m&aacute;ximo  n&atilde;o pode ser inferior a 0!' ControlToValidate='txtDescontoMax' ValueToCompare='0' />
					<asp:CompareValidator runat='server' ID='CompareValidator2' Display='None' Operator="LessThanEqual" Type='Double' ErrorMessage='Desconto m&aacute;ximo  n&atilde;o pode ser superior a 100!' ControlToValidate='txtDescontoMax' ValueToCompare='100' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoLimiteCredito'>
						Limite de Cr&eacute;dito:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtLimiteCredito' />
					<asp:CompareValidator runat='server'  ID='valCompLimiteCredito' Display='None' ErrorMessage='LimiteCredito inv&aacute;lida' ControlToValidate='txtLimiteCredito' Operator='DataTypeCheck' Type='Currency' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'>
						Data de cria&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
				 <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='DataCriado' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
	          	<asp:TextBox runat='server' ID='DataCriado' MaxLength="10" Width='75px' />		
                <ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="DataCriado" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />		
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label2'>
						Bloqueado:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkBloqueado' />
				</td>
				<td class='tdFieldHeader' colspan='2'>
						&nbsp;
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label1'>
						Observa&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' TextMode='MultiLine' Rows='4' width='100%' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlVendedores'>
            <ContentTemplate>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdVendedores' AutoGenerateColumns='false' Width='100%'>
                        <Columns>
                            <asp:BoundField DataField='Vendedor' HeaderText='Vendedor autorizado' HeaderStyle-HorizontalAlign='Left' />
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
                                    Vendedor autorizado
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nenhum vendedor selecionado
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
                    <asp:CompareValidator runat='server' ID='valCompIDVendedor' ErrorMessage='Por favor selecione o vendedor!' ControlToValidate='cboIDVendedor' Operator='GreaterThan' ValueToCompare='0' ValidationGroup='AdicionarVendedor' ></asp:CompareValidator>
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
		        <asp:Localize runat='server' ID='Localize1'>
			        <b>Adicionar:</b>
				    Grava apenas um vendedor para cada cliente no banco de dados.
		        </asp:Localize>
		    </li> 
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

