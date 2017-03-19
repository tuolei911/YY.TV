using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class T_UserBLL
    {
       public int Add(T_UserModel r_UserModel)
       {
           return new T_UserDAL().Add(r_UserModel);
       }

       public bool CheckUser(int userId)
       {
           T_UserModel model = new T_UserDAL().Get(userId);
           if (model == null || model.UserId==0)
               return false;
           else
               return true;
       }
    }
}
