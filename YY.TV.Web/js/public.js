// 公共部分顶部直播视频切换js
jQuery(document).ready(function($) {
	$(document).on('click', '.tabChange_zhibo', function(event) {
	$(this).children('img').css('top',-68);
	$(this).next().children('img').css('top',0);
	});
	$(document).on('click', '.tabChange_shiping', function(event) {
	$(this).children('img').css('top',-68);
	$(this).prev().children('img').css('top', 0);
	});
    // 公共部分顶部直播视频切换js
    //移上去显示蓝条//
	$(document).on('mouseenter', '.tabChange_zhibo', function (event) {
	    $(this).find('img').stop().css('top', -68);
	});
	$(document).on('mouseleave', '.tabChange_zhibo', function (event) {
	    $(this).find('img').stop().css('top', -68);
	});
	$(document).on('mouseenter', '.tabChange_shiping', function (event) {
	    $(this).find('img').stop().css('top', -68);
	});
	$(document).on('mouseleave', '.tabChange_shiping', function (event) {
	    $(this).find('img').stop().css('top', 0);
	});
    //移上去显示蓝条//


  // 首页热门游戏类型切换
	$(document).on('click', '.inMain_Left ul li', function(event) {
		$(this).addClass('current').siblings().removeClass('current')
	});

  // 首页热门游戏类型切换
  
 
 

 //// 收藏爱心点击
 //$(document).on('click', '.like i', function(event) {
 //	if ($(this).hasClass('xin')) {
 //		$(this).removeClass('xin');
 //	}else if (!$(this).hasClass('xin')) {
 //		$(this).addClass('xin')
 //	}
 //})
 //// 收藏爱心点击
 

 // 悬浮上去添加蒙版
$(document).on('mouseover', '.inMain_Right ul li', function(event) {
    $(this).find('.mb').stop().hide();
});
$(document).on('mouseleave', '.inMain_Right ul li', function(event) {
    $(this).find('.mb').stop().fadeIn(200);
});
 // 悬浮上去添加蒙版


// 关闭悬浮蒙版
$(document).on('click', '.indiving span', function(event) {
	$('.model').css('display', 'none');
	$(this).css('display', 'none');
});


$(document).on('click', '.header_intro span.tc', function(event) {
	$('.model').css('display', 'none');
	$(this).css('display', 'none');
});
//关闭悬浮蒙版

});





