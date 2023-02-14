<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="Mapa.aspx.vb" Inherits="Relatorios_Mapa" %>

<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
                    <cc1:XMMapViewer ID="XMMapViewer1" 
                    Width='600' 
                    FrameBorder='false'
                    Height='600' 
                    runat="server" 
                    DataLatitudeField="Latitude" 
                    DataLongitudeField="Longitude" 
                    DataDetailsField="Descricao" 
                    DataSequenceField="Sequencia" 
                    DataTextField='Descricao'
                    Title="Mapa">
            <Sequences> 
                <cc1:XMMapViewerSequence SequenceID='0' ShowMarker='true' ShowLine='true' LineColor='Blue'  />
            </Sequences>
            </cc1:XMMapViewer>
</asp:Content>           