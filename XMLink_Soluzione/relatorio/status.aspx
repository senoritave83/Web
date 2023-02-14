<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>

<script language="VB" runat="server">


	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		dtgStatus.DataSource = cls.GetDataSet("SP_SOL_WEB_RPT_STATUS " & IDEmpresa & ", " & GetSQLDate(Request("datainicio") & "") & ", " & GetSQLDate(Request("datafinal") & ""))
		dtgStatus.DataBind
		cls = Nothing
	end sub
	
	Private Function GetSQLDate(vDate) as String
		if isDate(vDate) Then
			GetSQLDate = "'" & CDate(vDate).toString("yyyy-MM-dd") & "'"
		else
			GetSQLDate = "NULL"
		end if
	end Function
		
</script>
<html>
	<HEAD>
		<title>.: XMLink 2.0 :.</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" rel="StyleSheet" type="text/css">
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form runat="server">
			<center>
				<br>
				<b class='TextDefault' style='font-size:12pt;'>Relatório de Status</b>
				<br>
				<asp:DataGrid Runat="server" ID='dtgStatus' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
					<Columns>
						<asp:BoundColumn HeaderText="Status" DataField='sta_Status_chr' />
						<asp:BoundColumn HeaderText="Quantidade" DataField='Qtd' />
						<asp:BoundColumn HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
						<asp:BoundColumn HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
					</Columns>
				</asp:DataGrid>
			</center>
		</form>
	</body>
</html>
