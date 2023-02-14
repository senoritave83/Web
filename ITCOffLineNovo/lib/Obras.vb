'************************************************************
'Classe gerada por XM Class Creator - 15/1/2003 11:47:40
'************************************************************

Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsObras

    Inherits DataClass

    Private m_intCodigo As Integer
    Private m_strCodigoAntigo As String
    Private m_varAtualizacao As Object
    Private m_varPublicacao As Object
    Private m_dblNrDaRevisao As Double
    Private m_intIdPesquisador As Integer
    Private m_strProjeto As String
    Private m_varValor As String
    Private m_dblAreaConstruida As String
    Private m_shrNrdeFuncionarios As String
    Private m_strCapacidadeDeProducao As String
    Private m_strProdutoFinal As String
    Private m_strMateriaPrima As String
    Private m_strFantasia As String
    Private m_strRazaoSocial As String
    Private m_strEndereco As String
    Private m_strComplemento As String
    Private m_strCEP As String
    Private m_strCidade As String
    Private m_intEstado As Integer
    Private m_varInicio As Object
    Private m_varTermino As Object
    Private m_varEstagioAtual As Object
    Private m_intIDFase As Object
    Private m_intIDTipo As Integer
    Private m_intIdVen As Integer
    Private m_varTipo As Object
    Private m_strDecricaoProjeto As Object
    Private m_dtmDataCadastro As Object
    Private m_strInicioTermino As String
    Private m_Demo As Boolean
    Private m_Ativo As Integer
    Private m_Nome As String
    Private m_Vendedor As Integer

    '************************************************
    'CAMPOS NOVOS 
    '************************************************
    Private m_obr_IdSubTipo_int As Integer
    Private m_obr_IdAreaLazer_int As Integer
    Private m_obr_EstagioDetalhes_chr As String
    Private m_obr_DescResidEdificio_chr As String
    Private m_obr_DescResidResidenciais_chr As String
    Private m_obr_DescResidCondominios_chr As String
    Private m_obr_DescResidPavimentos_chr As String
    Private m_obr_DescResidApartamentos_chr As String
    Private m_obr_DescResidDormitorios_chr As String
    Private m_obr_DescResidSuite_chr As String
    Private m_obr_DescResidBanheiro_chr As String
    Private m_obr_DescResidLavabo_chr As String
    Private m_obr_DescResidSala_chr As String
    Private m_obr_DescResidCopa_chr As String
    Private m_obr_DescResidATV_chr As String
    Private m_obr_DescResidDepEmpreg_chr As String
    Private m_obr_DescResidOutros_chr As String
    Private m_obr_DescInfoAdicTotalUnicades_chr As String
    Private m_obr_DescInfoAdicAreaUtil_chr As String
    Private m_obr_DescInfoAdicAreaTerreno_chr As String
    Private m_obr_DescInfoAdicElevador_chr As String
    Private m_obr_DescInfoAdicVagas_chr As String
    Private m_obr_DescInfoAdicCobert_chr As String
    Private m_obr_DescInfoAdicArCondic_chr As String
    Private m_obr_DescInfoAdicAquecimento_chr As String
    Private m_obr_DescInfoAdicFundacoes_chr As String
    Private m_obr_DescInfoAdicEstrutura_chr As String
    Private m_obr_DescInfoAdicAcabamento_chr As String
    Private m_obr_DescInfoAdicFachada_chr As String
    Private m_obr_Foto_chr As String
    Private m_obr_Mapa_chr As String
    Private m_usuarioalteracao_chr As String
    Private m_obr_IdTipoCotacao_int As Integer
    Private m_obr_ValorDolar_chr As String
    Private m_obr_OutrosAreaLazer_chr As String

    '************************************************
    'FIM CAMPOS NOVOS 
    '************************************************

    Public Enum Categoria
        OBRA = 1
        EMPRESA = 2
        ITC = -1
    End Enum

    Public Enum Ordenacao
        CODIGOITC = 1
        RAZAOSOCIAL = 2
        FANTASIA = 3
        NOMEOBRA = 4
        ENDERECO = 5
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

    Public Property Nome() As String
        Get
            Return m_Nome
        End Get
        Set(ByVal Value As String)
            m_Nome = Value
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

    Public Property CodigoAntigo() As String
        Get
            Return m_strCodigoAntigo
        End Get
        Set(ByVal Value As String)
            m_strCodigoAntigo = Value
        End Set
    End Property

    Public Property Atualizacao() As Object
        Get
            Return m_varAtualizacao
        End Get
        Set(ByVal Value As Object)
            m_varAtualizacao = Value
        End Set
    End Property

    Public Property Publicacao() As Object
        Get
            If IsDate(m_varPublicacao) Then
                Return Right("00" & Day(m_varPublicacao), 2) & "/" & Right("00" & Month(m_varPublicacao), 2) & "/" & Right("0000" & Year(m_varPublicacao), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_varPublicacao = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_varPublicacao = Nothing
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

    Public Property Pesquisador() As Integer
        Get
            Return m_intIdPesquisador
        End Get
        Set(ByVal Value As Integer)
            m_intIdPesquisador = Value
        End Set
    End Property

    Public Property Projeto() As String
        Get
            Return m_strProjeto
        End Get
        Set(ByVal Value As String)
            m_strProjeto = Value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return m_varValor
        End Get
        Set(ByVal Value As String)
            m_varValor = Value
        End Set
    End Property

    Public Property AreaConstruida() As String
        Get
            Return m_dblAreaConstruida
        End Get
        Set(ByVal Value As String)
            m_dblAreaConstruida = Value
        End Set
    End Property

    Public Property NrdeFuncionarios() As Short
        Get
            Return m_shrNrdeFuncionarios
        End Get
        Set(ByVal Value As Short)
            m_shrNrdeFuncionarios = Value
        End Set
    End Property

    Public Property CapacidadeDeProducao() As String
        Get
            Return m_strCapacidadeDeProducao
        End Get
        Set(ByVal Value As String)
            m_strCapacidadeDeProducao = Value
        End Set
    End Property

    Public Property ProdutoFinal() As String
        Get
            Return m_strProdutoFinal
        End Get
        Set(ByVal Value As String)
            m_strProdutoFinal = Value
        End Set
    End Property

    Public Property MateriaPrima() As String
        Get
            Return m_strMateriaPrima
        End Get
        Set(ByVal Value As String)
            m_strMateriaPrima = Value
        End Set
    End Property

    Public Property Fantasia() As String
        Get
            Return m_strFantasia
        End Get
        Set(ByVal Value As String)
            m_strFantasia = Value
        End Set
    End Property

    Public Property RazaoSocial() As String
        Get
            Return m_strRazaoSocial
        End Get
        Set(ByVal Value As String)
            m_strRazaoSocial = Value
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

    Public Property Complemento() As String
        Get
            Return m_strComplemento
        End Get
        Set(ByVal Value As String)
            m_strComplemento = Value
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
            Return m_strCidade
        End Get
        Set(ByVal Value As String)
            m_strCidade = Value
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return m_intEstado
        End Get
        Set(ByVal Value As Integer)
            m_intEstado = Value
        End Set
    End Property

    Public Property Inicio() As Object
        Get
            If IsDate(m_varInicio) Then
                Return Right("00" & Day(CDate(m_varInicio)), 2) & "/" & Right("00" & Month(CDate(m_varInicio)), 2) & "/" & Right("0000" & Year(CDate(m_varInicio)), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_varInicio = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_varInicio = Nothing
            End If

        End Set
    End Property

    Public Property Termino() As Object
        Get
            If IsDate(m_varTermino) Then
                Return Right("00" & Day(CDate(m_varTermino)), 2) & "/" & Right("00" & Month(CDate(m_varTermino)), 2) & "/" & Right("0000" & Year(CDate(m_varTermino)), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_varTermino = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_varTermino = Nothing
            End If
        End Set
    End Property

    Public Property DataCadastro() As Object
        Get
            If IsDate(m_dtmDataCadastro) Then
                Return Right("00" & Day(CDate(m_dtmDataCadastro)), 2) & "/" & Right("00" & Month(CDate(m_dtmDataCadastro)), 2) & "/" & Right("0000" & Year(CDate(m_dtmDataCadastro)), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataCadastro = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataCadastro = Nothing
            End If
        End Set
    End Property

    Public Property EstagioAtual() As Object
        Get
            Return m_varEstagioAtual
        End Get
        Set(ByVal Value As Object)
            m_varEstagioAtual = Value
        End Set
    End Property

    Public Property IDFase() As Object
        Get
            Return m_intIDFase
        End Get
        Set(ByVal Value As Object)
            m_intIDFase = Value
        End Set
    End Property

    Public ReadOnly Property Tipo() As Object
        Get
            Return m_varTipo
        End Get
    End Property

    Public Property IdVendedor() As Integer
        Get
            Return m_intIdVen
        End Get
        Set(ByVal Value As Integer)
            m_intIdVen = Value
        End Set
    End Property

    Public Property IdTipo() As Integer
        Get
            Return m_intIDTipo
        End Get
        Set(ByVal Value As Integer)
            m_intIDTipo = Value
        End Set
    End Property

    Public Property DescProj1() As Object
        Get
            Return m_strDecricaoProjeto
        End Get
        Set(ByVal Value As Object)
            m_strDecricaoProjeto = Value
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

    Public Property InicioTermino() As String
        Get
            Return m_strInicioTermino
        End Get
        Set(ByVal Value As String)
            m_strInicioTermino = Value
        End Set
    End Property

    Public Property IdAreaLazer()
        Get
            Return m_obr_IdAreaLazer_int
        End Get
        Set(ByVal Value)
            m_obr_IdAreaLazer_int = Value
        End Set
    End Property

    Public Property IdSubTipo() As Integer
        Get
            Return m_obr_IdSubTipo_int
        End Get
        Set(ByVal Value As Integer)
            m_obr_IdSubTipo_int = Value
        End Set
    End Property

    Public Property EstagioDetalhes() As String
        Get
            Return m_obr_EstagioDetalhes_chr
        End Get
        Set(ByVal Value As String)
            m_obr_EstagioDetalhes_chr = Value
        End Set
    End Property


    Public Property DescResidEdificio() As String
        Get
            Return m_obr_DescResidEdificio_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidEdificio_chr = Value
        End Set
    End Property


    Public Property DescResidResidenciais() As String
        Get
            Return m_obr_DescResidResidenciais_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidResidenciais_chr = Value
        End Set
    End Property


    Public Property DescResidCondominios() As String
        Get
            Return m_obr_DescResidCondominios_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidCondominios_chr = Value
        End Set
    End Property


    Public Property DescResidPavimentos() As String
        Get
            Return m_obr_DescResidPavimentos_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidPavimentos_chr = Value
        End Set
    End Property


    Public Property DescResidApartamentos() As String
        Get
            Return m_obr_DescResidApartamentos_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidApartamentos_chr = Value
        End Set
    End Property

    Public Property DescResidDormitorios() As String
        Get
            Return m_obr_DescResidDormitorios_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidDormitorios_chr = Value
        End Set
    End Property


    Public Property DescResidSuite() As String
        Get
            Return m_obr_DescResidSuite_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidSuite_chr = Value
        End Set
    End Property

    Public Property DescResidBanheiro() As String
        Get
            Return m_obr_DescResidBanheiro_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidBanheiro_chr = Value
        End Set
    End Property


    Public Property DescResidLavabo() As String
        Get
            Return m_obr_DescResidLavabo_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidLavabo_chr = Value
        End Set
    End Property


    Public Property DescResidSala() As String
        Get
            Return m_obr_DescResidSala_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidSala_chr = Value
        End Set
    End Property

    Public Property DescResidCopa() As String
        Get
            Return m_obr_DescResidCopa_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidCopa_chr = Value
        End Set
    End Property

    Public Property DescResidATV() As String
        Get
            Return m_obr_DescResidATV_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidATV_chr = Value
        End Set
    End Property


    Public Property DescResidDepEmpreg() As String
        Get
            Return m_obr_DescResidDepEmpreg_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidDepEmpreg_chr = Value
        End Set
    End Property

    Public Property DescResidOutros() As String
        Get
            Return m_obr_DescResidOutros_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescResidOutros_chr = Value
        End Set
    End Property

    Public Property DescInfoAdicTotalUnicades() As String
        Get
            Return m_obr_DescInfoAdicTotalUnicades_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicTotalUnicades_chr = Value
        End Set
    End Property

    Public Property DescInfoAdicAreaUtil() As String
        Get
            Return m_obr_DescInfoAdicAreaUtil_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicAreaUtil_chr = Value
        End Set
    End Property

    Public Property DescInfoAdicAreaTerreno() As String
        Get
            Return m_obr_DescInfoAdicAreaTerreno_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicAreaTerreno_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicElevador() As String
        Get
            Return m_obr_DescInfoAdicElevador_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicElevador_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicVagas() As String
        Get
            Return m_obr_DescInfoAdicVagas_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicVagas_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicCobert() As String
        Get
            Return m_obr_DescInfoAdicCobert_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicCobert_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicArCondic() As String
        Get
            Return m_obr_DescInfoAdicArCondic_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicArCondic_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicAquecimento() As String
        Get
            Return m_obr_DescInfoAdicAquecimento_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicAquecimento_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicFundacoes() As String
        Get
            Return m_obr_DescInfoAdicFundacoes_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicFundacoes_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicEstrutura() As String
        Get
            Return m_obr_DescInfoAdicEstrutura_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicEstrutura_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicAcabamento() As String
        Get
            Return m_obr_DescInfoAdicAcabamento_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicAcabamento_chr = Value
        End Set
    End Property


    Public Property DescInfoAdicFachada() As String
        Get
            Return m_obr_DescInfoAdicFachada_chr
        End Get
        Set(ByVal Value As String)
            m_obr_DescInfoAdicFachada_chr = Value
        End Set
    End Property

    Public Property Foto() As String
        Get
            Return m_obr_Foto_chr
        End Get
        Set(ByVal Value As String)
            m_obr_Foto_chr = Value
        End Set
    End Property

    Public Property Mapa() As String
        Get
            Return m_obr_Mapa_chr
        End Get
        Set(ByVal Value As String)
            m_obr_Mapa_chr = Value
        End Set
    End Property

    Public Property UsuarioAlteracao() As String
        Get
            Return m_usuarioalteracao_chr
        End Get
        Set(ByVal Value As String)
            m_usuarioalteracao_chr = Value
        End Set
    End Property

    Public Property IDTipoCotacao() As Integer
        Get
            Return m_obr_IdTipoCotacao_int
        End Get
        Set(ByVal Value As Integer)
            m_obr_IdTipoCotacao_int = Value
        End Set
    End Property

    Public Property ValorDolar() As String
        Get
            Return m_obr_ValorDolar_chr
        End Get
        Set(ByVal Value As String)
            m_obr_ValorDolar_chr = Value
        End Set
    End Property

    Public Property OutrosAreaLazer() As String
        Get
            Return m_obr_OutrosAreaLazer_chr
        End Get
        Set(ByVal Value As String)
            m_obr_OutrosAreaLazer_chr = Value
        End Set
    End Property

    Private Sub Inflate(ByVal dr As SqlDataReader)

        Me.m_intCodigo = CLng(0 & dr("Codigo"))
        Me.m_strCodigoAntigo = CStr(dr("CodigoAntigo") & "")
        Me.m_varPublicacao = CStr(dr("Publicacao") & "")
        Me.m_dblNrDaRevisao = CLng(0 & dr("NrDaRevisao"))
        Me.m_strProjeto = CStr(dr("Projeto") & "")
        Me.m_varValor = CLng(0 & dr("Valor"))
        'If IsNumeric(dr("Valor")) Then
        '    Me.m_varValor = FormatNumber(dr("Valor"), 2).ToString.Replace(".", "")
        'Else
        '    Me.m_varValor = ""
        'End If
        Me.m_intIdPesquisador = CLng(0 & dr("Pesquisador"))
        Me.m_dblAreaConstruida = CStr(dr("AreaConstruida") & "")
        Me.m_strCapacidadeDeProducao = CStr(dr("CapacidadeDeProducao") & "")
        Me.m_strMateriaPrima = CStr(dr("MateriaPrima") & "")
        Me.m_strEndereco = CStr(dr("Endereco") & "")
        Me.m_strComplemento = CStr(dr("Complemento") & "")
        Me.m_strCEP = CStr(dr("CEP") & "")
        Me.m_strCidade = CStr(dr("Cidade") & "")
        Me.m_intEstado = CInt(0 & dr("IDEstado"))
        Me.m_varInicio = CStr(dr("Inicio") & "")
        Me.m_varTermino = CStr(dr("Termino") & "")
        Me.m_varEstagioAtual = CInt(0 & dr("IdEstagio"))
        Me.m_intIDFase = CInt(0 & dr("IDFase"))
        Me.m_varTipo = CStr(dr("Tipo") & "")
        Me.m_intIDTipo = CStr(dr("IdTipo") & "")
        Me.m_strDecricaoProjeto = CStr(dr("DescProj1") & "")
        Me.m_dtmDataCadastro = CStr(dr("DataCadastro") & "")
        Me.m_strInicioTermino = CStr(dr("InicioTermino") & "")
        Me.m_Demo = IIf(CInt(0 & dr("IndDemo")) = 1, True, False)
        Me.m_Ativo = CInt(0 & dr("IndStatus"))
        Me.m_Vendedor = CInt(0 & dr("Vendedor"))

        m_obr_IdSubTipo_int = CInt(0 & dr("obr_IdSubTipo"))
        m_obr_IdAreaLazer_int = CInt(0 & dr("obr_AreaLazer_int"))
        m_obr_EstagioDetalhes_chr = CStr(dr("obr_EstagioDetalhes_chr") & "")
        m_obr_DescResidEdificio_chr = CStr(dr("obr_DescResidEdificio_chr") & "")
        m_obr_DescResidResidenciais_chr = CStr(dr("obr_DescResidResidenciais_chr") & "")
        m_obr_DescResidCondominios_chr = CStr(dr("obr_DescResidCondominios_chr") & "")
        m_obr_DescResidPavimentos_chr = CStr(dr("obr_DescResidPavimentos_chr") & "")
        m_obr_DescResidApartamentos_chr = CStr(dr("obr_DescResidApartamentos_chr") & "")
        m_obr_DescResidDormitorios_chr = CStr(dr("obr_DescResidDormitorios_chr") & "")
        m_obr_DescResidSuite_chr = CStr(dr("obr_DescResidSuite_chr") & "")
        m_obr_DescResidBanheiro_chr = CStr(dr("obr_DescResidBanheiro_chr") & "")
        m_obr_DescResidLavabo_chr = CStr(dr("obr_DescResidLavabo_chr") & "")
        m_obr_DescResidSala_chr = CStr(dr("obr_DescResidSala_chr") & "")
        m_obr_DescResidCopa_chr = CStr(dr("obr_DescResidCopa_chr") & "")
        m_obr_DescResidATV_chr = CStr(dr("obr_DescResidATV_chr") & "")
        m_obr_DescResidDepEmpreg_chr = CStr(dr("obr_DescResidDepEmpreg_chr") & "")
        m_obr_DescResidOutros_chr = CStr(dr("obr_DescResidOutros_chr") & "")
        m_obr_DescInfoAdicTotalUnicades_chr = CStr(dr("obr_DescInfoAdicTotalUnicades_chr") & "")
        m_obr_DescInfoAdicAreaUtil_chr = CStr(dr("obr_DescInfoAdicAreaUtil_chr") & "")
        m_obr_DescInfoAdicAreaTerreno_chr = CStr(dr("obr_DescInfoAdicAreaTerreno_chr") & "")
        m_obr_DescInfoAdicElevador_chr = CStr(dr("obr_DescInfoAdicElevador_chr") & "")
        m_obr_DescInfoAdicVagas_chr = CStr(dr("obr_DescInfoAdicVagas_chr") & "")
        m_obr_DescInfoAdicCobert_chr = CStr(dr("obr_DescInfoAdicCobert_chr") & "")
        m_obr_DescInfoAdicArCondic_chr = CStr(dr("obr_DescInfoAdicArCondic_chr") & "")
        m_obr_DescInfoAdicAquecimento_chr = CStr(dr("obr_DescInfoAdicAquecimento_chr") & "")
        m_obr_DescInfoAdicFundacoes_chr = CStr(dr("obr_DescInfoAdicFundacoes_chr") & "")
        m_obr_DescInfoAdicEstrutura_chr = CStr(dr("obr_DescInfoAdicEstrutura_chr") & "")
        m_obr_DescInfoAdicAcabamento_chr = CStr(dr("obr_DescInfoAdicAcabamento_chr") & "")
        m_obr_DescInfoAdicFachada_chr = CStr(dr("obr_DescInfoAdicFachada_chr") & "")
        m_obr_Foto_chr = CStr(dr("obr_Foto_chr") & "")
        m_obr_Mapa_chr = CStr(dr("obr_Mapa_chr") & "")
        m_obr_IdTipoCotacao_int = CInt(0 & dr("obr_IdTipoCotacao_int"))
        m_obr_ValorDolar_chr = CStr(dr("obr_ValorDolar_chr") & "")
        m_obr_OutrosAreaLazer_chr = CStr(dr("obr_OutrosAreaLazer_chr") & "")

    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String

        strDeflate &= "" & m_intCodigo & "" & ","
        strDeflate &= "'" & Replace(m_strCodigoAntigo, "'", "''") & "'" & ","
        strDeflate &= Microsoft.VisualBasic.IIf(m_varPublicacao Is Nothing, "NULL", "'" & m_varPublicacao) & "',"
        strDeflate &= "" & m_dblNrDaRevisao & "" & ","
        strDeflate &= "'" & Replace(m_strProjeto, "'", "''") & "'" & ","
        strDeflate &= Microsoft.VisualBasic.IIf(IsNumeric(m_varValor), "'" & m_varValor & "'", "NULL") & ","
        strDeflate &= "'" & m_dblAreaConstruida & "" & "',"
        strDeflate &= "'" & Replace(m_strCapacidadeDeProducao, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strMateriaPrima, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strEndereco, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strComplemento, "'", "''") & "'" & ","
        strDeflate &= "'" & Replace(m_strCEP, "'", "''") & "" & "',"
        strDeflate &= "'" & Replace(m_strCidade, "'", "''") & "'" & ","
        strDeflate &= m_intEstado & ","
        strDeflate &= Microsoft.VisualBasic.IIf(m_varInicio Is Nothing, "NULL", "'" & m_varInicio & "'") & ","
        strDeflate &= Microsoft.VisualBasic.IIf(m_varTermino Is Nothing, "NULL", "'" & m_varTermino & "'") & ","
        strDeflate &= m_varEstagioAtual & ","
        strDeflate &= m_intIDFase & ","
        strDeflate &= "" & m_intIDTipo & "" & ","
        strDeflate &= "'" & Replace(m_strDecricaoProjeto, "'", "''") & "',"
        strDeflate &= m_intIdPesquisador & ","
        strDeflate &= Microsoft.VisualBasic.IIf(m_dtmDataCadastro Is Nothing, "NULL", "'" & m_dtmDataCadastro & "'") & ","
        strDeflate &= "'" & Replace(m_strInicioTermino, "'", "''") & "',"
        strDeflate &= IIf(m_Demo, 1, 0) & ","
        strDeflate &= m_Ativo & ","
        strDeflate &= Me.Categoria.ITC & ","
        strDeflate &= m_Vendedor & ","
        strDeflate &= m_intIDTipo & ","

        strDeflate &= m_obr_IdSubTipo_int & ","
        strDeflate &= m_obr_IdAreaLazer_int & ","
        strDeflate &= "'" & Replace(m_obr_EstagioDetalhes_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidEdificio_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidResidenciais_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidCondominios_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidPavimentos_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidApartamentos_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidDormitorios_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidSuite_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidBanheiro_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidLavabo_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidSala_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidCopa_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidATV_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidDepEmpreg_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescResidOutros_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicTotalUnicades_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicAreaUtil_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicAreaTerreno_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicElevador_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicVagas_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicCobert_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicArCondic_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicAquecimento_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicFundacoes_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicEstrutura_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicAcabamento_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_DescInfoAdicFachada_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_Foto_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_Mapa_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_usuarioalteracao_chr, "'", "''") & "',"
        strDeflate &= m_obr_IdTipoCotacao_int & ","
        strDeflate &= "'" & Replace(m_obr_ValorDolar_chr, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_obr_OutrosAreaLazer_chr, "'", "''") & "'"

        Return strDeflate


    End Function

    Public Function ExisteCodigoObra() As Boolean

        Dim sql As String
        Dim myData As DataSet

        sql = "SP_BS_EXISTECODIGOOBRA '" & m_strCodigoAntigo & "'"
        myData = GetDataSet(sql)

        If myData.Tables(0).Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If

        myData.Dispose()

    End Function

    'Public Sub Update()

    '    Dim sql As String
    '    Dim myData As DataSet

    '    sql = "SP_SV_OBRAS " & Deflate()
    '    myData = GetDataSet(sql)

    '    If myData.Tables(0).Rows.Count <= 0 Then
    '        Throw New ArgumentException("Não houve retorno de dados!")
    '    Else
    '        Inflate(myData.Tables(0).Rows(0))
    '    End If

    '    myData.Dispose()

    'End Sub

    Public Sub Update()
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SV_OBRAS"
        cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = m_intCodigo     
        cmd.Parameters.Add("@CODIGOANTIGO", SqlDbType.VarChar, 255).Value = m_strCodigoAntigo
        cmd.Parameters.Add("@PUBLICACAO", SqlDbType.DateTime).Value = m_varPublicacao
        cmd.Parameters.Add("@NRDAREVISAO", SqlDbType.Real).Value = m_dblNrDaRevisao
        cmd.Parameters.Add("@PROJETO", SqlDbType.VarChar, 255).Value = m_strProjeto
        cmd.Parameters.Add("@VALOR", SqlDbType.Money).Value = m_varValor
        cmd.Parameters.Add("@AREACONSTRUIDA", SqlDbType.Real).Value = m_dblAreaConstruida
        cmd.Parameters.Add("@CAPACIDADEDEPRODUCAO", SqlDbType.VarChar, 255).Value = m_strCapacidadeDeProducao
        cmd.Parameters.Add("@MATERIAPRIMA", SqlDbType.VarChar, 255).Value = m_strMateriaPrima
        cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 255).Value = m_strEndereco
        cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar, 255).Value = m_strComplemento
        cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 20).Value = m_strCEP
        cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 255).Value = m_strCidade
        cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = m_intEstado
        cmd.Parameters.Add("@INICIO", SqlDbType.DateTime).Value = m_varInicio
        cmd.Parameters.Add("@TERMINO", SqlDbType.DateTime).Value = m_varTermino
        cmd.Parameters.Add("@ESTAGIOATUAL", SqlDbType.Int).Value = m_varEstagioAtual
        cmd.Parameters.Add("@FASE", SqlDbType.Int).Value = m_intIDFase
        cmd.Parameters.Add("@DESCPROJ1", SqlDbType.VarChar, 1000).Value = m_strDecricaoProjeto
        cmd.Parameters.Add("@IDPESQUISADOR", SqlDbType.Int).Value = m_intIdPesquisador
        cmd.Parameters.Add("@DATACADASTRO", SqlDbType.DateTime).Value = m_dtmDataCadastro
        cmd.Parameters.Add("@INICIOTERMINO", SqlDbType.VarChar, 50).Value = m_strInicioTermino
        cmd.Parameters.Add("@DEMO", SqlDbType.TinyInt).Value = m_Demo
        cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = m_Ativo
        cmd.Parameters.Add("@IDASSOCIADO", SqlDbType.Int).Value = Me.Categoria.ITC
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_Vendedor
        cmd.Parameters.Add("@IDTIPO", SqlDbType.Int).Value = m_intIDTipo
        cmd.Parameters.Add("@obr_IdSubTipo", SqlDbType.Int).Value = m_obr_IdSubTipo_int
        cmd.Parameters.Add("@obr_AreaLazer_int", SqlDbType.Int).Value = m_obr_IdAreaLazer_int
        cmd.Parameters.Add("@obr_EstagioDetalhes_chr", SqlDbType.VarChar, 1000).Value = m_obr_EstagioDetalhes_chr
        cmd.Parameters.Add("@obr_DescResidEdificio_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidEdificio_chr
        cmd.Parameters.Add("@obr_DescResidResidenciais_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidResidenciais_chr
        cmd.Parameters.Add("@obr_DescResidCondominios_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidCondominios_chr
        cmd.Parameters.Add("@obr_DescResidPavimentos_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidPavimentos_chr
        cmd.Parameters.Add("@obr_DescResidApartamentos_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidApartamentos_chr
        cmd.Parameters.Add("@obr_DescResidDormitorios_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidDormitorios_chr
        cmd.Parameters.Add("@obr_DescResidSuite_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidSuite_chr
        cmd.Parameters.Add("@obr_DescResidBanheiro_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidBanheiro_chr
        cmd.Parameters.Add("@obr_DescResidLavabo_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidLavabo_chr
        cmd.Parameters.Add("@obr_DescResidSala_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidSala_chr
        cmd.Parameters.Add("@obr_DescResidCopa_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidCopa_chr
        cmd.Parameters.Add("@obr_DescResidATV_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidATV_chr
        cmd.Parameters.Add("@obr_DescResidDepEmpreg_chr", SqlDbType.VarChar, 20).Value = m_obr_DescResidDepEmpreg_chr
        cmd.Parameters.Add("@obr_DescResidOutros_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescResidOutros_chr
        cmd.Parameters.Add("@obr_DescInfoAdicTotalUnicades_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicTotalUnicades_chr
        cmd.Parameters.Add("@obr_DescInfoAdicAreaUtil_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicAreaUtil_chr
        cmd.Parameters.Add("@obr_DescInfoAdicAreaTerreno_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicAreaTerreno_chr
        cmd.Parameters.Add("@obr_DescInfoAdicElevador_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicElevador_chr
        cmd.Parameters.Add("@obr_DescInfoAdicVagas_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicVagas_chr
        cmd.Parameters.Add("@obr_DescInfoAdicCobert_chr", SqlDbType.VarChar, 15).Value = m_obr_DescInfoAdicCobert_chr
        cmd.Parameters.Add("@obr_DescInfoAdicArCondic_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicArCondic_chr
        cmd.Parameters.Add("@obr_DescInfoAdicAquecimento_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicAquecimento_chr
        cmd.Parameters.Add("@obr_DescInfoAdicFundacoes_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicFundacoes_chr
        cmd.Parameters.Add("@obr_DescInfoAdicEstrutura_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicEstrutura_chr
        cmd.Parameters.Add("@obr_DescInfoAdicAcabamento_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicAcabamento_chr
        cmd.Parameters.Add("@obr_DescInfoAdicFachada_chr", SqlDbType.VarChar, 1000).Value = m_obr_DescInfoAdicFachada_chr
        cmd.Parameters.Add("@obr_Foto_chr", SqlDbType.VarChar, 1000).Value = m_obr_Foto_chr
        cmd.Parameters.Add("@obr_Mapa_chr", SqlDbType.VarChar, 1000).Value = m_obr_Mapa_chr
        cmd.Parameters.Add("@usuario_logado", SqlDbType.VarChar, 100).Value = m_usuarioalteracao_chr
        cmd.Parameters.Add("@obr_IdTipoCotacao_int", SqlDbType.Int).Value = m_obr_IdTipoCotacao_int
        cmd.Parameters.Add("@obr_ValorDolar_chr", SqlDbType.VarChar, 15).Value = m_obr_ValorDolar_chr
        cmd.Parameters.Add("@obr_OutrosAreaLazer_chr", SqlDbType.VarChar, 50).Value = m_obr_OutrosAreaLazer_chr
        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
    End Sub

    Public Sub New(ByVal p_Codigo As Integer, ByVal p_Versao As Integer)
        If p_Codigo = 0 Then
            Clear()
        Else
            If p_Versao = 0 Then
                Load(p_Codigo)
            Else
                Load(p_Codigo, p_Versao)
            End If
        End If
    End Sub

    Protected Sub Load(ByVal p_Codigo As Integer)

        If p_Codigo = 0 Then
            Clear()
            Exit Sub
        End If

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_OBRAS"
        cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = p_Codigo

        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        'Dim myData As DataSet

        'myData = GetDataSet("SP_SE_OBRAS " & p_Codigo)

        'If myData.Tables(0).Rows.Count <= 0 Then
        '    Throw New ArgumentException("O cadastro indicado não existe!")
        'Else
        '    Inflate(myData.Tables(0).Rows(0))
        'End If
        'myData.Dispose()

    End Sub

    Protected Sub Load(ByVal p_CodigoObr As Integer, ByVal p_Versao As Integer)

        If p_CodigoObr = 0 Then
            Clear()
            Exit Sub
        End If

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_OBRASVERSAOANTIGA"
        cmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = p_CodigoObr
        cmd.Parameters.Add("@VERSAO", SqlDbType.Int).Value = p_Versao

        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        'Dim myData As DataSet

        'myData = GetDataSet("SP_SE_OBRASVERSAOANTIGA " & p_CodigoObr & "," & p_Versao)

        'If myData.Tables(0).Rows.Count <= 0 Then
        '    Throw New ArgumentException("O cadastro indicado não existe!")
        'Else
        '    Inflate(myData.Tables(0).Rows(0))
        'End If
        'myData.Dispose()

    End Sub

    Public Sub InserirEmpresa(ByVal vIDEmpresa As Integer)
        ExecuteNonQuery("SP_IN_EMPRESA_OBRA " & m_intCodigo & ", " & vIDEmpresa)
    End Sub

    Public Sub New()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Clear()
    End Sub

    Private Sub Clear()
        m_intCodigo = 0
        m_strCodigoAntigo = ""
        m_varAtualizacao = ""
        m_varPublicacao = ""
        m_dblNrDaRevisao = 0
        m_intIdPesquisador = 0
        m_strProjeto = ""
        m_varValor = 0
        m_dblAreaConstruida = 0
        m_shrNrdeFuncionarios = 0
        m_strCapacidadeDeProducao = ""
        m_strProdutoFinal = ""
        m_strMateriaPrima = ""
        m_strFantasia = ""
        m_strRazaoSocial = ""
        m_strEndereco = ""
        m_strComplemento = ""
        m_strCEP = ""
        m_strCidade = ""
        m_intEstado = 0
        m_varInicio = ""
        m_varTermino = ""
        m_varEstagioAtual = 0
        m_intIDFase = 0
        m_varTipo = ""
        m_strDecricaoProjeto = ""
        m_dtmDataCadastro = ""
        m_Vendedor = 0

        m_obr_EstagioDetalhes_chr = ""
        m_obr_DescResidEdificio_chr = ""
        m_obr_DescResidResidenciais_chr = ""
        m_obr_DescResidCondominios_chr = ""
        m_obr_DescResidPavimentos_chr = ""
        m_obr_DescResidApartamentos_chr = ""
        m_obr_DescResidDormitorios_chr = ""
        m_obr_DescResidSuite_chr = ""
        m_obr_DescResidBanheiro_chr = ""
        m_obr_DescResidLavabo_chr = ""
        m_obr_DescResidSala_chr = ""
        m_obr_DescResidCopa_chr = ""
        m_obr_DescResidATV_chr = ""
        m_obr_DescResidDepEmpreg_chr = ""
        m_obr_DescResidOutros_chr = ""
        m_obr_DescInfoAdicTotalUnicades_chr = ""
        m_obr_DescInfoAdicAreaUtil_chr = ""
        m_obr_DescInfoAdicAreaTerreno_chr = ""
        m_obr_DescInfoAdicElevador_chr = ""
        m_obr_DescInfoAdicVagas_chr = ""
        m_obr_DescInfoAdicCobert_chr = ""
        m_obr_DescInfoAdicArCondic_chr = ""
        m_obr_DescInfoAdicAquecimento_chr = ""
        m_obr_DescInfoAdicFundacoes_chr = ""
        m_obr_DescInfoAdicEstrutura_chr = ""
        m_obr_DescInfoAdicAcabamento_chr = ""
        m_obr_DescInfoAdicFachada_chr = ""
        m_obr_Foto_chr = ""
        m_obr_Mapa_chr = ""
        m_obr_IdTipoCotacao_int = 0
        m_obr_ValorDolar_chr = ""
        m_obr_OutrosAreaLazer_chr = ""

    End Sub

    Public Function List(ByVal p_CodigoITC As String, ByVal p_RazaoSocial As String, ByVal p_DataInicio As String, ByVal p_DataFim As String) As DataSet
        Try
            '**************************************************************
            'verificando parametros passados para repassar para a procedure
            '**************************************************************
            If p_CodigoITC.Trim = "" Then
                p_CodigoITC = "NULL"
            Else
                p_CodigoITC = "'" & p_CodigoITC & "'"
            End If
            If p_RazaoSocial.Trim = "" Then
                p_RazaoSocial = "NULL"
            Else
                p_RazaoSocial = "'" & p_RazaoSocial & "'"
            End If
            If Not IsDate(p_DataInicio) Then
                p_DataInicio = "NULL"
            Else
                p_DataInicio = "'" & CDate(p_DataInicio).ToString("yyyy-MM-dd") & "'"
            End If
            If Not IsDate(p_DataFim) Then
                p_DataFim = "NULL"
            Else
                p_DataFim = "'" & CDate(p_DataFim).ToString("yyyy-MM-dd") & "'"
            End If
            '**************************************************************
            List = GetDataSet("SP_SE_OBRAS 0, " & p_CodigoITC & "," & p_RazaoSocial & "," & p_DataInicio & "," & p_DataFim)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListInicial(ByVal p_CodigoITC As String, ByVal p_RazaoSocial As String, ByVal p_DataInicio As String, ByVal p_DataFim As String, ByVal Ordem As Ordenacao, ByVal Status As Integer) As DataSet
        Try
            '**************************************************************
            'verificando parametros passados para repassar para a procedure
            '**************************************************************
            If p_CodigoITC.Trim = "" Then
                p_CodigoITC = "NULL"
            Else
                p_CodigoITC = "'" & p_CodigoITC & "'"
            End If
            If p_RazaoSocial.Trim = "" Then
                p_RazaoSocial = "NULL"
            Else
                p_RazaoSocial = "'" & p_RazaoSocial & "'"
            End If
            If Not IsDate(p_DataInicio) Then
                p_DataInicio = "NULL"
            Else
                p_DataInicio = "'" & CDate(p_DataInicio).ToString("yyyy-MM-dd") & "'"
            End If
            If Not IsDate(p_DataFim) Then
                p_DataFim = "NULL"
            Else
                p_DataFim = "'" & CDate(p_DataFim).ToString("yyyy-MM-dd") & "'"
            End If
            '**************************************************************
            ListInicial = GetDataSet("SP_SE_OBRAS_LISTA 0, " & p_CodigoITC & "," & p_RazaoSocial & "," & p_DataInicio & "," & p_DataFim & ", " & Ordem & "," & Status)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListEmpresas(ByVal IdObra As Integer) As DataSet
        Try
            ListEmpresas = GetDataSet("SP_SE_OBRAS_EMPRESAS " & IdObra)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    'Public Function ListVendedores(ByVal IdObra As Integer) As DataSet
    '    Try
    '        ListVendedores = GetDataSet("SP_SE_LISTARUSUARIOS" & IdObra)
    '    Catch e As Exception
    '        ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
    '    End Try
    'End Function

    Public Function ListContatos(ByVal IdObra As Integer) As DataSet
        Try
            ListContatos = GetDataSet("SP_SE_CONTATOSOBRAS 0, " & IdObra)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Sub Apagar()
        Dim sql As String
        sql = "SP_DE_OBRAS " & m_intCodigo
        ExecuteNonQuery(sql)
    End Sub

    Public Function ListVersoes(ByVal IdObra As Integer) As DataSet
        Try
            ListVersoes = GetDataSet("SP_LS_CONTROLEVERSOES " & IdObra)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function


End Class