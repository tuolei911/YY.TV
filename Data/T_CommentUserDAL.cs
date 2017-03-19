
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BaseClasses;
using System.Data;
using System.Data.SqlClient;
namespace Data
{
   public class T_CommentUserDAL
    {
       public bool Exist(int roomId, int userId, string CommentTxt)
       {
           var sqlparams = new SqlParameter[] {
                new SqlParameter("@RoomId",roomId),
                 new SqlParameter("@UserId",userId),
                  new SqlParameter("@CommentTxt",CommentTxt),
             };
           string sql = " select * from T_CommentUser where RoomId=@RoomId and UserId=@UserId and CommentTxt=@CommentTxt ";
           var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
           if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public int Add(T_CommentUserModel t_CommentUserModel)
       {
           var sqlparams = new SqlParameter[] {
               new SqlParameter("@CommentId",t_CommentUserModel.CommentId),
                  new SqlParameter("@UserId",t_CommentUserModel.UserId),
                new SqlParameter("@RoomId",t_CommentUserModel.RoomId),
                 new SqlParameter("@CommentTxt",t_CommentUserModel.CommentTxt),
                   new SqlParameter("@CreateTime",DateTime.Now),
            };
           string sql = @" INSERT INTO  [T_CommentUser]
           ([CommentId]
           ,[UserId]
           ,[RoomId]
           ,[CommentTxt]
           ,[CreateTime])
           VALUES
           (@CommentId
           ,@UserId
           ,@RoomId
           ,@CommentTxt
           ,@CreateTime)";

           return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
       }
    }
}
