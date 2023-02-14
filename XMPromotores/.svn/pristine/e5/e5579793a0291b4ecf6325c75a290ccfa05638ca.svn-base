Imports System.Collections.Generic

Public Class XMWebEditPage
    Inherits XMWebPage

    Private m_colObservers As New List(Of IEditPageObserver)

    Public Sub AddObserver(ByVal obj As IEditPageObserver)
        m_colObservers.Add(obj)
    End Sub

    Public Sub RemoveObserver(ByVal obj As IEditPageObserver)
        m_colObservers.Remove(obj)
    End Sub

    Public Sub NotifyUpdate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
        For Each o As IEditPageObserver In m_colObservers
            o.NotifyUpdate(vEntidade, vID)
        Next
    End Sub

    Public Sub NotifyInflate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
        For Each o As IEditPageObserver In m_colObservers
            o.NotifyInflate(vEntidade, vID)
        Next
    End Sub

    Public Sub NotifyDelete(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
        For Each o As IEditPageObserver In m_colObservers
            o.NotifyDelete(vEntidade, vID)
        Next
    End Sub

    Public Interface IEditPageObserver
        Sub NotifyUpdate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
        Sub NotifyInflate(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
        Sub NotifyDelete(ByVal vEntidade As enTipoEntidade, ByVal vID As Integer)
    End Interface

End Class



