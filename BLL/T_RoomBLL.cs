using BaseClasses;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class T_RoomBLL
    {
       public int Add(T_RoomModel t_RoomModel)
       {
           return new T_RoomDAL().Add(t_RoomModel);
       }

       public int Update(T_RoomModel t_RoomModel, int roomId)
       {
           return new T_RoomDAL().Update(t_RoomModel, roomId);
       }

       public int AddCollect(int roomId)
       {
           return new T_RoomDAL().AddCollect(roomId);
       }

       public int DelCollect(int roomId)
       {
           return new T_RoomDAL().DelCollect(roomId);
       }

       public RetInfo<int> Del(int roomId)
       {
           RetInfo<int> ret = new RetInfo<int>() { Code=0};
           int i= new T_RoomDAL().Del(roomId);
           if (i <1)
           {
               ret.Code = -1;
           }

           return ret;
       }

       public T_RoomModel Get(int roomId)
       {
           return new T_RoomDAL().Get(roomId);
       }

       public List<T_RoomModel> GetAll()
       {
           return new T_RoomDAL().GetAll();
       }

       public List<T_RoomModel> GetPageT_RoomModelList(string type,  int userId, int PageSize, int CurPage,ref int PageNum)
       {
           List<T_RoomModel> T_RoomModelList = new T_RoomBLL().GetAll().Where(e=>e.Status==1).OrderByDescending(t => t.OrderNum).ToList();
         
           switch (type)
           {
               case "hot":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.IsHot == 1).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "1":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 1).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "2":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 2).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "3":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 3).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "4":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 4).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "5":
                   T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 5).OrderByDescending(t => t.OrderNum).ToList();
                   break;
               case "user":
                   T_RoomModelList = new T_UserCollectBLL().GetUserRoom(userId);
                   break;

           }
           T_RoomModelList.ForEach(e => e = new RoomLiveBLL().getRoomLive(e));
           T_RoomModelList = T_RoomModelList.OrderByDescending(e => e.isLive).ToList();
           PageNum = (int)Math.Ceiling((decimal)T_RoomModelList.Count() / PageSize);

           return QueryByPage(PageSize,CurPage,T_RoomModelList);
       }

       protected List<T_RoomModel> QueryByPage(int PageSize, int CurPage, List<T_RoomModel> objs)
       {
           var query = from cms_contents in objs select cms_contents;
           return query.Take(PageSize * CurPage).Skip(PageSize * (CurPage - 1)).ToList(); 
       }


       public RetInfo<string> UploadPic(Stream stream, int roomId, string type = "live")
       {
           var ret = new RetInfo<string> { Code = 0, Msg = "success" };
           try
           {
               //Log.ErrorFormat("【RpgMapsBll】-【UploadPic】上传文件 start，categoryId:{0}", categoryId);
               //var bytes = new byte[stream.Length];
               //stream.Read(bytes, 0, bytes.Length);

               var param = new Dictionary<string, string> {
                    {"type",type },
                    {"routeId",  DateTime.Now.ToString("MMddhhmmss") },
                    { "ext",".jpg"}
                };

               ret = FileUploadBLL.PostFile(stream, param);

               //Log.ErrorFormat("【RpgMapsBll】-【UploadPic】上传文件 PostFile，bytes.Length:{0}", bytes.Length);
               //var result = HttpFunction.PostFile("http://115.159.106.86:8697/upload.ashx", bytes, param);
               //ret = JsonSerializer.DeserializeFromString<RetInfo<string>>(result);

               if (ret.Code == 0)
               {
                   ret.Value = ret.Value;
               }
           }
           catch (Exception e)
           {
               Log.ErrorFormat("【T_RoomBLL】-【UploadPic】上传文件异常，msg:{0}", e.ToString());
               ret.Code = -1000;
               ret.Msg = "上传图片异常";
           }
           return ret;
       }
    }
}
