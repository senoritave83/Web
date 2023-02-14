Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports XMSistemas.Web.Base

Public Class clsUsuario
    Inherits DataClass
    Protected m_intIDUsuario As Integer 'Primary Key
    Protected m_strNome As String
    Protected m_strLogin As String
    Protected m_blnAdministrador As Boolean


    Public Property IDUsuario() As Integer
        Get
            Return m_intIDUsuario
        End Get
        Set(ByVal Value As Integer)
            m_intIDUsuario = Value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return m_strNome
        End Get
        Set(ByVal Value As String)
            m_strNome = Value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return m_strLogin
        End Get
        Set(ByVal Value As String)
            m_strLogin = Value
        End Set
    End Property

    Public Property Administrador() As Boolean
        Get
            Return m_blnAdministrador
        End Get
        Set(ByVal Value As Boolean)
            m_blnAdministrador = Value
        End Set
    End Property


    Protected Overridable Sub Inflate(ByRef dr As IDataReader)
        m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("usu_Usuario_int_PK"))
        m_strNome = dr.GetString(dr.GetOrdinal("usu_Usuario_chr"))
        m_strLogin = dr.GetString(dr.GetOrdinal("usu_Login_chr"))
        m_blnAdministrador = IIf(dr.GetByte(dr.GetOrdinal("usu_Administrador_ind")) = 1, True, False)
    End Sub

    Protected Overridable Sub Clear()
        m_intIDUsuario = 0
        m_strLogin = ""
        m_strNome = ""
    End Sub

    Public Function Update() As Boolean
        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_USUARIO"

        cmd.Parameters.Add("@usu_Usuario_int_PK", SqlDbType.Int).Value = m_intIDUsuario
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@usu_Usuario_chr", SqlDbType.VarChar, 100).Value = m_strNome
        cmd.Parameters.Add("@usu_login_chr", SqlDbType.VarChar, 20).Value = m_strLogin
        cmd.Parameters.Add("@usu_Administrador_ind", SqlDbType.TinyInt).Value = IIf(m_blnAdministrador, 1, 0)
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
        Update = True
    End Function

    Public Function Existe(ByVal vIDUsuario As Integer, ByVal vNome As String, ByVal vLogin As String, ByVal vSenha As String) As Boolean
        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_USUARIO_EXISTENTE"

        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@usu_Usuario_int_FK", SqlDbType.Int).Value = vIDUsuario
        cmd.Parameters.Add("@usu_Usuario_chr", SqlDbType.VarChar, 100).Value = vNome
        cmd.Parameters.Add("@usu_login_chr", SqlDbType.VarChar, 20).Value = vLogin
        cmd.Parameters.Add("@usu_Senha_chr", SqlDbType.VarChar, 20).Value = vSenha
        dr = ExecuteReader(cmd)
        Try
            Existe = dr.Read
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        cmd.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDUsuario As Integer)
        If p_intIDUsuario = 0 Then
            Clear()
            Exit Sub
        End If


        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_USUARIO"

        cmd.Parameters.Add("@usu_Usuario_int_PK", SqlDbType.Int).Value = p_intIDUsuario
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                Throw New ArgumentException("This key does not exist!")
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        cmd.Dispose()
    End Sub

    Public Function LoadLogin(ByVal p_strChave As String, ByVal p_strLogin As String, ByVal p_strSenha As String) As Boolean

        Dim dr As IDataReader = Nothing
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_USUARIO_LOGIN"

        cmd.Parameters.Add("@CHAVE", SqlDbType.VarChar).Value = p_strChave
        cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = p_strLogin
        cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = p_strSenha

        dr = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
                With Identity
                    .IDEmpresa = dr.GetInt32(dr.GetOrdinal("emp_Empresa_int_FK"))
                    .IDUsuario = dr.GetInt32(dr.GetOrdinal("usu_Usuario_int_PK"))
                    .Login = dr.GetString(dr.GetOrdinal("usu_Login_chr"))
                    .Nome = dr.GetString(dr.GetOrdinal("usu_Usuario_chr"))
                    .Administrador = IIf(dr.GetByte(dr.GetOrdinal("usu_Administrador_ind")) = 1, True, False)
                End With
                LoadLogin = True
            Else
                LoadLogin = False

            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        cmd.Dispose()
    End Function


    Public Sub Delete()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_USUARIO"

        cmd.Parameters.Add("@usu_Usuario_int_PK", SqlDbType.Int).Value = m_intIDUsuario
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_USUARIO_SEL"

        cmd.Parameters.Add("@IDS", SqlDbType.VarChar, 1000).Value = vIDs
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
    End Sub

    Public Function List() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_USUARIO"

        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa

        Return ExecuteReader(cmd)
    End Function

    Public Function ListarUsuarios(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vDesc As Integer) As IPaginaResult
        Dim ret As New PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_USUARIOS"

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

    Public Sub AlteraSenha(ByVal vSenha As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "UP_USUARIO_SENHA"

        cmd.Parameters.Add("@usu_Usuario_int_PK", SqlDbType.Int).Value = m_intIDUsuario
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@Senha", SqlDbType.VarChar, 20).Value = vSenha
        ExecuteNonQuery(cmd)
    End Sub

End Class
