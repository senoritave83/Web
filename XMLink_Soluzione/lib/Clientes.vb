Public Class clsClientes
    Inherits clsBaseClass
    Protected m_intIDCliente As Integer
    Protected m_strNome As String
    Protected m_strCodigo As String
    Protected m_strCNPJ As String
    Protected m_strEndereco As String
    Protected m_strReferencia As String
    Protected m_strBairro As String
    Protected m_decTabelaPreco As Decimal
    Protected m_decDescontoMax As Decimal
    Protected m_decLimite As Decimal
    Protected m_strCidade As String
    Protected m_strCep As String
    Protected m_strUF As String
    Protected m_strContato As String
    Protected m_strTelefone As String
    Protected m_strObservacao As String
    Protected m_decLatitude As Decimal
    Protected m_decLongitude As Decimal

    Public ReadOnly Property IDCliente() As Integer
        Get
            Return m_intIDCliente
        End Get
    End Property

    Public Property Nome() As String
        Get
            Return m_strNome
        End Get
        Set(ByVal Value As String)
            m_strNome = Value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return m_strCodigo
        End Get
        Set(ByVal Value As String)
            m_strCodigo = Value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return m_strCNPJ
        End Get
        Set(ByVal Value As String)
            m_strCNPJ = Value
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Return m_strEndereco
        End Get
        Set(ByVal Value As String)
            m_strEndereco = Value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_strReferencia
        End Get
        Set(ByVal Value As String)
            m_strReferencia = Value
        End Set
    End Property

    Public Property Bairro() As String
        Get
            Return m_strBairro
        End Get
        Set(ByVal Value As String)
            m_strBairro = Value
        End Set
    End Property

    Public Property Cidade() As String
        Get
            Return m_strCidade
        End Get
        Set(ByVal Value As String)
            m_strCidade = Value
        End Set
    End Property

    Public Property Cep() As String
        Get
            Return m_strCep
        End Get
        Set(ByVal Value As String)
            m_strCep = Value
        End Set
    End Property

    Public Property UF() As String
        Get
            Return m_strUF
        End Get
        Set(ByVal Value As String)
            m_strUF = Value
        End Set
    End Property

    Public Property Contato() As String
        Get
            Return m_strContato
        End Get
        Set(ByVal Value As String)
            m_strContato = Value
        End Set
    End Property

    Public Property TabelaPreco() As Decimal
        Get
            Return m_decTabelaPreco
        End Get
        Set(ByVal Value As Decimal)
            m_decTabelaPreco = Value
        End Set
    End Property

    Public Property DescontoMax() As Decimal
        Get
            Return m_decDescontoMax
        End Get
        Set(ByVal Value As Decimal)
            m_decDescontoMax = Value
        End Set
    End Property

    Public Property LimiteCredito() As Decimal
        Get
            Return m_decLimite
        End Get
        Set(ByVal Value As Decimal)
            m_decLimite = Value
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

    Public Property Observacao() As String
        Get
            Return m_strObservacao
        End Get
        Set(ByVal Value As String)
            m_strObservacao = Value
        End Set
    End Property

    Public Property Latitude() As Decimal
        Get
            Return m_decLatitude
        End Get
        Set(ByVal Value As Decimal)
            m_decLatitude = Value
        End Set
    End Property

    Public Property Longitude() As Decimal
        Get
            Return m_decLongitude
        End Get
        Set(ByVal Value As Decimal)
            m_decLongitude = Value
        End Set
    End Property

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDCliente = CLng(0 & row("cli_Cliente_int_PK"))
        m_strNome = row("cli_Cliente_chr") & ""
        m_strCodigo = row("cli_Codigo_chr") & ""
        m_strCNPJ = row("cli_CNPJ_chr") & ""
        m_strEndereco = row("cli_Endereco_chr") & ""
        m_strReferencia = row("cli_Referencia_chr") & ""
        m_strBairro = row("cli_Bairro_chr") & ""
        m_strCidade = row("cli_Cidade_chr") & ""
        m_strCep = row("cli_CEP_chr") & ""
        m_strUF = row("cli_UF_chr") & ""
        m_strContato = row("cli_Contato_chr") & ""
        m_strTelefone = row("cli_Telefone_chr") & ""
        m_strObservacao = row("cli_Observacao_chr") & ""
        m_decTabelaPreco = CDec(0 & row("cli_TabelaPreco_num"))
        m_decDescontoMax = CDec(0 & row("cli_DescontoMax_num"))

        If IsDBNull(row("cli_LimiteCredito_cur")) Then
            m_decLimite = 0
        Else
            m_decLimite = CDec(row("cli_LimiteCredito_cur"))
        End If

        If IsDBNull(row("cli_Latitude_num")) Then
            m_decLatitude = 0
        Else
            m_decLatitude = row("cli_Latitude_num") & ""
        End If

        If IsDBNull(row("cli_Longitude_num")) Then
            m_decLongitude = 0
        Else
            m_decLongitude = row("cli_Longitude_num") & ""
        End If

    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDCliente & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCNPJ.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strEndereco.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strReferencia.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strBairro.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCidade.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCep.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strUF.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strTelefone.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strContato.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strObservacao.Replace("'", "''") & "', "
        strDeflate &= m_decTabelaPreco.ToString("#0.##").Replace(",", ".") & ", "
        strDeflate &= m_decDescontoMax.ToString("#0.##").Replace(",", ".") & ", "
        strDeflate &= m_decLimite.ToString("#0.##").Replace(",", ".") & ", "
        strDeflate &= "" & CStr(m_decLatitude).Replace(",", ".") & ", "
        strDeflate &= "" & CStr(m_decLongitude).Replace(",", ".") & ""
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_CLIENTE " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDCliente As Integer)
        If p_intIDCliente = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CLIENTE " & p_intIDCliente & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDCliente = 0
        m_strNome = ""
        m_strCodigo = ""
        m_strCNPJ = ""
        m_strEndereco = ""
        m_strReferencia = ""
        m_strBairro = ""
        m_strCidade = ""
        m_strCep = ""
        m_strUF = ""
        m_strContato = ""
        m_strTelefone = ""
        m_strObservacao = ""
        m_decDescontoMax = 0
        m_decTabelaPreco = 0
        m_decLimite = 0
        m_decLatitude = 0
        m_decLongitude = 0
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_CLIENTE " & m_intIDCliente & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_CLIENTE_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar() As DataSet
        Return Listar(0, "", "", False, 0, 0)
    End Function

    Public Function AcrescentarVendedor(ByVal vIDVendedor As Integer)
        ExecuteNonQuery(PREFIXO & "IN_VENDEDOR_CLIENTE " & XMPage.IDEmpresa & ", " & m_intIDCliente & ", " & vIDVendedor)
    End Function

    Public Function RetirarVendedor(ByVal vIDVendedor As Integer)
        ExecuteNonQuery(PREFIXO & "DE_VENDEDOR_CLIENTE " & XMPage.IDEmpresa & ", " & m_intIDCliente & ", " & vIDVendedor)
    End Function

    Public Function Listar(ByVal vIDVendedor As Integer, ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_CLIENTES " & XMPage.IDEmpresa & ", " & vIDVendedor & ",'" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

    Public Function ListarRoteirizados(ByVal vIDVendedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean) As DataSet
        ListarRoteirizados = GetDataSet(PREFIXO & "LS_CLIENTES_ROT " & XMPage.IDEmpresa & ", " & vIDVendedor & ",'" & vOrder & "'," & IIf(vDescending, 1, 0))
    End Function

    Public Function ListarVendedores() As DataSet
        Return GetDataSet(PREFIXO & "LS_VENDEDORES_CLIENTE " & XMPage.IDEmpresa & ", " & m_intIDCliente)
    End Function

    Public Function ListarFiltro() As DataSet
        Return GetDataSet(PREFIXO & "LS_CLIENTES_FILTRO " & XMPage.IDEmpresa)
    End Function

    Public Function Existe(ByVal vIDCliente As Integer, ByVal vCodigo As String, ByVal vNome As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CLIENTE_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDCliente & ", '" & vNome.Replace("'", "''") & "', '" & vCodigo.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Public Function ListarInclusosRoteiro(ByVal vIDClientes As String) As DataSet
        ListarInclusosRoteiro = GetDataSet(PREFIXO & "LS_CLIENTES_INC_ROT " & XMPage.IDEmpresa & ",'" & vIDClientes & "'")
    End Function

End Class
