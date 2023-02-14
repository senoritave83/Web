<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='3'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='3'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCodigo'> C&oacute;digo: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='40' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display="None"  ErrorMessage='Codigo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</td>
			    <td rowspan='7' width='200' align='center'>
			        <asp:Panel runat='server' ID='pnlFoto'>
			            <table>
			                <tr>
			                    <td>
			                        <asp:HyperLink runat='server' ID='lnkFoto'>
		    	                        <asp:Image runat='server' ID='imgProduto' ImageUrl="~/imagens/noimage.png" Width='200' />
    		                        </asp:HyperLink>
	    	                    </td>
			                </tr>
			            </table>
    			        <a href='produtofotos.aspx?idproduto=<%=ViewState(VW_IDPRODUTO) %>'>Ver/Adicionar fotos</a>
			        </asp:Panel>
			    </td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDescricao'> Descri&ccedil;&atilde;o: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='120' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDCategoria'> Categoria: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
					<asp:CompareValidator runat="server"  ID="valCompIDCategoria" Display="None" ErrorMessage="Categoria inv&aacute;lida" ControlToValidate="cboIDCategoria" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDCategoria' Display='None' ErrorMessage='Categoria &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDCategoria' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoEstoque'> Estoque: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtEstoque' />
					<asp:CompareValidator runat='server'  ID='valCompEstoque' Display='None' ErrorMessage='Estoque inv&aacute;lida' ControlToValidate='txtEstoque' Operator='DataTypeCheck' Type='Integer' />
				</td>
			</tr>


			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoPrecoUnitario'> Pre&ccedil;o Unit&aacute;rio: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPrecoUnitario' />
					<asp:CompareValidator runat='server'  ID='valCompPrecoUnitario' Display='None' ErrorMessage='PrecoUnitario inv&aacute;lida' ControlToValidate='txtPrecoUnitario' Operator='DataTypeCheck' Type='Currency' />
                    				</td>
			</tr>

            <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoPrecoVista'> Custo a Vista: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPrecoVista' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecoVista"  ErrorMessage="Preco á Vista Vazio"></asp:RequiredFieldValidator>
					<asp:CompareValidator runat='server'  ID='valCompPrecoVista' Display='None' ErrorMessage='PrecoaVista inv&aacute;lida' ControlToValidate='txtPrecoVista' Operator='DataTypeCheck' Type='Currency' />
                    <asp:CustomValidator runat='server' ID="FuncaoPrecoVista" Display='None' OnServerValidate="FuncaoPrecoVista_ServerValidate" ControlToValidate="txtPrecoVista" ></asp:CustomValidator>
				</td>
			</tr>

              <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoPrecoPre'> Custo Pre: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPrecoPre' />
                    <asp:RequiredFieldValidator  runat="server" ControlToValidate="txtPrecoPre"  ErrorMessage="Preço Pré Vazio"></asp:RequiredFieldValidator>
					<asp:CompareValidator runat='server'  ID='valCompPrecoPRe' Display='None' ErrorMessage='PrecoPRe inv&aacute;lida' ControlToValidate='txtPrecoPre' Operator='DataTypeCheck' Type='Currency' />
                    <asp:CustomValidator runat='server' ID="FuncaoPrecoPre" OnServerValidate="FuncaoPrecoPre_ServerValidate" ControlToValidate="txtPrecoPre"  ></asp:CustomValidator>
				</td>
			</tr>

              <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoPrecoBoleto'> Custo Boleto: </asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPrecoBoleto' />
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecoBoleto"  ErrorMessage="Preco Boleto Vazio"></asp:RequiredFieldValidator>
					<asp:CompareValidator runat='server'  ID='valCompPrecoBoleto' Display='None' ErrorMessage='Precoboleto inv&aacute;lida' ControlToValidate='txtPrecoBoleto' Operator='DataTypeCheck' Type='Currency' />
                    <asp:CustomValidator runat='server' ID="FuncaoPrecoBoleto" OnServerValidate="FuncaoPrecoBoleto_ServerValidate" ControlToValidate="txtPrecoBoleto" ></asp:CustomValidator>
				</td>
			</tr>
            
            
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'> Data de cria&ccedil;&atilde;o: </asp:Label> 
				</td>
				<td class='tdField'>
				
				<asp:Label runat='server' ID='DataCriado' />		
          
		        
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' colspan='2'>&nbsp;</td>
		    </tr> 
			<tr class="trEditFooter">
			    <td colspan='3'>&nbsp;</td>
			</tr>
		</table>
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
		        <asp:Localize runat='server' ID='lclAjudaGravar'> <b>Gravar:</b> Grava as altera&ccedil;&otilde;es efetuadas no banco. </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'> <b>Apagar:</b> Apaga o registro atual. </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'> <b>Novo:</b> Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es. </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'> <b>Voltar:</b> Volta para o menu anterior. </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

