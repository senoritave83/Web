<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Pages.Visita.Visitas" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../controls/FiltroSuperior.ascx" tagname="FiltroSuperior" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro' style="height:375px;">
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' Width="455" />
				</div> 
				<br class='cb' />
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
		        <div class='FiltroItem' style="width:425px;">Data<br>
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
		        		at&eacute;
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
                <br class='cb' />
                <div class='FiltroItem' style="width:400px;" id='divPromotores'>
                    <table width="100%" border='1'>
                        <tr>
                            <td><label>Filtragem de Usuários:</label></td>
                        </tr>
		                <tr>
		                    <td>
                                <asp:label  Runat="server" ID="Label3">Status dos usuários:</asp:label><br />
		                        <asp:DropDownList runat="server" ID="cboStatus" AutoPostBack='true'>
		                            <asp:ListItem Value='2' Enabled='true'>Ativos</asp:ListItem>
		                            <asp:ListItem Value='1'>Inativos</asp:ListItem>
		                            <asp:ListItem Value='8'>Todos</asp:ListItem>
		                        </asp:DropDownList>
		                     </td> 
                            <td>
                                <asp:label  Runat="server" ID="Label1">Cargo:</asp:label><br />
		                        <asp:DropDownList DataTextField="Cargo" DataValueField="IDCargo"  Width="150px" style="width:150px;height:20px;"  AutoPostBack='true' runat="server" 
                                ID="drpCargoSuperior" CssClass="Select"></asp:DropDownList>
                            </td>		                     
		                </tr>
                        <tr>
                            <td colspan="2">
                                <asp:label Runat="server" ID="lblCargoNivel1">Usuários:</asp:label><br />
                                <asp:ListBox ID="lstSuperior" 
                                            SelectionMode='Multiple' 
                                            AutoPostBack='true' runat="server" 
                                            DataTextField="Usuario" DataValueField="IDUsuario" 
                                            CssClass="Select"  Width="400px" style="margin-bottom:5px;width:400px;height:150px;" ></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:label Runat="server" ID="Label2">Exibir apenas as pesquisas efetuadas:</asp:label><br />
		                        <asp:DropDownList runat="server" ID="drpTipoSelecao" CssClass="Select" Width="400px" style="width:400px;">
                                    <asp:ListItem Text="Pelo(s) usuário(s) selecionado(s)" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Pelo(s) subordinado(s) do(s) usuário(s) selecionado(s)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Pelo(s) usuário(s) selecionado(s) e subordinado(s) " Value="3"></asp:ListItem>
                                </asp:DropDownList>
                             </td>
                             <td>&nbsp;
                            </td>
                        </tr>
                    </table>                   
                </div>
					<div class='FiltroBotao'>
						<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
					</div>                 
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea' style="margin-left:10px; margin-right:10px; width:80%\9;">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="5" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDVisita" DataNavigateUrlFormatString="Visita.aspx?IDVisita={0}" DataTextField="IDVisita" HeaderText="Visita" SortExpression=""  />
                        <asp:BoundField HeaderText="Código" DataField="Codigo" SortExpression="Codigo" />
						<asp:BoundField HeaderText="Loja" DataField="Loja" SortExpression="Loja" />
						<asp:BoundField HeaderText='Superior' DataField="Superior" SortExpression="Superior" />
						<asp:BoundField HeaderText="Usuário" DataField="Promotor" SortExpression="Promotor" />
						<asp:BoundField HeaderText="Data Visita" DataField="DataInicio" SortExpression="Data" DataFormatString="{0:dd/MM/yyyy}" />
						<asp:BoundField HeaderText="Justificativa" DataField="TipoJustificativa" SortExpression="TipoJustificativa" />

						<asp:TemplateField visible='<%$Settings: visible, Visita.Excluir, false %>'>
						    <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IDVisita") %>'  ImageUrl="~/imagens/lixeira.GIF" ></asp:ImageButton>                               
                                <cc1:ConfirmButtonExtender ID="ConfirmBtExt1" runat="server" TargetControlID="imgDelete" ConfirmText="Tem certeza que deseja excluir essa visita ?"></cc1:ConfirmButtonExtender>
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
                <xm:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Visita.aspx?idvisita=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Visitas.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Visita.Exportar, false %>' />
   </div>
   <div>
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

