Public Module ITC
    Public Function XMCheckDate(ByVal p_Date As String, Optional ByVal p_SQLFormat As Boolean = False, Optional ByVal p_ReturnNull As Boolean = False) As String
        If Not IsDate(p_Date) Then
            Return IIf(p_ReturnNull, "NULL", "")
        End If
        If p_SQLFormat Then
            Return "'" & Right("0000" & Year(p_Date), 4) & "-" & Right("00" & Month(p_Date), 2) & "-" & Right("00" & Day(p_Date), 2) & "'"
        Else
            Return Right("00" & Day(p_Date), 2) & "/" & Right("00" & Month(p_Date), 2) & "/" & Right("0000" & Year(p_Date), 4)
        End If
    End Function

    Public Function XMCheckValue(ByVal p_Value As String) As String
        If Not IsNumeric(p_Value) Then
            Return ""
        End If
        Return p_Value.Replace(".", "").Replace(",", ".")
    End Function

    Public Function XMSQLFormat(ByVal p_String As String) As String
        Return "'" & p_String.Replace("'", "''") & "'"
    End Function

    Public Function XMGetListItemValue(ByRef vCombo As Object) As Integer
        Try
            Return vCombo.SelectedValue
        Catch ex As System.Exception
            Return 0
        End Try
    End Function

    Public Function XMGetListItemValues(ByRef vCombo As Object) As String
        Try
            Dim obj As ListItem, p_ReturnValue As String = ""
            For Each obj In vCombo.Items
                If obj.Selected Then
                    If p_ReturnValue <> "" Then p_ReturnValue &= ","
                    p_ReturnValue &= obj.Value
                End If
            Next
            Return p_ReturnValue
        Catch ex As System.Exception
            Return ""
        End Try
    End Function

    Public Function XMGetListItemValuesSum(ByRef vCombo As Object) As Integer
        Try
            Dim obj As ListItem, p_ReturnValue As Integer
            For Each obj In vCombo.Items
                If obj.Selected Then
                    p_ReturnValue += obj.Value
                End If
            Next
            Return p_ReturnValue
        Catch ex As System.Exception
            Return 0
        End Try
    End Function

    Public Function XMSetListItemValues(ByRef vCombo As Object, ByVal p_Values As String) As Boolean
        Try
            Dim objValues As Object = p_Values.Split(",")
            With vCombo
                .ClearSelection()
                Dim objItem As Object
                For Each objItem In objValues
                    .Items.FindByValue(objItem).Selected = True
                Next
            End With
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Function XMSetListItemValue(ByRef vCombo As Object, ByVal p_Value As Integer) As Boolean
        Try
            With vCombo
                .ClearSelection()
                .Items.FindByValue(p_Value).Selected = True
            End With
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Function XMItensSelecionados(ByRef obj As Object) As String

        Dim p_Itens As String = ""
        Dim lst As ListItem
        For Each lst In obj.Items
            If lst.Selected Then
                p_Itens &= lst.Value & ","
            End If
        Next
        Return p_Itens

    End Function

    Public Function XMExcelExportFormatCells(ByVal p_Value As String) As String

        Dim p_NewValue As String = ""
        If IsNumeric(p_Value) Then
            p_Value = FormatNumber(p_Value, 2).ToString
            p_NewValue = p_Value.Replace(".", "").Replace(",", ".")
        End If
        Return p_NewValue

    End Function


    Public Function fncRetornaCelula(ByVal p_Num As Integer) As String

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

    Public Sub XMSetCheckBoxListItems(ByRef chk As CheckBoxList, ByVal ds As DataSet, ByVal p_TestFieldName As String)

        Dim i As Integer = 0
        chk.Items.Clear()
        If ds.Tables.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim lst As New ListItem(ds.Tables(0).Rows(i).Item(chk.DataTextField), ds.Tables(0).Rows(i).Item(chk.DataValueField))
                If p_TestFieldName <> "" Then lst.Selected = IIf(ds.Tables(0).Rows(i).Item(p_TestFieldName) = 1, True, False)
                chk.Items.Add(lst)
            Next
        End If

    End Sub

    Public Function XMSelectColor(ByVal p_Type As Integer) As String

        Dim p_Cor As String = ""

        Try

            Dim xmc As New XMLConfig, p_objCores As Object
            p_objCores = xmc.GetValue("CoresRel", "").Split(",")
            p_Cor = p_objCores(p_Type)

        Catch ex As System.Exception
            p_Cor = "black"
        End Try
        Return p_Cor

    End Function



    ''' <summary>
    ''' Função Responsável por tranformar a data padrão em data interna
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function _setDateTimePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("yyyy-MM-dd HH:mm:ss")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por tranformar a data interna em uma data padrão
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function _getDateTimePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("dd/MM/yyyy HH:mm:ss")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por tranformar a data interna em uma data padrão
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function _getDatePropertyValue(ByVal Value As String) As String
        If IsDate(Value) Then
            Return CDate(Value).ToString("dd/MM/yyyy")
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Função Responsável por transformar o valor gravado no SQL em formato string interno 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function _getDateTimeDBValue(ByVal Value As Date) As String
        Return Value.ToString("yyyy-MM-dd hh:mm:ss")
    End Function

    ''' <summary>
    ''' Função Responsável por transformar o valor no formato string interno em um valor Date 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function _setDateTimeDBValue(ByVal Value As String) As Date
        Return CDate(Value)
    End Function

End Module