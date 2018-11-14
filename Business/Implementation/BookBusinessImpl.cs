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
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {

            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}