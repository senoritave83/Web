<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Dicas.ascx.vb" Inherits="ITC.MostraDicas" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="popupWin" style="display:none; background:#E0E9F8; border-right:1px solid #ffffce; border-bottom:1px solid #ffffce;
                  border-left:1px solid #B9C9EF; border-top:1px solid #B9C9EF; position:absolute;
                  z-index:9999;  width:230px; height:120px; " onselectstart="return false;" onmousedown="return popupWinespopup_DragDrop(event);"><div id="popupWin_header" style="cursor:default; display:none; position:absolute; left:2px; width:224px; top:2px; height:14px;
                 filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0,
                 StartColorStr='#ffffce', EndColorStr='#FFFFFFFF');font:12px arial,sans-serif; color:#1F336B; text-decoration:none;"><span id="popupWintitleEl" class="hometitulo">DICAS 
			DO ITC</span><span style="position:absolute; right:0px; top:0px; cursor:pointer; color:#728EB8; font:bold 12px arial,sans-serif; 
                  position:absolute; right:3px;" onclick="popupWinespopup_Close()" onmousedown="event.cancelBubble=true;" onmouseover="style.color='#455690';" onmouseout="style.color='#728EB8';">X</span></div>
	<div id="popupWin_content" onmousedown="event.cancelBubble=true;" style="display:none; border-left:1px solid #728EB8; border-top:1px solid #728EB8;
                 border-bottom:1px solid #B9C9EF; border-right:1px solid #B9C9EF;
                 background:#E0E9F8; padding:2px; overflow:hidden; text-align:center;
                 filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0,
                 StartColorStr='#ffffce', EndColorStr='#FFFFFFFF');position:absolute; left:2px; width:224px; top:20px; height:115px;"><IMG alt="" border="0" src="imagens/postIT3.JPG" align="right" valign="top"><asp:Label Runat="server" CssClass="f8" id="Label1"></asp:Label></div>
</div>
<script type="text/javascript">
      //<![CDATA[
      
        var popupWinoldonloadHndlr=window.onload, popupWinpopupHgt, popupWinactualHgt, popupWintmrId=-1, popupWinresetTimer;
        var popupWintitHgt, popupWincntDelta, popupWintmrHide=-1, popupWinhideAfter=12000, popupWinhideAlpha, popupWinhasFilters=true;
        var popupWinnWin, popupWinshowBy=null, popupWindxTimer=-1, popupWinpopupBottom;

        var popupWinnText,popupWinnMsg,popupWinnTitle,popupWinbChangeTexts=false;

        window.onload=popupWinespopup_winLoad;
        popupWinnText="<head><title>DICAS DO ITC</title><style type=\"text/css\">body {    background:#E0E9F8; padding:5px;    filter:progid:DXImageTransform.Microsoft.Gradient(     GradientType=0,StartColorStr='#FFE0E9F8', EndColorStr='#FFFFFFFF');  }  h1 {    font:bold 16px arial,sans-serif; color:#1F336B;     text-align:center; margin:0px;  }  p {    font:14px arial,sans-serif; color:#1F336B;  }</style></head><body onload="vertical();horizontal();" ><h1>DICAS DO ITC</h1><p>This very long text will be displayed in new window. To open this window click on \"Show Popup\" button and then click on popup window.</p></body>";
        
        function popupWinespopup_ShowPopup(show)
        {
          if (popupWindxTimer!=-1) { el.filters.blendTrans.stop(); }

          if ((popupWintmrHide!=-1) && ((show!=null) && (show==popupWinshowBy)))
          {
            clearInterval(popupWintmrHide);
            popupWintmrHide=setInterval(popupWinespopup_tmrHideTimer,popupWinhideAfter);
            return;
          }
          if (popupWintmrId!=-1) return;
          popupWinshowBy=show;

          elCnt=document.getElementById('popupWin_content')
          elTit=document.getElementById('popupWin_header');
          el=document.getElementById('popupWin');
          el.style.left='';
          el.style.top='';
          el.style.filter='';

          if (popupWintmrHide!=-1) clearInterval(popupWintmrHide); popupWintmrHide=-1;

          document.getElementById('popupWin_header').style.display='none';
          document.getElementById('popupWin_content').style.display='none';

          if (navigator.userAgent.indexOf('Opera')!=-1)
            el.style.bottom=(document.body.scrollHeight*1-document.body.scrollTop*1
                            -document.body.offsetHeight*1+1*popupWinpopupBottom)+'px';
          
          if (popupWinbChangeTexts)
          {
            popupWinbChangeTexts=false;
            document.getElementById('popupWinaCnt').innerHTML=popupWinnMsg;
            document.getElementById('popupWintitleEl').innerHTML=popupWinnTitle;
          }

          popupWinactualHgt=0; el.style.height=popupWinactualHgt+'px';
          el.style.visibility='';
          if (!popupWinresetTimer) el.style.display='';
          popupWintmrId=setInterval(popupWinespopup_tmrTimer,(popupWinresetTimer?1000:20));
        }

        function popupWinespopup_winLoad()
        {
          if (popupWinoldonloadHndlr!=null) popupWinoldonloadHndlr();

          elCnt=document.getElementById('popupWin_content')
          elTit=document.getElementById('popupWin_header');
          el=document.getElementById('popupWin');
          popupWinpopupBottom=el.style.bottom.substr(0,el.style.bottom.length-2);
          
          popupWintitHgt=elTit.style.height.substr(0,elTit.style.height.length-2);
          popupWinpopupHgt=el.style.height;
          popupWinpopupHgt=popupWinpopupHgt.substr(0,popupWinpopupHgt.length-2); popupWinactualHgt=0;
          popupWincntDelta=popupWinpopupHgt-(elCnt.style.height.substr(0,elCnt.style.height.length-2));

          if (true)
          {
            popupWinresetTimer=true;
            popupWinespopup_ShowPopup(null);
          }
          
		  popupWin_position();
          
        }

        function popupWinespopup_tmrTimer()
        {
          el=document.getElementById('popupWin');
          if (popupWinresetTimer)
          {
            el.style.display='';
            clearInterval(popupWintmrId); popupWinresetTimer=false;
            popupWintmrId=setInterval(popupWinespopup_tmrTimer,20);
          }
          popupWinactualHgt+=5;
          if (popupWinactualHgt>=popupWinpopupHgt)
          {
            popupWinactualHgt=popupWinpopupHgt; clearInterval(popupWintmrId); popupWintmrId=-1;
            document.getElementById('popupWin_content').style.display='';
            if (popupWinhideAfter!=-1) popupWintmrHide=setInterval(popupWinespopup_tmrHideTimer,popupWinhideAfter);
          }
          if (popupWintitHgt<popupWinactualHgt-6)
            document.getElementById('popupWin_header').style.display='';
          if ((popupWinactualHgt-popupWincntDelta)>0)
          {
            elCnt=document.getElementById('popupWin_content')
            elCnt.style.display='';
            elCnt.style.height=(popupWinactualHgt-popupWincntDelta)+'px';
          }
          el.style.height=popupWinactualHgt+'px';
        }
        
        function popupWinespopup_tmrHideTimer()
        {
          clearInterval(popupWintmrHide); popupWintmrHide=-1;
          el=document.getElementById('popupWin');
          if (popupWinhasFilters)
          {
            backCnt=document.getElementById('popupWin_content').innerHTML;
            backTit=document.getElementById('popupWin_header').innerHTML;
            document.getElementById('popupWin_content').innerHTML='';
            document.getElementById('popupWin_header').innerHTML='';
            el.style.filter='blendTrans(duration=1)';
            el.filters.blendTrans.apply();
            el.style.visibility='hidden';
            el.filters.blendTrans.play();
            document.getElementById('popupWin_content').innerHTML=backCnt;
            document.getElementById('popupWin_header').innerHTML=backTit;
            
            popupWindxTimer=setInterval(popupWinespopup_dxTimer,1000);
          }
          else el.style.visibility='hidden';
        }
        
        function popupWinespopup_dxTimer()
        {
          clearInterval(popupWindxTimer); popupWindxTimer=-1;
        }
     
        function popupWinespopup_Close()
        {
          if (popupWintmrId==-1)
          {
            el=document.getElementById('popupWin');
            el.style.filter='';
            el.style.display='none';
            if (popupWintmrHide!=-1) clearInterval(popupWintmrHide); popupWintmrHide=-1;
            
          }
        }
    
        function popupWinespopup_ShowWindow()
        {
          
          if (popupWinnWin!=null) popupWinnWin.close();
          popupWinnWin=window.open('','popupWinnWin','width=300,height=200,scrollbars=no, '+
            'menubar=no, resizable=no, status=no, toolbar=no, location=no');
          popupWinnWin.document.write(popupWinnText);
        }

        var popupWinmousemoveBack,popupWinmouseupBack;
        var popupWinofsX,popupWinofsY;
        function popupWinespopup_DragDrop(e)
        {
          popupWinmousemoveBack=document.body.onmousemove;
          popupWinmouseupBack=document.body.onmouseup;
          ox=(e.offsetX==null)?e.layerX:e.offsetX;
          oy=(e.offsetY==null)?e.layerY:e.offsetY;
          popupWinofsX=ox; popupWinofsY=oy;

          document.body.onmousemove=popupWinespopup_DragDropMove;
          document.body.onmouseup=popupWinespopup_DragDropStop;
          if (popupWintmrHide!=-1) clearInterval(popupWintmrHide);
        }

        function popupWinespopup_DragDropMove(e)
        {
          el=document.getElementById('popupWin');          
          if (e==null&&event!=null)
          {
            el.style.left=(event.clientX*1+document.body.scrollLeft-popupWinofsX)+'px';
            el.style.top=(event.clientY*1+document.body.scrollTop-popupWinofsY)+'px';
            event.cancelBubble=true;
          }
          else
          {
            el.style.left=(e.pageX*1-popupWinofsX)+'px';
            el.style.top=(e.pageY*1-popupWinofsY)+'px';
            e.cancelBubble=true;
          }
          if ((event.button&1)==0) popupWinespopup_DragDropStop();
        }

        function popupWinespopup_DragDropStop()
        {
			document.body.onmousemove=popupWinmousemoveBack;
			document.body.onmouseup=popupWinmouseupBack;
        }
        
        function popupWin_position(){
			if(screen.width==1024){
				popupWin.style.posLeft = 312;
				popupWin.style.posTop = 184;
			}
			else{
				popupWin.style.posLeft = 300;
				popupWin.style.posTop = 150;
			}
        }
        
//ffffce
//FFE0E9F8
      //]]>
</script>