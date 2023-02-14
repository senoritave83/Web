

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsPerguntaResposta
		Inherits BaseClass

#Region "Declarations"
        Protected m_intIDResposta As Integer
        Protected m_strResposta As String
        Protected m_varUnica As Boolean

#End Region

#Region "Properties"
        Public Overridable Property IDResposta() As Integer
            Get
                Return m_intIDResposta
            End Get
            Set(ByVal value As Integer)
                m_intIDResposta = value
            End Set
        End Property

        Public Overridable Property Resposta() As String
            Get
                Return m_strResposta
            End Get
            Set(ByVal Value As String)
                m_strResposta = Value
            End Set
        End Property

        Public Overridable Property Unica() As Boolean
            Get
                Return m_varUnica
            End Get
            Set(ByVal Value As Boolean)
                m_varUnica = Value
            End Set
        End Property


#End Region

    End Class

    Public Class clsPerguntaRespostaCollection
        Inherits Collections.Generic.List(Of clsPerguntaResposta)

        Public Overloads Sub Add(ByVal vResposta As String, ByVal vUnica As Boolean)
            Dim rep As New clsPerguntaResposta
            rep.Resposta = vResposta
            rep.Unica = vUnica
            rep.IDResposta = MyBase.Count() + 1
            MyBase.Add(rep)
        End Sub
    End Class

End Namespace

