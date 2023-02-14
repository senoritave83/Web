Imports System.Web.Services

Namespace EOL.Pages.home

    Partial Class home_Default
        Inherits XMProtectedPage
        Protected clsOS As clsOrdemServico

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            clsOS = New clsOrdemServico()
            If Not IsPostBack Then

                'Dim hs As New HotSite
                'If hs.ExibirHotSite = False Then
                '    If Not ClientScript.IsStartupScriptRegistered("Hotsite") Then
                '        ClientScript.RegisterStartupScript(Me.GetType, "Hotsite", hs.ShowScript)
                '    End If
                '    'hs.HotSiteExibido()
                'Else
                Dim pp As New Popup
                If pp.ExibirPopUp = False Then
                    If Not ClientScript.IsStartupScriptRegistered("Popup") Then
                        ClientScript.RegisterStartupScript(Me.GetType, "Popup", pp.ShowScript)
                    End If
                End If
                'End If

                ViewState("Desc") = True

                Dim clsSta As New clsStatus()
                lstStatus.DataSource = clsSta.Listar
                lstStatus.DataBind()
                lstStatus.Items.Insert(0, New ListItem("Todos", ""))
                clsSta = Nothing

                ViewState("Status") = Request("Status") & ""

                If Not String.IsNullOrEmpty(Request("Status")) Then
                    lstStatus.SelectedValue = Request("Status")
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

                Me.RecuperaFiltro(SelectCliente1, SelectResponsaveis1, lstStatus, txtDataInicial, txtDataFinal)
                BindGrid()
                RefrestStatus()

                If Not ClientScript.IsStartupScriptRegistered("Script_Filtrar") Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "Script_Filtrar", "<script type='text/javascript'>fncFiltrar()</script>")
                End If

            End If

        End Sub

        Public Sub BindGrid()                        
            frmGrid.Attributes.Add("src", "listaos.aspx?type=1&cliente=" & SelectCliente1.Cliente & "&responsavel=" & SelectResponsaveis1.Responsavel & "&status=" & ViewState("Status") & "&txtDataInicial=" & txtDataInicial.Text & "&txtDataFinal=" & txtDataFinal.Text & "&strTipo=" & ViewState("_Tipo") & "&intCodigo=" & ViewState("_Codigo"))
        End Sub

        Public Sub RefrestStatus()
            Dim dr As IDataReader
            Dim strTemp As String
            dr = clsOS.StatusOrdem()
            If dr.Read Then
                If dr.GetValue(0) = 0 Then
                    strTemp = "Não há OS armazenadas, "
                ElseIf dr.GetValue(0) = 1 Then
                    strTemp = "Você tem 1 OS armazenada na <a href='pasta.aspx?" & "' class='cinza1'>Pasta</a> "
                Else
                    strTemp = "Você tem " & dr.GetValue(0) & " OS armazenada na <a href='pasta.aspx?" & "' class='cinza1'>Pasta</a> "
                End If
                If dr.GetValue(1) = 0 Then
                    strTemp &= " e nenhum agendamento."
                ElseIf dr.GetValue(1) = 1 Then
                    strTemp &= " e 1 <a href='agendamentos.aspx?" & "' class='cinza1'>Agendamento</a>, "
                Else
                    strTemp &= " e " & dr.GetValue(1) & " <a href='agendamentos.aspx?" & "' class='cinza1'>Agendamentos</a>, "
                End If

                ltrMessage.Text = strTemp
            End If
        End Sub

        Protected Sub lstStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstStatus.SelectedIndexChanged
            If lstStatus.SelectedIndex = 0 Then
                ViewState("Status") = ""
            Else
                ViewState("Status") = lstStatus.SelectedItem.Text
            End If
        End Sub

    End Class

End Namespace
