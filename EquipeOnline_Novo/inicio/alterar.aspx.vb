
Imports System.Configuration.ConfigurationManager

Partial Class inicio_alterar
    Inherits XMWebPage

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim dts As DataSet = Nothing
        Dim strPath As String = AppSettings("logfiles") & ""
        If AppSettings("checkpim").ToLower() = "true" Then
            If isValidLoginClient(txtCodigo.Text, txtPin.Text, dts) Then
                If strPath <> "" Then
                    Try
                        dts.WriteXml(strPath & txtCodigo.Text & ".txt", XmlWriteMode.IgnoreSchema)
                    Catch ex As Exception
                    End Try
                End If
                AlterarEmail()
            Else
                lblMensagem.Text = "Codigo inv&aacute;lido!"
                lblMensagem.Visible = True
            End If
        Else
            AlterarEmail()
        End If
    End Sub

    Private Sub AlterarEmail()
        Dim cls As New clsEmpresa()
        plhMensagem.Visible = True
        plhIdentificacao.Visible = False
        If cls.AlterarEmail(txtCodigo.Text, txtEmail.Text) Then
            lblMensagem.Text = "E-mail alterado!"
        Else
            lblMensagem.Text = "N&atilde;o foi poss&iacute;vel alterar o e-mail"
        End If
    End Sub


    Public Function isValidLoginClient(ByVal BscsCode As String, ByVal Password As String, ByRef dtsDados As DataSet) As Boolean
        Dim objValidaCliente As nextel.ws.wsCliente = Nothing
        Dim blnRet As Boolean = False

        Try
            objValidaCliente = New nextel.ws.wsCliente()
            dtsDados = New DataSet()

            'Realiza a valida&ccedil;&atilde;o do Cliente (Se true, o cliente est&aacute; validado)

            blnRet = objValidaCliente.ValidaCliente("", BscsCode, Password, dtsDados)

        Catch ex As Exception

        Finally
            If Not objValidaCliente Is Nothing Then
                objValidaCliente.Dispose()
            End If
            objValidaCliente = Nothing
        End Try

        Return blnRet

    End Function




End Class
