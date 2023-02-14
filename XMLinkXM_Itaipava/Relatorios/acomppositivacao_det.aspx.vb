Imports Classes

Partial Class Relatorios_acomppositivacao
    Inherits XMWebPage


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(CInt(Request("em")), Request("di"), Request("df"), CInt(Request("ger")), CInt(Request("sup")))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.DataInicial, Filtro1.DataFinal, Filtro1.IDGerente, Filtro1.IDSupervisor)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer)

        Dim rep As New clsRelatorio
        grdRelatorio.DataSource = rep.GetRelatorioAcompanhamentoPositivacao(vIdEmpresa, vDataInicial, vDataFinal, vIdGerente, vIdSupervisor)
        grdRelatorio.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class
