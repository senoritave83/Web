<%@ Page Language="VB" AutoEventWireup="false" CodeFile="produtos.aspx.vb" Inherits="formulario_produtos" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc2" %>
<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language='javascript' type='text/javascript'>

            function fncGetVisualizouEstoque(vIDProduto) {
                chkEstoque = document.getElementById("cboVisualizouEstoque_" + vIDProduto);
                if (chkEstoque.selectedIndex < 1)
                    return "";
                else
                    return chkEstoque.options[chkEstoque.selectedIndex].value;
            }

            function fncGetEncontrado(vIDProduto) {
                var cboEncontrado = document.getElementById("cboEncontrado_" + vIDProduto);
                if (cboEncontrado.selectedIndex < 1)
                    return ""
                else 
                    return cboEncontrado.options[cboEncontrado.selectedIndex].value;
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
                var tr = document.getElementById("tr_" + vIDProduto);
                var iAcao = tr.getAttribute("acao");
                var divPreco = document.getElementById("divPreco_" + vIDProduto);
                var divVisualizouEstoque = document.getElementById("divVisualizouEstoque_" + vIDProduto);
                var divEstoque = document.getElementById("divQuantidadeEstoque_" + vIDProduto);
                if (value == 1) {
                
                    if ((iAcao & 2) != 0) { divPreco.style.display = 'inline'; }
                    if ((iAcao & 1) != 0) { divVisualizouEstoque.style.display = 'inline'; }
                    if ((iAcao & 1) != 0) {
                        if (fncGetVisualizouEstoque(vIDProduto) == 1) divEstoque.style.display = 'inline'; 
                    }
                } else {
                    divPreco.style.display = 'none';
                    divVisualizouEstoque.style.display = 'none';
                    divEstoque.style.display = 'none';
                }

                if ((iAcao & 4) != 0) {
                    var divs = tr.getElementsByTagName("div");
                    var vname = 'divPergunta_' + vIDProduto + '_';
                    for (var i = 0; i < divs.length; i++) {
                        if (Left(divs[i].id, vname.length) == vname) {
                            if (value == 1) {
                                divs[i].style.display = 'inline';
                            } else {
                                divs[i].style.display = 'none';
                            }
                        }
                    }
                }
                fncVerificaStatus(vIDProduto);
            }

            function fncVisualizouEstoque(vIDProduto, value) {
                var tr = document.getElementById("tr_" + vIDProduto);
                var iAcao = tr.getAttribute("acao");
                var divEstoque = document.getElementById("divQuantidadeEstoque_" + vIDProduto);
                var txtEstoque = divEstoque.getElementsByTagName("input")[0];
                if (value == 1) {
                    if ((iAcao & 1) != 0) { divEstoque.style.display = 'inline'; }
                    txtEstoque.setAttribute("validar", 'true');
                    txtEstoque.setAttribute("obrigatorio", 'true');
                } else {
                    divEstoque.style.display = 'none';
                    txtEstoque.setAttribute("validar", 'false');
                    txtEstoque.setAttribute("obrigatorio", 'false');
                }
                fncVerificaStatus(vIDProduto);
            }

            function fncClose(vIDCat, vIDSub, vIDFor) {
                window.opener.refresh(vIDCat, vIDSub, vIDFor);
                window.opener.focus();
                self.close();
            }

            function fncVerificaStatus(vIDProduto) {
                var tr = document.getElementById("tr_" + vIDProduto);
                var iAcao = tr.getAttribute("acao");
                var encontrado = fncGetEncontrado(vIDProduto);
                var vStatus = 'completo';

                if (encontrado == 1) {
                    if ((iAcao & 2) != 0) {
                        var divPreco = document.getElementById("divPreco_" + vIDProduto);
                        var txtPreco = divPreco.getElementsByTagName("input")[0];
                        if (txtPreco.getAttribute("validar") == 'true' && verificaCampo(txtPreco) != '') {
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
                        var divs = tr.getElementsByTagName("div");
                        var vname = 'divPergunta_' + vIDProduto + '_';
                        for (var i = 0; i < divs.length; i++) {
                            if (Left(divs[i].id, vname.length) == vname) {
                                var divCampo = divs[i].getElementsByTagName("div")[0];
                                var vIDPergunta = divs[i].id.substring(vname.length);
                                var vResps = fncGetRespostasPergunta(vIDProduto, vIDPergunta);
                                if (vResps.length < 1) {
                                    vStatus = "parcial";
                                }
                                else if (vResps[0] == '') {
                                    vStatus = "parcial";
                                }
                            }
                        }
                    }
                }
                else if (encontrado == "") {
                    vStatus = 'não preenchido'
                }

                document.getElementById("status_" + vIDProduto).innerHTML = vStatus;
                if (vStatus == 'completo') {
                    document.getElementById("status_" + vIDProduto).style.color = 'green'
                    document.getElementById("status_" + vIDProduto).innerHTML = vStatus;
                    document.getElementById("status_" + vIDProduto).innerHTML = 'gravando...';
                    fncGravarItem(vIDProduto);
                }
                else {
                    document.getElementById("status_" + vIDProduto).style.color = 'red';
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
 
            function fncGetRespostasPergunta(vIDProduto, vIDPergunta) {
                var vArr = new Array();
                var divPergunta = document.getElementById("divPergunta_" + vIDProduto + "_" + vIDPergunta)
                var divs = divPergunta.getElementsByTagName("div");
                for (var i = 0; i < divs.length; i++) {
                    if (divs[i].idpergunta == vIDPergunta) {
                        var iTipoCampo = divs[i].tipocampo;
                        var vtipo = divs[i].tipo;
                        if (iTipoCampo == 1 || iTipoCampo == 3) {
                            var txtResposta = divs[i].getElementsByTagName("input")[0];
                            vArr[0] = txtResposta.value;
                        }
                        else if (iTipoCampo == 0 && (vtipo == 'radio' || vtipo == 'list')) {
                            var chks = divs[i].getElementsByTagName("input");
                            var labels = divs[i].getElementsByTagName("label");
                            for (var j = 0; j < chks.length; j++) {
                                if (chks[j].checked) {
                                    vArr[vArr.length] = labels[j].innerText;
                                }
                            }
                        }                
                        else if (iTipoCampo == 0 && vtipo == 'combo') {
                            var cbo = divs[i].getElementsByTagName("select")[0];
                            if (cbo.selectedIndex > 0)
                                vArr[vArr.length] = cbo.options[cbo.selectedIndex].value;
                        }                
                    }
                }
                return vArr;
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
                                    <th scope="col" class='thSubCategoria'>Categoria</th>
                                    <th scope="col" class='thFornecedor'>Marca</th>
                                    <th scope="col" class='thProduto'>Produtos</th>
                                    <th scope="col">Produto encontrado?</th>
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
                                        <uc1:pergunta ID="pergunta1" runat="server" ShowCaption='false' onblur='<%# "fncVerificaStatus(" & Container.DataItem.Item("IDProduto") & ")" %>' UseCombo='True' />
                                    </div>	                    
                                </td>
                       </ItemTemplate>
                       <EmptyItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>&nbsp;</td>
                       </EmptyItemTemplate>
                       <RowFooterTemplate>
                                <td class='tdStatus'>
                                    <span id='<%# "status_" & Container.dataItem.Item("IDProduto")%>'><%#Container.DataItem.Item("Status")%></span>
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
        <uc2:Paginate ID="Paginate1" runat="server" />
    </form>
</body>
</html>
