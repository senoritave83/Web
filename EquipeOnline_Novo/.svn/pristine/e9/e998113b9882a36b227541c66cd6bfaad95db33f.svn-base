
Partial Class relatorios_relperformance_prn
    Inherits XMProtectedPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()
        Dim strDataInicial As String = Request("di")
        Dim strDataFinal As String = Request("df")
        intTotal = 0
        blnTotal = False
        grdRelatorio.DataSource = cls.GetReport_Performance(strDataInicial, strDataFinal)
        grdRelatorio.DataBind()

        ltTitulo.Text = "Relat&oacute;rio de Performance por Respons&aacute;vel. de " & strDataInicial & " até " & strDataFinal

    End Sub

    Protected Function GetPercentage(ByVal vTotal As Integer, ByVal vRealizadas As Integer) As Integer
        If vTotal = 0 Or vRealizadas = 0 Then
            Return 0
        Else
            Return ((vRealizadas * 85) / vTotal)
        End If
    End Function

    Protected Function GetPercentageExport(ByVal vTotal As Integer, ByVal vRealizadas As Integer) As Double
        If vTotal = 0 Or vRealizadas = 0 Then
            Return 0
        Else
            Return ((vRealizadas / vTotal))
        End If
    End Function

End Class
