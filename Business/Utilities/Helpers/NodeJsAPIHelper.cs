using System.Collections.Generic;
using System.Linq;
using Entities.Concrete;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Entities.Dto;

namespace Business.Utilities.Helpers
{
    public class NodeJsAPIHelper
    {
        private class ApiUrlHelper
        {
            private const string ApiUrl = "http://localhost:8081/";
            private const string ApiPrefix = "api/";
            public static string GetUrl(string path) => ApiUrl + ApiPrefix + path;

            public static string GetUrl(string path, Dictionary<string, string> parameters)
            {
                var baseUrl = GetUrl(path) + '?';
                baseUrl = parameters.Aggregate(baseUrl, (current, parameter) => current + $"{parameter.Key}={parameter.Value}&");
                return baseUrl;
            }
        }

        

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
            var t = APIHelper.PostMethod<Transaction>(new { postOwner = privateKey, post = post}, ApiUrlHelper.GetUrl("post/addpost"));
        }

        public static byte[] Hash(object obj)
        {
            var result = APIHelper.PostMethod<string>(obj,ApiUrlHelper.GetUrl("hash/createhash"));
            return GetStringToBytes(result);
        }

        public static KeyDto CreateKey(object obj)
        {
            return APIHelper.PostMethod<KeyDto>(obj, ApiUrlHelper.GetUrl("key/createkey"));
        }

        public static string PrivateKeyToPublicKey(string privateKey)
        {
            return APIHelper.PostMethod<string>(privateKey, ApiUrlHelper.GetUrl("key/PrivateKeyToPublicKey"));
        }
    }

    
}