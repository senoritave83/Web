Imports Microsoft.VisualBasic

Namespace Settings


    Public Class clsXMLinkSettings

        Public Roteiro As New clsRoteiro

    End Class


    Public Class clsRoteiro
        Public PorDia As Boolean = True
        Public PorMes As Boolean = True
        Public PorAno As Boolean = False
        Public PorDiaSemana As Boolean = True
        Public PorSemanaMes As Boolean = True
        Public UtilizaVendedor As Boolean = True
        Public UtilizaVendedorMultiplo As Boolean = False
    End Class


End Namespace
