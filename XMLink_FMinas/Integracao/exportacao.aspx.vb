﻿Imports Classes
Imports System.Data



Partial Class integracao_exportacao
    Inherits XMWebPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            '***************************************************************
            'VERIFICANDO SE O USUÁRIO TEM PERMISSÃO DE ACESSAR ESTE MÓDULO
            '***************************************************************
            If Not VerificaPermissao("Integração", "Exportar pedidos") Then
                Response.Redirect("default.aspx")
            End If

            txtDataInicial.Text = Now.AddDays(-1).ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

        End If

    End Sub

End Class
