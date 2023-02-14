<%@ Application Language="VB" %>
<script runat="server">

    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Try
            Dim cn As New System.Data.SqlClient.SqlConnection(Application("cnStr"))
            cn.Open()
            Dim myCommand As New System.Data.SqlClient.SqlCommand
            myCommand.Connection = cn
            Dim err As Exception = Server.GetLastError
            myCommand.CommandText = "SP_WEB_IN_ERRO '" & err.ToString().Replace("'", "''") & "'"
            myCommand.CommandType = CommandType.Text
            myCommand.ExecuteNonQuery()
            cn.Close()
            myCommand.Dispose()
            cn = Nothing
        Catch er As Exception
            'Nada
        End Try
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>