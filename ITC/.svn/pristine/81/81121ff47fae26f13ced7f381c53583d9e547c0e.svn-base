
Imports System.Diagnostics.EventLog

Public Class clsModalidades

    Inherits DataClass

    Private m_IdModalidade As Integer
    Private m_Descricao As String

    Sub New()

    End Sub

    Public ReadOnly Property IdModalidade() As Integer
        Get
            Return m_IdModalidade
        End Get
    End Property


    Public ReadOnly Property Modalidade() As String
        Get
            Return m_Descricao
        End Get
    End Property

    Public Sub load(ByVal p_IdModalidade As Integer)

        Dim myData As DataSet
        myData = GetDataSet("SP_SE_MODALIDADE " & p_IdModalidade)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_IdModalidade = CLng(0 & row("IDMODALIDADE"))
        Me.m_Descricao = CStr(row("DESCRICAOMODALIDADE") & "")
    End Sub

    Public Function ListModalidades() As DataSet
        Try
            ListModalidades = GetDataSet("SP_SE_MODALIDADE")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

End Class
