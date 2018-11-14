using System.ComponentModel.DataAnnotations.Schema;
using DotNetCoreEF.Model.Base;

namespace DotNetCoreEF.Model
{
    [Table("persons")]
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}