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
    public class RandomWordManager : IRandomWordService
    {
        IRandomWordDal _randomWordDal;

        public RandomWordManager(IRandomWordDal randomWordDal)
        {
            _randomWordDal = randomWordDal;
        }

        public void Add(RandomWord randomWord)
        {
            _randomWordDal.Add(randomWord);
        }

        public void Delete(RandomWord randomWord)
        {
            _randomWordDal.Delete(randomWord);
        }

        public List<RandomWord> GetAll()
        {
            throw new NotImplementedException();
        }

        public RandomWord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RandomWord randomWord)
        {
            throw new NotImplementedException();
        }
    }
}
