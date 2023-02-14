Imports Classes

Partial Class Relatorios_performancelog_det
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios Logística", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            Dim rep As New clsRelatorio
            grdRelatorio.DataSource = rep.GetRelatorioPerformanceLogistica(vIDEmpresa, Request("di"), Request("df"), Request("pl"))
            grdRelatorio.DataBind()
            rep = Nothing

        End If
    End Sub

    Function FormataPasta(ByVal vPasta As String) As String

        If Len(vPasta) > 2 Then
            vPasta = Left(vPasta, Len(vPasta) - 2)
        Else
            vPasta = "Sem Rota"
        End If

        Return vPasta

    End Function

End Class
