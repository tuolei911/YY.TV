<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="YY.TV.RoomList" %>

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
<script type="text/javascript" src="lib/DD_belatedPNG_0.0.8a-min.js" ></script>
<script>DD_belatedPNG.fix('*');</script>
<![endif]-->
    <title>管理员列表</title>
    <style type="text/css">
        .text-c td img {
            width: 50px;
            height: 50px;
        }
        .table td {
    text-align: center;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <nav class="breadcrumb">
            <i class="Hui-iconfont">&#xe67f;</i>房间列表 <a class="btn btn-success radius r" style="line-height: 1.6em; margin-top: 3px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a>
        </nav>

        <div class="page-container">
            <div class="cl pd-5 bg-1 bk-gray ">
                <span class="r">
                    <a href="javascript:;" onclick="showUrl('房间管理','RoomDetail.aspx','1000','800')" class="btn btn-primary radius"><i class="Hui-iconfont"></i>添加房间</a>

                </span>
            </div>
            <div class="mt-20">
                <table class="table table-border table-bordered table-bg table-hover table-sort">
                    <thead>
                        <tr class="text-c">
                            <th width="80">房间id</th>
                            <th width="80">房间标题</th>
                            <th width="80">主播名</th>
                             <th width="80">头像</th>
                            <th width="80">直播平台</th>
                              <th width="80">直播时间</th>
                              <th width="80">收藏数</th>
                            
                             <th width="80">排序值</th>
                             <th width="80">状态</th>
                            <th width="80">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                    <% foreach( Model.T_RoomModel item in T_RoomModelList)
                       { %>
                        <tr class="text-c">
                            <td><%=item.RoomId %></td>
                            <td><%=item.RoomName %></td>
                            <td><%=item.OwnerName %></td>
                              <td> <img width="80" height="80" src="<%=item.RoomBG %>" /></td>
                            <td><%=  GetPlatName(item.PlatType) %></td>
                            <td><%=item.PlayTime %></td>
                            <td><%=item.CollectNum %></td>
                            <td><%=item.OrderNum %></td>
                             <td><%= item.Status==1?"上线":"隐藏" %></td>
                            <td>
                                 <a style="text-decoration: none" class="ml-20" onclick="showUrl('房间管理','RoomDetail.aspx?roomId=<%=item.RoomId %>','1000','800')" href="javascript:;" title="明细">明细</a>
                                <a style="text-decoration: none; margin-left:20px;" class="ml-20" onclick="admin_del(<%=item.RoomId %>)" href="javascript:;" title="删除">删除</a>
                            </td>

                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
        </div>

        <script type="text/javascript" src="Content/lib/jquery/1.9.1/jquery.min.js"></script>
        <script type="text/javascript" src="Content/lib/layer/2.1/layer.js"></script>
        <script type="text/javascript" src="Content/lib/laypage/1.2/laypage.js"></script>
        <script type="text/javascript" src="Content/lib/datatables/1.10.0/jquery.dataTables.min.js"></script>
        <script type="text/javascript" src="Content/lib/My97DatePicker/WdatePicker.js"></script>
        <script type="text/javascript" src="Content/static/h-ui/js/H-ui.js"></script>
        <script type="text/javascript" src="Content/static/h-ui.admin/js/H-ui.admin.js"></script>
        <script type="text/javascript">
            /*
                参数解释：
                title	标题
                url		请求的url
                id		需要操作的数据id
                w		弹出层宽度（缺省调默认值）
                h		弹出层高度（缺省调默认值）
            */
            $('.table-sort').dataTable({
                //"aaSorting": [[1, "desc"]],//默认第几个排序
                ordering: true,
                bLengthChange: false,
                "bStateSave": false,//状态保存
                "aoColumnDefs": [
                  //{"bVisible": false, "aTargets": [ 3 ]} //控制列的隐藏显示
                  //{ "orderable": false, "aTargets": [0, 2] }// 不参与排序的列
                ]
            });

            /*图片-添加*/
            function showUrl(title, url, w, h) {

                layer_show(title, url, w, h);
            }

          

            function admin_del(id) {
                layer.confirm('确认要删除吗？', function (index) {
                    //此处请求后台程序，下方是成功后的前台处理……
                    var url = 'WebService/Page/PageActionRequert.ashx?roomId=' + id + '&action=DelRoom';
                    $.post(url, function (m) {
                        if (m.Code == 0) {
                            layer.msg('已删除!', { icon: 1, time: 1000 });
                            self.location.reload();
                        }
                        else {
                            layer.msg('删除失败!', { icon: 1, time: 1000 });
                        }
                    });
                   
                });
            }

        </script>
    </form>
</body>
</html>
