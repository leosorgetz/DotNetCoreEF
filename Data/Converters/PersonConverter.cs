using System.Collections.Generic;
using System.Linq;
using DotNetCoreEF.Data.Converter;
using DotNetCoreEF.Data.VO;
using DotNetCoreEF.Model;

namespace DotNetCoreEF.Data.Converters
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };

        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();

            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}