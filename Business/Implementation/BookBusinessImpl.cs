using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DotNetCoreEF.Data.Converters;
using DotNetCoreEF.Data.VO;
using DotNetCoreEF.Model;
using DotNetCoreEF.Model.Context;
using DotNetCoreEF.Repository;
using DotNetCoreEF.Repository.Generic;

namespace DotNetCoreEF.Business.Implementation
{
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}