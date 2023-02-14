<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rota_popup.aspx.vb" Inherits="Relatorios_rota_popup" %>
<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                Title="Rota de Pedidos"
                ShowLegend="false">
        <Sequences> 
            <cc1:XMMapViewerSequence SequenceID='0' ShowMarker='true' ShowLine='false' LineColor='Green'  />
            <cc1:XMMapViewerSequence SequenceID='1' ShowMarker='true' ShowLine='true' LineColor='Blue' />
            <cc1:XMMapViewerSequence SequenceID='2' ShowMarker='true' ShowLine='false' LineColor='gainsboro' />
        </Sequences>
        </cc1:XMMapViewer>
        <asp:Label ID="lblError" runat="server" Text="" Font-Size="16px" Font-Italic="true" ForeColor="Red" />
    </div>
    </form>
</body>
</html>
