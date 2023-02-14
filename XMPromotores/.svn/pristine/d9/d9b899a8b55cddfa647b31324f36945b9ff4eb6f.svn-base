Imports Microsoft.VisualBasic

Public Module Geral

    Public Enum enTipoEntidade As Integer
        Produto = 1
        Linha = 2
        Marca = 3
        Categoria = 4
        SubCategoria = 5
        Usuario = 6
        Loja = 7
        Cliente = 8
        Regiao = 9
        Pergunta = 10
        Pesquisa = 11
        TipoLoja = 12
        TipoJustificativa = 13
        TipoEvento = 14
        Shopping = 15
        Roteiro = 16
        MotivoUsoForm = 17
        MotivoFolga = 18
        MensagemDia = 19
        JustificativaRuptura = 20
        TipoTarefa = 21
        Propriedade = 22
    End Enum

    Public Function TipoPergunta(ByVal vTipoPergunta As Classes.clsPergunta.enTipoPergunta) As String

        Dim strReturn As String = ""

        Select Case vTipoPergunta
            Case Classes.clsPergunta.enTipoPergunta.Amostra
                strReturn = "Amostra"
            Case Classes.clsPergunta.enTipoPergunta.Categoria
                'strReturn = "Segmento"
                strReturn = SettingsExpression.GetProperty("caption", "Categoria", "Segmento")
            Case Classes.clsPergunta.enTipoPergunta.Loja
                strReturn = "Loja"
            Case Classes.clsPergunta.enTipoPergunta.Produto
                'strReturn = "Produto"
                strReturn = SettingsExpression.GetProperty("caption", "Produto", "Produto")
            Case Classes.clsPergunta.enTipoPergunta.SubCategoria
                'strReturn = "Categoria"
                strReturn = SettingsExpression.GetProperty("caption", "SubCategoria", "Categoria")
        End Select

        Return strReturn

    End Function

    Public Sub setComboValue(ByVal vCombo As Object, ByVal vValue As String)
        Dim it As ListItem
        Try
            it = vCombo.Items.FindByValue(vValue)
            If TypeOf vCombo Is HtmlControls.HtmlSelect Then
                vCombo.SelectedIndex = -1
            Else
                vCombo.ClearSelection()
            End If
            If Not it Is Nothing Then
                it.Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub setComboValues(ByVal vCombo As Object, ByVal vValue As String)
        Try
            Dim lst As New Generic.List(Of String)
            lst.AddRange(Split(vValue, ","))
            For Each it As ListItem In vCombo.Items
                it.Selected = lst.Contains(it.Value)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Function getComboValue(ByVal vCombo As Object, Optional ByVal vReturnAll As Boolean = False) As Integer

        Dim it As ListItem, strReturn As Integer

        For Each it In vCombo.Items
            If it.Selected Then
                strReturn = it.Value
                Exit For
            End If
        Next

        Return strReturn

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

    'Public Function verificaAcessoRelatorio(ByVal p_IdSegmento As Integer, ByRef xmPage As XMWebPage) As Boolean

    '    Dim blnReturn As Boolean = False
    '    Dim p_SegmentoRelatorios As String = AppSettings("SegmentoRelatorios").ToString()
    '    If p_SegmentoRelatorios <> "" Then
    '        Dim p_Obj As Object = p_SegmentoRelatorios.Split("||")
    '        For Each objItem As Object In p_Obj
    '            Dim objSegmento As Object = objItem.ToString().Split(",")
    '            If UBound(objSegmento) > 0 Then
    '                If objSegmento(0) = p_IdSegmento Then
    '                    If xmPage.User.IsInRole(objSegmento(1)) = True Or xmPage.User.isAdmin = True Then
    '                        blnReturn = True
    '                        Exit For
    '                    End If
    '                End If
    '            End If
    '        Next
    '    Else
    '        blnReturn = True
    '    End If

    '    Return blnReturn

    'End Function

End Module


