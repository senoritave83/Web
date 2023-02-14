Imports System.Data.SqlClient

Public Class Horario
    Inherits XMProtectedPage
    Protected WithEvents rptGrid As System.Web.UI.WebControls.Repeater
    Protected WithEvents valRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboInicio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboFinal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnNovo As System.Web.UI.WebControls.Button
    Protected WithEvents btnApagar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected cls As clsAcesso

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
        'Put user code to initialize the page here
        cls = New clsAcesso(Me)
        If Not Page.IsPostBack Then
            Dim i, j As Integer
            cboInicio.Items.Clear()
            cboFinal.Items.Clear()
            For i = 0 To 23
                For j = 0 To 45 Step 15
                    cboInicio.Items.Add(New ListItem(i.ToString("00") & ":" & j.ToString("00"), i.ToString("00") & j.ToString("00")))
                    cboFinal.Items.Add(New ListItem(i.ToString("00") & ":" & j.ToString("00"), i.ToString("00") & j.ToString("00")))
                Next
            Next
            cboFinal.Items.Add(New ListItem("24:00", "2400"))
            BindGrid()
            btnNovo.Enabled = CheckPermission("Controle de Horários", "Adicionar Horário")
            btnApagar.Enabled = CheckPermission("Controle de Horários", "Apagar Horário")
        End If
    End Sub

    Public Sub BindGrid()
        rptGrid.DataSource = cls.Listar()
        rptGrid.DataBind()
    End Sub

    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        If CheckPermission("Controle de Horários", "Adicionar Horário") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        cls.Nome = txtNome.Text
        cls.HorarioDe = cboInicio.SelectedItem.Value
        cls.HorarioAte = cboFinal.SelectedItem.Value
        Try
            cls.Update()
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
        MostraGravado("horario.aspx")
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        cls.Delete(Request("chkSelected"))
        BindGrid()
    End Sub

End Class
