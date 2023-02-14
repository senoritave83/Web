function Inv(Wid, Hei) {
	w('<img src="/imagens/comuns/invisivel.gif" width="' + Wid + '" height="' + Hei + '" border=0>');
}
function w(Tex) {
	document.write(Tex);
}

function CaixaM1(Lar, Alt, Memo, Tag, Txt, Fonte, Bor, Fun) {
	w('<table width="' + Lar + '" border=0 cellpadding=0 cellspacing=0><tr><td align=right width="' + Lar + '"><table border=0 cellspacing=0 cellpadding=0 bgcolor=' + Bor + '><tr><td width=9 height=19 valign=top><img src="/imagens/tags/' + Tag + '/tag_pe.gif" width=9 height=7 border=0></td><td nowrap class=f8><font color=' + (Fonte == '' ? 'black' : Fonte) + '><b>' + Txt + '</b></font></td><td width=9 height=19 valign=top><img src="/imagens/tags/' + Tag + '/tag_pd.gif" width=9 height=7 border=0></td></tr></table></td></tr><tr><td bgcolor="' + Bor + '"><table width="100%"' + (Alt != '' && Alt != 0 ? ' height="' + Alt + '"' : '') + ' border=0 cellpadding=0 cellspacing=1><tr><td valign=top bgcolor="' + Fun + '" class=f8><img src="/imagens/memo/' + Memo + '" width=168 height=145 border=0><table width="100%" border=0 cellspacing=0 cellpadding=6><tr><td class=f8>');
}
function CaixaM2() {
	w('</td></tr></table></td></tr></table></td></tr></table>');
}

function Not(Cod,Texto) {
	w(
	'<img src="/imagens/home/seta_preta.gif" width=10 height=8 border=0><a href="/vestibular/noticia.asp?CodigoNoticia=' + Cod + '">' + Texto + '</a><br>'
	);
}

function CaixaR1(Lar, Tag, Txt, Fonte, Bor, Fun) {
	w('<table width="' + Lar + '" border=0 cellpadding=0 cellspacing=0><tr><td align=right><table border=0 cellspacing=0 cellpadding=0 bgcolor=' + Bor + '><tr><td width=9 height=19 valign=top><img src="/imagens/tags/' + Tag + '/tag_pe.gif" width=9 height=7 border=0></td><td nowrap class=f8><font color=' + (Fonte == '' ? 'black' : Fonte) + '><b>' + Txt + '</b></font></td><td width=9 height=19 valign=top><img src="/imagens/tags/' + Tag + '/tag_pd.gif" width=9 height=7 border=0></td></tr></table></td></tr><tr><td bgcolor="' + Bor + '"><table width="' + Lar + '" border=0 cellpadding=12 cellspacing=1><tr><td bgcolor="' + Fun + '" class=f8>');
}
function CaixaR2() {
	w('</td></tr></table></td></tr></table>');
}

function CaixaQ1(Lar, Txt, Cor, Bor, Fun) {
	w('<table width="' + Lar + '" bgcolor="' + Bor + '" border=0 cellpadding=0 cellspacing=0><tr><td height=21 class=f10 nowrap>');
	Inv(1,1);
	w('<br>');
	Inv(13,1);
	w((Cor != '' ? '<font color=' + Cor + '>' : '') + '<b>' + Txt + '</b>' + (Cor != '' ? '</font>' : '') + '</td></tr><tr><td><table width="' + Lar + '" border=0 cellpadding=9 cellspacing=1><tr><td bgcolor="' + Fun + '" class=f7>');
}
function CaixaQ2() {
	w('</td></tr></table></td></tr></table>');
}
function IM(Titulo, Url) {
	w ('<tr valign=top><td width=14><a href="' + Url + '" class=nohover><img src="/imagens/home/menu.gif" width=4 height=12 border=0></a></td><td width=132 class=f10><a href="' + Url + '">' + Titulo + '</a></font></td></tr><tr><td><img src="/imagens/comuns/invisivel.gif" width=12 height=2 border=0></td></tr>');
}

function AbrePopup (url, target, width, height) {
	var popup = window.open('', 'popup_' + target, 'menu=0,history=0,scrollbars=0,resizable=0,toolbar=0,width=' + width + ',height=' + height);
	popup.location.href = url;
	popup.focus();
}

function Caixa1a (Lar, Alt, Cor1, Cor2, Tit) {
	w('<table cellpadding=0 cellspacing=0 border=0 width=' + Lar + ' height=' + Alt + '><tr><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td><td width="100%" style="border-top: solid 1px black;" height=2 bgcolor="#949494"><script>Inv(1,1);</script></td><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td></tr><tr><td colspan=3 height=13 style="border-left: solid 1px black; border-right: solid 1px black;" bgcolor="' + Cor1 + '" class="f7 b w">&nbsp;&nbsp;' + Tit + '</td></tr><tr><td colspan=3 style="border: solid 1px black;" valign=top bgcolor="' + Cor2 + '"><table width="100%" height="100%" cellpadding=0 cellspacing=5 border=0><tr><td valign=top class=f8>');
}

function Caixa1f () {
	w('</td></tr></table></td></tr></table>');
}

function Barra1 (Lar, Cor, Tit) {
	w('<table cellpadding=0 cellspacing=0 border=0 width=' + Lar + '><tr><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td><td width="100%" style="border-top: solid 1px black;" height=2 bgcolor="#949494"><script>Inv(1,1);</script></td><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td></tr><tr><td colspan=3 height=14 style="border-left: solid 1px black; border-right: solid 1px black; border-bottom: solid 1px black;" bgcolor="' + Cor + '" class="f7 b w">&nbsp; ' + Tit + '</td></tr></table>');
	Inv(1,8);
	w('<br>');
}

function Barra2 (Lar, Cor, Tit, Lin) {
	w('<table cellpadding=0 cellspacing=0 border=0 width=' + Lar + '><tr><td><table cellpadding=0 cellspacing=0 border=0 width="100%"><tr><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td><td width="100%" style="border-top: solid 1px black;" height=2 bgcolor="#949494"><script>Inv(1,1);</script></td><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td></tr><tr><td colspan=3 height=14 style="border-left: solid 1px black; border-right: solid 1px black; border-bottom: solid 1px black;" bgcolor="' + Cor + '" class="f7 b w">&nbsp; ' + Tit + '</td></tr></table></td><td width=5></td><td width=55><table cellpadding=0 cellspacing=0 border=0 width=62><tr><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td><td width="100%" style="border-top: solid 1px black;" height=2 bgcolor="#949494"><script>Inv(1,1);</script></td><td width=1 height=2 valign=top><img src="/imagens/comuns/ponta_tabela.gif" width=1 height=2 border=0></td></tr><tr><td colspan=3 height=14 style="border-left: solid 1px black; border-right: solid 1px black; border-bottom: solid 1px black;" bgcolor="' + Cor + '" class="f7 b w">&nbsp;<a href="' + Lin + '" class=w>veja mais</a></td></tr></table></td></tr></table>');
}




