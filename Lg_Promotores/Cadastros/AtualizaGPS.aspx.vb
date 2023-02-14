Imports Classes

Partial Class Cadastros_AtualizaGPS
    Inherits XMWebPage

    Protected Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim strURL As String = System.Configuration.ConfigurationManager.AppSettings("apiGoogleMaps") & ""

        Dim gps As New AtualizaGPS
        Dim ds As System.Data.DataSet = gps.getLojas

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

            Dim vIdLoja As Integer = ds.Tables(0).Rows(i).Item("loj_Loja_int_PK")
            Dim strEndereco As String = ds.Tables(0).Rows(i).Item("loj_Endereco_chr")
            Dim strNumero As String = ds.Tables(0).Rows(i).Item("loj_Numero_chr")
            Dim strBairro As String = ds.Tables(0).Rows(i).Item("loj_Bairro_chr")
            Dim strCidade As String = ds.Tables(0).Rows(i).Item("loj_Cidade_chr")
            Dim strUF As String = ds.Tables(0).Rows(i).Item("loj_UF_chr")

            If strEndereco <> "" Then strURL = strURL & strEndereco & "+"
            If strNumero <> "" Then strURL = strURL & strNumero & "+"
            If strBairro <> "" Then strURL = strURL & strBairro & "+"
            If strCidade <> "" Then strURL = strURL & strCidade & "+"
            If strUF <> "" Then strURL = strURL & strUF & "+"

            strURL &= "&sensor=true"

            Dim webRequest As System.Net.HttpWebRequest = Net.WebRequest.Create(strURL)
            Dim webResponse As System.Net.HttpWebResponse = webRequest.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(webResponse.GetResponseStream())
            Dim strReturn As String = sr.ReadToEnd()
            webResponse.Close()

            Dim myDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
            myDoc.LoadXml(strReturn)
            Dim root As System.Xml.XmlElement = myDoc.DocumentElement()
            Dim myNode1 As System.Xml.XmlNode = root.SelectSingleNode("result/geometry/location")
            If Not myNode1 Is Nothing Then

                Dim strLatitude As String = myNode1.SelectSingleNode("lat").InnerText
                Dim strLongitude As String = myNode1.SelectSingleNode("lng").InnerText

                gps.setLoja(vIdLoja, strLatitude, strLongitude)

            End If

        Next

        gps = Nothing

    End Sub
End Class
