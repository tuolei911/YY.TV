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
    public class T_RoomDAL : BaseDal
    {
        public int Add(T_RoomModel t_RoomModel)
        {
            var sqlparams = new SqlParameter[] {
                new SqlParameter("@RoomName",t_RoomModel.RoomName),
                new SqlParameter("@OwnerName",t_RoomModel.OwnerName),
                new SqlParameter("@OwnerInfo",t_RoomModel.OwnerInfo),
                new SqlParameter("@PlatType",t_RoomModel.PlatType),
                new SqlParameter("@PlayTime",t_RoomModel.PlayTime),
                new SqlParameter("@PlayUrl",t_RoomModel.PlayUrl),
                new SqlParameter("@ActiveUrl",t_RoomModel.ActiveUrl),
                new SqlParameter("@CollectNum",t_RoomModel.CollectNum),
                new SqlParameter("@RoomType",t_RoomModel.RoomType),
                new SqlParameter("@IsHot",t_RoomModel.IsHot),
                new SqlParameter("@RoomBG",t_RoomModel.RoomBG),
                new SqlParameter("@OrderNum",t_RoomModel.OrderNum),
                new SqlParameter("@Status",t_RoomModel.Status),
                new SqlParameter("@CreateTime",DateTime.Now),
                new SqlParameter("@UpateTime",DateTime.Now),
            };
            string sql = @" INSERT INTO [T_Room]
           ([RoomName]
           ,[OwnerName]
           ,[OwnerInfo]
           ,[PlatType]
           ,[PlayTime]
           ,[PlayUrl]
           ,[ActiveUrl]
           ,[CollectNum]
           ,[RoomType]
           ,[IsHot]
           ,[RoomBG]
           ,[OrderNum]
           ,[Status]
           ,[CreateTime]
           ,[UpateTime])
     VALUES
           (@RoomName
           ,@OwnerName
           ,@OwnerInfo
           ,@PlatType
           ,@PlayTime
           ,@PlayUrl
           ,@ActiveUrl
           ,@CollectNum
           ,@RoomType
           ,@IsHot
           ,@RoomBG
           ,@OrderNum
           ,@Status
           ,@CreateTime
           ,@UpateTime
            ) ";

            return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }

        public int Del(int roomId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@RoomId",roomId),
          };

          string sql=" delete from T_Room where RoomId=@RoomId  ";
          return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }

        public int AddCollect(int roomId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@RoomId",roomId),
          };

            string sql = " update T_Room set CollectNum=CollectNum+1 where  RoomId=@RoomId  ";
            return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }

        public int DelCollect(int roomId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@RoomId",roomId),
          };

            string sql = " update T_Room set CollectNum=CollectNum-1 where  RoomId=@RoomId and CollectNum>0 ";
            return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }

        public int Update(T_RoomModel t_RoomModel, int roomId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@RoomId",roomId),
                new SqlParameter("@RoomName",t_RoomModel.RoomName),
                new SqlParameter("@OwnerName",t_RoomModel.OwnerName),
                new SqlParameter("@OwnerInfo",t_RoomModel.OwnerInfo),
                new SqlParameter("@PlatType",t_RoomModel.PlatType),
                new SqlParameter("@PlayTime",t_RoomModel.PlayTime),
                new SqlParameter("@PlayUrl",t_RoomModel.PlayUrl),
                new SqlParameter("@ActiveUrl",t_RoomModel.ActiveUrl),
                new SqlParameter("@CollectNum",t_RoomModel.CollectNum),
                new SqlParameter("@RoomType",t_RoomModel.RoomType),
                new SqlParameter("@IsHot",t_RoomModel.IsHot),
                new SqlParameter("@RoomBG",t_RoomModel.RoomBG),
                new SqlParameter("@OrderNum",t_RoomModel.OrderNum),
                  new SqlParameter("@Status",t_RoomModel.Status),
                new SqlParameter("@UpateTime",DateTime.Now),
            };
            string sql = @"UPDATE  [T_Room]
                       SET [RoomName] = @RoomName
                          ,[OwnerName] = @OwnerName
                          ,[OwnerInfo] = @OwnerInfo
                          ,[PlatType] = @PlatType
                          ,[PlayTime] = @PlayTime
                          ,[PlayUrl] = @PlayUrl
                          ,[ActiveUrl] = @ActiveUrl
                          ,[CollectNum] = @CollectNum
                          ,[RoomType] = @RoomType
                          ,[IsHot] = @IsHot
                          ,[RoomBG] = @RoomBG
                          ,[OrderNum] = @OrderNum
                          ,[Status] = @Status
                          ,[UpateTime] = @UpateTime
                     WHERE RoomId=@RoomId";

            return SqlHelper.ExecuteNonQuery(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
        }


        public T_RoomModel Get(int roomId)
        {
            var sqlparams = new SqlParameter[] {
                 new SqlParameter("@RoomId",roomId),
               };
            string sql=" select * from T_Room where RoomId=@RoomId ";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql, sqlparams);
            return ds.CreateModel<T_RoomModel>();
        }

        public List<T_RoomModel> GetAll()
        {
            string sql = " select * from T_Room  ";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql);
            return ds.CreateModels<T_RoomModel>();
        }
    }
}
