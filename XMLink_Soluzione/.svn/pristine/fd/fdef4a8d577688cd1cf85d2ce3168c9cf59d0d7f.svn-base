Public Class clsMotivo
    Inherits clsBaseClass
    Protected m_intIDMotivo As Integer
    Protected m_strMotivo As String

    Public ReadOnly Property IDMotivo() As Integer
        Get
            Return m_intIDMotivo
        End Get
    End Property

    Public Property Motivo() As String
        Get
            Return m_strMotivo
        End Get
        Set(ByVal Value As String)
            m_strMotivo = Value
        End Set
    End Property

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDMotivo = CLng(0 & row("mot_Motivo_int_PK"))
        m_strMotivo = row("mot_Motivo_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDMotivo & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strMotivo.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_MOTIVO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDMotivo As Integer)
        If p_intIDMotivo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_MOTIVO " & p_intIDMotivo & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDMotivo = 0
        m_strMotivo = ""
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_MOTIVO " & m_intIDMotivo & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_MOTIVO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub


    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Public Function Listar() As DataSet
        Return Listar("", "", False, 0, 0)
    End Function

    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_MOTIVOS " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

End Class
