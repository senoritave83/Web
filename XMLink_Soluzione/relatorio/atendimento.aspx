<%@ Page Inherits="xmlinkwm.XMProtectedPage" %>
<HTML>
	<HEAD>
		<title>.: XMLink 2.0 :.</title>
		<script language="VB" runat="server">

	Dim dtsLista As System.Data.Dataset		
	
	Sub Page_Load(Source as Object, E as EventArgs)	Handles MyBase.Load	

		addHandler dtgLista.ItemDataBound, AddressOf Me.dtgLista_ItemDataBound
		
		addHandler dtgCategoria.ItemDataBound, AddressOf Me.dtgCategoria_ItemDataBound
	
		If not page.IsPostBack Then
			
			dim nome as string
			nome=Request("nome")
						
			if nome="" then
				tblImprime.visible = false			
			else
				tblImprime.visible = true
			end if	
		
			BindGrid()
		end if

	end sub

	Private Sub BindGrid()
	
		Dim dtCur As Date
		dtCur = CDate("01/" & Request("mes") & "/" & Request("ano"))
		ViewState("vPeriodo") = dtCur.toString("MMMM") & "/" & dtCur.toString("yyyy")
		dtCur = Dateadd(DateInterval.Month, -1, dtCur)
		ViewState("vPeriodo1") = dtCur.toString("MMMM") & "/" & dtCur.toString("yyyy")
		dtCur = Dateadd(DateInterval.Month, -1, dtCur)
		ViewState("vPeriodo2") = dtCur.toString("MMMM") & "/" & dtCur.toString("yyyy")
							
		dim cls as New xmlinkwm.DataClass(ConnectionString)
		dtsLista = cls.GetDataSet("SP_SOL_WEB_RPT_ATEND_CLI " & IDEmpresa & ", " & Request("mes") & ", " & Request("ano") & ", " & Request("ven") & "")  
		
		dtgLista.DataSource = dtsLista.Tables(0)
		dtgLista.DataBind

		dtgCategoria.DataSource = dtsLista.Tables(2)
		dtgCategoria.DataBind
				
		dtgResumo.DataSource = dtsLista.Tables(3)
		dtgResumo.DataBind
		
		lblSituacao.Text = dtsLista.Tables(4).Rows(0)(0)
		
		cls = Nothing
	End Sub

	Private Sub dtgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) 
		If e.Item.ItemType = ListItemType.Header Then
			e.Item.Cells(4).Text = ViewState("vPeriodo2")
			e.Item.Cells(6).Text = ViewState("vPeriodo1")
			e.Item.Cells(8).Text = ViewState("vPeriodo")
		ElseIf e.Item.ItemType = ListItemType.Footer Then
			Dim dtbSum As System.Data.DataTable
			dtbSum = dtsLista.Tables(1)
			If dtbSum.rows.Count > 0 Then
				e.Item.Cells(1).Text = "TOTAL"
				e.Item.Cells(3).Text = dtbSum.rows(0)("NPed-2")
				e.Item.Cells(4).Text = FormatCurrency(dtbSum.rows(0)("Val-2"), 2)
				e.Item.Cells(5).Text = dtbSum.rows(0)("NPed-1")
				e.Item.Cells(6).Text = FormatCurrency(dtbSum.rows(0)("Val-1"), 2)
				e.Item.Cells(7).Text = dtbSum.rows(0)("NPed")
				e.Item.Cells(8).Text = FormatCurrency(dtbSum.rows(0)("Val"), 2)
				e.Item.Cells(9).Text = dtbSum.rows(0)("NPed Media")
				e.Item.Cells(10).Text = FormatCurrency(dtbSum.rows(0)("Val Media"), 2)
			End If			
		End If
	End Sub	

	Private Sub dtgCategoria_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) 
		If e.Item.ItemType = ListItemType.Header Then
			e.Item.Cells(2).Text = ViewState("vPeriodo2")
			e.Item.Cells(3).Text = ViewState("vPeriodo1")
			e.Item.Cells(4).Text = ViewState("vPeriodo")
		End If
	End Sub	
		
		</script>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" rel="StyleSheet" type="text/css">
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form runat="server">
			<table width=100% runat=server id=tblImprime>
				<tr>
					<td align=center class='TextDefault' style='FONT-WEIGHT:bold;FONT-SIZE:10pt' colspan=3>
						<b>Relatório</b><br><br>
					</td>
				</tr>
				<tr class='TextDefault' style='FONT-WEIGHT:bold;FONT-SIZE:10pt'>
					<td>
						Vendedor: <%=Request("nome")%>
					</td>
					<td align=right>
						Mês: <%=Request("mes")%>
					</td>
					<td align=right>
						Ano: <%=Request("ano")%>
					</td>
				</tr>
			</table>
			<center>
				<br>
				<b class='TextDefault' style='FONT-WEIGHT:bold;FONT-SIZE:10pt'>Atendimento de Clientes</b>
				<br>
				<div id="divReport">
					<asp:DataGrid Runat="server" ID='dtgLista' Width="100%" AutoGenerateColumns="False" AllowSorting="False" ShowFooter="True" EnableViewState="False"
						CssClass='TextDefault' BorderStyle="none">
						<HeaderStyle ForeColor="White" CssClass='Header' />
						<FooterStyle ForeColor="White" CssClass='Header' />
						<ItemStyle CssClass="GridItem" />
						<Columns>
							<asp:BoundColumn HeaderText="Cód." DataField='cli_Codigo_chr' />
							<asp:BoundColumn HeaderText="Cliente" DataField='cli_Cliente_chr' />
							<asp:BoundColumn HeaderText="CNPJ" DataField='cli_CNPJ_chr' />
							<asp:TemplateColumn HeaderText='' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "NPed-2")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo2")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val-2"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "NPed-1")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo1")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val-1"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "NPed")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "NPed Media")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Trimestral" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val Media"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
					</asp:DataGrid>
					<br>



					<asp:DataGrid Runat="server" ID="dtgCategoria" Width="100%" AutoGenerateColumns="False" AllowSorting="False" ShowFooter="False" EnableViewState="False"
						CssClass='TextDefault' BorderStyle="none">
						<HeaderStyle ForeColor="White" CssClass='Header' />
						<FooterStyle ForeColor="White" CssClass='Header' />
						<ItemStyle CssClass="GridItem" />
						<Columns>
							<asp:BoundColumn HeaderText="Cód." DataField='cat_Codigo_chr' />
							<asp:BoundColumn HeaderText="Categoria" DataField='cat_Categoria_chr' />
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo2")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val-2"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo1")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val-1"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText='<%=ViewState("vPeriodo")%>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Trimestral" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
								<ItemTemplate>
									<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "Val Media"), 2)%>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
					</asp:DataGrid>






					
					<br>
				</div>
				<br>
				<asp:DataGrid Runat="server" ID="dtgResumo" Width="100%" AutoGenerateColumns="False" AllowSorting="False"
					CssClass='TextDefault' BorderStyle="none">
					<HeaderStyle ForeColor="White" CssClass='Header' />
					<ItemStyle CssClass="GridItem" />
					<Columns>
						<asp:TemplateColumn HeaderText="Valor Vendido">
							<ItemTemplate>
								<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "ValorMes_cur"), 2)%>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn HeaderText="Num. Clientes" DataField='ClientesCarteira_int' />
						<asp:BoundColumn HeaderText="Clientes Atendidos" DataField='ClientesAtendidos_int' />
						<asp:TemplateColumn HeaderText="Média por Cliente">
							<ItemTemplate>
								<%# FormatCurrency(DataBinder.Eval(Container.DataItem, "MediaClientes_cur"), 2)%>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="% Atendimento">
							<ItemTemplate>
								<%# FormatPercent(DataBinder.Eval(Container.DataItem, "PercAtendimentos_num"), 2)%>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</center>
			<br>
			<asp:Label Runat="server" ID="lblSituacao" CssClass="TextDefault" style='FONT-WEIGHT:bold;FONT-SIZE:10pt'></asp:Label>
		</form>
	</body>
</HTML>
