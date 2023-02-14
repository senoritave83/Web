Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

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

    Public Sub setComboValue(ByVal vCombo As DropDownList, ByVal Value As String)
        Dim it As ListItem
        it = vCombo.Items.FindByValue(Value)
        vCombo.ClearSelection()
        If Not it Is Nothing Then
            it.Selected = True
        End If
    End Sub

    Public Function getComboValues(ByVal vCombo As Object) As String

        Dim it As ListItem, strReturn As String = ""

        For Each it In vCombo.Items
            If it.Selected Then
                If strReturn <> "" Then strReturn &= ","
                strReturn &= it.Value
            End If
        Next
        Return strReturn

    End Function

    Public Function checkDate(ByVal p_Date As String, Optional ByVal p_SQLFormat As Boolean = False, Optional ByVal p_ReturnNull As Boolean = False) As String
        If Not IsDate(p_Date) Then
            Return IIf(p_ReturnNull, "NULL", "")
        End If
        If p_SQLFormat Then
            Return "'" & Right("0000" & Year(p_Date), 4) & "-" & Right("00" & Month(p_Date), 2) & "-" & Right("00" & Day(p_Date), 2) & "'"
        Else
            Return Right("00" & Day(p_Date), 2) & "/" & Right("00" & Month(p_Date), 2) & "/" & Right("0000" & Year(p_Date), 4)
        End If
    End Function

    Public Sub setCheckValue(ByVal vCombo As Object, ByVal p_Value As String)
        Dim it As ListItem
        it = vCombo.Items.FindByValue(p_Value)
        vCombo.ClearSelection()
        If Not it Is Nothing Then
            it.Selected = True
        End If
    End Sub

    Public Function retornaCelula(ByVal p_Num As Integer) As String

        Const P_BASE As Integer = 26
        p_Num = p_Num - 1
        Dim p_Ret As String, objCel As Object = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(",")

        Dim p_tmpResultado As Integer = p_Num \ P_BASE, p_NumResto As Integer = p_Num Mod P_BASE
        p_Ret = objCel(p_NumResto)
        While p_tmpResultado > 0
            p_tmpResultado = p_tmpResultado - 1
            p_NumResto = (p_tmpResultado) Mod P_BASE
            p_tmpResultado = p_tmpResultado \ P_BASE
            p_Ret = objCel(p_NumResto) & p_Ret
        End While

        'Dim p_tmpNum As Integer = p_Num \ p_Val, p_NumRest As Integer = p_Num Mod p_Val, i As Integer = 0
        'If p_tmpNum > 0 Then
        '    While p_tmpNum > p_Val
        '        p_Ret = p_Ret & objCel((p_tmpNum - p_Val) - 1)
        '        p_tmpNum = p_tmpNum - p_Val
        '    End While
        '    p_Ret = p_Ret & objCel(p_tmpNum - 1)
        'End If
        'p_Ret = p_Ret & objCel(p_NumRest)
        '' p_Ret = objCel(p_tmpNum) & p_Ret
        Return p_Ret

    End Function

    Public Function excelExportFormatCells(ByVal p_Value As String) As String

        Dim p_NewValue As String = ""
        If IsNumeric(p_Value) Then
            p_Value = FormatNumber(p_Value, 2).ToString
            p_NewValue = p_Value.Replace(".", "").Replace(",", ".")
        End If
        Return p_NewValue

    End Function

    Public Function ValidaExpressao(ByVal Texto As String, ByVal Expressao As String) As Boolean
        Dim oExpressao As Regex = New Regex(Expressao, RegexOptions.IgnoreCase)
        Dim oValidador As Match = oExpressao.Match(Texto)
        Return oValidador.Success
    End Function

End Module

