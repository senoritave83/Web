﻿<%@ Page Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="status_det.aspx.vb" Inherits="Relatorios_status" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False">
	    <HeaderStyle HorizontalAlign='Left' />
		<Columns>
			<asp:BoundField HeaderText="Status" DataField='Status' />
			<asp:BoundField HeaderText="Quantidade" DataField='Quantidade' />
			<asp:BoundField HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
			<asp:BoundField HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
		</Columns>
	</asp:GridView>
</asp:Content>

