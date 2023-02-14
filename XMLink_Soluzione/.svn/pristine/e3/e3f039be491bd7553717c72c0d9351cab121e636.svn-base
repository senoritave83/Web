Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class XMWebPage
    Inherits System.Web.UI.Page
    Private m_Usuario As Usuario

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_Usuario Is Nothing Then m_Usuario = New Usuario(Me)
        If m_Usuario.IDUsuario = -1 Then
            Response.End()
        End If
    End Sub

    Public ReadOnly Property Usuario() As Usuario
        Get
            Return m_Usuario
        End Get
    End Property

    Public ReadOnly Property IDEmpresa() As Integer
        Get
            Try
                Return Application("IDEmpresa")
            Catch
                Return 0
            End Try
        End Get
    End Property

    Public Sub LogError(ByVal e As System.Exception, ByVal vModule As String)

    End Sub

    Public Function CryptographyEncoded(ByVal param As String) As String
        Dim strReturn As String = MyBase.Server.UrlEncode(XMCrypto.Encrypt(param))
        Return strReturn
    End Function

    Public Function Cryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Encrypt(param)
        Return strReturn
    End Function

    Public Function DeCryptography(ByVal param As String) As String
        Dim strReturn As String = XMCrypto.Decrypt(param)
        Return strReturn
    End Function

    Public Sub Log(ByVal vData As String)
        Dim t As New IO.StreamWriter(Server.MapPath("/") & "\log.txt", True)
        t.WriteLine(vData)
        t.Close()
        t = Nothing
    End Sub



    Public ReadOnly Property ConnectionString() As String

        Get
            On Error Resume Next
            Return Application("cnStr")
        End Get

    End Property

End Class

Public Class Usuario

    Inherits DataClass
    Private m_strUsuario As String
    Private m_strLogin As String
    Private m_intID As Integer

    Public ReadOnly Property Nome() As String
        Get
            Return m_strUsuario
        End Get
    End Property

    Public ReadOnly Property Login() As String
        Get
            Return m_strLogin
        End Get
    End Property

    Public ReadOnly Property IDUsuario() As Integer
        Get
            Return m_intID
        End Get
    End Property

    Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Dim ds As DataSet
        ds = GetDataSet("SP_SOL_WEB_SE_USUARIO_LOGIN '" & XMPage.Application("chave") & "', '" & XMCrypto.Decrypt(XMPage.Request("u")) & "', '" & XMCrypto.Decrypt(XMPage.Request("p")) & "'")
        If ds.Tables(0).Rows.Count = 0 Then
            Clear()
        Else
            m_intID = ds.Tables(0).Rows(0).Item("USU_USUARIO_INT_PK")
            m_strUsuario = ds.Tables(0).Rows(0).Item("USU_USUARIO_CHR") & ""
            m_strLogin = ds.Tables(0).Rows(0).Item("USU_LOGIN_CHR") & ""
        End If
    End Sub


    Private Sub Clear()
        m_intID = -1
        m_strUsuario = ""
        m_strLogin = ""
    End Sub

End Class


Public Class DataClass
    Private m_XMWebPage As XMWebPage
    Private Connection As SqlConnection

    Public Sub New(ByVal vXMPage As XMWebPage)
        m_XMWebPage = vXMPage
    End Sub

    Public ReadOnly Property XMPage() As XMWebPage
        Get
            Return m_XMWebPage
        End Get
    End Property

    Protected Sub Close()
        If Not Connection Is Nothing Then
            Connection.Close()
        End If
    End Sub

    Protected Sub Open()
        If Connection Is Nothing Then
            Connection = New SqlConnection(ConnectionString)
        End If
        If Connection.State <> ConnectionState.Open Then Connection.Open()
    End Sub

    Public Function GetDataSet(ByVal SQL As String) As DataSet
        Open()
        Dim myData As New DataSet()
        Try
            Dim adapter As New SqlDataAdapter(SQL, Connection)
            adapter.Fill(myData, "data")
            adapter.Dispose()
        Catch e As System.Exception
            XMPage.LogError(e, "DataClass")
        Finally
            Close()
        End Try
        Return myData

    End Function

    Public Sub ExecuteNonQuery(ByVal SQL As String)
        Open()
        Dim myCommand As New SqlCommand()
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        myCommand.ExecuteNonQuery()
        'clean up
        Close()
        myCommand.Dispose()
    End Sub

    Public Function ExecuteReader(ByVal SQL As String) As SqlDataReader
        Open()
        Dim myCommand As New SqlCommand()
        myCommand.Connection = Connection
        myCommand.CommandText = SQL
        myCommand.CommandType = CommandType.Text
        ExecuteReader = myCommand.ExecuteReader
        'clean up
        Close()
        myCommand.Dispose()
    End Function

    Protected ReadOnly Property ConnectionString() As String

        Get
            Return XMPage.Application("cnStr")
        End Get

    End Property

End Class



Public Class XMCrypto

    Private Const cryptoKey As String = "ajhgdteusm32"
    Private Shared IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, 173, 59}
    Private Shared IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, 42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}

    Public Shared Function Encrypt(ByVal p_Val As String) As String
        Dim buffer As Byte() = Encoding.ASCII.GetBytes(p_Val)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
        des.IV = IV
        Return Convert.ToBase64String(des.CreateEncryptor.TransformFinalBlock(buffer, 0, buffer.Length))
    End Function

    Public Shared Function Decrypt(ByVal p_Val As String) As String
        Try
            Dim buffer As Byte() = Convert.FromBase64String(p_Val)
            Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
            Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
            des.IV = IV
            Return Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
        Catch
            Return ""
        End Try
    End Function

End Class