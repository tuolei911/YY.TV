using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class T_CommentModel
    {
       public int CommentId { get; set; }

       public int RoomId { get; set; }

       public string CommentTxt { get; set; }

       public int CommentNum { get; set; }
    }
}
