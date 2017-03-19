using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YY.TV
{
    public partial class RoomList : System.Web.UI.Page
    {
       public  List<T_RoomModel> T_RoomModelList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();
        }

        public void BindList()
        {
            T_RoomModelList = new T_RoomBLL().GetAll();           
        
        }

        public string GetPlatName(int PlatType)
        {
            switch (PlatType)
           {
                case 1:
                   return "斗鱼";
                   break;
                case 2:
                   return "熊猫";
                   break;
                case 3:
                   return "虎牙";
                   break;
                case 4:
                   return "全民";
                   break;
                default:
                   return "";
           }
        }

    }
}