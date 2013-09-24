function slideSwitch() {
	var $active = $('#mvPanel li.active');
	var $next =  ($active.next().length ? $active.next() : $('#mvPanel li:first'));
	var $activeThumb = $('#mvThumbnail li.active');
	var $nextThumb =  ($activeThumb.next().length ? $activeThumb.next() : $('#mvThumbnail li:first'));
	$active.fadeOut('fast').removeClass("active");
	$next.fadeIn('fast').addClass("active");
	$activeThumb.removeClass("active");
	$nextThumb.addClass("active");
	$('#globalNav ul').removeClass('b');
	$('#globalNav ul').removeClass('w');
	if($next.hasClass("w")){$('#globalNav ul').addClass('w');}else{$('#globalNav ul').addClass('b');}
}

$(function() {
rotateSwitch = function(){
	play=setInterval( "slideSwitch()", 5000 );
};

rotateSwitch();

$("#mvThumbnail a").hover(function() {
	$('#mvPanel li.active').fadeOut('fast').removeClass('active');
	$('#mvThumbnail li.active').removeClass('active');
	var num=($(this).attr("rel"));
	$($('#mvPanel li')[num]).fadeIn('fast').addClass('active');
	$($('#mvThumbnail li')[num]).addClass('active');
	$('#globalNav ul').removeClass('b');
	$('#globalNav ul').removeClass('w');
	if($($('#mvPanel li')[num]).hasClass("w")){$('#globalNav ul').addClass('w');}else{$('#globalNav ul').addClass('b');}
	clearInterval(play);
	}, function() {
	rotateSwitch();
});

});

