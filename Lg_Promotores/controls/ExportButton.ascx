<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ExportButton.ascx.vb" Inherits="controls_ExportButton" %>
<asp:UpdatePanel runat='server' ID='updExportar'>
    <ContentTemplate>
        <input type='button' class="Botao fr" style="float:right;" id='Button1' value=' Exportar ' onclick='fncExportar()'/>
        <input type="hidden" id='hid_export' value='' runat='server' />
        <script type='text/javascript'>
            function fncExportar()
            {
                var vparams = document.getElementById("<%=hid_export.ClientID %>").value;
                var wh = window.open(vparams, "export", "width=500, toolbars=yes, scrollbars=1, resizable=1");
                wh.focus();
            }
        </script>
    </ContentTemplate>
</asp:UpdatePanel>
