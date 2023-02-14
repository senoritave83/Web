Imports System.Data.SqlClient
Imports XMSistemas.Web.Base

Public Class clsMensagem
    Inherits DataClass
    Protected m_intIDMensagem As Integer
    Protected m_strNome As String
    Protected m_strMensagem As String

    Public ReadOnly Property IDMensagem() As Integer
        Get
            Return m_intIDMensagem
        End Get
    End Property

    Public Property Nome() As String
        Get
            Return m_strNome
        End Get
        Set(ByVal Value As String)
            m_strNome = Value
        End Set
    End Property

    Public Property Mensagem() As String
        Get
            Return m_strMensagem
        End Get
        Set(ByVal Value As String)
            m_strMensagem = Value
        End Set
    End Property


    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDMensagem = dr.GetInt32(dr.GetOrdinal("msp_MensagemPadrao_int_PK"))
        If dr.IsDBNull(dr.GetOrdinal("msp_Nome_chr")) Then
            m_strNome = ""
        Else
            m_strNome = dr.GetString(dr.GetOrdinal("msp_Nome_chr"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("msp_MensagemPadrao_chr")) Then
            m_strMensagem = ""
        Else
            m_strMensagem = dr.GetString(dr.GetOrdinal("msp_MensagemPadrao_chr"))
        End If
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate = m_intIDMensagem & ", "
        strDeflate &= Identity.IDEmpresa & ", "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strMensagem.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Sub Update()
        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_MENSAGEM"

        cmd.Parameters.Add("@msp_MensagemPadrao_int_PK", SqlDbType.Int).Value = m_intIDMensagem
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@msp_Nome_chr", SqlDbType.VarChar, 30).Value = m_strNome
        cmd.Parameters.Add("@msp_MensagemPadrao_chr", SqlDbType.VarChar, 250).Value = m_strMensagem
        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Throw New ArgumentException("There was no data response!")
                'Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        cmd.Dispose()
    End Sub

    Public Sub Load(ByVal p_intIDMensagem As Integer)
        If p_intIDMensagem = 0 Then
            Clear()
            Exit Sub
        End If

        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_MENSAGEM"

        cmd.Parameters.Add("@msp_MensagemPadrao_int_PK", SqlDbType.Int).Value = p_intIDMensagem
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
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

    Protected Sub Clear()
        m_intIDMensagem = 0
        m_strMensagem = ""
    End Sub

    Public Sub Delete()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_MENSAGEM"

        cmd.Parameters.Add("@msp_MensagemPadrao_int_PK", SqlDbType.Int).Value = m_intIDMensagem
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_MENSAGEM_SEL"

        cmd.Parameters.Add("@IDS", SqlDbType.VarChar, 1000).Value = vIDs
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
    End Sub


    Public Function Listar() As IDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_MENSAGENS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        Return ExecuteReader(cmd)
    End Function

    Public Function ListarMensagens(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vDesc As Integer) As IPaginaResult
        Dim ret As New PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_MENSAGENS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 50).Value = vOrder
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
        cmd.Parameters.Add("@DESC", SqlDbType.TinyInt).Value = vDesc

        'Dim ds As DataSet = ExecuteDataSet(cmd)
        ret = ExecutePaginate(cmd, enReturnType.DataSet, vPageSize, vPage)
        ret.CurrentPage = vPage
        ret.PageSize = vPageSize
        ret.RecordCount = ret.Tables(1).Rows(0).Item(0)
        Return ret
    End Function

End Class
