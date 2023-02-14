Imports System.Web
Imports System.Web.SessionState

Public Class Global
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        Dim cfg As New System.Configuration.AppSettingsReader()
        Dim strPath As String
        strPath = cfg.GetValue("File_Directory", GetType(System.String)) & ""
        If strPath = "" Then
            strPath = Request.ServerVariables("APPL_PHYSICAL_PATH") & "files\"
        Else
            strPath = Server.MapPath(strPath)
            If Not strPath.EndsWith("\") Then strPath &= "\"
        End If
        Application.Add("Path", strPath)
        Application.Add("cnStr", cfg.GetValue("cnStr", GetType(System.String)))
        Application.Add("IDEmpresa", cfg.GetValue("IDEmpresa", GetType(System.Int32)))
        On Error Resume Next
        Application.Add("chave", cfg.GetValue("chave", GetType(System.String)))
        cfg = Nothing
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
