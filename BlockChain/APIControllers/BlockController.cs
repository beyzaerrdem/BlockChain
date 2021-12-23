
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
        private static List<Block> blocks = new List<Block>(){new Block(){Hash = "00000000000000000000",BlockId = 0}};
        private static List<Transaction> transactions = new List<Transaction>(){new Transaction(){TransactionId = 0}};
        [HttpPost]
        public JsonResult<string> NewBlock(Block block)
        {
            block.BlockId = blocks[blocks.Count - 1].BlockId + 1;
            foreach (var transaction in block.Transactions)
            {
                transaction.BlockId = block.BlockId;
                transaction.TransactionId = transactions[transactions.Count - 1].TransactionId + 1;
                transactions.Add(transaction);
            }
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
