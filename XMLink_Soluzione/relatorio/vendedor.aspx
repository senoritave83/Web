<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>

<script language="VB" runat="server">

	Dim dtsLista As System.Data.Dataset

	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load	
		addHandler dtgStatus.ItemDataBound, AddressOf Me.dtgStatus_ItemDataBound
		
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		dtsLista = cls.GetDataSet("SP_SOL_WEB_RPT_VENDEDOR " & IDEmpresa & ", " & GetSQLDate(Request("datainicio") & "") & ", " & GetSQLDate(Request("datafinal") & ""))
		dtgStatus.DataSource = dtsLista 
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
	
	Private Sub dtgStatus_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) 
		If e.Item.ItemType = ListItemType.Footer Then
			Dim dtbSum As System.Data.DataTable
			dtbSum = dtsLista.Tables(1)
			If dtbSum.rows.count > 0 Then
				e.Item.Cells(0).Text = dtbSum.rows(0)(0)
				e.Item.Cells(1).Text = dtbSum.rows(0)(1)
				e.Item.Cells(2).Text = dtbSum.rows(0)(2)
				e.Item.Cells(3).Text = FormatCurrency(dtbSum.rows(0)(3), 2)
				e.Item.Cells(4).Text = FormatCurrency(dtbSum.rows(0)(4), 2)
			
			End If
		End If
	end Sub
		
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
				<b class='TextDefault' style='font-size:10pt;font-weight:bold;'>Vendas x Vendedor</b>
				<br>
				<asp:DataGrid Runat="server" ID='dtgStatus' Width="100%" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True" CssClass='TextDefault' BorderStyle="none">
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<FooterStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
					<Columns>
						<asp:BoundColumn HeaderText="Vendedor" DataField='ven_Vendedor_chr' />
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
