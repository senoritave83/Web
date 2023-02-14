Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog

Public Class clsAcesso

    Inherits clsBaseClass

    Private m_intIDAcesso As Integer 'Primary Key
    Private m_strNome As String
    Private m_intHorarioDe As Integer
    Private m_intHorarioAte As Integer
    Private m_indAtivo As Integer

    Public Property IDAcesso() As Integer
        Get
            Return m_intIDAcesso
        End Get
        Set(ByVal Value As Integer)
            Load(Value)
        End Set
    End Property

    Public Property HorarioDe() As Integer
        Get
            Return m_intHorarioDe
        End Get
        Set(ByVal Value As Integer)
            m_intHorarioDe = Value
        End Set
    End Property


    Public Property Nome() As String
        Get
            Return m_strNome
        End Get
        Set(ByVal Value As String)
            m_strNome = Value
        End Set
    End Property

    Public Property HorarioAte() As Integer
        Get
            Return m_intHorarioAte
        End Get
        Set(ByVal Value As Integer)
            m_intHorarioAte = Value
        End Set
    End Property

    Public Property Ativo() As Integer
        Get
            Return m_indAtivo
        End Get
        Set(ByVal Value As Integer)
            m_indAtivo = Value
        End Set
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIDAcesso = CLng(0 & row("hof_HorarioFuncionamento_int_PK"))
        Me.m_intHorarioDe = CLng(0 & row("hof_HorarioInicial_int"))
        Me.m_intHorarioAte = CLng(0 & row("hof_HorarioFinal_int"))
        Me.m_strNome = "" & row("hof_Horario_chr")
        Me.m_indAtivo = CLng(0 & row("hof_HorarioFuncionamento_ind"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDAcesso & ", '"
        strDeflate &= m_strNome.Replace("'", "''") & "', "
        strDeflate &= m_intHorarioDe & ", "
        strDeflate &= m_intHorarioAte & ", "
        strDeflate &= m_indAtivo
        Return strDeflate
    End Function

    Public Sub Update()
        Dim sql As String
        sql = PREFIXO & "SV_ACESSO " & XMPage.IDEmpresa & ", " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub


    Protected Sub Load(ByVal p_intIDAcesso As Integer)
        If p_intIDAcesso = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_ACESSO " & XMPage.IDEmpresa & ", " & p_intIDAcesso)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_ACESSO " & XMPage.IDEmpresa & ", " & m_intIDAcesso)
        Clear()
    End Sub

    Public Sub Delete(ByVal p_intIDAcesso As Integer)
        ExecuteNonQuery(PREFIXO & "DE_ACESSO " & XMPage.IDEmpresa & ", " & p_intIDAcesso)
        If p_intIDAcesso = m_intIDAcesso Then Clear()
    End Sub

    Public Sub Delete(ByVal vIDAcessos As String)
        ExecuteNonQuery(PREFIXO & "DE_ACESSO_SEL " & XMPage.IDEmpresa & ", '" & vIDAcessos.Replace("'", "''") & "'")
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Private Sub Clear()
        m_intIDAcesso = 0
        m_intHorarioDe = 0
        m_strNome = ""
        m_intHorarioAte = 0
        m_indAtivo = 0
    End Sub

    Public Function Listar() As DataSet
        Try
            Listar = GetDataSet(PREFIXO & "LS_ACESSO " & XMPage.IDEmpresa)
        Catch e As System.Exception
            XMPage.LogError(e, "clsAcesso")
        End Try
    End Function
End Class