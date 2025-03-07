﻿Imports Microsoft.VisualBasic
Imports XMSistemas.Web.Base

Public Class XMWebPage
    Inherits XMSistemas.Web.Base.XMBasePage

    '    Public Overloads ReadOnly Property User() As XMLinkPrincipal
    '        Get
    '            Dim obj As Object = Context.User
    '            If Not TypeOf obj Is XMLinkPrincipal Then
    '                obj = New XMLinkPrincipal(obj)
    '                Context.User = obj
    '            End If
    '            Return MyBase.User
    '        End Get
    '    End Property
    'End Class

    'Public Class XMLinkPrincipal
    '    Inherits XMPrincipal

    '    Sub New(ByVal source As XMPrincipal)
    '        MyBase.New(source.AllData, source.InternalName)
    '    End Sub

    '    Public ReadOnly Property IDVendedor() As Integer
    '        Get
    '            Return MyBase.AllData("idvendedor")
    '        End Get
    '    End Property

    Public ReadOnly Property SecaoAtual() As String
        Get
            Try
                If SiteMap.CurrentNode Is Nothing Then
                    Return ""
                End If
                Return SiteMap.CurrentNode.Item("secao") & ""
            Catch
                Return "Indefinida"
            End Try
        End Get
    End Property
End Class
