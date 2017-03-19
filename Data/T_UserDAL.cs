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
    public class T_UserDAL
    {
        public int Add(T_UserModel r_UserModel)
        {
            var sqlparams = new SqlParameter[] {
                new SqlParameter("@UserId",r_UserModel.UserId),
                new SqlParameter("@UserName",r_UserModel.UserName),
               };

            string sql = @"INSERT INTO [T_User]
                           ([UserId]
                           ,[UserName])
                     VALUES
                           (@UserId
                           ,@UserName)
               ";
            return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }

        public T_UserModel Get(int userId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@UserId",userId),
               };
            string sql = " select * from T_User where UserId=@UserId ";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
            return ds.CreateModel<T_UserModel>();
        }
    }
}
