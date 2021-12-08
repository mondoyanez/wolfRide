using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

        Double GetBalance(string username);

        void AddFunds(string username, decimal amount);

        void RequestRide(string username, string destination, int passengers);

        void getCurrentRide(string username, DataGridView datagrid);

        bool isDriver(string username);

        void RiderWaiting(DataGridView dataGrid);

        void MyRiders(string name, DataGridView datagrid);

        void DriverApply(string name);

        void ContactAdmin(string name, string message);

        bool isAdmin(string name);

        void ViewDriverRequests(DataGridView datagrid);

        void ViewDrivers(DataGridView datagrid);

        void ViewPassengers(DataGridView datagrid);

        void ViewVehicles(DataGridView datagrid);

        void ViewAllUsers(DataGridView datagrid);

        void ViewAdmins(DataGridView datagrid);

        void ViewMessages(DataGridView datagrid);

        void ViewTerminationRequests(DataGridView datagrid);

        IEnumerable<Credential> GetCredentials();

        void DeleteCredential(string username);
    }
}
