Imports System.Diagnostics

Partial Class XMError
    Inherits XMWebPage


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim objErr As New Exception
        objErr = Server.GetLastError().GetBaseException()
        Dim err As String = "<b>Ocorreu um erro na aplicação</b><br>Se o error persistir, entre em contato com o administrador do sistema.<hr><br>" & _
                              "<br><b>Error in: </b>" + Request.Url.ToString() & _
                              "<br><b>Error Message: </b>" + objErr.Message.ToString() & _
                              "<br><b>Stack Trace:</b><br>" & _
                            objErr.StackTrace.ToString()
        lblErrorMessage.Text = err.ToString()
        Server.ClearError()

    End Sub
End Class
