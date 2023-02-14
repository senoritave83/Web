Imports System.Data.SqlClient
Imports System.Xml
Imports System.Configuration.ConfigurationManager

Public Class DataClass
    Inherits XMSistemas.Web.Base.DataClass
    Private m_strConnectionString As String
    Private m_Identity As clsIdentity
    Protected SQLPREFIXO As String = "SP_EOL_WEB_"
    Private m_colBrokenRules As New List(Of String)


    'Public Enum enReturnType
    '    DataReader = 0
    '    DataSet = 1
    'End Enum

    'Private Function GetDBConnection() As SqlConnection
    '    Return New SqlConnection(GetConnectionString)
    'End Function

    'Protected Function GetConnectionString() As String
    '    Return ConnectionStrings.Item("cnStr").ConnectionString
    'End Function

    Public Sub New()
        m_Identity = New clsIdentity
        'SQLPREFIXO = AppSettings("SQLPrefix")
    End Sub

    Public ReadOnly Property Identity() As clsIdentity
        Get
            Return m_Identity
        End Get
    End Property

    'Protected Sub ExecuteNonQuery(ByRef cmd As SqlCommand)
    '    Dim cn As SqlConnection = GetDBConnection()
    '    Try
    '        cmd.Connection = cn
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '    Finally
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '    End Try
    'End Sub

    'Protected Function ExecuteReader(ByRef cmd As SqlCommand) As SqlDataReader
    '    Dim cn As SqlConnection = GetDBConnection()
    '    Dim dr As SqlDataReader = Nothing
    '    Try
    '        cmd.Connection = cn
    '        cn.Open()
    '        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '    Catch ex As Exception
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '        Throw ex
    '    End Try
    '    Return dr
    'End Function


    'Protected Function ExecuteCommand(ByVal cmd As SqlCommand, ByVal vReturnType As enReturnType) As Object
    '    Dim ret As Object = Nothing
    '    Dim cn As SqlConnection = GetDBConnection()
    '    cmd.Connection = cn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cn.Open()
    '    If vReturnType = enReturnType.DataReader Then
    '        ret = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '    Else
    '        Try
    '            Dim adp As New SqlDataAdapter(cmd)
    '            Dim ds As New DataSet
    '            adp.Fill(ds)
    '            ret = ds
    '        Finally
    '            If (Not cn Is Nothing) Then
    '                cn.Close()
    '                cn = Nothing
    '            End If
    '        End Try
    '    End If
    '    Return ret
    'End Function


    'Protected Function ExecuteScalar(ByRef cmd As SqlCommand) As Object
    '    Dim cn As SqlConnection = GetDBConnection()
    '    Dim ret As Object = Nothing
    '    Try
    '        cmd.Connection = cn
    '        cn.Open()
    '        ret = cmd.ExecuteScalar()
    '    Finally
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '    End Try
    '    Return ret
    'End Function

    'Protected Function ExecuteDataSet(ByRef cmd As SqlCommand) As DataSet
    '    Dim cn As SqlConnection = GetDBConnection()
    '    Dim myData As New DataSet("data")

    '    Try
    '        cmd.Connection = cn
    '        cn.Open()
    '        Dim adapter As New SqlDataAdapter(cmd)
    '        adapter.Fill(myData)
    '        adapter.Dispose()
    '    Finally
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '    End Try
    '    Return myData
    'End Function

    'Protected Function ExecuteXML(ByRef cmd As SqlCommand) As String
    '    Dim cn As SqlConnection = GetDBConnection()
    '    Dim strXML As String = "<?xml version=""1.0"" encoding=""iso-8859-1""?>"
    '    Try
    '        cmd.Connection = cn
    '        cn.Open()

    '        strXML &= "<xml>"

    '        Dim xmlR As XmlReader = cmd.ExecuteXmlReader()
    '        With xmlR
    '            .Read()
    '            Do While .ReadState <> System.Xml.ReadState.EndOfFile
    '                strXML &= .ReadOuterXml
    '            Loop
    '            .Close()
    '        End With
    '        cmd.Dispose()
    '        strXML &= "</xml>"
    '    Finally
    '        If (Not cn Is Nothing) Then
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '    End Try
    '    Return strXML
    'End Function



    'Protected Function ExecutePaginate(ByVal cmd As SqlCommand, ByVal vReturnType As enReturnType, ByVal vPageSize As Integer, ByVal vPage As Integer) As PaginateResult
    '    Dim ret As New PaginateResult
    '    If vReturnType = enReturnType.DataReader Then
    '        Dim dr As IDataReader = ExecuteReader(cmd)
    '        If dr.Read Then
    '            ret.PageSize = vPageSize
    '            ret.CurrentPage = vPage
    '            ret.RecordCount = dr.GetInt32(0)
    '            If dr.NextResult Then
    '                ret.Data = dr
    '            End If
    '        End If
    '    Else
    '        Dim ds As DataSet = ExecuteDataSet(cmd)
    '        ret.PageSize = vPageSize
    '        ret.CurrentPage = vPage
    '        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
    '        ret.Data = ds.Tables(1)
    '    End If
    '    Return ret
    'End Function



    ' ''' <summary>
    ' ''' Função Responsável por tranformar a data padrão em data interna
    ' ''' </summary>
    ' ''' <param name="Value"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function _setDateTimePropertyValue(ByVal Value As String) As String
    '    If IsDate(Value) Then
    '        Return CDate(Value).ToString("yyyy-MM-dd HH:mm:ss")
    '    Else
    '        Return ""
    '    End If
    'End Function

    ' ''' <summary>
    ' ''' Função Responsável por tranformar a data interna em uma data padrão
    ' ''' </summary>
    ' ''' <param name="Value"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function _getDateTimePropertyValue(ByVal Value As String) As String
    '    If IsDate(Value) Then
    '        Return CDate(Value).ToString("dd/MM/yyyy HH:mm:ss")
    '    Else
    '        Return ""
    '    End If
    'End Function

    ' ''' <summary>
    ' ''' Função Responsável por tranformar a data interna em uma data padrão
    ' ''' </summary>
    ' ''' <param name="Value"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function _getDatePropertyValue(ByVal Value As String) As String
    '    If IsDate(Value) Then
    '        Return CDate(Value).ToString("dd/MM/yyyy")
    '    Else
    '        Return ""
    '    End If
    'End Function



    ' ''' <summary>
    ' ''' Função Responsável por transformar o valor gravado no SQL em formato string interno 
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function _getDateTimeDBValue(ByVal Value As Date) As String
    '    Return Value.ToString("yyyy-MM-dd hh:mm:ss")
    'End Function

    ' ''' <summary>
    ' ''' Função Responsável por transformar o valor no formato string interno em um valor Date 
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function _setDateTimeDBValue(ByVal Value As String) As Date
    '    Return CDate(Value)
    'End Function

    Public Function isValid() As Boolean
        m_colBrokenRules.Clear()
        Return CheckIfSubClassIsValid()
    End Function

    Protected Overridable Function CheckIfSubClassIsValid() As Boolean
        Return True
    End Function

    Public Function BrokenRules() As List(Of String)
        Return m_colBrokenRules
    End Function

    Protected Sub AddBrokenRule(ByVal vMessage As String)
        m_colBrokenRules.Add(vMessage)
    End Sub

    'Public Function GetXML(ByVal SQL As String) As String

    '    Dim strXML As String = "<?xml version=""1.0"" encoding=""iso-8859-1""?><xml>"
    '    Open()

    '    Dim myCommand As New SqlCommand()
    '    myCommand.Connection = Connection
    '    myCommand.CommandText = SQL
    '    myCommand.CommandType = CommandType.Text

    '    Dim xmlR As XmlReader = myCommand.ExecuteXmlReader
    '    xmlR.Read()
    '    Do While xmlR.ReadState <> ReadState.EndOfFile
    '        strXML &= xmlR.ReadOuterXml
    '    Loop
    '    Close()
    '    myCommand.Dispose()
    '    Return strXML & "</xml>"
    'End Function



End Class
