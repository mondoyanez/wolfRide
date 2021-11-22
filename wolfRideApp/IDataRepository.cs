using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wolfRideApp
{
    public interface IDataRepository
    {
        void AddCredential(Credential credential);

        Credential GetCredential(string username);

        IEnumerable<Credential> GetCredentials();

        void DeleteCredential(string username);
    }
}
