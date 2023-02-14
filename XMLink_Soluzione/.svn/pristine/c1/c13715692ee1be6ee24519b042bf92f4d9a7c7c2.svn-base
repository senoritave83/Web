<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>

<script language="VB" runat="server">


	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load
		If not page.IsPostBack Then
			BindGrid()
		end if
	end sub

	Private Sub BindGrid()
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		dtgStatus.DataSource = cls.GetDataSet("SP_SOL_WEB_RPT_VELOCIDADE_VENDA " & IDEmpresa & ", " & GetSQLDate(Request("datainicio") & "") & ", " & GetSQLDate(Request("datafinal") & "") & ", '" & ViewState("Sort") & "'")  
		dtgStatus.DataBind
		cls = Nothing
	End Sub
	
	Private Function GetSQLDate(vDate) as String
		if isDate(vDate) Then
			GetSQLDate = "'" & CDate(vDate).toString("yyyy-MM-dd") & "'"
		else
			GetSQLDate = "NULL"
		end if
	end Function

    Private Sub dtgStatus_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) 
        ViewState("Sort") = e.SortExpression
        BindGrid()
    End Sub

		
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
				<b class='TextDefault' style='font-size:10pt;font-weight:bold;'>Velocidade de Venda</b>
				<br>
				<asp:DataGrid Runat="server" ID='dtgStatus' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none" OnSortCommand='dtgStatus_SortCommand'>
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
					<Columns>
						<asp:BoundColumn HeaderText="Código" DataField='prd_Codigo_chr' SortExpression='Codigo' />
						<asp:BoundColumn HeaderText="Descrição" DataField='prd_Descricao_chr' SortExpression='Descricao' />
						<asp:BoundColumn HeaderText="Estoque" DataField='prd_Estoque_int' SortExpression='Estoque' />
						<asp:BoundColumn HeaderText="Qtd. Vendida" DataField='Qtd_Vendida' SortExpression='Vendida' />
						<asp:BoundColumn HeaderText="Qtd. por Dia" DataField='Media_dia' DataFormatString='{0:0.0}' SortExpression='Media' />
						<asp:BoundColumn HeaderText="Prev. Estoque" DataFormatString='{0:0.0}' DataField='Dias_Coberto' SortExpression='Coberto' />
					</Columns>
				</asp:DataGrid>
			</center>
		</form>
	</body>
</html>
