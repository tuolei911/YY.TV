using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses;
namespace Data
{
   public class T_UserCollectDAL
    {
       public int Add(T_UserCollectModel t_UserCollectModel)
        {
            try
            {
                var sqlparams = new SqlParameter[] {
                new SqlParameter("@UserId",t_UserCollectModel.UserId),
                new SqlParameter("@RoomId",t_UserCollectModel.RoomId),
                new SqlParameter("@CreateTime",DateTime.Now),
               };

                string sql = @"INSERT INTO [T_UserCollect]
                           ([UserId]
                           ,[RoomId]
                           ,[CreateTime])
                     VALUES
                           (@UserId
                           ,@RoomId
                           ,@CreateTime )
               ";
                return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public List<T_RoomModel> GetUserRoom(int userId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@UserId",userId),
               };
            string sql = @" select T_Room.* from T_UserCollect
                            left join T_Room on T_Room.RoomId=T_UserCollect.RoomId
                            where T_UserCollect.UserId=@UserId
                            order by T_UserCollect.CreateTime desc ";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
            return ds.CreateModels<T_RoomModel>();
        }

       public int Del(T_UserCollectModel t_UserCollectModel)
       {
           var sqlparams = new SqlParameter[] {
                new SqlParameter("@UserId",t_UserCollectModel.UserId),
                new SqlParameter("@RoomId",t_UserCollectModel.RoomId),
               };

           string sql = @"DELETE FROM [T_UserCollect]
                        WHERE UserId=@UserId AND RoomId=@RoomId 
               ";
           return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
       }

    }
}
