Imports System.Data.SqlClient


Public Class clsEmpresa
    Inherits DataClass
    Private m_intIDEmpresa As Integer
    Private m_strChave As String
    Private m_strEmpresa As String
    Private m_strUsuario As String
    Private m_strCodigo As String
    Private m_strEMail As String
    Private m_strAdministrador As String
    Private m_strLogin As String
    Private m_strSenha As String
    Private m_strMotivo As String
    Private m_strTelefone As String
    Private m_blnVerifica As Boolean
    Private m_blnIntegracao As Boolean

    Public ReadOnly Property IDEmpresa() As Integer
        Get
            Return m_intIDEmpresa
        End Get
    End Property

    Public Property Empresa() As String
        Get
            Return m_strEmpresa
        End Get
        Set(ByVal Value As String)
            m_strEmpresa = Value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return m_strCodigo
        End Get
        Set(ByVal Value As String)
            m_strCodigo = Value
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

    Public Property Administrador() As String
        Get
            Return m_strAdministrador
        End Get
        Set(ByVal Value As String)
            m_strAdministrador = Value
        End Set
    End Property


    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
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

    Public Property Senha() As String
        Get
            Return m_strSenha
        End Get
        Set(ByVal Value As String)
            m_strSenha = Value
        End Set
    End Property

    Public Property Chave() As String
        Get
            Return m_strChave
        End Get
        Set(ByVal Value As String)
            m_strChave = Value
        End Set
    End Property


    Public Property Motivo() As String
        Get
            Return m_strMotivo
        End Get
        Set(ByVal Value As String)
            m_strMotivo = Value
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

    Public ReadOnly Property Verifica() As Boolean
        Get
            Return m_blnVerifica
        End Get
    End Property

    Public ReadOnly Property Integracao() As Boolean
        Get
            Return m_blnIntegracao
        End Get
    End Property


    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDEmpresa = dr.GetInt32(dr.GetOrdinal("IDEmpresa"))
        m_strEmpresa = dr.GetString(dr.GetOrdinal("Empresa"))
        m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
        m_strChave = dr.GetString(dr.GetOrdinal("Chave"))
        m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
        m_strLogin = dr.GetString(dr.GetOrdinal("Login"))
        m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
        If dr.IsDBNull(dr.GetOrdinal("Email")) Then
            m_strEMail = ""
        Else
            m_strEMail = dr.GetString(dr.GetOrdinal("Email"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
            m_strTelefone = ""
        Else
            m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Motivo")) Then
            m_strMotivo = ""
        Else
            m_strMotivo = dr.GetString(dr.GetOrdinal("Motivo"))
        End If
        m_blnVerifica = IIf(dr.Item(dr.GetOrdinal("Verifica")) = 1, True, False)
        If dr.IsDBNull(dr.GetOrdinal("Integracao")) Then
            m_blnIntegracao = False
        Else
            m_blnIntegracao = IIf(dr.Item(dr.GetOrdinal("Integracao")) = 1, True, False)
        End If


    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate = m_intIDEmpresa & ","
        strDeflate &= "'" & m_strEmpresa.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strAdministrador.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strEMail.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strLogin.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strSenha.Replace("'", "''") & "'"
        Deflate = strDeflate
    End Function


    Public Sub Update()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_WEB_SV_EMPRESA"
        cmd.Parameters.Add("@EMPRESA", SqlDbType.VarChar, 100).Value = m_strEmpresa
        cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = m_strCodigo
        cmd.Parameters.Add("@CHAVE", SqlDbType.VarChar, 20).Value = m_strChave

        cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 150).Value = m_strUsuario
        cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 150).Value = m_strLogin
        cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 150).Value = m_strSenha

        cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 150).Value = m_strEMail
        cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).Value = m_strTelefone
        cmd.Parameters.Add("@MOTIVO", SqlDbType.VarChar, 1000).Value = m_strMotivo
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
    ''' <param name="vIDEmpresa">Chave primaria IDEmpresa</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDEmpresa As Integer) As Boolean
        If vIDEmpresa = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_EMPRESA"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = vIDEmpresa
        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
                Load = True
            Else
                Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        Return True
    End Function


    Public Function AlterarEmail(ByVal p_strCodigo As String, ByVal vEmail As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "UP_EMPRESA_EMAIL"
        cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = p_strCodigo
        cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = vEmail
        Return (ExecuteScalar(cmd) > 0)
    End Function


    Public Function Pesquisar(ByVal p_strCodigo As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_EMPRESA_CODIGO"
        cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = p_strCodigo
        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
                Pesquisar = True
            Else
                Clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
        Return True
    End Function

    Public Function GenerateKey() As String

        Dim str As StringBuilder = New StringBuilder()
        Dim intASCII As Integer = 0

        Do While True
            str = New StringBuilder()
            Do While str.Length < 8
                intASCII = Rnd() * 123 ' .Next(123)
                If str.Length = 3 Or str.Length = 4 Then
                    If intASCII >= 48 And intASCII <= 57 Then
                        Dim bytes() As Byte = {Convert.ToByte(intASCII)}
                        Dim chrCaracter() As Char = ASCIIEncoding.ASCII.GetChars(bytes)
                        str.Append(chrCaracter(0))
                    End If
                ElseIf str.Length Mod 2 = 1 Then
                    If intASCII = 97 Or intASCII = 101 Or intASCII = 105 Or intASCII = 111 Or intASCII = 117 Then
                        Dim bytes() As Byte = {Convert.ToByte(intASCII)}
                        Dim chrCaracter() As Char = ASCIIEncoding.ASCII.GetChars(bytes)
                        str.Append(chrCaracter(0))
                    End If
                Else
                    If ((intASCII >= 97 And intASCII <= 122) And (Not (intASCII = 97 Or intASCII = 101 Or intASCII = 105 Or intASCII = 111 Or intASCII = 117 Or intASCII = 104 Or intASCII = 107 Or intASCII = 121 Or intASCII = 119 Or intASCII = 120))) Then
                        Dim bytes() As Byte = {Convert.ToByte(intASCII)}
                        Dim chrCaracter() As Char = ASCIIEncoding.ASCII.GetChars(bytes)
                        str.Append(chrCaracter(0))
                    End If
                End If
            Loop
            If Not ChaveExistente(str.ToString) Then Exit Do
        Loop
        Return str.ToString()

    End Function

    Private Function ChaveExistente(ByVal vChave As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_EMPRESA_CHAVE_EXISTENTE"
        Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        parameter.Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add(parameter)
        cmd.Parameters.Add("@CHAVE", SqlDbType.VarChar, 20).Value = vChave
        ExecuteNonQuery(cmd)
        Return (cmd.Parameters("@RETURN_VALUE").Value = 1)
    End Function

    Public Function ChecaDados(ByVal vCodigo As String, ByVal vSenha As String) As Boolean
        Return True
    End Function

    Protected Sub Clear()
        m_intIDEmpresa = 0
        m_strChave = ""
        m_strEmpresa = ""
        m_strCodigo = ""
        m_strEMail = ""
        m_strAdministrador = ""
        m_strLogin = ""
        m_strSenha = ""
        m_blnVerifica = False
        m_blnIntegracao = False
    End Sub


End Class
