Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Drawing

Imports VM.xPort

Public Module Geral

    Public Function GetNomeMes(ByVal p_Mes As Integer) As String
        Dim p_NomeMes As String = ""
        Select Case p_Mes
            Case 1
                p_NomeMes = "Janeiro"
            Case 2
                p_NomeMes = "Fevereiro"
            Case 3
                p_NomeMes = "Março"
            Case 4
                p_NomeMes = "Abril"
            Case 5
                p_NomeMes = "Maio"
            Case 6
                p_NomeMes = "Junho"
            Case 7
                p_NomeMes = "Julho"
            Case 8
                p_NomeMes = "Agosto"
            Case 9
                p_NomeMes = "Setembro"
            Case 10
                p_NomeMes = "Outubro"
            Case 11
                p_NomeMes = "Novembro"
            Case 12
                p_NomeMes = "Dezembro"
        End Select

        Return p_NomeMes

    End Function

    Public Function fncDiferencaEntreDatas(ByVal vData1 As String, ByVal vData2 As String) As String

        Dim strReturn As String = ""
        Dim intSegundos As Integer = 0
        Dim vHoras As String = 0
        Dim vMinutos As Integer = 0
        Dim vSegundos As Integer = 0

        If IsDate(vData1) And IsDate(vData2) Then

            Dim m_dtmInicio As New DateTime(Year(vData1), Month(vData1), Day(vData1), Hour(vData1), Minute(vData1), Second(vData1))
            Dim m_dtmFim As New DateTime(Year(vData2), Month(vData2), Day(vData2), Hour(vData2), Minute(vData2), Second(vData2))

            Dim dif As TimeSpan = m_dtmFim.Subtract(m_dtmInicio)
            Dim dias As Integer = dif.Days
            Dim horas As Integer = dif.Hours
            Dim minutos As Integer = dif.Minutes
            Dim segundos As Integer = dif.Seconds

            strReturn = IIf(horas > 0, horas & " Hora" & IIf(horas > 1, "s", ""), "") & " " & _
                        IIf(minutos > 0, minutos & " Minuto" & IIf(minutos > 1, "s", ""), "") & " " & _
                        IIf(segundos > 0, segundos & " Segundo" & IIf(segundos > 1, "s", ""), "")

        End If

        Return strReturn

    End Function

    Public Function fncTempoRestanteDias(ByVal vQuantidade As Integer, _
                                         ByVal vDiasPassados As Integer, _
                                         ByVal vTotalPesquisas As Integer) As String
        Dim strReturn As String = ""
        Dim vDiasTotal As Integer = 0

        If vQuantidade > 0 And vDiasPassados > 0 And vTotalPesquisas > 0 Then

            vDiasTotal = (vTotalPesquisas * vDiasPassados) / vQuantidade
            strReturn = Now().AddDays(vDiasTotal - vDiasPassados).ToShortDateString()

        End If

        Return strReturn

    End Function

End Module

Public Module REPORTS



End Module