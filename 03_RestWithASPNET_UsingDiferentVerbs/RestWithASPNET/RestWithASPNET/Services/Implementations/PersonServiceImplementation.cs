using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private volatile int count;

    public Person Create(Person person)
    {
      return person;
    }

    public void Delete(long id)
    {

    }

    public List<Person> FindAll()
    {
      List<Person> people = new List<Person>();

      for (int i = 0; i < 8; i++)
      {
        Person person = MockPerson(i);
        people.Add(person);
      }

      return people;
    }

    public Person FindById(long id)
    {
      return new Person
      {
        Id = IncrementAndGet(),
        FirstName = "Leandro",
        LastName = "Costa",
        Address = "Uberlândia - Minas Gerais - Brasil",
        Gender = "Male"
      };
    }

    public Person Update(Person person)
    {
      return person;
    }

    private Person MockPerson(int i)
    {
      return new Person
      {
        Id = IncrementAndGet(),
        FirstName = "Person FirstName" + i,
        LastName = "Person LastName" + i,
        Address = "Some Address" + i,
        Gender = "Male"
      };
    }

    private long IncrementAndGet()
    {
      return Interlocked.Increment(ref count);
    }
  }
}
