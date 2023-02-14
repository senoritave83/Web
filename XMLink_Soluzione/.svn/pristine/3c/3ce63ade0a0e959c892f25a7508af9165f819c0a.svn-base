Public Class clsCopiarRoteiros
    Inherits clsBaseClass
    Protected m_intIDRoteiro As Integer
    Protected m_intIDVendedor As Integer
    Protected m_intSemana As Integer
    Protected m_intDiaSemana As Integer
    Protected m_indAtivo As Integer
    Protected m_strVendedor As String
    Protected m_strIDClientes As String
    Protected varClientes As String
    Protected m_strNomeRoteiro As String
    Protected m_indCopiaRoteiro As Integer

    Friend IDPrimeiroVendedor As Object

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Property IDRoteiro() As Integer
        Get
            Return m_intIDRoteiro
        End Get
        Set(ByVal Value As Integer)
            m_intIDRoteiro = Value
        End Set
    End Property

    Public Property IDVendedor() As Integer
        Get
            Return m_intIDVendedor
        End Get
        Set(ByVal Value As Integer)
            m_intIDVendedor = Value
        End Set
    End Property

    Public Property IdClientes() As String
        Get
            Return varClientes
        End Get
        Set(ByVal Value As String)
            varClientes = Value
        End Set
    End Property

    Public Property Vendedor() As String
        Get
            Return m_strVendedor
        End Get
        Set(ByVal Value As String)
            m_strVendedor = Value
        End Set
    End Property

    Public Property Semana() As Integer
        Get
            Return m_intSemana
        End Get
        Set(ByVal Value As Integer)
            m_intSemana = Value
        End Set
    End Property

    Public Property DiaSemana() As Integer
        Get
            Return m_intDiaSemana
        End Get
        Set(ByVal Value As Integer)
            m_intDiaSemana = Value
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

    Public Property Clientes() As String
        Get
            Return m_strIDClientes
        End Get
        Set(ByVal Value As String)
            m_strIDClientes = Value
        End Set
    End Property

    Public Property NomeRoteiro() As String
        Get
            Return m_strNomeRoteiro
        End Get
        Set(ByVal Value As String)
            m_strNomeRoteiro = Value
        End Set
    End Property

    Public Property CopiaRoteiro() As Integer
        Get
            Return m_indCopiaRoteiro
        End Get
        Set(ByVal Value As Integer)
            m_indCopiaRoteiro = Value
        End Set
    End Property



    Protected Overridable Sub Inflate(ByVal row As DataRow)

        m_intIDRoteiro = CLng(0 & row("rot_roteiro_int_PK")) & ""
        m_strVendedor = CStr(row("ven_vendedor_chr")) & ""
        m_intSemana = CLng(0 & row("rot_semana_int")) & ""
        m_intDiaSemana = CLng(0 & row("rot_diasemana_int")) & ""
        m_indAtivo = CInt(row("rot_ativo_ind")) & ""
        m_strIDClientes = CStr(row("Clientes")) & ""
        m_strNomeRoteiro = CStr(row("NomeRoteiro") & "")


    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String
        strDeflate &= m_intIDRoteiro & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= m_intIDVendedor & ", "
        strDeflate &= m_intSemana & ", "
        strDeflate &= m_intDiaSemana & ", "
        strDeflate &= m_indAtivo & ",'"
        strDeflate &= m_strIDClientes & "','"
        strDeflate &= m_strNomeRoteiro & "',"
        strDeflate &= m_indCopiaRoteiro

        Return strDeflate

    End Function

    Public Sub Update()

        Dim sql As String
        sql = PREFIXO & "SV_ROTEIRO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Public Sub Load(ByVal p_intIDRoteiro As Integer)

        If p_intIDRoteiro = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_ROTEIRO " & p_intIDRoteiro & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Protected Sub Clear()

        m_intIDRoteiro = 0
        m_intIDVendedor = 0
        m_intSemana = 0
        m_intDiaSemana = 0
        m_indAtivo = 0
        m_strIDClientes = ""
        m_strNomeRoteiro = ""

    End Sub

    Public Sub Delete()

        ExecuteNonQuery(PREFIXO & "DE_ROTEIRO " & m_intIDRoteiro & ", " & XMPage.IDEmpresa)
        Clear()

    End Sub

    Public Function Listar(ByVal m_intIDVendedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet

        Return GetDataSet(PREFIXO & "LS_ROTEIROS " & m_intIDVendedor & ", " & XMPage.IDEmpresa & ",'" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)

    End Function

    Public Function MontaClientes(ByVal m_intIDRoteiro) As DataSet
        GetClientes(GetDataSet(PREFIXO & "LS_ROTEIRO_CLI " & m_intIDRoteiro & ", " & XMPage.IDEmpresa).Tables(0).Rows(0))
    End Function

    Protected Overridable Sub GetClientes(ByVal row As DataRow)
        varClientes = CStr(row("DADOS")) & ""
    End Sub

End Class
