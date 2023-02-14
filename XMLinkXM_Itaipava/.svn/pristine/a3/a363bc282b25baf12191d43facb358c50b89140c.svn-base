<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="Untitled Page" %>
<%@ Register src="../controls/ImageRotator.ascx" tagname="ImageRotator" tagprefix="uc3" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Literal ID="ltrAlert" Text="" runat="server" />
    <asp:ScriptManager runat='server' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trDescricao' visible='<%$Settings: visible, Produto.Descricao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Descricao:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='40' Width="400" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Enabled='<%$Settings: Required, Produto.Descricao, true %>' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<asp:UpdatePanel runat='server' ID='updEmbalagem'>
			    <ContentTemplate>
			        <div class='trField cb' runat='server'  id='trTipo' visible='<%$Settings: visible, Produto.Tipo, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Tipo:
				        </div>
				        <div class='tdField fl'>
					        <asp:DropDownList runat='server' ID='cboTipo' AutoPostBack='true'>
					            <asp:ListItem Value=''></asp:ListItem>
					            <asp:ListItem Value='P'>P - Produto unit&aacute;rio</asp:ListItem>
					            <asp:ListItem Value='E'>E - Embalagem</asp:ListItem>
					        </asp:DropDownList>
					        <asp:RequiredFieldValidator runat='server' ID='valReqTipo' Enabled='<%$Settings: Required, Produto.Tipo, false %>' Display='None' ErrorMessage='Tipo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboTipo' />
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='trEmbalagem' visible='<%$Settings: visible, Produto.Embalagem, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Qtd Embalagem:
				        </div>
				        <div class='tdField fl'>
					        <asp:TextBox runat='server' ID='txtEmbalagem' />
					        <asp:RequiredFieldValidator runat='server' ID='valReqEmbalagem' Enabled='<%$Settings: Required, Produto.Embalagem, false %>' Display='None' ErrorMessage='Embalagem &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmbalagem' />
					        <asp:CompareValidator runat='server'  ID='valCompEmbalagem' Display='None' ErrorMessage='Embalagem inv&aacute;lida' ControlToValidate='txtEmbalagem' Operator='DataTypeCheck' Type='Integer' />
				        </div>
			        </div>
			    </ContentTemplate>
			</asp:UpdatePanel>
			<div class='trField cb' runat='server'  id='trIDCategoria' visible='<%$Settings: visible, Produto.IDCategoria, true %>' >
				<div class='tdFieldHeader cb fl'>
					Categoria:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDCategoria' Display='None' ErrorMessage='Categoria &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDCategoria' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trLinha' visible='<%$Settings: visible, Produto.Linha, true %>' >
				<div class='tdFieldHeader cb fl'>
					Linha:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDLinha" DataTextField="Linha" DataValueField="IDLinha" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Linha do produto &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDLinha' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='divBonificacao'>
				<div class='tdFieldHeader cb fl'>
					Bonifica&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox ID='chkBonificacao' runat='server' Text='Permite Bonificação' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Produto.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
                  	<asp:Label runat='server' ID='lblCriado' />
			   </div>
             </div> 
             <div class='trField cb' runat='server'  id='trImagem'>
				<div class='tdField fl'>
				   <div class="GridHeader"   >
					Imagens :
				    <uc3:ImageRotator ID="imgRotatorLoja" runat="server" Width='200' />
				</div>
              </div>
             </div>
			
                                       
                             
		</div>
	</div>
	<div class='ListArea'>
	    <asp:Repeater runat='server' ID='rptTransacao'>
	        <HeaderTemplate>
	            <table width='100%'>
	                <tr class="GridHeader" align=center>
	                    <td>Tipo de Pedido</td>
	                    <td>Transa&ccedil;&atilde;o</td>
	                </tr>
	        </HeaderTemplate>
	        <ItemTemplate>
	                <tr>
	                    <td><%#Eval("TipoPedido")%></td>
	                    <td>
	                        <asp:HiddenField runat='server' ID='hidIDTipoPedido' Value='<%#Eval("IDTipoPedido")%>' />
	                        <asp:TextBox runat='server' ID='txtTransacao' Value='<%#Eval("Transacao")%>' />
	                        <asp:CompareValidator runat='server' ID='valTransacao' ControlToValidate='txtTransacao' ErrorMessage='Código de transação inválido' Operator='DataTypeCheck' Type='Integer'></asp:CompareValidator>
	                    </td>
	                </tr>
	        </ItemTemplate>
	        <FooterTemplate>
	            </table>
	        </FooterTemplate>
	    </asp:Repeater>
	</div>
    <br />
    <div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='grdTabelaProduto' 
                AutoGenerateColumns='false' 
                DataKeyNames="IdTabela"
                OnRowEditing="grdTabelaProduto_RowEditing"
                OnRowUpdating="grdTabelaProduto_RowUpdating"
                OnRowCancelingEdit="grdTabelaProduto_RowCancelingEdit"
                AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
                        <asp:BoundField ReadOnly="true" ItemStyle-Width="150" HeaderText="Cod Tabela" DataField="IdTabela" SortExpression="IdTabela" />
                        <asp:BoundField ReadOnly="true" HeaderText="Tabela" DataField="Tabela" SortExpression="Tabela" />
                        <asp:BoundField ReadOnly="true" HeaderText="Preço" DataField="Preco" SortExpression="Preco" />
                        <asp:BoundField ReadOnly="true" HeaderText="Preço Base" DataField="PrecoBase" SortExpression="PrecoBase" />
                        <asp:TemplateField HeaderText="Quantidade Mínima" ItemStyle-Width="150">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtQuantidadeMinima" Text='<%#EVal("QuantidadeMinima") %>'></asp:TextBox>
                                <asp:CompareValidator ControlToValidate="txtQuantidadeMinima" runat="server" ID="compQuantidadeMinima" Type="Integer" ValueToCompare="0" Display="None" Operator="GreaterThanEqual" ErrorMessage="Quantidade incorreta. Digite a quantidade mínima desejada ou zero para excluir a quantidade." ></asp:CompareValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%#EVal("QuantidadeMinima") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowCancelButton="true" ShowEditButton="true" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o existem tabelas para o produto.
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <div class='trField cb' runat='server'  id='Div1'>
				    <div class='tdFieldHeader cb fl'>
					    Hist&oacute;rico:
				    </div>
				    <div class='tdField fl'>
	                    <asp:GridView runat='server' ID='grdHistorico' AutoGenerateColumns='false' SkinID='GridHistorico'>
	                        <Columns>
	                            <asp:TemplateField>
	                                <ItemTemplate>
	                                    <%# Eval("Data") %> - <%#Eval("Historico")%>
	                                </ItemTemplate>
	                            </asp:TemplateField>
	                        </Columns>
	                    </asp:GridView>
				    </div>
			    </div>	
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <br class="cb" />
    <div class='ListArea'>
	    <asp:GridView runat='server' ID='grdFamilias' AutoGenerateColumns='false'>
	        <Columns>
	            <asp:TemplateField HeaderText="Produto pertence às seguintes famílias" HeaderStyle-HorizontalAlign="Left">
	                <ItemTemplate>
	                    <%# Eval("Familia")%>
	                </ItemTemplate>
	            </asp:TemplateField>
	        </Columns>
	    </asp:GridView>
    </div>
    <br class="cb" />
    <br class="cb" />
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
    <script type='text/javascript'>
        function fncImageClick(sender, e) {
            var wh = window.open(e.key, "images", "height=200, width=300");
        }
    </script>
</asp:Content>
