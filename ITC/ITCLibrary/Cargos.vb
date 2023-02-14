Imports System.Data.SqlClient

Imports System.Diagnostics.EventLog

Public Class clsCargos
    Inherits DataClass


    Public Sub New(ByVal vXMPage As XMWebPage)
        'TODO: Add your implementation code here...
        'Class Wizard: Generated code.
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Private Sub Clear()
    End Sub

    Private m_MensagemErro As String = ""
    Public ReadOnly Property MensagemErro()
        Get
            Return m_MensagemErro
        End Get
    End Property

    Public Function List() As DataSet
        Try
            m_MensagemErro = ""
            List = GetDataSet("SP_SE_CARGOS", m_MensagemErro)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function


End Class

