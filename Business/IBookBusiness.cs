using System.Collections.Generic;
using DotNetCoreEF.Model;

namespace DotNetCoreEF.Business
{
    public interface IBookBusiness
    {
        Book Create(Book Book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
    }
}