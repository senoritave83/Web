<%@ Page Language="VB" MasterPageFile="../XMPromotores.master" validateRequest="false" AutoEventWireup="false" CodeFile="Pergunta.aspx.vb" Inherits="Pages.Cadastros.Pergunta" title="XM Promotores - Yes Mobile" %>


<%@ Register src="../controls/Segmentacao.ascx" tagname="Segmentacao" tagprefix="uc1" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc2" %>

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
	<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="updEditArea" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image100" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel ID="updEditArea" runat="server">
        <ContentTemplate>
        <div class='EditArea'>
            <table id='tblEditArea' >
                <tr class='trField' id='trCodigo' runat='server'>
				    <td class='tdFieldHeader' style="width: 200px;">
					    &nbsp;&nbsp;<a>C&oacute;digo:</a>
				    </td>
				    <td class='tdField'>
					    <asp:Label runat='server' ID='lblCodigo' />
				    </td>
			    </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Pergunta:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPergunta' Width='90%' CssClass="formulario"  onKeyPress="return permitir_caractere(event);"/>
			            <asp:RequiredFieldValidator runat='server' ID='valReqPergunta' Display='None' ErrorMessage='Pergunta &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPergunta' />
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Descri&ccedil;&atilde;o no Relat&oacute;rio:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPerguntaRelatorio' Width='90%' CssClass="formulario" />
			            <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Descri&#231;&#227;o no Relat&#243;rio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPerguntaRelatorio' />
		            </td>
	            </tr>
                <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Prioridade:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtPrioridade' Width='81px' CssClass="formulario" />
			            <asp:RequiredFieldValidator runat='server' ID='ValReqPrioridade' Display='None' ErrorMessage='Prioridade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrioridade' />
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px;">
			            Tipo de Campo:
		            </td>
		            <td class='tdField'>
                        <asp:Label runat="server" ID="lblTipoCampo" Visible="false"></asp:Label>
                        <asp:HiddenField runat="server" ID="hidTipoCampo" Value="0" />
		                <asp:DropDownList runat='server' ID='cboTipoCampo' CssClass="Select" Height="23px" AutoPostBack="true">
		                    <asp:ListItem Value='0'>Sele&ccedil;&atilde;o</asp:ListItem>
		                    <asp:ListItem Value='1'>Num&eacute;rico</asp:ListItem>
		                    <asp:ListItem Value='2'>Foto</asp:ListItem>
                            <asp:ListItem Value='3'>Data</asp:ListItem>
                            <asp:ListItem Value='4'>Decimal</asp:ListItem>
                            <asp:ListItem Value='5'>Alfa-Num&eacute;rico</asp:ListItem>
                            <asp:ListItem Value='6'>C&oacute;digo de Barras</asp:ListItem>

		                </asp:DropDownList>
		            </td>
	            </tr>           
                <tr class='trField' id='trMinimo' runat="server">
		            <td class='tdFieldHeader' style="width:200px;">
			            M&iacute;nimo:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtMinimo' Width='81px' MaxLength='10' CssClass="formulario" />
                        <asp:CompareValidator runat='server' ID='compValMinimo' Display="Dynamic" SetFocusOnError="true" ErrorMessage='Digite corretamente o M&iacute;nimo!' Type='Double' ControlToValidate='txtMinimo' />
		            </td>
	            </tr>            
                <tr class='trField' id='trMaximo' runat="server">
		            <td class='tdFieldHeader' style="width:200px;">
			            M&aacute;ximo:
		            </td>
		            <td class='tdField'>
			            <asp:TextBox runat='server' ID='txtMaximo' Width='81px' MaxLength='10' CssClass="formulario" />
                        <asp:CompareValidator runat='server' ID='compValMaximo' Display="Dynamic" SetFocusOnError="true" ErrorMessage='Digite corretamente o M&aacute;ximo!' Type='Double' ControlToValidate='txtMaximo' />
		            </td>
	            </tr>
	            <tr class='trField' id='trTiporesposta' runat="server">
		            <td class='tdFieldHeader' style="width:200px;">
			            Tipo de Resposta:
		            </td>
		            <td class='tdField'>
                        <asp:Label runat="server" ID="lblMultiResposta" Visible="false"></asp:Label>
		                <asp:DropDownList runat='server' ID='cboMultiResposta' AutoPostBack="true" CssClass="Select" Height="23px">
		                    <asp:ListItem Value='0'>Alternativa &uacute;nica</asp:ListItem>
		                    <asp:ListItem Value='1'>M&uacute;ltiplas alternativas</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td valign="top" class='tdFieldHeader' style="width:200px;">
			            Fazer a pergunta:
		            </td>
		            <td class='tdField'>
                        <asp:Label runat="server" ID="lblPerguntaLoja" Visible="false"></asp:Label>
		                <asp:DropDownList runat='server' ID='cboPerguntaLoja' CssClass="Select" Height="23px">
		                    <asp:ListItem Value='1'>Itens est�o no code-behind</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' style="width:200px; height: 25px;">
			            Pergunta ativa:
		            </td>
		            <td style="height: 25px">
		                <asp:CheckBox runat='server' ID='chkAtivo' />
		            </td>
	            </tr>
	            <tr class='trField' id='tblPerguntaCondicional' runat="server">
		            <td class='tdFieldHeader' style="width:200px;">
			            Pergunta Condicional:
		            </td>
		            <td class='tdField'>
		                <asp:DropDownList AutoPostBack="true" runat='server' ID='cboCondicional'  CssClass="Select" Height="23px">
		                    <asp:ListItem Value='0'>N&atilde;o</asp:ListItem>
		                    <asp:ListItem Value='1'>Sim</asp:ListItem>
		                </asp:DropDownList>
		            </td>
	            </tr>           
	            <tr class='trField' id='tblCondicional' runat="server" style='<%=IIF(cls.Condicional, "display:inline;", "display:none;") %>'>
		            <td class='tdFieldHeader' style="width:200px; vertical-align:top; padding-top:8px;">
                        Exibir quando a pergunta:
                    </td>
		            <td class='tdField'>
		                <div class='fl'>
                            <table width="100%">
                                <tr>
                                    <td colspan='3' style="height: 26px">
                                        <asp:DropDownList runat='server' ID='cboIDPerguntaDependente' DataTextField='Pergunta' DataValueField='IDPergunta' CssClass="Select" Height="23px" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="20">for</td>
                                    <td width="100"><asp:DropDownList AutoPostBack="true"  runat='server' ID='cboIDTipoDependencia' CssClass="Select" Height="23px">
                                            <asp:ListItem Value='0'>indiferente</asp:ListItem>
                                            <asp:ListItem Value='1'>Igual</asp:ListItem>
                                            <asp:ListItem Value='2'>Diferente</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <div id="tblCondicaoResposta" runat="server" >
                                            <span id="lblPreposicao" runat="server">Que</span>
                                            <asp:TextBox runat='server' ID='txtValorDependencia' CssClass="formulario"  Width="85%" />
                                        </div>
                                    </td>  
                                </tr>
                            </table>
		                </div>
	                </td>
	            </tr>
            </table>
        </div>
        <br class='cb' />
        <div class='AreaBotoes'>
            <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
            <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
            <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pergunta.aspx?idpergunta=0'" />
            <input type="button" class="Botao" value=" Voltar " onclick="location.href='Perguntas.aspx'" />
        </div>
        <div id='AreaRespostasPergunta' style="width:94%;">
            <asp:GridView runat='server' id='grdRespostas' AutoGenerateColumns='False' SkinID='GridInterno' Width='100%'>
                <columns>
                    <asp:BoundField HeaderText='' DataField='IDResposta'  ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='Left'/>
                    <asp:TemplateField HeaderText="Resposta" ItemStyle-HorizontalAlign='Left' HeaderStyle-HorizontalAlign='Left'>
                        <ItemTemplate>
                            <asp:TextBox runat='server' ID='txtResposta' Text='<%# Eval("Resposta")%>' Width='100%' MaxLength="200" onKeyPress="return permitir_caractere(event);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exclusiva" ItemStyle-HorizontalAlign='Center'>
                        <ItemTemplate>
                            <input type="checkbox" runat="server" id="chkRespostaUnica" name='chkRespostaUnica' onclick='fncCheckboxClicked(this)' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='A&ccedil;&atilde;o condicional' ItemStyle-Width='410px'>
                        <ItemTemplate>
                            <table id='tblCondicaoResposta_<%# Eval("IDResposta")%>' style="<%# IIF(cls.Condicional, "display:inline;", "display:none;") %>">
                                <tr>
                                    <td style="width:100px">
                                        <asp:DropDownList runat='server' ID='cboAcao' style="width:100px;">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:300px;">
                                        <div id='divAcaoPergunta_<%# Eval("IDResposta")%>' style='<%# iif(Eval("Acao") = 1, "display:inline;", "display:none;")%>'>
                                            <asp:DropDownList runat='server' ID='cboIDPerguntaPular' DataTextField='Pergunta' DataValueField='IDPergunta' style="width:300px;">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
                <EmptyDataTemplate>
                    N&atilde;o h&aacute; op&ccedil;&otilde;es de respostas cadastradas
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGravar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        <script language="javascript" type="text/javascript">

            function fncCheckboxClicked(vCheckbox) {
                $("[id$='chkRespostaUnica']").each(function () {
                    if (this.value != vCheckbox.value) {
                        this.checked = false;
                    }
                });
            }

        /*
            function fncChangeMultiplo(vMulti) {$('*[name="RespostaUnica"]').each(function (i) {this.disabled =  !vMulti;});}
            
            function fncChangeTipo(vSelection)
            {
                return;
                var max_min = true; //<%= SettingsExpression.GetProperty("visible", "Pergunta.MinMax", "true") %>;
                var ctrls = document.getElementsByTagName("input");
                var vDisabled = document.getElementById('<%=btnGravar.ClientID %>').disabled;
                alert($('<%=trMaximo.ClientID%>'))
                $('<%=trMaximo.ClientID%>').hide();
                $('<%=trMinimo.ClientID%>').hide();
                if (vSelection) {
                    $('input[id$="_txtResposta"]').css("background-color", "white");
                    $('input[id$="_txtResposta"]').removeAttr("disabled");
                    $(trTiporesposta).show();
                    fncChangeMultiplo($("#<%=cboMultiResposta.ClientID%>").selectedIndex == 1);
                } else  {
                    $('input[id$="_txtResposta"]').css("background-color", "gainsboro");
                    $('input[id$="_txtResposta"]').attr("disabled", "true");
                    $(trTiporesposta).hide();
                    fncChangeMultiplo(false);
                    if(max_min==true) {
                        var cbo = $('#<%=lblTipoCampo.ClientID%>');
                        if (cbo.value == 1 || cbo.value == 4) {
                            $('<%=trMaximo.ClientID%>').show();
                            $('<%=trMinimo.ClientID%>').show();
                        }
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

             function fncChangeCondicional(source)
            {
                if (source.selectedIndex == 1) {
                    //$('tr[id^="tblCondicaoResposta_"]').show();
                    $('#tblCondicaoResposta').show();
                    $('#tblCondicional').show();
                } else {
                    //$('tr[id^="tblCondicaoResposta_"]').hide();
                    $('#tblCondicaoResposta').hide();
                    $('#tblCondicional').hide();
                }
            }

                        
            function fncChangeDependencia(source)
            {
                if (source.selectedIndex == 0) {
                    $('#tblCondicaoResposta').hide();
                }
                else if (source.selectedIndex == 1) {
                    $('#tblCondicaoResposta').show();
                    $('#lblPreposicao').html('a');
                }
                 else {
                     $('#tblCondicaoResposta').show();
                     $('#lblPreposicao').html('de');
                }
            }

                        function fncChangeAcao(source, idresposta)
            {
             if (source.options[source.selectedIndex].value == 1)
                 {$('#divAcaoPergunta_' + idresposta).show();}
                 else 
                 {$('#divAcaoPergunta_' + idresposta).hide();}
             }


            */


        </script>
 
    <br class='cb' />
    <uc1:Segmentacao ID="Segmentacao1" runat="server">
        <Title>Exibir a pergunta para a seguinte segmenta&ccedil;&atilde;o</Title>
        <EmptyDataText>
             N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada para essa pergunta!
        </EmptyDataText>
    </uc1:Segmentacao>
	    <uc2:Localizacao ID="Localizacao1" runat="server">
	        <Title>Exibir a pergunta para os seguintes crit&eacute;rios de lojas:</Title>
	        <EmptyDataText>N&atilde;o h&aacute; crit&eacute;rios de lojas cadastradas para essa pergunta!</EmptyDataText>
	    </uc2:Localizacao>  
    <div id='divErros' style="padding-left:21px;">
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
        /*
        fncChangeTipo(document.getElementById('<%=hidTipoCampo.ClientID%>').value == 0);
        */
    </script>
</asp:Content>

