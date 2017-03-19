using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class T_RoomModel
    {
        public int RoomId { get; set; }
        /// <summary>
        /// 房间标题
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 主播名字
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 主播简介
        /// </summary>
        public string OwnerInfo { get; set; }
        /// <summary>
        /// 直播平台 1 斗鱼 2 熊猫 3 虎牙
        /// </summary>
        public int PlatType { get; set; }
        /// <summary>
        /// 直播时间
        /// </summary>
        public string PlayTime { get; set; }
        /// <summary>
        /// 播放地址
        /// </summary>
        public string PlayUrl { get; set; }
        /// <summary>
        /// 互动地址
        /// </summary>
        public string ActiveUrl { get; set; }

        /// <summary>
        /// 收藏人数
        /// </summary>
        public int CollectNum { get; set; }
        /// <summary>
        /// 房间分类
        /// </summary>
        public int RoomType { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public int IsHot { get; set; }
        /// <summary>
        /// 房间背景图
        /// </summary>
        public string RoomBG { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 状态值
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 直播状态
        /// </summary>
        public int isLive { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpateTime { get; set; }
    }
}
