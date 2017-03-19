<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YY.TV.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>直播</title>
    <link rel="stylesheet" type="text/css" href="https://g.5211game.com/5211/TVlive/css/base.css">
    <link rel="stylesheet" type="text/css" href="css/public.css?v=23">
    <link rel="stylesheet" type="text/css" href="css/index.css?2323">

    <script>
        var _hmt = _hmt || [];
        (function() {
            var hm = document.createElement("script");
            hm.src = "https://hm.baidu.com/hm.js?6fa90f5965eb4e375352e5090311c266";
            var s = document.getElementsByTagName("script")[0]; 
            s.parentNode.insertBefore(hm, s);
        })();
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="pagement" id="container">
            <% if (IsFristUser != true)
               {
            %>
            <div class="model">
            </div>
            <%} %>
            <!-- 头部导航 -->
            <div class="nav">
                <div class="inNavTab">
                    <img src="https://img.5211game.com/5211/TVlive/images/logo.jpg" height="68" width="54" alt="" class="logo">
                    <div class="tabChange_zhibo">
                        <a style="width: 100%; height: 100%; display: inline-block;" href="http://tvlive.5211game.com/web/index.aspx">
                            <img src="https://img.5211game.com/5211/TVlive/images/tabnavbg.jpg" height="136" width="436" alt="">
                        </a>
                    </div>
                    <div class="tabChange_shiping">
                        <a style="width: 100%; height: 100%; display: inline-block;" href="http://video.5211game.com/main/index.aspx">
                            <img src="https://img.5211game.com/5211/TVlive/images/tabnavbg.jpg" height="136" width="436" alt="">
                        </a>
                    </div>
                </div>
                <div class="Dividing">
                    <div class="indiving">
                        <a href="index.aspx?type=user">
                            <img src="https://img.5211game.com/5211/TVlive/images/mysc.jpg" height="12" width="13" alt="">我的收藏</a>
                        <span  style="display:none;"><em></em></span>
                    </div>
                </div>
            </div>
            <!-- 头部导航 -->

            <!-- 内容区域 -->
            <div class="mainBody" style="padding-bottom:36px;">
                <!-- 左边切换部分 -->
                <div class="inMain_Left">
                    <ul>
                        <li onclick="GoUrl('')" class="<%=(pageType=="defaut"?"current":"") %>">全部主播<em>>></em></li>
                        <li style="position: relative" onclick="GoUrl('hot')" class="<%=(pageType=="hot"?"current":"") %>">
                            <img src="https://img.5211game.com/5211/TVlive/images/hot.png" style="position: absolute; top: 0px; left: 0px; width: 32px; height: 37px;" />
                            热门主播</li>
                          <li onclick="GoUrl('5')" class="<%=(pageType=="5"?"current":"") %>">斗鱼从零单排</li>
                        <li onclick="GoUrl('1')" class="<%=(pageType=="1"?"current":"") %>">DotA</li>
                        <li onclick="GoUrl('2')" class="<%=(pageType=="2"?"current":"") %>">IMBA</li>
                        <li onclick="GoUrl('3')" class="<%=(pageType=="3"?"current":"") %>">真三</li>
                        <li onclick="GoUrl('4')" class="<%=(pageType=="4"?"current":"") %>">RPG</li>
                    </ul>
                </div>
                <!-- 左边切换部分 -->

                <!-- 右边内容部分 -->
                <div class="inMain_Right">
                    <ul id="listContainer">
                        <%foreach (Model.T_RoomModel item in T_RoomModelList)
                          { %>
                        <li>
                           
                                <div class="bannerBg">
                                    <% if (item.IsHot == 1)
                                       { %>
                                    <div class="hot"></div>
                                    <%} %>
                                    <%=item.isLive==1?"<div class=\"zhibo_zt\">直播中</div>":"<div class=\"zhibo_zt1\">休息</div>" %>
                                    
                                     <a href="Room.aspx?roomId=<%=item.RoomId %>&pageType=<%=pageType %>">
                                    <img src="<%=item.RoomBG %>" height="190" width="190" alt="">
                                          </a>
                                    <div class="gameName">
                                        <%=GetRoomTypeName(item.RoomType) %>
                                    </div>
                                    <div class="like">

                                        <i class="xin"></i>
                                        <%=item.CollectNum %>
                                    </div>
                                    <div class="mb"></div>
                                </div>



                                <div class="tvChange">
                                    <span class="name"><%=item.OwnerName %></span>
                                    <span class="douyu">
                                        <img src="https://img.5211game.com/5211/TVlive/images/<%=GetPlatName(item.PlatType)%>.png" height="17" width="18" alt=""></span>
                                </div>
                                <div class="infor">
                                    <%=item.RoomName %>
                                </div>


                           
                        </li>

                        <%} %>
                    </ul>
                    <div id="loadingTxt" style="text-align: center; display: none; line-height: 30px; height: 30px;">加载中...</div>
                </div>
                <!-- 右边内容部分 -->
            </div>
            <!-- 内容区域 -->
            <!-- 尾部 -->
            <div class="footer">
                <div class="main">
                    <div class="link">
                        <dl>
                            <dt><a href="http://www.5211game.com/">
                                <img src="http://static.7fgame.com/11video/images/logo_11.jpg" width="142" height="60" alt="11对战平台"></a><a href="#"><img src="http://static.7fgame.com/11video/images/logo_11_video.jpg" style="width: 54px; height: 57px;" alt="11对战平台视频中心"></a></dt>
                            <dd><a href="#">关于平台&nbsp;|</a><a href="#">商务合作&nbsp;|</a><a href="#">招聘信息&nbsp;|</a><a href="#">客服中心&nbsp;|</a><a href="#">家长监护&nbsp;|</a><a href="#">虚拟货币服务说明&nbsp;|</a><a href="#">使用协议&nbsp;|</a><a href="#">服务条款</a><span>Copyright 2011 11对战平台.All rights reserved.
                                <br>
                                沪ICP备15038004号-2  沪网文【2016】0225-125号</span></dd>
                        </dl>
                    </div>
                </div>
            </div>
            <!-- 尾部 -->
        </div>
        <script type="text/javascript" src="https://g.5211game.com/5211/TVlive/js/jQuery.js"></script>
        <script type="text/javascript" src="js/public.js"></script>
        <script>
            function GoUrl( pageType)
            {
                switch(pageType)
                {
                    case "":
                        window.location.href = "index.aspx";
                        break;
                    case "hot":
                        window.location.href = "index.aspx?type=hot";
                        break;
                    case "1":
                        window.location.href = "index.aspx?type=1";
                        break;
                    case "2":
                        window.location.href = "index.aspx?type=2";
                        break;
                    case "3":
                        window.location.href = "index.aspx?type=3";
                        break;
                    case "4":
                        window.location.href = "index.aspx?type=4";
                        break;
                    case "5":
                        window.location.href = "index.aspx?type=5";
                        break;
                }
            }
            $(document).ready(function ($) {
                <% if (IsFristUser== true)
                   {
            %>
                $('.model').css('display', 'none');
                $('.indiving span').css('display', 'none');
                <%}
                   else
                   { 
                  %>
                $('.model').css('display', '');
                $('.indiving span').css('display', '');
               <%}%>
            });
          
            // 滚动条下拉加载
            var oContainer = document.getElementById('container');
            var num = 1;

            window.onscroll = function () {
                var allHeight = oContainer.offsetHeight;
                var viewHeight=document.documentElement.clientHeight;
                var ScrTHeight=document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop;
              

                if (allHeight - viewHeight - ScrTHeight ==0) {
                                          
                                           
                    if(num+1<=<%=ListPageNum%>)
                    {
                                            num++;
                    loadroomlist(<%=userId%>,num);
                }

                /*
                if (num <= 6) {
                    $('#listContainer').append('<li style="background:red;">' + 432142314321 + '</li>');
                    $('#listContainer').append('<li style="background:red;">' + 432142314321 + '</li>')
                    if (num <= 5) {
                        $('#listContainer').append('<li style="background:red;">' + 432142314321 + '</li>')
                        $('#listContainer').append('<li style="background:red;">' + 432142314321 + '</li>')
                    };
                };
                */

            };
                               
            }

            function loadroomlist(userid,curpage) {
                
                $("#loadingTxt").css('display', 'block');
                setTimeout(function(){ addList(userid,curpage); } ,1000);
                //addList(userid,curpage);
            }

         

            function addList(userid,curpage)
            {
                
                $.ajax({
                    type: "Post",
                    url: "WebService/Page/PageActionRequert.ashx",
                    async: false,
                    data: "action=loadroomlist&userid=" + userid +  "&curpage=" + curpage+"&type=<%=pageType %>" ,
                    success: function (data) {
                        if (data.Code == 0) {
                            $("#loadingTxt").css('display', 'none');
                            $('.comment-box').empty();
                            $.each(data.Value, function (n, value) {

                                var hotHtml="";
                                if(value.IsHot==1)
                                {
                                    hotHtml='<div class="hot"></div>';
                                }

                                $('#listContainer').append('<li >' +
                                   '<div class="bannerBg">'+
                                    hotHtml+GeLiveName(value.isLive)+
                                     '<a href="Room.aspx?roomId='+value.RoomId+'&pageType=<%=pageType %>">'+

							'<img src="'+value.RoomBG+'" height="190" width="190" alt="">'+
                            '</a>'+
							'<div class="gameName">'+GetRoomTypeName(value.RoomType)+'</div>'+
                             '<div class="like">'+'<i class="xin"></i>'+value.CollectNum+'</div>'+
							'<div class="mb"></div>'+
						    '</div>'+
						    '<div class="tvChange">'+
							    '<span class="name">'+value.OwnerName+'</span>'+
							    '<span class="douyu"><img src="https://img.5211game.com/5211/TVlive/images/'+GetPlatName(value.PlatType)+'.png" height="17" width="18" alt=""></span>'+
						    '</div>'+
						    '<div class="infor">'+
                                    value.RoomName+
						    '</div></li>');
                            }
                            );
                        }
                    }
                });

            }

            function GeLiveName(RoomType)
            {
                switch (RoomType)
                { 
                    case 0:
                        return '<div class="zhibo_zt1">休息</div>';
                    case 1:
                        return '<div class="zhibo_zt">直播中</div>';
                }
            }


            function GetRoomTypeName(RoomType)
            {
                switch (RoomType)
                { 
                    case 1:
                        return "DOTA";
                        break;
                    case 2:
                        return "IMBA";
                        break;
                    case 3:
                        return "真三";
                        break;
                    case 4:
                        return "RPG";
                        break; 
                    case 5:
                        return "斗鱼从零单排";
                        break;
                    default:
                        return "";
                }
            }

            function GetPlatName( PlatType)
            {
                switch (PlatType)
                {
                    case 1:
                        return "douyu";
                        break;
                    case 2:
                        return "xm";
                        break;
                    case 3:
                        return "huya";
                        break;
                    case 4:
                        return "quanming";
                        break;
                    default:
                        return "";
                }
            }

            // 滚动条下拉加载
        </script>

    </form>
</body>
</html>
