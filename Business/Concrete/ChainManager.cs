using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ChainManager : IChainService
    {
        private IBlockService _blockService;
        private ITransactionService _transactionService;

        public ChainManager(IBlockService blockService, ITransactionService transactionService)
        {
            _blockService = blockService;
            _transactionService = transactionService;
        }

        public void Add(Block block)
        {
            _blockService.Add(block);
        }

        public List<Block> GetAllBlocks()
        {
            return _blockService.GetAll();
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionService.GetAll();
        }

        public string GetLastBlockHash()
        {
            var lastBlock = _blockService.GetLastBlock();
            return lastBlock == null ? "0000" : lastBlock.Hash;
        }
    }
}
