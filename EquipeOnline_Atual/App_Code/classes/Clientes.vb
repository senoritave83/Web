Imports System.Data.SqlClient

Public Class clsClientes
    Inherits DataClass
    Protected m_intIDCliente As Integer
    Protected m_strNome As String
    Protected m_strRazao As String
    Protected m_strCNPJ As String
    Protected m_strEndereco As String
    Protected m_strReferencia As String
    Protected m_strBairro As String
    Protected m_strCidade As String
    Protected m_strCep As String
    Protected m_strUF As String
    Protected m_strContato As String
    Protected m_strTelefone As String
    Protected m_strObservacao As String

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

    Public Property Razao() As String
        Get
            Return m_strRazao
        End Get
        Set(ByVal Value As String)
            m_strRazao = Value
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

    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDCliente = dr.GetInt32(dr.GetOrdinal("cli_Cliente_int_PK"))
        m_strNome = dr.GetString(dr.GetOrdinal("cli_Cliente_chr"))
        If dr.IsDBNull(dr.GetOrdinal("cli_Razao_chr")) Then
            m_strRazao = ""
        Else
            m_strRazao = dr.GetString(dr.GetOrdinal("cli_Razao_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_CNPJ_chr")) Then
            m_strCNPJ = ""
        Else
            m_strCNPJ = dr.GetString(dr.GetOrdinal("cli_CNPJ_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Endereco_chr")) Then
            m_strEndereco = ""
        Else
            m_strEndereco = dr.GetString(dr.GetOrdinal("cli_Endereco_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Referencia_chr")) Then
            m_strReferencia = ""
        Else
            m_strReferencia = dr.GetString(dr.GetOrdinal("cli_Referencia_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Bairro_chr")) Then
            m_strBairro = ""
        Else
            m_strBairro = dr.GetString(dr.GetOrdinal("cli_Bairro_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Cidade_chr")) Then
            m_strCidade = ""
        Else
            m_strCidade = dr.GetString(dr.GetOrdinal("cli_Cidade_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_CEP_chr")) Then
            m_strCep = ""
        Else
            m_strCep = dr.GetString(dr.GetOrdinal("cli_CEP_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_UF_chr")) Then
            m_strUF = ""
        Else
            m_strUF = dr.GetString(dr.GetOrdinal("cli_UF_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Telefone_chr")) Then
            m_strTelefone = ""
        Else
            m_strTelefone = dr.GetString(dr.GetOrdinal("cli_Telefone_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Contato_chr")) Then
            m_strContato = ""
        Else
            m_strContato = dr.GetString(dr.GetOrdinal("cli_Contato_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cli_Observacao_chr")) Then
            m_strObservacao = ""
        Else
            m_strObservacao = dr.GetString(dr.GetOrdinal("cli_Observacao_chr"))
        End If
    End Sub


    Public Sub Update()

        Dim cmd As New SqlCommand()
        Dim dr As IDataReader
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_CLIENTE"
        cmd.Parameters.Add("@CLI_CLIENTE_INT_PK", SqlDbType.Int).Value = m_intIDCliente
        cmd.Parameters.Add("@EMP_EMPRESA_INT_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@CLI_CLIENTE_CHR", SqlDbType.VarChar, 100).Value = m_strNome
        cmd.Parameters.Add("@CLI_RAZAO_CHR", SqlDbType.VarChar, 100).Value = m_strRazao
        cmd.Parameters.Add("@CLI_CNPJ_CHR", SqlDbType.VarChar, 20).Value = m_strCNPJ
        cmd.Parameters.Add("@CLI_ENDERECO_CHR", SqlDbType.VarChar, 150).Value = m_strEndereco
        cmd.Parameters.Add("@CLI_REFERENCIA_CHR", SqlDbType.VarChar, 50).Value = m_strReferencia
        cmd.Parameters.Add("@CLI_BAIRRO_CHR", SqlDbType.VarChar, 30).Value = m_strBairro
        cmd.Parameters.Add("@CLI_CIDADE_CHR", SqlDbType.VarChar, 50).Value = m_strCidade
        cmd.Parameters.Add("@CLI_CEP_CHR", SqlDbType.VarChar, 10).Value = m_strCep
        cmd.Parameters.Add("@CLI_UF_CHR", SqlDbType.Char, 2).Value = m_strUF
        cmd.Parameters.Add("@CLI_CONTATO_CHR", SqlDbType.VarChar, 30).Value = m_strContato
        cmd.Parameters.Add("@CLI_TELEFONE_CHR", SqlDbType.VarChar, 20).Value = m_strTelefone
        cmd.Parameters.Add("@CLI_OBSERVACAO_CHR", SqlDbType.VarChar, 1000).Value = m_strObservacao
        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Throw New ArgumentException("There was no data response!")
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try

    End Sub

    Public Sub Load(ByVal p_intIDCliente As Integer)
        If p_intIDCliente = 0 Then
            Clear()
            Exit Sub
        End If

        Dim cmd As New SqlCommand()
        Dim dr As IDataReader
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_CLIENTE"
        cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = p_intIDCliente
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Throw New ArgumentException("There was no data response!")
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
    End Sub

    Protected Sub Clear()
        m_intIDCliente = 0
        m_strNome = ""
        m_strRazao = ""
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
    End Sub

    Public Sub Delete()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_CLIENTE"
        cmd.Parameters.Add("@CLI_CLIENTE_INT_PK", SqlDbType.Int).Value = m_intIDCliente
        cmd.Parameters.Add("@EMP_EMPRESA_INT_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_CLIENTE_SEL"
        cmd.Parameters.Add("@IDS", SqlDbType.VarChar, 1000).Value = vIDs
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
    End Sub


    Public Function Listar(ByVal vFiltro As String) As IDataReader
        Return Listar(vFiltro, Identity.IDEmpresa)
    End Function

    Public Function Listar(ByVal vFiltro As String, ByVal vIDEmpresa As Integer) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_CLIENTES"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFiltro
        Return ExecuteReader(cmd)
    End Function


    Public Function ListarClientes(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vDesc As Integer, Optional ByVal vFiltro As String = "") As IPaginaResult
        Dim ret As New PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_CLIENTES"

        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFiltro
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 50).Value = vOrder
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
        cmd.Parameters.Add("@DESC", SqlDbType.TinyInt).Value = vDesc

        Dim ds As DataSet = ExecuteDataSet(cmd)
        ret.DataSet = ds
        ret.CurrentPage = vPage
        ret.PageSize = vPageSize
        ret.RecordCount = ds.Tables(1).Rows(0).Item(0)
        Return ret
    End Function


    Public Function Count() As Integer
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_CLIENTE_COUNT"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteScalar(cmd)
    End Function

    Public Function Listar() As IDataReader
        Return Listar("")
    End Function


End Class
