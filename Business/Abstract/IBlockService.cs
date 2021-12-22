using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlockService
    {
        List<Block> GetAll();
        Block GetById(int id);
        void Add(Block block);
        void Update(Block block);
        void Delete(Block block);
    }
}
