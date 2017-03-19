using BaseClasses;
using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YY.TV.Web
{
    public partial class Index : BasePage
    {
        public List<T_RoomModel> T_RoomModelList = null;
        public string pageType = "";
        public bool IsFristUser = false;
        public int userId = 0;
        public int ListPageNum = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId =(int) base.NowUserInfo.UserId;
                IsFristUser = new T_UserBLL().CheckUser(userId);
                if (IsFristUser == false)
                {
                    new T_UserBLL().Add(new T_UserModel() {UserId=userId,UserName=base.NowUserInfo.UserName });
                }

                if (Request.QueryString["type"] != null)
                {
                    pageType = Request.QueryString["type"];
                    BindList(pageType);
                }
                else
                {
                    pageType = "defaut";
                    BindList("");
                }
            }
        }

        public void BindList(string type)
        {

            T_RoomModelList = new T_RoomBLL().GetPageT_RoomModelList(type, (int)base.NowUserInfo.UserId, 16, 1, ref ListPageNum);
           
         

                /*
                            T_RoomModelList = new T_RoomBLL().GetAll().OrderByDescending(t => t.OrderNum).ToList();
                            switch (type)
                            { 
                                case "hot":
                                    T_RoomModelList = T_RoomModelList.FindAll(e => e.IsHot == 1).OrderByDescending(t=>t.OrderNum).ToList();
                                    break;
                                case "1":
                                    T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 1).OrderByDescending(t => t.OrderNum).ToList();
                                    break;
                                case "2":
                                    T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 2).OrderByDescending(t => t.OrderNum).ToList();
                                    break;
                                case "3":
                                    T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 3).OrderByDescending(t => t.OrderNum).ToList();
                                    break;
                                case "4":
                                    T_RoomModelList = T_RoomModelList.FindAll(e => e.RoomType == 4).OrderByDescending(t => t.OrderNum).ToList();
                                    break;
                                case "user":
                                    T_RoomModelList = new T_UserCollectBLL().GetUserRoom((int)base.NowUserInfo.UserId);
                                    break;

                            }
                 */
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