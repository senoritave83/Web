
Partial Class relatorios_reletapas_prn
    Inherits XMProtectedPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False
    Protected colColors As List(Of String)


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()

        intTotal = 0
        blnTotal = False

        Dim strDataInicio As String = Request("di")
        Dim strDataFinal As String = Request("df")

        colColors = New List(Of String)

        Dim dr As IDataReader = cls.GetReport_Etapas(strDataInicio, strDataFinal)

        Do While dr.Read
            colColors.Add(dr.GetString(2))
            With grdRelatorio.Columns.Item(dr.GetInt32(0) + 1)
                .Visible = True
                .HeaderText = dr.GetString(1)
            End With
        Loop

        If dr.NextResult Then
            grdRelatorio.DataSource = dr
            grdRelatorio.DataBind()
        End If

        ltTitulo.Text = "Relat&oacute;rio de etapas realizadas  de " & strDataInicio & " até " & strDataFinal

    End Sub

    Protected Sub grdRelatorio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorio.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim intRealizada As Integer = e.Row.DataItem("Realizadas")
            Dim strColor As String = ""
            If intRealizada > 0 Then
                If Not IsDBNull(e.Row.DataItem("ColorEtapa" & intRealizada)) Then
                    strColor = e.Row.DataItem("ColorEtapa" & intRealizada)
                End If
            End If
            For i As Integer = 1 To e.Row.DataItem("Realizadas")
                If strColor <> "" Then
                    e.Row.Cells(i + 1).BackColor = Drawing.ColorTranslator.FromHtml(strColor)
                End If
            Next
        End If
    End Sub

    Protected Function GetPercentageExport(ByVal vTotal As Integer, ByVal vRealizadas As Integer) As Double
        If vTotal = 0 Or vRealizadas = 0 Then
            Return 0
        Else
            Return ((vRealizadas / vTotal))
        End If
    End Function
  
End Class
