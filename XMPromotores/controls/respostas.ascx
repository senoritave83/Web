<%@ Control Language="VB" AutoEventWireup="false" CodeFile="respostas.ascx.vb" Inherits="controls_respostas" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>

    <script language='javascript' type='text/javascript'>

            function verificaUnica(obj, vUnico, campo){
                var vIDReferencia = $('#' + campo.id).attr("idreferencia");
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
                fncVerificaStatus(vIDReferencia);
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

            function fncVerificaStatus(vIDReferencia, checkOnly) {
                var tr = document.getElementById("tr_" + vIDReferencia);
                var iAcao = $('#tr_' + vIDReferencia).attr('acao');
                var vStatus = 'completo';
                var iPularPara = 0;
                var bCondicional = false;

                $('div[id^="divPergunta_' + vIDReferencia + '_"]').each(function (i) {
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
                                var vResps = fncGetRespostasPergunta(vIDReferencia, $('#' + this.id + ' div').attr("iddependente"));
                                var bOk = false;
                                for (var s = 0; s < vResps.length; s++)
                                {
                                    if(vResps[s] == $('#' + this.id + ' div').attr('dependentevalor')) bOk = true;
                                }
                                if (bOk == false) {
                                    fncEsconderLimpar('#' + this.id + ' div')
                                } else {
                                    $('#' + this.id + ' div').show();
                                    if (fncPerguntaRespondida(vIDReferencia, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                        vStatus = "parcial";
                                    }
                                }
                            } else {
                                if (fncPerguntaRespondida(vIDReferencia, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                    vStatus = "parcial";
                                }
                            }
                            iPularPara = fncVerificaPular(vIDReferencia, $('#' + this.id + ' div').attr("idpergunta"));
                            if (iPularPara != 0) {
                                bCondicional =true;    
                            }
                        } else {
                            $('#' + this.id + ' div').show();         
                            if (fncPerguntaRespondida(vIDReferencia, $('#' + this.id + ' div').attr("idpergunta")) == false) {
                                vStatus = "parcial";
                            }
                        }
                     } else {
                        // Perguntas puladas
                        fncEsconderLimpar('#' + this.id + ' div')
                     }
                    
                });

                $('#status_' + vIDReferencia).text(vStatus);
                if (vStatus == 'completo') {
                    $('#status_' + vIDReferencia).css('color', 'green');
                    $('#status_' + vIDReferencia).text('gravando...');
                    fncGravarItem(vIDReferencia);
                }
                else {
                    $('#status_' + vIDReferencia).css('color', 'red');
                }
            }
            
            function xmlencode(value) {
                return replace(replace(replace(replace(value, '<', '&lt;'), '"', '&quot;'), '&', '&amp;'),'>', '&gt;');
            }        
            
            function fncExcluir(vIDReferencia){
                var vIdentifier = document.getElementById('respostas1_hidIdentifier').value;
                PageMethods.ApagarXMLEntidadeItem(vIdentifier, <%=me.TipoEntidade %>, vIDReferencia, OnSucceeded(vIDReferencia), OnFailed);
            }

            function fncGravarItem(vIDReferencia) {
                var tr = document.getElementById("tr_" + vIDReferencia);
                var iAcao = tr.attributes["acao"].value;
                var vXML = '';
            
                vXML += '<?xml version="1.0" encoding="ISO-8859-1"?><xml>';
                vXML += '<ent id="' + vIDReferencia + '" ';
                vXML += '>';

                var divs = tr.getElementsByTagName("div");
                var vname = 'divPergunta_' + vIDReferencia + '_';
                for (var i = 0; i < divs.length; i++) {
                    if (Left(divs[i].id, vname.length) == vname) {
                        var vIDPergunta = divs[i].id.substring(vname.length);
                        vXML += '<perg id="' + vIDPergunta + '">'
                        var vResp = fncGetRespostasPergunta(vIDReferencia, vIDPergunta);
                        for (var j = 0; j < vResp.length; j++) {
                            vXML += '<resposta text="' + xmlencode(vResp[j]) + '" item="' + j + '" />';
                        }
                        vXML += '</perg>'
                    }
                }
                vXML += '</ent></xml>'
                var vIdentifier = document.getElementById('<%=hidIdentifier.ClientID %>').value;
                PageMethods.GravarXMLEntidadeItem(vIdentifier, <%=me.TipoEntidade %>, vIDReferencia, vXML, OnSucceeded(vIDReferencia), OnFailed);
            }

            function OnSucceeded(vIDReferencia) {
                document.getElementById("status_" + vIDReferencia).innerHTML = 'gravado';
                <%
                if me.TipoEntidade = 11 then Response.Write("window.location.reload(true);")
                %>
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
 
            function fncGetRespostasPergunta(vIDReferencia, vIDPergunta) {
                var vArr = new Array();
                var selector = '#divPergunta_' + vIDReferencia + '_' + vIDPergunta + ' div[idpergunta="' + vIDPergunta + '"]';
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
                $(document).ready(function () {
                    $('.ControlPergunta').each( function (i) {
                        if (iAtual != $(this).attr("idreferencia")) {
                            iAtual = $(this).attr("idreferencia");
                            fncVerificaStatus(iAtual, true);
                        }
                    });
                });
            }
                
    </script>
        <asp:HiddenField runat='server' id='hidIdentifier' />
        <div id='divFormularioProdutos'>
			<table>
                <xm:XMCrossRepeater ID="xmProdutos" runat="server" EnableViewState='false'>
                    <TopTemplates>
                        <xm:XMCrossRepeaterTopTemplate>
                            <TopLeftTemplate>
                                <thead>
                                <tr>
                                    <th>Nome</th>
                            </TopLeftTemplate>
                            <ColHeaderTemplate>
                                    <th scope="col">
                                        <%#Server.HtmlEncode(Container.DataItem.Item("Pergunta") & "")%>
                                    </th>
                            </ColHeaderTemplate>
                            <TopRightTemplate>
                                    <th scope="col" class='thStatus'>Status</th>
                                    <asp:PlaceHolder runat='server' ID='plhDel' Visible='<%# IIF(me.TipoEntidade = 11 AND Me.ReadOnly =false, True, false) %>'>
                                        <th scope="col" class='thDel'>&nbsp;</th>
                                    </asp:PlaceHolder>
                                </tr>
                                </thead>
                                <tbody>
                            </TopRightTemplate>
                        </xm:XMCrossRepeaterTopTemplate>
                    </TopTemplates>
                    <RowTemplate>
                       <RowHeaderTemplate>
                            <tr id='<%# "tr_" & Container.dataItem.Item("IDReferencia")%>' acao='<%# Container.DataItem.Item("Acao") %>' valign='top' class='<%# iif(Container.DataItem.Row Mod 2 = 0, "trAlternate", "trNormal")%>' >
                                <td><%# Container.dataItem.Item("Nome") %></td>
                       </RowHeaderTemplate>
                       <ItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>
                                    <div id='<%# "divPergunta_" & Container.dataItem.Item("IDReferencia") & "_" & Container.dataItem.Item("IDPergunta")%>'>
                                        <uc1:pergunta ID="pergunta1" runat="server" ShowCaption='false' onblur='<%# "fncVerificaStatus(" & Container.DataItem.Item("IDReferencia") & ")" %>' idreferencia='<%#Container.DataItem.Item("IDReferencia")%>' UseCombo='True' />
                                        <asp:Literal runat='server' ID='ltrResposta'></asp:Literal>
                                    </div>	                    
                                </td>
                       </ItemTemplate>
                       <EmptyItemTemplate>
                                <td class='<%# "td" & (Container.DataItem.Row Mod 2) & (Container.DataItem.Column Mod 2)%>'>&nbsp;</td>
                       </EmptyItemTemplate>
                       <RowFooterTemplate>
                                <td class='tdStatus'>
                                    <span id='<%# "status_" & Container.dataItem.Item("IDReferencia")%>'><%#Container.DataItem.Item("Status")%></span>
                                </td>
                                <asp:PlaceHolder runat='server' ID='plhDel' Visible='<%# IIF(Container.dataItem.Item("IDReferencia") > 0 AND me.TipoEntidade = 11 AND Me.ReadOnly =false, True, false) %>'>
                                    <td class='thDel'>
                                        <a href='javascript:void(0)' onclick='<%# "fncExcluir(" & Container.dataItem.Item("IDReferencia") & ")"%>'><img src="../imagens/excluir_ico.png" border='0' /></a>                                    
                                    </td>
                                </asp:PlaceHolder>
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
            </table>                
        </div>
        <xm:Paginate ID="Paginate1" runat="server" />
        <script type='text/javascript'>
            fncCheckAll()
        </script>
