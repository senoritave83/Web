Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsPedidos

    Inherits DataClass
#Region "Declarations"
    Private m_intIdAssociado As Integer
    Private m_intCodigoITC As String
    Private m_intIdVendedor As Integer
    Private m_intIdPosicao As Integer
    Private m_intIdRamo As Integer
    Private m_intIdAtividade As Integer
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
    Private m_varWebSite As String
    Private m_varEMail As String
    Private m_dtmDataPedido As Object
    Private m_strObservacoes As String
    Private m_dtmPrimeiroContrato As String
    Private m_MensagemErro As String

    Private m_strTelefone As String
    Private m_strFax As String
    Private m_strContato As String
    Private m_strFone As String
    Private m_strEmailContato As String
    Private m_strCelular As String
    Private m_strTelEntrega As String
    Private m_strFaxEntrega As String
    Private m_strTelCobranca As String
    Private m_strFaxCobranca As String
    Private m_strTelFaturamento As String
    Private m_strFaxFaturamento As String
    Private m_intIdPlano As Integer
    Private m_dtmDataInicio As Object
    Private m_dtmDataTermino As Object
    Private m_dcmValor As Double
    Private m_strCondPagto As String
    Private m_dtmPrimeiroVencto As Object
    Private m_dcmPedidoRS As Double
    Private m_strVendedor As String
    Private m_intIdPedido As Integer

    Private m_strRamo As String
    Private m_strAtividade As String
    Private m_strUfEntrega As String
    Private m_strUfCobranca As String
    Private m_strUfFaturamento As String
    Private m_strPosicao As String
    Private m_strPlanoEspecifico As String
    Private m_intIdTipoPedido As String
    Private m_strProdutos As String
    Private m_intNumeroPedido As Integer
    Private m_intIdStatus As Integer

#End Region

#Region "Properties"
    Public Property Codigo() As Integer
        Get
            Return m_intIdAssociado
        End Get
        Set(ByVal Value As Integer)
            m_intIdAssociado = Value
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

    Public Property IdVendedor() As Integer
        Get
            Return m_intIdVendedor
        End Get
        Set(ByVal Value As Integer)
            m_intIdVendedor = Value
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

    Public Property Estado() As Integer
        Get
            Return m_varEstado
        End Get
        Set(ByVal Value As Integer)
            m_varEstado = Value
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

    Public Property PrimeiroContrato() As String
        Get
            Return m_dtmPrimeiroContrato
        End Get
        Set(ByVal Value As String)
            m_dtmPrimeiroContrato = Value
        End Set
    End Property

    Public Property DataPedido() As Object
        Get
            Return IIf(IsDate(m_dtmDataPedido), Right("00" & Day(m_dtmDataPedido), 2) & "/" & Right("00" & Month(m_dtmDataPedido), 2) & "/" & Right("0000" & Year(m_dtmDataPedido), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataPedido = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataPedido = Nothing
            End If
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

    Public Property Fax() As String
        Get
            Return m_strFax
        End Get
        Set(ByVal Value As String)
            m_strFax = Value
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

    Public Property Fone() As String
        Get
            Return m_strFone
        End Get
        Set(ByVal Value As String)
            m_strFone = Value
        End Set
    End Property

    Public Property EmailContato() As String
        Get
            Return m_strEmailContato
        End Get
        Set(ByVal Value As String)
            m_strEmailContato = Value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return m_strCelular
        End Get
        Set(ByVal Value As String)
            m_strCelular = Value
        End Set
    End Property

    Public Property TelefoneEntrega() As String
        Get
            Return m_strTelEntrega
        End Get
        Set(ByVal Value As String)
            m_strTelEntrega = Value
        End Set
    End Property

    Public Property FaxEntrega() As String
        Get
            Return m_strFaxEntrega
        End Get
        Set(ByVal Value As String)
            m_strFaxEntrega = Value
        End Set
    End Property

    Public Property TelefoneCobranca() As String
        Get
            Return m_strTelCobranca
        End Get
        Set(ByVal Value As String)
            m_strTelCobranca = Value
        End Set
    End Property

    Public Property FaxCobranca() As String
        Get
            Return m_strFaxCobranca
        End Get
        Set(ByVal Value As String)
            m_strFaxCobranca = Value
        End Set
    End Property

    Public Property TelefoneFaturamento() As String
        Get
            Return m_strTelFaturamento
        End Get
        Set(ByVal Value As String)
            m_strTelFaturamento = Value
        End Set
    End Property

    Public Property FaxFaturamento() As String
        Get
            Return m_strFaxFaturamento
        End Get
        Set(ByVal Value As String)
            m_strFaxFaturamento = Value
        End Set
    End Property

    Public Property IdPlano() As Integer
        Get
            Return m_intIdPlano
        End Get
        Set(ByVal Value As Integer)
            m_intIdPlano = Value
        End Set
    End Property

    Public Property DataInicio() As Object
        Get
            Return IIf(IsDate(m_dtmDataInicio), Right("00" & Day(m_dtmDataInicio), 2) & "/" & Right("00" & Month(m_dtmDataInicio), 2) & "/" & Right("0000" & Year(m_dtmDataInicio), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataInicio = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataInicio = Nothing
            End If
        End Set
    End Property

    Public Property DataTermino() As Object
        Get
            Return IIf(IsDate(m_dtmDataTermino), Right("00" & Day(m_dtmDataTermino), 2) & "/" & Right("00" & Month(m_dtmDataTermino), 2) & "/" & Right("0000" & Year(m_dtmDataTermino), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmDataTermino = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmDataTermino = Nothing
            End If
        End Set
    End Property

    Public Property PrimeiroVencimento() As Object
        Get
            Return IIf(IsDate(m_dtmPrimeiroVencto), Right("00" & Day(m_dtmPrimeiroVencto), 2) & "/" & Right("00" & Month(m_dtmPrimeiroVencto), 2) & "/" & Right("0000" & Year(m_dtmPrimeiroVencto), 4), "")
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                m_dtmPrimeiroVencto = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                m_dtmPrimeiroVencto = Nothing
            End If
        End Set
    End Property

    Public Property Valor() As Double
        Get
            Return m_dcmValor
        End Get
        Set(ByVal Value As Double)
            m_dcmValor = Value
        End Set
    End Property

    Public Property CondicaoPagamento() As String
        Get
            Return m_strCondPagto
        End Get
        Set(ByVal Value As String)
            m_strCondPagto = Value
        End Set
    End Property

    Public Property PedidoRS() As Double
        Get
            Return m_dcmPedidoRS
        End Get
        Set(ByVal Value As Double)
            m_dcmPedidoRS = Value
        End Set
    End Property

    Public Property IdPedido() As Integer
        Get
            Return m_intIdPedido
        End Get
        Set(ByVal Value As Integer)
            m_intIdPedido = Value
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

    Public Property Ramo() As String
        Get
            Return m_strRamo
        End Get
        Set(ByVal Value As String)
            m_strRamo = Value
        End Set
    End Property

    Public Property Atividade() As String
        Get
            Return m_strAtividade
        End Get
        Set(ByVal Value As String)
            m_strAtividade = Value
        End Set
    End Property

    Public Property UFCobranca() As String
        Get
            Return m_strUfCobranca
        End Get
        Set(ByVal Value As String)
            m_strUfCobranca = Value
        End Set
    End Property

    Public Property UFEntrega() As String
        Get
            Return m_strUfEntrega
        End Get
        Set(ByVal Value As String)
            m_strUfEntrega = Value
        End Set
    End Property

    Public Property UFFaturamento() As String
        Get
            Return m_strUfFaturamento
        End Get
        Set(ByVal Value As String)
            m_strUfFaturamento = Value
        End Set
    End Property

    Public Property Posicao() As String
        Get
            Return m_strPosicao
        End Get
        Set(ByVal Value As String)
            m_strPosicao = Value
        End Set
    End Property

    Public Property PlanoEspecifico() As String
        Get
            Return m_strPlanoEspecifico
        End Get
        Set(ByVal Value As String)
            m_strPlanoEspecifico = Value
        End Set
    End Property

    Public Property IdTipoPedido() As String
        Get
            Return m_intIdTipoPedido
        End Get
        Set(ByVal Value As String)
            m_intIdTipoPedido = Value
        End Set
    End Property

    Public Property Produtos() As String
        Get
            Return m_strProdutos
        End Get
        Set(ByVal Value As String)
            m_strProdutos = Value
        End Set
    End Property

    Public Property NumeroPedido() As Integer
        Get
            Return m_intNumeroPedido
        End Get
        Set(ByVal Value As Integer)
            m_intNumeroPedido = Value
        End Set
    End Property

    Public ReadOnly Property MensagemErro()
        Get
            Return m_MensagemErro
        End Get
    End Property

    Public Property IdStatus() As Integer
        Get
            Return m_intIdStatus
        End Get
        Set(ByVal Value As Integer)
            m_intIdStatus = Value
        End Set
    End Property
#End Region

#Region "Métodos"
    ''' <summary>
    ''' 	Função privada que carrega nas variaveis internas os valores presentes no DataRow
    ''' </summary>
    ''' <param name="row">objeto DataRow com os valores obtidos do banco de dados</param>
    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIdAssociado = CLng(0 & row("Codigo"))

        Me.m_intCodigoITC = CStr(row("CodigoITC") & "")
        Me.m_intIdVendedor = CLng(0 & row("IdVendedor"))
        Me.m_intIdPosicao = CLng(0 & row("IdPosicao"))
        Me.m_intIdRamo = CLng(0 & row("IdRamo"))
        Me.m_intIdAtividade = CLng(0 & row("IdAtividade"))
        Me.m_varFantasia = CStr(row("Fantasia") & "")
        Me.m_varRazaoSocial = CStr(row("RazaoSocial") & "")

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
        Me.m_varWebSite = CStr(row("WebSite") & "")
        Me.m_varEMail = CStr(row("EMail") & "")
        Me.m_dtmDataPedido = CDate(row("DataPedido"))
        Me.m_strObservacoes = CStr(row("Observacoes") & "")
        Me.m_dtmPrimeiroContrato = CStr(row("PrimeiroContrato") & "")

        Me.m_strTelefone = CStr(row("Telefone") & "")
        Me.m_strFax = CStr(row("Fax") & "")
        Me.m_strContato = CStr(row("Contato") & "")
        Me.m_strFone = CStr(row("Fone") & "")
        Me.m_strEmailContato = CStr(row("EmailContato") & "")
        Me.m_strCelular = CStr(row("Celular") & "")
        Me.m_strTelEntrega = CStr(row("TelefoneEntrega") & "")
        Me.m_strFaxEntrega = CStr(row("FaxEntrega") & "")
        Me.m_strTelCobranca = CStr(row("TelefoneCobranca") & "")
        Me.m_strFaxCobranca = CStr(row("FaxCobranca") & "")
        Me.m_strTelFaturamento = CStr(row("TelefoneFaturamento") & "")
        Me.m_strFaxFaturamento = CStr(row("FaxFaturamento") & "")
        'Me.m_strCondPagto = CStr(row("CondicaoPagto") & "")
        Me.m_strVendedor = CStr(row("Vendedor") & "")
        Me.m_intIdPedido = CLng(0 & row("IdPedido"))
        Me.m_dcmPedidoRS = CDec(0 & row("PedidoRS"))
        Me.m_intIdTipoPedido = CInt(row("IdTipoPedido"))
        Me.m_strProdutos = CStr(row("Produto") & "")
        Me.m_intNumeroPedido = CInt(row("NumeroPedido"))

        '***********************************************************
        'CAMPOS USADOS NO FORMULARIO DE PEDIDOS P/ IMPRESSÃO.
        '***********************************************************
        Me.m_strRamo = CStr(row("Ramo") & "")
        Me.m_strAtividade = CStr(row("Atividade") & "")
        Me.m_strUfEntrega = CStr(row("UfEntrega") & "")
        Me.m_strUfCobranca = CStr(row("UfCobranca") & "")
        Me.m_strUfFaturamento = CStr(row("UfFaturamento") & "")
        Me.m_strPosicao = CStr(row("Posicao") & "")
        Me.m_intIdStatus = CInt(row("IdStatus") & "")

        '***********************************************************
        'CHECAGENS DE DATA PARA NÃO DAR INVALID USE OF NULL
        '***********************************************************
        If IsDate(row("PrimeiroVencto")) Then
            Me.m_dtmPrimeiroVencto = FormatDateTime(CDate(row("PrimeiroVencto")), DateFormat.ShortDate)
        Else
            Me.m_dtmPrimeiroVencto = ""
        End If
        '***********************************************************
        'FIM CHECAGENS DE DATA PARA NÃO DAR INVALID USE OF NULL
        '***********************************************************
    End Sub

    ''' <summary>
    ''' 	Função privada que carrega a variavel strDeflate com os valores obtidos do formulário para gravação no banco de dados
    ''' </summary>
    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIdAssociado & "" & ","
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
        strDeflate &= "'" & Replace(m_varWebSite, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_varEMail, "'", "''") & "',"

        strDeflate &= Me.m_intIdPosicao & ","
        strDeflate &= Me.m_intIdAtividade & ","
        strDeflate &= Me.m_intIdVendedor & ","
        strDeflate &= "'" & Me.m_intCodigoITC & "',"
        strDeflate &= "'" & Replace(Me.m_strObservacoes, "'", "''") & "',"
        strDeflate &= Me.m_intIdRamo & ","
        strDeflate &= "'" & Replace(m_dtmPrimeiroContrato, "'", "''") & "',"

        strDeflate &= "'" & Replace(m_strTelefone, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strFax, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strContato, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strFone, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strEmailContato, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strCelular, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strTelEntrega, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strFaxEntrega, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strTelCobranca, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strFaxCobranca, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strTelFaturamento, "'", "''") & "',"
        strDeflate &= "'" & Replace(m_strFaxFaturamento, "'", "''") & "',"
        strDeflate &= "'" & Me.m_dtmPrimeiroVencto & "',"
        strDeflate &= Replace(Me.m_dcmPedidoRS, ",", ".") & ","
        strDeflate &= Me.m_intIdPedido & ","
        strDeflate &= Me.m_intIdTipoPedido & ","
        strDeflate &= "'" & Replace(Me.m_strProdutos, "'", "''") & "',"
        strDeflate &= Me.m_intNumeroPedido & ","
        strDeflate &= Me.m_intIdStatus
        Deflate = strDeflate
    End Function

    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Function Delete(ByVal p_IdPedido As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PEDIDOS " & p_IdPedido)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update(ByVal p_IdUsuario As Integer)

        Try
            Dim sql As String
            m_MensagemErro = ""
            sql = "SP_SV_PEDIDOS " & Deflate() & "," & p_IdUsuario
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

    ''' <summary>
    ''' 	Construtor padrão da classe Pedidos
    ''' </summary>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 	Construtor da classe Pedidos, Instância a classe e obtem os dados do registro solicitado
    ''' </summary>
    ''' <param name="p_intCodigo">Chave primaria IDPedido</param>
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
        m_MensagemErro = ""
        Dim myData As DataSet = GetDataSet("SP_SE_PEDIDOS " & p_intCodigo, m_MensagemErro)

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
        m_intIdAssociado = 0
        m_varFantasia = ""
        m_varRazaoSocial = ""
        m_varEndereco = ""
        m_varComplemento = ""
        m_strCEP = ""
        m_varCidade = ""
        m_varEstado = 0
        m_varCNPJ = ""
        m_strInscricaoEstadual = ""
        m_varWebSite = ""
        m_varEMail = ""
        m_strObservacoes = ""
        m_dtmPrimeiroContrato = ""

        m_strTelefone = ""
        m_strFax = ""
        m_strContato = ""
        m_strFone = ""
        m_strEmailContato = ""
        m_strCelular = ""
        m_strTelEntrega = ""
        m_strFaxEntrega = ""
        m_strTelCobranca = ""
        m_strFaxCobranca = ""
        m_strTelFaturamento = ""
        m_strFaxFaturamento = ""
        m_intIdPlano = 0
        m_dtmDataInicio = Nothing
        m_dtmDataTermino = Nothing
        m_dcmValor = 0
        m_strCondPagto = ""
        m_dtmPrimeiroVencto = Nothing
        m_dcmPedidoRS = 0
        m_intIdPedido = 0
        m_intIdTipoPedido = 0

        m_strVendedor = ""
        m_strRamo = ""
        m_strAtividade = ""
        m_strUfCobranca = ""
        m_strUfEntrega = ""
        m_strUfFaturamento = ""
        m_strPosicao = ""
        m_strProdutos = ""
        m_intNumeroPedido = 0
        m_intIdStatus = 0
    End Sub

    ''' <summary>
    ''' 	Função que retorna um DataSet com filtragem
    ''' </summary>
    ''' <param name="p_IDPedido">Filtra a pesquisa pelo ID do Pedido</param>
    ''' <param name="p_RazaoSocial">Filtra a pesquisa pela Razão Social do Associado</param>
    ''' <param name="p_CNPJ">Filtra a pesquisa pelo CNPJ do Associado</param>
    ''' <param name="p_Registros">Quantidade de resgistro que serão mostrados por vez</param>
    ''' <returns>DataSet</returns>
    Public Function List(ByVal p_IDPedido As Integer, ByVal p_RazaoSocial As String, ByVal p_CNPJ As String, ByVal p_Registros As Integer) As DataSet
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

            Return GetDataSet("SP_SE_PEDIDOS " & p_IDPedido & ", " & p_RazaoSocial & "," & p_CNPJ & "," & p_Registros, m_MensagemErro)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        Finally

        End Try
    End Function

    ''' <summary>
    ''' 	Função que retorna um DataSet com filtragem e ordenação
    ''' </summary>
    ''' <param name="p_NumPedido">Filtra a pesquisa pelo Número do Pedido</param>
    ''' <param name="p_RazaoSocial">Filtra a pesquisa pela Razão Social do Associado</param>
    ''' <param name="p_CNPJ">Filtra a pesquisa pelo CNPJ do Associado</param>
    ''' <param name="p_Registros">Quantidade de resgistro que serão mostrados por vez</param>
    ''' <returns>DataSet</returns>
    Public Function ListaPedido(ByVal p_NumPedido As Integer, ByVal p_RazaoSocial As String, ByVal p_CNPJ As String, ByVal p_Registros As Integer) As DataSet
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

            Return GetDataSet("SP_LS_PEDIDOS " & p_NumPedido & ", " & p_RazaoSocial & "," & p_CNPJ & "," & p_Registros, m_MensagemErro)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        Finally

        End Try
    End Function

    Public Function ListLog(ByVal p_IdPedido As Integer) As DataSet
        Try
            m_MensagemErro = ""
            Return GetDataSet("SP_LS_LOGPEDIDOS " & p_IdPedido, m_MensagemErro)

        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    ''' <summary>
    ''' 	Rotina que apaga os Contatos/Usuários do Associado no registro (Pedido) atual
    ''' </summary>
    ''' <param name="p_IdContato">Deleta o Contato do Pedido pela chave primária do Contato</param>
    Public Function DeleteItemContato(ByVal p_IdContato As Integer, ByVal p_IdUsuario As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PEDIDOCONTATO " & p_IdContato & "," & p_IdUsuario)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Function GerarPedido(ByVal p_IdProposta As Integer) As Integer

        Dim p_Return As Integer = 0 'RETORNA O NUMERO DO PEDIDO

        Try

            Dim dr As SqlDataReader = ExecuteReader("SP_BS_GERARPEDIDO_PROPOSTA " & p_IdProposta)
            If dr.Read Then
                p_Return = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
            End If
            dr.Close()

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message.Replace("'", "''") & "','" & e.Source & "','ITC-NET'")

        End Try

        Return p_Return

    End Function

#End Region

End Class