
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Entities.Concrete;

namespace BlockChain.APIControllers
{
    public class BlockController : ApiController
    {
        private static List<Block> blocks = new List<Block>(){new Block(){Hash = "00000000000000000000"}};
        [HttpPost]
        public JsonResult<string> NewBlock(Block block)
        {
            blocks.Add(block);
            return Json("tmm");
        }

        [HttpGet]
        public JsonResult<string> GetLastBlockHash()
        {
            var result = blocks[blocks.Count - 1].Hash;
            return Json(result);
        }
    }
}
