using System.Collections.Generic;
using DotNetCoreEF.Data.VO;
using DotNetCoreEF.Model;

namespace DotNetCoreEF.Business
{
    public interface IPersonBusiness
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}