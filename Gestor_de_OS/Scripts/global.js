/* www.itelios.com - 2011 - global */
$(function() {
						   
 $('.menuCat li, .menu li').hover(
	  function(){
		  $(this).addClass('over');							
	  },
	  function(){
		  $(this).removeClass('over');	
	  }
  );
  
  //toggle backup/ perguntas frequentes	
  
  $('.containerPerguntas li').children('p, div').hide();
  $('.containerPerguntas li:first').addClass('open');
  $('.containerPerguntas li:first').children('p, div').show();
  
  $('.containerPerguntas li > a').click(function () {
	  if($(this).parent('li').hasClass('open')){
		  $(this).siblings('p, div').slideUp();
	  }
	  else {
		  $(this).siblings('p, div').slideDown();
	  }
	  $(this).parent('li').toggleClass('open');	
	  return false;
  });    
  //IE6
  $('.containerPerguntas li').hover(function () {
	  $(this).addClass("over");
	},
	function () {
	  $(this).removeClass("over");
	}
  );
    // Desabiltado, comendo o espaço em branco.    //custom drop down
    //try {
    //$("body select").msDropDown();
    //} catch(e) {
    //alert(e.message);
    //}

	//tabs 
	
	$("#tabs > div > div").hide();
	$("#tabs > div > div:first").show();
	$("#tabs ul li a").click(function(){
		$("#tabs > ul > li").removeClass('current');
		$(this).parent().addClass('current');
		$("#tabs > div > div").hide();
		var content_show = $(this).attr("href");
	   $(content_show).show();
	   return false;
	});
			
	//pop up download
	
	$(".opcoesAparelhos").hide();
	$(".aparelho a").click(function(){
		$(".opcoesAparelhos").show();
		return false;
	});
	$(".closeContainer a").click(function(){
		$('.opcoesAparelhos').hide();			
		return false;
	});		

	//voltar button
	$(".voltar").click(function(){
		history.go(-1);	
		return false;
	});

		// colorbox call

	$('.ajudaTela').colorbox({width:"575px", height:"388px;", innerHeight: "382px",  initialWidth: "800px", initialHeight: "450px", opacity: '0.7'});
});
  
  
