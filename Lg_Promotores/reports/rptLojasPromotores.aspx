<%@ Page title="XM Promotores - Yes Mobile" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="rptLojasPromotores.aspx.vb" Inherits="reports_rptLojasPromotores" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    
        function XM_RadioButtonValue_Shopping() { 
			    var m_Value = '';
			    if(document.aspnetForm.chkShopping.checked==true) m_Value+='1';
			    return m_Value;
		    }

        function XM_RadioButtonValue_Status() { 
			    var m_Value = '';
			    if(document.aspnetForm.rdAtivo0.checked==true) 
			        m_Value='2';
			    else if(document.aspnetForm.rdAtivo1.checked==true) 
			        m_Value='0';
			    else if(document.aspnetForm.rdAtivo2.checked==true) 
			        m_Value='1';
			    return m_Value;
			}


			function XM_RadioButtonValue_StatusProm() {
			    var m_Value = '';
			    if (document.aspnetForm.rdAtivop0.checked == true)
			        m_Value = '2';
			    else if (document.aspnetForm.rdAtivop1.checked == true)
			        m_Value = '0';
			    else if (document.aspnetForm.rdAtivop2.checked == true)
			        m_Value = '1';
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

                    var p_IdCliente = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstClientes.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstClientes.options[i].selected == true)
					    {

					        if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstClientes.options[i].value == 0) {
					            p_IdCliente = 0;
					            break;
					        }
					        else {
					            p_IdCliente += document.aspnetForm.ctl00_ContentPlaceHolder1_lstClientes.options[i].value + ',';
					        }
					    }
				    }
    				
				    var p_IdLoja = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options[i].selected == true) {

					        if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options[i].value == 0) {
					            p_IdLoja = 0;
					            break;
					        }
					        else {
					            p_IdLoja += document.aspnetForm.ctl00_ContentPlaceHolder1_lstLojas.options[i].value + ',';
					        }
					    }
				    }

					var p_Segmento = '';
					var p_SegmentoIndex = 0;

					p_SegmentoIndex = document.aspnetForm.ctl00_ContentPlaceHolder1_cboSegmento.selectedIndex
					p_Segmento = document.aspnetForm.ctl00_ContentPlaceHolder1_cboSegmento.options[p_SegmentoIndex].value;
					
				    var p_IdCoordenador = '';
				    if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options.length == 1) {
				        p_IdCoordenador = document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options[0].value;
				    }
				    else {
				        for (var i = 0; i < document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options.length; i++) {
				            if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options[i].selected == true) {

				                if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options[i].value == 0) {
				                    p_IdCoordenador = 0;
				                    break;
				                }
				                else {
				                    p_IdCoordenador += document.aspnetForm.ctl00_ContentPlaceHolder1_lstCoordenador.options[i].value + ',';
				                }
				            }
				        }
				    }

				    var p_IdLider = '';
				    if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options.length == 1) {
				        p_IdLider += document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options[0].value
				    }
				    else {
				        for (var i = 0; i < document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options.length; i++) {
				            if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options[i].selected == true) {

				                if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options[i].value == 0) {
				                    p_IdLider = 0;
				                    break;
				                }
				                else {
				                    if (p_IdLider != '') p_IdLider += ',';
				                    p_IdLider += document.aspnetForm.ctl00_ContentPlaceHolder1_lstLider.options[i].value;
				                }
				            }
				        }
				    }
    				
				    var p_IdPromotor = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstPromotor.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstPromotor.options[i].selected == true) {

					        if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstPromotor.options[i].value == 0) {
					            p_IdPromotor = 0;
					            break;
					        }
					        else {
					            if (p_IdPromotor != '') p_IdPromotor += ',';
					            p_IdPromotor += document.aspnetForm.ctl00_ContentPlaceHolder1_lstPromotor.options[i].value;
					        }
					    }
				    }
				    
				    var p_IdShopping = '';
				    for (var i=0; i<document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options.length; i++) 
				    { 
					    if(document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options[i].selected == true) {

					        if (document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options[i].value == 0) {
					            p_IdShopping = 0;
					            break;
					        }
					        else {
					            if (p_IdShopping != '') p_IdShopping += ',';
					            p_IdShopping += document.aspnetForm.ctl00_ContentPlaceHolder1_lstShopping.options[i].value;
					        }
					    }
				    }
    																	
				    var p_Estado        = XM_RadioButtonValue_Estados();
				    var p_TipoLoja      = XM_RadioButtonValue_TipoLoja();
				    var p_Regiao        = XM_RadioButtonValue_Regiao();
				    var p_Status        = XM_RadioButtonValue_Status();
				    var p_Statusp       = XM_RadioButtonValue_StatusProm();
    				
				    //VERIFICANDO PERIODO SELECIONADO
				    var p_Periodo = '';
				    var p_PeriodoText = '';
				    if (document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataInicial.value == '' || document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataFinal.value == '')
					    {
						    alert('É NESCESSÁRIO INFORMAR CORRETAMENTE O PERÍODO');
						    return false;
					    }
					    //USUARIO DIGITOU UM PERIODO NO TEXTBOX
					    p_Periodo = document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataInicial.value + '||' + document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataFinal.value;
					    p_PeriodoText = document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataInicial.value.substring(0, 5) + ' À ' + document.aspnetForm.ctl00_ContentPlaceHolder1_txtDataFinal.value.substring(0, 5);
    				    											
    				
                    var URL = 'rptlojaspromotoresdet.aspx?cli=' + p_IdCliente + '&loj=' + p_IdLoja + '&pro=' + p_IdPromotor + 
														    '&crd=' + p_IdCoordenador + '&lid=' + p_IdLider + 
														    '&per=' + p_Periodo + '&pertxt=' + p_PeriodoText + 
														    '&tiploj=' + p_TipoLoja + '&regs=' + p_Regiao +
														    '&sta=' + p_Status + '&stap=' + p_Statusp +
														    '&est=' + p_Estado + '&shop=' + p_IdShopping + 
                                                            '&seg=' + p_Segmento
														    
                    //alert(URL);
														    
				    var win = window.open(URL, 'RPTPERFORMANCE', 'location = no, toolbar = yes, resizable=yes, scrollbars = yes, width=850, height=650');
            
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
					                        <asp:label ID="lblNomeBandeira" runat="server" Text='<%$Settings: NomeBandeira, Relatorios.DescricaoBandeira, "Bandeira" %>'></asp:label>:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="Fantasia" DataValueField="IdCliente" style="width:300;" runat="Server" ID="lstClientes"></asp:ListBox>				                        
					                        <asp:Button runat="Server" ID="btnVisLojas" Text="Visualizar Lojas" />
				                        </td>
				                    </tr>
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
				                    </tr>
				                </table>
                            </div>
                            <div id='divPromotores'>
                                <table id='tblPromotores'>
                                    <tr>
                                        <td valign="top">
					                        Segmento:<br />
                                            <asp:DropDownList DataTextField="Categoria" DataValueField="Categoria" style="width:300;" runat="Server" ID="cboSegmento" AutoPostBack="True"></asp:DropDownList>					                        
				                        </td>
                                    </tr>
                                    <tr>
				                        <td valign="top">
					                        Coordenador:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="Coordenador" DataValueField="IdCoordenador" style="width:300" runat="Server" ID="lstCoordenador"></asp:ListBox>
					                        <asp:Button runat="Server" ID="btnLideres" Text="Visualizar L&iacute;deres" />
				                        </td>
			                        </tr>
			                        <tr>
				                        <td valign="top">
					                        L&iacute;der:<br />
                                            <asp:ListBox SelectionMode="Multiple" DataTextField="Lider" DataValueField="IdLider" style="width:300;" runat="Server" ID="lstLider"></asp:ListBox>
                                            <asp:Button runat="Server" Width="200" ID="btnPromotores" Text="Visualizar Promotores" />
				                        </td>
			                        </tr>                                    
                                    <tr>
				                        <td valign="top">
					                        Promotor:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="Promotor" DataValueField="IdPromotor" style="width:300;" runat="Server" ID="lstPromotor"></asp:ListBox>                                            
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
	                                <td width="50%" valign="top" colspan="2">
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
                                    <td width="25%" height="60" colspan='2' valign="middle">
                                        Status da Loja:<br />
                                        <input type="radio" id="rdAtivo0" name="rdAtivo" value="2" />Todas&nbsp;
                                        <input type="radio" id="rdAtivo1" name="rdAtivo" value="0" />Inativo&nbsp;
                                        <input type="radio" id="rdAtivo2" name="rdAtivo" value="1" checked />Ativo
                                    </td>
                                    <td width="50%" rowspan="3" valign="middle">
				                        UF:<br />
				                        <asp:CheckBoxList RepeatColumns="9" RepeatDirection="Horizontal" Runat="server" ID="chkEstado">
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
                                    <td width="25%" height="60" colspan='2' valign="middle">
                                        Status do Promotor:<br />
                                        <input type="radio" id="rdAtivop0" name="rdAtivop" value="2" />Todos&nbsp;
                                        <input type="radio" id="rdAtivop1" name="rdAtivop" value="0" />Inativo&nbsp;
                                        <input type="radio" id="rdAtivop2" name="rdAtivop" value="1" checked />Ativo
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
                <div class='AreaBotoes'>
                    <input type="button" runat='server' id='btnBuildReport' onclick="javascript:showReport()" class="Botao" value=" Visualizar "  />
                    <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
                </div>
                <div id='divErros'>
                    <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
                    <asp:ValidationSummary runat='server' ID='valSummary' />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnVisLojas" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnLideres" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnPromotores" EventName="Click" />
            </Triggers>

		</asp:UpdatePanel>
	</div>

</asp:Content>