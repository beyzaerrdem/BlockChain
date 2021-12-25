using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Data_Access.Abstract;
using Entities.Dto;

namespace Business.Concrete
{
    public class ChainManager : IChainService
    {
        private IChainDal _chainDal;
        private IBlockService _blockService;
        private ITransactionService _transactionService;

        public ChainManager(IBlockService blockService, ITransactionService transactionService, IChainDal chainDal)
        {
            _blockService = blockService;
            _transactionService = transactionService;
            _chainDal = chainDal;
        }

        public void Add(Block block)
        {
            _blockService.Add(block);
        }

        public List<Block> GetAllBlocks()
        {
            return _blockService.GetAll();
        }

        public List<PostDto> GetAllPostDtos()
        {
            return _chainDal.GetAllPostDtos();
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
