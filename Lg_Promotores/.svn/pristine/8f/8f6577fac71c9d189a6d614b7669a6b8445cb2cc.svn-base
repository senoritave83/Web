Imports Classes
Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class reports_rptPrecos
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            carregaClientes()
            carregaCategorias()
            carregaTipoLojas()
            carregaRegioes()
            carregaShopping()

        End If

    End Sub

    Private Sub carregaClientes()

        lstClientes.Items.Clear()
        lstLojas.Items.Clear()

        Dim clsCli As clsCliente
        clsCli = New clsCliente
        lstClientes.DataSource = clsCli.Listar(DataClass.enReturnType.DataReader)
        lstClientes.DataBind()
        clsCli = Nothing

    End Sub

    Private Sub carregaLojas()

        Dim p_Clientes As String = getComboValues(lstClientes)

        Dim clsLoj As clsLoja
        clsLoj = New clsLoja
        lstLojas.DataSource = clsLoj.Listar(p_Clientes, DataClass.enReturnType.DataReader)
        lstLojas.DataBind()
        clsLoj = Nothing

    End Sub

    Private Sub carregaShopping()

        Dim clsShop As clsShopping
        clsShop = New clsShopping
        lstShopping.DataSource = clsShop.Listar(DataClass.enReturnType.DataReader)
        lstShopping.DataBind()
        lstShopping.Items.Insert(0, New ListItem("Loja de Rua", "0"))
        clsShop = Nothing

    End Sub

    Private Sub carregaCategorias()

        lstCategoria.Items.Clear()
        lstSubCategoria.Items.Clear()
        lstProduto.Items.Clear()

        Dim clsCat As clsCategoria
        clsCat = New clsCategoria
        lstCategoria.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
        lstCategoria.DataBind()
        clsCat = Nothing

    End Sub

    Private Sub carregaSubCategorias()

        lstSubCategoria.Items.Clear()
        lstProduto.Items.Clear()

        Dim p_Categorias As String = getComboValues(lstCategoria)

        Dim clsSubCat As clsSubCategoria
        clsSubCat = New clsSubCategoria
        lstSubCategoria.DataSource = clsSubCat.Listar(p_Categorias, DataClass.enReturnType.DataReader)
        lstSubCategoria.DataBind()
        clsSubCat = Nothing

    End Sub

    Private Sub carregaProdutos()

        Dim p_SubCategorias As String = getComboValues(lstSubCategoria)

        Dim clsProd As clsProduto
        clsProd = New clsProduto
        lstProduto.DataSource = clsProd.Listar(p_SubCategorias, DataClass.enReturnType.DataReader)
        lstProduto.DataBind()
        clsProd = Nothing

    End Sub

    Private Sub carregaTipoLojas()

        Dim clsTipo As clsTipoLoja, strScript As String = "", i As Integer = 0

        ltScriptTipoLoja.Text = ""
        clsTipo = New clsTipoLoja

        Dim dr As SqlDataReader = clsTipo.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_TipoLoja() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkTipoLoja_" & i & ".checked==true) m_Value+='" & dr("IdTipoLoja") & ",';" & vbCrLf
            chkTipoLoja.Items.Add(New ListItem(dr("TipoLoja"), dr("IdTipoLoja")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptTipoLoja.Text = strScript

        End If

        strScript = ""
        clsTipo = Nothing

    End Sub

    Private Sub carregaRegioes()

        Dim clsReg As clsRegiao, strScript As String = "", i As Integer = 0

        ltScriptRegiao.Text = ""
        clsReg = New clsRegiao

        Dim dr As SqlDataReader = clsReg.Listar(DataClass.enReturnType.DataReader)
        While dr.Read
            If strScript = "" Then
                strScript = "<script language='javascript'>" & vbCrLf
                strScript &= "function XM_RadioButtonValue_Regiao() {" & vbCrLf
                strScript &= "var m_Value = '';" & vbCrLf
            End If
            strScript &= "if(document.aspnetForm.ctl00_ContentPlaceHolder1_chkRegiao_" & i & ".checked==true) m_Value+='" & dr("IdRegiao") & ",';" & vbCrLf
            chkRegiao.Items.Add(New ListItem(dr("Regiao"), dr("IdRegiao")))
            i += 1
        End While
        If strScript <> "" Then
            strScript &= "return m_Value;" & vbCrLf
            strScript &= "}" & vbCrLf
            strScript &= "</script>" & vbCrLf
            ltScriptRegiao.Text = strScript

        End If

        strScript = ""
        clsReg = Nothing

    End Sub

    Protected Sub btnVisLojas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisLojas.Click
        carregaLojas()
    End Sub

    Protected Sub btnVisSubCat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisSubCat.Click
        carregaSubCategorias()
    End Sub

    Protected Sub btnVisProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisProd.Click
        carregaProdutos()
    End Sub
End Class
