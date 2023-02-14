Imports Classes
Imports System.Data

Partial Class Relatorios_historico_visitas
    Inherits XMWebPage


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then
            Dim vIdCliente As Integer = 0
            If IsNumeric(Request("codcli") & "") Then
                vIdCliente = CInt(Request("codcli"))
            End If

            showData(CInt(Request("em")), vIdCliente, Request("cli"), CInt(Request("stavis")), Request("di"), Request("df"), Request("vend"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.CodigoCliente, Filtro1.NomeCliente, Filtro1.StatusVisita, Filtro1.DataInicial, Filtro1.DataFinal, Filtro1.IDVendedor)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vCodigoCliente As Integer, ByVal vNomeCliente As String, ByVal vStatusVisita As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDVendedor As Integer)

        Dim rep As New clsRelatorio
        grdRelatorio.DataSource = rep.GetRelatorioVisita(vIdEmpresa, vCodigoCliente, vNomeCliente, vStatusVisita, vDataInicial, vDataFinal, vIDVendedor)
        grdRelatorio.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub
End Class
