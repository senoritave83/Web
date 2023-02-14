Imports System.Data.SqlClient

Public Class clsConfig
    Inherits DataClass
    Protected m_strPrefixo As String
    Protected m_strFormato As String
    Protected m_intNumeroInicial As Integer
    Protected m_intIncremento As Short
    Protected m_blnCheckFleetID As Boolean
    Protected m_intTempoLimite As Integer
    Protected m_blnModuloJava As Boolean

    Public Property Prefixo() As String
        Get
            Return m_strPrefixo
        End Get
        Set(ByVal Value As String)
            m_strPrefixo = Value
        End Set
    End Property

    Public Property Formato() As String
        Get
            Return m_strFormato
        End Get
        Set(ByVal Value As String)
            m_strFormato = Value
        End Set
    End Property

    Public Property NumeroInicial() As Integer
        Get
            Return m_intNumeroInicial
        End Get
        Set(ByVal Value As Integer)
            m_intNumeroInicial = Value
        End Set
    End Property

    Public Property Incremento() As Short
        Get
            Return m_intIncremento
        End Get
        Set(ByVal Value As Short)
            m_intIncremento = Value
        End Set
    End Property

    Public Property TempoLimite() As Integer
        Get
            Return m_intTempoLimite
        End Get
        Set(ByVal Value As Integer)
            m_intTempoLimite = Value
        End Set
    End Property

    Public ReadOnly Property CheckFleetID() As Boolean
        Get
            Return m_blnCheckFleetID
        End Get
    End Property

    Public Property ModuloJava() As Boolean
        Get
            Return m_blnModuloJava
        End Get
        Set(ByVal Value As Boolean)
            m_blnModuloJava = Value
        End Set
    End Property

    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_strPrefixo = dr.GetString(dr.GetOrdinal("cfg_Prefixo_chr"))
        m_strFormato = dr.GetString(dr.GetOrdinal("cfg_Formato_chr"))
        m_intNumeroInicial = dr.GetInt32(dr.GetOrdinal("cfg_Numero_int"))
        m_intIncremento = dr.GetByte(dr.GetOrdinal("cfg_Incremento_int"))
        If dr.IsDBNull(dr.GetOrdinal("cfg_TempoLimite_int")) Then
            m_intTempoLimite = 0
        Else
            m_intTempoLimite = dr.GetInt32(dr.GetOrdinal("cfg_TempoLimite_int"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("cfg_CheckFleetID_ind")) Then
            m_blnCheckFleetID = True
        Else
            m_blnCheckFleetID = IIf(dr.GetByte(dr.GetOrdinal("cfg_CheckFleetID_ind")) = 1, True, False)
        End If
        m_blnModuloJava = IIf(dr.GetByte(dr.GetOrdinal("cfg_ModuloJava_ind")) = 1, True, False)
    End Sub

    Public Sub New()
        Load()
    End Sub

    Public Sub Update()

        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_CONFIG"

        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@cfg_Prefixo_chr", SqlDbType.VarChar, 4).Value = m_strPrefixo
        cmd.Parameters.Add("@cfg_Formato_chr", SqlDbType.VarChar, 20).Value = m_strFormato
        cmd.Parameters.Add("@cfg_Numero_int", SqlDbType.Int).Value = m_intNumeroInicial
        cmd.Parameters.Add("@cfg_Incremento_int", SqlDbType.TinyInt).Value = m_intIncremento
        cmd.Parameters.Add("@cfg_TempoLimite_int", SqlDbType.Int).Value = m_intTempoLimite
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

    Public Sub Load()

        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_CONFIG"

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

    Public Property ModoContingencia() As Boolean
        Get
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SQLPREFIXO & "SE_MODO_CONTINGENCIA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
            Return CBool(ExecuteScalar(cmd))
        End Get
        Set(ByVal Value As Boolean)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SQLPREFIXO & "SV_MODO_CONTINGENCIA"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
            cmd.Parameters.Add("@MODO", SqlDbType.Int).Value = IIf(Value, 1, 0)
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
            ExecuteNonQuery(cmd)
        End Set
    End Property

End Class
