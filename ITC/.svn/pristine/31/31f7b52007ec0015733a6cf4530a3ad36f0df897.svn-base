<%@ Page Language="VB" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Security" %>
<script runat="server">

    Sub Page_Load(sender As Object, e As EventArgs)
         Dim sconn As String
         Dim conn As New Sqlconnection
         Dim comm As New SqlCommand
         Dim sqlRd As SqlDataReader
    
         sconn = ConfigurationSettings.AppSettings("ConnectionString")
	 conn = New SqlConnection(sconn) 'New SqlConnection("server=127.0.0.1; uid=sa; pwd=Sucesso; database=BD_1906")'
    
         comm.Connection = conn
    
         comm.CommandText = "SP_SE_ULTIMA_DICA"
         comm.CommandType = CommandType.StoredProcedure
    
         conn.open()
    
         sqlrd = comm.ExecuteReader()
    
         dltDica.DataSource = sqlrd
         dltDica.DataBind()
    
         sqlrd.Close()
         conn.Close()
         conn.Dispose()
    
    End Sub

</script>
<html>
<head>
<style language="StyleSheet" type="text/Css">
BODY {
scrollbar-face-color:#FD9B30;
scrollbar-highlight-color:#FED4AC;
scrollbar-3dlight-color:#FFFFFF;
scrollbar-darkshadow-color:#FFFFFF;
scrollbar-shadow-color:#FED4AC;
scrollbar-arrow-color:#000000;
scrollbar-track-color:#DEDEDE;
}
.tema {
font-size: 12px;
font-family: Verdana, Arial, helvetica;
font-weight: bold;
}
.testo {
font-size: 12px;
font-family: Verdana, Arial, helvetica;
}
</style>
</head>
<body topmargin="0" leftmargin="0" marginbottom="0" marginright="0" bgcolor="transparent" allowtransparency="true">
    <form runat="server">
        <div id="dica" runat="server" border="0" style="background-color: transparent;">
            <asp:DataList runat="server" id="dltDica">
                <ItemTemplate>
                    <table cellspacing="2" cellpadding="5">
                        <tr>
                            <td align="left" class="tema">
                                <b><%# DataBinder.Eval(Container.DataItem, "Titulo") %> </b> <br /> <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:justify" class="testo">
                                <div runat="server" border="0" style="overflow: no; margin-top: 15px; width: 205px; height: 170px; background-color: transparent;">
                                <%# DataBinder.Eval(Container.DataItem, "Descricao") %>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
