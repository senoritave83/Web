<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="agendamento.aspx.vb" Inherits="home_agendamento" title="Untitled Page" %>

<%@ Register src="../include/os_editor.ascx" tagname="os_editor" tagprefix="uc2" %>
<%@ Register src="../include/Agenda.ascx" tagname="Agenda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat='server'></asp:ScriptManager>

	<table width="101%" cellpadding="0" cellspacing='0' align="center" align="right*">
        <tr class='Header1'> 
            <td colspan="3" style="height: 18px">
                <strong>&nbsp;Agendamento</strong>
            </td>
        </tr> 
        <tr> 
            <td colspan="3" class='Linha1'>
                <img src="../images/transpa.gif" height="1" alt=""/>
            </td>
        </tr>                
	    <tr class="Header2">
	        <td colspan="3" style="height: 31px">
                Dados do Agendamento
            </td>
	    </tr>
        <tr>
            <td align="left">
                <table width="500" border="0" cellpadding='2'>
                    <tr>
			            <td width="54px" align='right' *align='right'>
                            <br />
			                Nome:
			            </td>
			            <td style="width: 353px">
                            <br />
			                <asp:TextBox runat='server' ID='txtAgendamento' width='350'></asp:TextBox>
			                <asp:RequiredFieldValidator runat='server' ID='valReqAgendamento' ControlToValidate='txtAgendamento' ErrorMessage='O nome do agendamento &eacute; obrigat&oacute;rio!'>*</asp:RequiredFieldValidator>
			            </td> 
			            <td align='left' valign="middle">
				            <asp:CheckBox runat='server' ID='chkAtivo' Text='Ativo' TextAlign='Left' Checked='true' />
			            </td>
		            </tr>
                </table>            
            </td>
        </tr>	        
		<tr>
            <td colspan="3">
			    <hr />
            </td>
        </tr>                    
        <tr>
            <td colspan="3" align="left">                        
                <uc2:os_editor ID="os_editor1" runat="server" />
            </td>
        </tr>                    
        <tr>
            <td colspan="3">
			    <hr />
            </td>
        </tr>
    </table>
    <table width="101%" cellpadding="0" cellspacing='0' align="center" style="border-">
        <tr>
            <td>
				<uc1:agenda ID="Agenda1" runat="server" DayPanelCssClass='PanelDia' 
                    MesPanelCssClass='PanelMes' WeekDayPanelCssClass='PanelDiaSemana' />
        	    <asp:ValidationSummary runat='server' ID='valSummary' ShowMessageBox='true' ShowSummary='false' />
                <br />
            </td>
		</tr>   
        <tr class='Footer1'> 
            <td>
                <img width="1" height="25" src="../images/transpa.gif" alt=""/>
            </td>
        </tr>							
	</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton Runat="server" ID="btnExcluir" ImageUrl="../images/buttons/btn_excluir.png"></asp:ImageButton>
    <asp:ImageButton Runat="server" ID="btnSalvar" ImageUrl="../images/buttons/btn_salvar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="calendario.aspx">Calend&aacute;rio</a></dt>
    <dt><a href="agendamentos.aspx">Agendamento</a></dt>
    <dt class="current"><span lang="pt-br"><a href="agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

