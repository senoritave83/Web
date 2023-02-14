<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="VisitaProduto.aspx.vb" Inherits="Pages.Visita.VisitaProduto" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ImageRotator.ascx" tagname="ImageRotator" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
        <script type="text/javascript" language="javascript">

            function showMessage() {
                alert('Aten��o ! Alterando o produto para \"N�o Pesquisado\" ou \"N�o Encontrado\" as respostas das perguntas abaixo ser�o eliminadas.');
            }

            function verificar() {
                var vRet = false;
                if (confirm('Aten��o ! Alterando o produto para \"N�o Pesquisado\" ou \"N�o Encontrado\" as respostas das perguntas abaixo ser�o eliminadas.\n Deseja continuar ?')) {
                    vRet = true;
                }
                return vRet;
            }

           //function NVisualiza() {
          // alert('Aten�ao! Alterando o produto para \N�o\ as respostas das perguntas abaixo serao eliminadas');
          // }
            function VerificaCampos() {
                var MyColumn = document.getElementById('<%=cboVisualizouEstoque.ClientID%>');

                if (MyColumn.value == "0") {
                    alert('Aten�ao! Alterando o campo !VISUALIZOU ESTOQUE! para !N�O! o campo !ESTOQUE! abaixo ficar� inativo e sera modificado para ZERO');
                   } 
                }

        </script>

        <asp:UpdatePanel runat='server' ID='pnlCadastro'>
            <ContentTemplate>
		        <table id='tblEditArea'>
			        <tr class="trEditHeader">
			            <td colspan='2'>&nbsp;</td>
			        </tr>
			        <tr class='trEditSpace'>
			            <td colspan='2'>&nbsp;</td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoIDLoja'>
						        Loja:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblLoja' />
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoIDPromotor'>
						        Usu�rio:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblPromotor' />
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label3'>
						        <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal>:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblSegmento'>-</asp:Label>
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label5'>
						        <asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal>:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblCategoria'>-</asp:Label>
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label1'>
						        <asp:Literal ID="Literal3" runat="server" Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal>:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblProduto'>-</asp:Label>
				        </td>
			        </tr>
                    <tr id='trJustificativaRuptura' runat="server" class='trField' visible="false">
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label6'>
						        Justificativa de Ruptura:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblJustificativaRuptura'>-</asp:Label>
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label2'>
						        Pesquisado:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:DropDownList runat='server' ID='cboPesquisado' AutoPostBack='true'>
				                <asp:ListItem Value='0' Text='N&atilde;o' />
				                <asp:ListItem Value='1' Text='Sim' />
				            </asp:DropDownList>
				        </td>
			        </tr>
			        <asp:PlaceHolder runat='server' ID='plhPainel'>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoEncontrado'>
						        Encontrado:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:DropDownList runat='server' ID='cboEncontrado' AutoPostBack='true'>
				                <asp:ListItem Value='0' Text='N&atilde;o' />
				                <asp:ListItem Value='1' Text='Sim' />
				            </asp:DropDownList>
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoPreco'>
						        Pre&ccedil;o:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblHidePreco' Visible='false'>-</asp:Label>
					        <asp:TextBox runat='server' ID='txtPreco' />
					        <asp:CompareValidator runat='server'  ID='valCompPreco' Display='None' ErrorMessage='Pre&ccedil;o inv&aacute;lido' ControlToValidate='txtPreco' Operator='DataTypeCheck' Type='Currency' />
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoVisualizouEstoque'>
						        Visualizou Estoque:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblHideVisualizouEstoque' Visible='false'>-</asp:Label>
				            <asp:DropDownList runat='server' ID='cboVisualizouEstoque' AutoPostBack='true'>
				                <asp:ListItem Value='0' Text='N&atilde;o'  />
				                <asp:ListItem Value='1' Text='Sim' />
				                <asp:ListItem Value='2' Text='N&atilde;o permitido' />
				            </asp:DropDownList>
				        </td>
			        </tr>
			        <tr class='trField' ID='trEstoque' runat='server'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoEstoque'>
						        Estoque:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
				            <asp:Label runat='server' ID='lblHideEstoque' Visible='false'>-</asp:Label>
					        <asp:TextBox runat='server' ID='txtEstoque' />
					        <asp:CompareValidator runat='server'  ID='valCompEstoque' Display='None' ErrorMessage='Estoque inv&aacute;lido' ControlToValidate='txtEstoque' Operator='DataTypeCheck' Type='Integer' />
				        </td>
			        </tr>
			        </asp:PlaceHolder>
			        <tr class="trEditFooter">
			            <td colspan=2>&nbsp;</td>
			        </tr>
		        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
	</div>
	<div id='AreaVisitaProduto'>
	    <asp:UpdatePanel runat='server' ID='pnlPerguntas' >
	        <ContentTemplate>
			    <div class='Filtro'>
				    <div class='FiltroItem'>
					    <asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					    <br>
					    <asp:TextBox Runat="server" ID='txtFiltro' />
				    </div> 
				    <div class='FiltroBotao'>
					    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				    </div>
			    </div>	
                <asp:GridView runat='server' ID='dtgPerguntas' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' AllowSorting='true'>
                    <HeaderStyle HorizontalAlign='Left' />
                    <Columns>
                        <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' />
                        <asp:TemplateField HeaderText='Resposta'>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
						<asp:HyperLinkField Visible="true" DataNavigateUrlFields="IDVisita,IDProduto,IDPergunta" DataNavigateUrlFormatString="VisitaProdutoResposta.aspx?IDVisita={0}&IDProduto={1}&IDPergunta={2}" Text='Visualizar' HeaderText="" SortExpression=""  />
                    </Columns>
                    <EmptyDataTemplate>
                        N&atilde;o h&aacute; perguntas respondidas para este produto!
                    </EmptyDataTemplate>
                </asp:GridView>
                <xm:Paginate ID="pagPerguntas" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel> 
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnEditar' Text="Editar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnGravar' OnClientClick="return verificar();" Text="Gravar" CssClass='Botao' />
           <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick='fncVoltar()' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar' Text="&lt;b&gt;Gravar:&lt;/b&gt;
				    Grava as altera&amp;ccedil;&amp;otilde;es efetuadas no banco.
		        "></asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar' Text="&lt;b&gt;Voltar:&lt;/b&gt; Volta para a tela de visita.
		        "></asp:Localize>
			</li>
	    </ul>
	    <script type='text/javascript'>
	        function fncVoltar(){
	            location.href='Visita.aspx?idvisita=<%=ViewState(VW_IDVISITA)%>';
	        }
            function fncImageClick(sender, e) {
                var wh = window.open(e.key, "images", "height=400, width=500");
            }
	    </script>
    </div>
</asp:Content>

