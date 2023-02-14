
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Parametros
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Parametros de Venda"
        Dim cls As clsParametros

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsParametros()
            If Not Page.IsPostBack Then
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                Inflate()
            End If
        End Sub

        Protected Sub Inflate()
            Dim dr As Data.IDataReader = Nothing
            Try
                dr = cls.Listar(DataClass.enReturnType.DataReader)
                Do While dr.Read
                    If dr.GetString(0) = "ValorSug" Then
                        txtFatorSug.Text = dr.GetString(1)
                    ElseIf dr.GetString(0) = "ValorMax" Then
                        txtFatorMax.Text = dr.GetString(1)
                    End If
                Loop
                dr.Close()
            Catch ex As Exception
                If Not dr Is Nothing Then
                    dr.Dispose()
                    dr = Nothing
                End If
            End Try
        End Sub


        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If VerificaPermissao(SECAO, ACAO_EDITAR) = False Then
                Exit Sub
            End If
            If Page.IsValid Then
                cls.Update("ValorSug", txtFatorSug.Text)
                cls.Update("ValorMax", txtFatorMax.Text)
                Inflate()
                MostraGravado("~/Cadastros/Parametros.aspx")
            End If
        End Sub



    End Class

End Namespace

