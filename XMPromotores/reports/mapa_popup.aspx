<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mapa_popup.aspx.vb" Inherits="reports_mapa_popup" %>
<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:XMMapViewer ID="XMMapViewer1" 
                Width='100%' 
                FrameBorder='false'
                Height='600' 
                runat="server" 
                DataLatitudeField="Latitude" 
                DataLongitudeField="Longitude" 
                DataDetailsField="Descricao" 
                DataSequenceField="Sequencia" 
                DataTextField='Descricao'
                Title="Rota Referente ao Evento do Promotor"
                ShowLegend="false">
        <Sequences> 
            <cc1:XMMapViewerSequence SequenceID='0' ShowMarker='true' ShowLine='false' LineColor='Green'  />
            <cc1:XMMapViewerSequence SequenceID='1' ShowMarker='true' ShowLine='true' LineColor='Blue' />
        </Sequences>
        </cc1:XMMapViewer>
        <asp:Label ID="lblError" runat="server" Text="" Font-Size="16px" Font-Italic="true" ForeColor="Red" />
    </div>
    </form>
</body>
</html>