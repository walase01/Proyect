using ProyectTecni.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectTecni.Services
{
    public interface IDatabaseService
    {
        Task<List<Person>> GetListPeople();
        Task<int> InsertAddress(Address address);

        Task<List<Address>> GetAddresses();

        Task<int> InsertPeople(Person person);
    }
}
