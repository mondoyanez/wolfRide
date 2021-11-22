using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wolfRideApp
{
    public class SqlServerDataRepository : IDataRepository
    {
        private string _connectionString = "Server=.;Database=wolfRide;Trusted_Connection=True;Integrated Security=true;";
        public void AddCredential(Credential credential)
        {
            throw new NotImplementedException();
        }

        public void DeleteCreditial(string UserName)
        {
            throw new NotImplementedException();
        }

        public Credential GetCreditial(string UserName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credential> GetPasswords()
        {
            throw new NotImplementedException();
        }
    }
}
