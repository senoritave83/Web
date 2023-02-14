Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports XMSistemas.Web.Base
Imports System.Web

Namespace Classes

    Public MustInherit Class BaseClass
        Inherits DataClass

        Private m_colBrokenRules As New List(Of String)


        Public Overloads ReadOnly Property User() As XMPromotoresPrincipal
            Get
                Dim obj As Object = HttpContext.Current.User
                If Not TypeOf obj Is XMPromotoresPrincipal Then
                    obj = New XMPromotoresPrincipal(obj)
                    HttpContext.Current.User = obj
                End If
                Return MyBase.User
            End Get
        End Property

        Protected Sub LogEvent(ByVal vMessage As String, ByVal vCategory As String, ByVal vPriority As Integer, ByVal vEventType As TraceEventType)

        End Sub

        Protected Sub Log(ByVal vEntidade As String, ByVal vEvento As String, ByVal vMensagem As String)
            Audit(vEntidade, vEvento, vMensagem)
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


        Protected Overridable ReadOnly Property SecaoAtual() As String
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


    End Class

End Namespace
