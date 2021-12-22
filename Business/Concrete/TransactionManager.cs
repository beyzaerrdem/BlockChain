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
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public void Add(Transaction transaction)
        {
            _transactionDal.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactionDal.Delete(transaction);
        }

        public List<Transaction> GetAll()
        {
            return _transactionDal.GetAll();
        }

        public Transaction GetById(int id)
        {
            return _transactionDal.Get(t => t.TransactionId == id);
        }

        public void Update(Transaction transaction)
        {
            _transactionDal.Update(transaction);
        }
    }
}
