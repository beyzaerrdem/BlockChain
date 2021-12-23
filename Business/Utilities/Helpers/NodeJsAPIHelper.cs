using System;
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

            return null;
        }
        //public static string CreateKey()
        //{

        //}
    }
}