<%@ Page Language="VB" AutoEventWireup="false" CodeFile="produtos.aspx.vb" Inherits="formulario_produtos" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script type="text/javascript" src="../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../js/functions.js"></script>
	<script type="text/javascript" src="../js/validations.js"></script>
    <script language='javascript' type='text/javascript'>

            function verificaUnica(obj, vUnico, campo){
                var vIDProduto = $('#' + campo.id).attr("idreferencia");

                if (vUnico > -1) {
                    if ($('#' + obj.id + ' input').eq(vUnico).is(":checked") == true) {
                        $('#' + obj.id + ' input').each(function (i) {
                            if (this.checked == true){
                                if (i!=vUnico){
                                    this.checked = false;
                                }
                            }
                        });
                    }
                }                
                fncVerificaStatus(vIDProduto);
            }
    
            function fncPerguntaRespondida(vIDReferencia, vIDPergunta){
            
                if ($('#divPergunta_' + vIDReferencia + '_' + vIDPergunta + ' div[idpergunta="' + vIDPergunta + '"]').attr("tipocampo") == "2") {
                    return true
                }
                
                var vResps = fncGetRespostasPergunta(vIDReferencia, vIDPergunta);
                if (vResps.length < 1) {
                    return false;
                }
                else if (vResps[0] == '') {
                    return false;
                }
                return true;
            }
            
            function fncGetVisualizouEstoque(vIDProduto) {
                return $('#cboVisualizouEstoque_' + vIDProduto).val();
            }

            function fncGetEncontrado(vIDProduto) {
                return $('#cboEncontrado_' + vIDProduto).val();
            }

	        function fncVerificaPreco(vIDProduto)
	        {
                var divPreco = document.getElementById("divPreco_" + vIDProduto);
                var txtPreco = divPreco.getElementsByTagName("input")[0];
                if (txtPreco.getAttribute("validar") == 'true' && verificaCampo(txtPreco) != '')
		        {
			        alert(verificaCampo(txtPreco));
			        txtPreco.focus();
		        }
            }
    
            function fncProdutoEncontrado(vIDProduto, value) {
                var iAcao = $('#tr_' + vIDProduto).attr('acao');
                if (value == 1) {
                    if ((iAcao & 2) != 0) {$('#divPreco_' + vIDProduto).show();}
                    if ((iAcao & 1) != 0) {$('#divVisualizouEstoque_' + vIDProduto).show(); }
                    if ((iAcao & 1) != 0) {
                        if (fncGetVisualizouEstoque(vIDProduto) == 1)  $('#divQuantidadeEstoque_' + vIDProduto).show(); 
                    }
                    if ((iAcao & 4) != 0) {$('div[id^="divPergunta_' + vIDProduto + '"]').show()}
                } else {
                    $('#divPreco_' + vIDProduto + ', #divVisualizouEstoque_' + vIDProduto + ', #divQuantidadeEstoque_' + vIDProduto + ', div[id^="divPergunta_' + vIDProduto + '"]').hide();
                }
                fncVerificaStatus(vIDProduto);
            }

            function fncVisualizouEstoque(vIDProduto, value) {
                var iAcao = $('#tr_' + vIDProduto).attr('acao');
                if (value == 1 && (iAcao & 1) != 0){
                    $('#divQuantidadeEstoque_' + vIDProduto).show();
                    $('#divQuantidadeEstoque_' + vIDProduto + ' input').attr('validar', 'true');
                    $('#divQuantidadeEstoque_' + vIDProduto + ' input').attr('obrigatorio', 'true');
                } else {
                    $('#divQuantidadeEstoque_' + vIDProduto).hide();
                    $('#divQuantidadeEstoque_' + vIDProduto + ' input').attr('validar', 'false');
                    $('#divQuantidadeEstoque_' + vIDProduto + ' input').attr('obrigatorio', 'false');
                }
                fncVerificaStatus(vIDProduto);
            }

            function fncClose(vIDCat, vIDSub, vIDFor) {
                window.opener.refresh(vIDCat, vIDSub, vIDFor);
                window.opener.focus();
                self.close();
            }
            
            function fncEsconderLimpar(selector){
                $(selector + ' input[type="text"]').val("");
                $(selector + ' input[type="checkbox"]').attr('checked', false);
                $(selector + ' select').attr("selectedIndex", 0);
                $(selector + ' select').val("");
                $(selector).hide();   
            }            

            function fncVerificaStatus(vIDProduto) {
                var tr = document.getElementById("tr_" + vIDProduto);
                var iAcao = $('#tr_' + vIDProduto).attr('acao');
                var encontrado = fncGetEncontrado(vIDProduto);
                var iPularPara = 0;
                var bCondicional = false;
                var vStatus = 'completo';

                if (encontrado == 1) {
                    if ((iAcao & 2) != 0) {
                        if ($('#divPreco_' + vIDProduto + ' input').attr('validar') == 'true' && verificaCampo($('#divPreco_' + vIDProduto + ' input').get(0)) != ''){
                            vStatus = "parcial";
                        }
                    }
                    if ((iAcao & 1) != 0 && vStatus == 'completo') {
                        var divEstoque = document.getElementById("divQuantidadeEstoque_" + vIDProduto);
                        var txtEstoque = divEstoque.getElementsByTagName("input")[0];
                        if (fncGetVisualizouEstoque(vIDProduto) || fncGetVisualizouEstoque(vIDProduto) == "") {
                            if ((txtEstoque.getAttribute("validar") == 'true' && verificaCampo(txtEstoque) != '') ||
                                (fncGetVisualizouEstoque(vIDProduto) == "")) {
                                vStatus = "parcial";
                            }
                        }
                    }

                    if ((iAcao & 4) != 0 && vStatus == 'completo') {
                        var sel = 'div[id^="divPergunta_' + vIDProduto + '_"]';
                        $(sel).each(function (i) {
                            if (bCondicional == false && $('#' + this.id + ' div').attr('condicional') == 1)
                                bCondicional = true;
                                
                            if (iPularPara > 0 && iPularPara==$('#' + this.id + ' div').attr("idpergunta")) 
                                {
                                    iPularPara = 0;
                                }
                            if (iPularPara == 0)
                                {
                                if (bCondicional == true && vStatus == "parcial"){
                                    fncEsconderLimpar('#' + this.id + ' div')
                                } else if ($('#' + this.id + ' div').attr('condicional') == 1){
                                    if ($('#' + this.id + ' div').attr('dependencia') != 0){
                                        var vResps = fncGetRespostasPergunta(vIDProduto, $('#' + this.id + ' div').attr("iddependente"));
                                        var bOk = false;
                                        for (var s = 0; s < vResps.length; s++)
                                        {
                                            if(vResps[s] == $('#' + this.id + ' div').attr('dependentevalor')) bOk = true;
                                        }
                                        if (bOk == false) {
                                            fncEsconderLimpar('#' + this.id + ' div')
                                        } else {
                                            $('#' + this.id + ' div').show();
                                            if (fncPerguntaRespondida(vIDProduto, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                                vStatus = "parcial";
                                            }
                                        }
                                    } else {
                                        if (fncPerguntaRespondida(vIDProduto, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                            vStatus = "parcial";
                                        }
                                    }
                                    iPularPara = fncVerificaPular(vIDProduto, $('#' + this.id + ' div').attr("idpergunta"));
                                    if (iPularPara != 0) {
                                        bCondicional =true;    
                                    }
                                } else {
                                    $('#' + this.id + ' div').show();         
                                    if (fncPerguntaRespondida(vIDProduto, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                        vStatus = "parcial";
                                    }
                                }
                             } else {
                                // Perguntas puladas
                                fncEsconderLimpar('#' + this.id + ' div')
                             }
                            
                        });
                    }
                }
                else if (encontrado == "") {
                    vStatus = 'não preenchido'
                }

                $('#status_' + vIDProduto).text(vStatus);
                if (vStatus == 'completo') {
                    $('#status_' + vIDProduto).css('color', 'green');
                    $('#status_' + vIDProduto).text('gravando...');
                    fncGravarItem(vIDProduto);                    
                }
                else {
                    $('#status_' + vIDProduto).css('color', 'red');
                }

            
            }

            function xmlencode(value) {
                return replace(replace(replace(replace(value, '<', '&lt;'), '"', '&quot;'), '&', '&amp;'),'>', '&gt;');
            }        

            function fncGravarItem(vIDProduto) {
                var tr = document.getElementById("tr_" + vIDProduto);
                var iAcao = tr.attributes["acao"].value;
                var vXML = '';
            
                vXML += '<?xml version="1.0" encoding="ISO-8859-1"?><xml>';
                vXML += '<prd id="' + vIDProduto + '" ';
                var bEncontrado = fncGetEncontrado(vIDProduto);
                vXML += 'encontrado="' + bEncontrado + '" '
                if ((iAcao & 2) != 0 && bEncontrado == 1) {
                    var divPreco = document.getElementById("divPreco_" + vIDProduto);
                    var txtPreco = divPreco.getElementsByTagName("input")[0];
                    vXML += 'preco="' + CFloat(txtPreco.value) + '" ';
                }
                if ((iAcao & 1) != 0 && bEncontrado == 1) {
                    var divEstoque = document.getElementById("divQuantidadeEstoque_" + vIDProduto);
                    var txtEstoque = divEstoque.getElementsByTagName("input")[0];
                    vXML += 'visualizouEstoque="' + fncGetVisualizouEstoque(vIDProduto) + '" ';
                    if (fncGetVisualizouEstoque(vIDProduto) == 1) {
                        vXML += 'estoque="' + txtEstoque.value + '" ';
                    }
                }
                vXML += '>';

                if ((iAcao & 4) != 0 && bEncontrado == 1) {
                    var divs = tr.getElementsByTagName("div");
                    var vname = 'divPergunta_' + vIDProduto + '_';
                    for (var i = 0; i < divs.length; i++) {
                        if (Left(divs[i].id, vname.length) == vname) {
                            var vIDPergunta = divs[i].id.substring(vname.length);
                            vXML += '<perg id="' + vIDPergunta + '">'
                            var vResp = fncGetRespostasPergunta(vIDProduto, vIDPergunta);
                            for (var j = 0; j < vResp.length; j++) {
                                vXML += '<resposta text="' + xmlencode(vResp[j]) + '" item="' + j + '" />';
                            }
                            vXML += '</perg>'
                        }
                    }
                }
                vXML += '</prd></xml>'
                var vIdentifier = document.getElementById('hidIdentifier').value;
                PageMethods.GravarXMLItem(vIdentifier, vIDProduto, vXML, OnSucceeded(vIDProduto), OnFailed);
            }

            function OnSucceeded(vIDProduto) {
                document.getElementById("status_" + vIDProduto).innerHTML = 'gravado';
            }

            function OnFailed(error) {
                // Alert user to the error.
                alert(error.get_message());
            }            

            function fncVerificaPular(vIDReferencia, vIDPergunta) {
                var selector = '#divPergunta_' + vIDReferencia + '_' + vIDPergunta + ' div[idpergunta="' + vIDPergunta + '"]';
                var divPerg = $(selector);
                var iRet = 0;
                if (divPerg.attr("tipocampo") == 0 && (divPerg.attr("tipo") == 'radio' || divPerg.attr("tipo") == 'list')) {
                    $(selector + ' input').each(function (i) {
                        if (this.checked && iRet == 0){
                            if ($('#' + this.id).parent().attr("acao") == '2'){
                                iRet = -1;
                            } else if ($('#' + this.id).parent().attr("acao") == '1'){
                                iRet = $('#' + this.id).parent().attr("acaovalor");
                            }
                        }
                    });
                } else if (divPerg.attr("tipocampo") == 0 && divPerg.attr("tipo") == 'combo') {
                    if ($(selector + ' select option:selected').attr("acao")=='1'){
                        return $(selector + ' select option:selected').attr("acaovalor");
                    } else if ($(selector + ' select option:selected').attr("acao")=='2'){
                        return -1; // encerrar
                    }
                } 
                return iRet;
            }            
 
            function fncGetRespostasPergunta(vIDProduto, vIDPergunta) {
                var vArr = new Array();
                var selector = '#divPergunta_' + vIDProduto + '_' + vIDPergunta + ' div[idpergunta="' + vIDPergunta + '"]';
                var divPerg = $(selector);
                if (divPerg.attr("tipocampo") == 1 || divPerg.attr("tipocampo") >= 3){
                    vArr[0] = $(selector + ' input').val();
                } else if (divPerg.attr("tipocampo") == 0 && (divPerg.attr("tipo") == 'radio' || divPerg.attr("tipo") == 'list')) {
                    $(selector + ' input').each(function (i) {
                        if (this.checked){
                            vArr[vArr.length] = $(selector + ' label[for="' + this.id + '"]').text();
                        }
                    });
                } else if (divPerg.attr("tipocampo") == 0 && divPerg.attr("tipo") == 'combo') {
                    vArr[0] = $(selector + ' select').val();
                } 
                if (vArr.length == 0) vArr[0] = '';
                return vArr;
            }
        
            function fncCheckAll() {
                var iAtual = 0;
                $('.ControlPergunta').each( function (i) {
                    if (iAtual != $(this).attr("idreferencia")) {
                        iAtual = $(this).attr("idreferencia");
                        fncVerificaStatus(iAtual, true);
                    }
                });
            }
                
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat='server' EnablePageMethods='true' />
        <asp:HiddenField runat='server' id='hidIdentifier' />
        <div class='EditArea'>
            <table id='tblEditArea' >
	            <tr class="trEditHeader">
	                <td colspan='4' >&nbsp;</td>
	            </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader' >
			            Id do Promotor:
		            </td>
		           <td class='tdField' >
		                <asp:Label runat='server' ID='lblIdPromotor' />        
		           </td>
		            <td class='tdFieldHeader' style="width:80px;">
			            Promotor:
		            </td>
		           <td class='tdField' >
		                <asp:Label runat='server' ID='lblPromotor' />        
		           </td>
		        </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader'>
			            Id da Loja:
		            </td>
		           <td class='tdField'>
		                <asp:Label runat='server' ID='lblIdLoja' />
		           </td>
		            <td class='tdFieldHeader' style="width:80px;">
			            Loja:
		            </td>
		           <td class='tdField' >
		                <asp:Label runat='server' ID='lblLoja' />
		           </td>
                </tr>
	            <tr class='trField'>
		            <td class='tdFieldHeader'>
			            Data:
		            </td>
		           <td class='tdField' colspan='3'>
		                <asp:Label runat='server' ID='lblData' />
		           </td>
		        </tr>
		    </table>
		</div> 
        <div id='divFormularioProdutos'>
			<table>
                <xm:XMCrossRepeater ID="xmProdutos" runat="server" EnableViewState='false'>
                    <TopTemplates>
                        <xm:XMCrossRepeaterTopTemplate>
                            <TopLeftTemplate>
                                <thead>
                                <tr>
                                    <th scope="col" class='thSubCategoria'><asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal></th>
                                    <th scope="col" class='thFornecedor'><asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, Fornecedor, "Marca"%>'></asp:Literal></th>
                                    <th scope="col" class='thProduto'><asp:Literal ID="Literal3" runat="server" Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal></th>
                                    <th scope="col"><asp:Literal ID="Literal4" runat="server" Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal> encontrado?</th>
                                    <th scope="col">Informe o preço</th>
                                    <th scope="col">Visualizou Estoque?</th>
                                    <th scope="col">Quantidade no Estoque?</th>
                            </TopLeftTemplate>
                            <ColHeaderTemplate>
                                    <th scope="col">
                                        <%#Server.HtmlEncode(Container.DataItem.Item("Pergunta") & "")%>
                                    </th>
                            </ColHeaderTemplate>
                            <TopRightTemplate>
                                    <th scope="col" class='thStatus'>Status</th>
                                </tr>
                                </thead>
                                <tbody>
                            </TopRightTemplate>
                        </xm:XMCrossRepeaterTopTemplate>
                    </TopTemplates>
                    <RowTemplate>
                       <RowHeaderTemplate>
                            <tr id='<%# "tr_" & Container.dataItem.Item("IDProduto")%>' acao='<%# Container.DataItem.Item("Acao") %>' valign='top' class='<%# iif(Container.DataItem.Row Mod 2 = 0, "trAlternate", "trNormal")%>' >
                                <td class='tdSubCategoria'><%#Server.HtmlEncode(Container.DataItem.Item("SubCategoria") & "")%></td>
                                <td class='tdFornecedor'><%#Server.HtmlEncode(Container.DataItem.Item("Fornecedor") & "")%></td>
                                <td class='tdProduto'><%#Server.HtmlEncode(Container.DataItem.Item("Descricao")& "")%></td>
                                <td>
                                    <div id='<%# "divEncontrado_" & Container.DataItem.Item("IDProduto")%>'>
                                        <select id='<%# "cboEncontrado_" & Container.dataItem.Item("IDProduto")%>' onchange='<%# "fncProdutoEncontrado(" & Container.dataItem.Item("IDProduto") & ", this.value);"%>'>
                                            <option></option>
                                            <option value='0' <%# iif(GetBooleanCompare(Container.dataItem.Item("Encontrado"), false), "selected", "") %>>N&atilde;o</option>
                                            <option value='1' <%# iif(GetBooleanCompare(Container.dataItem.Item("Encontrado"), true), "selected", "") %>>Sim</option>
                                        </select>
                                    </div>
                                </td>
                                <td>
                                    <div id='<%# "divPreco_" & Container.dataItem.Item("IDProduto")%>' <%# iif(GetBooleanCompare(Container.dataItem.Item("Encontrado"), true) = false OR ((Container.dataItem.Item("Acao") and 2) = 0), " style='display:none'", "")%> >
                                        <asp:PlaceHolder runat='server' ID='plhPrecoSugerido' Visible='<%# Container.dataItem.Item("PrecoSugerido") > 0 %>'>Sugerido: <asp:Label runat='server' ID='lblPrecoSugerido' Text='<%# FormatNumber(Container.dataItem.Item("PrecoSugerido"),2) %>' /> <br /></asp:PlaceHolder>
                                        <asp:PlaceHolder runat='server' ID='plhPrecoMinimo' Visible='<%# Container.dataItem.Item("PrecoMinimo") > 0 %>'>Mínimo: <asp:Label runat='server' ID='lblPrecoMin' Text='<%# FormatNumber( Container.dataItem.Item("PrecoMinimo"),2) %>' /><br /></asp:PlaceHolder>
                                        <asp:PlaceHolder runat='server' ID='plhPrecoMaximo' Visible='<%# Container.dataItem.Item("PrecoMaximo") > 0 %>'>Máximo: <asp:Label runat='server' ID='lblPrecoMax' Text='<%# FormatNumber(Container.dataItem.Item("PrecoMaximo"),2) %>' /><br /></asp:PlaceHolder>
                                        <asp:TextBox runat='server' ID='txtPreco' Width='100px' Text='<%# getPreco(Container.DataItem.Item("Preco"), 2) %>' validar='true' tipo='moeda' opcoes='format_inline' onblur='<%# "fncVerificaStatus(" & Container.DataItem.Item("IDProduto") & ");fncVerificaPreco(" & Container.DataItem.Item("IDProduto") & ");" %>' />
                                    </div>
                                </td>
                                <td>
                                    <div id='<%# "divVisualizouEstoque_" & Container.dataItem.Item("IDProduto")%>' <%# iif((GetBooleanCompare(Container.dataItem.Item("Encontrado"), true) = false) OR ((Container.dataItem.Item("Acao") and 1) = 0), " style='display:none'", "")%> >
                                        <select id='<%# "cboVisualizouEstoque_" & Container.dataItem.Item("IDProduto")%>' onchange='<%# "fncVisualizouEstoque(" & Container.dataItem.Item("IDProduto") & ", this.value);"%>'>
                                            <option></option>
                                            <option value='0' <%# iif(GetTinyintCompare(Container.dataItem.Item("VisualizouEstoque"), 0), "selected", "") %>>N&atilde;o</option>
                                            <option value='1' <%# iif(GetTinyintCompare(Container.dataItem.Item("VisualizouEstoque"), 1), "selected", "") %>>Sim</option>
                                        </select>
                                    </div>
                                </td>
                                <td>
                                    <div id='<%# "divQuantidadeEstoque_" & Container.dataItem.Item("IDProduto")%>' <%# iif(GetBooleanCompare(Container.dataItem.Item("Encontrado"), false) OR ((Container.dataItem.Item("Acao") and 1) = 0) OR (GetTinyintCompare(Container.dataItem.Item("VisualizouEstoque"), 1) = false), " style='display:none'", "")%> >
                                        <asp:TextBox runat='server' ID='txtEstoque' Width='100px' Text='<%# getValue(Container.DataItem.Item("Estoque")) %>' validar='true' tipo='inteiro' campo='<%# "Estoque do produto " & Container.DataItem.Item("Descricao") %>' onblur='<%# "fncVerificaStatus(" & Container.DataItem.Item("IDProduto") & ")" %>' />
                                    </div>
                                </td>
                       </RowHeaderTemplate>
                       <ItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>
                                    <div id='<%# "divPergunta_" & Container.dataItem.Item("IDProduto") & "_" & Container.dataItem.Item("IDPergunta")%>' <%# iif(GetBooleanCompare(Container.dataItem.Item("Encontrado"), true) = false OR ((Container.dataItem.Item("Acao") and 4) = 0), " style='display:none'", "")%>>
                                        <uc1:pergunta ID="pergunta1" runat="server" ShowCaption='false' onblur='<%# "fncVerificaStatus(" & Container.DataItem.Item("IDProduto") & ")" %>' idreferencia='<%#Container.DataItem.Item("IDProduto")%>' UseCombo='True' FotoEnabled='false' />
                                    </div>	                    
                                </td>
                       </ItemTemplate>
                       <EmptyItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>&nbsp;</td>
                       </EmptyItemTemplate>
                       <RowFooterTemplate>
                                <td class='tdStatus'>
                                    <span id='<%# "status_" & Container.dataItem.Item("IDProduto")%>'><%# Container.DataItem.Item("Status")%></span>
                                </td>
                            </tr>
                       </RowFooterTemplate>
                    </RowTemplate>
                    <BottomTemplates>
                        <xm:XMCrossRepeaterBottomTemplate>
                            <BottomRightTemplate>
                                </tbody>
                            </BottomRightTemplate>
                        </xm:XMCrossRepeaterBottomTemplate>
                    </BottomTemplates>
                </xm:XMCrossRepeater>
                <tfoot>
                    <tr>
                        <td colspan='<%= xmProdutos.ColumnCount + 8 %>'>
                            <input type='button' value='Fechar' onclick='fncClose(<%=ViewState("IDCATEGORIA") %>, <%=ViewState("IDSUBCATEGORIA") %>, <%=ViewState("IDFORNECEDOR") %>);' class='Botao fr' />
                        </td>
                    </tr>                     
                </tfoot>
            </table>                
        </div>
        <xm:Paginate ID="Paginate1" runat="server" />
        <script type='text/javascript'>
            fncCheckAll()
        </script>
    </form>
</body>
</html>
