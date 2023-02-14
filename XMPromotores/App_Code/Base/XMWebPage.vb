'Imports System.Security.Cryptography
'Imports Microsoft.VisualBasic
'Imports System.Drawing
'Imports System.Drawing.Color
'Imports System.Xml.Serialization
'Imports System.Configuration.ConfigurationManager
'Imports System.Web
'Imports System.Web.UI
'Imports System.Web.Security
'Imports Authentication
Imports Classes


Public Class XMWebPage
    Inherits XMSistemas.Web.Base.XMBasePage
    Public Const PAGESIZE As Integer = 20
    Private m_strPageName As String = ""

    Public Property PageName() As String
        Get
            Return m_strPageName
        End Get
        Set(ByVal value As String)
            m_strPageName = value
        End Set
    End Property

    Public Overloads ReadOnly Property User() As XMPromotoresPrincipal
        Get
            Dim obj As Object = Context.User
            If Not TypeOf obj Is XMPromotoresPrincipal Then
                obj = New XMPromotoresPrincipal(obj)
                Context.User = obj
            End If
            Return MyBase.User
        End Get
    End Property

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim strMasterPage As String = SettingsExpression.GetProperty("masterpage", "", "")
        If Not Me.MasterPageFile Is Nothing Then
            Me.Page.Trace.Write("MASTERPAGE: " & Me.MasterPageFile)
            If strMasterPage <> "" And Me.MasterPageFile.ToLower.EndsWith("xmpromotores.master") Then
                Me.MasterPageFile = strMasterPage
                Me.Page.Trace.Write("NEW MASTERPAGE: " & Me.MasterPageFile)
            End If
        Else
            Me.Page.Trace.Write("NO MASTER PAGE")
        End If
        Me.Theme = SettingsExpression.GetProperty("theme", "", "default")
    End Sub

End Class

Public Class XMPromotoresPrincipal
    Inherits XMSistemas.Web.Base.XMPrincipal

    Sub New(ByVal source As XMPrincipal)
        MyBase.New(source.AllData, source.InternalName)
    End Sub

    Public ReadOnly Property IDCargo() As Integer
        Get
            Return MyBase.AllData("idcargo")
        End Get
    End Property

    Public Sub Log(ByVal vEvento As String, ByVal vMensagem As String)
        'Audit(Me.Secao, vEvento, vMensagem)
    End Sub

End Class
