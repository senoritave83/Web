/*
Sliding Menu Bar Script 2- © Dynamic Drive (www.dynamicdrive.com)
For full source code, installation instructions, and TOS
Visit http://www.dynamicdrive.com
*/

var ns4=document.layers?1:0
var ie4=document.all?1:0
var ns6=document.getElementById&&!document.all?1:0
var carregado = 0
window.status='Pressione "Ctrl+Shift+H" para chamar o assistente e para mandá-lo embora'

function showtip(nulling){
	if (ie4){
		if (nulling==0&&assistenteFlutuante.style.pixelLeft==-150)
			window.status='Pressione "Ctrl+Shift+H" para chamar o assistente e para mandá-lo embora'
		else
			assistenteFlutuante.title=''
	} else if (ns6){

	} else if (ns4){
		if (nulling==0&&!window.pullit)
			window.status='Pressione "Ctrl+Shift+H" para chamar o assistente e para mandá-lo embora'
		else
			window.status=''
	}
}
function regenerate(){
	window.location.reload()
}
function regenerate2(){
	if (document.layers)
		setTimeout("window.onresize=regenerate",400)
}
window.onload=regenerate2

function pull(){
	if (!carregado)
		mostraMascote();
	if (window.drawit)
		clearInterval(drawit)
	pullit=setInterval("pullengine()",50)
	carregado=1;
}
function draw(){
	clearInterval(pullit)
	drawit=setInterval("drawengine()",50)
}
function pullengine(){
	if (ie4&&themenu.pixelLeft<rightboundary)
		themenu.pixelLeft+=20
	else if (ns6&&parseInt(themenu.left)<rightboundary)
		themenu.left=parseInt(themenu.left)+20
	else if(ns4&&themenu.left<rightboundary)
		themenu.left+=20
	else if (window.pullit)
	clearInterval(pullit)
}
function drawengine(){
	if (ie4&&themenu.pixelLeft>leftboundary)
		themenu.pixelLeft-=20
	else if (ns6&&parseInt(themenu.left)>leftboundary)
		themenu.left=parseInt(themenu.left)-20
	else if(ns4&&themenu.left>leftboundary)
		themenu.left-=20
	else if (window.drawit)
		clearInterval(drawit)
}

if (ns4)
	document.captureEvents(Event.KEYPRESS)

function menuengine(e){
	if (ns4||ns6){
		if (e.which==8)
			vemMascote()
//		if (e.which==6)
//			draw()
	}
	else if (ie4){
		if (event.keyCode==8)
			vemMascote()
//		if (event.keyCode==6)
//			draw()
	}
}
function vemMascote() {
	if (ie4){
		if (themenu.pixelLeft>-10)
			draw()
	} else if(parseInt(themenu.left)>-10)
		draw()
	if (ie4){
		if (themenu.pixelLeft<0)
			pull()
	} else if(parseInt(themenu.left)<0)
		pull()
}
document.onkeypress=menuengine