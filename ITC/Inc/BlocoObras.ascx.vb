Public MustInherit Class BlocoObras
    Inherits System.Web.UI.UserControl
    Protected WithEvents titulo As System.Web.UI.WebControls.Label
    Protected WithEvents ltScrollable As System.Web.UI.WebControls.Literal
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        If Not Page.IsPostBack Then
            ltScrollable.Text = MontaScrollable()
        End If
    End Sub

    Private Function MontaScrollable() As String

        Dim strScrollable As String = ""

        strScrollable += "<script language=""JavaScript1.2"">" & vbCrLf

        strScrollable += "	//Translucent scroller- By Dynamic Drive" & vbCrLf
        strScrollable += "	//For full source code and more DHTML scripts, visit http://www.dynamicdrive.com" & vbCrLf
        strScrollable += "	//This credit MUST stay intact for use" & vbCrLf

        strScrollable += "	var scroller_width=tblScrollable.width" & vbCrLf
        strScrollable += "	var scroller_height=150" & vbCrLf
        strScrollable += "	var bgcolor='#FFFFFF'" & vbCrLf
        strScrollable += "	var pause=15000 //SET PAUSE BETWEEN SLIDE (3000=3 seconds)" & vbCrLf

        strScrollable += "	//scrollercontent defined in functions.js" & vbCrLf

        strScrollable += "	////NO need to edit beyond here/////////////" & vbCrLf

        strScrollable += "	var ie4=document.all&&navigator.userAgent.indexOf(""Opera"")==-1" & vbCrLf
        strScrollable += "	var dom=document.getElementById&&navigator.userAgent.indexOf(""Opera"")==-1" & vbCrLf

        strScrollable += "	if (ie4||dom)" & vbCrLf
        strScrollable += "	document.write('<div style=""position:relative;width:'+scroller_width+';height:'+scroller_height+';overflow:hidden""><div id=""canvas0"" style=""position:absolute;background-color:'+bgcolor+';width:'+scroller_width+';height:'+scroller_height+';top:'+scroller_height+';filter:alpha(opacity=20);-moz-opacity:0.2;""></div><div id=""canvas1"" style=""position:absolute;background-color:'+bgcolor+';width:'+scroller_width+';height:'+scroller_height+';top:'+scroller_height+';filter:alpha(opacity=20);-moz-opacity:0.2;""></div></div>')" & vbCrLf
        strScrollable += "	//else if (document.layers){" & vbCrLf
        strScrollable += "	//document.write('<ilayer id=tickernsmain visibility=hide width='+scroller_width+' height='+scroller_height+' bgColor='+bgcolor+'><layer id=tickernssub width='+scroller_width+' height='+scroller_height+' left=0 top=0>'+scrollercontent[0]+'</layer></ilayer>')" & vbCrLf
        strScrollable += "	//}" & vbCrLf

        strScrollable += "	var curpos=scroller_height*(1)" & vbCrLf
        strScrollable += "	var degree=10" & vbCrLf
        strScrollable += "	var curcanvas=""canvas0""" & vbCrLf
        strScrollable += "	var curindex=0" & vbCrLf
        strScrollable += "	var nextindex=1" & vbCrLf

        strScrollable += "	function moveslide(){" & vbCrLf
        strScrollable += "	if (curpos>0){" & vbCrLf
        strScrollable += "	curpos=Math.max(curpos-degree,0)" & vbCrLf
        strScrollable += "	tempobj.style.top=curpos" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	else{" & vbCrLf
        strScrollable += "	clearInterval(dropslide)" & vbCrLf
        strScrollable += "	if (crossobj.filters)" & vbCrLf
        strScrollable += "	crossobj.filters.alpha.opacity=100" & vbCrLf
        strScrollable += "	else if (crossobj.style.MozOpacity)" & vbCrLf
        strScrollable += "	crossobj.style.MozOpacity=1" & vbCrLf
        strScrollable += "	nextcanvas=(curcanvas==""canvas0"")? ""canvas0"" : ""canvas1""" & vbCrLf
        strScrollable += "	tempobj=ie4? eval(""document.all.""+nextcanvas) : document.getElementById(nextcanvas)" & vbCrLf
        strScrollable += "	tempobj.innerHTML=scrollercontent[curindex]" & vbCrLf
        strScrollable += "	nextindex=(nextindex<scrollercontent.length-1)? nextindex+1 : 0" & vbCrLf
        strScrollable += "	setTimeout(""rotateslide()"",pause)" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	}" & vbCrLf

        strScrollable += "	function rotateslide(){" & vbCrLf
        strScrollable += "	if (ie4||dom){" & vbCrLf
        strScrollable += "	resetit(curcanvas)" & vbCrLf
        strScrollable += "	crossobj=tempobj=ie4? eval(""document.all.""+curcanvas) : document.getElementById(curcanvas)" & vbCrLf
        strScrollable += "	crossobj.style.zIndex++" & vbCrLf
        strScrollable += "	if (crossobj.filters)" & vbCrLf
        strScrollable += "	document.all.canvas0.filters.alpha.opacity=document.all.canvas1.filters.alpha.opacity=20" & vbCrLf
        strScrollable += "	else if (crossobj.style.MozOpacity)" & vbCrLf
        strScrollable += "	document.getElementById(""canvas0"").style.MozOpacity=document.getElementById(""canvas1"").style.MozOpacity=0.2" & vbCrLf
        strScrollable += "	var temp='setInterval(""moveslide()"",50)'" & vbCrLf
        strScrollable += "	dropslide=eval(temp)" & vbCrLf
        strScrollable += "	curcanvas=(curcanvas==""canvas0"")? ""canvas1"" : ""canvas0""" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	//else if (document.layers){" & vbCrLf
        strScrollable += "	//crossobj.document.write(scrollercontent[curindex])" & vbCrLf
        strScrollable += "	//crossobj.document.close()" & vbCrLf
        strScrollable += "	//}" & vbCrLf
        strScrollable += "	curindex=(curindex<scrollercontent.length-1)? curindex+1 : 0" & vbCrLf
        strScrollable += "	}" & vbCrLf

        strScrollable += "	function resetit(what){" & vbCrLf
        strScrollable += "	curpos=scroller_height*(1)" & vbCrLf
        strScrollable += "	var crossobj=ie4? eval(""document.all.""+what) : document.getElementById(what)" & vbCrLf
        strScrollable += "	crossobj.style.top=curpos" & vbCrLf
        strScrollable += "	}" & vbCrLf

        strScrollable += "	function startit(){" & vbCrLf
        strScrollable += "	crossobj=ie4? eval(""document.all.""+curcanvas) : dom? document.getElementById(curcanvas) : document.tickernsmain.document.tickernssub" & vbCrLf
        strScrollable += "	if (ie4||dom){" & vbCrLf
        strScrollable += "	crossobj.innerHTML=scrollercontent[curindex]" & vbCrLf
        strScrollable += "	rotateslide()" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	//else{" & vbCrLf
        strScrollable += "	//document.tickernsmain.visibility='show'" & vbCrLf
        strScrollable += "	//curindex++" & vbCrLf
        strScrollable += "	//setInterval(""rotateslide()"",pause)" & vbCrLf
        strScrollable += "	//}" & vbCrLf
        strScrollable += "	}" & vbCrLf

        strScrollable += "	if (ie4||dom){//||document.layers)" & vbCrLf
        strScrollable += "		window.onload=startit;" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	else{" & vbCrLf
        strScrollable += "		numberOfMessages = scrollercontent.length;" & vbCrLf
        strScrollable += "		for (var i = 0; i < numberOfMessages; i++) {" & vbCrLf
        strScrollable += "			document.write(scrollercontent[i]);" & vbCrLf
        strScrollable += "			document.write(""<br /><br />"");" & vbCrLf
        strScrollable += "			document.close();" & vbCrLf
        strScrollable += "		}" & vbCrLf
        strScrollable += "	}" & vbCrLf
        strScrollable += "	var scrollercontent=new Array()" & vbCrLf
        strScrollable += "	//Define scroller contents. Extend or contract array as needed" & vbCrLf

        Dim clsNot As Noticia
        clsNot = New Noticia()
        With clsNot
            Dim ds As DataSet = .UltimasNoticias(3)
            Dim i As Integer
            If ds.Tables.Count > 0 Then
                strScrollable += "scrollercontent[" & i & "]='<span class=f8><font style=""color:#003366""><b>" & ds.Tables(0).Rows(i).Item("TITULO") & "</b></font></span>';" & vbCrLf
                strScrollable += "scrollercontent[" & i & "]+='<br><a href=""noticiasdet.aspx?idnoticia=" & ds.Tables(0).Rows(i).Item("IDNOTICIA") & """><span class=f8 style=""color:#003366"">Ver esta notícia...</span></a><br><br>';" & vbCrLf
                If ds.Tables(0).Rows.Count >= 2 Then
                    strScrollable += "scrollercontent[" & i & "]+='<span class=f8><font style=""color:#003366""><b>" & ds.Tables(0).Rows(i + 1).Item("TITULO") & "</b></font></span>';" & vbCrLf
                    strScrollable += "scrollercontent[" & i & "]+='<br><a href=""noticiasdet.aspx?idnoticia=" & ds.Tables(0).Rows(i + 1).Item("IDNOTICIA") & """><span class=f8 style=""color:#003366"">Ver esta notícia...</span></a><br><br>';" & vbCrLf
                End If
                If ds.Tables(0).Rows.Count >= 3 Then
                    strScrollable += "scrollercontent[" & i & "]+='<span class=f8><font style=""color:#003366""><b>" & ds.Tables(0).Rows(i + 2).Item("TITULO") & "</b></font></span>';" & vbCrLf
                    strScrollable += "scrollercontent[" & i & "]+='<br><a href=""noticiasdet.aspx?idnoticia=" & ds.Tables(0).Rows(i + 2).Item("IDNOTICIA") & """><span class=f8 style=""color:#003366"">Ver esta notícia...</span></a>';" & vbCrLf
                End If
            End If
        End With

        strScrollable += "</script>" & vbCrLf

        Return strScrollable

    End Function

End Class
