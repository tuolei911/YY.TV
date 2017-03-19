using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RetInfo<T>
    {
        public RetInfo()
        {
            this.Code = -999;
        }
        /// <summary>
        /// 大于0 逻辑错误,可打印msg
        /// 小于0 应用程序错误,不需要打印msg
        /// 等于0 成功
        /// </summary>
        public int Code { set; get; }
        public string Msg { set; get; }
        public T Value { set; get; }
    }
}
