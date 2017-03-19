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
   public class T_CommentDAL
    {
       public int Add(T_CommentModel T_CommentModel)
       {
           var sqlparams = new SqlParameter[] {
                new SqlParameter("@RoomId",T_CommentModel.RoomId),
                 new SqlParameter("@CommentTxt",T_CommentModel.CommentTxt),
            };
           string sql = @" if not exists(select * from T_Comment where RoomId=@RoomId and CommentTxt=@CommentTxt )
                           BEGIN
                            INSERT INTO [T_Comment]
                                       ([RoomId]
                                       ,[CommentTxt]
                                       ,[CommentNum])
                                 VALUES
                                       (@RoomId
                                       ,@CommentTxt
                                       ,0)
                             select @@identity
                            END
                            else
                            BEGIN
                             update T_Comment set [CommentNum]=[CommentNum]+1 where RoomId=@RoomId and CommentTxt=@CommentTxt
                            select CommentId from T_Comment where RoomId=@RoomId and CommentTxt=@CommentTxt
                              END
                            ";

            object ret  = SqlHelper.ExecuteScalar(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);

            int i = Convert.ToInt32(ret);
            return i;
       }

       public List<T_CommentModel> GetList(int roomId)
       {
         
           var sqlparams = new SqlParameter[] {
                new SqlParameter("@RoomId",roomId),
             };
           string sql = " select * from T_Comment where RoomId=@roomId order by CommentNum desc ";
           var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql,sqlparams);
           return ds.CreateModels<T_CommentModel>();
       }
    }
}
