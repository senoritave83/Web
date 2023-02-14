<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="agendamentos.aspx.vb" Inherits="home_agendamentos" ValidateRequest='false' %>

<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../include/SelectCliente.ascx" tagname="SelectCliente" tagprefix="uc2" %>

<%@ Register src="../include/SelectDestinatario.ascx" tagname="SelectDestinatario" tagprefix="uc3" %>

<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager runat='server' />
<table width="101%" align="center" cellpadding="0" cellspacing="0">
    <tr class='Header1'> 
        <td>
            <strong>Lista de agendamentos programados</strong>
        </td>
    </tr>
    <tr> 
        <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
    </tr>                
	<tr>
		<td>	
			<!-- INICIO CONTE&#65533;DO -->
			<asp:Repeater runat='server' ID='grdAgendamentos'>
                    <HeaderTemplate>
                        <table width='100%'>
                            <tr class='Header2'>
                                <th style="padding-left:5px;" colspan='2'>Agendamento</th>
                                <th>Cliente</th>
                                <th>Destinat&aacute;rio</th>
                                <th>Usuario</th>
                                <th>Ultima execu&ccedil;&atilde;o</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr <%#IIF(Eval("Ativo"), "class='griditemAgendamento'", "class='griditemAgendamento_inativo'") %> onclick='location.href="<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>"'>
                                <td width='30' rowspan='2' valign='middle' style='vertical-align:middle;'><a href='<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>'><img src=' <%#IIF(Eval("Ativo"), "../images/img_calendario.jpg", "../images/img_calendario_off.jpg") %>' border='0' style='margin-top:10px;' /></a></td>
                                <td><a href="<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>"><%#Eval("Agendamento") %></a></td>
                                <td><%#Server.HtmlEncode(Eval("Cliente")) %></td>
                                <td><%#Server.HtmlEncode(Eval("Destinatario")) %></td>
                                <td><%#Server.HtmlEncode(Eval("Usuario")) %></td>
                                <td><%#Eval("UltimaExecucao") %></td>
                            </tr>
                            <tr <%#IIF(Eval("Ativo"), "class='griditem'", "class='griditem_inativo'") %> onclick='location.href="<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>"'>
                                <td colspan='5'>
                                    <i><%#REPLACE(Eval("Descricao"), vbCrLf, "<br />") %></i>
                                </td>
                            </tr>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <tr>
                            <td colspan='6'><hr /></td>
                        </tr>
                    </SeparatorTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Literal runat='server' ID='ltrSemAgendamentos' Visible='false'>
                    <div style='text-align:center;margin-top:10px;margin-bottom:10px;'>N&atilde;o h&aacute; agendamentos cadastrados para essa filtragem!</div>
                </asp:Literal>
                <xm:Paginate runat='server' ID='Paginate1' />
                <table width="100%" cellpadding='0' cellspacing='0'  border='0'>
                    <tr class='Header2'>
                        <td>Filtrar os agendamentos por:</td>
                    </tr>
                    <tr>
                        <td>
                            <br />
				            <table width="70%">
                            <tr align="left">
                                <td>
                                    <font class='cinza1'>Cliente</font>
                                    <br />
                                    <uc2:SelectCliente ID="SelectCliente1" runat="server" />
                                </td>
                                <td colspan="2">
                                    <font class='cinza1'>Destinat&aacute;rio</font>
                                    <br />
                                    <uc3:SelectDestinatario ID="SelectDestinatario1" runat="server" />
                                </td>                                    
                            </tr>
                            <tr align="left">
                                <td>
                                    <font class='cinza1'>De</font>
                                    <br />
                                    <uc4:MaskFormater ID="txtDataInicial" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                                </td>
                                <td>
                                    <font class='cinza1'>At&eacute;</font>
                                    <br />
                                    <uc4:MaskFormater ID="txtDataFinal" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                                </td>
                                <td>
						            <asp:ImageButton runat='server' ID='btnFiltrar' ImageUrl="../images/buttons/Filtrar.png" border='0' />
                                </td>
                            </tr>
                        </table>
                        <br />
			        </td> 
		        </tr>
   	        </table>
		</td>
	</tr>
    <tr class='Footer1'> 
        <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
    </tr>							
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton Runat="server" ID='btnNovo' ImageUrl="../images/buttons/btn_adicionar.png"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="calendario.aspx">Calend&aacute;rio</a></dt>
    <dt class="current"><a href="agendamentos.aspx">Agendamento</a></dt>
    <dt><span lang="pt-br"><a href="agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	&bull; <b> Adicionar:</b> Adicione um novo 
	agendamento recorrente de O.S.<br />
</asp:Content>