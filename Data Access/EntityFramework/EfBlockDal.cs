using Data_Access.Abstract;
using Data_Access.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.EntityFramework
{
    public class EfBlockDal : GenericRepository<Block>, IBlockDal
    {
        public Block GetLastBlock()
        {
            var result = context.Blocks.OrderByDescending(x => x.BlockId).FirstOrDefault();
            return result;
        }

        public List<Block> GetBlocksWTransactions()
        {
            return context.Blocks.Include("Transactions").ToList();
        }
    }
}
