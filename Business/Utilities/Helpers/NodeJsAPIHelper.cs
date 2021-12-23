using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Entities.Dto;

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
            var result = APIHelper.PostMethod<string>(obj,"http://localhost:8081/api/hash/createhash");
            return GetStringToBytes(result);
        }

        public static KeyDto CreateKey(List<RandomWord> randomWords)
        {
            return APIHelper.PostMethod<KeyDto>(randomWords, "http://localhost:8081/api/key/createkey");
        }

        public static string PrivateKeyToPublicKey(string privateKey)
        {
            return APIHelper.PostMethod<string>(privateKey, "http://localhost:8081/api/key/PrivateKeyToPublicKey");
        }
    }
}