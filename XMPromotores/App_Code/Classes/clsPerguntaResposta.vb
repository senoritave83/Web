

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
        Protected m_indAcao As Byte
        Protected m_intAcaoValor As Integer

        Public Enum enRespostaAcao As Byte
            Nenhuma = 0
            Pular = 1
            Finalizar = 2
        End Enum
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

        Public Overridable Property Acao() As enRespostaAcao
            Get
                Return m_indAcao
            End Get
            Set(ByVal Value As enRespostaAcao)
                m_indAcao = Value
            End Set
        End Property

        Public Overridable Property AcaoValor() As Integer
            Get
                Return m_intAcaoValor
            End Get
            Set(ByVal Value As Integer)
                m_intAcaoValor = Value
            End Set
        End Property



#End Region

    End Class

    Public Class clsPerguntaRespostaCollection
        Inherits Collections.Generic.List(Of clsPerguntaResposta)

        Public Overloads Sub Add(ByVal vResposta As String, ByVal vUnica As Boolean, ByVal vAcao As clsPerguntaResposta.enRespostaAcao, ByVal vAcaoValor As Integer)
            Dim rep As New clsPerguntaResposta
            rep.Resposta = vResposta
            rep.Unica = vUnica
            rep.IDResposta = MyBase.Count() + 1
            rep.Acao = vAcao
            rep.AcaoValor = vAcaoValor
            MyBase.Add(rep)
        End Sub
    End Class

End Namespace

