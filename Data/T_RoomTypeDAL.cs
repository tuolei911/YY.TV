using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses;
namespace Data
{
    public class T_RoomTypeDAL : BaseDal
    {
        public List<T_RoomTypeModel> GetAll()
        {
            string sql = " select * from T_RoomType order by TypeId ";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.WTVDns, CommandType.Text, sql);
            return ds.CreateModels<T_RoomTypeModel>();
        }
    }
}
