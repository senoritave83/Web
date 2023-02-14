<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FormaPagamento.aspx.vb" Inherits="Pages.Cadastros.FormaPagamento" title="Untitled Page" %>
<%@ Register src="../controls/txtCorrecao.ascx" tagname="txtCorrecao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCodigo'>
						C&oacute;digo:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='Codigo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoFormaPagamento'>
						Forma de Pagamento:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtFormaPagamento' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqFormaPagamento' Display='None' ErrorMessage='FormaPagamento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFormaPagamento' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCorrecao'>
						Corre&ccedil&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					 <uc1:txtCorrecao runat='server' ID='txtCorrecao' />
				</td>
			</tr>

               <tr class='trField'>
				<td class='tdFieldHeader'>
					Status:
				</td>
				<td class='tdField'>
					<asp:RadioButtonList runat="server" ID="rdStatus" RepeatDirection="Horizontal" Width="170">
                        <asp:ListItem Text="Ativo" Value="1" Selected></asp:ListItem>
                        <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'>
						Data de cria&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan=2>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='FormaPagamento.aspx?idformapagamento=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='FormaPagamentos.aspx'" />
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

