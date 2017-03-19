<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomDetail.aspx.cs" Inherits="YY.TV.RoomDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="renderer" content="webkit|ie-comp|ie-stand">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="Bookmark" href="/favicon.ico">
    <link rel="Shortcut Icon" href="/favicon.ico" />
    <!--[if lt IE 9]>
<script type="text/javascript" src="lib/html5.js"></script>
<script type="text/javascript" src="lib/respond.min.js"></script>
<script type="text/javascript" src="lib/PIE_IE678.js"></script>
<![endif]-->
    <link rel="stylesheet" type="text/css" href="Content/static/h-ui/css/H-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/static/h-ui.admin/css/H-ui.admin.css" />
    <link rel="stylesheet" type="text/css" href="Content/lib/Hui-iconfont/1.0.7/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="Content/lib/icheck/icheck.css" />
    <link rel="stylesheet" type="text/css" href="Content/static/h-ui.admin/skin/default/skin.css" id="skin" />
    <link rel="stylesheet" type="text/css" href="Content/static/h-ui.admin/css/style.css" />
    <!--[if IE 6]>
<script type="text/javascript" src="http://lib.h-ui.net/DD_belatedPNG_0.0.8a-min.js" ></script>
<script>DD_belatedPNG.fix('*');</script>
<![endif]-->
    <!--/meta 作为公共模版分离出去-->

    <title>房间设置</title>
</head>
<body>
    <div class="page-container">
        <form class="form form-horizontal" id="form1" runat="server">
             <script>
                 var roomId=<%=roomId%>;
              </script>

            <div id="tab-system" class="HuiTab">
                <div class="tabBar cl"><span>房间信息</span></div>
                <!-- 基本信息列表 -->
                <div class="tabCon">

                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>房间标题：</label>
                        <div class="formControls col-xs-4 col-sm-4">
                            <input type="text" class="input-text" value="" placeholder="" id="RoomNameTxt" name="RoomNameTxt" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>主播名：</label>
                        <div class="formControls col-xs-4 col-sm-4">
                            <input type="text" class="input-text" value="" placeholder="" id="OwnerNameTxt" name="OwnerNameTxt" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>上传头像：</label>
                        <div class="formControls col-xs-4 col-sm-4" style="text-align: left;">
                            <img id="ImgRoomBG" width="140" height="140" runat="server" src="Content/images/img/flieUpLoad.jpg" />
                            <div id="uploadRoomBGFile" class="upload" style="margin:5px;width:86px;height:22px;top:-5px;background-color:#fff;line-height:35px;color:#459ae9;cursor:pointer;">点击上传</div>
                            <asp:HiddenField ID="HiddenFieldRoomBG" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>直播平台：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <select name="PlatTypeSelet" id="PlatTypeSelet" runat="server" class="select">
                            </select>
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>游戏分类：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <select name="PlatTypeSelet" id="RoomTypeSelect" runat="server" class="select">
                            </select>
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>主播时间：</label>
                        <div class="formControls col-xs-4 col-sm-4">
                            <input type="text" class="input-text" value="" placeholder="" id="PlayTimeTxt" name="PlayTimeTxt" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>播放地址：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <input type="text" class="input-text" value="" placeholder="" id="PlayUrlTxt" name="PlayUrlLTxt" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2">互动链接：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <input type="text" class="input-text" value="" placeholder="" id="ActiveUrlTxt" name="ActiveUrlTxt" runat="server" />
                        </div>
                    </div>

                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2">主播简介：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <textarea class="input-text" value="" style="height: 90px" id="OwnerInfoTxt" name="OwnerInfoTxt" runat="server"></textarea>
                        </div>
                    </div>
                       <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>房间状态：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <select name="StatusSelet" id="StatusSelet" runat="server" class="select">
                            </select>
                        </div>
                    </div>
                      <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>排序值：</label>
                        <div class="formControls col-xs-8 col-sm-9">
                            <input type="text" class="input-text" value="" placeholder="" id="OrderNumTxt" name="OrderNumTxt" runat="server" />
                        </div>
                    </div>
                    <div class="row cl">
                        <label class="form-label col-xs-4 col-sm-2">是否热门：</label>
                        <div class="formControls col-xs-8 col-sm-9">

                            <span style="margin-left: 20px;">
                                <input type="checkbox" runat="server" id="cbxIsHot" />
                                是  </span>

                        </div>
                   
                        <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2">
                            <button onserverclick="Savebtn_ServerClick" id="Savebtn" name="Savebtn" runat="server" class="btn btn-primary radius mt-20" type="submit"><i class="Hui-iconfont">&#xe632;</i> 提交</button>
                        </div>
                    </div>
                    <!-- 基本信息列表 -->


                    <div class="tabCon">
                    </div>
                </div>
        </form>
    </div>
    <!--_footer 作为公共模版分离出去-->
    <script type="text/javascript" src="Content/lib/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="Content/lib/layer/2.1/layer.js"></script>
    <script type="text/javascript" src="Content/lib/icheck/jquery.icheck.min.js"></script>
    <script type="text/javascript" src="Content/lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="Content/lib/jquery.validation/1.14.0/validate-methods.js"></script>
    <script type="text/javascript" src="Content/lib/jquery.validation/1.14.0/messages_zh.min.js"></script>
    <script type="text/javascript" src="Content/static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="Content/static/h-ui.admin/js/H-ui.admin.js"></script>
      <script type="text/javascript" src="Content/lib/SwfUpload/swfupload.js"></script>
    <!--/_footer /作为公共模版分离出去-->

    <!--请在下方写此页面业务相关的脚本-->
    <script type="text/javascript">
        $(function () {
            $('.skin-minimal input').iCheck({
                checkboxClass: 'icheckbox-blue',
                radioClass: 'iradio-blue',
                increaseArea: '20%'
            });
            $.Huitab("#tab-system .tabBar span", "#tab-system .tabCon", "current", "click", "0");
        });
    </script>
    <!--/请在上方写此页面业务相关的脚本-->
    <script>
       

        var _swf = new SWFUpload({
            upload_url: "WebService/Page/PageActionRequert.ashx",
            flash_url: "Content/lib/SwfUpload/SWFUpload.swf",
            file_size_limit: "2048",
            file_types: "*.jpg;*.gif",
            file_types_description: "TV Picture",
            file_upload_limit: "0",
            button_width: "70",
            button_height: "21",
            button_text: '<span class="testclass">点击上传</span>',
            button_text_style: '.testclass{color: #459ae9;font-family:"微软雅黑";font-size:14px;}',
            button_placeholder_id: "uploadRoomBGFile",
            post_params: {
                "action": "uploadRoomBGFile",
                "roomId": roomId   //$.cookie("11_GuildInfo_Param2")
            },
            file_dialog_complete_handler: function () {
                if (parseInt(arguments[0]) > 1) {
                    alert("只允许上传一份文件");
                    return false;
                }
                this.startUpload();
            },
            upload_success_handler: function () {

                var _response = eval('(' + arguments[1] + ')');
                if (_response.result > 0) {
                    $("#ImgRoomBG").attr("src", _response.url);
                    
                    $("#HiddenFieldRoomBG").val(_response.url);
                } else {
                    alert(_response.message);
                }
            },
            upload_error_handler: function (e) {
                alert("服务器繁忙,请稍后重试...");
            }
        });

        </script>
</body>
</html>
