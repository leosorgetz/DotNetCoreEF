using System;
using System.Collections.Generic;
using System.Linq;
using ApiTesteDotNet.Business;
using ApiTesteDotNet.Model;
using ApiTesteDotNet.Model.Context;
using ApiTesteDotNet.Repository;

namespace ApiTesteDotNet.Repository.Implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if(result!= null) _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if(!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return person;
        }

        public bool Exist(long? id)
        {
           return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}