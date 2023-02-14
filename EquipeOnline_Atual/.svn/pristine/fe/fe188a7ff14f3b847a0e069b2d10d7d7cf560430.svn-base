
Partial Class home_resumo
    Inherits XMProtectedPage


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IsPostBack Then

            Dim cls As New clsOrdemServico()
            dtgGrid.DataSource = cls.ListaResumo
            dtgGrid.DataBind()
            Dim intCount As Integer = cls.Total_OS
            If intCount = 0 Then
                lblMessage.Text = "Não há ordens de serviço."
            ElseIf intCount = 1 Then
                lblMessage.Text = "Você tem <b>1</b> ordem de serviço."
            Else
                lblMessage.Text = "Você tem <b>" & intCount & "</b> ordens de serviço."
            End If

        End If

    End Sub

End Class
