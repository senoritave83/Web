'************************************************************
'Classe gerada por XM Class Creator - 15/1/2003 11:47:40
'************************************************************

Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsObras

    Inherits DataClass

    Private m_intCodigo As Integer
    Private m_strCodigoAntigo As String
    Private m_varAtualizacao As Object
    Private m_varPublicacao As Object
    Private m_dblNrDaRevisao As Double
    Private m_intIdPesquisador As Integer
    Private m_strProjeto As String
    Private m_varValor As Object
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
    Private m_varTipo As Object
    Private m_strDecricaoProjeto As Object
    Private m_dtmDataCadastro As Object
    Private m_strInicioTermino As String
    Private m_Demo As Boolean
    Private m_Ativo As Integer
    Private m_varVendedor As String
    'NOVOS CAMPOS
    Private m_IdSubTipo_int As Integer
    Private obr_EstagioDetalhes_chr As String
    Private obr_DescResidEdificio_chr As String
    Private obr_DescResidResidenciais_chr As String
    Private obr_DescResidCondominios_chr As String
    Private obr_DescResidPavimentos_chr As String
    Private obr_DescResidApartamentos_chr As String
    Private obr_DescResidDormitorios_chr As String
    Private obr_DescResidSuite_chr As String
    Private obr_DescResidBanheiro_chr As String
    Private obr_DescResidLavabo_chr As String
    Private obr_DescResidSala_chr As String
    Private obr_DescResidCopa_chr As String
    Private obr_DescResidATV_chr As String
    Private obr_DescResidDepEmpreg_chr As String
    Private obr_DescResidOutros_chr As String
    Private obr_DescInfoAdicTotalUnicades_chr As String
    Private obr_DescInfoAdicAreaUtil_chr As String
    Private obr_DescInfoAdicAreaTerreno_chr As String
    Private obr_DescInfoAdicElevador_chr As String
    Private obr_DescInfoAdicVagas_chr As String
    Private obr_DescInfoAdicCobert_chr As String
    Private obr_DescInfoAdicArCondic_chr As String
    Private obr_DescInfoAdicAquecimento_chr As String
    Private obr_DescInfoAdicFundacoes_chr As String
    Private obr_DescInfoAdicEstrutura_chr As String
    Private obr_DescInfoAdicAcabamento_chr As String
    Private obr_DescInfoAdicFachada_chr As String
    Private obr_Foto_chr As String
    Private obr_Mapa_chr As String
    Private obr_IdSubTipo As Integer
    Private obr_AreaLazer_int As Integer
    Private obr_IdTipoCotacao_int As Integer
    Private obr_ValorDolar_chr As String
    Private obr_OutrosAreaLazer_chr As String

    Private m_VendedorAssociado As ControleVenObraEmp

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

    Public Property EstagioDetalhes() As String
        Get
            Return obr_EstagioDetalhes_chr
        End Get
        Set(ByVal Value As String)
            obr_EstagioDetalhes_chr = Value
        End Set
    End Property

    Public Property ResiEdicifio() As String
        Get
            Return obr_DescResidEdificio_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidEdificio_chr = Value
        End Set
    End Property

    Public Property ResiResidenciais() As String
        Get
            Return obr_DescResidResidenciais_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidResidenciais_chr = Value
        End Set
    End Property

    Public Property ResiCondominios() As String
        Get
            Return obr_DescResidCondominios_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidCondominios_chr = Value
        End Set
    End Property

    Public Property ResiPavimentos() As String
        Get
            Return obr_DescResidPavimentos_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidPavimentos_chr = Value
        End Set
    End Property

    Public Property ResiApartamentos() As String
        Get
            Return obr_DescResidApartamentos_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidApartamentos_chr = Value
        End Set
    End Property

    Public Property ResiDormitorios() As String
        Get
            Return obr_DescResidDormitorios_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidDormitorios_chr = Value
        End Set
    End Property

    Public Property ResiSuite() As String
        Get
            Return obr_DescResidSuite_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidSuite_chr = Value
        End Set
    End Property

    Public Property ResiBanheiro() As String
        Get
            Return obr_DescResidBanheiro_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidBanheiro_chr = Value
        End Set
    End Property
    Public Property ResiLavabo() As String
        Get
            Return obr_DescResidLavabo_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidLavabo_chr = Value
        End Set
    End Property
    Public Property ResiDepEmp() As String
        Get
            Return obr_DescResidDepEmpreg_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidDepEmpreg_chr = Value
        End Set
    End Property

    Public Property ResiCopa() As String
        Get
            Return obr_DescResidCopa_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidCopa_chr = Value
        End Set
    End Property

    Public Property ResiAtv() As String
        Get
            Return obr_DescResidATV_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidATV_chr = Value
        End Set
    End Property

    Public Property ResiSala() As String
        Get
            Return obr_DescResidSala_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidSala_chr = Value
        End Set
    End Property

    Public Property ResidOutros() As String
        Get
            Return obr_DescResidOutros_chr
        End Get
        Set(ByVal Value As String)
            obr_DescResidOutros_chr = Value
        End Set
    End Property

    Public Property AreaUtil() As String
        Get
            Return obr_DescInfoAdicAreaUtil_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicAreaUtil_chr = Value
        End Set
    End Property

    Public Property TotalUnidades() As String
        Get
            Return obr_DescInfoAdicTotalUnicades_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicTotalUnicades_chr = Value
        End Set
    End Property

    Public Property AreaTerreno() As String
        Get
            Return obr_DescInfoAdicAreaTerreno_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicAreaTerreno_chr = Value
        End Set
    End Property

    Public Property Elevador() As String
        Get
            Return obr_DescInfoAdicElevador_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicElevador_chr = Value
        End Set
    End Property

    Public Property Vagas() As String
        Get
            Return obr_DescInfoAdicVagas_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicVagas_chr = Value
        End Set
    End Property

    Public Property Coberturas() As String
        Get
            Return obr_DescInfoAdicCobert_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicCobert_chr = Value
        End Set
    End Property

    Public Property ArCondicionado() As String
        Get
            Return obr_DescInfoAdicArCondic_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicArCondic_chr = Value
        End Set
    End Property

    Public Property Aquecimento() As String
        Get
            Return obr_DescInfoAdicAquecimento_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicAquecimento_chr = Value
        End Set
    End Property

    Public Property Fundacoes() As String
        Get
            Return obr_DescInfoAdicFundacoes_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicFundacoes_chr = Value
        End Set
    End Property

    Public Property Acabamento() As String
        Get
            Return obr_DescInfoAdicAcabamento_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicAcabamento_chr = Value
        End Set
    End Property

    Public Property Estrutura() As String
        Get
            Return obr_DescInfoAdicEstrutura_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicEstrutura_chr = Value
        End Set
    End Property

    Public Property Foto() As String
        Get
            Return obr_Foto_chr
        End Get
        Set(ByVal Value As String)
            obr_Foto_chr = Value
        End Set
    End Property

    Public Property Mapa() As String
        Get
            Return obr_Mapa_chr
        End Get
        Set(ByVal Value As String)
            obr_Mapa_chr = Value
        End Set
    End Property

    Public Property Fachada() As String
        Get
            Return obr_DescInfoAdicFachada_chr
        End Get
        Set(ByVal Value As String)
            obr_DescInfoAdicFachada_chr = Value
        End Set
    End Property

    Public Property AreaLazer() As Integer
        Get
            Return obr_AreaLazer_int
        End Get
        Set(ByVal Value As Integer)
            obr_AreaLazer_int = Value
        End Set
    End Property

    Public Property IdSubTipo() As Integer
        Get
            Return obr_IdSubTipo
        End Get
        Set(ByVal Value As Integer)
            obr_IdSubTipo = Value
        End Set
    End Property

    Public Property Vendedor() As String
        Get
            Return m_varVendedor
        End Get
        Set(ByVal Value As String)
            m_varVendedor = Value
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

    Public Property Valor() As Object
        Get
            Return m_varValor
        End Get
        Set(ByVal Value As Object)
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

    Public Property InicioTermino() As String
        Get
            Return m_strInicioTermino
        End Get
        Set(ByVal Value As String)
            m_strInicioTermino = Value
        End Set
    End Property

    Public Property IDTipoCotacao() As Integer
        Get
            Return obr_IdTipoCotacao_int
        End Get
        Set(ByVal Value As Integer)
            obr_IdTipoCotacao_int = Value
        End Set
    End Property

    Public Property ValorDolar() As String
        Get
            Return obr_ValorDolar_chr
        End Get
        Set(ByVal Value As String)
            obr_ValorDolar_chr = Value
        End Set
    End Property

    Public Property OutrosAreaLazer() As String
        Get
            Return obr_OutrosAreaLazer_chr
        End Get
        Set(ByVal Value As String)
            obr_OutrosAreaLazer_chr = Value
        End Set
    End Property

    Public ReadOnly Property VendedorAssociado() As ControleVenObraEmp
        Get
            Return m_VendedorAssociado
        End Get
    End Property


    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intCodigo = CLng(0 & row("Codigo"))
        Me.m_strCodigoAntigo = CStr(row("CodigoAntigo") & "")
        Me.m_varPublicacao = CStr(row("Publicacao") & "")
        Me.m_dblNrDaRevisao = CLng(0 & row("NrDaRevisao"))
        Me.m_strProjeto = CStr(row("Projeto") & "")
        If IsNumeric(row("Valor")) Then
            Me.m_varValor = FormatNumber(row("Valor"), 2).ToString.Replace(".", "")
        Else
            Me.m_varValor = ""
        End If
        Me.m_intIdPesquisador = CLng(0 & row("Pesquisador"))
        Me.m_dblAreaConstruida = CStr(row("AreaConstruida") & "")
        Me.m_strCapacidadeDeProducao = CStr(row("CapacidadeDeProducao") & "")
        Me.m_strMateriaPrima = CStr(row("MateriaPrima") & "")
        Me.m_strEndereco = CStr(row("Endereco") & "")
        Me.m_strComplemento = CStr(row("Complemento") & "")
        Me.m_strCEP = CStr(row("CEP") & "")
        Me.m_strCidade = CStr(row("Cidade") & "")
        Me.m_intEstado = CInt(0 & row("IDEstado"))
        Me.m_varInicio = CStr(row("Inicio") & "")
        Me.m_varTermino = CStr(row("Termino") & "")
        Me.m_varEstagioAtual = CInt(0 & row("IdEstagio"))
        Me.m_intIDFase = CInt(0 & row("IDFase"))
        Me.m_varTipo = CStr(row("Tipo") & "")
        Me.m_intIDTipo = CStr(row("IdTipo") & "")
        Me.m_strDecricaoProjeto = CStr(row("DescProj1") & "")
        Me.m_dtmDataCadastro = CStr(row("DataCadastro") & "")
        Me.m_strInicioTermino = CStr(row("InicioTermino") & "")
        Me.m_Demo = IIf(CInt(0 & row("IndDemo")) = 1, True, False)
        Me.m_Ativo = CInt(0 & row("IndStatus"))
        Me.m_varVendedor = CStr(row("Vendedor") & "")

        'NOVOS CAMPOS
        Me.obr_EstagioDetalhes_chr = CStr(row("obr_EstagioDetalhes_chr") & "")
        Me.obr_DescResidEdificio_chr = CStr(row("obr_DescResidEdificio_chr") & "")
        Me.obr_DescResidResidenciais_chr = CStr(row("obr_DescResidResidenciais_chr") & "")
        Me.obr_DescResidCondominios_chr = CStr(row("obr_DescResidCondominios_chr") & "")
        Me.obr_DescResidPavimentos_chr = CStr(row("obr_DescResidPavimentos_chr") & "")
        Me.obr_DescResidApartamentos_chr = CStr(row("obr_DescResidApartamentos_chr") & "")
        Me.obr_DescResidApartamentos_chr = CStr(row("obr_DescResidApartamentos_chr") & "")
        Me.obr_DescResidDormitorios_chr = CStr(row("obr_DescResidDormitorios_chr") & "")
        Me.obr_DescResidSuite_chr = CStr(row("obr_DescResidSuite_chr") & "")
        Me.obr_DescResidBanheiro_chr = CStr(row("obr_DescResidBanheiro_chr") & "")
        Me.obr_DescResidLavabo_chr = CStr(row("obr_DescResidLavabo_chr") & "")
        Me.obr_DescResidSala_chr = CStr(row("obr_DescResidSala_chr") & "")
        Me.obr_DescResidCopa_chr = CStr(row("obr_DescResidCopa_chr") & "")
        Me.obr_DescResidATV_chr = CStr(row("obr_DescResidATV_chr") & "")
        Me.obr_DescResidDepEmpreg_chr = CStr(row("obr_DescResidDepEmpreg_chr") & "")
        Me.obr_DescResidOutros_chr = CStr(row("obr_DescResidOutros_chr") & "")
        Me.obr_DescInfoAdicTotalUnicades_chr = CStr(row("obr_DescInfoAdicTotalUnicades_chr") & "")
        Me.obr_DescInfoAdicAreaUtil_chr = CStr(row("obr_DescInfoAdicAreaUtil_chr") & "")
        Me.obr_DescInfoAdicAreaTerreno_chr = CStr(row("obr_DescInfoAdicAreaTerreno_chr") & "")
        Me.obr_DescInfoAdicElevador_chr = CStr(row("obr_DescInfoAdicElevador_chr") & "")
        Me.obr_DescInfoAdicVagas_chr = CStr(row("obr_DescInfoAdicVagas_chr") & "")
        Me.obr_DescInfoAdicCobert_chr = CStr(row("obr_DescInfoAdicCobert_chr") & "")
        Me.obr_DescInfoAdicArCondic_chr = CStr(row("obr_DescInfoAdicArCondic_chr") & "")
        Me.obr_DescInfoAdicAquecimento_chr = CStr(row("obr_DescInfoAdicAquecimento_chr") & "")
        Me.obr_DescInfoAdicFundacoes_chr = CStr(row("obr_DescInfoAdicFundacoes_chr") & "")
        Me.obr_DescInfoAdicEstrutura_chr = CStr(row("obr_DescInfoAdicEstrutura_chr") & "")
        Me.obr_DescInfoAdicAcabamento_chr = CStr(row("obr_DescInfoAdicAcabamento_chr") & "")
        Me.obr_DescInfoAdicFachada_chr = CStr(row("obr_DescInfoAdicFachada_chr") & "")
        Me.obr_Foto_chr = CStr(row("obr_Foto_chr") & "")
        Me.obr_Mapa_chr = CStr(row("obr_Mapa_chr") & "")
        Me.obr_IdSubTipo = CInt(0 & row("obr_IdSubTipo"))
        Me.obr_AreaLazer_int = CInt(0 & row("obr_AreaLazer_int"))
        Me.obr_IdTipoCotacao_int = CInt(0 & row("obr_IdTipoCotacao_int"))
        Me.obr_ValorDolar_chr = CStr(row("obr_ValorDolar_chr") & "")
        Me.obr_OutrosAreaLazer_chr = CStr(row("obr_OutrosAreaLazer_chr") & "")

        m_VendedorAssociado = New ControleVenObraEmp(m_intCodigo, ITC_Global.TIPO_CADASTRO.OBRA)
    End Sub

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

    Public Sub New(ByVal p_Codigo As Integer)
        If p_Codigo = 0 Then
            Clear()
        Else
            Load(p_Codigo)
        End If
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

        Dim myData As DataSet

        myData = GetDataSet("SP_SE_Obras " & p_Codigo)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Load(ByVal p_CodigoObr As Integer, ByVal p_Versao As Integer)

        If p_CodigoObr = 0 Then
            Clear()
            Exit Sub
        End If

        Dim myData As DataSet

        myData = GetDataSet("SP_SE_ObrasVersaoAntiga " & p_CodigoObr & "," & p_Versao)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

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
        'NOVOS CAMPOS
        obr_EstagioDetalhes_chr = ""
        obr_DescResidEdificio_chr = ""
        obr_DescResidResidenciais_chr = ""
        obr_DescResidCondominios_chr = ""
        obr_DescResidPavimentos_chr = ""
        obr_DescResidApartamentos_chr = ""
        obr_DescResidApartamentos_chr = ""
        obr_DescResidDormitorios_chr = ""
        obr_DescResidSuite_chr = ""
        obr_DescResidBanheiro_chr = ""
        obr_DescResidLavabo_chr = ""
        obr_DescResidSala_chr = ""
        obr_DescResidCopa_chr = ""
        obr_DescResidATV_chr = ""
        obr_DescResidDepEmpreg_chr = ""
        obr_DescResidOutros_chr = ""
        obr_DescInfoAdicTotalUnicades_chr = ""
        obr_DescInfoAdicAreaUtil_chr = ""
        obr_DescInfoAdicAreaTerreno_chr = ""
        obr_DescInfoAdicElevador_chr = ""
        obr_DescInfoAdicVagas_chr = ""
        obr_DescInfoAdicCobert_chr = ""
        obr_DescInfoAdicArCondic_chr = ""
        obr_DescInfoAdicAquecimento_chr = ""
        obr_DescInfoAdicFundacoes_chr = ""
        obr_DescInfoAdicEstrutura_chr = ""
        obr_DescInfoAdicAcabamento_chr = ""
        obr_DescInfoAdicFachada_chr = ""
        obr_Foto_chr = ""
        obr_Mapa_chr = ""
        obr_IdSubTipo = 0
        obr_AreaLazer_int = 0
        obr_IdTipoCotacao_int = 0
        obr_ValorDolar_chr = ""
        obr_OutrosAreaLazer_chr = ""

    End Sub

    Public Function Buscar(ByVal p_NomeObra As String, ByVal p_IdUsuario As Integer) As DataSet
        Try
            Return GetDataSet("SP_BS_BUSCAROBRA '" & p_NomeObra & "'," & p_IdUsuario)

        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

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

    Public Function ListContatos(ByVal IdObra As Integer) As DataSet
        Try
            ListContatos = GetDataSet("SP_SE_CONTATOSOBRAS 0, " & IdObra)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class