/*
---------------------
XM SISTEMAS
---------------------
*/
	var m_vPage, m_vPost, wh;								

	function XM_ITC_POST(__Page, __Values, __Params, __Name, __PageFeatures){
		m_vPost = 'dt=<%=Now()%>&o=' + __Values;
		m_vPage = __Page + '?dt=<%=Now()%>&' + __Params;
		wh = window.open('repost.asp', __Name, __PageFeatures);
		wh.focus();
		setTimeout("XM_setTimeOut()",3000);
	}

	function XM_setTimeOut()
	{
		wh.rePost(m_vPage, m_vPost);
		return true;
	}