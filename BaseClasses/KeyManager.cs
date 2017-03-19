using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses
{
    public class KeyManager
    {
        public enum EnumCacheDirections
        {

            GetRoomLive
           
        }

     

        public static string GetCacheKey(EnumCacheDirections directions, List<string> list)
        {
            string sideName = "tvlive_";
            switch (directions)
            {
                case EnumCacheDirections.GetRoomLive: return sideName + "GetRoomLive_";
              

                default: return string.Empty;
            }
        }
    }
}
