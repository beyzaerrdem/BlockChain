using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;

namespace Business.Utilities.Helpers
{
    public class NodeJsAPIHelper
    {
        public static void CreatePost(string privateKey,string post)
        {
            var t = APIHelper.PostMethod<Transaction>(new { postOwner = privateKey, post = post}, "http://localhost:8081/api/post/addpost");

        }

        public static byte[] Hash(object obj)
        {
            var result = APIHelper.GetMethod<string>("http://localhost:8081/api/hash/createhash");
            byte[] StringToByteArray(string hex)
            {
                return Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
            }
            return StringToByteArray(result);
        }
        //public static string CreateKey()
        //{

        //}
    }
}