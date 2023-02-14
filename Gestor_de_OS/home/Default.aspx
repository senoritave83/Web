<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="EOL.Pages.home.home_Default" title="Gestor de O.S" %>

<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../include/SelectCliente.ascx" tagname="SelectCliente" tagprefix="uc2" %>

<%@ Register src="../include/SelectResponsaveis.ascx" tagname="SelectResponsaveis" tagprefix="uc3" %>

<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat='server'></asp:ScriptManager>
    <div style='height:330px'>
        <iframe id="frmGrid" name="frmListaOS" src="" frameborder="0" width="101%" runat="server" style="height: 103%; *height: 107%;"></iframe>
    </div>
    <table class="fdo_cinza" width="101%" cellpadding='0' cellspacing='0'  border='0' style="margin-top:18px; *margin-top:25px;">
        <tr class='Header2'>
            <td>Filtrar as ordens de servi&ccedil;o por:</td>
        </tr>
        <tr>
            <td>
                <br />
				 <table width="100%" style="text-align:left;">
                    <tr>
                        <td style="padding-left:11px; height: 70px;">
                            <font class='cinza1'>Cliente</font>
                            <br />
                            <uc2:SelectCliente ID="SelectCliente1" runat="server" />
                        </td>
                        <td style="height: 70px">
                            <font class='cinza1'>Respons&aacute;vel</font>
                            <br />
                            <uc3:SelectResponsaveis ID="SelectResponsaveis1" runat="server" />
                        </td>
                        <td style="height: 70px">
                            <font class='cinza1'>Status</font>
                            <br />
                            <asp:ListBox cssclass="formulario" SelectionMode="Multiple" DataTextField="ors_Status_chr" DataValueField="ors_Status_chr" runat="Server" ID="lstStatus"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:11px">
                            <font class='cinza1'>De</font>
                            <br />
                            <uc4:MaskFormater ID="txtDataInicial" runat="server" Height="15px" Width="140px" MaxLength='10' cssclass="formulario"/>
                        </td>
                        <td>
                            <font class='cinza1'>At&eacute;</font>                            
                            <br />
                            <uc4:MaskFormater ID="txtDataFinal" runat="server" Height="15px" Width="140px" MaxLength='10' cssclass="formulario"/>
                        </td>
                        <td>
                            <br />
					        <a href='javascript:void();' onclick='fncFiltrar()'><img src='../images/buttons/Filtrar.png' border='0' /></a>
                        </td>
                    </tr>                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />                                
                <script type='text/javascript'>

                    Date.prototype.toDDMMYYYYString = function () { return isNaN(this) ? 'NaN' : [this.getDate() > 9 ? this.getDate() : '0' + this.getDate(), this.getMonth() > 8 ? this.getMonth() + 1 : '0' + (this.getMonth() + 1), this.getFullYear()].join('/') }

                    Date.fromDDMMYYYY = function (s) { return (/^(\d\d?)\D(\d\d?)\D(\d{4})$/).test(s) ? new Date(RegExp.$3, RegExp.$2 - 1, RegExp.$1) : new Date(s) }

                    function XM_GetValues(vList) {
                        var m_Values = '';
                        for (var i = 0; i < vList.options.length; i++) {
                            if (vList.options[i].selected == true) {
                                if (m_Values != '') m_Values += ',';
                                m_Values += vList.options[i].value;
                            }
                        }
                        //if (m_Values != '') {m_Values = Left(m_Values, m_Values.length - 1)};
                        return m_Values;
                    }

                    function fncFiltrar() {
                        if (Page_IsValid) {

                            var frmGrid = document.getElementById('<%=frmGrid.ClientID %>');
                            var lstStatus = XM_GetValues(document.getElementById('<%=lstStatus.ClientID()%>'));
                            var txtDataInicial = document.getElementById('<%=txtDataInicial.UID()%>');
                            var txtDataFinal = document.getElementById('<%=txtDataFinal.UID()%>');

                            if (validaDatas(txtDataInicial.value, txtDataFinal.value) == false) {
                                alert('A data inicial deve ser menor ou igual a data final');
                                return;
                            }

                            if (Page_ClientValidate()) {

                                var vUrl = 'listaos.aspx?cliente=' + escape(getSelectedCliente()) +
											                '&responsavel=' + escape(getSelectedResponsavel()) +
											                '&status=' + lstStatus +
											                '&txtDataInicial=' + txtDataInicial.value +
											                '&txtDataFinal=' + txtDataFinal.value +
											                '&type=2';
                                frmGrid.attributes.getNamedItem("src").value = vUrl;

                                gravarFiltro();
                            }
                        }
                    }

                    function fncExportar() {
                        var lstStatus = XM_GetValues(document.getElementById('<%=lstStatus.ClientID()%>'));
                        var txtDataInicial = document.getElementById('<%=txtDataInicial.UID()%>');
                        var txtDataFinal = document.getElementById('<%=txtDataFinal.UID()%>');

                        if (validaDatas(txtDataInicial.value, txtDataFinal.value) == false) {
                            alert('A data inicial deve ser menor ou igual a data final');
                            return;
                        }

                        var url = '../home/exportar.aspx?cliente=' + escape(getSelectedCliente());
                        url += '&Responsavel=' + escape(getSelectedResponsavel());
                        url += '&Status=' + lstStatus;
                        url += '&DataInicial=' + escape(txtDataInicial.value);
                        url += '&DataFinal=' + escape(txtDataFinal.value);
                        location.href = url;

                    }
                    function reload() {
                        document.forms[0].submit();
                    }

                    function gravarFiltro() {
                        var filtro = "FILTRO";

                        filtro += "=URL=/EquipeOnline/home/Default.aspx&";
                        filtro += "SelectCliente1=" + escape(getSelectedCliente()) + "&";
                        filtro += "SelectResponsaveis1=" + escape(getSelectedResponsavel()) + "&";
                        filtro += "lstStatus=" + XM_GetValues(document.getElementById('<%=lstStatus.ClientID()%>')) + "&";
                        filtro += "txtDataInicial=" + escape(document.getElementById('<%=txtDataInicial.UID()%>').value) + "&";
                        filtro += "txtDataFinal=" + escape(document.getElementById('<%=txtDataFinal.UID()%>').value);
                        document.cookie = filtro;
                    }                            
                </script>
			</td>
		</tr>
        <tr class='Footer1' style="background:none;"> 
            <td style="height: 20px"><asp:literal id="ltrMessage" Runat="server"></asp:literal>&nbsp;</td>
        </tr>
   	</table>
</asp:Content>

<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current" style="border-bottom:none;"><a href="default.aspx">Lista de O.S.</a></dt>
    <dd><a href="#" onclick='fncExportar();'>Exportar</a></dd>
    <dd><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    </dl>
    <dt style="border-top:1px #D7D2CB solid;"><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='Ajuda'>
	
</asp:Content>

