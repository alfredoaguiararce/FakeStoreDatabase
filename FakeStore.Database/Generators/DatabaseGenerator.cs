using FakeStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Database.Generators
{
    internal class DatabaseGenerator: IFakeStoreDatabase
    {
        private readonly FakeDatabaseConfigurator _Configurator;

        public DatabaseGenerator(FakeDatabaseConfigurator configurator)
        {
            _Configurator = configurator;
        }

        public List<FakeUser> GetUsers() 
        {
            int MaxDefaultUsers = _Configurator.MaxDefaultUsers;
            List<FakeUser> Users = new List<FakeUser>();

            return Users;
        }

    }

    public interface IFakeStoreDatabase
    {

    }
}
