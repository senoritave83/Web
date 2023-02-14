Public Class clsRelatorio
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function GetReport_Periodo(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Return GetDataSet(PREFIXO & "RPT_PERIODO " & XMPage.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Status(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Return GetDataSet(PREFIXO & "RPT_STATUS " & XMPage.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Clientes(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Return GetDataSet(PREFIXO & "RPT_CLIENTES " & XMPage.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Public Function GetReport_Vendedor(ByVal vDataIni As Date, ByVal vDataFim As Date) As DataSet
        Return GetDataSet(PREFIXO & "RPT_VENDEDOR " & XMPage.IDEmpresa & ", '" & vDataIni.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & vDataFim.ToString("yyyy-MM-dd HH:mm:ss") & "'")
    End Function

    Protected Function Serialize(ByVal ds As DataSet) As String
        Dim strX, strY As String
        strX = "xValues="
        strY = "yValues="
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            strX &= ds.Tables(0).Rows(i).Item(0) & "|"
            strY &= ds.Tables(0).Rows(i).Item(1) & "|"
        Next
        strX = strX.TrimEnd("|")
        strY = strY.TrimEnd("|")
        Return strX & "&" & strY
    End Function

End Class
