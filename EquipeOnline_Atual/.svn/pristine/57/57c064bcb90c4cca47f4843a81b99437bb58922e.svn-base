
Partial Class include_DataFormater
    Inherits System.Web.UI.UserControl

    Implements IFiltroControl

    Public Property Width() As Unit
        Get
            Return txtMaskFormater.Width
        End Get
        Set(ByVal value As Unit)
            txtMaskFormater.Width = value
        End Set
    End Property

    Public Property Height() As Unit
        Get
            Return txtMaskFormater.Height
        End Get
        Set(ByVal value As Unit)
            txtMaskFormater.Height = value
        End Set
    End Property

    Public Property MaxValue() As Integer
        Get
            Return txtMaskFormater.MaxLength
        End Get
        Set(ByVal value As Integer)
            txtMaskFormater.MaxLength = value
        End Set
    End Property

    Public Property CssClass() As String
        Get
            Return txtMaskFormater.CssClass
        End Get
        Set(ByVal value As String)
            txtMaskFormater.CssClass = value
        End Set
    End Property

    Public Property ValidatorCssClass() As String
        Get
            Return valReqMask.CssClass
        End Get
        Set(ByVal value As String)
            valReqMask.CssClass = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return txtMaskFormater.Text
        End Get
        Set(ByVal value As String)
            txtMaskFormater.Text = value
        End Set
    End Property

    Public ReadOnly Property UID() As String
        Get
            Return txtMaskFormater.ClientID
        End Get
    End Property

    Public Property Required() As Boolean
        Get
            Return valReqMask.Enabled
        End Get
        Set(ByVal value As Boolean)
            valReqMask.Enabled = value
        End Set
    End Property

    Public Property Value As Object Implements IFiltroControl.Value
        Get
            Return txtMaskFormater.Text
        End Get
        Set(ByVal value As Object)
            txtMaskFormater.Text = value
        End Set
    End Property

    Public Property Enabled As Boolean
        Get
            Return txtMaskFormater.Enabled
        End Get
        Set(ByVal value As Boolean)
            txtMaskFormater.Enabled = value
        End Set
    End Property
End Class
