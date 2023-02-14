<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc1" %>

<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Agenda.ascx.vb" Inherits="Controls.Agenda" %>
        <asp:Panel runat='server' ID='pnlRoteiro'>
            <table width='100%' class="roteiro">
                <tr valign='top'>
                    <td style="border-right:3px solid white; border-bottom:3px solid white;">
		                <asp:Panel runat='server' ID='pnlDia'>
		                    <asp:label Runat="server"><span>Dia:</span></asp:label><a href='javascript:fncLimparChecks("<%=chkDia.ClientID%>_");' class='LinkLimpar'>Limpar</a>
                            <br />
			                <asp:checkboxlist id="chkDia" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="5" OnClick='fncAgendaRefresh();'>
				                <asp:ListItem Value="1">1</asp:ListItem>
				                <asp:ListItem Value="2">2</asp:ListItem>
				                <asp:ListItem Value="4">3</asp:ListItem>
				                <asp:ListItem Value="8">4</asp:ListItem>
				                <asp:ListItem Value="16">5</asp:ListItem>
				                <asp:ListItem Value="32">6</asp:ListItem>
				                <asp:ListItem Value="64">7</asp:ListItem>
			                </asp:checkboxlist>
		                </asp:Panel>
                    </td>
                    <td style="border-right:3px solid white;border-bottom:3px solid white;">
		                <asp:Panel runat='server' ID='pnlMes'>
		                    <asp:label id="Label3" Runat="server">M&ecirc;s:&nbsp;</asp:label><a href='javascript:fncLimparChecks("<%=chkMes.ClientID%>_");' class='LinkLimpar'>Limpar</a>
                            <br />
			                <asp:checkboxlist id="chkMes" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="2" OnClick='fncAgendaRefresh();'>
				                <asp:ListItem Value="1">Janeiro</asp:ListItem>
				                <asp:ListItem Value="2">Fevereiro</asp:ListItem>
				                <asp:ListItem Value="4">Mar&#65533;o</asp:ListItem>
			                </asp:checkboxlist>
			            </asp:Panel>
                    </td>
                    <td>
		                <asp:Panel runat='server' ID='pnlDiaSemana'>
		                    <asp:label id="Label5" CssClass="TextoNegrito" Runat="server">Dia da Semana:&nbsp;</asp:label><a href='javascript:fncLimparChecks("<%=chkDiaSemana.ClientID%>_");' class='LinkLimpar'>Limpar</a>
                            <br />
			                <asp:checkboxlist id="chkDiaSemana" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="1" OnClick='fncAgendaRefresh();'>
				                <asp:ListItem Value="1">Domingo</asp:ListItem>
				                <asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
			                </asp:checkboxlist>
		                </asp:Panel>                    
                    </td>
                </tr>
            </table>
        </asp:Panel>
	    <br style='clear:both;' />
        <table width='100%' border='0'>
            <tr valign='top'>
                <td rowspan='2' style='padding-top:7px;' align="left">
                    Frequ&ecirc;ncia di&aacute;ria:
                </td>
                <td rowspan='2' align="left">
                    <asp:RadioButtonList runat='server' ID='radTipoFrequenciaDiaria' onClick='fncAlteraFrequencia();'>
                        <asp:ListItem Selected='True' Value='0' Text='Ocorre uma vez &agrave;s:'></asp:ListItem>
                        <asp:ListItem Value='1' Text='Ocorre a cada:'></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan='2' align="left">
                    <asp:TextBox runat='server' ID='txtHora' onblur='fncAgendaRefresh();' onkeypress="mascaraHora(this,hora)" Width='60px'></asp:TextBox>
                    <asp:CustomValidator runat='server' ID='valHora' ClientValidationFunction='validaFrequencia' ControlToValidate='radTipoFrequenciaDiaria' ErrorMessage='A hora de execu&ccedil;&atilde;o &eacute; obrigat&oacute;ria!' EnableClientScript='true'>*</asp:CustomValidator><br />
                </td>
             </tr>
             <tr valign='top'>
                <td align="left">                            
                    <asp:TextBox runat='server' ID='txtTempo' Text='1' Enabled='false' MaxLength='2' onChange='fncVerificaTempo();' Width='60px'></asp:TextBox>
                    <asp:DropDownList runat='server' ID='cboTempo' Enabled='false' onChange='fncVerificaTempo();'>
                        <asp:ListItem Text='minuto(s)' Value='2'></asp:ListItem>
                        <asp:ListItem Selected='true' Text='hora(s)' Value='4'></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator runat='server' ID='valTempo' ClientValidationFunction='validaFrequencia' ControlToValidate='radTipoFrequenciaDiaria' ErrorMessage='O tempo de repeti&ccedil;&atilde;o &eacute; obrigat&oacute;rio!' EnableClientScript='true'>*</asp:CustomValidator><br />
                </td>
                <td align='right'>
                    In&iacute;cio:
                    <asp:TextBox runat='server' ID='txtHoraInicio' Enabled='false' onkeypress="mascaraHora(this,hora)" Width='60px' onBlur='fncAgendaRefresh();'></asp:TextBox>
                    <asp:CustomValidator runat='server' ID='valInicioCustomHora' ClientValidationFunction='validaFrequencia' ControlToValidate='radTipoFrequenciaDiaria' ErrorMessage='Informe a hora in&iacute;cial.' EnableClientScript='true'>*</asp:CustomValidator><br />
                    <br />
                    T&eacute;rmino:
                    <asp:TextBox runat='server' ID='txtHoraTermino' Enabled='false' onkeypress="mascaraHora(this,hora)" Width='60px' onBlur='fncAgendaRefresh();'></asp:TextBox>
                    <asp:CustomValidator runat='server' ID='valTerminoCustomHora' ClientValidationFunction='validaFrequencia' ControlToValidate='radTipoFrequenciaDiaria' ErrorMessage='Informe a hora de t&eacute;rmino.' EnableClientScript='true'>*</asp:CustomValidator><br />
                    <asp:CompareValidator runat='server' ID='valCompareHora' Operator='GreaterThan' ControlToValidate='txtHoraTermino' ControlToCompare='txtHoraInicio' ErrorMessage='A hora final deve ser maior do que a hora inicial!'>*</asp:CompareValidator>
                    <br />
                </td>
            </tr>
        </table>
	    <hr />
        <table width='100%' border='0'>
            <tr valign='top'>
                <td style='padding-top:7px;width:30%' align="left">
            	    Dura&ccedil;&atilde;o:
                </td>
                <td style='width:170px' align="left">
                    Data de In&iacute;cio:	    
                    <uc1:MaskFormater ID="txtDataInicio" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                </td>
                <td style='width:130px' align="left">
                    <asp:RadioButtonList ID='radDataFinal' runat='server' onClick='fncAlteraDataTermino();'>
                        <asp:ListItem Selected='True' Value='0' Text='Com data de t&eacute;rmino:'></asp:ListItem>
                        <asp:ListItem Selected='True' Value='1' Text='Sem data de t&eacute;rmino.'></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td valign='top' align="left">
    	            <uc1:MaskFormater ID="txtDataTermino" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                    <asp:CustomValidator  runat='server' ID='valReqDataTermino' ControlToValidate='radDataFinal' ErrorMessage='A data de t&eacute;rmino &eacute; orbigat&oacute;ria' ClientValidationFunction='validaDataTermino'>*</asp:CustomValidator>                    
                </td>
            </tr>
        </table>
	    <hr />
	    <table width='100%'>
	        <tr valign='top'>
	            <td align="left">
                    Resumo:
                </td>
	            <td align="left">
	                <span id='spResumo'>&nbsp;</span>
	            </td>
	        </tr>
	    </table>
        <script type='text/javascript'>
            
            fncAgendaRefresh();
            
        </script>
