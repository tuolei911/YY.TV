using BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
   public class RoomLiveHelper
    {
       public List<string> GetDouyuLiveUserName()
       {
           string douyuUrl = "https://www.douyu.com/directory/game/mszb";
           string douyuresult = HttpFunction.Get(douyuUrl, Encoding.UTF8,25600000);

           Regex douyureg = new Regex(@"(?<=<span class=""dy-name ellipsis fl"">)(.*?)(?=</span>)", RegexOptions.IgnoreCase);
           MatchCollection douyumc = douyureg.Matches(douyuresult);
           List<string> douyuUserName = new List<string>();

           foreach (Match m in douyumc)
           {
               douyuUserName.Add(m.Value);
           }
           return douyuUserName;
       }

       public List<string> GetDouyuDataLiveUserName()
       {
           string douyuUrl = "https://www.douyu.com/directory/game/DOTA";
           string douyuresult = HttpFunction.Get(douyuUrl, Encoding.UTF8, 25600000);

           Regex douyureg = new Regex(@"(?<=<span class=""dy-name ellipsis fl"">)(.*?)(?=</span>)", RegexOptions.IgnoreCase);
           MatchCollection douyumc = douyureg.Matches(douyuresult);
           List<string> douyuUserName = new List<string>();

           foreach (Match m in douyumc)
           {
               douyuUserName.Add(m.Value);
           }
           return douyuUserName;
       }



       public List<string> GetPandaLiveUserName()
       {
           string pandaUrl = "http://www.panda.tv/cate/war3";
           string result = HttpFunction.Get(pandaUrl, Encoding.UTF8, 25600000);

           Regex reg = new Regex(@"(?<=<span class=""video-nickname"">)(.*?)(?=</span>)", RegexOptions.IgnoreCase);//[^(<td>))] 
           MatchCollection mc = reg.Matches(result);

           List<string> pandaUserName = new List<string>();

           foreach (Match m in mc)
           {
               pandaUserName.Add(m.Value);
           }
           return pandaUserName;
       }

       public List<string> GetHuyaUserName()
       {
           List<string> huyaUserName = new List<string>();
           //string huyaUrl = "http://www.huya.com/cache.php?m=Tag&do=getGameTagLiveByPage&gameId=6&tagId=22&page=1";

           for (int i = 0; i <= 10; i++)
           {
               string huyaUrl = "http://www.huya.com/cache.php?m=Game&do=ajaxGameLiveByPage&gid=6&page=" + i.ToString()+ "&pageNum=1";

               string huyaresult = HttpFunction.Get(huyaUrl, Encoding.UTF8, 25600000);

               HuyaJson sModel = JsonSerializer.DeserializeFromString<HuyaJson>(huyaresult);

               if (sModel != null && sModel.data != null && sModel.data.list != null)
               {
                   huyaUserName.AddRange(sModel.data.list.Select(e => e.nick).ToList());
               }
           }
           return huyaUserName;

       }

       [Serializable]
       public class HuyaJson
       {
           public int status { get; set; }
           public string message { get; set; }
           public HuyadataJson data { get; set; }
       }
       [Serializable]
       public class HuyadataJson
       {
           public List<HuyadatasJson> list { get; set; }
       }

       [Serializable]
       public class HuyadatasJson
       {
           public string gameFullName { get; set; }
           public string gameHostName { get; set; }

           public string boxDataInfo { get; set; }

           public string totalCount { get; set; }

           public string roomName { get; set; }

           public string bussType { get; set; }

           public string screenshot { get; set; }

           public string privateHost { get; set; }

           public string nick { get; set; }

           public string avatar180 { get; set; }

           public string gid { get; set; }

           public string introduction { get; set; }

           public string recommendStatus { get; set; }
           public string recommendTagName { get; set; }
           public string recommendTagColor { get; set; }

           public string isBluRay { get; set; }
           public string screenType { get; set; }
           public string liveSourceType { get; set; }

           public string uid { get; set; }
          
        
       }
    }
}
