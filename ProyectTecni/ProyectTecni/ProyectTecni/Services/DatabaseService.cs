using ProyectTecni.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectTecni.Services
{
    public class DatabaseService : IDatabaseService
    {

        private bool _initialized = false;
        private static SQLiteAsyncConnection db;

        public List<Address> ListAddress { get; set; }
        public List<Person> ListPerson { get; set; }

        public DatabaseService()
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                if (!_initialized)
                {
                    _initialized = true;

                    if (db != null)
                    {
                        return;
                    }

                    var databaseperson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "person.db");
                    db = new SQLiteAsyncConnection(databaseperson);

                    await db.CreateTableAsync<Address>();
                    await db.CreateTableAsync<Person>();

                    ListAddress = await db.Table<Address>().ToListAsync();
                    ListPerson = await db.Table<Person>().ToListAsync();
                }


            }
            catch (Exception ex)
            {

            }
        }


        public async Task<List<Person>> GetListPeople()
        {
            return await db.Table<Person>().ToListAsync();
        }

        //public async Task<List<T>> GetListPersonAndAddress()
        //{
        //    return await db.QueryAsync<T>
        //}
        

        public async Task<int> InsertAddress(Address address)
        {
            try
            {
                int result = await db.InsertAsync(address);
                ListAddress = await db.Table<Address>().ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertPeople(Person person)
        {
            try
            {
                int result = await db.InsertAsync(person);
                ListPerson = await db.Table<Person>().ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Address>> GetAddresses()
        {
            return await db.Table<Address>().ToListAsync();
        }
    }
}
