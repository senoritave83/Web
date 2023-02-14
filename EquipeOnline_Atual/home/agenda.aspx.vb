
Partial Class home_agenda
    Inherits XMProtectedPage
    Protected cls As clsAgenda

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsAgenda()
        If Not IsPostBack Then
            ViewState("Data") = Now()
            BindGrid()
        End If
    End Sub

    Public Function GetTarefas(ByVal vData As Date, ByVal vMinutes As Integer) As IDataReader
        Return cls.GetTarefas(vData, vMinutes)
    End Function

    Protected Sub BindGrid()
        lstAgenda.DataSource = cls.ListDia(ViewState("Data"))
        lstAgenda.DataBind()
        lblData.Text = CDate(ViewState("Data")).ToString("dd/MM/yyyy")
    End Sub

    Private Sub lnkNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        ViewState("Data") = CDate(ViewState("Data")).AddDays(1)
        BindGrid()
    End Sub

    Private Sub lnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
        ViewState("Data") = CDate(ViewState("Data")).AddDays(-1)
        BindGrid()
    End Sub
End Class
