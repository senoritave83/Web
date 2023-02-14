<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Bem Vindo
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlGrafico" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat='server' id='pnlGrafico'>
         <ContentTemplate>
            <!-- 
                VERIFICA O ARQUIVO SETTINGS.XML ELEMENTO REPORTVIEWER
            -->
            <asp:RadioButtonList runat="server" ID="rdlGrafico" AutoPostBack='true' RepeatDirection="Horizontal" Visible='<%$Settings: visible, Default.ReportViewer, false %>'>
            </asp:RadioButtonList>
            <rsweb:ReportViewer AsyncRendering="true" ID="ReportViewer1" runat="server" ShowParameterPrompts='false'></rsweb:ReportViewer>
        </ContentTemplate>
    </asp:UpdatePanel>

<div id="example" style="color:White"></div>

<script type="text/javascript">
    txt = "<p>Browser CodeName: " + navigator.appCodeName + "</p>";
    txt += "<p>Browser Name: " + navigator.appName + "</p>";
    txt += "<p>Browser Version: " + navigator.appVersion + "</p>";
    txt += "<p>Cookies Enabled: " + navigator.cookieEnabled + "</p>";
    txt += "<p>Platform: " + navigator.platform + "</p>";
    txt += "<p>User-agent header: " + navigator.userAgent + "</p>";

    //document.getElementById("example").innerHTML = txt; 
</script>
</asp:Content>

