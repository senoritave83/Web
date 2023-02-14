/*
	webfxMenuDefaultWidth			= 100;
	webfxMenuDefaultBorderWidth		= 1;
	webfxMenuDefaultPaddingWidth	= 1;
	webfxMenuDefaultBorderTop		= 1;
	webfxMenuDefaultPaddingTop		= 1;

	webfxMenuItemDefaultHeight		= 16;
	webfxMenuItemDefaultText		= "Untitled";
	webfxMenuItemDefaultHref		= "javascript:void(0)";

	webfxMenuImageDefaultHeight		= 54;
	webfxMenuSeparatorDefaultHeight	= 2;
	webfxMenuDefaultImagePath		= "imagens/";
	webfxMenuDefaultEmptyText		= "Empty";

	// check browsers
	var op = /opera 5|opera\/5/i.test(navigator.userAgent);
	var ie = !op && /msie/i.test(navigator.userAgent);	// preventing opera to be identified as ie
	var mz = !op && /mozilla\/5/i.test(navigator.userAgent);	// preventing opera to be identified as mz
	var ieBox = ie && /win/.test(navigator.platform) && (document.compatMode == null || document.compatMode != "BackCompat");	// IE proprietary box model
	var popupPrimeira = 0;
	var menuAparente = 0;
	var rapido = 0;
	if (ie)	{
		var colSelec = this.document.all.tags("SELECT");
		var ex = colSelec.length;
		var escondido = 0;
	}
	if (ie && document.getElementById == null) {	// ie4
		document.getElementById = function(sId) {
			return document.all[sId];
		};
	}
	function escondeMenu() {
 		if (menuAparente && !popupPrimeira) {
			if (escondido) {
				document.body.focus();
				rapido = 1;
			} else
				window.setTimeout("if (!menuAparente) document.body.focus()",600);
			menuAparente = 0;
			aparece();
		} else
	 		if (popupPrimeira)
				esconde()
	}
	function esconde() {
		menuAparente = 1;
		if ((ex && !escondido) || popupPrimeira) {
			for (iCnt = 0; iCnt < ex; iCnt++) {
				colSelec(iCnt).style.display  = "none";
			}
			escondido = 1;
		}
	}
	function aparece() {
		if (ex && escondido && !popupPrimeira) {
			for (iCnt = 0; iCnt < ex; iCnt++) {
				colSelec(iCnt).style.display  = "";
			}
			escondido = 0;
		}
	}
	var webFXMenuHandler = { 
		idCounter		:	0,
		idPrefix		:	"webfx-menu-object-",
		getId			:	function () { return this.idPrefix + this.idCounter++; },
		overMenuItem	:	function (oItem) {
			var jsItem = this.all[oItem.id];
			if (jsItem.subMenu) {
				jsItem.parentMenu.hideAllSubs();
				jsItem.subMenu.show();
			}
			else {
				jsItem.parentMenu.hideAllSubs();
			}
		},
		blurMenu		:	function (oMenuItem) {
			if (rapido) {
				webFXMenuHandler.all[oMenuItem.id].subMenu.hide();
				rapido = 0;
			} else
				window.setTimeout("webFXMenuHandler.all[\"" + oMenuItem.id + "\"].subMenu.hide();", 200);
		},
		all				:	{}
	};

	function WebFXMenu() {
		this._menuItems	= [];
		this._subMenus	= [];
		this.id			= webFXMenuHandler.getId();
		this.top		= 0;
		this.left		= 0;
		this.shown		= false;
		webFXMenuHandler.all[this.id] = this;
	}
	WebFXMenu.prototype.width			= webfxMenuDefaultWidth;
	WebFXMenu.prototype.borderWidth		= webfxMenuDefaultBorderWidth;
	WebFXMenu.prototype.paddingWidth	= webfxMenuDefaultPaddingWidth;
	WebFXMenu.prototype.borderTop		= webfxMenuDefaultBorderTop;
	WebFXMenu.prototype.paddingTop		= webfxMenuDefaultPaddingTop;
	WebFXMenu.prototype.emptyText		= webfxMenuDefaultEmptyText;

	WebFXMenu.prototype.add = function (menuItem) {
		this._menuItems[this._menuItems.length] = menuItem;
		if (menuItem.subMenu)
			this._subMenus[this._subMenus.length] = menuItem.subMenu;
		
		menuItem.parentMenu = this;
	};
	WebFXMenu.prototype.show = function () {
		if (ie && !escondido)
			esconde();
		var divElement = document.getElementById(this.id);
		divElement.style.left = op ? this.left : this.left + "px";
		divElement.style.top = op ? this.top : this.top + "px";
		divElement.style.visibility = "visible";
		menuAparente = 1;
		this.shown = true;
		if (this.parentMenu)
			this.parentMenu.show();
	};
	WebFXMenu.prototype.hide = function () {
		this.hideAllSubs();
		var divElement = document.getElementById(this.id);
		divElement.style.visibility = "hidden";
		this.shown = false;
		if (ie && this._subMenus.length > 0 && this.parentMenu && escondido) {
			aparece();
			menuAparente = 0;
		}
	};
	WebFXMenu.prototype.hideAllSubs = function () {
		for (var i = 0; i < this._subMenus.length; i++) {
			if (this._subMenus[i].shown) {
				this._subMenus[i].hide();
			}
		}
	};
	WebFXMenu.prototype.toString = function () {
		var top = this.top + this.borderTop + this.paddingTop;
		var str = "<div id='" + this.id + "' class='webfx-menu' style='" + 
		"width:" + (!ieBox  ?  this.width - this.borderWidth - this.paddingWidth  :  this.width) + "px;" +
		"left:" + this.left + "px;" +
		"top:" + this.top + "px;" +
		" onmouseover='esconde()'" +
		"'>";

		if (this._menuItems.length == 0) {
			str += "<span class='webfx-menu-empty'>" + this.emptyText + "</span>";
		}
		else {	
			// loop through all menuItems
			for (var i = 0; i < this._menuItems.length; i++) {
				var mi = this._menuItems[i]
				str += mi;
				if (mi.subMenu)
					mi.subMenu.top = top - mi.subMenu.borderTop - mi.subMenu.paddingTop;
				top += mi.height;
			}

		}
		str += "</div>";
		for (var i = 0; i < this._subMenus.length; i++) {
			this._subMenus[i].left = this.left + this.width - this._subMenus[i].borderWidth/2;
			str += this._subMenus[i];
		}
		return str;
	};
	function WebFXMenuItem(sText, sHref, sToolTip, oSubMenu) {
		this.text = sText || webfxMenuItemDefaultText;
		this.href = (sHref == null || sHref == "") ? webfxMenuItemDefaultHref : sHref;
		this.subMenu = oSubMenu;
		if (oSubMenu)
			oSubMenu.parentMenuItem = this;
		this.toolTip = sToolTip;
		this.id = webFXMenuHandler.getId();
		webFXMenuHandler.all[this.id] = this;
	};
	WebFXMenuItem.prototype.height = webfxMenuItemDefaultHeight;
	WebFXMenuItem.prototype.toString = function () {
		return	"<a" +
				" id='" + this.id + "'" +
				" href='" + this.href + "'" +
				(this.toolTip ? " title='" + this.toolTip + "'" : "") +
				" onmouseover='menuAparente=1;webFXMenuHandler.overMenuItem(this);'" +
				">" +
				(this.subMenu ? "<img class='arrow' src='" + webfxMenuDefaultImagePath + "setadireita.jpg'>" : "") +
				this.text + 
				"</a>";
	};


	function WebFXMenuSeparator() {
		this.id = webFXMenuHandler.getId();
		webFXMenuHandler.all[this.id] = this;
	};
	WebFXMenuSeparator.prototype.height = webfxMenuSeparatorDefaultHeight;
	WebFXMenuSeparator.prototype.toString = function () {
		return "<div></div>"
	};

	function WebFXMenuBar() {
		this._parentConstructor = WebFXMenu;
		this._parentConstructor();
	}
	WebFXMenuBar.prototype = new WebFXMenu;
	WebFXMenuBar.prototype.barra = 1;
	WebFXMenuBar.prototype.toString = function () {
		var str = "<div id='" + this.id + "' class='webfx-menu-bar'>";
		
		// loop through all menuButtons
		for (var i = 0; i < this._menuItems.length; i++)
			str += this._menuItems[i];
		
		str += "</div>";

		for (var i = 0; i < this._subMenus.length; i++)
			str += this._subMenus[i];
		
		return str;
	};

	function WebFXMenuButton(sText, sHref, sToolTip, oSubMenu) {
		this._parentConstructor = WebFXMenuItem;
		this._parentConstructor(sText, sHref, sToolTip, oSubMenu);
	}
	WebFXMenuButton.prototype = new WebFXMenuItem;
	WebFXMenuButton.prototype.toString = function () {
		return	"<a" +
				" id='" + this.id + "'" +
				" href='" + this.href + "'" +
				(this.toolTip ? " title='" + this.toolTip + "'" : "") +
				(op ? (
					" onoperafocus='webFXMenuHandler.overMenuItem(this)'" +
					(this.subMenu ? " onoperablur='webFXMenuHandler.blurMenu(this)'" : "")
				) : (
					" onfocus='webFXMenuHandler.overMenuItem(this)'" +
					(this.subMenu ? " onblur='webFXMenuHandler.blurMenu(this)'" : "")
				)) +
				" onmouseover='menuAparente=1;webFXMenuHandler.overMenuItem(this);this.focus()'" +
				">" +
				this.text + 
				(this.subMenu ? " <img class='arrow' src='" + "arrow.down.gif' align='absmiddle' width='6' height='3'>" : "") +				
				"</a>";
	};

	function WebFXMenuImage(sText, sHref, sToolTip, oSubMenu) {
		this._parentConstructor = WebFXMenuItem;
		this._parentConstructor(sText, sHref, sToolTip, oSubMenu);
	}
	WebFXMenuImage.prototype = new WebFXMenuItem;
	WebFXMenuImage.prototype.height = webfxMenuImageDefaultHeight;
	WebFXMenuImage.prototype.toString = function () {
		return	"<center><img border='0'" +
				" id='" + this.id + "'" +
				" src='" + this.href + "'" +
				(this.toolTip ? " title='" + this.toolTip + "'" : "") +
				(op ? (
					" onoperafocus='webFXMenuHandler.overMenuItem(this)'" +
					(this.subMenu ? " onoperablur='webFXMenuHandler.blurMenu(this)'" : "")
				) : (
					" onfocus='webFXMenuHandler.overMenuItem(this)'" +
					(this.subMenu ? " onblur='webFXMenuHandler.blurMenu(this)'" : "")
				)) +
				" onmouseover='menuAparente=1;webFXMenuHandler.overMenuItem(this);this.focus()'" +
				" alt='"+this.text + "'" +
				"></center>";
	};

	/* add onfocus/blur for anchors in opera
	* Opera 5.10 seems to support focus and blur but in reality it is even worse
	
	if (op) {
			document.onmousedown = function(e) {
			var a = e.target;
			while (a != null && a.tagName != "A") a = a.parentNode;

			if (document._oldFocus && document._oldFocus != a) {
				if (typeof document._oldFocus.onoperablur == "string") {
					var f = new Function ("event", document._oldFocus.onoperablur);
					document._oldFocus.onFakeBlur = f;
				}
				if (typeof document._oldFocus.onFakeBlur == "function") 
					document._oldFocus.onFakeBlur(e);
			}

			if (a && a != document._oldFocus) {
				document._oldFocus = a;
				if (typeof a.onoperafocus == "string") {
					var f = new Function ("event", a.onoperafocus);
					a.onFakeFocus = f;
				}
				if (typeof a.onFakeFocus == "function") 
					a.onFakeFocus(e);
			}
			else
				document._oldFocus = null;
		};
	}*/