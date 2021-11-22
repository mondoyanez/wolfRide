using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wolfRideApp
{
    public interface IDataRepository
    {
        void AddCredential(Credential credential);

        Credential GetCreditial(string UserName);

        IEnumerable<Credential> GetPasswords();

        void DeleteCreditial(string UserName);
    }
}
