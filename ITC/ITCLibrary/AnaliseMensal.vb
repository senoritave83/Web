
Public Class clsAnaliseMensal

    Inherits DataClass

    Private m_IdAnaliseMensal As Integer
    Private m_Imagem As String
    Private m_Titulo As String
    Private m_IdStatus As Integer
    Private m_strLink As String

    Public ReadOnly Property IdAnaliseMensal()
        Get
            Return m_IdAnaliseMensal
        End Get
    End Property

    Public Property Imagem() As String
        Get
            Return m_Imagem
        End Get
        Set(ByVal Value As String)
            m_Imagem = Value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return m_Titulo
        End Get
        Set(ByVal Value As String)
            m_Titulo = Value
        End Set
    End Property

    Public Property IdStatus() As Integer
        Get
            Return m_IdStatus
        End Get
        Set(ByVal Value As Integer)
            m_IdStatus = Value
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal IdDica As Integer)
        If IdDica = 0 Then
            Clear()
        Else
            Load(IdDica)
        End If
    End Sub

    Public Property Link() As String
        Get
            Return m_strLink
        End Get
        Set(ByVal Value As String)
            m_strLink = Value
        End Set
    End Property

    Private Sub Clear()
        m_IdAnaliseMensal = 0
        m_Imagem = ""
        m_Titulo = ""
        m_IdStatus = 0
        m_strLink = ""
    End Sub

    Private Function Load(ByVal m_IdAnaliseMensal As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_ANALISEMENSAL " & m_IdAnaliseMensal)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Function

    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_ANALISEMENSAL " & Deflate()
        Dim myData As DataSet = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdAnaliseMensal = CLng(0 & row("anm_analise_int_pk"))
        Me.m_Imagem = CStr(row("anm_imagem_chr") & "")
        Me.m_Titulo = CStr(row("anm_texto_chr") & "")
        Me.m_IdStatus = CInt(0 & row("anm_ativo_ind"))
        Me.m_strLink = CStr(row("anm_link_chr") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_IdAnaliseMensal & ","
        strDeflate &= "'" & m_Imagem.Replace("'", "''") & "',"
        strDeflate &= "'" & m_Titulo.Replace("'", "''") & "',"
        strDeflate &= m_IdStatus & ",'"
        strDeflate &= m_strLink & "'"
        Return strDeflate
    End Function

    Public Function Delete(ByVal m_IdAnaliseMensal As Integer) As Boolean
        ExecuteNonQuery("SP_DE_ANALISEMENSAL " & m_IdAnaliseMensal)
        Return True
    End Function

    Public Function List() As DataSet
        Return GetDataSet("SP_LS_ANALISEMENSAL")
    End Function

    Public Function ListTodas() As DataSet
        Return GetDataSet("SP_SE_ANALISEMENSALFULL")
    End Function

End Class
