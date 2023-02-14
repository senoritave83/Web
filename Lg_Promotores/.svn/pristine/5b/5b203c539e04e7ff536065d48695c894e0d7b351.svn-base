Imports Microsoft.VisualBasic
Imports System.Web.Compilation
Imports System.CodeDom
Imports System.Configuration.ConfigurationManager
Imports System.Xml
Imports System.Web.Caching

<ExpressionPrefix("Settings")> _
Public Class SettingsExpression
    Inherits ExpressionBuilder

    Private Shared ReadOnly _lock As New Object()

    Public Class SettingsCollectionItem
        Public Value As Object
        Public isDefault As Boolean

        Public Sub New(ByVal vValue As Object, ByVal vDefaultValue As Object)
            isDefault = (vValue = vDefaultValue)
            Value = vValue
        End Sub
    End Class

    Public Shared ReadOnly Property SettingsCollection() As Collections.IDictionary

        Get
            Dim strCacheName As String = "XMSistemas.SettingsCollection"
            If TypeOf HttpContext.Current.User Is XMPrincipal Then
                strCacheName &= "." & CType(HttpContext.Current.User, XMPrincipal).IDEmpresa
            End If
            Dim col As Collections.Specialized.HybridDictionary = HttpContext.Current.Cache.Get(strCacheName)
            '            Dim s As New System.Web.Caching.Cache()
            If col Is Nothing Then
                col = New Collections.Specialized.HybridDictionary(True)
                Dim dep As CacheDependency = New CacheDependency(GetFileName)
                HttpContext.Current.Cache.Insert(strCacheName, col, dep)
            End If
            Return col
        End Get
    End Property



    Public Enum enReturnType As Byte
        _Boolean = 0
        _String = 1
    End Enum

    Public Structure stRequired
        Public Atributo As String
        Public Entidade As String
        Public DefaultValue As Object
        Public ReturnType As enReturnType
    End Structure

    Public Overrides Function GetCodeExpression(ByVal entry As System.Web.UI.BoundPropertyEntry, ByVal parsedData As Object, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As System.CodeDom.CodeExpression

        Dim strProperty As String = "Empty"
        Dim strDefault As String = ""
        Dim strAtributo As String = "empty"
        Dim indReturnType As Byte

        If TypeOf (parsedData) Is stRequired Then
            With CType(parsedData, stRequired)
                strProperty = .Entidade
                strDefault = .DefaultValue
                strAtributo = .Atributo
                indReturnType = .ReturnType
            End With
        End If

        Dim att As CodePrimitiveExpression = New CodePrimitiveExpression(strAtributo)
        Dim prim As CodePrimitiveExpression = New CodePrimitiveExpression(strProperty)
        Dim def As CodePrimitiveExpression = New CodePrimitiveExpression(strDefault)
        Dim rt As CodePrimitiveExpression = New CodePrimitiveExpression(indReturnType)
        Dim args() As CodeExpression = New CodeExpression(3) {att, prim, def, rt}

        Dim refType As CodeTypeReferenceExpression
        refType = New CodeTypeReferenceExpression(Me.GetType())
        Return New CodeMethodInvokeExpression(refType, "GetProperty", args)

    End Function

    Public Overrides Function ParseExpression(ByVal expression As String, ByVal propertyType As System.Type, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As Object
        Dim vArr() As String = Split(expression, ",")
        Dim st As stRequired
        st.Atributo = Trim(vArr(0))
        st.Entidade = Trim(vArr(1))
        st.DefaultValue = Trim(vArr(2))
        If Trim(vArr(2)).ToLower = "true" Or Trim(vArr(2)).ToLower = "false" Then
            st.ReturnType = enReturnType._Boolean
            st.DefaultValue = (Trim(vArr(2)).ToLower = "true")
        Else
            If vArr.GetUpperBound(0) > 2 Then
                st.DefaultValue = vArr(2)
                For k As Integer = 3 To vArr.GetUpperBound(0)
                    st.DefaultValue &= "," & vArr(k)
                Next
            End If
            st.ReturnType = enReturnType._String
            st.DefaultValue = Trim(st.DefaultValue).Trim("""").Trim("'")
        End If
        Return st
    End Function

    Public Shared Function GetProperty(ByVal vAtributo As String, ByVal vProperty As String, ByVal vDefault As Boolean) As Boolean
        Dim strValue As String = IIf(vDefault, "true", "")
        strValue = GetProperty(vAtributo, vProperty, strValue)
        Return (strValue.ToLower = "true")
    End Function

    Public Shared Function GetProperty(ByVal vAtributo As String, ByVal vProperty As String, ByVal vDefault As String, ByVal vReturnType As enReturnType) As Object
        If vReturnType = enReturnType._Boolean Then
            Return GetProperty(vAtributo, vProperty, (vDefault.ToLower = "true"))
        Else
            Return GetProperty(vAtributo, vProperty, vDefault)
        End If
    End Function

    Protected Shared ReadOnly Property GetFileName() As String
        Get
            Dim strFileName As String = HttpContext.Current.Server.MapPath("~") & "\settings.xml"
            Dim intIDEmpresa As Integer = 0
            If TypeOf HttpContext.Current.User Is XMPrincipal Then
                intIDEmpresa = CType(HttpContext.Current.User, XMPrincipal).IDEmpresa
                If IO.File.Exists(HttpContext.Current.Server.MapPath("~") & "\app_settings\" & intIDEmpresa & "\settings.xml") Then
                    strFileName = HttpContext.Current.Server.MapPath("~") & "\app_settings\" & intIDEmpresa & "\settings.xml"
                End If
            End If
            Return strFileName
        End Get
    End Property

    Public Shared Function GetXMLNodeProperty(ByVal vNode As String) As XmlNode

        Dim ndValue As XmlNode = Nothing
        Dim strFileName As String = GetFileName

        SyncLock (_lock)

            If IO.File.Exists(strFileName) Then
                Dim doc As New XmlDocument
                doc.Load(strFileName)
                Dim strSearch As String = "/settings/" & Replace(vNode, ".", "/")
                If strSearch.EndsWith("/") Then strSearch = strSearch.Substring(0, strSearch.Length - 1)
                ndValue = doc.SelectSingleNode(strSearch)
            End If

        End SyncLock

        Return ndValue

    End Function

    Public Shared Function GetProperty(ByVal vAtributo As String, ByVal vProperty As String, ByVal vDefault As String) As String

        Dim strValue As String = vDefault

        Dim strKey As String = vProperty & "|" & vAtributo
        If SettingsCollection.Contains(strKey) Then
            Return CType(SettingsCollection.Item(strKey), SettingsCollectionItem).Value
            Exit Function
        End If

        Dim strFileName As String = GetFileName 'HttpContext.Current.Server.MapPath("~") & "\settings.xml"

        SyncLock (_lock)

            If SettingsCollection.Contains(strKey) Then
                Return CType(SettingsCollection.Item(strKey), SettingsCollectionItem).Value
                Exit Function
            End If

            If IO.File.Exists(strFileName) Then
                Dim doc As New XmlDocument
                doc.Load(strFileName)
                Dim strSearch As String = "/settings/" & Replace(vProperty, ".", "/")
                If strSearch.EndsWith("/") Then strSearch = strSearch.Substring(0, strSearch.Length - 1)
                Dim nd As XmlNode = doc.SelectSingleNode(strSearch)
                If Not nd Is Nothing Then
                    'If vProperty <> "" Then
                    '    nd = nd.SelectSingleNode(Replace(vProperty, ".", "/"))
                    'End If
                    If Not nd Is Nothing Then
                        Dim at As XmlNode = nd.Attributes.GetNamedItem(vAtributo.ToLower)
                        If Not at Is Nothing Then
                            strValue = at.Value
                        End If
                    End If
                End If
            End If
            Dim it As New SettingsCollectionItem(strValue, vDefault)
            SettingsCollection.Add(strKey, it)

        End SyncLock

        Return strValue

    End Function

    Public Overrides Function EvaluateExpression(ByVal target As Object, ByVal entry As System.Web.UI.BoundPropertyEntry, ByVal parsedData As Object, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As Object

        Dim strProperty As String = "Empty"
        Dim blnDefault As Boolean = False
        Dim strAtributo As String = "empty"

        If TypeOf (parsedData) Is stRequired Then
            With CType(parsedData, stRequired)
                strProperty = .Entidade
                blnDefault = .DefaultValue
                strAtributo = .Atributo
            End With
        End If

        Return GetProperty(strAtributo, strProperty, blnDefault)
    End Function

    Public Overrides ReadOnly Property SupportsEvaluate() As Boolean
        Get
            Return True
        End Get
    End Property

End Class



