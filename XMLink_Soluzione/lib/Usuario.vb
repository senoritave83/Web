Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsUsuario
    Inherits clsUsuarioBase
    Protected m_lstPermissoes As clsLista

    Protected Overrides Sub Clear()
        MyBase.Clear()
        m_lstPermissoes = New clsLista()
    End Sub
    
    Public Function SavePermissoes()
        Dim sql As String
        sql = PREFIXO & "SV_USUARIO_PERMISSOES " & XMPage.IDEmpresa & ", " & m_intIDUsuario & ", '" & m_lstPermissoes.GetLista.Replace("'", "''") & "'"
        ExecuteNonQuery(sql)
    End Function

    Public Function Update() As Boolean
        Dim sql As String
        sql = PREFIXO & "SV_USUARIO " & Deflate()
        Dim myData As DataSet, vMessage As String
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
        Update = True
    End Function

    Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Public ReadOnly Property Permissoes() As clsLista
        Get
            Return m_lstPermissoes
        End Get
    End Property

    Public Function Existe(ByVal vIDUsuario As Integer, ByVal vNome As String, ByVal vLogin As String, ByVal vSenha As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_USUARIO_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDUsuario & ", '" & vNome.Replace("'", "''") & "', '" & vLogin.Replace("'", "''") & "', '" & vSenha.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Public Sub Load(ByVal p_intIDUsuario As Integer)
        If p_intIDUsuario = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_USUARIO " & p_intIDUsuario & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_USUARIO " & m_intIDUsuario & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_USUARIO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Function ListarPermissoes() As DataSet
        Return GetDataSet(PREFIXO & "LS_PERMISSOES_USUARIO " & XMPage.IDEmpresa & ", " & m_intIDUsuario)
    End Function

    Public Function Listar() As DataSet
        Return Listar("", "", False, 0, 0)
    End Function

    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_USUARIO " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

    Public Sub AlteraSenha(ByVal vSenha As String)
        ExecuteNonQuery(PREFIXO & "UP_USUARIO_SENHA " & m_intIDUsuario & ", " & XMPage.IDEmpresa & ", '" & vSenha.Replace("'", "''") & "'")
    End Sub

End Class
