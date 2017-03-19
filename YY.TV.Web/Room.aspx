<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="YY.TV.Web.Room" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>直播</title>
    <link rel="stylesheet" type="text/css" href="https://g.5211game.com/5211/TVlive/css/base.css">
    <link rel="stylesheet" type="text/css" href="css/public.css">
    <link rel="stylesheet" type="text/css" href="css/playaudio.css">
    <script type="text/javascript" src="https://g.5211game.com/5211/TVlive/js/jQuery.js"></script>
        <script type="text/javascript" src="js/public.js"></script>
        <script src="http://static.7fgame.com/advSysFiles/AdScripts/YYAD-Min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="pagement">
            <div class="model" style="display: none">
            </div>
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
                        <a href="index.aspx?type=<%=pageType %>">
                            <img src="https://img.5211game.com/5211/TVlive/images/fh.jpg" height="13" width="14" alt="">返回</a>
                    </div>
                </div>
            </div>
            <!-- 头部导航 -->

            <!-- 内容区域 -->
            <div class="mainBody">
                <div class="headerTitle">
                    <em></em><%=item.RoomName %>
                </div>
                <div class="bodyContent">
                    <div class="videoMain">
                        <!-- 这里放视频 -->
                        <% if( item.PlayUrl!="")
                              { %>
                              <iframe style="border:none;position;absolute;" width="707" height="436" src="<%=item.PlayUrl %>">
                            </iframe>
                        <%}
                          else
                          { %>
                        <img src="https://img.5211game.com/5211/TVlive/images/mr.jpg" height="436" width="707" alt="">
                        <%} %>
                        <!-- 这里放视频 -->
                    </div>
                    <div class="inforMain">
                        <div class="header_intro">
                            <span class="userPic">
                                <img src="<%=item.RoomBG %>" height="65" width="65" alt=""></span>
                            <span class="userName"><%=item.OwnerName %></span>
                            <span class="userTv">
                                <img src="https://img.5211game.com/5211/TVlive/images/<%=GetPlatName(item.PlatType)%>.png" height="16" width="17" alt=""></span>
                            <div class="like">
                                <%if (IsCollect == true)
                                  { %>
                                <i id="collectI" onclick="delCollect(this,<%=userId %>,<%=roomId %>)" class="xin"></i>
                                <%}
                                  else
                                  { %>
                                <i id="collectI" onclick="addCollect(this,<%=userId %>,<%=roomId %>)" class=""></i>
                                <%} %>
                                <span class="CollectNum"><%=item.CollectNum %> </span>
                            </div>
                            <span class="tc" style="display:none"><em></em></span>
                        </div>
                        <div class="body_intro">
                            <p><em>直播时间:</em><%=item.PlayTime %></p>
                            <p><em>主播简介:</em><%=item.OwnerInfo %></p>
                        </div>
                    </div>
                </div>
                <div class="tbodyMain">
                    <div class="bodyLeft" style="float: left">
                        <div class="comment">
                            <div class="Collection">
                                <span><i></i>收藏次数:<em><span class="CollectNum"><%=item.CollectNum %> </span></em></span>
                                <span class="hd" style="width:400px">
                                 <%--    <a style="float:right; " href="<%=item.PlayUrl %>" target="_blank">
                                    <img src="https://img.5211game.com/5211/TVlive/images/button.jpg" height="33" width="164" alt=""></a>--%>
                                    <a style="float:right;margin-right:10px;" href="<%=item.ActiveUrl %>" target="_blank">
                                    <img src="https://img.5211game.com/5211/TVlive/images/hd.jpg" height="33" width="164" alt=""></a></span>
                            </div>
                            <div class="Tucao">
                                <span><i></i>评论吐槽</span>
                            </div>
                        </div>

                        <div id="divPhraseList" class="comment-box">
                        </div>

                        <div class="tu-box">
                            <input id="txtPhrase" type="text" class="tu-ipt" placeholder="一起来吐槽" maxlength="10">
                            <input id="btnPhrase" type="button" class="tu-btn" value="发送吐槽">
                        </div>
                    </div>
                </div>
                <div class="advanter" style="width: 267px; height: 178px; float: right;margin-right:30px;">
                    <script>YYAD.LoadAds(1115);</script>
                </div>
            </div>

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
        

        <script>
            $(document).ready(function ($) {
                <% if (IsFristUser == true)
                   {
                 %>
                $('.model').css('display', 'none');
                $('.header_intro span.tc').css('display', 'none');
                <%}
                   else
                   { %>
                $('.model').css('display', '');
                $('.header_intro span.tc').css('display', '');
                <%}%>
                bindcomment(<%=roomId %>);
            });

            function addCollect(obj,userid, roomid)
            {
                $.ajax({
                    type: "Post",
                    url: "WebService/Page/PageActionRequert.ashx",
                    async: false,
                    data: "action=addCollect&userid=" + userid + "&roomid=" + roomid,
                    success: function (data) {
                        if (data.Code == 0) {
                            if ($(obj).hasClass('xin')) {
                                $(obj).removeClass('xin');
                            } else if (!$(obj).hasClass('xin')) {
                                $(obj).addClass('xin')
                            }

                            document.getElementById('collectI').onclick = function(){ 
                                delCollect(obj,userid, roomid);
                            }; 

                            getCollect(roomid);
                        }
                    }
                });
            }

            function delCollect(obj,userid, roomid) {
                $.ajax({
                    type: "Post",
                    url: "WebService/Page/PageActionRequert.ashx",
                    async: false,
                    data: "action=delCollect&userid=" + userid + "&roomid=" + roomid,
                    success: function (data) {
                        if (data.Code == 0) {
                            if ($(obj).hasClass('xin')) {
                                $(obj).removeClass('xin');
                            } else if (!$(obj).hasClass('xin')) {
                                $(obj).addClass('xin')
                            }
                            document.getElementById('collectI').onclick = function(){ 
                                addCollect(obj,userid, roomid);
                            };
                            getCollect(roomid);
                        }
                    }
                });
            }

            function getCollect( roomid) {
                $.ajax({
                    type: "Post",
                    url: "WebService/Page/PageActionRequert.ashx",
                    async: false,
                    data: "action=GetCollectNum&roomid=" + roomid,
                    success: function (data) {
                        if (data.Code == 0) {
                            $(".CollectNum").text(data.Value);
                        }
                    }
                });
            }



            function bindcomment(roomid)
            {
                $.ajax({
                    type: "Post",
                    url: "WebService/Page/PageActionRequert.ashx",
                    async: false,
                    data: "action=bindcomment&roomid=" + roomid,
                    success: function (data) {
                        if (data.Code == 0) {
                            $('.comment-box').empty();
                            $.each(data.Value, function (n, value) {
                                if(value.CommentNum<10)
                                    $('.comment-box').append('<span onclick=" addcomment(<%=userId %>,<%=roomId %>,\'' + value.CommentTxt + '\') " ><a href="javascript:void(0);"  param="194060" class="option-red3">' + value.CommentTxt + '</a></span>');
                                else if(value.CommentNum>=10 && value.CommentNum<=30 )
                                    $('.comment-box').append('<span onclick=" addcomment(<%=userId %>,<%=roomId %>,\'' + value.CommentTxt + '\') " ><a href="javascript:void(0);"  param="194060" class="option-red2">' + value.CommentTxt + '</a></span>');
                                else if(value.CommentNum>30)
                                    $('.comment-box').append('<span onclick=" addcomment(<%=userId %>,<%=roomId %>,\'' + value.CommentTxt + '\') " ><a href="javascript:void(0);"  param="194060" class="option-red1">' + value.CommentTxt + '</a></span>');
                            }
                            );
                }
                    }
                });
    }

    // 阻止快速发表言论js
    var comment;
    var timeOut = 1000;
    var date1 = null;
    $(document).on('click', '.tu-btn', function (event) {
        comment = $('.tu-ipt').val();
        if (comment == '') {
            return false
        } else if (!date1) {
            date1 = new Date();
            bindcomment(<%=roomId %>);
            addcomment(<%=userId %>,<%=roomId %>,comment);
        } else {
            var now = new Date();
            var timespan = now.getTime() - date1.getTime();
            if (timespan < timeOut) {
                alert('您的操作太快了')
            } else {

                date1 = new Date();
                addcomment(<%=userId %>,<%=roomId %>,comment);
            };
        };
    });
// 阻止快速发表言论js

function addcomment(userid, roomid, msgcomment)
{
    $.ajax({
        type: "Post",
        url: "WebService/Page/PageActionRequert.ashx",
        async: false,
        data: "action=addcomment&roomId=" + roomid + "&userId=" + userid + "&Comment=" + msgcomment,
        success: function (data) {
            if (data.Code == 0) {
                if( data.Msg!='提交成功')
                {
                    alert(data.Msg);
                }
                bindcomment(roomid);
            }
        }
    });
}


        </script>

    </form>
</body>
</html>
