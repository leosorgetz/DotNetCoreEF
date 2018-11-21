using System.Collections.Generic;
using DotNetCoreEF.Data.VO;
using DotNetCoreEF.Model;

namespace DotNetCoreEF.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}