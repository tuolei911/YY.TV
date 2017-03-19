using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace YY.TV.WebService.Page
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
                case "DelRoom":
                    DelRoom(context);
                    break;

                case "uploadRoomBGFile":
                    uploadRoomBGFile(context);
                    break;
              
            }
        }
        public void DelRoom(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomId"] != null)
            {
                roomId = int.Parse(context.Request["roomId"]);
            }
            RetInfo<int> result = new T_RoomBLL().Del(roomId);
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

       
     

        public void uploadRoomBGFile(HttpContext context)
        {
            int roomId = 0;
            if (context.Request["roomId"] != null)
            {
                roomId = int.Parse(context.Request["roomId"]);
            }

            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            Stream _stream = postedFile.InputStream;
            RetInfo<string> ret = new T_RoomBLL().UploadPic(_stream, roomId);

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(new { result = 1, url = ret.Value + "?stamp=" + DateTime.Now.Ticks });
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