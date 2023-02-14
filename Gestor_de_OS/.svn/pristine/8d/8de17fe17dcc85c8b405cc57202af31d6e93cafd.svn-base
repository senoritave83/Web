<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="novaordem.aspx.vb" Inherits="home_novaordem" title="Gestor de O.S" %>

<%@ Register src="../include/Agenda.ascx" tagname="Agenda" tagprefix="uc1" %>

<%@ Register src="../include/os_editor.ascx" tagname="os_editor" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server'></asp:ScriptManager>
    <asp:PlaceHolder Runat="server" ID='plhNova' Visible="True">
        <center>
		<table cellpadding="0" width="101%">
            <tr class='Header1'> 
                <td>
                    <strong>Envio de O.S.</strong>
                </td>
            </tr> 
            <tr> 
                <td class='Linha1'><img src="../images/transpa.gif" height="1" alt=""/></td>
            </tr>                
		    <tr class="Header2">
		        <td>
                    Dados da O.S.
                </td>
		    </tr>
			<tr valign="top" bgcolor="white">
				<td>
                    <uc2:os_editor ID="os_editor1" runat="server" />
				</td>
	        </tr>
            <tr runat='server' id='trFoto' align="left">
                <td>
                    <h6>Incluir Foto na OS</h6>
                    <br />
                    <asp:Image runat="server" ID="imgOS" ImageUrl="~/images/FotosOS/noimage.png" Width="150" />
                    <br />
                    <asp:FileUpload runat="server" ID="flImgOS" />
                    <br />
                    <asp:Button runat="server" ID="btnAnexarFoto" Text="Anexar Foto" CausesValidation="False" />
                </td>
            </tr>
            <tr class='Footer1'> 
                <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
            </tr>							
		</table>
        </center>
	</asp:PlaceHolder>

	<asp:PlaceHolder runat='server' ID='plhAgenda' Visible='False'>
        <table width="101%" align="center">
            <tr class='Header1'> 
                <td>
                    <strong>Envio de O.S.</strong>
                </td>
            </tr> 
            <tr> 
                <td class='Linha1'><img src="../images/transpa.gif" height="1" alt="" /></td>
            </tr>
            <tr class="Header2">
                <td>Selecione a data de envio.</td>
            </tr>
            <tr>
                <td height='400px'>
                    <asp:UpdatePanel runat='server' ID='updAgendamento'>
                        <ContentTemplate>
                            <table width='100%'>
                                <tr>
                                    <td style="padding:10px 0px 0px 10px; text-align:left;">
	                                    Tipo de Agendamento: 
	                                    <asp:DropDownList runat='server' ID='cboTipoAgendamento' AutoPostBack='true'>
	                                        <asp:ListItem Selected='True' Value='0'>Simples</asp:ListItem>
	                                        <asp:ListItem Value='1'>Recorrente</asp:ListItem>
	                                    </asp:DropDownList>
                                    </td>
                                    <td runat='server' id='tdNome' visible='false'>
	                                    Nome: <asp:TextBox runat='server' ID='txtNome' />	    
	                                    <asp:RequiredFieldValidator runat='server' ID='reqNomeAgenda' ControlToValidate='txtNome' ErrorMessage='Por favor informe um nome para esse agendamento.'>*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>                    
	                        <hr />
                            <table width='100%'>
	                            <asp:PlaceHolder runat='server' ID='plhSimples'>
                                    <tr>
                                        <td>
                                            <asp:Calendar id="calDataEnvio" Runat="server" CssClass="cinza1" Width="100%">
                                                <DayStyle BackColor="white" />
                                                <SelectedDayStyle ForeColor="black" BackColor="#E5E7E9"></SelectedDayStyle>
                                            </asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding:10px 0px 0px 10px; text-align:left;">
                                            <font class="cinza1">Hora de envio:</font>
                                            <asp:TextBox id="txtHoraEnvio" Runat="server" CssClass="formulario" Width="130px" MaxLength="16"></asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoraEnvio" CssClass="formulario"
                                                Display="Dynamic" ErrorMessage="Campo obrigat&oacute;rio"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator id="TimeValidator" Runat="server" ControlToValidate="txtHoraEnvio" CssClass="formulario"
                                                ErrorMessage="*" ValidationExpression="^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$"></asp:RegularExpressionValidator>                                            
                                        </td>
                                    </tr>
	                            </asp:PlaceHolder>
	                            <asp:PlaceHolder runat='server' ID='plhRecorrente' Visible='false'>
                                    <uc1:Agenda ID="Agenda1" runat="server" DayPanelCssClass='PanelDia' MesPanelCssClass='PanelMes' WeekDayPanelCssClass='PanelDiaSemana' />
	                            </asp:PlaceHolder>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
	            </td>
	        </tr>
            <tr class='Footer1'> 
                <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
            </tr>							
        </table>
	    <asp:ValidationSummary runat='server' ID='valSummary' ShowMessageBox='true' ShowSummary='false' />
	</asp:PlaceHolder>
</asp:Content>

<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='Botoes'>
    <asp:PlaceHolder runat='server' ID='plhBotoesNova'>
        <asp:ImageButton Runat="server" id="btnVoltar" ImageUrl="~/images/buttons/btn_voltar.png" CssClass="botao_voltar" CausesValidation="false"></asp:ImageButton>
        <asp:ImageButton Runat="server" id="btnGuardar" ImageUrl="~/images/buttons/btn_armazenar.png" CssClass="botao"></asp:ImageButton>
        <asp:ImageButton Runat="server" id="btnAgendar" ImageUrl="~/images/buttons/btn_agendar.png" CssClass="botao"></asp:ImageButton>
	    <asp:ImageButton Runat="server" id="btnEnviar" ImageUrl="~/images/buttons/btn_enviar.png" CssClass="botao"></asp:ImageButton>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat='server' ID='plhBotaoAgendar' Visible='False'>
        <asp:ImageButton Runat="server" id="btnVoltar2" ImageUrl="~/images/buttons/btn_voltar.png" CssClass="botao_voltar" CausesValidation="false"></asp:ImageButton>
        <asp:ImageButton Runat="server" id="btnAgendarOS" ImageUrl="~/images/buttons/btn_agendar.png"></asp:ImageButton>
    </asp:PlaceHolder>
</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID='menuEsquerdo'>
    <dl>
    <dt><a href="default.aspx">Lista de O.S.</a></dt>
    <dd><a href="#" onclick='fncExportar();'>Exportar</a></dd>
    <dd><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    <dt class="current"><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>
    </dl>
</asp:Content>
