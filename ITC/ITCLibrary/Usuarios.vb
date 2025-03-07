'************************************************************
'Classe gerada por XM Class Creator - 22/1/2003 15:30:18
'************************************************************

Imports System.Diagnostics.EventLog
Imports System.Data.SqlClient

Public Class clsUsuario

    Inherits DataClass

    Private m_intIDUsuario As Integer
    Private m_strUsuario As String
    Private m_strLogin As String
    Private m_varSenha As Object
    Private m_intIDCargo As Integer
    Private m_strCargo As String
    Private m_intIDGrupo As Integer
    Private m_strGrupo As String
    Private m_intIDUsuarioMaster As Integer
    Private m_strEmail As String
    Private m_intIDIdEmpresa As Integer
    Private m_strNomeEmpresa As String
    Private m_strFantasiaEmpresa As String
    Private m_intIDTipoUsuario As Integer
    Private m_indIndAtivo As Integer

    Public Enum TIPO_USUARIO
        Master = 1
        SubUsuario = 2
        Vendedor = 3
        Gestor = 4
    End Enum

    Public ReadOnly Property IDUsuario() As Integer
        Get
            Return m_intIDUsuario
        End Get
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

    Public Property Senha() As Object
        Get
            Return m_varSenha
        End Get
        Set(ByVal Value As Object)
            m_varSenha = Value
        End Set
    End Property

    Public Property IDCargo() As Integer
        Get
            Return m_intIDCargo
        End Get
        Set(ByVal Value As Integer)
            m_intIDCargo = Value
        End Set
    End Property

    Public ReadOnly Property Cargo() As String
        Get
            Return m_strCargo
        End Get
    End Property

    Public Property IDGrupo() As Integer
        Get
            Return m_intIDGrupo
        End Get
        Set(ByVal Value As Integer)
            m_intIDGrupo = Value
        End Set
    End Property

    Public ReadOnly Property Grupo() As String
        Get
            Return m_strGrupo
        End Get
    End Property

    Public Property IDUsuarioMaster() As Integer
        Get
            Return m_intIDUsuarioMaster
        End Get
        Set(ByVal Value As Integer)
            m_intIDUsuarioMaster = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return m_strEmail
        End Get
        Set(ByVal Value As String)
            m_strEmail = Value
        End Set
    End Property

    Public Property IdEmpresa() As Integer
        Get
            Return m_intIDIdEmpresa
        End Get
        Set(ByVal Value As Integer)
            m_intIDIdEmpresa = Value
        End Set
    End Property

    Public Property NomeEmpresa() As String
        Get
            Return m_strNomeEmpresa
        End Get
        Set(ByVal Value As String)
            m_strNomeEmpresa = Value
        End Set
    End Property

    Public ReadOnly Property FantasiaEmpresa() As String
        Get
            Return m_strFantasiaEmpresa
        End Get
    End Property

    Public Property IdTipoUsuario() As Integer
        Get
            Return m_intIDTipoUsuario
        End Get
        Set(ByVal Value As Integer)
            m_intIDTipoUsuario = Value
        End Set
    End Property

    Public Property IdSituacao() As Integer
        Get
            Return m_indIndAtivo
        End Get
        Set(ByVal Value As Integer)
            m_indIndAtivo = Value
        End Set
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_intIDUsuario = CLng(0 & row("usu_Usuario_int_PK"))
        Me.m_strUsuario = CStr(row("usu_Usuario_chr") & "")
        Me.m_strLogin = CStr(row("usu_Login_chr") & "")
        Me.m_intIDCargo = CLng(0 & row("crg_Cargo_int_FK"))
        Me.m_intIDUsuarioMaster = CLng(0 & row("usu_Usuario_int_FK"))
        Me.m_strEmail = CStr(row("usu_Email_chr") & "")
        Me.m_intIDIdEmpresa = CLng(row("emp_IdEmpresa_int_FK"))
        Me.m_strNomeEmpresa = CStr(row("usu_Empresa_chr") & "")
        Me.m_intIDTipoUsuario = CInt(0 & row("USU_TIPOUSUARIO_INT"))
        Me.m_indIndAtivo = CInt(0 & row("USU_INDATIVO_IND"))
        Me.m_intIDGrupo = CLng(0 & row("IdGrupo"))

    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= "" & m_intIDUsuario & "" & ","
        strDeflate &= "'" & m_strUsuario & "'" & ","
        strDeflate &= "'" & m_strLogin & "'" & ","
        strDeflate &= "'" & m_strEmail & "',"
        strDeflate &= m_intIDIdEmpresa & ","
        strDeflate &= m_intIDTipoUsuario & ","
        strDeflate &= m_indIndAtivo & ","
        strDeflate &= "'" & m_strNomeEmpresa & "',"
        strDeflate &= m_intIDCargo & ","
        strDeflate &= m_intIDGrupo
        Deflate = strDeflate
    End Function

    Public Function Update() As Boolean

        Try
            Dim sql As String
            sql = "SP_SV_USUARIO " & Deflate()
            Dim myData As DataSet
            myData = GetDataSet(sql)
            If myData.Tables(0).Rows.Count <= 0 Then
                Return False
            Else
                Inflate(myData.Tables(0).Rows(0))
                Return True
            End If
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Sub UpdateSubCadastro()
        Dim sql As String
        sql = "SP_IN_USUARIOSUBSENHA " & Deflate() & "," & m_intIDUsuarioMaster
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("N�o houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub New(ByVal p_intIDUsuario As Integer, ByVal p_IdEmpresa As Integer)
        If p_intIDUsuario = 0 Then
            Clear()
        Else
            Load(p_intIDUsuario, p_IdEmpresa)
        End If
    End Sub

    Protected Sub Load(ByVal p_intIDUsuario As Integer, ByVal p_IdEmpresa As Integer)
        If p_intIDUsuario = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_USUARIOS " & p_intIDUsuario & "," & p_IdEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado n�o existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub Delete()
        ExecuteNonQuery("SP_DE_Usuario " & m_intIDUsuario)
        Clear()
    End Sub

    Public Sub Delete(ByVal p_intIDUsuario As Integer)
        ExecuteNonQuery("SP_DE_USUARIO " & p_intIDUsuario)
        If m_intIDUsuario = p_intIDUsuario Then Clear()
    End Sub

    Public Sub New()
        Clear()
    End Sub

    Private Sub Clear()
        m_intIDUsuario = 0
        m_strUsuario = ""
        m_strLogin = ""
        m_varSenha = ""
        m_intIDCargo = 0
        m_strCargo = ""
        m_intIDUsuarioMaster = 0
        m_strEmail = ""
        m_intIDIdEmpresa = 0
        m_intIDGrupo = 0
        m_strGrupo = ""
    End Sub

    Public Function ListUsuariosEmpresa(ByVal p_IdEmpresa As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_USUARIOS 0, " & p_IdEmpresa)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListarVendedores(ByVal v_IdEmpresa As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_LISTARVENDEDORES " & TIPO_USUARIO.Vendedor & "," & v_IdEmpresa)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListUsuariosEmpresa(ByVal p_IdEmpresa As Integer, ByVal p_Tipo As TIPO_USUARIO) As DataSet
        Try
            Return GetDataSet("SP_SE_USUARIOS_EMPRESA 0, " & p_IdEmpresa & "," & p_Tipo)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListUsuariosSistema(ByVal p_IdUsuario As Integer) As DataSet
        Try
            Return GetDataSet("SP_SE_USUARIOS " & p_IdUsuario & ", -1")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function List(ByVal p_NomeUsuario As String, ByVal p_Login As String) As DataSet
        Try
            Dim strNomeUsuario As String = IIf(p_NomeUsuario.Trim() = "", "NULL", "'" & p_NomeUsuario & "'")
            Dim strLoginUsuario As String = IIf(p_Login.Trim() = "", "NULL", "'" & p_Login & "'")
            List = GetDataSet("SP_SE_SUPERUSUARIOS 0, " & strNomeUsuario & "," & strLoginUsuario)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListSubUsuarios(ByVal IdUsuario As Integer, ByVal IdUsuarioMaster As Integer) As DataSet
        Try
            ListSubUsuarios = GetDataSet("SP_SE_USUARIOSUBSENHA " & IdUsuario & "," & IdUsuarioMaster)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function AlterarSenha(ByVal IdUsuario As Integer) As Boolean
        Try

            Dim ds As DataSet
            ExecuteNonQuery("SP_UP_UPDATEPASSWORDNEXTELOGON " & IdUsuario)
            AlterarSenha = True

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function AlterarSenha(ByVal IdUsuario As Integer, ByVal NovaSenha As String) As Boolean
        Try

            Dim ds As DataSet
            ExecuteNonQuery("SP_UP_SENHA_ITC " & IdUsuario & ",'" & NovaSenha & "'")
            AlterarSenha = True

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function PermissoesRegiao() As DataSet
        Try

            PermissoesRegiao = GetDataSet("SP_SE_PERMISSAOUSUARIOREGIAO " & m_intIDUsuario)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function PermissoesEstados(ByVal IdRegiao As Integer) As DataSet
        Try

            PermissoesEstados = GetDataSet("SP_SE_PERMISSAOUSUARIOESTADO " & m_intIDUsuario) '& "," & IdRegiao)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function PermissoesTipo() As DataSet
        Try

            PermissoesTipo = GetDataSet("SP_SE_PERMISSAOUSUARIOTIPO " & m_intIDUsuario)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function SalvarPermissoes(ByVal Tipos As String, ByVal Regioes As String, ByVal Estados As String)
        Try

            ExecuteNonQuery("SP_SV_PERMISSAOUSUARIO " & m_intIDUsuario & ",'" & Tipos & "','" & Regioes & "','" & Estados & "'")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListPermissoes(ByVal p_IdUsuario As Integer) As DataSet
        'permiss�es dos usu�rios do sistema
        Try
            Return GetDataSet("SP_SE_PERMISSOES_USUARIOS " & p_IdUsuario)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function SavePermissoes(ByVal Permissoes As String, ByVal p_IdUsuario As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_SV_USUARIO_PERMISSOES '" & Permissoes & "'," & p_IdUsuario)
            Return True
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return False
        End Try
    End Function

    Public Sub ApagarUsuarioAssociado(ByVal IdAssociado As Integer, ByVal IdUsuario As Integer)
        Try
            Dim sql As String
            sql = "SP_DE_USUARIOASSOCIADO " & IdAssociado & "," & IdUsuario
            ExecuteNonQuery(sql)

        Catch e As Exception

        End Try

    End Sub


End Class