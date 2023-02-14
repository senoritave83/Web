<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TesteFreezeTable.aspx.vb" Inherits="TesteFreezeTable" %>

<%@ Register Assembly="Controls" Namespace="Tittle.Controls" TagPrefix="Tittle" %>
<%@ Register src="~/controls/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
	    <asp:UpdatePanel runat='server' ID='pnuRoteiro'>
	        <ContentTemplate>
                <div class='EditArea'>
	                <table width='98%' id='tblEditArea'>
                        <tr class="trEditHeader">
			                <td colspan='4'>&nbsp;</td>
			            </tr>	    
		                <tr class='trField'>
				            <td class='tdFieldHeader' style="width:180px;text-align:right;">
				                <b>Roteiro para o promotor:</b>
			                </td>
			                <td class='tdField' colspan='3'>
				                <asp:Label runat='server' ID='lblPromotor' />
			                </td>
		                </tr>
		                <tr class='trField'>
				            <td class='tdFieldHeader' style="width:180px;text-align:right;">
				                <b>Periodo:</b>
			                </td>
		                    <td class='tdField' width='400'>
					            De&nbsp;<asp:TextBox runat='server' maxlength="10" cssclass="form_text" id="txtDataInicial" onKeyUp="fncDataAlterada()" onkeydown="FormataData(this, event);" onblur="VerificaData(this);valida_data();" />
					            <asp:RequiredFieldValidator ValidationGroup='VisualizarRoteiro' ID="RequiredFieldValidator1" runat='server' ControlToValidate='txtDataInicial' Display="Dynamic" Text='*' ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <cc1:CalendarExtender  ID="Cal_txtDataInicial" 
													            runat="server" 
													            TargetControlID="txtDataInicial"
													            PopupPosition="Right"
													            PopupButtonID="imgCalendarInicial"
													            Format="dd/MM/yyyy"
													            />
							            <asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" width="5%" />					
					            <font class="content_text">&nbsp;até&nbsp;</font>
					            <asp:TextBox runat='server' maxlength="10" cssclass="form_text" id="txtDataFinal" onKeyUp="fncDataAlterada()" onkeydown="FormataData(this, event);" onblur="VerificaData(this);valida_data();" />
					            <asp:RequiredFieldValidator ValidationGroup='VisualizarRoteiro' ID="RequiredFieldValidator2" runat='server' ControlToValidate='txtDataFinal' Display="Dynamic" Text='*' ErrorMessage="*"></asp:RequiredFieldValidator>
					            <cc1:CalendarExtender  ID="Cal_txtDataFinal" 
													            runat="server" 
													            TargetControlID="txtDataFinal"
													            PopupPosition="Right"
													            PopupButtonID="imgCalendarFinal"
													            Format="dd/MM/yyyy"
													            />
					            <asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" width="5%"/>	
		                    </td>
		                    <td>
					            <asp:Button runat='server' ID='btnFiltrar' Text='Visualizar Roteiro' ValidationGroup='VisualizarRoteiro' />
		                    </td>
		                    <td>
                                <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter='0' runat="Server" AssociatedUpdatePanelID="pnuRoteiro">
                                    <ProgressTemplate>
                                        <div class="progress">
                                            <img id="Img1" runat="server" src="~/imagens/ajax-loader.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>  
		                    </td>
		                </tr>
		            </table>
	            </div>
                <div id='RoteiroPeriodo' >
                <asp:PlaceHolder runat='server' ID='plhRoteiro' Visible='false'>
                    <h4>Lojas do promotor (<asp:Label runat='server' ID='lblNumeroLojas'></asp:Label>)</h4>
                    <Tittle:CustomDataGrid id="dgTittle3" 
                            FreezeHeader="true"
							runat="server" 
							GridHeight="200"
							GridWidth="250"
							FreezeColumns="2"
							AutoGenerateColumns="false">
                            <Columns>
							    <asp:TemplateColumn HeaderText="Lojas" >
								    <ITEMTEMPLATE>
									    <%# eval("IDLoja") & " - " & Eval("Loja").ToString().Trim()%><input type='hidden' name='IdLoja' value='<%# eval("IDLoja") %>' />
								    </ITEMTEMPLATE>
							    </asp:TemplateColumn>
							    <asp:TemplateColumn HeaderText="Grade"  HeaderStyle-HorizontalAlign=Right  >
								    <ITEMTEMPLATE>
									    <asp:Label Runat="server"   ID="Textbox1" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>'  />
								    </ITEMTEMPLATE>
							    </asp:TemplateColumn>
							    <asp:TemplateColumn HeaderText="Address"  HeaderStyle-HorizontalAlign=Right  ItemStyle-Wrap=False >
								    <ITEMTEMPLATE>
									    <asp:Label Runat="server"  ID="Label2" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'  />
								    </ITEMTEMPLATE>
							    </asp:TemplateColumn>
						</Columns> 	
                    </Tittle:CustomDataGrid>
                    <div style="width:815px;height:300px;overflow:auto;">
                    <table cellpadding='0' cellspacing='0' border='0'>
                        <asp:Repeater runat='server' ID='rptLojas'>
                        <HeaderTemplate>
                            <tr>
                              <td width='300'style="width:300px;" rowspan='3' colspan='2' class='Roteiro_LojaHeader'>
                                <img id="Img2" runat="server" src="~/imagens/pt.gif" width="200" height="1"/><center>Lojas</center>
                              </td>
                                <asp:Repeater runat='server' ID='rptDias' DataSource='<%# getDias() %>'>
                                    <ItemTemplate>
                                        <td class='Roteiro_Dia' colspan='2'>
                                            <%#FormatDateTime(Container.DataItem, 2)%>
                                            <br />
                                            <%#Replace(WeekdayName(Weekday(Container.DataItem)), "-feira", "")%>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <td class='Roteiro_DiaAlt' colspan='2'>
                                            <%#FormatDateTime(Container.DataItem, 2)%>
                                            <br />
                                            <%#Replace(WeekdayName(Weekday(Container.DataItem)), "-feira", "")%>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tr>
                            <tr></tr>
                            <tr>
                                <asp:Repeater runat='server' ID='Repeater1' OnItemDataBound="CarregaCombo" DataSource='<%# getDias() %>'>
                                    <ItemTemplate>
                                        <td class='Roteiro_Dia'><input folga='true' grupo='<%# Format(Container.DataItem, "yyyyMMdd")%>' type='checkbox' onclick="javascript:VerificaFolga(this);cboFolga(this);" id='DiaFolga_<%# Format(Container.DataItem, "yyyyMMdd")%>' title='Marcar dia como Folga' name='DiaFolga_<%# Format(Container.DataItem, "yyyyMMdd")%>' <%# IIF(VerificaDiaFolga(Container.DataItem), "checked", "") %> <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(Format(Container.DataItem, "yyyyMMdd") < Format(Now(), "yyyyMMdd"),"disabled","")) %> /></td>
                                        <td class='Roteiro_Dia'>
                                        <table cellspacing=0 >  
                                            <tr>
                                                <td  class='Roteiro_Dia' align='center'>
                                                    Entrada<br />
                                                </td>
                                                <td class='Roteiro_Dia'>&nbsp;</td>
                                                <td  class='Roteiro_Dia' align='center'>
                                                    Saída<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class='Roteiro_Dia' align='center' colspan="3">&nbsp;
                                                    <asp:Literal runat=server ID=ltTeste></asp:Literal>
                                                </td>                                                  
                                            </tr>
                                        </table>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id='tr_<%# eval("IDLoja") %>'>
                                <td class='Roteiro_Loja' style="text-wrap:none;width:300px;"><%# eval("IDLoja") & " - " & Eval("Loja").ToString().Trim()%><input type='hidden' name='IdLoja' value='<%# eval("IDLoja") %>' /></td>
                                <td class='Roteiro_Loja'>
                                    <asp:ImageButton ID="ImageButton2" runat='server' CommandName="RetirarLoja" Visible='<%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "false", Eval("Deletable")) %>' CommandArgument='<%#eval("IDLoja") %>' ImageUrl="~/imagens/Excluir.gif" AlternateText="Excluir loja do Roteiro" />
                                </td>
                                <asp:Repeater runat='server' ID='rptDias' OnItemDataBound="rptDias_ItemDataBound" DataSource='<%# GetDiasLoja(eval("IDLoja")) %>'>
                                    <ItemTemplate>
                                        <td class='Roteiro_Loja' id="tdDia" runat="server">
                                            <input type="hidden" grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' id='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' />
                                            <input type="checkbox" folga='false' grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' title='Realizar pesquisa neste dia'  <%# IIF(DataBinder.Eval(Container.DataItem, "Pesquisa") = True, "checked", "") %> /><br />
                                            <img runat='server' id="imgCopiarHorarios" /><br />
                                        </td>
                                        <td class='Roteiro_Loja' id="td1" runat="server">
                                            <table cellspacing=0>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Visita" OnMouseOver="this.style.cursor='default'">V</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>' <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> <%# IIF(DataBinder.Eval(Container.DataItem, "DiaFolga") = true, "checked","") %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraInicio")%>' name='HoraInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' /><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraFim")%>' name='HoraFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Almoço" onmouseover="this.style.cursor='default'">A</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoInicio")%>' name='HoraAlmocoInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoFim")%>' name='HoraAlmocoFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <td class='Roteiro_LojaDia' id="tdDia" runat="server">
                                            <input type="hidden" grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' id='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' />
                                            <input type="checkbox" folga='false' grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' title='Realizar pesquisa neste dia' <%# IIF(DataBinder.Eval(Container.DataItem, "Pesquisa") = True, "checked", "") %> /><br />
                                            <img runat='server' id="imgCopiarHorarios" /><br />
                                        </td>
                                        <td class='Roteiro_LojaDia' id="td1" runat="server">
                                            <table cellspacing=0>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Visita" OnMouseOver="this.style.cursor='default'">V</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>' <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> <%# IIF(DataBinder.Eval(Container.DataItem, "DiaFolga") = true, "checked","") %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraInicio")%>' name='HoraInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' /><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraFim")%>' name='HoraFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Almoço" onmouseover="this.style.cursor='default'">A</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoInicio")%>' name='HoraAlmocoInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoFim")%>' name='HoraAlmocoFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tr>                
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr id='tr_<%# eval("IDLoja") %>'>
                                <td class='Roteiro_LojaAlt'><%# eval("IDLoja") & " - " & Eval("Loja")%><input type='hidden' name='IdLoja' value='<%# eval("IDLoja") %>' /></td>
                                <td class='Roteiro_LojaAlt'>
                                    <asp:ImageButton ID="ImageButton1" runat='server' Visible='<%# Eval("Deletable") %>' CommandName="RetirarLoja" CommandArgument='<%#eval("IDLoja") %>' ImageUrl="~/imagens/Excluir.gif" AlternateText="Excluir loja do Roteiro" />
                                </td>
                                <asp:Repeater runat='server' ID='rptDias' OnItemDataBound="rptDias_ItemDataBound" DataSource='<%# GetDiasLoja(eval("IDLoja")) %>'>
                                    <ItemTemplate>
                                        <td class='Roteiro_LojaAlt' id="tdDia" runat="server">
                                            <input type="hidden" grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' id='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' />
                                            <input type="checkbox" folga='false' grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' title='Realizar pesquisa neste dia' <%# IIF(DataBinder.Eval(Container.DataItem, "Pesquisa") = True, "checked", "") %> /><br />
                                            <img runat='server' id="imgCopiarHorarios" /><br />
                                        </td>
                                        <td class='Roteiro_LojaAlt' id="td1" runat="server">
                                            <table cellspacing=0>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Visita" OnMouseOver="this.style.cursor='default'">V</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>' <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> <%# IIF(DataBinder.Eval(Container.DataItem, "DiaFolga") = true, "checked","") %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraInicio")%>' name='HoraInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' /><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraFim")%>' name='HoraFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Almoço" onmouseover="this.style.cursor='default'">A</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoInicio")%>' name='HoraAlmocoInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoFim")%>' name='HoraAlmocoFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <td class='Roteiro_LojaDiaAlt' id="tdDia" runat="server">
                                            <input type="hidden" grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' id='hid_Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' />
                                            <input type="checkbox" folga='false' grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' name='Dia_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' value='<%#DataBinder.Eval(Container.DataItem, "IDLoja")%>' title='Realizar pesquisa neste dia' <%# IIF(DataBinder.Eval(Container.DataItem, "Pesquisa") = True, "checked", "") %> /><br />
                                            <img runat='server' id="imgCopiarHorarios" /><br />
                                        </td>
                                        <td class='Roteiro_LojaDiaAlt' id="td1" runat="server">
                                            <table cellspacing=0>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Visita" OnMouseOver="this.style.cursor='default'">V</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>' <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> <%# IIF(DataBinder.Eval(Container.DataItem, "DiaFolga") = true, "checked","") %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraInicio")%>' name='HoraInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' /><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraFim")%>' name='HoraFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class='Roteiro_Loja'>
                                                        <a title="Horário de Almoço" onmouseover="this.style.cursor='default'">A</a><input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoInicio")%>' name='HoraAlmocoInicio_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                    <td class='Roteiro_Loja'>
                                                        <input selecionado='<%#IIF(DataBinder.Eval(Container.DataItem, "Selecionado")="2","2", "1") %>'  <%# IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", IIF(DataBinder.Eval(Container.DataItem, "Data") < Now.AddDays(-1),"disabled", IIF(VerificaDiaFolga(DataBinder.Eval(Container.DataItem, "Data")), "disabled", ""))) %> grupo='<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>' type='text' style="width:72px;" maxlength='5' size='4' onblur='hora_out(this);hours_between(this);' onkeypress="mascaraHora(this,hora)" value='<%# DataBinder.Eval(Container.DataItem, "HoraAlmocoFim")%>' name='HoraAlmocoFim_<%# DataBinder.Eval(Container.DataItem, "IdLoja")%>_<%# Format(DataBinder.Eval(Container.DataItem, "Data"), "yyyyMMdd")%>'/><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width:1px;">&nbsp;</td>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    </table>
                    </div>
                    <asp:PlaceHolder runat='server' ID='plhImportarRoteiro' Visible='false'>
                        <div id='ImportRoteiro'>
                            <asp:UpdatePanel runat='server' ID='pnlImportarRoteiro'>
                                <ContentTemplate>
                                    <br />
                                    <table style='width:815px;'>
                                        <tr>
                                            <td class='Roteiro_Loja' colspan='5' style="text-align:center;"><h4>Copiar Roteiro</h4></TD>
                                        </tr>
                                        <tr class='trField'>
		                                    <td class='Roteiro_Loja' style="width:130px;text-align:right;">
		                                        <b>Data Inicial Cópia:</b>
	                                        </td>
                                            <td class='Roteiro_Loja' style="text-align:left;" >
			                                    <asp:RequiredFieldValidator ValidationGroup='valCopiarRoteiro' ID="reqtxtImportDataInicial" runat='server' ControlToValidate='txtImportDataInicial' Display="Dynamic" Text='*' ErrorMessage="Data Inicial Cópia"></asp:RequiredFieldValidator>
			                                    <asp:TextBox runat='server' maxlength="10" cssclass="form_text" id="txtImportDataInicial" onkeydown="FormataData(this, event);" AutoPostBack="true" />
			                                    <cc1:CalendarExtender  ID="CalendarExtender1" 
													            runat="server" 
													            TargetControlID="txtImportDataInicial"
													            PopupPosition="Right"
													            PopupButtonID="imgCalDataInicialImport"
													            Format="dd/MM/yyyy"
            													
													            />
							            <asp:ImageButton ID="imgCalDataInicialImport" runat="server" ImageUrl="~/imagens/Calendario.png" />					
                                            </td>
		                                    <td class='Roteiro_Loja' style="width:130px;text-align:right;">
		                                        <b>Data Final Cópia:</b>
	                                        </td>
                                            <td class='Roteiro_Loja' style="text-align:left;" >
			                                    <asp:RequiredFieldValidator ValidationGroup='valCopiarRoteiro' ID="reqtxtImportDataFinal" runat='server' Display='Dynamic' ControlToValidate='txtImportDataFinal' Text='*' ErrorMessage="Data Final Cópia"></asp:RequiredFieldValidator>
			                                    <asp:TextBox runat='server' maxlength="10" cssclass="form_text" id="txtImportDataFinal" />
			                                    <cc1:CalendarExtender  ID="CalendarExtender2" 
													            runat="server" 
													            TargetControlID="txtImportDataFinal"
													            PopupPosition="Right"
													            PopupButtonID="imgCalDataFinalImport"
													            Format="dd/MM/yyyy"
            													
													            />
							            <asp:ImageButton ID="imgCalDataFinalImport" runat="server" ImageUrl="~/imagens/Calendario.png" />					
                                            </td>
                                        </tr>
                                        <tr class='Roteiro_Loja' >
                                            <td class='tdFieldHeader' style="width:130px;text-align:right;">
		                                        <b>Copiar para o Promotor:</b>
	                                        </td>
                                            <td class='Roteiro_Loja' colspan='3' style="text-align:left;" >
                                                <asp:CompareValidator ID="CompareValidator1" runat='server' ValidationGroup='valCopiarRoteiro' ControlToValidate='cboIdPromotor' ValueToCompare='0' Operator='GreaterThan' Display='Dynamic' Text='*' ErrorMessage="Copiar para o Promotor"></asp:CompareValidator>
                                                <asp:DropDownList runat="server" ID="cboIDPromotor" DataTextField="Promotor" DataValueField="IDPromotor" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div> 
                        <br class='cb' />
                    </asp:PlaceHolder>
                
                    <div class='AreaBotoes'>
                        <asp:Button runat='server' OnClientClick="return confirm('Confirma a gravação do roteiro ?');" ValidationGroup='valGravar' ID='btnGravar' Text="Gravar" CssClass='Botao' />
                        <asp:Button runat='server' ID='btnImportRoteiro' Text='Copiar Roteiro' />
                        <asp:CustomValidator ID="CustomValidator1"  runat='SERVER' ValidationGroup='valCopiarRoteiro' OnServerValidate="validacaoDatasCopiaRoteiro" Display=Dynamic ErrorMessage="O periodo entre as datas deve ser igual ao periodo de origem"></asp:CustomValidator>
			            <asp:Button runat='server' ValidationGroup='valCopiarRoteiro' ID='btnConfirmar' Text='Confirmar' Visible='false' />    
			            <asp:Button runat='server' CausesValidation='false' ID='btnCancelarCopiaRoteiro' Text='Cancelar'  Visible='false' />    
			            <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
                    </div>
            </asp:PlaceHolder>
            </div>
            <asp:PlaceHolder runat='server' ID='plhLojas'>
                <div id='divLojasRoteiro'>                    
                    <table>
                        <tr>
                            <td id='tdProcurar' style="width:200" >
                                <h4>Procurar lojas</h4><asp:TextBox style="width:200" runat='server' ID='txtProcurarLoja' />
                            </td>
                            <td id='tdProcurar' style="width:200" >
                                <h4>Cidade</h4><asp:TextBox style="width:200" runat='server' ID='txtProcurarCidade' />
                            </td>
                            <td>
                                <h4>UF</h4>
                                <p>
                                    <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
                                </p>
                            </td>
                            <td>
                                <h4>Tipo de loja</h4>
                                <p>
                                    <asp:DropDownList runat="server" ID="cboIDTipoLoja" DataTextField="TipoLoja" DataValueField="IDTipoLoja" />
                                </p>
                            </td>
                            <td>
                                <h4>Região</h4>
                                <p>
                                    <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" />                                            
                                </p>
                            </td>
                            <td>
                                <h4 style="color:'#F5F5A0';">.</h4>
                                <p>
                                    <asp:Button runat='server' ID='btnProcurar' Text='Procurar loja' />
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:UpdatePanel runat='server' ID='pnlLojasUpdate'>
                                    <ContentTemplate>
                                        <asp:GridView runat='server' ID='grdProcurar' Width='100%' SkinID='GridInterno' DataKeyNames='IDLoja' AutoGenerateColumns='false' AllowSorting="true">
                                            <Columns>  
                                                <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' SortExpression='Codigo' />
                                                <asp:BoundField HeaderText='Loja' DataField='Loja' SortExpression='Loja' />                                                
                                                <asp:BoundField HeaderText='Cidade' DataField='Cidade' SortExpression='Cidade' />
                                                <asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
                                                <asp:BoundField HeaderText="Tipo de Loja" DataField="TipoLoja" SortExpression="TipoLoja" />
                                                <asp:BoundField HeaderText="Regi&atilde;o" DataField="Regiao" SortExpression="Regiao" />
                                                <asp:ButtonField CommandName='AdicionarLoja' ButtonType='Image' ImageUrl="~/imagens/set-pb.gif" />
                                            </Columns>
                                        </asp:GridView>
                                        <uc1:Paginate ID="Paginate1" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdateProgress DisplayAfter="500" ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="pnlLojasUpdate">
                    <ProgressTemplate>
                        <div class="progress">
                            <img src="../../imagens/ajax-loader.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                        </div>
                    </ProgressTemplate>
                    </asp:UpdateProgress>
                </div> 
                <br class='cb' />
            </asp:PlaceHolder>
            </ContentTemplate>
	    </asp:UpdatePanel>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' DisplayMode='List' />
        <asp:ValidationSummary runat='server' ID='valSummaryCopia'  HeaderText="Informe corretamente os campos abaixo:" ValidationGroup="valCopiarRoteiro" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li><b>Gravar: Grava as altera&ccedil;&otilde;es efetuadas no banco.</li>
            <li><b>Copiar Roteiro: Abre a tela com opção de cópia de roteiro para outro promotor.</b></li>
		    <li><b>Voltar: Volta para o menu anterior..</b></li>   
        </ul>
    </div>
			<script type='text/javascript'>
	        var folga = false;
	        function CopiarHorarios(vIdLoja, vDataInicial, vGrupo)
	        {
	            
                var tr = document.getElementById("tr_" + vIdLoja);
	            var inputs = tr.getElementsByTagName("input");
	            	            
	            //alert(vGrupo);
	            
	            //return;
	            
	            var blnHoraInicio = false;
	            var vHoraInicial;
	            
	            var j = 0;
                
	            for (var i = inputs.length - 1; i>= 0; i--)
	            {
                    if(inputs[i].grupo != null)
                    {
	                    if (inputs[i].grupo == vGrupo)
	                    {                    	                    
	                        blnHoraInicio = true; 
	                    }
                        if (inputs[i].grupo != vGrupo && blnHoraInicio == true)
	                    {                    	                    
	                        var txtHI = document.getElementById("HoraInicio_" + vIdLoja + "_" + inputs[i].grupo);
	                        var txtHF = document.getElementById("HoraFim_" + vIdLoja + "_" + inputs[i].grupo);
	                        var txtHIA = document.getElementById("HoraAlmocoInicio_" + vIdLoja + "_" + inputs[i].grupo);
	                        var txtHFA = document.getElementById("HoraAlmocoFim_" + vIdLoja + "_" + inputs[i].grupo);
	                        
	                        if(txtHI.value != '' && txtHF.value != '')
	                        {
	                            document.getElementById("HoraInicio_" + vIdLoja + "_" + vGrupo).value = txtHI.value;
	                            document.getElementById("HoraFim_" + vIdLoja + "_" + vGrupo).value = txtHF.value;
	                            document.getElementById("HoraAlmocoInicio_" + vIdLoja + "_" + vGrupo).value = txtHIA.value;
	                            document.getElementById("HoraAlmocoFim_" + vIdLoja + "_" + vGrupo).value = txtHFA.value;
	                            break;
	                        }

	                    }
                    }

	            }
	            	            
	        }
	        
	    
	       function VerificaFolga(vSource)
	        {
	            
                var blnChecked = vSource.checked;
                var vGrupo = vSource.grupo
                var form = document.forms[0];
                var p_Fixo = 1; /*
                                VARIAVEL QUE VERIFICA SE EXISTE ALGUM CAMPO TEXTO
                                QUE PERTENCE A UM ROTEIRO CRIADO NA TELA
                                ROTEIRO.ASPX
                                1 = LIVRE
                                2 = FIXO
                                */

				for (var i=0;i<form.elements.length;i++)
				{
					var e = form.elements[i];
					
					if(e.grupo != null)
					{
					
					    var strGrupo = e.grupo;
					    					        					
					    if (e.type == 'text' && strGrupo == vGrupo)
					    {
                            var selecionado = e.selecionado;
                            if(selecionado=='2') 
                                p_Fixo = 2;
                            else
                            {
						        e.value = '';
						        e.disabled = blnChecked;
                            }
					    }
					    else if (e.type == 'checkbox' && strGrupo == vGrupo)
					    {
                            if(e.folga=='true')
                                e.checked = blnChecked;
                            else
                                e.disabled = blnChecked;

					    }
					
					}

				}
				if(p_Fixo=='2')
				{
				    alert('Existem alguns roteiros que são fixos e não podem ser alterados.\nVerifique os períodos fixos na tela de roteiros.\nSe for marcado como folga, o dia ficará indisponível para o promotor no momento de carregar o roteiro.');
				}
	        
	        }
	    
	        function selecionaTudo(vIDLoja)
	        {
	            var form = document.forms[0];
	            for (var iField = 0; iField < form.length; iField++) {
				    var field = form.elements(iField);
				    if (field.value == vIDLoja) {
				        field.checked = true; 
				    }
			    }
	        }
	        function deselecionaTudo(vIDLoja)
	        {
	            var form = document.forms[0];
	            for (var iField = 0; iField < form.length; iField++) {
				    var field = form.elements(iField);
				    if (field.value == vIDLoja && field.disabled != true) {
				        field.checked = false;
				    }
			    }
	        }
	        function fncDataAlterada()
	            {
	            var p_Botao = document.getElementById('<%=btnGravar.ClientID %>');
	            if(p_Botao != null)
	                document.forms[0].<%=btnGravar.ClientID %>.disabled=true;
	            var p_BotaoConf = document.getElementById('<%=btnImportRoteiro.ClientID %>');
	            if(p_BotaoConf != null)
	                document.forms[0].<%=btnImportRoteiro.ClientID %>.disabled=true;
	            }
	            
	       		    
		    function mascaraHora(o,f)
		    {
                v_obj=o
                v_fun=f
                setTimeout("execmascara()",1)
            }

            function execmascara(){
                v_obj.value=v_fun(v_obj.value)
            }

                //valida formato de hora 00:00 até 23:59 com mascara
                //er=/^(([01][\d])|([2][0-3]))([0-5][\d])/ //ereg que valida a hora(nao usada aqui)
            function hora(v){
                
                v=v.replace(/\D/g,"") //Remove tudo o que não é dígito
                v=v.replace(/^[^012]/,"") //valida o primeiro dígito #
                v=v.replace(/^([2])([^0-3])/,"$1") //valida o segundo dígito ##
                v=v.replace(/^([\d]{2})([^0-5])/,"$1")//valida o terceiro dígito ###
                v=v.replace(/(\d{2})(\d)/,"$1:$2") //Coloca dois ponto entre o segundo e o terceiro dígitos ##:##
                v=v.substr(0,5) //Remove digitos extras (aceita no max 5 caracteres(contando o ':' no meio) )
                                
                return v
            }
            
            function hora_out(v)
            {
                var vl = v.value;
            
                if(vl.length==1)
                    vl=vl+'0:00';
                else if(vl.length==2)
                    vl=vl+':00';
                else if(vl.length==3)
                    vl=vl+'00';
                else if(vl.length==4)
                    vl=vl+'0';
                    
                return v.value = vl;
            }

            function hours_between(campoorigem)
            {

                var p_obj1 = campoorigem.name.split('_');
                var p_obj2 = null;

                if(p_obj1.length>0)
                {
                    if (p_obj1[0]=='HoraInicio')
                    {
                        p_obj2 = document.getElementById('HoraFim_' + p_obj1[1] + '_' + p_obj1[2]);
                        p_obj1 = document.getElementById('HoraInicio_' + p_obj1[1] + '_' + p_obj1[2]);
                        var hora1 = p_obj1.value;
                        var hora2 = p_obj2.value;
                        if(hora1 !='' && hora2 !='')
                        {
                            //testa se hora1 (Hora Inicio) é maior que hora2 (Hora Fim)
                            if(CompararHoras(hora1, hora2)==false)
                            {
                                p_obj2.value = '' //apaga hora fim
                                alert('Horário de entrada deve ser menor que o horário de saída');
                            }
                        }
                    }
                    else if (p_obj1[0]=='HoraFim')
                    {
                        p_obj2 = document.getElementById('HoraInicio_' + p_obj1[1] + '_' + p_obj1[2]);
                        p_obj1 = document.getElementById('HoraFim_' + p_obj1[1] + '_' + p_obj1[2]);
                        var hora1 = p_obj1.value;
                        var hora2 = p_obj2.value;
                        if(hora1!='' && hora2 !='')
                        {
                            //testa se hora1 (Hora Fim) é menor que hora2 (Hora Inicio)
                            if(CompararHoras(hora1, hora2)==true)
                            {
                                p_obj1.value = '' //apaga hora fim
                                alert('Horário de entrada deve ser menor que o horário de saída');
                            }
                        }
                    }
                    else if (p_obj1[0]=='HoraAlmocoInicio')
                    {
                        p_obj2 = document.getElementById('HoraAlmocoFim_' + p_obj1[1] + '_' + p_obj1[2]);
                        p_obj1 = document.getElementById('HoraAlmocoInicio_' + p_obj1[1] + '_' + p_obj1[2]);
                        var hora1 = p_obj1.value;
                        var hora2 = p_obj2.value;
                        if(hora1 !='' && hora2 !='')
                        {
                            //testa se hora1 (Hora Inicio) é maior que hora2 (Hora Fim)
                            if(CompararHoras(hora1, hora2)==false)
                            {
                                p_obj2.value = '' //apaga hora fim
                                alert('Horário de entrada deve ser menor que o horário de saída');
                            }
                        }
                    }
                    else if (p_obj1[0]=='HoraAlmocoFim')
                    {
                        p_obj2 = document.getElementById('HoraAlmocoInicio_' + p_obj1[1] + '_' + p_obj1[2]);
                        p_obj1 = document.getElementById('HoraAlmocoFim_' + p_obj1[1] + '_' + p_obj1[2]);
                        var hora1 = p_obj1.value;
                        var hora2 = p_obj2.value;
                        if(hora1 !='' && hora2 !='')
                        {
                            //testa se hora1 (Hora Inicio) é maior que hora2 (Hora Fim)
                            if(CompararHoras(hora1, hora2)==true)
                            {
                                p_obj1.value = '' //apaga hora fim
                                alert('Horário de entrada deve ser menor que o horário de saída');
                            }
                        }
                    }
                }
                

            }

            function CompararHoras(sHora1, sHora2) { 
     
                var arHora1 = sHora1.split(":"); 
                var arHora2 = sHora2.split(":"); 
     
                // Obtener horas y minutos (hora 1) 
                var hh1 = parseInt(arHora1[0],10); 
                var mm1 = parseInt(arHora1[1],10); 

                // Obtener horas y minutos (hora 2) 
                var hh2 = parseInt(arHora2[0],10); 
                var mm2 = parseInt(arHora2[1],10); 

                // Comparar 
                if (hh1<hh2 || (hh1==hh2 && mm1<mm2)) 
                    return true;
                else  
                    return false;
            } 
                                    
            function addDate(campo, campo2) 
            {

                var value = campo.value;
                value = value.substring(3, 5) + '/' + value.substring(0, 2) + '/' + value.substring(6);
                var dt = new Date(value);
                var p_DiasEntre = days_between(document.getElementById('<%=txtDataInicial.ClientID %>'), document.getElementById('<%=txtDataFinal.ClientID %>'));
		        //alert(p_DiasEntre);
                if(isNaN(p_DiasEntre)==false)
                {
                    dt.setDate(dt.getDate() + p_DiasEntre);
                    //campo2.value = Right('00' + dt.getDate(), 2) + '/' + Right('00' + (dt.getMonth() + 1), 2) + '/' + dt.getFullYear();
                }
            }

            function days_between(date1, date2) {

                // The number of milliseconds in one day
                var ONE_DAY = 1000 * 60 * 60 * 24

                // Convert both dates to milliseconds

                var date1_vl = date1.value;
                var date2_vl = date2.value;

                date1_vl = new Date(date1_vl.substring(3, 5) + '/' + date1_vl.substring(0, 2) + '/' + date1_vl.substring(6));
                date2_vl = new Date(date2_vl.substring(3, 5) + '/' + date2_vl.substring(0, 2) + '/' + date2_vl.substring(6));
                
                var date1_ms = date1_vl.getTime()
                var date2_ms = date2_vl.getTime()

                // Calculate the difference in milliseconds
                var difference_ms = Math.abs(date1_ms - date2_ms)

                // Convert back to days and return
                return Math.round(difference_ms / ONE_DAY)

            }
            
            function valida_data (){
                if (document.getElementById('<%=txtDataInicial.ClientID %>').value == "" || document.getElementById('<%=txtDataFinal.ClientID %>').value == "")
                {
                    if (document.getElementById('<%=txtImportDataInicial.ClientID %>') != null)
                        document.getElementById('<%=txtImportDataInicial.ClientID %>').value = "";
                    
                    if (document.getElementById('<%=txtImportDataFinal.ClientID %>') != null)
                        document.getElementById('<%=txtImportDataFinal.ClientID %>').value = "";
                }
                    
            }
            
            function cboFolga(vFolga)
            {
                var check = vFolga.checked;
                var p_obj1 = vFolga.name.split('_');
                var folga = document.getElementById('cboFolga_' + p_obj1[1]);
                //document.getElementById('cboFolga_' + p_obj1[1]).value = folga.value;

                if(check == true)
                {
                    folga.disabled = false;
                }
                else
                {
                    folga.disabled = true;
                }
            }

	    </script>
    </b>


</asp:Content>

