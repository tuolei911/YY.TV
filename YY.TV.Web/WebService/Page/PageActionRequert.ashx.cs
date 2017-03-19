using BaseClasses;
using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace YY.TV.Web.WebService.Page
{
    /// <summary>
    /// PageActionRequert 的摘要说明
    /// </summary>
    public class PageActionRequert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];

            switch (action)
            {
                case "addCollect":
                    addCollect(context);
                    break;

                case "delCollect":
                    delCollect(context);
                    break;

                case "bindcomment":
                    bindcomment(context);
                    break;
                case "addcomment":
                    addcomment(context);
                    break;
                case "loadroomlist":
                    loadroomlist(context);
                    break;
                case "GetCollectNum":
                    GetCollectNum(context);
                    break;
            }
        }
        public void GetCollectNum(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomId"] != null)
            {
                roomId = int.Parse(context.Request["roomId"]);
            }


            RetInfo<int> result = new RetInfo<int>() { Code = 0, Value = 0 };

            T_RoomModel item = new T_RoomBLL().Get(roomId);
            if (item != null)
            {
                result.Value = item.CollectNum;
            }
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }


        public void loadroomlist(HttpContext context)
        {
            int curpage = 1;
            if (context.Request["curpage"] != null)
            {
                curpage = int.Parse(context.Request["curpage"]);
            }
            int userId = 0;
            if (context.Request["userid"] != null)
            {
                userId = int.Parse(context.Request["userid"]);
            }
            string type = "";
            if (context.Request["type"] != null)
            {
                type = context.Request["type"];
            }
           int  ListPageNum=1;
           List<T_RoomModel> list = new T_RoomBLL().GetPageT_RoomModelList(type, userId, 16, curpage,ref ListPageNum);
           list.ForEach(e => e = new RoomLiveBLL().getRoomLive(e));

           RetInfo<List<T_RoomModel>> result = new RetInfo<List<T_RoomModel>>() { Code = 0, Value = list };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }


        public void addCollect(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomid"] != null)
            {
                roomId = int.Parse(context.Request["roomid"]);
            }
            int userId = 0;
            if (context.Request["userid"] != null)
            {
                userId = int.Parse(context.Request["userid"]);
            }
            new T_UserCollectBLL().Add(new Model.T_UserCollectModel() {RoomId=roomId,UserId=userId,CreateTime=DateTime.Now });
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(new { Code = 0 });
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public void delCollect(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomid"] != null)
            {
                roomId = int.Parse(context.Request["roomid"]);
            }
            int userId = 0;
            if (context.Request["userid"] != null)
            {
                userId = int.Parse(context.Request["userid"]);
            }
            new T_UserCollectBLL().Del(new Model.T_UserCollectModel() { RoomId = roomId, UserId = userId });
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(new { Code = 0 });
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public void addcomment(HttpContext context)
        {
              RetInfo<string> result = new RetInfo<string>() { Code = 0 };
              try
              {
                  int roomId = 0;
                  if (context.Request["roomId"] != null)
                  {
                      roomId = int.Parse(context.Request["roomId"]);
                  }
                  int userId = 0;
                  if (context.Request["userId"] != null)
                  {
                      userId = int.Parse(context.Request["userId"]);
                  }
                  string comment = "";
                  if (context.Request["Comment"] != null)
                  {
                      comment = context.Request["Comment"];
                  }



                  bool isSave = new CommentBLL().CheckUserComment(roomId, userId, comment);
                  if (isSave == true)
                  {
                      result.Msg = "您已提交过当前评论";
                  }
                  else
                  {
                      int i = new CommentBLL().AddComment(new T_CommentUserModel() { CommentTxt = comment, RoomId = roomId, UserId = userId });
                      if (i > 0)
                      {
                          result.Msg = "提交成功";
                      }
                      else
                      {
                          result.Msg = "提交失败";
                      }
                  }
              }
              catch (Exception ex)
              {
                  Log.ErrorFormat("PageActionRequert.addcomment msg:{0}", ex.Message);
                  result.Code = -1;
                  result.Msg = "提交出错";
              }

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public void bindcomment(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomId"] != null)
            {
                roomId = int.Parse(context.Request["roomId"]);
            }

            List<T_CommentModel> list = new CommentBLL().GetList(roomId);
            RetInfo<List<T_CommentModel>> result = new RetInfo<List<T_CommentModel>>() { Code = 0, Value = list };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public void ActionRequest(HttpContext context, string result)
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}