using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRandomWordService
    {
        List<RandomWord> GetAll();
        List<RandomWord> GetRandomWords(int count);
        RandomWord GetById(int id);
        void Add(RandomWord randomWord);
        void Update(RandomWord randomWord);
        void Delete(RandomWord randomWord);
    }
}
