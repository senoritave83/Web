<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="calendario.aspx.vb" Inherits="home_calendario" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width='101%' cellpadding='0' cellspacing='0' align="center">
    <tr class='Header1'> 
        <td colspan='2'>
            Agendamentos programados
        </td>
    </tr>
     
    <tr>
        <td style="*display:inline">
            <table width="100%">
                <tr>
                    <td width="33%" style="border:1px #D7D2CB solid; *vertical-align:top;">
                        <asp:Calendar runat='server' ID='calCalendarioMesAnterior' OnDayRender="calCalendario_DayRender" OnSelectionChanged="calCalendario_SelectionChanged" Width='100%' TitleStyle-BorderStyle='None' TitleStyle-BorderWidth='0' DayNameFormat="Short" ShowNextPrevMonth="False" TitleStyle-CssClass="Calendar" BorderStyle='None'>
                        </asp:Calendar>
                    </td>
                    <td style="padding:0 1px 0 1px; border:1px #D7D2CB solid; *vertical-align:top" width="33%">
                        <asp:Calendar runat='server' ID='calCalendarioMesAtual' OnDayRender="calCalendario_DayRender" OnSelectionChanged="calCalendario_SelectionChanged" Width='100%' TitleStyle-BorderStyle='None' TitleStyle-BorderWidth='0' DayNameFormat="Short" ShowNextPrevMonth="False" TitleStyle-CssClass="Calendar" BorderStyle='None'>
                        </asp:Calendar>
                    </td>
                    <td style="border:1px #D7D2CB solid; *vertical-align:top" width="33%">
                        <asp:Calendar runat='server' ID='calCalendarioMesProximo' OnDayRender="calCalendario_DayRender" OnSelectionChanged="calCalendario_SelectionChanged" Width='100%' TitleStyle-BorderStyle='None' TitleStyle-BorderWidth='0' DayNameFormat="Short" ShowNextPrevMonth="False" TitleStyle-CssClass="Calendar" BorderStyle='None'>
                        </asp:Calendar>
                    </td>
                </tr>
            </table>            
        </td>
        <td style="padding-left:5px; *padding-left:0px; vertical-align:top;width:15%;">
            <asp:DataList runat='server' ID='lstMeses' RepeatDirection='Horizontal' RepeatColumns='3' BorderStyle='Solid' BorderWidth='1' BorderColor="#A09D96" CellPadding='3' CellSpacing='3' Width='100%' Height='100%'>
                <SelectedItemStyle BackColor='Gainsboro' />
                <HeaderStyle HorizontalAlign='Center' CssClass='zerar_borda' />
                <HeaderTemplate>
                    <table width='100%'>
                        <tr>
                            <td align='left' width='15%'>
                                <asp:LinkButton runat='server' ID='lnkPrevYear' CommandName='ChangeYear' CommandArgument='-1'>&lt;</asp:LinkButton>
                            </td>
                            <td align='center'>
                                <%=SelectedDate.Year%>
                            </td>
                            <td align='right' width='15%'>
                                <asp:LinkButton runat='server' ID='lnkNextYear' CommandName='ChangeYear' CommandArgument='1'>&gt;</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName='SelectMonth' CommandArgument='<%#Container.DataItem%>'> <%#MonthName(Month(Container.DataItem), True)%></asp:LinkButton>
                </ItemTemplate>
                <SelectedItemTemplate>
                    <%#MonthName(Month(Container.DataItem), True)%>
                </SelectedItemTemplate>
            </asp:DataList>
        </td>
    </tr>
        <tr>
            <td colspan='2' style="padding: 2px 0px 2px 0px;">
                <h4 style="text-align:center"><asp:Literal runat='server' ID='ltrDia'></asp:Literal></h4>
                <asp:Repeater runat='server' ID='grdAgendamentos'>
                    <HeaderTemplate>
                        <table width='101%'>
                            <tr class='Header2'>
                                <th colspan='2' style="padding-left:5px;">Agendamento</th>
                                <th>Cliente</th>
                                <th>Destinat&aacute;rio</th>
                                <th>Usuario</th>
                                <th>Ultima execu&ccedil;&atilde;o</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr <%#IIF(Eval("Ativo"), "class='griditemAgendamento'", "class='griditemAgendamento_inativo'") %> onclick='location.href="<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>"'>
                                <td width='30' rowspan='2' valign='middle' style='vertical-align:middle;'><a href='<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>'><img src=' <%#IIF(Eval("Ativo"), "../images/img_calendario.jpg", "../images/img_calendario_off.jpg") %>' border='0' /></a></td>
                                <td><a href="<%# IIF(EVAL("TipoAgendamento") = 0, "ordemservico.aspx?idos=", "agendamento.aspx?idagendamento=") & Eval("IDAgendamento") %>"><%#Eval("Agendamento") %></a></td>
                                <td><%#Eval("Cliente") %></td>
                                <td><%#Eval("Destinatario") %></td>
                                <td><%#Eval("Usuario") %></td>
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
                <asp:Literal runat='server' ID='ltrSemAgendamento' Visible='false'>
                    <div style="text-align:center;margin-bottom:10px;">
                    N&atilde;o h&aacute; agendamentos programados para esse dia!
                    </div>
                </asp:Literal>
            </td>
        </tr>
        <tr class='Footer1'> 
            <td colspan='2'><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
        </tr>	
    </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><a href="calendario.aspx">Calend&aacute;rio</a></dt>
    <dt><a href="agendamentos.aspx">Agendamento</a></dt>
    <dt><span lang="pt-br"><a href="agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

