Imports System.Diagnostics.EventLog

Public Class FollowUp

    Inherits DataClass

    Private intIdDFollowUp As Integer
    Private intIdAssociado As Integer
    Private intIdUsuario As Integer
    Private intIdEmpresaObra As Integer
    Private m_EmpresaObra As String
    Private indTipo As TIPO_CADASTRO
    Private dtmData As String
    Private dtmDataAgenda As String
    Private strDescricao As String
    Private intPrioridade As Integer
    Private intIdStatusSIG As Integer

    Public Property IdFollowUP() As Integer
        Get
            Return intIdDFollowUp
        End Get
        Set(ByVal Value As Integer)
            intIdDFollowUp = Value
        End Set
    End Property

    Public Property IdAssociado() As Integer
        Get
            Return intIdAssociado
        End Get
        Set(ByVal Value As Integer)
            intIdAssociado = Value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return intIdUsuario
        End Get
        Set(ByVal Value As Integer)
            intIdUsuario = Value
        End Set
    End Property

    Public Property IdEmpresaObra() As Integer
        Get
            Return intIdEmpresaObra
        End Get
        Set(ByVal Value As Integer)
            intIdEmpresaObra = Value
        End Set
    End Property

    Public Property CodigoObra() As Integer
        Get
            Return CodigoObra
        End Get
        Set(ByVal Value As Integer)
            intIdEmpresaObra = Value
        End Set
    End Property

    Public Property Tipo() As TIPO_CADASTRO
        Get
            Return indTipo
        End Get
        Set(ByVal Value As TIPO_CADASTRO)
            indTipo = Value
        End Set
    End Property

    Public Property Data() As Object
        Get
            If IsDate(dtmData) Then
                Return Right("00" & Day(dtmData), 2) & "/" & Right("00" & Month(dtmData), 2) & "/" & Right("0000" & Year(dtmData), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                dtmData = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                dtmData = Nothing
            End If
        End Set
    End Property

    Public Property DataAgenda() As Object
        Get
            If IsDate(dtmDataAgenda) Then
                Return Right("00" & Day(dtmDataAgenda), 2) & "/" & Right("00" & Month(dtmDataAgenda), 2) & "/" & Right("0000" & Year(dtmDataAgenda), 4)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As Object)
            Dim strTemp As Object
            strTemp = Split(Value, "/")
            If UBound(strTemp) > 0 Then
                dtmDataAgenda = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
            Else
                dtmDataAgenda = Nothing
            End If
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return strDescricao
        End Get
        Set(ByVal Value As String)
            strDescricao = Value
        End Set
    End Property

    Public ReadOnly Property EmpresaObra() As String
        Get
            Return m_EmpresaObra
        End Get
    End Property

    Public Property Prioridade() As Integer
        Get
            Return intPrioridade
        End Get
        Set(ByVal Value As Integer)
            intPrioridade = Value
        End Set
    End Property
    Public Property IdStatusSIG() As Integer
        Get
            Return intIdStatusSIG
        End Get
        Set(ByVal Value As Integer)
            intIdStatusSIG = Value
        End Set
    End Property

    Public Sub New()
        Clear()
    End Sub

    Public Sub New(ByVal p_IdFollowUP As Integer, ByVal p_Tipo As TIPO_CADASTRO)
        If p_IdFollowUP > 0 Then
            Load(p_IdFollowUP, p_Tipo)
        End If
    End Sub

    Private Sub Load(ByVal p_IdFollowUP As Integer, ByVal p_Tipo As TIPO_CADASTRO)
        If p_IdFollowUP = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_FOLLOWUP " & p_IdFollowUP & ",0," & p_Tipo)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.intIdDFollowUp = CLng(0 & row("IdFollowUP"))
        Me.intIdAssociado = CInt(row("IdAssociado"))
        Me.intIdUsuario = CLng(0 & row("IdUsuario"))
        Me.intIdEmpresaObra = CLng(0 & row("IdEmpresa_obra"))
        Me.indTipo = CLng(0 & row("IndTipo"))
        Me.dtmData = row("Data")
        Me.dtmDataAgenda = IIf(IsDBNull(row("DataAgenda")), "", row("DataAgenda"))
        Me.strDescricao = CStr(row("Descricao") & "")
        Me.m_EmpresaObra = CStr(row("OBRAEMPRESA") & "")
        Me.intPrioridade = CLng(0 & row("IDPrioridade"))
        Me.intIdStatusSIG = CInt(row("IdStatusSIG"))
    End Sub

    Private Function Deflate() As String

        Dim strDeflate As String

        strDeflate = intIdDFollowUp & ","
        strDeflate &= intIdAssociado & ","
        strDeflate &= intIdUsuario & ","
        strDeflate &= intIdEmpresaObra & ","
        strDeflate &= indTipo & ","
        strDeflate &= "'" & strDescricao & "'"
        strDeflate &= "," & XMCheckDate(dtmDataAgenda, True, True) & ","
        strDeflate &= intPrioridade & ","
        strDeflate &= intIdStatusSIG

        Return strDeflate

    End Function

    Private Sub Clear()
        intIdDFollowUp = 0
        intIdAssociado = 0
        intIdUsuario = 0
        intIdEmpresaObra = 0
        indTipo = 0
        dtmData = ""
        dtmDataAgenda = ""
        strDescricao = ""
        m_EmpresaObra = ""
        intPrioridade = 0
        intIdStatusSIG = 0
    End Sub

    Public Sub Excluir(ByVal p_Itens As String)

        ExecuteNonQuery("SP_DE_FOLLOWUP '" & p_Itens & "'")

    End Sub

    Public Function Update() As Boolean

        Try

            Dim sql As String = ""
            Dim myData As DataSet

            sql = "SP_SV_FOLLOWUP " & Deflate()
            myData = GetDataSet(sql)

            If myData.Tables(0).Rows.Count <= 0 Then
                Throw New ArgumentException("NÃO HOUVE RETORNO DE DADOS!")
                Return False
            Else
                Inflate(myData.Tables(0).Rows(0))
                Return True
            End If
            myData = Nothing

        Catch e As Exception

            Return False

        End Try

    End Function

    Public Function List(ByVal IdUsuario As Integer, _
                         ByVal Tipo As TIPO_CADASTRO, _
                         ByVal IdEmpresaObra As Integer, _
                         ByVal DataAgendamento As String, _
                         ByVal DataInicial As String, _
                         ByVal DataFinal As String, _
                         ByVal Descricao As String) As DataSet
        Try
            Return GetDataSet("SP_LS_FOLLOWUP " & IdUsuario & "," & Tipo & "," & IdEmpresaObra & "," & _
                                XMCheckDate(DataAgendamento, True, True) & "," & _
                                XMCheckDate(DataInicial, True, True) & "," & _
                                XMCheckDate(DataFinal, True, True) & ",'" & _
                                Descricao & "'")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListarOrigensFollowUp(ByVal IdUsuario As Integer, ByVal Tipo As TIPO_CADASTRO, ByVal p_Filtro As String, ByVal IdEmpresa As Integer, ByVal p_Codigo As String) As DataSet

        Dim ds As DataSet

        Try
            If Tipo = TIPO_CADASTRO.ASSOCIADO Then
                ds = GetDataSet("SP_LS_FOLLOWUP_BUSCARASSOCIADOS " & IdUsuario & ",'" & p_Filtro & "','" & p_Codigo & "'")
            ElseIf Tipo = TIPO_CADASTRO.EMPRESA Then
                ds = GetDataSet("SP_LS_FOLLOWUP_BUSCAREMPRESAS " & IdUsuario & ",'" & p_Filtro & "'," & IdEmpresa & ",'" & p_Codigo & "'")
            ElseIf Tipo = TIPO_CADASTRO.OBRA Then
                ds = GetDataSet("SP_LS_FOLLOWUP_BUSCAROBRAS " & IdUsuario & ",'" & p_Filtro & "'," & IdEmpresa & ",'" & p_Codigo & "'")
            End If
        Catch e As Exception
            ds = Nothing
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try

        Return ds

    End Function

    Public Function ChecaPermissao(ByVal IdUsuario As Integer, ByVal Tipo As TIPO_CADASTRO, ByVal IdEmpresa As Integer, ByVal p_Codigo As String) As Boolean

        Dim ds As DataSet

        If Tipo = TIPO_CADASTRO.ASSOCIADO Then
            ds = GetDataSet("SP_SE_FOLLOWUP_CHECARPERMISSAO_ASS " & IdUsuario & "," & IdEmpresa & "," & p_Codigo & "")
        ElseIf Tipo = TIPO_CADASTRO.EMPRESA Then
            ds = GetDataSet("SP_SE_FOLLOWUP_CHECARPERMISSAO_EMP " & IdUsuario & "," & IdEmpresa & "," & p_Codigo & "")
        ElseIf Tipo = TIPO_CADASTRO.OBRA Then
            ds = GetDataSet("SP_SE_FOLLOWUP_CHECARPERMISSAO_OBR " & IdUsuario & "," & IdEmpresa & "," & p_Codigo & "")
        End If

        If ds.Tables(0).Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function relAssociados(ByVal p_IdEmpresa As Integer, ByVal p_IdUsuario As Integer, ByVal p_NomeAssociado As String, _
                                  ByVal p_NomeVendedor As String, ByVal p_DataInicial As String, ByVal p_DataFinal As String, _
                                  ByVal p_AgendamentoInicial As String, ByVal p_AgendamentoFinal As String, _
                                  ByVal p_Descricao As String, ByVal p_Prioridade As String) As SqlClient.SqlDataReader

        Dim p_SQL As String = "SP_RELFOLLOWUP_ASSOCIADOS " & p_IdEmpresa & "," & p_IdUsuario & ",'" & _
                              p_NomeAssociado & "','" & p_NomeVendedor & "'," & XMCheckDate(p_DataInicial, True, True) & "," & _
                              XMCheckDate(p_DataFinal, True, True) & "," & XMCheckDate(p_AgendamentoInicial, True, True) & "," & _
                              XMCheckDate(p_AgendamentoFinal, True, True) & ",'" & p_Descricao & "'" & ",'" & p_Prioridade & "'"

        Dim dr As SqlClient.SqlDataReader = ExecuteReader(p_SQL)
        Return dr

    End Function

    Public Function relEmpresas(ByVal p_IdEmpresa As Integer, ByVal p_IdUsuario As Integer, ByVal p_NomeEmpresa As String, _
                                  ByVal p_NomeVendedor As String, ByVal p_DataInicial As String, ByVal p_DataFinal As String, _
                                  ByVal p_AgendamentoInicial As String, ByVal p_AgendamentoFinal As String, _
                                  ByVal p_Descricao As String, ByVal p_Prioridade As String) As SqlClient.SqlDataReader

        Dim p_SQL As String = "SP_RELFOLLOWUP_EMPRESAS " & p_IdEmpresa & "," & p_IdUsuario & ",'" & _
                              p_NomeEmpresa & "','" & p_NomeVendedor & "'," & XMCheckDate(p_DataInicial, True, True) & "," & _
                              XMCheckDate(p_DataFinal, True, True) & "," & XMCheckDate(p_AgendamentoInicial, True, True) & "," & _
                              XMCheckDate(p_AgendamentoFinal, True, True) & ",'" & p_Descricao & "'" & ",'" & p_Prioridade & "'"

        Dim dr As SqlClient.SqlDataReader = ExecuteReader(p_SQL)
        Return dr

    End Function

    Public Function relObras(ByVal p_IdEmpresa As Integer, ByVal p_IdUsuario As Integer, ByVal p_NomeObra As String, _
                                  ByVal p_NomeVendedor As String, ByVal p_DataInicial As String, ByVal p_DataFinal As String, _
                                  ByVal p_AgendamentoInicial As String, ByVal p_AgendamentoFinal As String, _
                                  ByVal p_Descricao As String, ByVal p_Prioridade As String) As SqlClient.SqlDataReader

        Dim p_SQL As String = "SP_RELFOLLOWUP_OBRAS " & p_IdEmpresa & "," & p_IdUsuario & ",'" & _
                              p_NomeObra & "','" & p_NomeVendedor & "'," & XMCheckDate(p_DataInicial, True, True) & "," & _
                              XMCheckDate(p_DataFinal, True, True) & "," & XMCheckDate(p_AgendamentoInicial, True, True) & "," & _
                              XMCheckDate(p_AgendamentoFinal, True, True) & ",'" & p_Descricao & "'" & ",'" & p_Prioridade & "'"

        Dim dr As SqlClient.SqlDataReader = ExecuteReader(p_SQL)
        Return dr

    End Function

    Public Function ListStatusSIG() As DataSet
        Try
            ListStatusSIG = GetDataSet("SP_LS_STATUS_SIG")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListStatusSIG(ByVal vIDStatusSIG As Integer) As DataSet
        Try
            ListStatusSIG = GetDataSet("SP_SE_STATUS_SIG " & vIDStatusSIG)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function




End Class
