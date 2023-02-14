/*
 * jQuery UI 1.8.1
 *
 * Copyright (c) 2010 AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.jquery.com/UI
 */
jQuery.ui||function(a){a.ui={version:"1.8.1",plugin:{add:function(f,c,h){f=a.ui[f].prototype;
for(var g in h){f.plugins[g]=f.plugins[g]||[];f.plugins[g].push([c,h[g]]);}},call:function(f,c,h){if((c=f.plugins[c])&&f.element[0].parentNode){for(var g=0;g<c.length;g++){f.options[c[g][0]]&&c[g][1].apply(f.element,h);}}}},contains:function(d,c){return document.compareDocumentPosition?d.compareDocumentPosition(c)&16:d!==c&&d.contains(c);
},hasScroll:function(e,c){if(a(e).css("overflow")=="hidden"){return false;}c=c&&c=="left"?"scrollLeft":"scrollTop";var f=false;if(e[c]>0){return true;}e[c]=1;f=e[c]>0;e[c]=0;return f;},isOverAxis:function(e,c,f){return e>c&&e<c+f;},isOver:function(h,c,l,k,j,i){return a.ui.isOverAxis(h,l,j)&&a.ui.isOverAxis(c,k,i);
},keyCode:{ALT:18,BACKSPACE:8,CAPS_LOCK:20,COMMA:188,CONTROL:17,DELETE:46,DOWN:40,END:35,ENTER:13,ESCAPE:27,HOME:36,INSERT:45,LEFT:37,NUMPAD_ADD:107,NUMPAD_DECIMAL:110,NUMPAD_DIVIDE:111,NUMPAD_ENTER:108,NUMPAD_MULTIPLY:106,NUMPAD_SUBTRACT:109,PAGE_DOWN:34,PAGE_UP:33,PERIOD:190,RIGHT:39,SHIFT:16,SPACE:32,TAB:9,UP:38}};
a.fn.extend({_focus:a.fn.focus,focus:function(d,c){return typeof d==="number"?this.each(function(){var b=this;setTimeout(function(){a(b).focus();c&&c.call(b);},d);}):this._focus.apply(this,arguments);},enableSelection:function(){return this.attr("unselectable","off").css("MozUserSelect","");},disableSelection:function(){return this.attr("unselectable","on").css("MozUserSelect","none");
},scrollParent:function(){var b;b=a.browser.msie&&/(static|relative)/.test(this.css("position"))||/absolute/.test(this.css("position"))?this.parents().filter(function(){return/(relative|absolute|fixed)/.test(a.curCSS(this,"position",1))&&/(auto|scroll)/.test(a.curCSS(this,"overflow",1)+a.curCSS(this,"overflow-y",1)+a.curCSS(this,"overflow-x",1));
}).eq(0):this.parents().filter(function(){return/(auto|scroll)/.test(a.curCSS(this,"overflow",1)+a.curCSS(this,"overflow-y",1)+a.curCSS(this,"overflow-x",1));}).eq(0);return/fixed/.test(this.css("position"))||!b.length?a(document):b;},zIndex:function(d){if(d!==undefined){return this.css("zIndex",d);}if(this.length){d=a(this[0]);
for(var c;d.length&&d[0]!==document;){c=d.css("position");if(c=="absolute"||c=="relative"||c=="fixed"){c=parseInt(d.css("zIndex"));if(!isNaN(c)&&c!=0){return c;}}d=d.parent();}}return 0;}});a.extend(a.expr[":"],{data:function(e,c,f){return !!a.data(e,f[3]);},focusable:function(e){var c=e.nodeName.toLowerCase(),f=a.attr(e,"tabindex");
return(/input|select|textarea|button|object/.test(c)?!e.disabled:"a"==c||"area"==c?e.href||!isNaN(f):!isNaN(f))&&!a(e)["area"==c?"parents":"closest"](":hidden").length;},tabbable:function(d){var c=a.attr(d,"tabindex");return(isNaN(c)||c>=0)&&a(d).is(":focusable");}});}(jQuery);
/*
 * jQuery UI Widget 1.8.1
 *
 * Copyright (c) 2010 AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.jquery.com/UI/Widget
 */
(function(a){var c=a.fn.remove;
a.fn.remove=function(b,d){return this.each(function(){if(!d){if(!b||a.filter(b,[this]).length){a("*",this).add(this).each(function(){a(this).triggerHandler("remove");});}}return c.call(a(this),b,d);});};a.widget=function(b,j,i){var h=b.split(".")[0],g;b=b.split(".")[1];g=h+"-"+b;if(!i){i=j;j=a.Widget;
}a.expr[":"][g]=function(d){return !!a.data(d,b);};a[h]=a[h]||{};a[h][b]=function(d,e){arguments.length&&this._createWidget(d,e);};j=new j;j.options=a.extend({},j.options);a[h][b].prototype=a.extend(true,j,{namespace:h,widgetName:b,widgetEventPrefix:a[h][b].prototype.widgetEventPrefix||b,widgetBaseClass:g},i);
a.widget.bridge(b,a[h][b]);};a.widget.bridge=function(b,d){a.fn[b]=function(k){var j=typeof k==="string",i=Array.prototype.slice.call(arguments,1),g=this;k=!j&&i.length?a.extend.apply(null,[true,k].concat(i)):k;if(j&&k.substring(0,1)==="_"){return g;}j?this.each(function(){var f=a.data(this,b),e=f&&a.isFunction(f[k])?f[k].apply(f,i):f;
if(e!==f&&e!==undefined){g=e;return false;}}):this.each(function(){var e=a.data(this,b);if(e){k&&e.option(k);e._init();}else{a.data(this,b,new d(k,this));}});return g;};};a.Widget=function(b,d){arguments.length&&this._createWidget(b,d);};a.Widget.prototype={widgetName:"widget",widgetEventPrefix:"",options:{disabled:false},_createWidget:function(b,f){this.element=a(f).data(this.widgetName,this);
this.options=a.extend(true,{},this.options,a.metadata&&a.metadata.get(f)[this.widgetName],b);var e=this;this.element.bind("remove."+this.widgetName,function(){e.destroy();});this._create();this._init();},_create:function(){},_init:function(){},destroy:function(){this.element.unbind("."+this.widgetName).removeData(this.widgetName);
this.widget().unbind("."+this.widgetName).removeAttr("aria-disabled").removeClass(this.widgetBaseClass+"-disabled ui-state-disabled");},widget:function(){return this.element;},option:function(b,h){var g=b,f=this;if(arguments.length===0){return a.extend({},f.options);}if(typeof b==="string"){if(h===undefined){return this.options[b];
}g={};g[b]=h;}a.each(g,function(e,d){f._setOption(e,d);});return f;},_setOption:function(b,d){this.options[b]=d;if(b==="disabled"){this.widget()[d?"addClass":"removeClass"](this.widgetBaseClass+"-disabled ui-state-disabled").attr("aria-disabled",d);}return this;},enable:function(){return this._setOption("disabled",false);
},disable:function(){return this._setOption("disabled",true);},_trigger:function(b,j,i){var h=this.options[b];j=a.Event(j);j.type=(b===this.widgetEventPrefix?b:this.widgetEventPrefix+b).toLowerCase();i=i||{};if(j.originalEvent){b=a.event.props.length;for(var g;b;){g=a.event.props[--b];j[g]=j.originalEvent[g];
}}this.element.trigger(j,i);return !(a.isFunction(h)&&h.call(this.element[0],j,i)===false||j.isDefaultPrevented());}};})(jQuery);
/*
 * jQuery UI Mouse 1.8.1
 *
 * Copyright (c) 2010 AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.jquery.com/UI/Mouse
 *
 * Depends:
 *	jquery.ui.widget.js
 */
(function(a){a.widget("ui.mouse",{options:{cancel:":input,option",distance:1,delay:0},_mouseInit:function(){var b=this;
this.element.bind("mousedown."+this.widgetName,function(c){return b._mouseDown(c);}).bind("click."+this.widgetName,function(c){if(b._preventClickEvent){b._preventClickEvent=false;c.stopImmediatePropagation();return false;}});this.started=false;},_mouseDestroy:function(){this.element.unbind("."+this.widgetName);
},_mouseDown:function(d){d.originalEvent=d.originalEvent||{};if(!d.originalEvent.mouseHandled){this._mouseStarted&&this._mouseUp(d);this._mouseDownEvent=d;var c=this,h=d.which==1,g=typeof this.options.cancel=="string"?a(d.target).parents().add(d.target).filter(this.options.cancel).length:false;if(!h||g||!this._mouseCapture(d)){return true;
}this.mouseDelayMet=!this.options.delay;if(!this.mouseDelayMet){this._mouseDelayTimer=setTimeout(function(){c.mouseDelayMet=true;},this.options.delay);}if(this._mouseDistanceMet(d)&&this._mouseDelayMet(d)){this._mouseStarted=this._mouseStart(d)!==false;if(!this._mouseStarted){d.preventDefault();return true;
}}this._mouseMoveDelegate=function(b){return c._mouseMove(b);};this._mouseUpDelegate=function(b){return c._mouseUp(b);};a(document).bind("mousemove."+this.widgetName,this._mouseMoveDelegate).bind("mouseup."+this.widgetName,this._mouseUpDelegate);a.browser.safari||d.preventDefault();return d.originalEvent.mouseHandled=true;
}},_mouseMove:function(b){if(a.browser.msie&&!b.button){return this._mouseUp(b);}if(this._mouseStarted){this._mouseDrag(b);return b.preventDefault();}if(this._mouseDistanceMet(b)&&this._mouseDelayMet(b)){(this._mouseStarted=this._mouseStart(this._mouseDownEvent,b)!==false)?this._mouseDrag(b):this._mouseUp(b);
}return !this._mouseStarted;},_mouseUp:function(b){a(document).unbind("mousemove."+this.widgetName,this._mouseMoveDelegate).unbind("mouseup."+this.widgetName,this._mouseUpDelegate);if(this._mouseStarted){this._mouseStarted=false;this._preventClickEvent=b.target==this._mouseDownEvent.target;this._mouseStop(b);
}return false;},_mouseDistanceMet:function(b){return Math.max(Math.abs(this._mouseDownEvent.pageX-b.pageX),Math.abs(this._mouseDownEvent.pageY-b.pageY))>=this.options.distance;},_mouseDelayMet:function(){return this.mouseDelayMet;},_mouseStart:function(){},_mouseDrag:function(){},_mouseStop:function(){},_mouseCapture:function(){return true;
}});})(jQuery);(function(f){f.ui=f.ui||{};var a=/left|center|right/,e=/top|center|bottom/,d=f.fn.position,b=f.fn.offset;f.fn.position=function(j){if(!j||!j.of){return d.apply(this,arguments);}j=f.extend({},j);var c=f(j.of),o=(j.collision||"flip").split(" "),n=j.offset?j.offset.split(" "):[0,0],m,l,k;
if(j.of.nodeType===9){m=c.width();l=c.height();k={top:0,left:0};}else{if(j.of.scrollTo&&j.of.document){m=c.width();l=c.height();k={top:c.scrollTop(),left:c.scrollLeft()};}else{if(j.of.preventDefault){j.at="left top";m=l=0;k={top:j.of.pageY,left:j.of.pageX};}else{m=c.outerWidth();l=c.outerHeight();k=c.offset();
}}}f.each(["my","at"],function(){var g=(j[this]||"").split(" ");if(g.length===1){g=a.test(g[0])?g.concat(["center"]):e.test(g[0])?["center"].concat(g):["center","center"];}g[0]=a.test(g[0])?g[0]:"center";g[1]=e.test(g[1])?g[1]:"center";j[this]=g;});if(o.length===1){o[1]=o[0];}n[0]=parseInt(n[0],10)||0;
if(n.length===1){n[1]=n[0];}n[1]=parseInt(n[1],10)||0;if(j.at[0]==="right"){k.left+=m;}else{if(j.at[0]==="center"){k.left+=m/2;}}if(j.at[1]==="bottom"){k.top+=l;}else{if(j.at[1]==="center"){k.top+=l/2;}}k.left+=n[0];k.top+=n[1];return this.each(function(){var p=f(this),h=p.outerWidth(),g=p.outerHeight(),i=f.extend({},k);
if(j.my[0]==="right"){i.left-=h;}else{if(j.my[0]==="center"){i.left-=h/2;}}if(j.my[1]==="bottom"){i.top-=g;}else{if(j.my[1]==="center"){i.top-=g/2;}}i.left=parseInt(i.left);i.top=parseInt(i.top);f.each(["left","top"],function(s,q){f.ui.position[o[s]]&&f.ui.position[o[s]][q](i,{targetWidth:m,targetHeight:l,elemWidth:h,elemHeight:g,offset:n,my:j.my,at:j.at});
});f.fn.bgiframe&&p.bgiframe();p.offset(f.extend(i,{using:j.using}));});};f.ui.position={fit:{left:function(g,c){var h=f(window);c=g.left+c.elemWidth-h.width()-h.scrollLeft();g.left=c>0?g.left-c:Math.max(0,g.left);},top:function(g,c){var h=f(window);c=g.top+c.elemHeight-h.height()-h.scrollTop();g.top=c>0?g.top-c:Math.max(0,g.top);
}},flip:{left:function(h,c){if(c.at[0]!=="center"){var k=f(window);k=h.left+c.elemWidth-k.width()-k.scrollLeft();var j=c.my[0]==="left"?-c.elemWidth:c.my[0]==="right"?c.elemWidth:0,i=-2*c.offset[0];h.left+=h.left<0?j+c.targetWidth+i:k>0?j-c.targetWidth+i:0;}},top:function(i,c){if(c.at[1]!=="center"){var m=f(window);
m=i.top+c.elemHeight-m.height()-m.scrollTop();var l=c.my[1]==="top"?-c.elemHeight:c.my[1]==="bottom"?c.elemHeight:0,k=c.at[1]==="top"?c.targetHeight:-c.targetHeight,j=-2*c.offset[1];i.top+=i.top<0?l+c.targetHeight+j:m>0?l+k+j:0;}}}};if(!f.offset.setOffset){f.offset.setOffset=function(i,c){if(/static/.test(f.curCSS(i,"position"))){i.style.position="relative";
}var m=f(i),l=m.offset(),k=parseInt(f.curCSS(i,"top",true),10)||0,j=parseInt(f.curCSS(i,"left",true),10)||0;l={top:c.top-l.top+k,left:c.left-l.left+j};"using" in c?c.using.call(i,l):m.css(l);};f.fn.offset=function(g){var c=this[0];if(!c||!c.ownerDocument){return null;}if(g){return this.each(function(){f.offset.setOffset(this,g);
});}return b.call(this);};}})(jQuery);