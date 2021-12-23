using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Business.Utilities.Helpers
{
    public class NodeJsAPIHelper
    {
        private static byte[] GetStringToBytes(string value)
        {
            var shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }

        private static string GetBytesToString(byte[] value)
        {
            var shb = new SoapHexBinary(value);
            return shb.ToString();
        }

        public static void CreatePost(string privateKey,string post)
        {
            var t = APIHelper.PostMethod<Transaction>(new { postOwner = privateKey, post = post}, "http://localhost:8081/api/post/addpost");
        }

        public static byte[] Hash(object obj)
        {

            var result = APIHelper.GetMethod<string>("http://localhost:8081/api/hash/createhash");
            return GetStringToBytes(result);
        }
        //public static string CreateKey()
        //{

        //}
    }
}