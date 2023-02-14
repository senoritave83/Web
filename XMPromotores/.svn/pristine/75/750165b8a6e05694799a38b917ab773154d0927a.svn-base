<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="exportar.aspx.vb" Inherits="reports_exportar" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class='ExportArea'>
        <table class="AreaSubTitulo" id='Table1' border="0" width="100%">
            <tr class='trField'>
	            <td width="50%">
	                Selecione os dados desejados para gerar o relat&oacute;rio.
	            </td>
	            <td>
                    <asp:UpdateProgress ID="updProgressPrecos" runat="Server" DisplayAfter="0" AssociatedUpdatePanelID="updExportar">
                        <ProgressTemplate>
                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
	            </td>
	        </tr>
        </table>
        <asp:UpdatePanel runat="Server" ID="updExportar">
            <ContentTemplate>
                <table class='tblExportFilterArea'>
                    <tr>
                        <td>
                            <div id='divLojas'>
		                        <table>
			                        <tr>
				                        <td valign="top">
					                        <asp:label ID="lblNomeBandeira" runat="server" Text='<%$Settings: NomeBandeira, Relatorios.DescricaoBandeira, "Bandeira" %>'></asp:label>:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="Fantasia" DataValueField="IdCliente" runat="Server" ID="lstClientes" CssClass="formulario"></asp:ListBox>				                        
					                        <asp:Button runat="Server" ID="btnVisLojas" Text="Listar Lojas" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
				                        </td>
				                    </tr>
			                        <tr>
				                        <td valign="top">
				                            Loja<br />
				                            <asp:ListBox SelectionMode="Multiple" DataTextField="Loja" DataValueField="IdLoja" runat="Server" ID="lstLojas" CssClass="formulario"></asp:ListBox>
				                        </td>
                                    </tr>
                                    <tr>
				                        <td valign="top" style="padding-top:22px; ">
	                                        Shopping:<br />
	                                        <asp:ListBox SelectionMode="Multiple" DataTextField="Shopping" DataValueField="IdShopping" runat="Server" ID="lstShopping"  CssClass="formulario"></asp:ListBox>
				                        </td>
				                    </tr>
				                </table>
                            </div>
                            <div id='divProdutos'>
                                <table id='tblProdutos'>
                                    <tr>
				                        <td valign="top">
					                        <asp:Literal runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal>:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="Categoria" DataValueField="IdCategoria" runat="Server" ID="lstCategoria" CssClass="formulario"></asp:ListBox>
					                        <asp:Button runat="Server" ID="btnVisSubCat" Text="Listar Categorias" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px"/>
				                        </td>
                                    </tr>                                
                                    <tr>
				                        <td valign="top">
					                        <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal>:<br />
                                            <asp:ListBox SelectionMode="Multiple" DataTextField="SubCategoria" DataValueField="IdSubCategoria" runat="Server" ID="lstSubCategoria" CssClass="formulario"></asp:ListBox>
					                        <asp:Button runat="Server" ID="btnVisProd" Text="Listar Produtos" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px"/>
				                        </td>
                                    </tr>
                                    <tr>
				                        <td valign="top">
					                        <asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal>:<br />
					                        <asp:ListBox SelectionMode="Multiple" DataTextField="DescricaoResumida" DataValueField="IdProduto" runat="Server" ID="lstProduto" CssClass="formulario" Height="91px"></asp:ListBox>
				                        </td>
                                    </tr>
                                </table>                             
                            </div>
                            <div id='divPromotores'>
                                <table width="100%">
                                    <tr>
                                        <td>Listar por</td>
                                    </tr>
                                    <tr>
                                        <td>
		                                <asp:DropDownList DataTextField="Cargo" DataValueField="IDCargo" style="width:300px; height:20px;"  AutoPostBack='true' runat="server" ID="drpCargouperior" CssClass="Select"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
		                                <asp:ListBox ID="lstSuperior" SelectionMode='Multiple' style="margin-bottom:5px;"  AutoPostBack='true' runat="server" DataTextField="Usuario" DataValueField="IDUsuario" CssClass="formulario" Height="98px" Width="300px"  /></td>
                                    </tr>
                                </table>
                                <asp:label  Runat="server" ID="Label6">Promotores</asp:label><br>			
                                <asp:ListBox SelectionMode="Multiple" runat="server" ID="LstPromotor" 
                                    DataTextField="Usuario" DataValueField="IdUsuario" 
                                    Height="200px" Width="300px" CssClass="formulario"></asp:ListBox>
                            </div>
                        </td>
                    </tr>
                </table>
                <table class="tblExportFilterArea" border="0">
                    <tr>
                        <td style="width: 100%">
                            <table id='tblRegioes' border="0">
                                <tr>
	                                <td valign="top" style="width: 35%">
	                                    <asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, TipoLoja, "Tipo de Loja" %>' />:
	                                    <asp:CheckBoxList RepeatDirection="Horizontal" RepeatColumns="2" RepeatLayout="Table" DataTextField="TipoLoja" DataValueField="IdTipoLoja" style="width:100%" runat="Server" ID="chkTipoLoja"></asp:CheckBoxList>
	                                    <asp:Literal runat="Server" ID="ltScriptTipoLoja"></asp:Literal>
	                                </td>
                                        <td rowspan = "4" valign="top" style="width: 30%">
                                        Campos a serem exportados:<br />
				                        <asp:ListBox SelectionMode="Multiple" DataTextField="CamposExportar" DataValueField="IdCamposExportar" height="350" width="100%" runat="Server" ID="lstCampExp" CssClass="formulario"></asp:ListBox>
                                        </td>
	                                <td style="width: 678px">
		                                <asp:Literal ID="Literal3" runat="Server" Text='<%$Settings: Caption, Regiao, "Região"%>' />:
                                        <asp:CheckBoxList RepeatDirection="Horizontal" DataTextField="Regiao" RepeatColumns="3" DataValueField="IdRegiao" style="width:5
                                            0%" runat="Server" ID="chkRegiao"></asp:CheckBoxList>
                                        <asp:Literal runat="Server" ID="ltScriptRegiao"></asp:Literal>
	                                </td>
                                </tr>
                                <tr>
                                    <td valign="top" id='StatusLoja' style="width: 35%">
                                        Status da Loja:<br />
                                        <asp:RadioButtonList runat="server" ID="rdStatus">
                                            <asp:ListItem Text="Todas" Value="2" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 678px">
                                        Justificativas:<br />
				                        <asp:ListBox SelectionMode="Multiple" DataTextField="TipoJustificativa" DataValueField="IdTipoJustificativa" runat="Server" ID="lstJustificativa"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 35%">
                                        Per&iacute;odo:<br />
										De&nbsp;<asp:TextBox runat="Server" MaxLength="10" CssClass="formulario" id="txtDataInicial" name="txtDataInicial" onkeydown="FormataData(this, event);" onblur="VerificaData(this);" Width="80px"></asp:TextBox>
                                        <cc1:CalendarExtender 
                                            ID="cal_txtDataInicial" 
										    runat="server" 
										    TargetControlID="txtDataInicial"
										    PopupPosition="Right"
										    PopupButtonID="imgCalendarInicial"
										    Format="dd/MM/yyyy"
										    Animated="true">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" />
                                        <font class="content_text">&nbsp;até&nbsp;</font><asp:TextBox runat="Server" MaxLength="10" CssClass="formulario" id="txtDataFinal" name="txtDataFinal" onkeydown="FormataData(this, event);" onblur="VerificaData(this);" Width="80px"></asp:TextBox>
                                        <cc1:CalendarExtender 
                                            ID="cal_txtDataFinal" 
										    runat="server" 
										    TargetControlID="txtDataFinal"
										    PopupPosition="Right"
										    PopupButtonID="imgCalendarFinal"
										    Format="dd/MM/yyyy"
										    Animated="true">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" />
                                    </td>
                                    <td rowspan="2" valign="bottom" style="width: 678px">
				                        UF:<br />
				                        <div class='divUF'>
				                        <asp:CheckBoxList RepeatColumns='8' RepeatDirection="Horizontal" Runat="server" ID="chkEstado">
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
				                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35%">
                                        <asp:RadioButtonList runat="server" ID="rdTabela" AutoPostBack='true'>
                                            <asp:ListItem Text="Apenas tabela de visita" Value="0" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Tabela de visitas e de produtos" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class='AreaBotoes'>
                    <asp:Button runat='server' id='btnBuildReport' CssClass="Botao" Text=" Exportar " />
                    <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
                </div>
                <div id='divErros'>
                    <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
                    <asp:ValidationSummary runat='server' ID='valSummary' />
                    <asp:Label runat="server" ID="ltDescricao"></asp:Label>
                </div>
            </ContentTemplate>
		</asp:UpdatePanel>
        <asp:UpdatePanel runat='server' ID='pnlUpdate'>
        </asp:UpdatePanel>
        <script type='text/javascript'>
        
            
        function XM_RadioButtonValue_Tabelas() { 
			    var m_Value = '';
			    var vradProdutos = document.getElementById('ctl00_ContentPlaceHolder1_rdTabela_1');
                if (vradProdutos.checked)
                    m_Value = '1';
                else
                    m_Value = '0';
                return m_Value;   
        }
       

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
		    
        function XM_GetValues(vList) { 
			    var m_Values = '';
			    for (var i=0; i < vList.options.length; i++) 
			    { 
				    if(vList.options[i].selected == true)
				    {
					    if(m_Values!='') m_Values += ',';
					    m_Values += vList.options[i].value;
				    }
			    }
				//if (m_Values != '') {m_Values = Left(m_Values, m_Values.length - 1)};
				return m_Values;
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
				    if (m_Value != '') m_Value = Left(m_Value, m_Value.length -1 );
				    return m_Value;
			    }

			    function Export() {

                    var p_IdCliente = XM_GetValues(document.getElementById('<%=lstClientes.ClientID%>'));
                    var p_IdLoja = XM_GetValues(document.getElementById('<%=lstLojas.ClientID%>'));
                    
                    var p_IdCategoria = XM_GetValues(document.getElementById('<%=lstCategoria.ClientID%>'));
                    var p_IdSubCat = XM_GetValues(document.getElementById('<%=lstSubCategoria.ClientID%>'));
                    var p_IdProduto = XM_GetValues(document.getElementById('<%=lstProduto.ClientID%>'));

                    var p_IdUsuarios = XM_GetValues(document.getElementById('<%=lstSuperior.ClientID%>'));

                    var p_IdShopping = XM_GetValues(document.getElementById('<%=lstShopping.ClientID%>'));
                    var p_idJustificativa = XM_GetValues(document.getElementById('<%=lstJustificativa.ClientID%>'));;
    								
			        var p_Estado        = XM_RadioButtonValue_Estados();
				    var p_TipoLoja      = XM_RadioButtonValue_TipoLoja();
				    var p_Regiao        = XM_RadioButtonValue_Regiao();
				    var p_Status        = XM_RadioButtonValue_Status();

				    //alert('');
    				
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

					    //var URL = 'exportardet2.aspx?cli=' + p_IdCliente;
					    var URL = '../cadastros/export/export2.aspx?cli=' + p_IdCliente;
					    //var URL = '../cadastros/export/exportdet.aspx?cli=' + p_IdCliente;
                        URL += '&tab=' + XM_RadioButtonValue_Tabelas();
                        if (p_IdLoja != "") URL += '&loj=' + p_IdLoja;
                        if (p_IdPromotor != "") URL += '&pro=' + p_IdPromotor;
                        if (p_IdSubCat != "") URL += '&sub=' + p_IdSubCat;
                        if (p_IdCategoria != "") URL += '&cat=' + p_IdCategoria;
                        if (p_IdProduto != "") URL += '&prd=' + p_IdProduto;
                        if (p_IdCoordenador != "") URL += '&crd=' + p_IdCoordenador;
                        if (p_IdLider != "") URL += '&lid=' + p_IdLider;
                        if (p_Periodo != "") URL += '&per=' + p_Periodo;
                        if (p_PeriodoText != "") URL += '&pertxt=' + p_PeriodoText;
                        if (p_TipoLoja != "") URL += '&tiploj=' + p_TipoLoja;
                        if (p_Regiao != "") URL += '&regiao=' + p_Regiao;
                        if (p_Status != "") URL += '&sta=' + p_Status;
                        if (p_Estado != "") URL += '&est=' + p_Estado;
                        if (p_idJustificativa != "") URL += '&jus=' + p_idJustificativa;
                        if (p_IdShopping != "") URL += '&shop=' + p_IdShopping;
    														    
				        //var win = window.open(URL, 'EXPORTAR', 'location = no, toolbar = yes, scrollbars = no, width=400, height=300, resize = yes');
				        var win = window.open(URL, 'EXPORTAR');

				    }


				    function openReport(p_Guid, p_ReportName) {

				        var win = window.open('rptShowReport.aspx?repId=' + p_Guid, p_ReportName, 'width=450, height=300, scrollbars=yes');
			            win.focus();
				    }
            
           
        </script>
    </div> 
   
</asp:Content>

