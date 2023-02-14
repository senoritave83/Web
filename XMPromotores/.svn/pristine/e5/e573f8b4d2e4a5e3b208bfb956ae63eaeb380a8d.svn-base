Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings.subclasses

    Public Class Roteiro
        
#Region "Declarations"
        Protected m_blnUtilizaVendedor As Boolean
        Protected m_blnUtilizaVendedorMultiplo As Boolean
        Protected m_blnPorDia As Boolean
        Protected m_blnPorMes As Boolean
        Protected m_blnPorAno As Boolean
        Protected m_blnPorDiaSemana As Boolean
        Protected m_blnPorSemanaMes As Boolean
#End Region


#Region "Properties"

        Public Overridable Property UtilizaVendedor() As Boolean
            Get
                Return m_blnUtilizaVendedor
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaVendedor = Value
            End Set
        End Property

        Public Overridable Property UtilizaVendedorMultiplo() As Boolean
            Get
                Return m_blnUtilizaVendedorMultiplo
            End Get
            Set(ByVal Value As Boolean)
                m_blnUtilizaVendedorMultiplo = Value
            End Set
        End Property

        Public Overridable Property PorDia() As Boolean
            Get
                Return m_blnPorDia
            End Get
            Set(ByVal Value As Boolean)
                m_blnPorDia = Value
            End Set
        End Property

        Public Overridable Property PorMes() As Boolean
            Get
                Return m_blnPorMes
            End Get
            Set(ByVal Value As Boolean)
                m_blnPorMes = Value
            End Set
        End Property

        Public Overridable Property PorAno() As Boolean
            Get
                Return m_blnPorAno
            End Get
            Set(ByVal Value As Boolean)
                m_blnPorAno = Value
            End Set
        End Property

        Public Overridable Property PorDiaSemana() As Boolean
            Get
                Return m_blnPorDiaSemana
            End Get
            Set(ByVal Value As Boolean)
                m_blnPorDiaSemana = Value
            End Set
        End Property

        Public Overridable Property PorSemanaMes() As Boolean
            Get
                Return m_blnPorSemanaMes
            End Get
            Set(ByVal Value As Boolean)
                m_blnPorSemanaMes = Value
            End Set
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Friend Sub New(ByVal dr As IDataReader)
            If Not dr Is Nothing Then
                If dr.IsDBNull(dr.GetOrdinal("RoteiroUtilizaVendedor")) Then
                    m_blnUtilizaVendedor = False
                Else
                    m_blnUtilizaVendedor = dr.GetBoolean(dr.GetOrdinal("RoteiroUtilizaVendedor"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroUtilizaVendedorMultiplo")) Then
                    m_blnUtilizaVendedorMultiplo = False
                Else
                    m_blnUtilizaVendedorMultiplo = dr.GetBoolean(dr.GetOrdinal("RoteiroUtilizaVendedorMultiplo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroPorDia")) Then
                    m_blnPorDia = False
                Else
                    m_blnPorDia = dr.GetBoolean(dr.GetOrdinal("RoteiroPorDia"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroPorMes")) Then
                    m_blnPorMes = False
                Else
                    m_blnPorMes = dr.GetBoolean(dr.GetOrdinal("RoteiroPorMes"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroPorAno")) Then
                    m_blnPorAno = False
                Else
                    m_blnPorAno = dr.GetBoolean(dr.GetOrdinal("RoteiroPorAno"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroPorDiaSemana")) Then
                    m_blnPorDiaSemana = False
                Else
                    m_blnPorDiaSemana = dr.GetBoolean(dr.GetOrdinal("RoteiroPorDiaSemana"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("RoteiroPorSemanaMes")) Then
                    m_blnPorSemanaMes = False
                Else
                    m_blnPorSemanaMes = dr.GetBoolean(dr.GetOrdinal("RoteiroPorSemanaMes"))
                End If
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Friend Sub SetParameters(ByRef prms As SqlParameterCollection)
            Dim ret As New Generic.List(Of SqlParameter)
            prms.Add("@ROTEIROUTILIZAVENDEDOR", SqlDbType.Bit).Value = m_blnUtilizaVendedor
            prms.Add("@ROTEIROUTILIZAVENDEDORMULTIPLO", SqlDbType.Bit).Value = m_blnUtilizaVendedorMultiplo
            prms.Add("@ROTEIROPORDIA", SqlDbType.Bit).Value = m_blnPorDia
            prms.Add("@ROTEIROPORMES", SqlDbType.Bit).Value = m_blnPorMes
            prms.Add("@ROTEIROPORANO", SqlDbType.Bit).Value = m_blnPorAno
            prms.Add("@ROTEIROPORDIASEMANA", SqlDbType.Bit).Value = m_blnPorDiaSemana
            prms.Add("@ROTEIROPORSEMANAMES", SqlDbType.Bit).Value = m_blnPorSemanaMes
        End Sub


        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_blnUtilizaVendedor = False
            m_blnUtilizaVendedorMultiplo = False
            m_blnPorDia = False
            m_blnPorMes = False
            m_blnPorAno = False
            m_blnPorDiaSemana = False
            m_blnPorSemanaMes = False
        End Sub

#End Region

    End Class
End Namespace