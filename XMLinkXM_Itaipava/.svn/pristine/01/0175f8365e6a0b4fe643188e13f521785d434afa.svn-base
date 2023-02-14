Imports Classes
Imports System.Data
Imports XMSistemas.Web.XMGMapControl

Partial Class Relatorios_Mapa
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As New DataSet
        With dt

            .Tables.Add("Dados")

            .Tables("Dados").Columns.Add(New DataColumn("Sequencia"))
            .Tables("Dados").Columns.Add(New DataColumn("Latitude"))
            .Tables("Dados").Columns.Add(New DataColumn("Longitude"))
            .Tables("Dados").Columns.Add(New DataColumn("Descricao"))

            Dim dr As DataRow = .Tables("Dados").NewRow()
            dr("Sequencia") = 0
            dr("Latitude") = Request("lat") & ""
            dr("Longitude") = Request("lon") & ""
            dr("Descricao") = Request("des") & ""

            .Tables("Dados").Rows.Add(dr)

        End With

        XMMapViewer1.Title = Request("tit") & ""
        XMMapViewer1.DataSource = dt
        XMMapViewer1.DataBind()

    End Sub

End Class
