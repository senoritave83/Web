Public MustInherit Class Top
    Inherits System.Web.UI.UserControl
    Protected WithEvents lblData As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserData As System.Web.UI.WebControls.Label

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


        Dim strNameOfTheWeek As String
        Select Case Date.Today.DayOfWeek
            Case 0
                strNameOfTheWeek = "Domingo"
            Case 1
                strNameOfTheWeek = "Segunda-Feira"
            Case 2
                strNameOfTheWeek = "Terça-Feira"
            Case 3
                strNameOfTheWeek = "Quarta-Feira"
            Case 4
                strNameOfTheWeek = "Quinta-Feira"
            Case 5
                strNameOfTheWeek = "Sexta-Feira"
            Case 6
                strNameOfTheWeek = "Sábado"
        End Select

        Dim strMonth As String
        Select Case Date.Today.Month
            Case 1
                strMonth = "Janeiro"
            Case 2
                strMonth = "Fevereiro"
            Case 3
                strMonth = "Março"
            Case 4
                strMonth = "Abril"
            Case 5
                strMonth = "Maio"
            Case 6
                strMonth = "Junho"
            Case 7
                strMonth = "Julho"
            Case 8
                strMonth = "Agosto"
            Case 9
                strMonth = "Setembro"
            Case 10
                strMonth = "Outubro"
            Case 11
                strMonth = "Novembro"
            Case 12
                strMonth = "Dezembro"
        End Select

        Dim strData As String
        strData = "São Paulo, " & strNameOfTheWeek & ", " & Right("00" & Day(Now), 2) & " de " & strMonth & " de " & Right("0000" & Year(Now), 4)

        lblData.Text = strData

    End Sub

    Public Sub Show(ByVal vText As String)
        Response.Write("<script language='javascript'>alert('" & vText & "'); </script>")
    End Sub

    Public Sub UserData(ByVal Dados As String)
        lblUserData.Text = Dados
    End Sub

End Class
