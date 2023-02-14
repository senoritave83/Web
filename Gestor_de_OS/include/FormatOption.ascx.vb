Namespace Controls

    Partial Class FormatOption
        Inherits System.Web.UI.UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cboFormato.Attributes.Add("onClick", "fncChangeFormat(this, " & txtFormato.ClientID & ");")
            txtFormato.Attributes.Add("onKeyUp", "fncFormatEdited(" & cboFormato.ClientID & ", this);")
            If IsPostBack Then
                Formato = Request.Form(cboFormato.UniqueID)

            End If

        End Sub

        Public Property Formato() As String
            Get
                If cboFormato.SelectedIndex = 8 Then
                    Return txtFormato.Text
                Else
                    Return cboFormato.Items(cboFormato.SelectedIndex).Value
                End If
            End Get
            Set(ByVal value As String)
                txtFormato.Text = value
                txtFormato.Enabled = False
                If value = "" Then
                    cboFormato.SelectedIndex = 0
                Else
                    For i As Integer = 0 To cboFormato.Items.Count - 1
                        If cboFormato.Items(i).Value = value Then
                            cboFormato.SelectedIndex = i
                        End If
                    Next
                    If cboFormato.SelectedIndex < 1 Then
                        cboFormato.SelectedIndex = 8
                        cboFormato.Items.Item(8).Value = value
                        txtFormato.Enabled = True
                    End If
                End If
            End Set
        End Property

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            MyBase.Render(writer)
        End Sub
    End Class

End Namespace
