Imports Classes


Partial Class Relatorios_status
    Inherits XMWebPage
    Protected Soma As New Somarizador


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(Request("em"), Request("sup"), Request("di"), Request("df"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDSupervisor, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdSupervisor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        Dim rep As New clsRelatorio
        grdRelatorio.DataSource = rep.GetRelatorioStatus(vIdEmpresa, vIdSupervisor, vDataInicial, vDataFinal)
        grdRelatorio.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class
