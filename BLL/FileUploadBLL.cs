using BaseClasses;
using Enyim.Caching.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class FileUploadBLL
    {
        private static string _uploadFileUrl = string.Empty;
        static FileUploadBLL()
        {
            _uploadFileUrl = BaseClasses.ConfigurationHelper.GetAppSetting<string>("UploadFile", "http://upload.5211game.com/upload.ashx");
            //_uploadFileUrl = "http://localhost:62187/Upload.ashx";
        }

        /// <summary>
        /// 普通上传文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static RetInfo<string> PostFile(Stream stream, Dictionary<string, string> param)
        {
            try
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                var result = HttpFunction.PostFile(_uploadFileUrl, bytes, param);
                var ret = JsonSerializer.DeserializeFromString<RetInfo<string>>(result);
                return ret;
            }
            catch
            {
                throw new Exception("上传文件失败");
            }
        }
    }
}
