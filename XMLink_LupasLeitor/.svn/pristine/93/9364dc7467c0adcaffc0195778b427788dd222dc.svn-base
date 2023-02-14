<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Vendedor.aspx.vb" Inherits="Pages.Cadastros.Vendedor" title="Untitled Page" %>
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
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoVendedor'>
						Vendedor:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtVendedor' MaxLength='60' />
					<asp:RequiredFieldValidator runat='server' ID='valReqVendedor' Display='None' ErrorMessage='Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtVendedor' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoLogin'>
						Login:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtLogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLogin' Display='None' ErrorMessage='Login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLogin' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoSenha'>
						Senha:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:UpdatePanel runat="server" id="pnlSenha">
				        <ContentTemplate>
        					<asp:TextBox runat="server" ID="txtSenha" MaxLength="20" TextMode="Password" />
        					<asp:Button runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin-left:0px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoTelefone'>
						Telefone :
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' /><span class="obs">(Formato: 1177777777)</span>
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoID'>
						ID :
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtID' MaxLength='20' /><span class="obs">(Formato: 55*111*111)</span>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoMaxDesconto'>
						M&aacute;x Desconto:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtMaxDesconto' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Desconto m&aacute;ximo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMaxDesconto' />
					<asp:CompareValidator runat='server' ID='valCompMinimo' Display='None' Operator='DataTypeCheck' Type='Double' ErrorMessage='Desconto m&aacute;ximo  inválido!' ControlToValidate='txtMaxDesconto' />
					<asp:CompareValidator runat='server' ID='CompareValidator1' Display='None' Operator="GreaterThanEqual" Type='Double' ErrorMessage='Desconto m&aacute;ximo  n&atilde;o pode ser inferior a 0!' ControlToValidate='txtMaxDesconto' ValueToCompare='0' />
					<asp:CompareValidator runat='server' ID='CompareValidator2' Display='None' Operator="LessThanEqual" Type='Double' ErrorMessage='Desconto m&aacute;ximo  n&atilde;o pode ser superior a 100!' ControlToValidate='txtMaxDesconto' ValueToCompare='100' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'>
						Data de cria&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
				<asp:Label runat='server' ID='DataCriado'/>		
               
				</td>
			</tr>
			<tr>
				<td colspan='4' align='center'>
				    <table width='90%'>
				        <tr id="trTodosClientes" runat="server" visible="false">
				            <td class='tdSimple'>
				                <span>
		                            <asp:Label runat='server' ID='lblTextoTodosClientes'>
				                        Ver todos os clientes:
			                        </asp:Label> 
			                        <asp:CheckBox runat='server' ID='chkTodosClientes' />
				                </span>
				            </td>
				        </tr>
				        <tr align='left'>
				            <td class='tdSimple' colspan='2'>
				                <asp:Label runat='server' ID='lblTextoObservacao'>
						            observa&ccedil;&atilde;o:
					            </asp:Label> 
					            <br />
					            <asp:TextBox runat='server' ID='txtObservacao' MaxLength='2000' TextMode='MultiLine' Width='100%' Rows='4' />
				            </td>
				        </tr>
				    </table>
				</td>
			</tr>
            <tr>
                <td colspan='4' align='center'>
				    <table width='90%'>
				        <tr class="trField" >
                            <td class="tdFieldHeaderLeft" style="width:100%" >
                            	<asp:Label runat='server' ID='Label1'>
				                    O vendedor atende os seguintes clientes:
			                    </asp:Label> 
                                <asp:GridView runat='server' id='grdClientes' AutoGenerateColumns='false' AllowSorting='false'>
				                    <HeaderStyle HorizontalAlign='Left' />
					                <columns>
						                <asp:BoundField HeaderText="Codigo" DataField="Codigo" SortExpression="Codigo" />
						                <asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						                <asp:BoundField HeaderText="CNPJ" DataField="CNPJ" SortExpression="CNPJ" />
						                <asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
                                        <asp:BoundField HeaderText="REFERENCIA" DataField="REFERENCIA" SortExpression="REFERENCIA" />
					                </columns>
					                <EmptyDataTemplate>
				                        <div class='GridHeader'>&nbsp;</div>					    
					                    <div class='divEmptyRow'>
							                <asp:Label runat='server' ID='lblNaoEncontrados'>
								                N&atilde;o h&aacute; clientes para este vendedor
							                </asp:Label>
					                    </div>
					                </EmptyDataTemplate>
                                    
				                </asp:GridView>
                                Quantidade de clientes: <asp:Literal runat="server" ID='ltrQuantidadeClientes' />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Vendedor.aspx?idvendedor=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Vendedores.aspx'" />
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

