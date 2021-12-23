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
    public class EfTransactionDal : GenericRepository<Transaction>, ITransactionDal
    {
    }
}
