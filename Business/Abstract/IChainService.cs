using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IChainService
    {
        List<Transaction> GetAllTransactions();
        List<Block> GetAllBlocks();
        List<PostDto> GetAllPostDtos();
        string GetLastBlockHash();
        void Add(Block block);
    }
}
