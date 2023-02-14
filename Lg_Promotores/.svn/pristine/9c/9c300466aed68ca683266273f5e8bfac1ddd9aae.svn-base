Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Data.SqlClient


Public MustInherit Class BaseClass
    Inherits DataClass

    Private m_colBrokenRules As New List(Of String)


    Protected Sub LogEvent(ByVal vMessage As String, ByVal vCategory As String, ByVal vPriority As Integer, ByVal vEventType As TraceEventType)

    End Sub

    Protected Sub Audit(ByVal vEntidade As String, ByVal vEvento As String, ByVal vMensagem As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "IN_AUDIT"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
        cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar).Value = vEntidade
        cmd.Parameters.Add("@EVENTO", SqlDbType.VarChar).Value = vEvento
        cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar).Value = vMensagem
        ExecuteNonQuery(cmd)
    End Sub

    Protected ReadOnly Property User() As XMPrincipal
        Get
            Return HttpContext.Current.User
        End Get
    End Property


    Public Overridable ReadOnly Property Secao() As String
        Get
            Try
                Dim prov As SiteMapProvider = SiteMap.Providers.Item("OpenXMLSiteMapProvider")
                If prov Is Nothing Then prov = SiteMap.Provider

                If prov.CurrentNode Is Nothing Then
                    Return ""
                End If
                Return prov.CurrentNode.Item("secao") & ""
            Catch
                Return "Indefinida"
            End Try
        End Get
    End Property


    ''' <summary>
    ''' Função Responsável por tranformar a data padrão em data interna
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function _setDateTimePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("yyyy-MM-dd HH:mm:ss")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por tranformar a data interna em uma data padrão
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function _getDateTimePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("dd/MM/yyyy HH:mm:ss")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por tranformar a data interna em uma data padrão
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function _getDatePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("dd/MM/yyyy")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por transformar o valor gravado no SQL em formato string interno 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function _getDateTimeDBValue(ByVal Value As Date) As String
        Return Value.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    ''' <summary>
    ''' Função Responsável por transformar o valor no formato string interno em um valor Date 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function _setDateTimeDBValue(ByVal Value As String) As Date
        Return CDate(Value)
    End Function

    Protected Overridable Function CheckIfSubClassIsValid() As Boolean

    End Function

    Protected Sub AddBrokenRule(ByVal vMessage As String)
        m_colBrokenRules.Add(vMessage)
    End Sub

    Public Function isValid() As Boolean
        m_colBrokenRules.Clear()
        Return CheckIfSubClassIsValid()
    End Function


    Public Function BrokenRules() As List(Of String)
        Return m_colBrokenRules
    End Function

End Class


Public Class clsPaginateResult
    Public Data As IDataReader
    Public CurrentPage As Integer
    Public PageCount As Integer
    Public PageSize As Integer
    Public RecordCount As Integer
End Class

