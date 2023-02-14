Imports System.Configuration.ConfigurationManager

Partial Class reports_schedule
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            XMScheduleDataSource1.ReportPath = SettingsExpression.GetProperty("reportspath", "", "/")
            XMScheduleDataSource1.SchedulingServerURL = AppSettings("SchedulingServerURL")
        End If
    End Sub

    Protected Function GetStatus(ByVal vStatus As Object, ByVal vDate As Object) As String
        If IsDBNull(vStatus) Then
            Return ""
        ElseIf vStatus = True Then
            Return "Executado com sucesso <br /> (" & vDate & ")"
        Else
            Return "Erro na execução <br /> (" & vDate & ")"
        End If

    End Function

    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound

        GridView1.Columns(4).Visible = VerificaPermissao("Serviço de Relatórios - Relatórios Agendados", "Excluir Agendamento")

    End Sub

End Class
