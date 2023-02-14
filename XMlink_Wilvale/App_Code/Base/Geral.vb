Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Configuration.ConfigurationManager

Public Module Geral

    Public Enum enValidateField
        CNPJ = 1
        Endereco = 2
    End Enum


    Public Function MustValidate(ByVal vEntidade As String, ByVal vCampo As enValidateField) As Boolean
        Dim strValue As String = AppSettings("Validade_" & vEntidade)
        If strValue <> "" Then
            Return True
        End If
        Return False
    End Function

    Public Function getComboValues(ByVal vCombo As Object, Optional ByVal vReturnAll As Boolean = False) As String

        Dim it As ListItem, strReturn As String = ""

        For Each it In vCombo.Items
            If it.Selected Then
                If strReturn <> "" Then strReturn &= ","
                strReturn &= it.Value
            End If
        Next

        If vReturnAll = True And strReturn = "" Then
            For Each it In vCombo.Items
                If strReturn <> "" Then strReturn &= ","
                strReturn &= it.Value
            Next
        End If

        Return strReturn

    End Function

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


    Public Function GetXML(ByVal obj As Object) As String

        Dim Output As StringWriter = New StringWriter(New StringBuilder())

        Dim Ret As String = ""

        Dim s As XmlSerializer = New XmlSerializer(obj.GetType())

        s.Serialize(Output, obj)

        Ret = Output.ToString().Replace("xmlns:xsd=""http://www.w3.org/2001/XMLSchema""", "")
        Ret = Ret.Replace("xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""", "")
        Ret = Ret.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "").Trim()
        Return Ret
    End Function

End Module


