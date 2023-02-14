<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Pages.Visita.Visitas" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" >
    </asp:ScriptManager>
    <script type="text/javascript">
        function MapaVendedor(p_Row) {
            var url = 'rota_popup.aspx?IDEmpresa=' + p_Row.IDEmpresa + '&IDVisita=' + p_Row.IDVisita + '&TipoMapa='+ p_Row.TipoMapa;
            //alert(url);
            window.open(url, 'MAPA', 'menubar=0,resizable=0,width=800,height=600');
        }

</script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' Width="455" />
				</div> 
				<br class='cb' />
		        <div class='FiltroItem'>
                    <asp:Literal ID="ltrCoordenador" runat="server" Text='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' /><br>
		            <asp:DropDownList AutoPostBack='true' runat="server" ID="cboIDCoordenador" DataTextField="Coordenador" DataValueField="IDCoordenador" />
		        </div>
                 <div class='FiltroItem'>Mapa<br>
		            <asp:DropDownList runat="server" ID="cboMapa">
                        <asp:ListItem Value="2" Selected="True">Todos</asp:ListItem>
                        <asp:ListItem Value="0">Não</asp:ListItem>
                        <asp:ListItem Value="1">Sim</asp:ListItem>
                    </asp:DropDownList>
		        </div>
                               <div class='FiltroItem' style="width:329px; padding-left:5px">Não mostrar pontos com precisão maior que:<br>
		                        <asp:DropDownList runat="server" ID="drpPrecisao" >
                                    <asp:ListItem Text="Todos" Value=0></asp:ListItem>
                                    <asp:ListItem Text="25 m" Value=25></asp:ListItem>
                                    <asp:ListItem Text="50 m" Value=50></asp:ListItem>
                                    <asp:ListItem Text="100 m" Value=100></asp:ListItem>
                                </asp:DropDownList>
		                    </div>

		        <div class='FiltroItem'>
                    <asp:Literal ID="ltrLider" runat="server" Text='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' /><br>
		            <asp:DropDownList AutoPostBack='true' runat="server" ID="cboIdLider" DataTextField="Lider" DataValueField="IDLider" />
		        </div>
                   <br class='cb' />
		        <div class='FiltroItem'>Promotor<br>
		            <asp:DropDownList runat="server" ID="cboIDPromotor" DataTextField="Promotor" DataValueField="IDPromotor" />
		        </div>
		        <div class='FiltroItem'>Justificativa<br>
		            <asp:DropDownList runat="server" ID="cboIDTipoJustificativa" DataTextField="TipoJustificativa" DataValueField="IDTipoJustificativa" />
		        </div>
                <div class='FiltroItem'>Teste<br>
		            <asp:DropDownList runat="server" ID="cboTeste">
                        <asp:ListItem Value="2" Selected="True">Todos</asp:ListItem>
                        <asp:ListItem Value="0">Não</asp:ListItem>
                        <asp:ListItem Value="1">Sim</asp:ListItem>
                    </asp:DropDownList>
		        </div>
                
		        <br class='cb' />
		        <div class='FiltroItem' style="width:400px;">Data<br>
						<asp:TextBox onkeydown="FormataData(this, event);" onblur="VerificaData(this);" runat='server' ID='txtDataInicial' MaxLength="10" />
						<cc1:CalendarExtender  ID="cal_txtDataInicial" 
													runat="server" 
													TargetControlID="txtDataInicial"
													PopupPosition="Right"
													PopupButtonID="imgCalendarInicial"
													Format="dd/MM/yyyy"
													/>
										<asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicioInicial' Display='None' ErrorMessage='DataInicio inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
		        		ate
						<asp:TextBox onkeydown="FormataData(this, event);" onblur="VerificaData(this);" runat='server' ID='txtDataFinal' MaxLength="10" />
						<cc1:CalendarExtender ID="cal_txtDataFinal" 
													runat="server" 
													TargetControlID="txtDataFinal"
													PopupPosition="Right"
													PopupButtonID="imgCalendarFinal"
													Format="dd/MM/yyyy"
													Animated="true"
													/><asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicioFinal' Display='None' ErrorMessage='DataInicio final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDVisita" DataNavigateUrlFormatString="Visita.aspx?IDVisita={0}" DataTextField="IDVisita" HeaderText="Visita" SortExpression=""  />
                        <asp:BoundField HeaderText="Código" DataField="Codigo" SortExpression="Codigo" />
						<asp:BoundField HeaderText="Loja" DataField="Loja" SortExpression="Loja" />
						<asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' DataField="Coordenador" SortExpression="Coordenador" />
						<asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' DataField="Lider" SortExpression="Lider" />
						<asp:BoundField HeaderText="Promotor" DataField="Promotor" SortExpression="Promotor" />
						<asp:BoundField HeaderText="Data Roteiro" DataField="Data" SortExpression="Data" DataFormatString="{0:dd/MM/yyyy}" />
						<asp:BoundField HeaderText="Justificativa" DataField="TipoJustificativa" SortExpression="TipoJustificativa" />
                       		<asp:TemplateField visible='<%$Settings: visible, Visita.Excluir, false %>'>
						    <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IDVisita") %>'  ImageUrl="~/imagens/lixeira.GIF" ></asp:ImageButton>                               
                                <cc1:ConfirmButtonExtender ID="ConfirmBtExt1" runat="server" TargetControlID="imgDelete" ConfirmText="Tem certeza que deseja excluir essa visita ?"></cc1:ConfirmButtonExtender>
						    </ItemTemplate>
						</asp:TemplateField>
                        <asp:TemplateField HeaderText="Mapa">
								<ItemTemplate>
										<a Style="cursor:hand;" OnClick='javascript:MapaVendedor(this);' IDVisita='<%#Eval("IDVisita")%>' IDEmpresa='<%#Eval("IDEmpresa")%>' TipoMapa='<%#Eval("TipoMapa")%>' ><img id="Img1" src='http://maps.google.com/mapfiles/kml/pal3/icon30.png' Visible='<%#IIf(Container.DataItem("TipoMapa") > 0, true, false)%>' runat="server" alt='Exibe a rota feita pelo vendedor na visita ao cliente' border='0'></a>
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
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Visita.aspx?idvisita=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Visitas.aspx'" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="updFiltro">
        <ProgressTemplate>
            <div class="progress">
                <img src="../imagens/ajax-loader.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress2" runat="Server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="progress">
                <img src="../imagens/ajax-loader.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>        
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

