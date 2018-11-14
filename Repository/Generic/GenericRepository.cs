using System.Collections.Generic;
using System;
using DotNetCoreEF.Model.Base;
using DotNetCoreEF.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCoreEF.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }


        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(i => i.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            return result;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));

            try
            {
                if (result != null) dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Exists(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}