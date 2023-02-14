'************************************************************
'Classe gerada por XM Class Creator - 21/1/2003 18:05:33
'************************************************************

Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog

Public Class clsPedido

    Inherits clsBaseClass

    Private m_varIDPedido As String 'Primary Key
    Private m_intIDVendedor As Integer
    Private m_strVendedor As String 'Referencia
    Private m_intIDCliente As Integer
    Private m_strCliente As String 'Referencia
    Private m_varCodigo As String
    Private m_varDataEmissao As String
    Private m_intIDCondicao As Integer
    Private m_strCondicao As String 'Referencia
    Private m_varDataEntrega As String
    Private m_intIdStatusPedido As Integer
    Private m_varStatusPedido As String
    Private m_sngDesconto As Single
    Private m_varTransportadora As String
    Private m_intIDFormaPagamento As Integer
    Private m_strFormaPagamento As String 'Referencia
    Private m_varDataSync As String
    Private m_intNumeroPedido As Integer
    Private m_decTotal As Decimal
    Private m_decSubTotal As Decimal
    Private m_decDescontos As Decimal
    Private m_decLatitude As Decimal
    Private m_decLongitude As Decimal
    Private m_strObservacao As String
    Private m_strCampanha As String
    Private m_strCampanhaSeq As String

    Public Enum _StatusPedido
        EmEdição = 0
        Aprovado = 1
        Reprovado = 2
        EmTransito = 3
        Apagado = 4
        EmEmpera = 5
    End Enum

    Public Property IDPedido() As String
        Get
            Return m_varIDPedido
        End Get
        Set(ByVal Value As String)
            Load(Value)
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

    Public ReadOnly Property Vendedor() As String
        Get
            Return m_strVendedor
        End Get
    End Property

    Public Property IDCliente() As Integer
        Get
            Return m_intIDCliente
        End Get
        Set(ByVal Value As Integer)
            m_intIDCliente = Value
        End Set
    End Property

    Public ReadOnly Property Cliente() As String
        Get
            Return m_strCliente
        End Get
    End Property

    Public Property Codigo() As String
        Get
            Return m_varCodigo
        End Get
        Set(ByVal Value As String)
            m_varCodigo = Value
        End Set
    End Property

    Public Property DataEmissao() As String
        Get
            Return m_varDataEmissao
        End Get
        Set(ByVal Value As String)
            m_varDataEmissao = Value
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

    Public Property Campanha() As String
        Get
            Return m_strCampanha
        End Get
        Set(ByVal Value As String)
            m_strCampanha = Value
        End Set
    End Property

    Public Property CampanhaSeq() As String
        Get
            Return m_strCampanhaSeq
        End Get
        Set(ByVal Value As String)
            m_strCampanhaSeq = Value
        End Set
    End Property

    Public Property IDCondicao() As Integer
        Get
            Return m_intIDCondicao
        End Get
        Set(ByVal Value As Integer)
            m_intIDCondicao = Value
        End Set
    End Property

    Public ReadOnly Property Condicao() As String
        Get
            Return m_strCondicao
        End Get
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Return m_decTotal
        End Get
    End Property

    Public ReadOnly Property SubTotal() As Decimal
        Get
            Return m_decSubTotal
        End Get
    End Property

    Public ReadOnly Property Descontos() As Decimal
        Get
            Return m_decDescontos
        End Get
    End Property

    Public Property DataEntrega() As String
        Get
            Return m_varDataEntrega
        End Get
        Set(ByVal Value As String)
            m_varDataEntrega = Value
        End Set
    End Property
    Public Property IdStatusPedido() As Integer
        Get
            Return m_intIdStatusPedido
        End Get
        Set(ByVal Value As Integer)
            m_intIdStatusPedido = Value
        End Set
    End Property

    Public ReadOnly Property StatusPedido() As String
        Get
            Return m_varStatusPedido
        End Get
    End Property

    Public ReadOnly Property Latitude() As Decimal
        Get
            Return m_decLatitude
        End Get
    End Property

    Public ReadOnly Property Longitude() As Decimal
        Get
            Return m_decLongitude
        End Get
    End Property

    Public ReadOnly Property Desconto() As Single
        Get
            If m_decSubTotal <> 0 Then
                Return m_decDescontos / m_decSubTotal
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property Transportadora() As String
        Get
            Return m_varTransportadora
        End Get
        Set(ByVal Value As String)
            m_varTransportadora = Value
        End Set
    End Property

    Public Property IDFormaPagamento() As Integer
        Get
            Return m_intIDFormaPagamento
        End Get
        Set(ByVal Value As Integer)
            m_intIDFormaPagamento = Value
        End Set
    End Property

    Public ReadOnly Property FormaPagamento() As String
        Get
            Return m_strFormaPagamento
        End Get
    End Property

    Public Property DataSync() As String
        Get
            Return m_varDataSync
        End Get
        Set(ByVal Value As String)
            m_varDataSync = Value
        End Set
    End Property

    Public ReadOnly Property NumeroPedido()
        Get
            Return m_intNumeroPedido
        End Get
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_varIDPedido = CStr(row("ped_Pedido_int_PK") & "")
        Me.m_intIDVendedor = CLng(0 & row("ven_Vendedor_int_FK"))
        Me.m_strVendedor = CStr(row("ven_vendedor_chr") & "")
        Me.m_intIDCliente = CLng(0 & row("cli_Cliente_int_FK"))
        Me.m_strCliente = CStr(row("cli_cliente_chr") & "")
        Me.m_varCodigo = CStr(row("ped_Codigo_chr") & "")
        Me.m_varDataEmissao = CStr(row("ped_DataEmissao_dtm") & "")
        Me.m_intIDCondicao = CLng(0 & row("con_Condicao_int_FK"))
        Me.m_strCondicao = CStr(row("con_condicao_chr") & "")
        Me.m_varDataEntrega = CStr(row("ped_DataEntrega_dtm") & "")
        Me.m_intIdStatusPedido = CLng(0 & row("sta_StatusPedido_ind"))
        Me.m_varStatusPedido = CStr(row("sta_StatusPedido_chr") & "")
        Me.m_sngDesconto = CSng(row("ped_Desconto_num"))
        Me.m_varTransportadora = CStr(row("ped_Transportadora_chr") & "")
        Me.m_intIDFormaPagamento = CLng(0 & row("frm_FormaPagamento_int_FK"))
        Me.m_strFormaPagamento = CStr(row("frm_FormaPagamento_chr") & "")
        Me.m_varDataSync = CStr(row("ped_DataSync_dtm") & "")
        Me.m_intNumeroPedido = CInt(0 & row("PED_NUMEROPEDIDO_INT"))
        Me.m_decSubTotal = CDec(row("PED_SUBTOTAL_CUR"))
        Me.m_decDescontos = CDec(row("PED_DESCONTOS_CUR"))
        Me.m_decTotal = CDec(row("PED_TOTAL_CUR"))
        Me.m_strObservacao = row("ped_Observacao_chr") & ""
        Me.m_strCampanha = (row("ped_Campanha_chr") & "").ToString().Replace("|||", "<BR>")
        Me.m_strCampanhaSeq = row("ped_CampanhaSeq_chr") & ""
        If IsDBNull(row("PED_LATITUDE_NUM")) Then
            Me.m_decLatitude = 0
        Else
            Me.m_decLatitude = CDec(row("PED_LATITUDE_NUM"))
        End If
        If IsDBNull(row("PED_LONGITUDE_NUM")) Then
            Me.m_decLongitude = 0
        Else
            Me.m_decLongitude = CDec(row("PED_LONGITUDE_NUM"))
        End If

    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_varIDPedido & ","
        strDeflate &= m_intIDVendedor & ","
        strDeflate &= m_intIDCliente & ","
        strDeflate &= m_varCodigo & ","
        strDeflate &= m_varDataEmissao & ","
        strDeflate &= m_intIDCondicao & ","
        strDeflate &= m_varDataEntrega & ","
        strDeflate &= m_intIdStatusPedido & ","
        strDeflate &= m_sngDesconto & ","
        strDeflate &= m_varTransportadora & ","
        strDeflate &= m_intIDFormaPagamento & ", "
        strDeflate &= "'" & m_strObservacao.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCampanha.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCampanhaSeq.Replace("'", "''") & "'"
        Deflate = strDeflate
    End Function

    Public Sub Update()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Dim sql As String
        sql = PREFIXO & "SV_PEDIDO " & XMPage.IDEmpresa & ", " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Load(ByVal p_varIDPedido As String)
        If p_varIDPedido = "" Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_PEDIDO " & XMPage.IDEmpresa & ", '" & p_varIDPedido & "'")
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_PEDIDO " & XMPage.IDEmpresa & ", '" & m_varIDPedido & "'")
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Clear()
    End Sub

    Public Sub Delete(ByVal p_varIDPedido As String)
        ExecuteNonQuery(PREFIXO & "DE_PEDIDO " & XMPage.IDEmpresa & ", '" & p_varIDPedido & "'")
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        If m_varIDPedido = p_varIDPedido Then Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Private Sub Clear()
        m_varIDPedido = ""
        m_intIDVendedor = 0
        m_strVendedor = ""
        m_intIDCliente = 0
        m_strCliente = ""
        m_varCodigo = ""
        m_varDataEmissao = ""
        m_intIDCondicao = 0
        m_strCondicao = ""
        m_varDataEntrega = ""
        m_varStatusPedido = 0
        m_sngDesconto = 0
        m_varTransportadora = ""
        m_intIDFormaPagamento = 0
        m_strFormaPagamento = ""
        m_varDataSync = ""
        m_decLatitude = 0
        m_decLongitude = 0
        m_intNumeroPedido = 0
        m_strObservacao = ""
        m_strCampanha = ""
        m_strCampanhaSeq = ""
    End Sub


    Public Function List(ByVal vCliente As String, ByVal vVendedor As String, ByVal vIDStatus As Integer, ByVal vIDGrupo As Integer, ByVal vDataInicio As String, ByVal vDataFim As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Try
            If Not IsDate(vDataInicio) Then
                vDataInicio = "NULL"
            Else
                vDataInicio = "'" & CDate(vDataInicio).ToString("yyyy-MM-dd") & "'"
            End If
            If Not IsDate(vDataFim) Then
                vDataFim = "NULL"
            Else
                vDataFim = "'" & CDate(vDataFim).ToString("yyyy-MM-dd") & "'"
            End If
            List = GetDataSet(PREFIXO & "LS_PEDIDO " & XMPage.IDEmpresa & ", '" & vCliente.Replace("'", "''") & "', '" & vVendedor.Replace("'", "''") & "', " & vIDStatus & ", " & vIDGrupo & ", " & vDataInicio & ", " & vDataFim & ",'" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize & ", " & XMPage.Usuario.IDUsuario)
        Catch e As System.Exception
            XMPage.LogError(e, "clsPedido")
        End Try
    End Function

    Public Function ListResumo() As DataSet
        Try
            Return GetDataSet(PREFIXO & "LS_PEDIDO_RESUMO " & XMPage.IDEmpresa)
        Catch e As System.Exception
            XMPage.LogError(e, "clsPedido")
        End Try
    End Function


    Public Function EnviarAlerta(ByVal p_NumeroNextel As String, ByVal p_Subject As String, ByVal p_Mensagem As String)
        'Nada
    End Function

    Public Function AprovaPedido() As Boolean
        ExecuteNonQuery(PREFIXO & "BS_APROVAPEDIDO " & XMPage.IDEmpresa & ", '" & m_varIDPedido & "', " & XMPage.Usuario.IDUsuario)
        Return True
    End Function

    Public Function ReprovaPedido(ByVal vMotivo As String) As Boolean
        ExecuteNonQuery(PREFIXO & "BS_REPROVARPEDIDO " & XMPage.IDEmpresa & ", '" & m_varIDPedido & "', '" & vMotivo.Replace("'", "''") & "', " & XMPage.Usuario.IDUsuario)
        Return True
    End Function

    Public Function ListItensPedido() As DataSet
        Try
            ListItensPedido = GetDataSet(PREFIXO & "LS_ITENSPEDIDO " & XMPage.IDEmpresa & ", '" & m_varIDPedido & "'")
        Catch e As System.Exception
            XMPage.LogError(e, "clsPedido")
        End Try
    End Function

    Public Function ListMotivos() As DataSet
        Try
            ListMotivos = GetDataSet(PREFIXO & "SE_HISTORICO " & XMPage.IDEmpresa & ", '" & m_varIDPedido & "'")
        Catch e As System.Exception
            XMPage.LogError(e, "clsPedido")
        End Try
    End Function

End Class