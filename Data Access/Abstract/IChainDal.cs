using System.Collections.Generic;
using Entities.Dto;

namespace Data_Access.Abstract
{
    public interface IChainDal
    {
        List<PostDto> GetAllPostDtos();
    }
}