'************************************************************
'Classe gerada por XM Class Creator - 15/1/2003 12:03:46
'************************************************************

Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsEmpresas

    Inherits DataClass

#Region "Declarations"

    Private m_intCodigo As Integer
    Private m_varFantasia As String
    Private m_varRazaoSocial As String
    Private m_varEndereco As String
    Private m_varComplemento As String
    Private m_strCEP As String
    Private m_varCidade As String
    Private m_intIDEstado As Integer
    Private m_varEstado As String
    Private m_varCNPJ As String
    Private m_strInscricaoEstadual As String
    Private m_varInscricaoMunicipal As String
    Private m_intIdAtividade As Integer
    Private m_intIdPesquisador As Integer
    Private m_varPesquisador As String
    Private m_varAtualizacao As String
    Private m_dblNrDaRevisao As Double
    Private m_varCodigoAntigo As String
    Private m_Vendedor As Integer
    Private m_varWebSite As String
    Private m_varEMail As String
    Private m_Demo As Boolean
    Private m_Ativo As Integer
    Private m_strObservacao As String
    Private m_strEMail2 As String
    Private m_strSkype As String

#End Region

#Region "Properties"

    Public Enum Ordenacao
        RAZAOSOCIAL = 1
        FANTASIA = 2
        ENDERECO = 3
        ESTADO = 4
    End Enum

    Public Enum Categoria
        Obra = 1
        Empresa = 2
        ITC = -1
    End Enum

    Public Property Demo() As Boolean
        Get
            Return m_Demo
        End Get
        Set(ByVal Value As Boolean)
            m_Demo = Value
        End Set
    End Property

    Public Property Ativo() As Integer
        Get
            Return m_Ativo
        End Get
        Set(ByVal Value As Integer)
            m_Ativo = Value
        End Set
    End Property

    Public Property Codigo() As Integer
        Get
            Return m_intCodigo
        End Get
        Set(ByVal Value As Integer)
            m_intCodigo = Value
        End Set
    End Property

    Public Property Fantasia() As String
        Get
            Return m_varFantasia
        End Get
        Set(ByVal Value As String)
            m_varFantasia = Value
        End Set
    End Property

    Public Property RazaoSocial() As String
        Get
            Return m_varRazaoSocial
        End Get
        Set(ByVal Value As String)
            m_varRazaoSocial = Value
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Return m_varEndereco
        End Get
        Set(ByVal Value As String)
            m_varEndereco = Value
        End Set
    End Property

    Public Property Complemento() As String
        Get
            Return m_varComplemento
        End Get
        Set(ByVal Value As String)
            m_varComplemento = Value
        End Set
    End Property

    Public Property CEP() As String
        Get
            Return m_strCEP
        End Get
        Set(ByVal Value As String)
            m_strCEP = Value
        End Set
    End Property

    Public Property Cidade() As String
        Get
            Return m_varCidade
        End Get
        Set(ByVal Value As String)
            m_varCidade = Value
        End Set
    End Property

    Public Property IdEstado() As Integer
        Get
            Return m_intIDEstado
        End Get
        Set(ByVal Value As Integer)
            m_intIDEstado = Value
        End Set
    End Property

    Public ReadOnly Property Estado() As String
        Get
            Return m_varEstado
        End Get
    End Property

    Public Property CNPJ() As String
        Get
            Return m_varCNPJ
        End Get
        Set(ByVal Value As String)
            m_varCNPJ = Value
        End Set
    End Property

    Public Property InscricaoEstadual() As String
        Get
            Return m_strInscricaoEstadual
        End Get
        Set(ByVal Value As String)
            m_strInscricaoEstadual = Value
        End Set
    End Property

    Public Property InscricaoMunicipal() As String
        Get
            Return m_varInscricaoMunicipal
        End Get
        Set(ByVal Value As String)
            m_varInscricaoMunicipal = Value
        End Set
    End Property

    Public Property IdAtividade() As Integer
        Get
            Return m_intIdAtividade
        End Get
        Set(ByVal Value As Integer)
            m_intIdAtividade = Value
        End Set
    End Property

    Public ReadOnly Property Pesquisador() As String
        Get
            Return m_varPesquisador
        End Get
    End Property

    Public Property IdPesquisador() As String
        Get
            Return m_intIdPesquisador
        End Get
        Set(ByVal Value As String)
            m_intIdPesquisador = Value
        End Set
    End Property

    Public Property Atualizacao() As String
        Get
            Return CDate(m_varAtualizacao).ToString("dd/MM/yyyy")
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                Dim strTemp = Split(Value, "/")
                m_varAtualizacao = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            End If
        End Set
    End Property

    Public Property NrDaRevisao() As Double
        Get
            Return m_dblNrDaRevisao
        End Get
        Set(ByVal Value As Double)
            m_dblNrDaRevisao = Value
        End Set
    End Property

    Public Property Vendedor() As Integer
        Get
            Return m_Vendedor
        End Get
        Set(ByVal Value As Integer)
            m_Vendedor = Value
        End Set
    End Property

    Public Property CodigoAntigo() As String
        Get
            Return m_varCodigoAntigo
        End Get
        Set(ByVal Value As String)
            m_varCodigoAntigo = Value
        End Set
    End Property

    Public Property WebSite() As String
        Get
            Return m_varWebSite
        End Get
        Set(ByVal Value As String)
            m_varWebSite = Value
        End Set
    End Property

    Public Property EMail() As String
        Get
            Return m_varEMail
        End Get
        Set(ByVal Value As String)
            m_varEMail = Value
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

    Public Property EMail2() As String
        Get
            Return m_strEMail2
        End Get
        Set(ByVal Value As String)
            m_strEMail2 = Value
        End Set
    End Property

    Public Property Skype() As String
        Get
            Return m_strSkype
        End Get
        Set(ByVal Value As String)
            m_strSkype = Value
        End Set
    End Property

#End Region

#Region "Métodos"

    ''' <summary>
    ''' 	Função privada que carrega nas variaveis internas os valores presentes no DataRow
    ''' </summary>
    ''' <param name="row">objeto DataRow com os valores obtidos do banco de dados</param>	
    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intCodigo = CLng(0 & row("Codigo"))
        Me.m_varFantasia = CStr(row("Fantasia") & "")
        Me.m_varRazaoSocial = CStr(row("RazaoSocial") & "")
        Me.m_varEndereco = CStr(row("Endereco") & "")
        Me.m_varComplemento = CStr(row("Complemento") & "")
        Me.m_strCEP = CStr(row("CEP") & "")
        Me.m_varCidade = CStr(row("Cidade") & "")
        Me.m_varEstado = CStr(row("Estado") & "")
        Me.m_intIDEstado = CLng(0 & row("IdEstado"))
        Me.m_varCNPJ = CStr(row("CNPJ") & "")
        Me.m_strInscricaoEstadual = CStr(row("InscricaoEstadual") & "")
        Me.m_varInscricaoMunicipal = CStr(row("InscricaoMunicipal") & "")
        Me.m_intIdAtividade = CLng(0 & row("IdAtividade"))
        Me.m_intIdPesquisador = CLng(0 & row("IdPesquisador"))
        Me.m_varPesquisador = CStr(row("NOMEPESQUISADOR") & "")
        Me.m_varAtualizacao = CDate(row("Atualizacao")).ToString("yyyy-MM-dd")
        Me.m_dblNrDaRevisao = CLng(0 & row("NrDaRevisao"))
        Me.m_varCodigoAntigo = CStr(row("CodigoAntigo") & "")
        Me.m_varWebSite = CStr(row("WebSite") & "")
        Me.m_varEMail = CStr(row("EMail") & "")
        Me.m_Demo = IIf(CInt(0 & row("IndDemo")) = 1, True, False)
        Me.m_Ativo = CInt(0 & row("IndStatus"))
        Me.m_Vendedor = CInt(0 & row("Vendedor"))
        Me.m_strObservacao = CStr(row("Observacao") & "")
        Me.m_strEMail2 = CStr(row("EMail2") & "")
        Me.m_strSkype = CStr(row("Skype") & "")
    End Sub

    ''' <summary>
    ''' 	Função privada que carrega a variavel strDeflate com os valores obtidos do formulário para gravação no banco de dados
    ''' </summary>
    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intCodigo & "" & ","
        strDeflate &= "'" & Replace(m_varFantasia, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varRazaoSocial, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varEndereco, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varComplemento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strCEP, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varCidade, "'", "''") & "'" & ","
        strDeflate &= m_intIDEstado & ","
        strDeflate &= "'" & Replace(m_varCNPJ, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strInscricaoEstadual, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varInscricaoMunicipal, "'", "''") & "'" & ","
        strDeflate &= "" & m_intIdAtividade & "" & ","
        strDeflate &= m_intIdPesquisador & ","
        strDeflate &= "'" & Replace(m_varAtualizacao, "'", "''") & "'" & ","
        strDeflate &= "" & m_dblNrDaRevisao & "" & ","
        strDeflate &= "'" & Replace(m_varCodigoAntigo, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_varWebSite, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_varEMail, "'", "''") & "',"
        strDeflate &= IIf(m_Demo, 1, 0) & ","
        strDeflate &= m_Ativo & ","
        strDeflate &= Categoria.ITC & ","
        strDeflate &= m_Vendedor & ","
        strDeflate &= Categoria.Obra & ","
        strDeflate &= "'" & Replace(m_strObservacao, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strEMail2, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strSkype, "'", "''") & "'"
        Deflate = strDeflate
    End Function

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()

        Dim sql As String
        sql = "SP_SV_EMPRESAS " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    ''' <summary>
    ''' 	Construtor da classe Empresas
    ''' </summary>
    ''' <param name="p_intCodigo">Chave primaria IDEmpresa</param>
    Public Sub New(ByVal p_intCodigo As Integer)
        If p_intCodigo = 0 Then
            Clear()
        Else
            Load(p_intCodigo)
        End If
    End Sub

    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="p_intCodigo">Chave primaria IDEmpresa</param>
    Protected Sub Load(ByVal p_intCodigo As Integer)
        If p_intCodigo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_EMPRESAS " & p_intCodigo)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    ''' <summary>
    ''' 	Função interna que limpa as variaveis internas
    ''' </summary>
    Private Sub Clear()
        m_intCodigo = 0
        m_varFantasia = ""
        m_varRazaoSocial = ""
        m_varEndereco = ""
        m_varComplemento = ""
        m_strCEP = ""
        m_varCidade = ""
        m_varEstado = 0
        m_varCNPJ = ""
        m_strInscricaoEstadual = ""
        m_varInscricaoMunicipal = ""
        m_intIdAtividade = 0
        m_intIdPesquisador = 0
        m_varPesquisador = ""
        m_varAtualizacao = Now
        m_dblNrDaRevisao = 0
        m_varCodigoAntigo = ""
        m_varWebSite = ""
        m_varEMail = ""
        m_strObservacao = ""
        m_strEMail2 = ""
        m_strSkype = ""
    End Sub

    ''' <summary>
    ''' 	Função que retorna um DataSet com filtragem e ordenação
    ''' </summary>
    ''' <param name="p_Fantasia">Filtra a pesquisa pelo nome Fantasia da Empresa</param>
    ''' <param name="p_RazaoSocial">Filtra a pesquisa pela Razão Social da Empresa</param>
    ''' <param name="p_DataInicial">Filtra a pesquisa a partir de uma data inicial</param>
    ''' <param name="p_DataFinal">Filtra a pesquisa até uma data final</param>
    ''' <param name="Ordem">Ordena a pesquisa por Nome Fantasia, Razão Social, Endereço ou UF</param>
    ''' <param name="Status">Filtra a pesquisa pelo Status da Empresa</param>
    ''' <returns>DataSet</returns>
    Public Function List(ByVal p_Fantasia As String, ByVal p_RazaoSocial As String, ByVal p_DataInicial As String, ByVal p_DataFinal As String, ByVal Ordem As Ordenacao, ByVal Status As Integer) As DataSet
        Try
            If p_Fantasia.Trim = "" Then
                p_Fantasia = "NULL"
            Else
                p_Fantasia = "'" & p_Fantasia & "'"
            End If
            If p_RazaoSocial.Trim = "" Then
                p_RazaoSocial = "NULL"
            Else
                p_RazaoSocial = "'" & p_RazaoSocial & "'"
            End If
            If Not IsDate(p_DataInicial) Then
                p_DataInicial = "NULL"
            Else
                p_DataInicial = "'" & Year(p_DataInicial) & "-" & Month(p_DataInicial) & "-" & Day(p_DataInicial) & "'"
            End If
            If Not IsDate(p_DataFinal) Then
                p_DataFinal = "NULL"
            Else
                p_DataFinal = "'" & Year(p_DataFinal) & "-" & Month(p_DataFinal) & "-" & Day(p_DataFinal) & "'"
            End If
            List = GetDataSet("SP_SE_EMPRESAS 0, " & p_Fantasia & "," & p_RazaoSocial & "," & p_DataInicial & "," & p_DataFinal & "," & Ordem & "," & Status)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    ''' <summary>
    ''' 	Função que retorna um DataSet com filtragem
    ''' </summary>
    ''' <param name="RazaoSocialEmpresa">Filtra a pesquisa pela Razão Social da Empresa</param>
    ''' <returns>DataSet</returns>
    Public Function Find(ByVal RazaoSocialEmpresa As String) As DataSet
        Try
            Find = GetDataSet("SP_SE_EMPRESAS 0, NULL, " & RazaoSocialEmpresa & ", NULL")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    ''' <summary>
    ''' 	Função que Verifica se o CNPJ já está cadastrado p/ uma empresa
    ''' </summary>
    ''' <param name="CNPJ">Filtra a pesquisa pelo CNPJ da Empresa</param>
    ''' <returns>Boolean</returns>
    Public Function VerificaCNPJ(ByVal CNPJ As String) As Boolean
        Try
            Dim ds As DataSet = GetDataSet("SP_SE_VERIFICACNPJ '" & CNPJ & "'")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
            ds = Nothing
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Apagar()
        Dim sql As String
        sql = "SP_DE_EMPRESAS " & m_intCodigo
        ExecuteNonQuery(sql)
    End Sub

#End Region

End Class