<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" validateRequest="false" AutoEventWireup="false" CodeFile="Pergunta.aspx.vb" Inherits="Pages.Cadastros.Pergunta" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript">
    function permitir_caractere(e, args) {
        if (document.all) { var evt = event.keyCode; } // caso seja IE
        else { var evt = e.charCode; } 	// do contrário deve ser Mozilla
        var valid_chars = '0123456789abcdefghijlmnopqrstuvxzwykABCDEFGHIJLMNOPQRSTUVXZWYK-_/^~´`@.ãéúêô()¨%$#!+{}[]?|"' + args;      // criando a lista de teclas permitidas
        var chr = String.fromCharCode(evt);      // pegando a tecla digitada
        if (valid_chars.indexOf(chr) > -1) { return true; } // se a tecla estiver na lista de permissão permite-a
        // para permitir teclas como <BACKSPACE> adicionamos uma permissão para 
        // códigos de tecla menores que 09 por exemplo (geralmente uso menores que 20)
        if (valid_chars.indexOf(chr) > -1 || evt < 20) { return true; }
        if (valid_chars.indexOf(chr) > 30 || evt < 35) { return true; } //permite a tecla espaço
        return false;
        alert("caractere invalido!");
        // do contrário nega
    }
</script>

	<asp:ScriptManager runat='server' ID='ScriptManager1' />
    <div class='EditArea'>
    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="updEditArea" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image100" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel ID="updEditArea" runat="server">
        <ContentTemplate>
            <table id='tblEditArea'>
			    <tr class="trEditHeader">
			        <td colspan='2'>&nbsp;</td>
			    </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Pergunta:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPergunta' Width='100%' onKeyPress="return permitir_caractere(event);" />
			            <asp:RequiredFieldValidator runat='server' ID='valReqPergunta' Display='None' ErrorMessage='Pergunta &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPergunta' />
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Descrição no Relatório:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPerguntaRelatorio' Width='100%' />
			            <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Descri&#231;&#227;o no Relat&#243;rio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPerguntaRelatorio' />
		            </td>
	            </tr>
                <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Prioridade:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPrioridade' Width='81px' />
			            <asp:RequiredFieldValidator runat='server' ID='ValReqPrioridade' Display='None' ErrorMessage='Prioridade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrioridade' />
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Tipo de Campo:
		            </td>
		            <td class='tdField'>
		                <asp:DropDownList runat='server' ID='cboTipoCampo' onChange='fncChangeTipo(this.selectedIndex == 0)'>
		                    <asp:ListItem Value='0'>Sele&ccedil;&atilde;o</asp:ListItem>
		                    <asp:ListItem Value='1'>Num&eacute;rico</asp:ListItem>
		                    <asp:ListItem Value='2'>Foto</asp:ListItem>
                            <asp:ListItem Value='3'>Data</asp:ListItem>
                            <asp:ListItem Value='4'>Decimal</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>           
                <tr class='trField' id='trMinimo' style="display:none;">
		            <td class='tdFieldHeader' style="width:200px;">
			            M&iacute;nimo:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtMinimo' Width='81px' MaxLength='10' />
                        <asp:CompareValidator runat='server' ID='compValMinimo' Display="Dynamic" SetFocusOnError="true" ErrorMessage='Digite corretamente o M&iacute;nimo!' Type='Double' ControlToValidate='txtMinimo' />
		            </td>
	            </tr>            
                <tr class='trField' id='trMaximo' style="display:none;">
		            <td class='tdFieldHeader' style="width:200px;">
			            M&aacute;ximo:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtMaximo' Width='81px' MaxLength='10' />
                        <asp:CompareValidator runat='server' ID='compValMaximo' Display="Dynamic" SetFocusOnError="true" ErrorMessage='Digite corretamente o M&aacute;ximo!' Type='Double' ControlToValidate='txtMaximo' />
		            </td>
	            </tr>
	            <tr class='trField' id='trTiporesposta'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Tipo de Resposta:
		            </td>
		            <td class='tdField'>
		                <asp:DropDownList runat='server' ID='cboMultiResposta' onChange='fncChangeMultiplo(this.selectedIndex == 1)'>
		                    <asp:ListItem Value='0'>Alternativa &uacute;nica</asp:ListItem>
		                    <asp:ListItem Value='1'>M&uacute;ltiplas alternativas</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Fazer a pergunta:
		            </td>
		            <td class='tdField'>
		                <asp:DropDownList runat='server' ID='cboPerguntaLoja'>
		                    <asp:ListItem Value='0'>No Produto</asp:ListItem>
		                    <asp:ListItem Value='1'>Na Loja</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Pergunta ativa:
		            </td>
		            <td class='tdField'>
		                <asp:CheckBox runat='server' ID='chkAtivo' />
		            </td>
	            </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGravar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        <script language="javascript" type="text/javascript">
            function fncChangeMultiplo(vMulti)
            {
                var ctrls = document.getElementsByName("RespostaUnica");
                for (var i = 0; i < ctrls.length; i++)
                {
                    ctrls[i].disabled = !vMulti;
                }
            }
            
            function fncChangeTipo(vSelection)
            {

                var max_min = <%= SettingsExpression.GetProperty("visible", "Pergunta.MinMax", "false") %>;
                var ctrls = document.getElementsByTagName("input");
                for (var i = 0; i < ctrls.length; i++)
                {
                    var vID = ctrls[i].id;
                    if (Right(vID, 12) == '_txtResposta')
                    {
                        ctrls[i].disabled = !vSelection;
                        if (vSelection) 
                        {
                        ctrls[i].style.backgroundColor = 'white';
                        }
                        else
                        {
                        ctrls[i].style.backgroundColor = 'gainsboro';
                        }
                    }
                }
                if (vSelection) 
                {
                    
                    var cbo = document.getElementById('<%=cboMultiResposta.ClientID%>');
                    fncChangeMultiplo(cbo.selectedIndex == 1);
                    trTiporesposta.style.display='inline';
                    trMaximo.style.display='none';
                    trMinimo.style.display='none';

                }
                else
                {

                    fncChangeMultiplo(false);
                    trTiporesposta.style.display='none';

                    if(max_min==true)
                    {
                        var cbo = document.getElementById('<%=cboTipoCampo.ClientID%>');
                        if(cbo.selectedIndex == 1 || cbo.selectedIndex == 4)
                        {
                            trMaximo.style.display='inline';
                            trMinimo.style.display='inline';
                        }
                        else
                        {
                            trMaximo.style.display='none';
                            trMinimo.style.display='none';
                        }
                    }
                    else
                    {
                        trMaximo.style.display='none';
                        trMinimo.style.display='none';
                    }

                }

            }
            
            
            
            function fncCheckboxClicked(vCheckbox)
            {
                if (vCheckbox.checked)
                {
                    var ctrls = document.getElementsByName("RespostaUnica");
                    for (var i = 0; i < ctrls.length; i++)
                    {
                        if (ctrls[i].value != vCheckbox.value)
                        {
                            ctrls[i].checked = false;
                        }
                    }
                }
            }
            
            
        </script>
    </div>
    <div id='AreaRespostasPergunta'>
        <asp:GridView runat='server' id='grdRespostas' AutoGenerateColumns='False' SkinID='GridInterno' Width='100%'>
            <columns>
                <asp:BoundField HeaderText='' DataField='IDResposta'  ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='Left' />
                <asp:TemplateField HeaderText="Resposta" ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='Left'>
                    <ItemTemplate>
                        <asp:TextBox runat='server' ID='txtResposta' Text='<%# Eval("Resposta")%>' Width='100%' MaxLength=200  onKeyPress="return permitir_caractere(event);"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exclusiva" ItemStyle-HorizontalAlign='Center'>
                    <ItemTemplate>
                        <input type="checkbox" onclick='fncCheckboxClicked(this)' name='RespostaUnica' value='<%# Eval("IDResposta")%>' <%# IIF(cboMultiResposta.selectedIndex <> 1, "disabled", "")%> <%# IIF(Eval("Unica"), "checked", "")%> />
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
            <EmptyDataTemplate>
                N&atilde;o h&aacute; op&ccedil;&otilde;es de respostas cadastradas
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div id='AreaProdutoPergunta'>
        <asp:Panel runat='server' ID='pnlSegmentacao'>
            <asp:UpdatePanel runat='server' ID='pnlUpdate'>
                <ContentTemplate>
                    <h4>Exibir a pergunta para a seguinte segmenta&ccedil;&atilde;o:</h4>
                    <table id='Table2' width='100%'>
			                <tr class='trField'>
				                <td colspan='2' width='100%'>
					                <asp:RadioButtonList CellPadding='0' CellSpacing='0' runat="server" ID='rdTipoBusCaProduto' RepeatDirection='Horizontal' AutoPostBack='true'>
                                        <asp:ListItem Text="Marca" Value='Marca'></asp:ListItem>
                                        <asp:ListItem Text="Segmento" Value='Segmento' Selected='True'></asp:ListItem>
                                        <asp:ListItem Text="Categoria" Value='Categoria'></asp:ListItem>
                                        <asp:ListItem Text="Produto" Value='Produto'></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                        </ProgressTemplate>
                                    </asp:UpdateProgress> 
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='80%'>
                                    <asp:DropDownList runat='server' ID='drpBuscaMarca' AutoPostBack="true" Visible='false'>
			                            <asp:ListItem Value='1'>Propria</asp:ListItem>
			                            <asp:ListItem Value='2'>Concorrente</asp:ListItem>
			                        </asp:DropDownList>
					                <asp:TextBox runat="server" ID='txtBuscaProduto' Width='100%'></asp:TextBox>
				                </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscarProdutos' Text='Buscar' class='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                    <div class='ListaItens'>
                        <asp:GridView runat='server' ID='grdSegmentacao' Width='95%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDSegmentacao'>
                            <HeaderStyle HorizontalAlign='Left' />
                            <Columns>
                                <asp:BoundField DataField='Concorrente' HeaderText='Marca' />
                                <asp:BoundField DataField='Categoria' HeaderText='Segmentos' />
                                <asp:BoundField DataField='SubCategoria' HeaderText='Categorias' />
                                <asp:BoundField DataField='Produto' HeaderText='Produto' />
                                <asp:ButtonField  CommandName='RetirarProduto' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada para essa pergunta!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <div id='AdicionarProdutoPergunta'>
	                    <table id='tblProduto'>
		                    <tr class='trField'>
			                    <td>
				                    <h4>Adicionar um novo produto</h4>
			                    </td>
		                    </tr>
		                    <tr class='trField'>
			                    <td class='tdField'>
				                    Marca:<br />
			                        <asp:DropDownList runat='server' ID='cboConcorrente' AutoPostBack="true">
			                            <asp:ListItem Value='0' Selected='True'>Todas</asp:ListItem>
			                            <asp:ListItem Value='1'>Propria</asp:ListItem>
			                            <asp:ListItem Value='2'>Concorrente</asp:ListItem>
			                        </asp:DropDownList>
			                    </td>
                            </tr>
                            <tr class='trField'>
			                    <td class='tdField'>
				                    Segmento:<br />
			                        <asp:DropDownList runat='server' ID='cboCategoria' DataTextField='Categoria' DataValueField='IDCategoria' AutoPostBack="true" /> 
			                    </td>
                            </tr>
                            <tr class='trField'>
			                    <td class='tdField'>
				                    Categoria:<br />
			                        <asp:DropDownList runat='server' ID='cboSubCategoria' DataTextField='SubCategoria' DataValueField='IDSubCategoria' AutoPostBack="true" /> 
			                    </td>
                            </tr>
                            <tr class='trField'>
			                    <td class='tdField'>
			                        Produto:<br />
			                        <asp:DropDownList runat='server' ID='cboProduto' DataTextField='Codigo' DataValueField='IDProduto' /> 
			                    </td>
		                    </tr>
		                    <tr>
		                        <td>
                                    <asp:Button runat='server' ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' />
		                        </td>
		                    </tr>
	                    </table>
                    </div>
                 </ContentTemplate> 
            </asp:UpdatePanel> 
        </asp:Panel>
    </div> 
    <br class='cb' />
    <div id='AreaLojaPergunta'>
        <asp:Panel runat='server' ID='pnlLojas'>
            <asp:UpdatePanel runat='server' ID='pnlSegmentos'>
                <ContentTemplate>
                    <h4>Exibir a pergunta para os seguintes crit&eacute;rios de lojas:</h4>
                    <table id='Table3' width='400'>
			                <tr class='trField'>
				                <td colspan='2' width='100%'>
					                <asp:RadioButtonList CellPadding='0' CellSpacing='0' runat="server" ID='tdTipoBuscaLoja' RepeatDirection='Horizontal'>
                                        <asp:ListItem Text="Bandeira" Value='Bandeira' Selected='True'></asp:ListItem>
                                        <asp:ListItem Text="Loja" Value='Loja'></asp:ListItem>
                                        <asp:ListItem Text="Cidade" Value='Cidade'></asp:ListItem>
                                        <asp:ListItem Text="UF" Value='UF'></asp:ListItem>
                                    </asp:RadioButtonList>
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='80%'>
					                <asp:TextBox runat="server" ID='txtBuscaLoja' Width='100%'></asp:TextBox>
				                </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscaLoja' Text='Buscar' class='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                    <div class='ListaItens'>
                        <asp:GridView runat='server' ID='grdLojas' Width='100%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDPerguntaLoja'>
                            <HeaderStyle HorizontalAlign='Left' />
                            <Columns>
                                <asp:BoundField DataField='UF' HeaderText='UF' />
                                <asp:BoundField DataField='Cidade' HeaderText='Cidade' />
                                <asp:BoundField DataField='Cliente' HeaderText='Bandeira' />
                                <asp:BoundField DataField='Loja' HeaderText='Loja' />
                                <asp:BoundField DataField='Regiao' HeaderText='Regiao' />
                                <asp:BoundField DataField='TipoLoja' HeaderText='<%$ Settings: caption, Loja.TipoLoja, "Tipo Loja" %>' />
                                <asp:ButtonField  CommandName='RetirarLoja' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; crit&eacute;ios de lojas cadastradas para essa pergunta!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div> 
                    <div id='AdicionarLojaPergunta'>
	                    <table id='Table1'>
		                    <tr class='trField'>
			                    <td colspan='3'>
				                    <h4>Adicionar um novo crit&eacute;rio</h4>
			                    </td>
		                    </tr>
		                    <tr class='trField'>
			                    <td class='tdField' width='20%'>
			                        UF:<br />
				                    <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" ValidationGroup='AdicionarSegmento' AutoPostBack=true />
			                    </td>
			                    <td class='tdField' width='30%'>
			                        Cidade:<br />
				                    <asp:TextBox runat='server' ID='txtCidade' MaxLength='100' CssClass='txtCidade' />
			                    </td>
			                    <td class='tdField'>
			                        Bandeira:<br />
				                    <asp:DropDownList runat="server" ID="cboIDCliente" DataTextField="Fantasia" DataValueField="IDCliente" AutoPostBack='True' />
			                    </td>
		                    </tr>
		                    <tr class='trField'>
			                    <td class='tdField'>
			                        Regi&atilde;o:<br />
				                    <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" AutoPostBack=true />
			                    </td>
			                    <td class='tdField'>
			                        <asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' />:<br />
				                    <asp:DropDownList runat="server" ID="cboIDTipoLoja" DataTextField="TipoLoja" DataValueField="IDTipoLoja" AutoPostBack=true />
			                    </td>
			                    <td class='tdField'>
			                        Loja:<br />
				                    <asp:DropDownList runat="server" ID="cboIDLoja" DataTextField='<%$Settings: CampoLoja, Pesquisa.SegmentoLoja, "Loja"%>' DataValueField="IDLoja" />
			                    </td>
		                    </tr>
		                    <tr>
		                        <td colspan='3'>
                                    <asp:Button runat='server' ID='btnAdicionarSegmento' Text='Adicionar sele&ccedil;&atilde;o' class='BotaoAdicionar' />
		                        </td>
		                    </tr>
	                    </table>
                    </div>
                 </ContentTemplate> 
            </asp:UpdatePanel> 
        </asp:Panel>
    </div> 
    <br class='cb' />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pergunta.aspx?idpergunta=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Perguntas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
    <script>
                fncChangeTipo(document.getElementById('<%=cboTipoCampo.ClientID%>').selectedIndex == 0);
    </script>
</asp:Content>

