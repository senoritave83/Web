Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports XMSistemas.Web.Base
Imports System.Web

Namespace Classes

    Public MustInherit Class BaseClass
        Inherits DataClass

        Private m_colBrokenRules As New List(Of String)

        Protected Sub LogEvent(ByVal vMessage As String, ByVal vCategory As String, ByVal vPriority As Integer, ByVal vEventType As TraceEventType)

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

    End Class

End Namespace
