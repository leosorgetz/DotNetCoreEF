using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DotNetCoreEF.Model;
using DotNetCoreEF.Model.Context;
using DotNetCoreEF.Repository;
using DotNetCoreEF.Repository.Generic;

namespace DotNetCoreEF.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {

            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}