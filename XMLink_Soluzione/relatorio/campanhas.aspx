<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>

<script language="VB" runat="server">


	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		
		Dim dtsLista As System.Data.Dataset
		dtsLista = cls.GetDataSet("SP_SOL_WEB_RPT_CAMPANHA " & IDEmpresa & ", " & GetSQLDate(Request("datainicio") & "") & ", " & GetSQLDate(Request("datafinal") & ""))
		
		dtgStatus.DataSource = dtsLista.Tables(0)
		dtgStatus.DataBind

		dtgGrupo.DataSource = dtsLista.Tables(1)
		dtgGrupo.DataBind

		dtgVendedor.DataSource = dtsLista.Tables(2)
		dtgVendedor.DataBind
		
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
				<b class='TextDefault' style='font-size:10pt;font-weight:bold;'>Vendas x Campanhas</b>
				<br>
				<asp:DataGrid Runat="server" ID='dtgStatus' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none" AllowPaging=False>
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<Columns>
						<asp:BoundColumn HeaderText="Campanha" DataField='Campanha' />
						<asp:BoundColumn HeaderText="Status" DataField='Status' />
						<asp:BoundColumn HeaderText="Qtd" DataField='Qtd' />
						<asp:BoundColumn HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
						<asp:BoundColumn HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
					</Columns>
				</asp:DataGrid>
				<br>
				<asp:DataGrid Runat="server" ID="dtgGrupo" Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none" AllowPaging=False>
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<Columns>
						<asp:BoundColumn HeaderText="Grupo" DataField='Grupo' />					
						<asp:BoundColumn HeaderText="Campanha" DataField='Campanha' />
						<asp:BoundColumn HeaderText="Status" DataField='Status' />
						<asp:BoundColumn HeaderText="Qtd" DataField='Qtd' />
						<asp:BoundColumn HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
						<asp:BoundColumn HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
					</Columns>
				</asp:DataGrid>
				<br>
				<asp:DataGrid Runat="server" ID="dtgVendedor" Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none" AllowPaging=False>
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<Columns>
						<asp:BoundColumn HeaderText="Vendedor" DataField='Vendedor' />					
						<asp:BoundColumn HeaderText="Campanha" DataField='Campanha' />
						<asp:BoundColumn HeaderText="Status" DataField='Status' />
						<asp:BoundColumn HeaderText="Qtd" DataField='Qtd' />
						<asp:BoundColumn HeaderText="Total" DataFormatString='{0:C}' DataField='Total' />
						<asp:BoundColumn HeaderText="Média" DataFormatString='{0:C}' DataField='Media' />
					</Columns>
				</asp:DataGrid>				
			</center>
		</form>
	</body>
</html>
