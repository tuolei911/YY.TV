using BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reptile
{
    class Program
    {
        static void Main(string[] args)
        {
            string pandaUrl = "http://www.panda.tv/cate/war3";
            //string huyaUrl = "http://www.huya.com/g/war3#tag22";
            string huyaUrl = "http://www.huya.com/cache.php?m=Tag&do=getGameTagLiveByPage&gameId=6&tagId=22&page=1";


            string result = HttpFunction.Get(pandaUrl, Encoding.UTF8);


            Regex reg = new Regex(@"(?<=<span class=""video-nickname"">)(.*?)(?=</span>)", RegexOptions.IgnoreCase);//[^(<td>))] 
            MatchCollection mc = reg.Matches(result);

            List<string> pandaUserName = new List<string>();

            foreach (Match m in mc)
            {
                pandaUserName.Add(m.Value);
            }

            string huyaresult = HttpFunction.Get(huyaUrl, Encoding.UTF8);
           

            HuyaJson sModel = JsonSerializer.DeserializeFromString<HuyaJson>(huyaresult);


            Regex reghuya = new Regex(@"<i class=""nick"" title=""[\s\S]*?"">", RegexOptions.IgnoreCase);//[^(<td>))] 
            // Regex reghuya = new Regex(@"(^|,)\s*isNotLive\s*(,|$)", RegexOptions.IgnoreCase);
            List<string> huyaUserName = new List<string>();
            MatchCollection huyamc = reghuya.Matches(huyaresult);
            foreach (Match m in huyamc)
            {
                huyaUserName.Add(m.Value.Replace(@"<i class=""nick"" title=""", "").Replace(@""">", ""));
                //huyaUserName.Add(m.Value);
            }

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
            public int page { get; set; }
            public int pageSize { get; set; }
            public int totalPage { get; set; }
            public int totalCount { get; set; }

            public List<HuyadatasJson> datas { get; set; }
        }

        [Serializable]
        public class HuyadatasJson
        {
            public string uid { get; set; }
            public string yyid { get; set; }
            public string screenshot { get; set; }
            public string isBluRay { get; set; }

            public string gameFullName { get; set; }

            public string liveSourceType { get; set; }

            public string gameHostName { get; set; }

            public string screenType { get; set; }

            public string activityId { get; set; }

            public string activityCount { get; set; }

            public string privateHost { get; set; }

            public string level { get; set; }

            public string recommendStatus { get; set; }

            public string nick { get; set; }

            public string totalCount { get; set; }

            public string avatar180 { get; set; }

            public string gid { get; set; }

            public string recommendTagColor { get; set; }

            public string bitRate { get; set; }

            public string recommendTagName { get; set; }

            public string channel { get; set; }

            public string liveChannel { get; set; }

            public string introduction { get; set; }

            public string bussType { get; set; }
        }
    }
}
