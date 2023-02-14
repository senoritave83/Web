<%@ Page Inherits="xmlinkwm.XMProtectedPage" validateRequest="false" %>
<%@ Import Namespace="xmlinkwm.com.xmsistemas.maps" %>

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
	
	Private Sub btnOpenMap_Click(ByVal sender As Object, ByVal e As System.EventArgs) 
	
	        Dim map As GMapService
			map = new GMapService()
            Dim strID As String = map.RegistraPosicionamento(hidXMLMapa.value)
            Dim strURL As String = "http://maps.xmsistemas.com/xmgmapservice/viewmap.aspx?key=" & strID
            
            litScript.Text = "<scr" & "ipt language=""javascript"">window.open('" & strURL & "','MAPA');</scri" & "pt>"
			BindGrid()
	end Sub
	
	Private Sub BindGrid()
	
		Dim p_DataInicio as string = "", p_DataFinal as string = ""
		p_DataInicio = request("datainicio")
		p_DataFinal = request("datafinal")
		
		if isdate(p_DataInicio) and isdate(p_DataFinal) then
		
			p_DataInicio = right("0000" & year(p_DataInicio),4) & "-" & Right("00" & Month(p_DataInicio),2) & "-" & Right("00" & Day(p_DataInicio),2)
			p_DataFinal = right("0000" & year(p_DataFinal),4) & "-" & Right("00" & Month(p_DataFinal),2) & "-" & Right("00" & Day(p_DataFinal),2)
					
			dim cls as New xmlinkwm.DataClass(ConnectionString)
			dtsLista = cls.GetDataSet("SP_SOL_WEB_RPT_VISITA_CLI " & IDEmpresa & ",'" & p_DataInicio & "','" & p_DataFinal & "', " & Request("ven"))  
			
			dtgLista.DataSource = dtsLista
			dtgLista.DataBind
			
			hidXMLMapa.value = dtsLista.tables(1).rows(0).item(0)
					
			cls = Nothing
			

		end if
		
		
	End Sub
		
		</script>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" rel="StyleSheet" type="text/css">
  </HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form runat="server">
			<input type='hidden' id='hidXMLMapa' runat='server' >
			<center>
				<br>
				<b class='TextDefault' style='FONT-SIZE:10pt;FONT-WEIGHT:bold'>Relatório de Visitas</b>
				<br>
			<table width="100%" runat=server id=tblImprime>
				<tr class='TextDefault' style='FONT-SIZE:10pt'>
					<td>
						<b>Vendedor:</b> <%=Request("nome")%>
					</td>
				</tr>
				<tr class='TextDefault' style='FONT-SIZE:10pt'>
					<td>
						<b>Data Inicial:</b> <%=Right("00" & Day(Request("datainicio")),2) & "/" & Right("00" & Month(Request("datainicio")),2) & "/" & right("0000" & year(Request("datainicio")),4)%>&nbsp;
						<b>Data Final:</b> <%=Right("00" & Day(Request("datafinal")),2) & "/" & Right("00" & Month(Request("datafinal")),2) & "/" & right("0000" & year(Request("datafinal")),4)%>
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
			<asp:Label Runat="server" ID="lblSituacao" CssClass="TextDefault" style='FONT-SIZE:10pt;FONT-WEIGHT:bold'></asp:Label>
			<asp:Button Runat="server" ID="btnOpenMap" CssClass="Botao" OnClick="btnOpenMap_Click" Text="Ver Mapa"></asp:Button>
			<asp:Literal Runat="server" ID="litScript" Text=""></asp:Literal>
		</form>
	</body>
</HTML>
