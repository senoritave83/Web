Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports System.Xml


Public Class DataClass
    Protected PREFIXO As String = "SP_"

    Public Enum enReturnType
        DataReader = 0
        DataSet = 1
    End Enum
    
    Protected Function GetDBConnection() As SqlConnection
        Return New SqlConnection(ConnectionStrings.Item("cnStr").ConnectionString)
    End Function

    Protected Function GetConnectionString() As String
        Return ConnectionStrings.Item("cnStr").ConnectionString
    End Function

    Protected Function ExecuteCommand(ByVal cmd As SqlCommand, ByVal vReturnType As enReturnType) As Object
        Dim ret As Object = Nothing
        Dim cn As SqlConnection = GetDBConnection()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cn.Open()
        If vReturnType = enReturnType.DataReader Then
            ret = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Else
            Try
                Dim adp As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds)
                ret = ds
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
        End If
        Return ret
    End Function

    Protected Function ExecuteCommand(ByVal p_SQL As String, ByVal vReturnType As enReturnType) As Object
        Dim ret As Object = Nothing
        Dim cn As SqlConnection = GetDBConnection()
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = p_SQL
        cmd.Connection = cn
        cn.Open()
        If vReturnType = enReturnType.DataReader Then
            ret = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Else
            Try
                Dim adp As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                adp.Fill(ds)
                ret = ds
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
        End If
        Return ret
    End Function


    Protected Sub ExecuteNonQuery(ByVal cmd As SqlCommand)
        Dim cn As SqlConnection = GetDBConnection()
        cmd.Connection = cn
        cn.Open()
        Try
            cmd.ExecuteNonQuery()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If

        End Try
    End Sub


    Protected Function ExecuteReader(ByRef cmd As SqlCommand) As SqlDataReader
        Dim cn As SqlConnection = GetDBConnection()
        Dim dr As SqlDataReader = Nothing
        Try
            cmd.Connection = cn
            cn.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
            Throw ex
        End Try
        Return dr
    End Function

    Protected Function ExecuteScalar(ByRef cmd As SqlCommand) As Object
        Dim cn As SqlConnection = GetDBConnection()
        Dim ret As Object = Nothing
        Try
            cmd.Connection = cn
            cn.Open()
            ret = cmd.ExecuteScalar()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
        Return ret
    End Function

    Protected Function ExecuteDataSet(ByRef cmd As SqlCommand) As DataSet
        Dim cn As SqlConnection = GetDBConnection()
        Dim myData As New DataSet("data")

        Try
            cmd.Connection = cn
            cn.Open()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(myData)
            adapter.Dispose()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
        Return myData
    End Function

    Protected Function ExecutePaginate(ByVal cmd As SqlCommand, ByVal vReturnType As enReturnType, ByVal vPageSize As Integer, ByVal vPage As Integer) As PaginateResult
        Dim ret As New PaginateResult
        If vReturnType = enReturnType.DataReader Then
            Dim dr As IDataReader = ExecuteReader(cmd)
            If dr.Read Then
                ret.PageSize = vPageSize
                ret.CurrentPage = vPage
                ret.RecordCount = dr.GetInt32(0)
                If dr.NextResult Then
                    ret.Data = dr
                End If
            End If
        Else
            Dim ds As DataSet = ExecuteDataSet(cmd)
            ret.PageSize = vPageSize
            ret.CurrentPage = vPage
            ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
            ret.Data = ds.Tables(1)
        End If
        Return ret
    End Function


    Protected Function ExecuteXML(ByRef cmd As SqlCommand) As String
        Dim cn As SqlConnection = GetDBConnection()
        Dim strXML As String = "" ' <?xml version=""1.0"" encoding=""iso-8859-1""?>"
        Try
            cmd.Connection = cn
            cn.Open()

            Dim xmlR As XmlReader = cmd.ExecuteXmlReader()
            With xmlR
                .Read()
                Do While .ReadState <> System.Xml.ReadState.EndOfFile
                    strXML &= .ReadOuterXml
                Loop
                .Close()
            End With
            cmd.Dispose()
            If Not strXML.StartsWith("<?xml") Then
                strXML = "<?xml version=""1.0"" encoding=""iso-8859-1""?>" & strXML
            End If
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
        Return strXML
    End Function

    Public Sub New()
        PREFIXO = AppSettings("SQLPrefix")
    End Sub
End Class
