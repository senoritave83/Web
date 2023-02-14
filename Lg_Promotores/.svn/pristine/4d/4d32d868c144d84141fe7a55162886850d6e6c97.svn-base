<%@ Page title="XM Promotores - Yes Mobile" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="rptTotalMostruarios.aspx.vb" Inherits="reports_rptTotalMostruarios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    
            function XM_RadioButtonValue_Shopping() { 
			    var m_Value = '';
			    if(document.aspnetForm.chkShopping.checked==true) m_Value+='1';
			    return m_Value;
		    }
		    
		    function XM_RadioButtonValue_Estados() { 
		    var m_Value = '';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_0.checked==true) m_Value+='AC,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_1.checked==true) m_Value+='AL,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_2.checked==true) m_Value+='AP,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_3.checked==true) m_Value+='AM,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_4.checked==true) m_Value+='BA,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_5.checked==true) m_Value+='CE,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_6.checked==true) m_Value+='DF,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_7.checked==true) m_Value+='ES,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_8.checked==true) m_Value+='GO,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_9.checked==true) m_Value+='MA,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_10.checked==true) m_Value+='MT,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_11.checked==true) m_Value+='MS,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_12.checked==true) m_Value+='MG,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_13.checked==true) m_Value+='PA,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_14.checked==true) m_Value+='PB,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_15.checked==true) m_Value+='PR,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_16.checked==true) m_Value+='PE,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_17.checked==true) m_Value+='PI,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_18.checked==true) m_Value+='RJ,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_19.checked==true) m_Value+='RN,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_20.checked==true) m_Value+='RS,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_21.checked==true) m_Value+='RO,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_22.checked==true) m_Value+='RR,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_23.checked==true) m_Value+='SC,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_24.checked==true) m_Value+='SP,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_25.checked==true) m_Value+='SE,';
				    if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkEstado_26.checked==true) m_Value+='TO,';
				    return m_Value;
		}
    
        function showReport(){

				    var p_IdLoja = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options[i].selected == true)
					    {
						    p_IdLoja += document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options[i].value + ',';
					    }
				    }
    								    
				    var p_IdShopping = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options[i].selected == true)
					    {
						    if(p_IdShopping!='')p_IdShopping += ',';
						    p_IdShopping += document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options[i].value;
					    }
					}

					var p_IdCategoria = '';
					for (var i = 0; i < document.aspnetForm.ctl00_ContentPlaceHolder1_lstSubCategoria.options.length; i++) {
					    if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstSubCategoria.options[i].selected == true) {
					        p_IdCategoria += document.aspnetForm.ctl00_ContentPlaceHolder1_lstSubCategoria.options[i].value;
					    }
					}
    																	
				    var p_Estado        = XM_RadioButtonValue_Estados();
				    var p_TipoLoja      = XM_RadioButtonValue_TipoLoja();
				    var p_Regiao        = XM_RadioButtonValue_Regiao();

    				
				    //VERIFICANDO PERIODO SELECIONADO
				    var p_Periodo = '';
				    var p_PeriodoText = '';
				    if (document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataInicial.value == '' || document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataFinal.value == '')
					    {
						    alert('É NESCESSÁRIO INFORMAR CORRETAMENTE O PERÍODO');
						    return false;
						}

						if (p_IdCategoria == '') {
					    alert('É NESCESSÁRIO INFORMAR UMA CATEGORIA');
					    return false;
					}
    				
                    var URL = 'rptTotalMostruariosdet.aspx?pi=' + document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataInicial.value + '&pf=' + document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataFinal.value + '&rg=' + p_Regiao + 
                            '&est=' + p_Estado + '&tp=' + p_TipoLoja + '&sh=' + p_IdShopping + '&lj=' + p_IdLoja + '&ct=' + p_IdCategoria;
					
		            								    
				    var win = window.open(URL, 'RPTPERFORMANCE', 'location = no, toolbar = yes, scrollbars = yes, width=850, height=650');
            
            }
    </script>
	<asp:ScriptManager runat="Server" EnableScriptGlobalization="true" EnableScriptLocalization="true"  ID="sctRptPrecos"></asp:ScriptManager>
    <div class='ReportArea'>
        <table class="AreaSubTitulo" id='Table1' border="0" width="100%">
		    <tr class='trField'>
			    <td width="50%">
			        Selecione os dados desejados para gerar o relat&oacute;rio.
			    </td>
			    <td>
                    <asp:UpdateProgress ID="updProgressPrecos" runat="Server" DisplayAfter="0" AssociatedUpdatePanelID="updrptPrecos">
                        <ProgressTemplate>
                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
			    </td>
			</tr>
	    </table>
        <asp:UpdatePanel runat="Server" ID="updrptPrecos">
            <ContentTemplate>
                <table class='tblReportFilterArea' border="0">
                    <tr>
                        <td>
                            <div id='divLojas'>
		                        <table id='tblClientesLojas' cellspacing="2" border="0" width="100%">
			                        <tr>
				                        <td valign="top">
				                            Loja<br />
				                            <asp:ListBox SelectionMode="Multiple" DataTextField="Loja" DataValueField="IdLoja" style="width:300;" runat="Server" ID="lstLojas"></asp:ListBox>
				                        </td>
                                    </tr>
                                    <tr>
				                        <td valign="top">
	                                        Shopping:<br />
	                                        <asp:ListBox SelectionMode="Multiple" DataTextField="Shopping" DataValueField="IdShopping" style="width:300;" runat="Server" ID="lstShopping"></asp:ListBox>
				                        </td>
				                        <td>&nbsp;</td>
				                    </tr>
				                </table>
                            </div>
                            <div id='divProdutos'>
                                <table id='tblProdutos'>
                                    <tr>
				                        <td valign="top">
					                        Categoria:<br />
                                            <asp:ListBox DataTextField="SubCategoria" DataValueField="IdSubCategoria" runat="server" ID="lstSubCategoria"></asp:ListBox>
				                        </td>
                                    </tr>
                                </table>
                           </div>
                        </td>
                    </tr>
                </table>
                <table class="tblReportFilterArea" border="0">
                    <tr>
                        <td>
                            <table id='tblRegioes' cellspacing="2" cellpadding="2" border="0" width="100%">
                                <tr>
	                                <td width="50%" valign="top">
	                                    Tipo de Loja:
	                                    <asp:CheckBoxList RepeatDirection="Horizontal" RepeatColumns="2" RepeatLayout="Table" DataTextField="TipoLoja" DataValueField="IdTipoLoja" style="width:100%" runat="Server" ID="chkTipoLoja"></asp:CheckBoxList>
	                                    <asp:Literal runat="Server" ID="ltScriptTipoLoja"></asp:Literal>
	                                </td>
	                                <td width="50%">
		                                Regi&atilde;o:
                                        <asp:CheckBoxList RepeatDirection="Horizontal" DataTextField="Regiao" RepeatColumns="3" DataValueField="IdRegiao" style="width:100%" runat="Server" ID="chkRegiao"></asp:CheckBoxList>
                                        <asp:Literal runat="Server" ID="ltScriptRegiao"></asp:Literal>
	                                </td>
                                </tr>
                                <tr>
                                    <td width="50%" rowspan="3" valign="bottom">
				                        UF:<br />
				                        <asp:CheckBoxList RepeatColumns="7" RepeatDirection="Horizontal" Runat="server" ID="chkEstado">
				                            <asp:ListItem Value="AC" Text="AC"></asp:ListItem>
				                            <asp:ListItem Value="AL" Text="AL"></asp:ListItem>
				                            <asp:ListItem Value="AP" Text="AP"></asp:ListItem>
				                            <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
				                            <asp:ListItem Value="BA" Text="BA"></asp:ListItem>
				                            <asp:ListItem Value="CE" Text="CE"></asp:ListItem>
				                            <asp:ListItem Value="DF" Text="DF"></asp:ListItem>
				                            <asp:ListItem Value="ES" Text="ES"></asp:ListItem>
				                            <asp:ListItem Value="GO" Text="GO"></asp:ListItem>
				                            <asp:ListItem Value="MA" Text="MA"></asp:ListItem>
				                            <asp:ListItem Value="MT" Text="MT"></asp:ListItem>
				                            <asp:ListItem Value="MS" Text="MS"></asp:ListItem>
				                            <asp:ListItem Value="MG" Text="MG"></asp:ListItem>
				                            <asp:ListItem Value="PA" Text="PA"></asp:ListItem>
				                            <asp:ListItem Value="PB" Text="PB"></asp:ListItem>
				                            <asp:ListItem Value="PR" Text="PR"></asp:ListItem>
				                            <asp:ListItem Value="PE" Text="PE"></asp:ListItem>
				                            <asp:ListItem Value="PI" Text="PI"></asp:ListItem>
				                            <asp:ListItem Value="RJ" Text="RJ"></asp:ListItem>
				                            <asp:ListItem Value="RN" Text="RN"></asp:ListItem>
				                            <asp:ListItem Value="RS" Text="RS"></asp:ListItem>
				                            <asp:ListItem Value="RO" Text="RO"></asp:ListItem>
				                            <asp:ListItem Value="RR" Text="RR"></asp:ListItem>
				                            <asp:ListItem Value="SC" Text="SC"></asp:ListItem>
				                            <asp:ListItem Value="SP" Text="SP"></asp:ListItem>
				                            <asp:ListItem Value="SE" Text="SE"></asp:ListItem>
				                            <asp:ListItem Value="TO" Text="TO"></asp:ListItem>
				                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" valign="top"  colspan="2">
                                        Per&iacute;odo:<br />
										De&nbsp;<asp:TextBox runat="server" MaxLength="10" CssClass="form_text" ID="txtDataInicial" name="txtDataInicial"
													onkeydown="FormataData(this, event);" onblur="VerificaData(this);"></asp:TextBox>
													<cc1:CalendarExtender  ID="cal_txtDataInicial" 
													runat="server" 
													TargetControlID="txtDataInicial"
													PopupPosition="Right"
													PopupButtonID="imgCalendarInicial"
													Format="dd/MM/yyyy"
													/>
										<asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" />
													<font class="content_text">&nbsp;até&nbsp;</font><asp:TextBox runat="server" MaxLength="10" 
													CssClass="form_text" ID="txtDataFinal" name="txtDataFinal"
													onkeydown="FormataData(this, event);" onblur="VerificaData(this);"></asp:TextBox>
													<cc1:CalendarExtender ID="cal_txtDataFinal" 
													runat="server" 
													TargetControlID="txtDataFinal"
													PopupPosition="Right"
													PopupButtonID="imgCalendarFinal"
													Format="dd/MM/yyyy"
													Animated="true"
													/><asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
		</asp:UpdatePanel>
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnBuildReport' onclick="javascript:showReport()" class="Botao" value=" Visualizar "  />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

