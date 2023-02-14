Imports System.Data.SqlClient

Public Class clsResposta
    Inherits DataClass
    Protected m_intIDResposta As Integer
    Protected m_intIDSuperior As Integer
    Protected m_strResposta As String
    Protected m_strEtapa As String
    Protected m_intOpcaoObservacao As Byte
    Protected m_strFormatoObservacao As String
    Protected m_indRespostaMultipla As Boolean

    Public ReadOnly Property IDResposta() As Integer
        Get
            Return m_intIDResposta
        End Get
    End Property

    Public ReadOnly Property IDSuperior() As Integer
        Get
            Return m_intIDSuperior
        End Get
    End Property

    Public ReadOnly Property Resposta() As String
        Get
            Return m_strResposta
        End Get
    End Property

    Public ReadOnly Property Etapa() As String
        Get
            Return m_strEtapa
        End Get
    End Property

    Public ReadOnly Property OpcaoObservacao() As Byte
        Get
            Return m_intOpcaoObservacao
        End Get
    End Property

    Public ReadOnly Property FormatoObservacao() As String
        Get
            Return m_strFormatoObservacao
        End Get
    End Property

    Public ReadOnly Property RespostaMultipla() As Boolean
        Get
            Return m_indRespostaMultipla
        End Get
    End Property

    Public Sub GravarOpcaoObservacao(ByVal vOpcoes As Byte, ByVal vFormato As String, ByVal vResMultipla As Boolean)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_RESPOSTA_OBSERVACAO"
        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = m_intIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@OPCOES", SqlDbType.TinyInt).Value = vOpcoes
        cmd.Parameters.Add("@FORMATO", SqlDbType.VarChar, 30).Value = vFormato
        cmd.Parameters.Add("@RESMULTIPLA", SqlDbType.TinyInt).Value = vResMultipla
        ExecuteNonQuery(cmd)

        m_intOpcaoObservacao = vOpcoes
        m_strFormatoObservacao = vFormato
        m_indRespostaMultipla = vResMultipla
    End Sub


    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDResposta = dr.GetInt32(dr.GetOrdinal("res_Resposta_int_PK"))
        If dr.IsDBNull(dr.GetOrdinal("res_Superior_int_FK")) Then
            m_intIDSuperior = 0
        Else
            m_intIDSuperior = dr.GetInt32(dr.GetOrdinal("res_Superior_int_FK"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("res_Resposta_chr")) Then
            m_strResposta = ""
        Else
            m_strResposta = dr.GetString(dr.GetOrdinal("res_Resposta_chr"))
        End If
        If IsDBNull(dr.GetOrdinal("Etapa")) Then
            m_strEtapa = ""
        Else
            m_strEtapa = dr.GetString(dr.GetOrdinal("Etapa"))
        End If
        If IsDBNull(dr.GetOrdinal("OpcaoObs")) Then
            m_intOpcaoObservacao = ""
        Else
            m_intOpcaoObservacao = dr.GetByte(dr.GetOrdinal("OpcaoObs"))
        End If
        If IsDBNull(dr.GetOrdinal("FormatoObs")) Then
            m_strFormatoObservacao = ""
        Else
            m_strFormatoObservacao = dr.GetString(dr.GetOrdinal("FormatoObs"))
        End If
        If IsDBNull(dr.GetOrdinal("RespostaMultipla")) Then
            m_indRespostaMultipla = 0
        Else
            m_indRespostaMultipla = dr.GetByte(dr.GetOrdinal("RespostaMultipla"))
        End If
    End Sub

    Public Sub Load(ByVal p_intIDResposta As Integer)

        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_RESPOSTA"

        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = p_intIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Throw New ArgumentException("There was no data response!")
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        cmd.Dispose()

    End Sub

    'Public Sub Delete(ByVal vIDResposta As Integer)
    '    ExecuteNonQuery("SP_WEB_DE_RESPOSTA " & vIDResposta & ", " & Identity.IDEmpresa)
    'End Sub

    Public Sub DeleteSubDeck(ByVal vIDResposta As Integer)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_RESPOSTA_SUBDECK"

        cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = vIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        If vIDs <> "" Then
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SQLPREFIXO & "DE_RESPOSTA_SEL"

            cmd.Parameters.Add("@IDS", SqlDbType.VarChar, 1000).Value = vIDs
            cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
            ExecuteNonQuery(cmd)
        End If
    End Sub

    Public Function Listar() As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPOSTAS"

        cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = m_intIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        Return ExecuteDataSet(cmd)
    End Function

    Public Function ListarNiveis() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPOSTA_NIVEIS"

        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = m_intIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        Return ExecuteReader(cmd)
    End Function

    Public Function Listar(ByVal vIDSuperior As Integer) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPOSTAS"

        cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = vIDSuperior
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        Return ExecuteReader(cmd)
    End Function

    Public Sub Gravar(ByVal vPosicao As String, ByVal vTexto As String, ByVal vColor As String, ByVal vFinaliza As Boolean, ByVal vIDEtapa As Integer)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_RESPOSTA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDSUPERIOR", SqlDbType.Int).Value = m_intIDResposta
        cmd.Parameters.Add("@POSICAO", SqlDbType.Int).Value = vPosicao
        cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar, 50).Value = vTexto
        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar, 30).Value = vColor
        cmd.Parameters.Add("@FINALIZA", SqlDbType.TinyInt).Value = IIf(vFinaliza, 1, 0)
        cmd.Parameters.Add("@IDETAPA", SqlDbType.Int).Value = vIDEtapa
        ExecuteNonQuery(cmd)

    End Sub

End Class
