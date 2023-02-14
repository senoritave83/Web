Public Class Populate_Data

    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Try

                Dim p_Type As String = (Request("tp") & "")
                Dim p_Param As String = (Request("pr") & "")
                Dim p_Result As String = ""
                Dim rptRelatorios As Object

                Select Case p_Type

                    Case "CID" 'Cidades
                        Dim Cid As New clsCidades
                        p_Result = Cid.ListCidades(p_Param).GetXml()
                        Cid = Nothing

                End Select

                rptRelatorios = Nothing

                Response.Clear()
                Response.Expires = -1
                Response.ExpiresAbsolute = Now.AddSeconds(-1)
                'Response.ContentType = "text/xml"
                Response.Write(p_Result)

            Catch ex As System.Exception

                Response.Write("<xml><erro>" & ex.Message & "</erro></xml>")

            End Try

        End If
    End Sub


End Class
