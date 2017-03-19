using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentBLL
    {
        public List<T_CommentModel> GetList(int roomId)
        {
            return new T_CommentDAL().GetList(roomId);
        }

        public bool CheckUserComment(int roomId, int userId, string commentTxt)
        {
            return new T_CommentUserDAL().Exist(roomId, userId, commentTxt);
        }

        public int AddComment(T_CommentUserModel t_CommentUserModel)
        {
            int CommentId = new T_CommentDAL().Add(new T_CommentModel() { CommentTxt = t_CommentUserModel.CommentTxt, RoomId = t_CommentUserModel.RoomId });
            t_CommentUserModel.CommentId = CommentId;
          return  new T_CommentUserDAL().Add(t_CommentUserModel);
        }
    }
}
