﻿Imports Classes

Partial Class Relatorios_status
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim rep As New clsRelatorio
            grdRelatorio.DataSource = rep.GetRelatorioStatus(Request("di"), Request("df"))
            grdRelatorio.DataBind()
            rep = Nothing
        End If
    End Sub
End Class
