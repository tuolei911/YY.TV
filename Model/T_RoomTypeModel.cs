using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class T_RoomTypeModel
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpateTime { get; set; }
    }
}
