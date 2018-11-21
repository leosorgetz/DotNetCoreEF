using System.Collections.Generic;
using DotNetCoreEF.Data.VO;
using DotNetCoreEF.Model;
namespace DotNetCoreEF.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}