'************************************************************
'Classe gerada por XM Class Creator - 15/1/2003 12:03:46
'************************************************************
Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsAssociados

    Inherits DataClass

    Private m_intCodigo As Integer
    Private m_intCodigoITC As String
    Private m_intIdStatus As Integer
    Private m_intIdVendedor As Integer
    Private m_intIdPosicao As Integer
    Private m_intIdFormaPagto As Integer
    Private m_intIdTipo As Integer
    Private m_intIdRegiao As Integer
    Private m_intIdPessoa As Integer
    Private m_intIdRamo As Integer
    Private m_intIdAtividade As Integer
    Private m_intIdProduto As Integer
    Private m_NumFunc As String
    Private m_varModulo As String
    Private m_varFantasia As String
    Private m_varRazaoSocial As String
    Private m_varEndereco As String
    Private m_varComplemento As String
    Private m_strCEP As String
    Private m_varCidade As String
    Private m_varEstado As Integer
    Private m_varEnderecoCobranca As String
    Private m_varComplementoCobranca As String
    Private m_strCEPCobranca As String
    Private m_varCidadeCobranca As String
    Private m_varEstadoCobranca As Integer
    Private m_varEnderecoFaturamento As String
    Private m_varComplementoFaturamento As String
    Private m_strCEPFaturamento As String
    Private m_varCidadeFaturamento As String
    Private m_varEstadoFaturamento As Integer
    Private m_varCNPJ As String
    Private m_strInscricaoEstadual As String
    Private m_varInscricaoMunicipal As String
    Private m_varWebSite As String
    Private m_varEMail As String
    Private m_dtmDataInicioPlano As Object
    Private m_dtmDataFimPlano As Object
    Private m_dtmDataAtivacao As Object
    Private m_strObservacoes As String
    Private m_strProdutos As String
    Private m_strImagemGuia As String
    Private m_dtmPrimeiroContrato As String
    Private m_strVendedor As String
    Private m_varDDD As Integer
    Private m_strTelefone As String
    Private m_varDDDFax As String
    Private m_strFax As String
    Private m_strUf As String
    Private m_strSkype As String

    Private m_MensagemErro As String

#Region "Propriedades"

    Public Property Codigo() As Integer
        Get
            Return m_intCodigo
        End Get
        Set(ByVal Value As Integer)
            m_intCodigo = Value
        End Set
    End Property

    Public Property CodigoITC() As String
        Get
            Return m_intCodigoITC
        End Get
        Set(ByVal Value As String)
            m_intCodigoITC = Value
        End Set
    End Property
    Public Property IdStatus() As Integer
        Get
            Return m_intIdStatus
        End Get
        Set(ByVal Value As Integer)
            m_intIdStatus = Value
        End Set
    End Property
    Public Property IdVendedor() As Integer
        Get
            Return m_intIdVendedor
        End Get
        Set(ByVal Value As Integer)
            m_intIdVendedor = Value
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
    Public Property IdPosicao() As Integer
        Get
            Return m_intIdPosicao
        End Get
        Set(ByVal Value As Integer)
            m_intIdPosicao = Value
        End Set
    End Property
    Public Property IdFormaPagto() As Integer
        Get
            Return m_intIdFormaPagto
        End Get
        Set(ByVal Value As Integer)
            m_intIdFormaPagto = Value
        End Set
    End Property
    Public Property IdTipo() As Integer
        Get
            Return m_intIdTipo
        End Get
        Set(ByVal Value As Integer)
            m_intIdTipo = Value
        End Set
    End Property
    Public Property IdRegiao() As Integer
        Get
            Return m_intIdRegiao
        End Get
        Set(ByVal Value As Integer)
            m_intIdRegiao = Value
        End Set
    End Property
    Public Property IdPessoa() As Integer
        Get
            Return m_intIdPessoa
        End Get
        Set(ByVal Value As Integer)
            m_intIdPessoa = Value
        End Set
    End Property
    Public Property IdRamo() As Integer
        Get
            Return m_intIdRamo
        End Get
        Set(ByVal Value As Integer)
            m_intIdRamo = Value
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
    Public Property IdProduto() As Integer
        Get
            Return m_intIdProduto
        End Get
        Set(ByVal Value As Integer)
            m_intIdProduto = Value
        End Set
    End Property
    Public Property NumFunc() As String
        Get
            Return m_NumFunc
        End Get
        Set(ByVal Value As String)
            m_NumFunc = Value
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

    Public Property Modulo() As String
        Get
            Return m_varModulo
        End Get
        Set(ByVal Value As String)
            m_varModulo = Value
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

    Public Property Estado() As Integer
        Get
            Return m_varEstado
        End Get
        Set(ByVal Value As Integer)
            m_varEstado = Value
        End Set
    End Property

    Public Property UF() As String
        Get
            Return m_strUf
        End Get
        Set(ByVal Value As String)
            m_strUf = Value
        End Set
    End Property

    Public Property EnderecoCobranca() As String
        Get
            Return m_varEnderecoCobranca
        End Get
        Set(ByVal Value As String)
            m_varEnderecoCobranca = Value
        End Set
    End Property

    Public Property ComplementoCobranca() As String
        Get
            Return m_varComplementoCobranca
        End Get
        Set(ByVal Value As String)
            m_varComplementoCobranca = Value
        End Set
    End Property

    Public Property CEPCobranca() As String
        Get
            Return m_strCEPCobranca
        End Get
        Set(ByVal Value As String)
            m_strCEPCobranca = Value
        End Set
    End Property

    Public Property CidadeCobranca() As String
        Get
            Return m_varCidadeCobranca
        End Get
        Set(ByVal Value As String)
            m_varCidadeCobranca = Value
        End Set
    End Property

    Public Property EstadoCobranca() As Integer
        Get
            Return m_varEstadoCobranca
        End Get
        Set(ByVal Value As Integer)
            m_varEstadoCobranca = Value
        End Set
    End Property

    Public Property EnderecoFaturamento() As String
        Get
            Return m_varEnderecoFaturamento
        End Get
        Set(ByVal Value As String)
            m_varEnderecoFaturamento = Value
        End Set
    End Property

    Public Property ComplementoFaturamento() As String
        Get
            Return m_varComplementoFaturamento
        End Get
        Set(ByVal Value As String)
            m_varComplementoFaturamento = Value
        End Set
    End Property

    Public Property CEPFaturamento() As String
        Get
            Return m_strCEPFaturamento
        End Get
        Set(ByVal Value As String)
            m_strCEPFaturamento = Value
        End Set
    End Property

    Public Property CidadeFaturamento() As String
        Get
            Return m_varCidadeFaturamento
        End Get
        Set(ByVal Value As String)
            m_varCidadeFaturamento = Value
        End Set
    End Property

    Public Property EstadoFaturamento() As Integer
        Get
            Return m_varEstadoFaturamento
        End Get
        Set(ByVal Value As Integer)
            m_varEstadoFaturamento = Value
        End Set
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

    Public Property Observacoes() As String
        Get
            Return m_strObservacoes
        End Get
        Set(ByVal Value As String)
            m_strObservacoes = Value
        End Set
    End Property

    Public Property ImagemGuia() As String
        Get
            Return m_strImagemGuia
        End Get
        Set(ByVal Value As String)
            m_strImagemGuia = Value
        End Set
    End Property

    Public Property PrimeiroContrato() As String
        Get
            Return m_dtmPrimeiroContrato
        End Get
        Set(ByVal Value As String)
            m_dtmPrimeiroContrato = Value
        End Set
    End Property

    Public Property DDD() As Integer
        Get
            Return m_varDDD
        End Get
        Set(ByVal Value As Integer)
            m_varDDD = Value
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

    Public Property DDDFax() As Integer
        Get
            Return m_varDDDFax
        End Get
        Set(ByVal Value As Integer)
            m_varDDDFax = Value
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

    Public ReadOnly Property QuantidadeDiasPlano() As Long
        Get
            If IsDate(m_dtmDataInicioPlano) And IsDate(m_dtmDataFimPlano) Then
                Return DateDiff(DateInterval.Day, m_dtmDataInicioPlano, m_dtmDataFimPlano)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property DiasFimPlano() As Long
        Get
            If IsDate(m_dtmDataFimPlano) Then
                Dim p_Now As Object = FormatDateTime(Now, DateFormat.ShortDate)
                Dim lngDias As Long = DateDiff(DateInterval.Day, p_Now, m_dtmDataFimPlano)
                Return lngDias 'IIf(lngDias < 0, 0, lngDias)
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property DataAtivacao() As Object
        Get
            Return IIf(IsDate(m_dtmDataAtivacao), Right("00" & Day(m_dtmDataAtivacao), 2) & "/" & Right("00" & Month(m_dtmDataAtivacao), 2) & "/" & Right("0000" & Year(m_dtmDataAtivacao), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataAtivacao = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataAtivacao = Nothing
            End If
        End Set
    End Property

    Public Property InicioPlano() As Object
        Get
            Return IIf(IsDate(m_dtmDataInicioPlano), Right("00" & Day(m_dtmDataInicioPlano), 2) & "/" & Right("00" & Month(m_dtmDataInicioPlano), 2) & "/" & Right("0000" & Year(m_dtmDataInicioPlano), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataInicioPlano = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataInicioPlano = Nothing
            End If
        End Set
    End Property

    Public Property FimPlano() As Object
        Get
            Return IIf(IsDate(m_dtmDataFimPlano), Right("00" & Day(m_dtmDataFimPlano), 2) & "/" & Right("00" & Month(m_dtmDataFimPlano), 2) & "/" & Right("0000" & Year(m_dtmDataFimPlano), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataFimPlano = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataFimPlano = Nothing
            End If
        End Set
    End Property

    'Public ReadOnly Property Produtos()
    '    Get
    '        Return m_strProdutos
    '    End Get
    'End Property

    Public Property Produtos() As String
        Get
            Return m_strProdutos
        End Get
        Set(ByVal Value As String)
            m_strProdutos = Value
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

    Public ReadOnly Property MensagemErro()
        Get
            Return m_MensagemErro
        End Get
    End Property

#End Region

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intCodigo = CLng(0 & row("Codigo"))

        Me.m_intCodigoITC = CStr(row("CodigoITC") & "")
        Me.m_intIdStatus = CLng(0 & row("IdStatus"))
        Me.m_intIdVendedor = CLng(0 & row("IdVendedor"))
        Me.m_strVendedor = CStr(row("Vendedor") & "")
        Me.m_intIdPosicao = CLng(0 & row("IdPosicao"))
        Me.m_intIdFormaPagto = CLng(0 & row("IdFormaPagamento"))
        Me.m_intIdTipo = CLng(0 & row("IdTipo"))
        Me.m_intIdRegiao = CLng(0 & row("IdRegiao"))
        Me.m_intIdPessoa = CLng(0 & row("IdPessoa"))
        Me.m_intIdRamo = CLng(0 & row("IdRamo"))
        Me.m_intIdAtividade = CLng(0 & row("IdAtividade"))
        Me.m_intIdProduto = CLng(0 & row("IdProduto"))
        Me.m_NumFunc = CStr(row("NumFunc") & "")
        Me.m_varFantasia = CStr(row("Fantasia") & "")
        Me.m_varModulo = CStr(row("Modulo") & "")
        Me.m_varRazaoSocial = CStr(row("RazaoSocial") & "")
        Me.m_strImagemGuia = CStr(row("ImagemGuia") & "")


        Me.m_varEndereco = CStr(row("Endereco") & "")
        Me.m_varComplemento = CStr(row("Complemento") & "")
        Me.m_strCEP = CStr(row("CEP") & "")
        Me.m_varCidade = CStr(row("Cidade") & "")
        Me.m_varEstado = CLng(0 & row("IdEstado"))

        Me.m_varEnderecoCobranca = CStr(row("EnderecoCobranca") & "")
        Me.m_varComplementoCobranca = CStr(row("ComplementoCobranca") & "")
        Me.m_strCEPCobranca = CStr(row("CEPCobranca") & "")
        Me.m_varCidadeCobranca = CStr(row("CidadeCobranca") & "")
        Me.m_varEstadoCobranca = CLng(0 & row("IdEstadoCobranca"))

        Me.m_varEnderecoFaturamento = CStr(row("EnderecoFaturamento") & "")
        Me.m_varComplementoFaturamento = CStr(row("ComplementoFaturamento") & "")
        Me.m_strCEPFaturamento = CStr(row("CEPFaturamento") & "")
        Me.m_varCidadeFaturamento = CStr(row("CidadeFaturamento") & "")
        Me.m_varEstadoFaturamento = CLng(0 & row("IdEstadoFaturamento"))

        Me.m_varCNPJ = CStr(row("CNPJ") & "")
        Me.m_strInscricaoEstadual = CStr(row("InscricaoEstadual") & "")
        Me.m_varInscricaoMunicipal = CStr(row("InscricaoMunicipal") & "")
        Me.m_varWebSite = CStr(row("WebSite") & "")
        Me.m_varEMail = CStr(row("EMail") & "")
        Me.m_dtmDataAtivacao = CDate(row("DataAtivacao"))
        Me.m_strUf = CStr(row("UF"))

        '***********************************************************
        'CHECAGENS DE DATA PARA NÃO DAR INVALID USE OF NULL
        '***********************************************************
        If IsDate(row("dtm_DataInicioPlano")) Then
            Me.m_dtmDataInicioPlano = FormatDateTime(CDate(row("dtm_DataInicioPlano")), DateFormat.ShortDate)
        Else
            Me.m_dtmDataInicioPlano = ""
        End If

        If IsDate(row("dtm_DataInicioPlano")) Then
            Me.m_dtmDataFimPlano = FormatDateTime(CDate(row("dtmDataFimPlano")), DateFormat.ShortDate)
        Else
            Me.m_dtmDataFimPlano = ""
        End If
        '***********************************************************
        'FIM CHECAGENS DE DATA PARA NÃO DAR INVALID USE OF NULL
        '***********************************************************

        Me.m_strObservacoes = CStr(row("Observacoes") & "")
        Me.m_strProdutos = CStr(row("Produtos") & "")
        Me.m_dtmPrimeiroContrato = CStr(row("PrimeiroContrato") & "")
        Me.m_strSkype = CStr(row("Skype") & "")

    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intCodigo & "" & ","
        strDeflate &= "'" & Replace(m_varFantasia, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varRazaoSocial, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varEndereco, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varComplemento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strCEP, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varCidade, "'", "''") & "'" & ","
        strDeflate &= m_varEstado & ","
        strDeflate &= "'" & Replace(m_varEnderecoCobranca, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varComplementoCobranca, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strCEPCobranca, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varCidadeCobranca, "'", "''") & "'" & ","
        strDeflate &= m_varEstadoCobranca & ","
        strDeflate &= "'" & Replace(m_varEnderecoFaturamento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varComplementoFaturamento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strCEPFaturamento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varCidadeFaturamento, "'", "''") & "'" & ","
        strDeflate &= m_varEstadoFaturamento & ","
        strDeflate &= "'" & Replace(m_varCNPJ, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strInscricaoEstadual, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varInscricaoMunicipal, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_varWebSite, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_varEMail, "'", "''") & "',"
        strDeflate &= IIf(m_dtmDataInicioPlano Is Nothing, "NULL", "'" & m_dtmDataInicioPlano & "'") & ","
        strDeflate &= IIf(m_dtmDataFimPlano Is Nothing, "NULL", "'" & m_dtmDataFimPlano & "'") & ","
        strDeflate &= Me.m_intIdTipo & ","
        strDeflate &= Me.m_intIdRegiao & ","
        strDeflate &= Me.m_intIdPessoa & ","
        strDeflate &= Me.m_intIdPosicao & ","
        strDeflate &= Me.m_intIdFormaPagto & ","
        strDeflate &= Me.m_intIdAtividade & ","
        strDeflate &= Me.m_intIdStatus & ","
        strDeflate &= Me.m_intIdVendedor & ","
        strDeflate &= "'" & Me.m_NumFunc & "',"
        strDeflate &= "'" & Me.m_intCodigoITC & "',"
        strDeflate &= "'" & Me.m_dtmDataAtivacao & "',"
        strDeflate &= "'" & Me.m_strObservacoes & "',"
        strDeflate &= Me.m_intIdRamo & ","
        strDeflate &= Me.m_intIdProduto & ","
        strDeflate &= "'" & Replace(m_varModulo, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strImagemGuia, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_dtmPrimeiroContrato, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strSkype, "'", "''") & "'"
        Deflate = strDeflate
    End Function


    Public Function Delete(ByVal p_IdAssociado As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_ASSOCIADOS " & p_IdAssociado)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Sub Update()

        Try
            Dim sql As String
            m_MensagemErro = ""
            sql = "SP_SV_ASSOCIADOS " & Deflate()
            Dim myData As DataSet = GetDataSet(sql, m_MensagemErro)
            If myData.Tables(0).Rows.Count <= 0 Then
                Throw New ArgumentException("Não houve retorno de dados!")
            Else
                Inflate(myData.Tables(0).Rows(0))
            End If
            myData.Dispose()
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message.Replace("'", "''") & "','" & e.Source.Replace("'", "''") & "','ITC-NET'")
        End Try

    End Sub

    Public Sub New(ByVal p_intCodigo As Integer)
        If p_intCodigo = 0 Then
            Clear()
        Else
            Load(p_intCodigo)
        End If
    End Sub

    Sub New()

    End Sub

    Protected Sub Load(ByVal p_intCodigo As Integer)
        If p_intCodigo = 0 Then
            Clear()
            Exit Sub
        End If
        m_MensagemErro = ""
        Dim myData As DataSet = GetDataSet("SP_SE_ASSOCIADOS " & p_intCodigo, m_MensagemErro)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

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
        m_varWebSite = ""
        m_varEMail = ""
        m_dtmDataInicioPlano = Nothing
        m_dtmDataFimPlano = Nothing
        m_dtmDataAtivacao = Nothing
        m_strObservacoes = ""
        m_varModulo = ""
        m_dtmPrimeiroContrato = ""
        m_strVendedor = ""
        m_strUf = ""
        m_strSkype = ""
    End Sub

    Public Function List(ByVal p_Codigo As Integer, ByVal p_RazaoSocial As String, ByVal p_CNPJ As String, ByVal p_Registros As Integer) As DataSet
        Try

            If p_RazaoSocial.Trim = "" Then
                p_RazaoSocial = "NULL"
            Else
                p_RazaoSocial = "'" & p_RazaoSocial & "'"
            End If
            If p_CNPJ.Trim = "" Then
                p_CNPJ = "NULL"
            Else
                p_CNPJ = "'" & p_CNPJ & "'"
            End If
            m_MensagemErro = ""

            Return GetDataSet("SP_SE_ASSOCIADOS " & p_Codigo & ", " & p_RazaoSocial & "," & p_CNPJ & "," & p_Registros, m_MensagemErro)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        Finally

        End Try
    End Function

    Public Function List(ByVal p_IdProduto As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_ASSOCIADOSGUIA " & p_IdProduto)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        Finally

        End Try
    End Function

    Public Function List() As DataSet
        Try
            List = GetDataSet("SP_SE_ASSOCIADOS")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function Find(ByVal RazaoSocialEmpresa As String) As DataSet
        Try
            m_MensagemErro = ""
            Return GetDataSet("SP_SE_ASSOCIADOS 0, " & RazaoSocialEmpresa & ", NULL", m_MensagemErro)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTiposRegioes(ByVal p_IdAssociado As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_TIPOSREGIOES " & p_IdAssociado)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListTiposRegioesGestor(ByVal p_IdGestor As Integer, ByVal p_IdAssociado As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_PERMISSAOGESTOR " & p_IdGestor & "," & p_IdAssociado)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Sub SalvarPermissoesGestor(ByVal p_IdGestor As Integer, ByVal Item As String)
        Try
            ExecuteNonQuery("SP_SV_PERMISSOESGESTOR " & p_IdGestor & ",'" & Item & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Sub

    Public Sub SalvaSelecao(ByVal Item As String)
        Try
            If Item = "" Then
                Item = "_"
            End If
            ExecuteNonQuery("SP_SV_SALVASELECAOASSOCIADOS " & m_intCodigo & ",'" & Item & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Sub

    Public Function CNPJExiste(ByVal vCNPJ As String) As Boolean

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_ASSOCIADO_CNPJ_EXISTENTE"
        Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        parameter.Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add(parameter)
        cmd.Parameters.Add("@IDASSOCIADO", SqlDbType.Int).Value = m_intCodigo
        cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 20).Value = vCNPJ
        ExecuteNonQuery(cmd)

        Return IIf(cmd.Parameters("@RETURN_VALUE").Value = 1, True, False)

    End Function

End Class