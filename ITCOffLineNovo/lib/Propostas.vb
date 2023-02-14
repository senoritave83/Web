Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ITCOffLine

Public Class clsProposta

    Inherits DataClass
#Region "Declarations"
    Protected m_intIdProposta As Integer
    Protected m_intIdVendedor As Integer
    Protected m_intIdAssociado As Integer
    Protected m_strDataProposta As Object
    Protected m_strDataPropostaForm As Object
    Protected m_indIdStatus As Byte
    Protected m_indIdTipoProposta As Byte
    Protected m_strRazaoSocial As String
    Protected m_strEndereco As String
    Protected m_strComplemento As String
    Protected m_strCEP As String
    Protected m_strCidade As String
    Protected m_intIdEstado As Integer
    Protected m_strDDDTel As String
    Protected m_strTelefone As String
    Protected m_strDDDFax As String
    Protected m_strFax As String
    Protected m_strCNPJ As String
    Protected m_strWebSite As String
    Protected m_strEmailPrincipal As String
    Protected m_strContatoCad As String
    Protected m_strDDDTelContato As String
    Protected m_strTelefoneContato As String
    Protected m_strDDDFaxContato As String
    Protected m_strFaxContato As String
    Protected m_strCelularContato As String
    Protected m_strEmailContato As String
    Protected m_strUf As String
    Protected m_strVendedor As String
    Protected m_strEmailVendedor As String
    Protected m_intNumeroPedido As Integer
    Protected m_strValidadeProp As String
    Protected m_strObservacoes As String
    Protected m_booRenovacao As Byte
    Private m_MensagemErro As String
    Protected m_intIdPosicao As Integer
    Protected m_intIdPropostaPai As Integer
    Protected m_strTelefones As String
    'Protected m_strTelefone2 As String
    'Protected m_strCelular As String
#End Region


#Region "Properties"

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
    Public Property EmailVendedor() As String
        Get
            Return m_strEmailVendedor
        End Get
        Set(ByVal Value As String)
            m_strEmailVendedor = Value
        End Set
    End Property


    Public Property IdAssociado() As Integer
        Get
            Return m_intIdAssociado
        End Get
        Set(ByVal Value As Integer)
            m_intIdAssociado = Value
        End Set
    End Property

    Public Property DataProposta() As String
        Get
            Return m_strDataProposta
        End Get
        Set(ByVal Value As String)
            m_strDataProposta = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Property DataPropostaForm() As String
        Get
            Return m_strDataPropostaForm
        End Get
        Set(ByVal Value As String)
            m_strDataPropostaForm = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Property IdStatus() As Byte
        Get
            Return m_indIdStatus
        End Get
        Set(ByVal Value As Byte)
            m_indIdStatus = Value
        End Set
    End Property

    Public Property IdTipoProposta() As Byte
        Get
            Return m_indIdTipoProposta
        End Get
        Set(ByVal Value As Byte)
            m_indIdTipoProposta = Value
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

    Public Property IdEstado() As Integer
        Get
            Return m_intIdEstado
        End Get
        Set(ByVal Value As Integer)
            m_intIdEstado = Value
        End Set
    End Property

    Public Property DDDTel() As String
        Get
            Return m_strDDDTel
        End Get
        Set(ByVal Value As String)
            m_strDDDTel = Value
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

    Public Property DDDFax() As String
        Get
            Return m_strDDDFax
        End Get
        Set(ByVal Value As String)
            m_strDDDFax = Value
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

    Public Property CNPJ() As String
        Get
            Return m_strCNPJ
        End Get
        Set(ByVal Value As String)
            m_strCNPJ = Value
        End Set
    End Property

    Public Property WebSite() As String
        Get
            Return m_strWebSite
        End Get
        Set(ByVal Value As String)
            m_strWebSite = Value
        End Set
    End Property

    Public Property EmailPrincipal() As String
        Get
            Return m_strEmailPrincipal
        End Get
        Set(ByVal Value As String)
            m_strEmailPrincipal = Value
        End Set
    End Property

    Public Property ContatoCad() As String
        Get
            Return m_strContatoCad
        End Get
        Set(ByVal Value As String)
            m_strContatoCad = Value
        End Set
    End Property

    Public Property DDDTelContato() As String
        Get
            Return m_strDDDTelContato
        End Get
        Set(ByVal Value As String)
            m_strDDDTelContato = Value
        End Set
    End Property

    Public Property TelefoneContato() As String
        Get
            Return m_strTelefoneContato
        End Get
        Set(ByVal Value As String)
            m_strTelefoneContato = Value
        End Set
    End Property

    Public Property DDDFaxContato() As String
        Get
            Return m_strDDDFaxContato
        End Get
        Set(ByVal Value As String)
            m_strDDDFaxContato = Value
        End Set
    End Property

    Public Property FaxContato() As String
        Get
            Return m_strFaxContato
        End Get
        Set(ByVal Value As String)
            m_strFaxContato = Value
        End Set
    End Property

    Public Property CelularContato() As String
        Get
            Return m_strCelularContato
        End Get
        Set(ByVal Value As String)
            m_strCelularContato = Value
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

    Public Property IdProposta() As Integer

        Get
            Return m_intIdProposta
        End Get
        Set(ByVal Value As Integer)
            m_intIdProposta = Value
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

    Public Property NumeroPedido() As Integer
        Get
            Return m_intNumeroPedido
        End Get
        Set(ByVal Value As Integer)
            m_intNumeroPedido = Value
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

    Public Property ValidadeProposta() As String
        Get
            Return m_strValidadeProp
        End Get
        Set(ByVal Value As String)
            m_strValidadeProp = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable Property Renovacao() As Byte
        Get
            Return m_booRenovacao
        End Get
        Set(ByVal Value As Byte)
            m_booRenovacao = Value
        End Set
    End Property

    Public Property IdPosicao() As Byte
        Get
            Return m_intIdPosicao
        End Get
        Set(ByVal Value As Byte)
            m_intIdPosicao = Value
        End Set
    End Property

    Public Property IdPropostaPai() As Integer

        Get
            Return m_intIdPropostaPai
        End Get
        Set(ByVal Value As Integer)
            m_intIdPropostaPai = Value
        End Set
    End Property


    Public Property TelefonesVendedor() As String
        Get
            Return m_strTelefones
        End Get
        Set(ByVal Value As String)
            m_strTelefones = Value
        End Set
    End Property

    'Public Property TelefoneVendedor2() As String
    '    Get
    '        Return m_strTelefone2
    '    End Get
    '    Set(ByVal Value As String)
    '        m_strTelefone2 = Value
    '    End Set
    'End Property

    'Public Property CelularVendedor() As String
    '    Get
    '        Return m_strCelular
    '    End Get
    '    Set(ByVal Value As String)
    '        m_strCelular = Value
    '    End Set
    'End Property


#End Region

#Region "Metodos"

    ''' <summary>
    ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
    ''' </summary>
    ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIdProposta = dr.GetInt32(dr.GetOrdinal("IdProposta"))
        If dr.IsDBNull(dr.GetOrdinal("IdVendedor")) Then
            m_intIdVendedor = 0
        Else
            m_intIdVendedor = dr.GetInt32(dr.GetOrdinal("IdVendedor"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then
            m_strVendedor = ""
        Else
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("EmailVendedor")) Then
            m_strEmailVendedor = ""
        Else
            m_strEmailVendedor = dr.GetString(dr.GetOrdinal("EmailVendedor"))
        End If
        m_intIdAssociado = dr.GetInt32(dr.GetOrdinal("IdAssociado"))
        If dr.IsDBNull(dr.GetOrdinal("DataProposta")) Then
            m_strDataProposta = ""
        Else
            m_strDataProposta = dr.GetString(dr.GetOrdinal("DataProposta"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("DataPropostaForm")) Then
            m_strDataPropostaForm = ""
        Else
            m_strDataPropostaForm = dr.GetString(dr.GetOrdinal("DataPropostaForm"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
            m_indIdStatus = 0
        Else
            m_indIdStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("IdTipoProposta")) Then
            m_indIdTipoProposta = 0
        Else
            m_indIdTipoProposta = dr.GetByte(dr.GetOrdinal("IdTipoProposta"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("RazaoSocial")) Then
            m_strRazaoSocial = ""
        Else
            m_strRazaoSocial = dr.GetString(dr.GetOrdinal("RazaoSocial"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
            m_strEndereco = ""
        Else
            m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Complemento")) Then
            m_strComplemento = ""
        Else
            m_strComplemento = dr.GetString(dr.GetOrdinal("Complemento"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("CEP")) Then
            m_strCEP = ""
        Else
            m_strCEP = dr.GetString(dr.GetOrdinal("CEP"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Cidade")) Then
            m_strCidade = ""
        Else
            m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("IdEstado")) Then
            m_intIdEstado = 0
        Else
            m_intIdEstado = dr.GetInt32(dr.GetOrdinal("IdEstado"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("DDDTel")) Then
            m_strDDDTel = ""
        Else
            m_strDDDTel = dr.GetString(dr.GetOrdinal("DDDTel"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
            m_strTelefone = ""
        Else
            m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("DDDFax")) Then
            m_strDDDFax = ""
        Else
            m_strDDDFax = dr.GetString(dr.GetOrdinal("DDDFax"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Fax")) Then
            m_strFax = ""
        Else
            m_strFax = dr.GetString(dr.GetOrdinal("Fax"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("CNPJ")) Then
            m_strCNPJ = ""
        Else
            m_strCNPJ = dr.GetString(dr.GetOrdinal("CNPJ"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("WebSite")) Then
            m_strWebSite = ""
        Else
            m_strWebSite = dr.GetString(dr.GetOrdinal("WebSite"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("EmailPrincipal")) Then
            m_strEmailPrincipal = ""
        Else
            m_strEmailPrincipal = dr.GetString(dr.GetOrdinal("EmailPrincipal"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
            m_strContatoCad = ""
        Else
            m_strContatoCad = dr.GetString(dr.GetOrdinal("Contato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("DDDTelContato")) Then
            m_strDDDTelContato = ""
        Else
            m_strDDDTelContato = dr.GetString(dr.GetOrdinal("DDDTelContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("TelefoneContato")) Then
            m_strTelefoneContato = ""
        Else
            m_strTelefoneContato = dr.GetString(dr.GetOrdinal("TelefoneContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("DDDFaxContato")) Then
            m_strDDDFaxContato = ""
        Else
            m_strDDDFaxContato = dr.GetString(dr.GetOrdinal("DDDFaxContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("FaxContato")) Then
            m_strFaxContato = ""
        Else
            m_strFaxContato = dr.GetString(dr.GetOrdinal("FaxContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("CelularContato")) Then
            m_strCelularContato = ""
        Else
            m_strCelularContato = dr.GetString(dr.GetOrdinal("CelularContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("EmailContato")) Then
            m_strEmailContato = ""
        Else
            m_strEmailContato = dr.GetString(dr.GetOrdinal("EmailContato"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("NumeroPedido")) Then
            m_intNumeroPedido = 0
        Else
            m_intNumeroPedido = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Observacoes")) Then
            m_strObservacoes = ""
        Else
            m_strObservacoes = dr.GetString(dr.GetOrdinal("Observacoes"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("ValidadeProposta")) Then
            m_strValidadeProp = ""
        Else
            m_strValidadeProp = dr.GetString(dr.GetOrdinal("ValidadeProposta"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Renovacao")) Then
            m_booRenovacao = False
        Else
            m_booRenovacao = dr.GetByte(dr.GetOrdinal("Renovacao"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("IdPosicao")) Then
            m_intIdPosicao = 0
        Else
            m_intIdPosicao = dr.GetInt32(dr.GetOrdinal("IdPosicao"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("IdPropostaPai")) Then
            m_intIdPropostaPai = 0
        Else
            m_intIdPropostaPai = dr.GetInt32(dr.GetOrdinal("IdPropostaPai"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("TelefonesVendedor")) Then
            m_strTelefones = ""
        Else
            m_strTelefones = dr.GetString(dr.GetOrdinal("TelefonesVendedor"))
        End If
        'If dr.IsDBNull(dr.GetOrdinal("TelefoneVendedor2")) Then
        '    m_strTelefone2 = ""
        'Else
        '    m_strTelefone2 = dr.GetString(dr.GetOrdinal("TelefoneVendedor2"))
        'End If
        'If dr.IsDBNull(dr.GetOrdinal("CelularVendedor")) Then
        '    m_strCelular = ""
        'Else
        '    m_strCelular = dr.GetString(dr.GetOrdinal("CelularVendedor"))
        'End If
    End Sub

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()

        Dim cmd As New SqlCommand

        cmd.CommandText = "SP_SV_PROPOSTA"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = m_intIdProposta
        cmd.Parameters.Add("@IDASSOCIADO", SqlDbType.Int).Value = m_intIdAssociado
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_intIdVendedor
        If m_strDataProposta <> "" Then
            cmd.Parameters.Add("@DATAPROPOSTA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataProposta)
        End If
        cmd.Parameters.Add("@IDSTATUS", SqlDbType.TinyInt).Value = m_indIdStatus
        cmd.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar, 255).Value = m_strRazaoSocial
        cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 255).Value = m_strEndereco
        cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar, 255).Value = m_strComplemento
        cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 10).Value = m_strCEP
        cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 50).Value = m_strCidade
        cmd.Parameters.Add("@IDESTADO", SqlDbType.Int).Value = m_intIdEstado
        cmd.Parameters.Add("@DDDTEL", SqlDbType.VarChar, 5).Value = m_strDDDTel
        cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).Value = m_strTelefone
        cmd.Parameters.Add("@DDDFAX", SqlDbType.VarChar, 5).Value = m_strDDDFax
        cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 20).Value = m_strFax
        cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 18).Value = m_strCNPJ
        cmd.Parameters.Add("@WEBSITE", SqlDbType.VarChar, 200).Value = m_strWebSite
        cmd.Parameters.Add("@EMAILPRINCIPAL", SqlDbType.VarChar, 100).Value = m_strEmailPrincipal
        cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 100).Value = m_strContatoCad
        cmd.Parameters.Add("@DDDTELCONTATO", SqlDbType.VarChar, 5).Value = m_strDDDTelContato
        cmd.Parameters.Add("@TELEFONECONTATO", SqlDbType.VarChar, 20).Value = m_strTelefoneContato
        cmd.Parameters.Add("@DDDFAXCONTATO", SqlDbType.VarChar, 5).Value = m_strDDDFaxContato
        cmd.Parameters.Add("@FAXCONTATO", SqlDbType.VarChar, 20).Value = m_strFaxContato
        cmd.Parameters.Add("@CELULARCONTATO", SqlDbType.VarChar, 20).Value = m_strCelularContato
        cmd.Parameters.Add("@EMAILCONTATO", SqlDbType.VarChar, 100).Value = m_strEmailContato
        If m_strValidadeProp <> "" Then
            cmd.Parameters.Add("@VALIDADEPROPOSTA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strValidadeProp)
        End If
        cmd.Parameters.Add("@OBSERVACOES", SqlDbType.VarChar, 1000).Value = m_strObservacoes
        cmd.Parameters.Add("@TIPOPROPOSTA", SqlDbType.TinyInt).Value = m_indIdTipoProposta
        cmd.Parameters.Add("@IDPOSICAO", SqlDbType.TinyInt).Value = m_intIdPosicao
        'cmd.Parameters.Add("@RENOVACAO", SqlDbType.Bit).Value = m_booRenovacao
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


    ''' <summary>
    ''' 	Função que grava os dados do registro atual para uma proposta em renovação
    ''' </summary>
    Public Sub RenovarProposta(ByVal v_IdProposta As Integer)

        Dim cmd As New SqlCommand

        cmd.CommandText = "SP_SV_PROPOSTARENOVACAO"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = v_IdProposta

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


    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIdProposta">Chave primaria IdProposta</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIdProposta As Integer) As Boolean
        If vIdProposta = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_PROPOSTA"
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = vIdProposta
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
    End Function

    ''' <summary>
    ''' 	Função interna que limpa as variaveis internas
    ''' </summary>
    Protected Sub Clear()
        m_intIdProposta = 0
        m_intIdVendedor = 0
        m_strVendedor = ""
        m_strEmailVendedor = ""
        m_intIdAssociado = 0
        m_strDataProposta = ""
        m_strDataPropostaForm = ""
        m_indIdStatus = 0
        m_indIdTipoProposta = 0
        m_intIdPosicao = 0
        m_strRazaoSocial = ""
        m_strEndereco = ""
        m_strComplemento = ""
        m_strCEP = ""
        m_strCidade = ""
        m_intIdEstado = 0
        m_strDDDTel = ""
        m_strTelefone = ""
        m_strDDDFax = ""
        m_strFax = ""
        m_strCNPJ = ""
        m_strWebSite = ""
        m_strEmailPrincipal = ""
        m_strContatoCad = ""
        m_strDDDTelContato = ""
        m_strTelefoneContato = ""
        m_strDDDFaxContato = ""
        m_strFaxContato = ""
        m_strCelularContato = ""
        m_strEmailContato = ""
        m_intNumeroPedido = 0
        m_strObservacoes = ""
        m_strValidadeProp = ""
        m_intIdPropostaPai = 0
        m_strTelefones = ""
        'm_strTelefone2 = ""
        'm_strCelular = ""
    End Sub



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Function Delete() As Boolean

        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SP_DE_PROPOSTA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = m_intIdProposta

            ExecuteNonQuery(cmd)

        Catch ex As Exception
            Return False
        End Try

        Clear()

        Return True
    End Function

    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar() As SqlDataReader

        Dim cmd As New SqlCommand
        cmd.CommandText = "SP_LS_PROPOSTAS"
        cmd.CommandType = CommandType.StoredProcedure
        Return ExecuteReader(cmd)

    End Function

    ''' <summary>
    ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ''' </summary>
    ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ''' <param name="vIdProposta">Filtro</param>
    ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ''' <param name="vPage">Número da página a exibir</param>	
    ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ''' <returns>PaginateResult</returns>
    Public Function Listar(ByVal vFilter As String, ByVal vIdProposta As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As SqlDataReader

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_NV_PROPOSTAS"
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = vIdProposta
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecuteReader(cmd)

    End Function


    ''' <summary>
    ''' 	Função que retorna um DataSet com filtragem e ordenação
    ''' </summary>
    ''' <param name="p_NumPedido">Filtra a pesquisa pelo Número do Pedido</param>
    ''' <param name="p_RazaoSocial">Filtra a pesquisa pela Razão Social do Associado</param>
    ''' <param name="p_CNPJ">Filtra a pesquisa pelo CNPJ do Associado</param>
    ''' <param name="p_Registros">Quantidade de resgistro que serão mostrados por vez</param>
    ''' <returns>DataSet</returns>
    Public Function ListaProposta(ByVal p_NumProposta As Integer, ByVal p_RazaoSocial As String, ByVal p_CNPJ As String, ByVal p_Registros As Integer) As DataSet
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

            Return GetDataSet("SP_LS_PROPOSTAS " & p_NumProposta & ", " & p_RazaoSocial & "," & p_CNPJ & "," & p_Registros, m_MensagemErro)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        Finally

        End Try
    End Function

    ''' <summary>
    ''' 	Rotina que apaga os Contatos/Usuários do Associado no registro (Pedido) atual
    ''' </summary>
    ''' <param name="p_IdContato">Filtra a pesquisa pelo Número do Pedido</param>
    Public Function DeleteItemContato(ByVal p_IdContato As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_CONTATOITEMPROPOSTA " & p_IdContato)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 	Rotina que verifica se existe uma proposta para o associado selecionado
    ''' </summary>
    ''' <param name="IdAssociado">Chave primária do Associado que será usada para buscar a proposta</param>
    Public Function VerificaPropostaExistente(ByVal IdAssociado As Integer) As String

        Try

            Dim sql As String
            sql = "SP_BS_EXISTEPROPOSTA " & IdAssociado
            Dim ds As DataSet
            ds = GetDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                VerificaPropostaExistente = ds.Tables(0).Rows(0).Item(0)
            Else
                VerificaPropostaExistente = ""
            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function

#End Region


End Class
