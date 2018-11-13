using System.Collections.Generic;
using ApiTesteDotNet.Model;

namespace ApiTesteDotNet.Business
{
    public interface IPersonBusiness
    {
         Person Create(Person person);
         Person FindById(long id);
         List<Person> FindAll();
         Person Update(Person person);
         void Delete(long id);
    }
}