<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>
<HTML>
	<HEAD>
		<title>.: XMLink 2.0 :.</title>
		<script language="VB" runat="server">

	Dim dtsLista As System.Data.Dataset		
	
	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load	

		If not page.IsPostBack Then
		
			BindGrid()
			
		End If

	end sub

	Private Sub BindGrid()
				
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		dtsLista = cls.GetDataSet("SP_SOL_WEB_RPT_ROTEIRO " & IDEmpresa & ", " & Request("ven") & "")  
		
		dtgLista.DataSource = dtsLista
		dtgLista.DataBind
					
		cls = Nothing
	End Sub
		
		</script>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" rel="StyleSheet" type="text/css">
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form runat="server">
			<center>
				<br>
				<b class='TextDefault' style='FONT-WEIGHT:bold;FONT-SIZE:10pt'>Roteiros</b>
				<br>
			<table width=100% runat=server id=tblImprime>
				<tr class='TextDefault' style='FONT-SIZE:10pt'>
					<td>
						<b>Vendedor:</b> <%=Request("nome")%>
					</td>
				</tr>
			</table>
				<div id="divReport">
					<asp:DataGrid Runat="server" ID='dtgLista' Width="100%" AutoGenerateColumns="true" AllowSorting="False" ShowFooter="True" EnableViewState="False"
						CssClass='TextDefault' BorderStyle="none">
						<HeaderStyle ForeColor="White" CssClass='Header' />
						<FooterStyle ForeColor="White" CssClass='Header' />
						<ItemStyle CssClass="GridItem" />
						<Columns>
							
						</Columns>
					</asp:DataGrid>
				</div>
			</center>
			<br>
			<asp:Label Runat="server" ID="lblSituacao" CssClass="TextDefault" style='FONT-WEIGHT:bold;FONT-SIZE:10pt'></asp:Label>
		</form>
	</body>
</HTML>
