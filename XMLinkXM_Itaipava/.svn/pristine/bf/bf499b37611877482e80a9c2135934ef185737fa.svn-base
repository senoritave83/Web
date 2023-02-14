Imports Classes

Namespace PESQUISAS

    Partial Class Relatorios_Performance_Pesquisa
        Inherits XMWebPage
        Protected Soma As New Somarizador
        Protected clsPesquisa As clsPesquisa
        Protected Const VW_IDPESQUISA As String = "IDPESQUISA"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then

                Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
                If vIDEmpresa <> User.IDEmpresa Then
                    If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                        vIDEmpresa = User.IDEmpresa
                    End If
                End If
            End If

            Dim vIDPesquisa As Integer

            Integer.TryParse(Request("IDPesquisa"), vIDPesquisa)
            ViewState(VW_IDPESQUISA) = vIDPesquisa
            clsPesquisa = New clsPesquisa

            clsPesquisa.Load(ViewState(VW_IDPESQUISA))
            lblPesquisa.Text = clsPesquisa.Pesquisa
            lblPeriodoPesquisa.Text = clsPesquisa.DataInicio & "&nbsp;at&eacute;&nbsp;" & clsPesquisa.DataFim

            Dim clsEmp As New clsEmpresa
            Dim strEmpresas As String = ""
            Dim dr As System.Data.SqlClient.SqlDataReader = clsEmp.ListarAutorizadas()
            While dr.Read
                If strEmpresas <> "" Then strEmpresas &= ","
                strEmpresas &= dr("IdEmpresa")
            End While
            clsEmp = Nothing

            Dim rep As New clsRelatorioPesquisa
            grdPerformancePesquisa.DataSource = rep.GetPerformancePesquisa(vIDPesquisa, strEmpresas)
            grdPerformancePesquisa.DataBind()
            rep = Nothing

            clsPesquisa = Nothing

        End Sub

    End Class


End Namespace
