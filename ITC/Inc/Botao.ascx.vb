Public Class XMDefaultButton

    Inherits System.Web.UI.UserControl
    Implements IPostBackEventHandler

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btn As System.Web.UI.WebControls.Image

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim m_enButtonType As BUTTON_TYPE
    Dim m_stMessage As String
    Dim m_stMessageFailed As String

    Public Enum BUTTON_TYPE
        BUTTON_DEFAULT = 1
        BUTTON_QUESTION = 2
        BUTTON_VALIDATE = 3
    End Enum

    Public Event XMDefaultButton_Click()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strScript As String

        If m_enButtonType = BUTTON_TYPE.BUTTON_QUESTION Then
            strScript = "if(fncVerificaItemExclusao()){"
            strScript += "  if(confirm('" & m_stMessage & "')) "
            strScript += "      {"
            strScript += Page.GetPostBackEventReference(Me, "xmdefaultbutton_click") & ";"
            strScript += "      }"
            strScript += "} else alert('" & m_stMessageFailed & "');"
            btn.Attributes.Add("onClick", strScript)

        ElseIf m_enButtonType = BUTTON_TYPE.BUTTON_VALIDATE Then
            strScript = "if (typeof(Page_ClientValidate) == 'function')"
            strScript += "{"
            strScript += "  if(Page_ClientValidate())"
            strScript += "  {"
            strScript += "      if(confirm('" & m_stMessage & "')) "
            strScript += "      {"
            strScript += Page.GetPostBackEventReference(Me, "xmdefaultbutton_click") & ";"
            strScript += "      }"
            strScript += "  }"
            If m_stMessageFailed <> "" Then
                strScript += " else "
                strScript += "alert('" & m_stMessageFailed & "'); "
            End If
            strScript += "}"
            strScript += "else "
            strScript += "  if(confirm('" & m_stMessage & "')) "
            strScript += "  {"
            strScript += Page.GetPostBackEventReference(Me, "xmdefaultbutton_click") & ";"
            strScript += "  }"
            btn.Attributes.Add("onClick", strScript)

        Else
            btn.Attributes.Add("onClick", Page.GetPostBackEventReference(Me, "xmdefaultbutton_click"))

        End If

    End Sub

    Public Property ImageUrl() As String
        Get
            Return btn.ImageUrl
        End Get
        Set(ByVal Value As String)
            btn.ImageUrl = Value
        End Set
    End Property

    Public Property ButtonType() As BUTTON_TYPE
        Get
            Return m_enButtonType
        End Get
        Set(ByVal Value As BUTTON_TYPE)
            m_enButtonType = Value
        End Set
    End Property

    Public Property Message() As String
        Get
            Return m_stMessage
        End Get
        Set(ByVal Value As String)
            m_stMessage = Value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return m_stMessageFailed
        End Get
        Set(ByVal Value As String)
            m_stMessageFailed = Value
        End Set
    End Property

    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent

        RaiseEvent XMDefaultButton_Click()

    End Sub

End Class
