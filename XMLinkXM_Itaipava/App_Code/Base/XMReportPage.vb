Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class XMReportPage

    Inherits XMWebPage

    Private m_lstNames As NameValueCollection
    Private m_lstParameters As NameValueCollection
    Private m_rootcontrol As Control = Nothing

    Public Sub New()
        Xceed.Chart.Server.Licenser.LicenseKey = "CHW42-YEW8B-LTYKP-2N2A"
    End Sub

    Public Property Root() As Control
        Get
            If Not m_rootcontrol Is Nothing Then
                Return m_rootcontrol
            ElseIf ViewState("Root") Is Nothing Then
                Return Me
            Else
                Dim ctrs As New List(Of Control)
                ctrs.AddRange(RecursedControls(Me))
                For Each c As Control In ctrs
                    If c.UniqueID = ViewState("Root") Then
                        m_rootcontrol = c
                        Return c
                    End If
                Next
                m_rootcontrol = Me
                Return Me
            End If
        End Get
        Set(ByVal value As Control)
            m_rootcontrol = value
            ViewState("Root") = value.UniqueID
        End Set
    End Property

    Public Overridable Function GetAllControls() As List(Of Control)
        Dim ctrs As New List(Of Control)
        ctrs.AddRange(RecursedControls(Root))
        Return ctrs
    End Function

    Protected Function RecursedControls(ByVal vControl As Control) As List(Of Control)
        Dim l As New List(Of Control)
        l.Add(vControl)
        For Each c As Control In vControl.Controls
            l.AddRange(RecursedControls(c))
        Next
        Return l
    End Function

    Public ReadOnly Property ControlsNames() As NameValueCollection
        Get
            Return m_lstNames
        End Get
    End Property

    Public Overridable Sub BindParameter(ByVal vName As String, ByVal vValue As String)

        For Each c As Control In GetAllControls()
            Dim strName As String = GetControlName(c.ID)
            If strName = vName Then
                If TypeOf (c) Is TextBox Then
                    With CType(c, TextBox)
                        .Text = vValue
                    End With
                ElseIf TypeOf (c) Is DropDownList Then
                    With CType(c, DropDownList)
                        setComboValue(c, vValue)
                    End With
                ElseIf TypeOf (c) Is RadioButton Then
                    With CType(c, RadioButton)
                        .Checked = (vValue = "1")
                    End With
                ElseIf TypeOf (c) Is CheckBox Then
                    With CType(c, CheckBox)
                        .Checked = (vValue = "1")
                    End With
                ElseIf TypeOf (c) Is ListControl Then
                    With CType(c, ListControl)
                        .ClearSelection()
                        For Each i As ListItem In .Items
                            If InStr("," & vValue & ",", "," & i.Value & ",") > 0 Then
                                i.Selected = True
                            End If
                        Next
                    End With
                End If
            End If
        Next
    End Sub

    Public Overridable Function GetControlName(ByVal vID As String) As String
        Dim strName As String = Nothing
        strName = m_lstNames(vID)
        If strName Is Nothing Then strName = vID
        Return strName
    End Function

    Public Overridable Function CreateParameter(ByVal c As Control) As NameValueCollection
        Dim l As New NameValueCollection
        Dim strName As String = GetControlName(c.ID)
        If TypeOf (c) Is TextBox Then
            With CType(c, TextBox)
                l.Add(strName, .Text)
            End With
        ElseIf TypeOf (c) Is DropDownList Then
            With CType(c, DropDownList)
                l.Add(strName, .SelectedValue)
            End With
        ElseIf TypeOf (c) Is RadioButton Then
            With CType(c, RadioButton)
                l.Add(strName, IIf(.Checked, 1, 0))
            End With
        ElseIf TypeOf (c) Is CheckBox Then
            With CType(c, CheckBox)
                l.Add(strName, IIf(.Checked, 1, 0))
            End With
        ElseIf TypeOf (c) Is ListControl Then
            With CType(c, ListControl)
                Dim strList As String = ""
                For Each i As ListItem In .Items
                    If i.Selected Then
                        strList &= i.Value & ","
                    End If
                Next
                If strList.EndsWith(",") Then strList = strList.Substring(0, strList.Length - 1)
                l.Add(strName, strList)
            End With

        End If
        Return l
    End Function

    Public Function CreateParameters() As NameValueCollection

        Dim params As New NameValueCollection
        For Each c As Control In GetAllControls()
            params.Add(CreateParameter(c))
        Next
        Return params
    End Function

    Public Function CreateParameters(ByVal p_Params As String) As NameValueCollection

        m_lstParameters = New NameValueCollection()
        If p_Params.StartsWith("?") Then p_Params = p_Params.Substring(1)

        Dim strItens() As String = p_Params.Split("&")
        Dim strItem As String

        For Each strItem In strItens
            If strItem.IndexOf("=") > 0 Then
                Dim Value() As String = Split(strItem, "=")
                m_lstParameters.Add(Value(0), Value(1))
                '                m_lstParameters.Add(Mid(objItem, 1, objItem.ToString().IndexOf("=")), Mid(objItem, objItem.ToString().IndexOf("=") + 2, objItem.ToString().Length()))
            End If
        Next

        Return m_lstParameters

    End Function

    Public Function MontaUrl() As String

        Dim strURL As String = "?"
        Dim l As NameValueCollection = CreateParameters()
        For i As Integer = 0 To l.Count - 1
            strURL &= l.Keys(i) & "=" & l.Item(i) & "&"
        Next
        If strURL.EndsWith("&") Then strURL = strURL.Substring(0, strURL.Length - 1)
        Return strURL

    End Function


    Public Function getParameterData(ByVal param As String) As String

        If m_lstParameters Is Nothing Then
            Throw New Exception("É necessário criar o array de parãmetros - CreateParameters(ByVal p_Params As String) ")
            Return ""
        End If
        Return m_lstParameters.Item(param)

    End Function

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            m_lstNames = New NameValueCollection
        Else
            m_lstNames = ViewState("lstNames")
        End If
    End Sub

    Public Sub CarregaControles()
        CarregaControles(Me.Request.QueryString)
    End Sub

    Public Sub CarregaControles(ByVal Values As String)

    End Sub

    Public Sub CarregaControles(ByVal Col As NameValueCollection)
        For i As Integer = 0 To Col.Count - 1
            BindParameter(Col.Keys(i), Col.Item(i))
        Next
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        ViewState("lstNames") = m_lstNames
    End Sub

    Private Function Xceed() As Object
        Throw New NotImplementedException
    End Function

End Class
