
Imports Classes
Imports System.Data
Partial Class Relatorios_RelatorioPreco_det
    Inherits XMWebPage
    Protected Soma As New Somarizador


   Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDCategoriaPesq, Filtro1.Marcas, Filtro1.IDProdutoPesq, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

    Private Sub showData(ByVal vIDEmpresa As Integer, ByVal vIDCategoriaPesq As Integer, ByVal vIDMarcas As Integer, ByVal vIdIDProduto As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        Dim rep As New clsRelatorio
        grdRelatorioPreco.DataSource = rep.GetRelatorioPreco(vIDEmpresa, vIDCategoriaPesq, vIDMarcas, vIdIDProduto, vDataInicial, vDataFinal)
        grdRelatorioPreco.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Request("pr") = "2" Then
            showData(CInt(Request("em")), (CInt(Request("catpesq"))), CInt(Request("mar")), CInt(Request("prodpesq")), Request("di"), Request("df"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class
