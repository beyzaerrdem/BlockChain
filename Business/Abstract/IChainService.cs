using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IChainService
    {
        List<Transaction> GetAllTransactions();
        List<Block> GetAllBlocks();
        string GetLastBlockHash();
        void Add(Block block);
    }
}
