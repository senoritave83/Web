
Partial Class home_exportar
    Inherits XMProtectedPage


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            ViewState("Desc") = True

            Dim clsSta As New clsStatus()
            cboStatus.DataSource = clsSta.Listar
            cboStatus.DataBind()
            cboStatus.Items.Insert(0, New ListItem("todos", "0"))
            clsSta = Nothing


            ViewState("Status") = Request("Status") & ""

            If Not String.IsNullOrEmpty(Request("Status")) Then
                cboStatus.SelectedValue = Request("Status")
            End If

            If Not String.IsNullOrEmpty(Request("DataInicial")) Then
                txtDataInicial.Text = Request("DataInicial")
            Else
                txtDataInicial.Text = Now.AddDays(-7).ToString("dd/MM/yyyy")
            End If

            If Not String.IsNullOrEmpty(Request("DataFinal")) Then
                txtDataFinal.Text = Request("DataFinal")
            Else
                txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
            End If
            VerificaSeparador()

        End If

    End Sub

    Private Sub VerificaSeparador()
        If cboFormato.SelectedIndex = 0 Then
            If chkSeparador.SelectedIndex = 2 Then
                txtSeparador.Enabled = True
            Else
                txtSeparador.Enabled = False
            End If
            chkSeparador.Enabled = True
        Else
            chkSeparador.Enabled = False
            txtSeparador.Enabled = False
        End If

    End Sub

    Private Sub Exportar()
        Dim strText As String
        Dim strSeparador As String = ""
        Dim blnXML As Boolean = (cboFormato.SelectedItem.Value = "XML")
        If Not blnXML Then
            If chkSeparador.SelectedIndex = 2 Then
                strSeparador = txtSeparador.Text
            ElseIf chkSeparador.SelectedIndex = 0 Then
                strSeparador = ";"
            Else
                strSeparador = vbTab
            End If
        End If
        Dim exp As New clsOrdemServico()
        strText = exp.ExportarOrdens(SelectCliente1.Cliente, SelectResponsaveis1.Responsavel, txtDataInicial.Text, txtDataFinal.Text, cboStatus.SelectedValue, chkResposta.Checked, blnXML, strSeparador)
        Response.Clear()

        'Response.AddHeader("Content-Length", strText.Length)
        If blnXML Then
            Response.AppendHeader("Content-Type", "text/xml; charset=iso-8859-1")
            Response.ContentType = "text/xml"
        Else
            Response.AppendHeader("Content-Type", "text/html; charset=iso-8859-1")
            Response.ContentType = "text/plain"
        End If
        Response.AddHeader("Content-Disposition", "attachment; filename=ors_" & Now().ToString("yyyyMMdd-hhmmss") & IIf(blnXML, ".xml", ".txt"))
        Response.Write(strText)
        Response.End()
        exp = Nothing
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub


    Protected Sub cboFormato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFormato.SelectedIndexChanged
        VerificaSeparador()
    End Sub

    Protected Sub chkSeparador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSeparador.SelectedIndexChanged
        VerificaSeparador()
    End Sub
End Class
