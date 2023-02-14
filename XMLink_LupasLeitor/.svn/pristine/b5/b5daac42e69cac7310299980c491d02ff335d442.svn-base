Imports System.Configuration.ConfigurationManager

Partial Class Relatorios_history
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            XMScheduleDataSource1.ReportPath = AppSettings("reportspath")
            XMScheduleDataSource1.SchedulingServerURL = AppSettings("SchedulingServerURL")
            XMScheduleDataSource1.IDSchedule = Request("idschedule")
        End If
    End Sub

    Protected Function GetStatus(ByVal vStatus As Object, ByVal vDate As Object) As String
        If IsDBNull(vStatus) Then
            Return ""
        ElseIf vStatus = True Then
            Return "Executado com sucesso"
        Else
            Return "Erro na execução"
        End If

    End Function

End Class
