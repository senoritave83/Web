Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO

Public Class ajuda
    Inherits XMWebPage
    Protected WithEvents MyTree As System.Web.UI.WebControls.Literal
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm

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
        If Not Page.IsPostBack Then
            'Put user code to initialize the page here
            LoadTree()

        End If
    End Sub

    Private Sub LoadTree()

        Dim treedoc As New XPath.XPathDocument(Server.MapPath("inc/ajuda.xml"))
        Dim treeview As New XslTransform()
        treeview.Load(Server.MapPath("inc/treeview.xslt"))
        Dim sw As New StringWriter()
        'treeview.Transform(treedoc, Nothing, sw)
        Dim result As String = sw.ToString()
        result = result.Replace("xmlns:asp=""remove""", "")
        MyTree.Text = result
    End Sub

End Class
