<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="rotalog.aspx.vb" Inherits="Relatorios_rotalog" %>

<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat='server' ID='updFiltro'>
        <ContentTemplate>
            <table border='0' width=100% cellspacing='0'>
                <tr>
                    <td valign=top>
                        <div class='Filtro' style="height:88px;">
		                    <div class='FiltroItem' style="padding-left:5px">Veículo:<br>
		                        <asp:DropDownList runat="server" ID="cboVeiculo" DataTextField="Veiculo" DataValueField="Placa" />
		                    </div>
		                    <div class='FiltroItem' style="width:100px;padding-left:5px">Data:<br>
						            <asp:TextBox runat='server' ID='txtData' MaxLength="10" Width='80' />
						            <asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtData' Operator='DataTypeCheck' Type='Date' />
						            <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtData" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		                    </div>
		                    <div class='FiltroItem' style="width:300px;padding-left:5px">Não mostrar pontos com precisão maior que:<br>
		                        <asp:DropDownList runat="server" ID="drpPrecisao" >
                                    <asp:ListItem Text="Mostrar todos os pontos" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="25 m" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="50 m" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100 m" Value="100"></asp:ListItem>
                                </asp:DropDownList>
		                    </div>
				            <div class='FiltroBotao' style="padding-left:5px">
					            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				            </div>
			            </div>
                    </td>
                    <td valign=top >
                        <table cellspacing='1' class='GridHeader' style="margin-top:10px">
                            <tr>
                                <td bgcolor='white'>
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
            <table border='0' width=100%>
                <tr>
                    <td width='100%'>
                    <cc1:XMMapViewer ID="XMMapViewer1" 
                            Width='100%' 
                            FrameBorder='false'
                            Height='600' 
                            runat="server" 
                            DataLatitudeField="Latitude" 
                            DataLongitudeField="Longitude" 
                            DataDetailsField="Situacao" 
                            DataSequenceField="Sequencia" 
                            DataTextField='Situacao'
                            Title="Rota de Entregas"
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
                    <td valign=top>
                        <br class='cb' />
                    </td>
                </tr>
                <tr>
                    <td>

                    <asp:GridView runat='server' id='grdEntregas' AutoGenerateColumns='false' AllowSorting='true' Width=300>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" ItemStyle-Wrap='false' />
						<asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
                        <asp:BoundField HeaderText="Dist. Percorrida" DataField="DistanciaPercorrida" SortExpression="DistanciaPercorrida" />
                        <asp:TemplateField HeaderText="Difer.">
                            <ItemTemplate>
                                <%# fncDiferencaEntreDatas(Eval("Tempo"), Eval("Data"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Dist. Cliente" DataField="Distancia" SortExpression="Distancia" />
                        <asp:BoundField HeaderText="Status" DataField="StatusEntrega"/>
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



















