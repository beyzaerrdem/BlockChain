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

        public List<RandomWord> GetRandomWords(int count)
        {
            return _randomWordDal.GetRandomWords(count);
        }

        public List<RandomWord> GetAll()
        {
            return _randomWordDal.GetAll();
        }

        public RandomWord GetById(int id)
        {
            return _randomWordDal.Get(x => x.Id == id);
        }

        public void Update(RandomWord randomWord)
        {
            _randomWordDal.Update(randomWord);
        }
    }
}
