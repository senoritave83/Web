'************************************************************
'Classe gerada por XM Class Creator - 23/1/2003 16:59:11
'************************************************************

Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsContatoObras
    Inherits DataClass

    Private m_intIdContato As Integer
    Private m_intIdObra As Integer
    Private m_strNomeContato As String
    Private m_intIdCargo As Integer
    Private m_strDDD As String
    Private m_strTelefone As String
    Private m_strDDDFax As String
    Private m_strFax As String
    Private m_strEMail As String
    Private m_intIdEmpresa As Integer
    Private m_strEmpresa As String
    Private m_strDDD2 As String
    Private m_strTelefone2 As String
    Private m_intIdTipoTelefone1 As Integer
    Private m_intIdTipoTelefone2 As Integer
    Private m_intIdTipoTelefone3 As Integer

    Public Property IdContato() As Integer
        Get
            Return m_intIdContato
        End Get
        Set(ByVal Value As Integer)
            Load(Value)
        End Set
    End Property

    Public Property IdObra() As Integer
        Get
            Return m_intIdObra
        End Get
        Set(ByVal Value As Integer)
            m_intIdObra = Value
        End Set
    End Property

    Public Property NomeContato() As String
        Get
            Return m_strNomeContato
        End Get
        Set(ByVal Value As String)
            m_strNomeContato = Value
        End Set
    End Property

    Public Property IdCargo() As Integer
        Get
            Return m_intIdCargo
        End Get
        Set(ByVal Value As Integer)
            m_intIdCargo = Value
        End Set
    End Property

    Public Property DDD() As String
        Get
            Return m_strDDD
        End Get
        Set(ByVal Value As String)
            m_strDDD = Value
        End Set
    End Property

    Public Property Telefone() As String
        Get
            Return m_strTelefone
        End Get
        Set(ByVal Value As String)
            m_strTelefone = Value
        End Set
    End Property

    Public Property DDDFax() As String
        Get
            Return m_strDDDFax
        End Get
        Set(ByVal Value As String)
            m_strDDDFax = Value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return m_strFax
        End Get
        Set(ByVal Value As String)
            m_strFax = Value
        End Set
    End Property

    Public Property IdEmpresa() As Integer
        Get
            Return m_intIdEmpresa
        End Get
        Set(ByVal Value As Integer)
            m_intIdEmpresa = Value
        End Set
    End Property

    Public ReadOnly Property Empresa() As String
        Get
            Return m_strEmpresa
        End Get
    End Property

    Public Property EMail() As String
        Get
            Return m_strEMail
        End Get
        Set(ByVal Value As String)
            m_strEMail = Value
        End Set
    End Property

    Public Property DDD2() As String
        Get
            Return m_strDDD2
        End Get
        Set(ByVal Value As String)
            m_strDDD2 = Value
        End Set
    End Property

    Public Property Telefone2() As String
        Get
            Return m_strTelefone2
        End Get
        Set(ByVal Value As String)
            m_strTelefone2 = Value
        End Set
    End Property

    Public Property IdTipoTelefone1() As Integer
        Get
            Return m_intIdTipoTelefone1
        End Get
        Set(ByVal Value As Integer)
            m_intIdTipoTelefone1 = Value
        End Set
    End Property

    Public Property IdTipoTelefone2() As Integer
        Get
            Return m_intIdTipoTelefone2
        End Get
        Set(ByVal Value As Integer)
            m_intIdTipoTelefone2 = Value
        End Set
    End Property

    Public Property IdTipoTelefone3() As Integer
        Get
            Return m_intIdTipoTelefone3
        End Get
        Set(ByVal Value As Integer)
            m_intIdTipoTelefone3 = Value
        End Set
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIdContato = CLng(0 & row("IdContato"))
        Me.m_intIdObra = CLng(0 & row("IdObra"))
        Me.m_strNomeContato = CStr(row("NomeContato") & "")
        Me.m_intIdCargo = CLng(0 & row("IdCargo"))
        Me.m_strDDD = CStr(row("DDD") & "")
        Me.m_strTelefone = CStr(row("Telefone") & "")
        Me.m_strDDDFax = CStr(row("DDDFax") & "")
        Me.m_strFax = CStr(row("Fax") & "")
        Me.m_strEMail = CStr(row("EMail") & "")
        Me.m_intIdEmpresa = CLng(0 & row("IdEmpresa"))
        Me.m_strEmpresa = CStr(row("Fantasia") & "")
        Me.m_strDDD2 = CStr(row("DDD2") & "")
        Me.m_strTelefone2 = CStr(row("Telefone2") & "")
        Me.m_intIdTipoTelefone1 = CLng(0 & row("TipoTelefone1"))
        Me.m_intIdTipoTelefone2 = CLng(0 & row("TipoTelefone2"))
        Me.m_intIdTipoTelefone3 = CLng(0 & row("TipoTelefone3"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIdContato & "" & ","
        strDeflate &= "" & m_intIdObra & "" & ","
        strDeflate &= "'" & m_strNomeContato & "'" & ","
        strDeflate &= "" & m_intIdCargo & "" & ","
        strDeflate &= "'" & m_strDDD & "'" & ","
        strDeflate &= "'" & m_strTelefone & "'" & ","
        strDeflate &= "'" & m_strDDDFax & "'" & ","
        strDeflate &= "'" & m_strFax & "'" & ","
        strDeflate &= "'" & m_strEMail & "',"
        strDeflate &= m_intIdEmpresa & ","
        strDeflate &= "'" & m_strDDD2 & "'" & ","
        strDeflate &= "'" & m_strTelefone2 & "'" & ","
        strDeflate &= m_intIdTipoTelefone1 & ","
        strDeflate &= m_intIdTipoTelefone2 & ","
        strDeflate &= m_intIdTipoTelefone3
        Deflate = strDeflate
    End Function

    Public Sub Update()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Dim sql As String
        sql = "SP_SV_CONTATOOBRAS " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Load(ByVal vData As Integer)
        If vData = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_CONTATOSOBRAS " & vData)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub Delete(ByVal p_IdContato As Integer, ByVal p_IdObra As Integer)
        ExecuteNonQuery("SP_DE_CONTATOOBRAS " & p_IdContato & "," & p_IdObra)
        Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Private Sub Clear()
        m_intIdContato = 0
        m_intIdObra = 0
        m_strNomeContato = ""
        m_intIdCargo = 0
        m_strDDD = ""
        m_strTelefone = ""
        m_strDDDFax = ""
        m_strFax = ""
        m_strEMail = ""
        m_intIdEmpresa = 0
        m_strEmpresa = ""
        m_strDDD2 = ""
        m_strTelefone2 = ""
        m_intIdTipoTelefone1 = 0
        m_intIdTipoTelefone2 = 0
        m_intIdTipoTelefone3 = 0
    End Sub

    Public Function List(ByVal vIDObra As Integer) As DataSet
        Try
            List = GetDataSet("SP_SE_CONTATOSOBRAS 0, " & vIDObra)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class