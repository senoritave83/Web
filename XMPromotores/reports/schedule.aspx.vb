Imports System.Configuration.ConfigurationManager
Imports System.Data

Partial Class reports_schedule
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            BindNomeRelatorio()
            BindGrid()
        End If

    End Sub

    Protected Sub BindNomeRelatorio()

        Try
            XMReportDataSource1.ReportPath = SettingsExpression.GetProperty("reportspath", "", "/")
            cboNomeRelatorio.DataSource = XMReportDataSource1
            cboNomeRelatorio.DataBind()
            cboNomeRelatorio.Items.Insert(0, New ListItem("Todos", ""))

        Catch ex As Exception

            Erro(ex.Message)
        End Try

    End Sub

    Protected Sub BindGrid()

        Try
            XMScheduleDataSource1.ReportName = cboNomeRelatorio.SelectedValue
            XMScheduleDataSource1.StatusExecution = cboStatusExecucao.SelectedValue
            XMScheduleDataSource1.ReportPath = SettingsExpression.GetProperty("reportspath", "", "/")
            XMScheduleDataSource1.SchedulingServerURL = AppSettings("SchedulingServerURL")

            GridView1.DataSource = XMScheduleDataSource1
            GridView1.DataBind()

        Catch ex As Exception

            Erro(ex.Message)
        End Try

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

    Protected Sub Erro(ByVal msg As String)

        Dim errorMsg As String = "Agendamento não disponível devido ao seguinte erro: \n" & msg
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alert", "alert('" & errorMsg & "');", True)
    End Sub

    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound

        GridView1.Columns(4).Visible = VerificaPermissao("Serviço de Relatórios - Relatórios Agendados", "Excluir Agendamento")

    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        BindGrid()
    End Sub
End Class
