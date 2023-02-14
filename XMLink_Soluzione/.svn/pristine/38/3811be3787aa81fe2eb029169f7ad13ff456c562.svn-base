'************************************************************
'Autor: Marcelo R
'Data: 30/11/2010
'************************************************************
Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsVisita

    Inherits clsBaseClass

    Private m_varIDVisitaCliente As String 'Primary Key
    Private m_intIDVendedor As Integer
    Private m_strVendedor As String 'Referencia
    Private m_intIDCliente As Integer
    Private m_strCliente As String 'Referencia
    Private m_varDataVisita As String
    Private m_varDataInicio As String
    Private m_varDataTermino As String
    Private m_decLatitudeInicio As Decimal
    Private m_decLongitudeInicio As Decimal
    Private m_decLatitudeFinal As Decimal
    Private m_decLongitudeFinal As Decimal
    Private m_intAvulso As Integer
    Private m_intIDJustificativa As Integer

    Public Property IDVisitaCliente() As String
        Get
            Return m_varIDVisitaCliente
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

    Public Property DataVisita() As String
        Get
            Return m_varDataVisita
        End Get
        Set(ByVal Value As String)
            m_varDataVisita = Value
        End Set
    End Property

    Public Property DataInicio() As String
        Get
            Return m_varDataInicio
        End Get
        Set(ByVal Value As String)
            m_varDataInicio = Value
        End Set
    End Property

    Public Property DataTermino() As String
        Get
            Return m_varDataTermino
        End Get
        Set(ByVal Value As String)
            m_varDataTermino = Value
        End Set
    End Property

    Public Property IDJustificativa() As Integer
        Get
            Return m_intIDJustificativa
        End Get
        Set(ByVal Value As Integer)
            m_intIDJustificativa = Value
        End Set
    End Property


    Public ReadOnly Property LatitudeInicio() As Decimal
        Get
            Return m_decLatitudeInicio
        End Get
    End Property

    Public ReadOnly Property LongitudeInicio() As Decimal
        Get
            Return m_decLongitudeInicio
        End Get
    End Property


    Public ReadOnly Property LatitudeFinal() As Decimal
        Get
            Return m_decLatitudeFinal
        End Get
    End Property

    Public ReadOnly Property LongitudeFinal() As Decimal
        Get
            Return m_decLongitudeFinal
        End Get
    End Property


    Private Sub Inflate(ByVal row As DataRow)

        Me.m_varIDVisitaCliente = CStr(row("vcl_VisitaCliente_int_PK") & "")
        Me.m_intIDVendedor = CLng(0 & row("ven_Vendedor_int_FK"))
        Me.m_strVendedor = CStr(row("ven_vendedor_chr") & "")
        Me.m_intIDCliente = CLng(0 & row("cli_Cliente_int_FK"))
        Me.m_strCliente = CStr(row("cli_cliente_chr") & "")
        Me.m_varDataVisita = CStr(row("vcl_DataVisita_dtm") & "")
        Me.m_varDataInicio = CStr(row("vcl_Inicio_dtm") & "")
        Me.m_varDataTermino = CStr(row("vcl_Termino_dtm") & "")
        Me.m_intIDJustificativa = CLng(0 & row("jus_Justificativa_int_FK"))

        If IsDBNull(row("vcl_LATITUDEINICIO_NUM")) Then
            Me.m_decLatitudeInicio = 0
        Else
            Me.m_decLatitudeInicio = CDec(row("vcl_LATITUDEINICIO_NUM"))
        End If
        If IsDBNull(row("vcl_LONGITUDEINICIO_NUM")) Then
            Me.m_decLongitudeInicio = 0
        Else
            Me.m_decLongitudeInicio = CDec(row("vcl_LONGITUDEINICIO_NUM"))
        End If

        If IsDBNull(row("vcl_LATITUDETERMINO_NUM")) Then
            Me.m_decLatitudeFinal = 0
        Else
            Me.m_decLatitudeFinal = CDec(row("vcl_LATITUDETERMINO_NUM"))
        End If
        If IsDBNull(row("vcl_LONGITUDETERMINO_NUM")) Then
            Me.m_decLongitudeFinal = 0
        Else
            Me.m_decLongitudeFinal = CDec(row("vcl_LONGITUDETERMINO_NUM"))
        End If

    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String

        strDeflate &= m_varIDVisitaCliente & ","
        strDeflate &= m_intIDVendedor & ","
        strDeflate &= m_intIDCliente & ","
        strDeflate &= m_varDataVisita & ","
        strDeflate &= m_intIDJustificativa & ","

        strDeflate &= m_varDataInicio & ","
        strDeflate &= m_varDataTermino & ","
        strDeflate &= m_decLatitudeInicio & ","
        strDeflate &= m_decLongitudeInicio & ","
        strDeflate &= m_decLatitudeFinal & ","
        strDeflate &= m_decLongitudeFinal & ","
        strDeflate &= m_intAvulso

        Return strDeflate

    End Function

    Public Sub Update()
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Dim sql As String
        sql = PREFIXO & "SV_VISITA" & XMPage.IDEmpresa & ", " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Load(ByVal p_varIDVisitaCliente As String)
        If p_varIDVisitaCliente = "" Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_VISITA " & XMPage.IDEmpresa & ", '" & p_varIDVisitaCliente & "'")
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
        ExecuteNonQuery(PREFIXO & "DE_VISITA " & XMPage.IDEmpresa & ", '" & m_varIDVisitaCliente & "'")
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        Clear()
    End Sub

    Public Sub Delete(ByVal p_varIDVisitaCliente As String)
        ExecuteNonQuery(PREFIXO & "DE_VISITA " & XMPage.IDEmpresa & ", '" & p_varIDVisitaCliente & "'")
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        If m_varIDVisitaCliente = p_varIDVisitaCliente Then Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Private Sub Clear()

        m_varIDVisitaCliente = 0
        m_intIDVendedor = 0
        m_strVendedor = ""
        m_intIDCliente = 0
        m_strCliente = ""
        m_varDataVisita = ""
        m_varDataInicio = ""
        m_varDataTermino = ""
        m_decLatitudeInicio = 0
        m_decLongitudeInicio = 0
        m_decLatitudeFinal = 0
        m_decLongitudeFinal = 0
        m_intAvulso = 0
        m_intIDJustificativa = 0

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
            List = GetDataSet(PREFIXO & "LS_VISITA " & XMPage.IDEmpresa & ", '" & vCliente.Replace("'", "''") & "', '" & vVendedor.Replace("'", "''") & "', " & vIDStatus & ", " & vIDGrupo & ", " & vDataInicio & ", " & vDataFim & ",'" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize & ", " & XMPage.Usuario.IDUsuario)
        Catch e As System.Exception
            XMPage.LogError(e, "clsVisita")
        End Try
    End Function

    Public Function ListFotos(ByVal vIdVisita As Integer) As DataSet
        Try
            Return GetDataSet(PREFIXO & "LS_VISITAFOTOS " & XMPage.IDEmpresa & "," & vIdVisita)
        Catch e As System.Exception
            XMPage.LogError(e, "clsVisita")
        End Try
    End Function

End Class