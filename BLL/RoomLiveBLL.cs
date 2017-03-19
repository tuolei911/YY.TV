using BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomLiveBLL
    {
        public T_RoomModel getRoomLive(T_RoomModel baseT_RoomModel)
        {
            if (baseT_RoomModel != null)
            {
                baseT_RoomModel.isLive = GetIsLive(baseT_RoomModel);
                return baseT_RoomModel;
            }
            else
                return null;
        }

        /// <summary>
        /// 初始化直播状态
        /// </summary>
        public void InitLiveCache()
        {
            List<string> userListDouyu = new RoomLiveHelper().GetDouyuLiveUserName();//获取斗鱼直播列表
            List<string> userListdDotaDouyu = new RoomLiveHelper().GetDouyuDataLiveUserName();//获取斗鱼直播列表 dota 分类
            List<string> userListPanda = new RoomLiveHelper().GetPandaLiveUserName();//获取熊猫直播列表
            List<string> userListHuya = new RoomLiveHelper().GetHuyaUserName();//获取全民直播列表
            List<string> userList = new List<string>();
            userList.AddRange(userListDouyu);
            userList.AddRange(userListdDotaDouyu);
            userList.AddRange(userListPanda);
            userList.AddRange(userListHuya);
            userList.Add("UpdateTime");

            foreach (string item in userList)
            {
              

                string itemname = "";
                if (item != "UpdateTime")
                {
                    itemname = GetBase64(item);
                }
                else
                {
                    itemname = "UpdateTime";
                }
               // item = Microsoft.SqlServer.Server.UrlEncode(Name);
                string _cacheKey = KeyManager.GetCacheKey(KeyManager.EnumCacheDirections.GetRoomLive, new List<string>());
                _cacheKey = string.Format(_cacheKey + "OwnerName{0}", itemname);
               
                string cacheownerName = CacheHelper.Get(_cacheKey) as string;
                if (cacheownerName == null)
                {
                    try
                    {
                        CacheHelper.Add(_cacheKey, itemname, new TimeSpan(0, 3, 0));
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("InitLiveCache() 获取相关信息异常: {0}", ex.ToString());
                    }
                }
            }


        }

        public int GetIsLive(T_RoomModel baseT_RoomModel)
        {
            return GetCacheLiveStatus(baseT_RoomModel.OwnerName);
        }

        private string GetBase64(string txt)
        {
            byte[] b = Encoding.Default.GetBytes(txt.Replace(" ","").Replace("　",""));
            return  Convert.ToBase64String(b);
        }

        private int GetCacheLiveStatus(string ownerName)
        {
            try
            {
               
                ownerName = GetBase64(ownerName);
                string _cacheKey = KeyManager.GetCacheKey(KeyManager.EnumCacheDirections.GetRoomLive, new List<string>());
                string _cacheKeyUpdateTime = string.Format(_cacheKey + "OwnerName{0}", "UpdateTime");
                string cacheKeyUpdateTime = CacheHelper.Get(_cacheKeyUpdateTime) as string;
                if (cacheKeyUpdateTime == null)
                {
                    InitLiveCache();
                }

                _cacheKey = string.Format(_cacheKey + "OwnerName{0}", ownerName);
                string cacheownerName = CacheHelper.Get(_cacheKey) as string;
                if (cacheownerName == null)
                {
                    return 0;
                }
                else
                {
                    byte[] c = Convert.FromBase64String(ownerName);
                   string aa = Encoding.Default.GetString(c);

                    return 1;
                }

            }

            catch (Exception ex)
            {
                Log.ErrorFormat("InitLiveCache() 获取相关信息异常: {0}", ex.ToString());
                throw ex;
            }
        }

    }
}
