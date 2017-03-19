using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class BaseDal
    {
        private SqlParameter _sqlOutPutParams;
        /// <summary>
        /// 返回一个输出参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public SqlParameter DeclareOutParams(string name, SqlDbType dbType, int size = 4)
        {
            _sqlOutPutParams = new SqlParameter(name, dbType, size) { Direction = ParameterDirection.Output };
            return _sqlOutPutParams;
        }
        private SqlParameter _sqlReturnParams;
        /// <summary>
        /// 返回一个返回值参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public SqlParameter DeclareReturnParams(string name = "@ReturnValue", SqlDbType dbType = SqlDbType.Int, int size = 4)
        {
            _sqlReturnParams = new SqlParameter(name, dbType, size) { Direction = ParameterDirection.ReturnValue };
            return _sqlReturnParams;
        }

        public T GetOutPutValue<T>()
        {
            try
            {
                return (T)_sqlOutPutParams.Value;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public T GetReturnValue<T>()
        {
            try
            {
                return (T)_sqlReturnParams.Value;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
