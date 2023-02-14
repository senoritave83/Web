<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="rota.aspx.vb" Inherits="Relatorios_rota" %>
<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function MapaVendedor(p_Row) {
        var url = 'rota_popup.aspx?IDEmpresa=' + p_Row.IdEmpresa + '&IDVendedor=' + p_Row.IdVendedor + '&IDCliente=' + p_Row.IdCliente + '&Data=' + p_Row.Data;
        window.open(url, 'MAPA', 'menubar=0,resizable=0,width=800,height=600');
    }
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat='server' ID='updFiltro'>
        <ContentTemplate>
            <table border='0' width='100%' cellspacing='0'>
                <tr>
                    <td valign='top'>
                        <div class='Filtro'>
		                    <div class='FiltroItem' style="float:left;width:100px;padding-left:5px">Grupo<br>
		                        <asp:DropDownList runat="server" ID="cboIdGrupo" DataTextField="Grupo" DataValueField="IDGrupo" />
		                    </div>
		                    <div class='FiltroItem' style="float:left;width:100px;padding-left:5px">Supervisor<br>
		                        <asp:DropDownList AutoPostBack="true" runat="server" ID="cboIDSupervisor" DataTextField="Supervisor" DataValueField="IDSupervisor" />
		                    </div>
		                    <div class='FiltroItem' style="float:left;width:100px;padding-left:5px">Vendedor<br>
		                        <asp:DropDownList runat="server" ID="cboVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
		                    </div>
                            <div>
                                <br />
                                <asp:label runat="server" ID="lblMapaVendedor" Class="ErrorLbl" Visible="false" Text="&nbsp;&nbsp;- Selecione um vendedor para exibir o mapa!" />
                            </div>
		                    <br class='cb' />
		                    <div class='FiltroItem' style="float:left;width:100px;padding-left:5px">Data<br>
						            <asp:TextBox runat='server' ID='txtData' MaxLength="10" Width='80' />
						            <asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtData' Operator='DataTypeCheck' Type='Date' />
						            <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtData" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		                    </div>
				            <div class='FiltroBotao' style="padding-left:5px">
					            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				            </div>
			            </div>
                    </td>
                    <td valign=top >
                        <table cellspacing='1' class='GridHeader' style="margin-top:10px;height:112px;">
                            <tr>
                                <td bgcolor='white' valign=top>
                                    <table bgcolor='white'>
                                        <tr class='GridHeader'><td colspan='2'>Legenda</td></tr>
                                        <tr><td>Primeira Visita</td><td><img src='http://labs.google.com/ridefinder/images/mm_20_blue.png' border='0' /></td></tr>
                                        <tr><td>Visita Efetuada</td><td><img src='http://labs.google.com/ridefinder/images/mm_20_red.png' border='0' /></td></tr>
                                        <tr><td>Visita Pendente</td><td><img src='http://labs.google.com/ridefinder/images/mm_20_yellow.png' border='0' /></td></tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width='100%' border='0'>
                <tr>
                    <td width='100%'>
                        <cc1:XMMapViewer ID="XMMapViewer1" 
                                Width='100%' 
                                FrameBorder='false'
                                Height='600' 
                                runat="server" 
                                DataLatitudeField="Latitude" 
                                DataLongitudeField="Longitude" 
                                DataDetailsField="Descricao" 
                                DataSequenceField="Sequencia" 
                                DataTextField='Descricao'
                                Title="Rota de Pedidos"
                                ShowLegend="false">
                        <Sequences> 
                            <cc1:XMMapViewerSequence SequenceID='0' ShowMarker='true' ShowLine='false' LineColor='Green'  />
                            <cc1:XMMapViewerSequence SequenceID='1' ShowMarker='true' ShowLine='true' LineColor='Blue' />
                            <cc1:XMMapViewerSequence SequenceID='2' ShowMarker='true' ShowLine='false' LineColor='gainsboro' />
                        </Sequences>
                        </cc1:XMMapViewer>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat='server' id='grdPedidos' AutoGenerateColumns='false' AllowSorting='true' Width='300' SkinID='GridRelatorios'>
				            <HeaderStyle HorizontalAlign='Left' />
					        <columns>
						        <asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" ItemStyle-Wrap='false' />
						        <asp:BoundField FooterStyle-HorizontalAlign="Center" HeaderText="Início" DataField="DataInicio" SortExpression="Data" HeaderStyle-HorizontalAlign='Center' ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Fim" DataField="DataFim" SortExpression="Data" HeaderStyle-HorizontalAlign='Center' ItemStyle-HorizontalAlign="Center" />
						        <asp:BoundField HeaderText="Situação" DataField="Situacao"/>                                
								<asp:TemplateField HeaderText="Ver Mapa">
									<ItemTemplate>
										<a Style="cursor:hand;" OnClick='javascript:MapaVendedor(this);' IdCliente='<%#Eval("IdCliente")%>' IdEmpresa='<%#Eval("IdEmpresa")%>' IdVendedor='<%#Eval("IdVendedor")%>' Data='<%#Eval("DataVisita")%>' ><img src='http://maps.google.com/mapfiles/kml/pal3/icon30.png' Visible='<%#IIf(Container.DataItem("Latitude") = 0 And Container.DataItem("Longitude") = 0, false, true)%>' runat="server" alt='Exibe a rota feita pelo vendedor na visita ao cliente' border='0'></a>
									</ItemTemplate>
								</asp:TemplateField>
					        </columns>
					        <EmptyDataTemplate>
				                <div class='GridHeader'>&nbsp;</div>					    
					            <div class='divEmptyRow'>
							        <asp:Label runat='server' ID='lblNaoEncontrados'>
								        N&atilde;o h&aacute; Visitas com o filtro selecionado!
							        </asp:Label>
					            </div>
					        </EmptyDataTemplate>
				        </asp:GridView>
                    </td>
                </tr>
            </table>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



















