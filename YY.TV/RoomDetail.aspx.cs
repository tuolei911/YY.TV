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
    public partial class RoomDetail : System.Web.UI.Page
    {
        public int roomId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPage();
                if (Request.QueryString["roomId"] != null)
                {
                    int.TryParse(Request.QueryString["roomId"], out roomId);

                    T_RoomModel model = new T_RoomBLL().Get(roomId);
                    ActiveUrlTxt.Value = model.ActiveUrl;
                    if (model.IsHot == 1)
                    {
                        cbxIsHot.Checked = true;
                    }
                    OrderNumTxt.Value = model.OrderNum.ToString();
                    OwnerInfoTxt.Value = model.OwnerInfo;
                    OwnerNameTxt.Value = model.OwnerName;
                    PlatTypeSelet.Items.FindByValue(model.PlatType.ToString()).Selected = true;
                    PlayTimeTxt.Value = model.PlayTime;
                    PlayUrlTxt.Value = model.PlayUrl;
                    RoomNameTxt.Value = model.RoomName;
                    RoomTypeSelect.Items.FindByValue(model.RoomType.ToString()).Selected = true;

                    StatusSelet.Items.FindByValue(model.Status.ToString()).Selected = true;

                    if (model.RoomBG != "")
                    {
                        ImgRoomBG.Src = model.RoomBG;
                        HiddenFieldRoomBG.Value = model.RoomBG;
                    }
                }
            }
        }

        protected void BindPage()
        {
            PlatTypeSelet.Items.Clear();
            PlatTypeSelet.Items.Add(new ListItem() { Text = "斗鱼", Value = "1" });
            PlatTypeSelet.Items.Add(new ListItem() { Text = "熊猫", Value = "2" });
            PlatTypeSelet.Items.Add(new ListItem() { Text = "虎牙", Value = "3" });
            PlatTypeSelet.Items.Add(new ListItem() { Text = "全民", Value = "4" });

            StatusSelet.Items.Clear();
            StatusSelet.Items.Add(new ListItem() { Text = "上线", Value = "1" });
            StatusSelet.Items.Add(new ListItem() { Text = "隐藏", Value = "0" });


            RoomTypeSelect.Items.Clear();

            List<T_RoomTypeModel> T_RoomTypeModelList = new T_RoomTypeBLL().GetAll();
            foreach (T_RoomTypeModel T_RoomTypeModelItem in T_RoomTypeModelList)
            {
                RoomTypeSelect.Items.Add(new ListItem() { Text = T_RoomTypeModelItem.TypeName, Value = T_RoomTypeModelItem.TypeId.ToString() });
            }
        }

        protected void Savebtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                T_RoomModel model = new T_RoomModel();
                model.ActiveUrl = ActiveUrlTxt.Value;
                model.IsHot = cbxIsHot.Checked == true ? 1 : 0;
                if (OrderNumTxt.Value != "")
                {
                    model.OrderNum = int.Parse(OrderNumTxt.Value);
                }
                else
                {
                    model.OrderNum = 0;
                }

                model.OwnerInfo = OwnerInfoTxt.Value;
                model.OwnerName = OwnerNameTxt.Value;
                model.PlatType = int.Parse(PlatTypeSelet.Value);
                model.PlayTime = PlayTimeTxt.Value;
                model.PlayUrl = PlayUrlTxt.Value;
                model.RoomName = RoomNameTxt.Value;
                model.RoomType = int.Parse(RoomTypeSelect.Value);
                if (HiddenFieldRoomBG.Value != "")
                {
                  
                    model.RoomBG = HiddenFieldRoomBG.Value;
                }
                else
                {
                    model.RoomBG = "";
                }
                model.Status = int.Parse(StatusSelet.Value);
                int roomId = 0;
                if (Request.QueryString["roomId"] != null)
                {
                    int.TryParse(Request.QueryString["roomId"], out roomId);
                }

                if (roomId == 0)
                {
                    new T_RoomBLL().Add(model);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交成功');  var index = parent.layer.getFrameIndex(window.name);  parent.layer.close(index);", true);
                }
                else
                {
                    new T_RoomBLL().Update(model, roomId);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交成功');  var index = parent.layer.getFrameIndex(window.name);  parent.layer.close(index);", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('错误');", true);
            }

        }
    }
}