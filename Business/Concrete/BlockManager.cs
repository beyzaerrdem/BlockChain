using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlockManager : IBlockService
    {
        IBlockDal _blockDal;

        public BlockManager(IBlockDal blockDal)
        {
            _blockDal = blockDal;
        }

        public void Add(Block block)
        {
            _blockDal.Add(block);
        }

        public void Delete(Block block)
        {
            _blockDal.Delete(block);
        }

        public List<Block> GetAll()
        {
            return _blockDal.GetBlocksWTransactions();
        }

        public Block GetById(int id)
        {
            return _blockDal.Get(b => b.BlockId == id);
        }

        public Block GetLastBlock()
        {
            return _blockDal.GetLastBlock();
        }

        public void Update(Block block)
        {
            _blockDal.Update(block);
        }
    }
}
