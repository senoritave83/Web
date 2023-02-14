Imports System.Data.SqlClient

Public Class Home

    Inherits XMWebPage

    Protected ChartImage As System.Web.UI.WebControls.Image
    Protected WithEvents dtgSaibaMais As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgAnalise As DataGrid

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

        Dim SaibaMais As clsSaibaMais
        SaibaMais = New clsSaibaMais

        dtgSaibaMais.DataSource = SaibaMais.List()
        dtgSaibaMais.DataBind()



        Dim AnaliseMensal As clsAnaliseMensal
        AnaliseMensal = New clsAnaliseMensal

        dtgAnalise.DataSource = AnaliseMensal.List()
        dtgAnalise.DataBind()


        If 1 = 2 Then
            Dim dc As New DataClass
            Dim ds As DataSet
            Dim dr As DataRow
            Dim xValues As String, yValues As String

            ds = dc.GetDataSet("SP_SE_GRAFICO_ABERTURA")

            For Each dr In ds.Tables(0).Rows
                xValues += dr(0)
                yValues += dr(1)
            Next

            ChartImage.ImageUrl = "XMChartGenerator.aspx?" + "xvalues=3/11/2003 12:00|3/11/2003 13:00|3/11/2003 14:00|3/11/2003 15:00|3/11/2003 16:00|3/11/2003 17:00&yvalues=61|84|199|99|37|60"
            'ChartImage.ImageUrl = "XMChartGenerator.aspx?" + "xValues=Beverages|Condiments|Confections|Dairy Products|Grains/Cereals|Meat/Poultry|Produce|Seafood&yValues=267868,180522919|106047,084989548|167357,224831581|234507,285217285|95744,587474823|163022,359088898|99984,5800685882|131261,73742485"
        End If
        'ChartImage.Visible = False

    End Sub

End Class
