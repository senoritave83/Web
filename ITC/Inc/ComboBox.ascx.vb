Imports System.Data.SqlClient

Public MustInherit Class ComboBox
    Inherits System.Web.UI.UserControl
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Private dsSource As DataSet
    Private strDataValueField As String
    Private strDataTextField As String

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CompareValidator1.ControlToValidate = DropDownList1.ID.ToString

    End Sub

    Public Sub AddItem(ByVal Value As Integer, ByVal Text As String)
        Dim ls As New ListItem()
        ls.Text = Text
        ls.Value = Value
        DropDownList1.Items.Add(ls)
    End Sub

    Public Property Enabled() As Boolean
        Get
            Return DropDownList1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            DropDownList1.Enabled = Value
        End Set
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return DropDownList1.Items.Count
        End Get
    End Property

    Public Sub Clear()
        DropDownList1.Items.Clear()
    End Sub

    Public Property AutoPostBack() As Boolean
        Get
            Return DropDownList1.AutoPostBack
        End Get
        Set(ByVal Value As Boolean)
            DropDownList1.AutoPostBack = Value
        End Set
    End Property

    Public Property EnableValidation() As Boolean
        Get
            Return CompareValidator1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            CompareValidator1.Enabled = Value
        End Set
    End Property

    Public Property CssClass() As String
        Get
            Return DropDownList1.CssClass
        End Get
        Set(ByVal Value As String)
            DropDownList1.CssClass = Value
        End Set
    End Property

    Public Property CssClassValidator() As String
        Get
            Return CompareValidator1.CssClass
        End Get
        Set(ByVal Value As String)
            CompareValidator1.CssClass = Value
        End Set
    End Property

    Public Overrides Sub DataBind()
        DropDownList1.Items.Clear()
        Dim ls As New ListItem()
        ls.Text = "Selecione..."
        ls.Value = 0
        DropDownList1.Items.Add(ls)
        With dsSource.Tables(0)
            Dim i As Integer
            For i = 0 To .Rows.Count - 1
                ls = New ListItem()
                ls.Text = .Rows(i).Item(strDataTextField)
                ls.Value = .Rows(i).Item(strDataValueField)
                DropDownList1.Items.Add(ls)
            Next
        End With
    End Sub

    Public Property ErrorMessage() As String
        Get
            Return CompareValidator1.ErrorMessage()
        End Get
        Set(ByVal Value As String)
            CompareValidator1.ErrorMessage = Value
        End Set
    End Property

    Public Property DataTextField() As String
        Get
            Return strDataTextField
        End Get
        Set(ByVal Value As String)
            strDataTextField = Value
        End Set
    End Property

    Public Property DataValueField() As String
        Get
            Return strDataValueField
        End Get
        Set(ByVal Value As String)
            strDataValueField = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return DropDownList1.SelectedItem.Text
        End Get
        Set(ByVal Value As String)
            DropDownList1.Items.FindByText(Value).Selected = True
        End Set
    End Property

    Public Property TabIndex() As Integer
        Get
            Return DropDownList1.TabIndex
        End Get
        Set(ByVal Value As Integer)
            DropDownList1.TabIndex = Value
        End Set
    End Property

    Public Property Value() As Integer
        Get
            With DropDownList1
                If .SelectedIndex >= 0 Then
                    Return .SelectedItem.Value
                Else
                    Return 0
                End If
            End With
        End Get
        Set(ByVal Value As Integer)
            With DropDownList1
                Try
                    Dim ls As Object
                    .ClearSelection()
                    .Items.FindByValue(Value).Selected = True
                    'If Not ls Is Nothing Then ls.selected = True
                Catch EX As Exception
                    .ClearSelection()
                End Try
            End With
        End Set

    End Property

    Public Property ValueString() As String
        Get
            With DropDownList1
                If .SelectedItem.Text <> "" Then
                    Return .SelectedItem.Text
                Else
                    Return ""
                End If
            End With
        End Get
        Set(ByVal ValueString As String)
            With DropDownList1
                Try
                    Dim ls As Object
                    .ClearSelection()
                    .Items.FindByValue(ValueString).Selected = True
                    'If Not ls Is Nothing Then ls.selected = True
                Catch
                    .ClearSelection()
                End Try
            End With
        End Set
    End Property

    Public Property DataSource() As DataSet
        Get
            Return dsSource
        End Get
        Set(ByVal Value As DataSet)
            dsSource = Value
        End Set
    End Property

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub
End Class
