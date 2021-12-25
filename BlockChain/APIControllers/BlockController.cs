
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Business.Abstract;
using Business.Concrete;
using Data_Access.EntityFramework;
using Entities.Concrete;

namespace BlockChain.APIControllers
{
    public class BlockController : ApiController
    {
        private IChainService _chainService = new ChainManager
            (
                new BlockManager(new EfBlockDal()),
                new TransactionManager(new EfTransactionDal()),new EfChainDal()
            );

        [HttpPost]
        public void NewBlock(Block block)
        {
            _chainService.Add(block);
        }

        [HttpGet]
        public JsonResult<string> GetLastBlockHash()
        {
            var result = _chainService.GetLastBlockHash();
            return Json(result);
        }
    }
}
