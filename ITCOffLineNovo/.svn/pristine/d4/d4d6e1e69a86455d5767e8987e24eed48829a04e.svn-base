'************************************************************
'Classe gerada por XM Class Creator - 23/1/2003 16:59:11
'************************************************************

Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsContatoAssociados

    Inherits DataClass

    Private m_intIdContato As Integer
    Private m_intIdAssociado As Integer
    Private m_strNomeContato As String
    Private m_intIdCargo As Integer
    Private m_intIdFuncao As Integer
    Private m_strDDD As String
    Private m_strTelefone As String
    Private m_strDDDFax As String
    Private m_strFax As String
    Private m_strEMail As String
    Private m_strDDDCelular As String
    Private m_strCelular As String
    Private m_strSkype As String

    Public Property IdContato() As Integer
        Get
            Return m_intIdContato
        End Get
        Set(ByVal Value As Integer)
            Load(Value)
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

    Public Property NomeContato() As String
        Get
            Return m_strNomeContato
        End Get
        Set(ByVal Value As String)
            m_strNomeContato = Value
        End Set
    End Property

    Public Property IdCargo() As Integer
        Get
            Return m_intIdCargo
        End Get
        Set(ByVal Value As Integer)
            m_intIdCargo = Value
        End Set
    End Property

    Public Property IdFuncao() As Integer
        Get
            Return m_intIdFuncao
        End Get
        Set(ByVal Value As Integer)
            m_intIdFuncao = Value
        End Set
    End Property

    Public Property DDD() As String
        Get
            Return m_strDDD
        End Get
        Set(ByVal Value As String)
            m_strDDD = Value
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

    Public Property DDDCelular() As String
        Get
            Return m_strDDDCelular
        End Get
        Set(ByVal Value As String)
            m_strDDDCelular = Value
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


    Public Property EMail() As String
        Get
            Return m_strEMail
        End Get
        Set(ByVal Value As String)
            m_strEMail = Value
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

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIdContato = CLng(0 & row("IdContato"))
        Me.m_intIdAssociado = CLng(0 & row("IdAssociado"))
        Me.m_strNomeContato = CStr(row("NomeContato") & "")
        Me.m_intIdCargo = CLng(0 & row("IdCargo"))
        Me.m_intIdFuncao = CLng(0 & row("Idfuncao"))
        Me.m_strDDD = CStr(row("DDD") & "")
        Me.m_strTelefone = CStr(row("Telefone") & "")
        Me.m_strDDDFax = CStr(row("DDDFax") & "")
        Me.m_strFax = CStr(row("Fax") & "")
        Me.m_strEMail = CStr(row("EMail") & "")
        Me.m_strDDDCelular = CStr(row("DDDCelular") & "")
        Me.m_strCelular = CStr(row("Celular") & "")
        Me.m_strSkype = CStr(row("Skype") & "")
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIdContato & "" & ","
        strDeflate &= "" & m_intIdAssociado & "" & ","
        strDeflate &= "'" & m_strNomeContato & "'" & ","
        strDeflate &= "" & m_intIdCargo & "" & ","
        strDeflate &= "'" & m_strDDD & "'" & ","
        strDeflate &= "'" & m_strTelefone & "'" & ","
        strDeflate &= "'" & m_strDDDFax & "'" & ","
        strDeflate &= "'" & m_strFax & "'" & ","
        strDeflate &= "'" & m_strEMail & "',"
        strDeflate &= "'" & m_strDDDCelular & "'" & ","
        strDeflate &= "'" & m_strCelular & "',"
        strDeflate &= "" & m_intIdFuncao & "" & ","
        strDeflate &= "'" & m_strSkype & "'"
        Deflate = strDeflate
    End Function
    Private m_MensagemErro As String = ""
    Public ReadOnly Property MensagemErro()
        Get
            Return m_MensagemErro
        End Get
    End Property
    Public Sub Update()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Dim sql As String
        sql = "SP_SV_CONTATOASSOCIADOS " & Deflate()
        Dim myData As DataSet
        m_MensagemErro = ""
        myData = GetDataSet(sql, m_MensagemErro)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub Apagar(ByVal IdAssociado As Integer, ByVal IdUsuario As Integer)
        Try
            Dim sql As String
            sql = "SP_DE_CONTATOASSOCIADO " & IdAssociado & "," & IdUsuario
            ExecuteNonQuery(sql)

        Catch e As Exception

        End Try

    End Sub

    Protected Sub Load(ByVal vData As Integer)
        If vData = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_CONTATOSASSOCIADOS " & vData)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
    End Sub

    Public Sub Delete(ByVal vData)
        ExecuteNonQuery("SP_DE_ContatoAssociados " & vData)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Public Sub New()
        Clear()
    End Sub

    Private Sub Clear()
        m_intIdContato = 0
        m_intIdAssociado = 0
        m_strNomeContato = ""
        m_intIdCargo = 0
        m_strDDD = ""
        m_strTelefone = ""
        m_strDDDFax = ""
        m_strFax = ""
        m_strDDDCelular = ""
        m_strCelular = ""
        m_strEMail = ""
        m_intIdFuncao = 0
        m_strSkype = ""
    End Sub

    Public Function List(ByVal vIDAssociado As Integer) As DataSet
        Try
            List = GetDataSet("SP_SE_CONTATOSASSOCIADOS 0, " & vIDAssociado)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListContatosPedido(ByVal vIDPedido As Integer) As DataSet
        Try
            ListContatosPedido = GetDataSet("SP_SE_CONTATOSASSOCIADOSPEDIDO 0, " & vIDPedido)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListContatosProposta(ByVal vIDProposta As Integer) As DataSet
        Try
            ListContatosProposta = GetDataSet("SP_SE_CONTATOSASSOCIADOSPROPOSTA 0, " & vIDProposta)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Sub UpdateContatoPedido(ByVal vIDPedido As Integer, ByVal vIDContato As Integer, ByVal vIDUsuario As Integer)

        Load(vIDContato)
        Dim sql As String
        sql = "SP_SV_PEDIDOCONTATO " & Me.IdContato & "," & vIDPedido & ",'" & Me.NomeContato & "'," & Me.IdCargo & ",'" & Me.DDD & "','" & Me.Telefone & "','" & Me.EMail & "','" & Me.DDDCelular & "','" & Me.Celular & "'," & vIDUsuario & ",'" & Me.Skype & "'"
        Dim myData As DataSet
        m_MensagemErro = ""
        myData = GetDataSet(sql, m_MensagemErro)
        myData.Dispose()
    End Sub

    Public Sub UpdateContatoProposta(ByVal vIDProposta As Integer, ByVal vIDContato As Integer)

        Load(vIDContato)
        Dim sql As String
        sql = "SP_SV_CONTATOASSOCIADOSPROPOSTA " & Me.IdContato & "," & vIDProposta & ",'" & Me.NomeContato & "'," & Me.IdCargo & ",'" & Me.DDD & "','" & Me.Telefone & "','" & Me.EMail & "','" & Me.DDDCelular & "','" & Me.Celular & "'"
        Dim myData As DataSet
        m_MensagemErro = ""
        myData = GetDataSet(sql, m_MensagemErro)
        myData.Dispose()
    End Sub

End Class