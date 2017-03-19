using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseClasses;
using BLL;
using Model;
namespace YY.TV.Web
{
    public partial class Room : BasePage
    {
        public string pageType = "";
        public bool IsFristUser = false;
        public T_RoomModel item = null;
        public bool IsCollect = false;
        public int userId = 0;
        public int roomId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 userId = (int)base.NowUserInfo.UserId;
                IsFristUser = new T_UserBLL().CheckUser(userId);
                if (IsFristUser == false)
                {
                    new T_UserBLL().Add(new T_UserModel() { UserId = userId, UserName = base.NowUserInfo.UserName });
                }

                if (Request.QueryString["roomId"] != "")
                {
                     roomId = int.Parse(Request.QueryString["roomId"]);
                    item = new T_RoomBLL().Get(roomId);

                    IsCollect = new T_UserCollectBLL().GetUserRoom(userId, roomId);

                }
                else
                {
                    item = new T_RoomModel();
                }
                if (Request.QueryString["pageType"] != "")
                {
                    pageType =Request.QueryString["pageType"];
                }
            }
        }

        public string GetRoomTypeName(int i)
        {
            switch (i)
            {
                case 1:
                    return "DOTA";
                    break;
                case 2:
                    return "IMBA";
                    break;
                case 3:
                    return "真三";
                    break;
                case 4:
                    return "RPG";
                    break;
                case 5:
                    return "斗鱼从零单排";
                    break;
                default:
                    return "";
            }
        }

        public string GetPlatName(int PlatType)
        {
            switch (PlatType)
            {
                case 1:
                    return "douyu";
                    break;
                case 2:
                    return "xm";
                    break;
                case 3:
                    return "huya";
                    break;
                       case 4:
                    return "quanming";
                    break;
                default:
                    return "";
            }
        }
    }
}