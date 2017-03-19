using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
namespace BLL
{
   public class T_UserCollectBLL
    {
       public int Add(T_UserCollectModel t_UserCollectModel)
       {
            new T_UserCollectDAL().Add(t_UserCollectModel);
            return new T_RoomDAL().AddCollect(t_UserCollectModel.RoomId);
       }

       public int Del(T_UserCollectModel t_UserCollectModel)
       {
            new T_UserCollectDAL().Del(t_UserCollectModel);
            return new T_RoomDAL().DelCollect(t_UserCollectModel.RoomId);
       }

       public List<T_RoomModel> GetUserRoom(int userId)
       {
           return new T_UserCollectDAL().GetUserRoom(userId);

       }

       public bool GetUserRoom(int userId,int roomId)
       {
           List < T_RoomModel > list= new T_UserCollectDAL().GetUserRoom(userId);
           T_RoomModel model = list.Find(e => e.RoomId == roomId);
           if (model == null || model.RoomId == 0)
           {
               return false;
           }
           else
           {
               return true;
           }

       }
    }
}
