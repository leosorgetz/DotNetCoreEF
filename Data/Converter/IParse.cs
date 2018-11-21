
using System.Collections.Generic;

namespace DotNetCoreEF.Data.Converter
{
    public interface IParse<O, D>
    {
        D Parse(O Origin);
        List<D> ParseList(List<O> origin);
    }
}