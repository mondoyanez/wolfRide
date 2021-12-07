using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
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
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();

                // Add credential to credentials database
                var command = new SqlCommand();
                command.Connection = connection;

                var refCredUserName = "0";
                
                var PmtrUserName = new SqlParameter("@userName", SqlDbType.VarChar);
                PmtrUserName.Direction = ParameterDirection.Input;

                var PmtrPassword = new SqlParameter("@password", SqlDbType.VarChar);
                PmtrPassword.Direction = ParameterDirection.Input;

                command.Parameters.Add(PmtrUserName);
                command.Parameters.Add(PmtrPassword);

                PmtrUserName.Value = credential.UserName;
                PmtrPassword.Value = credential.Password;

                command.CommandText = "INSERT INTO Credentials VALUES (@userName, @password)";
                command.ExecuteNonQuery();

                refCredUserName = PmtrUserName.Value.ToString();

                // Check if state entered is already in state database and if not insert it
                var refStateString = "0";

                var PmtrStateName = new SqlParameter("@state", SqlDbType.VarChar);
                PmtrStateName.Direction = ParameterDirection.Input;

                var PmtrStateID = new SqlParameter("@stateID", SqlDbType.Int);
                PmtrStateID.Direction = ParameterDirection.Output;

                command.Parameters.Add(PmtrStateID);
                command.Parameters.Add(PmtrStateName);

                PmtrStateName.Value = credential.State;
                PmtrStateID.Value = refStateString;

                command.CommandText = "SELECT @stateID = StateID FROM [State] WHERE [State] = @state";
                command.ExecuteNonQuery();

                refStateString = PmtrStateID.Value.ToString();

                if (refStateString.Equals(String.Empty))
                {
                    command.CommandText = "INSERT INTO [State] VALUES (@state)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT @stateID = StateID FROM [State] WHERE [State] = @state";
                    command.ExecuteNonQuery();
                    refStateString = PmtrStateID.Value.ToString();
                }

                var refState = Convert.ToInt32(refStateString);

                // Check if Locale already exists and if not insert
                var refLocaleString = "0";

                var PmtrLocaleCity = new SqlParameter("@city", SqlDbType.VarChar);
                PmtrLocaleCity.Direction = ParameterDirection.Input;

                var PmtrLocaleState = new SqlParameter("@localeStateID", SqlDbType.Int);
                PmtrLocaleState.Direction = ParameterDirection.Input;

                var PmtrLocaleLocaleID = new SqlParameter("@localeID", SqlDbType.Int);
                PmtrLocaleLocaleID.Direction = ParameterDirection.Output;

                command.Parameters.Add(PmtrLocaleLocaleID);
                command.Parameters.Add(PmtrLocaleCity);
                command.Parameters.Add(PmtrLocaleState);

                PmtrLocaleLocaleID.Value = refLocaleString;
                PmtrLocaleCity.Value = credential.City;
                PmtrLocaleState.Value = refState;

                command.CommandText = "SELECT @localeID = LocaleID FROM Locale WHERE City = @city";
                command.ExecuteNonQuery();

                refLocaleString = PmtrLocaleLocaleID.Value.ToString();

                if(refLocaleString.Equals(String.Empty))
                {
                    command.CommandText = "INSERT INTO Locale VALUES (@city, @localeStateID)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT @localeID = LocaleID FROM Locale WHERE City = @city";
                    command.ExecuteNonQuery();
                    refLocaleString = PmtrLocaleLocaleID.Value.ToString();
                }

                var refLocale = Convert.ToInt32(refLocaleString);

                // check for zip and if it doesn't exist insert zip into Zip table
                var refZipString = "0";

                var PmtrZipCode = new SqlParameter("@zip", SqlDbType.Int);
                PmtrZipCode.Direction = ParameterDirection.Input;

                var PmtrZipID = new SqlParameter("@zipID", SqlDbType.Int);
                PmtrZipID.Direction = ParameterDirection.Output;

                command.Parameters.Add(PmtrZipID);
                command.Parameters.Add(PmtrZipCode);

                PmtrZipCode.Value = credential.Zip;
                PmtrZipID.Value = refZipString;

                command.CommandText = "SELECT @zipID = ZipID FROM Zip WHERE ZipCode = @zip";
                command.ExecuteNonQuery();

                refZipString = PmtrZipID.Value.ToString();

                if(refZipString.Equals(String.Empty))
                {
                    command.CommandText = "INSERT INTO Zip VALUES(@zip)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT @zipID = ZipID FROM Zip WHERE ZipCode = @zip";
                    command.ExecuteNonQuery();
                    refZipString = PmtrZipID.Value.ToString();
                }

                var refZip = Convert.ToInt32(refZipString);

                // check address and if address does not exist insert address into Address table
                var refAddressString = "0";

                var PmtrLine1 = new SqlParameter("@line1", SqlDbType.VarChar);
                PmtrLine1.Direction = ParameterDirection.Input;

                var PmtrLine2 = new SqlParameter("@line2", SqlDbType.VarChar);
                PmtrLine2.Direction = ParameterDirection.Input;

                var PmtrAddressLocaleID = new SqlParameter("@addressLocaleID", SqlDbType.Int);
                PmtrAddressLocaleID.Direction = ParameterDirection.Input;

                var PmtrAddressZipID = new SqlParameter("@addressZipID", SqlDbType.Int);
                PmtrAddressZipID.Direction = ParameterDirection.Input;

                var PmtrAddressAddressID = new SqlParameter("@addressID", SqlDbType.Int);
                PmtrAddressAddressID.Direction = ParameterDirection.Output;

                command.Parameters.Add(PmtrAddressAddressID);
                command.Parameters.Add(PmtrLine1);
                command.Parameters.Add(PmtrLine2);
                command.Parameters.Add(PmtrAddressLocaleID);
                command.Parameters.Add(PmtrAddressZipID);

                PmtrAddressAddressID.Value = refAddressString;
                PmtrLine1.Value = credential.Line1;
                PmtrLine2.Value = credential.Line2;
                PmtrAddressLocaleID.Value = refLocale;
                PmtrAddressZipID.Value = refZip;

                command.CommandText = "SELECT @addressID = AddressID FROM [Address] WHERE Line1 = @line1 AND Line2 = @line2";
                command.ExecuteNonQuery();

                refAddressString = PmtrAddressAddressID.Value.ToString();

                if (refAddressString.Equals(String.Empty))
                {
                    command.CommandText = "INSERT INTO Address VALUES(@line1, @line2, @addressLocaleID, @addressZipID)";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT @addressID = AddressID FROM [Address] WHERE Line1 = @line1 AND Line2 = @line2";
                    command.ExecuteNonQuery();
                    refAddressString = PmtrAddressAddressID.Value.ToString();
                }

                var refAddress = Convert.ToInt32(refAddressString);

                // check if user exists if they don't exist then add user to User table
                var PmtrUserFullName = new SqlParameter("@fullName", SqlDbType.VarChar);
                PmtrUserFullName.Direction = ParameterDirection.Input;

                var PmtrPhoneNumber = new SqlParameter("@phoneNumber", SqlDbType.VarChar);
                PmtrPhoneNumber.Direction = ParameterDirection.Input;

                var PmtrEmail = new SqlParameter("@email", SqlDbType.VarChar);
                PmtrEmail.Direction = ParameterDirection.Input;

                var PmtrBalance = new SqlParameter("@balance", SqlDbType.Money);
                PmtrBalance.Direction = ParameterDirection.Input;

                var PmtrUserTypeID = new SqlParameter("@userTypeID", SqlDbType.Int);
                PmtrUserTypeID.Direction = ParameterDirection.Input;

                var PmtrUserAddressID = new SqlParameter("@userAddressID", SqlDbType.Int);
                PmtrUserAddressID.Direction = ParameterDirection.Input;

                var PmtrUserCredentialsID = new SqlParameter("@userCredentialsID", SqlDbType.VarChar);
                PmtrUserCredentialsID.Direction = ParameterDirection.Input;

                command.Parameters.Add(PmtrUserFullName);
                command.Parameters.Add(PmtrPhoneNumber);
                command.Parameters.Add(PmtrEmail);
                command.Parameters.Add(PmtrBalance);
                command.Parameters.Add(PmtrUserTypeID);
                command.Parameters.Add(PmtrUserAddressID);
                command.Parameters.Add(PmtrUserCredentialsID);

                PmtrUserFullName.Value = credential.FullName;
                PmtrPhoneNumber.Value = credential.Phone;
                PmtrEmail.Value = credential.Email;
                PmtrBalance.Value = 0;
                PmtrUserTypeID.Value = 1;
                PmtrUserAddressID.Value = refAddress;
                PmtrUserCredentialsID.Value = refCredUserName;

                command.CommandText = "INSERT INTO [User] VALUES(@fullName, @phoneNumber, @email, @balance, @userTypeID, @userAddressID, @userCredentialsID)";
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Credential GetCredential(string username)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);

                connection.Open();

                var sql = "SELECT UserName, [Password] FROM Credentials WHERE UserName = @UserName";

                var usernameParam = new SqlParameter("@UserName", username);

                var command = new SqlCommand(sql, connection);
                command.Parameters.Add(usernameParam);

                var reader = command.ExecuteReader();

                reader.Read();

                var credential = new Credential
                {
                    UserName = Convert.ToString(reader["UserName"]),
                    Password = Convert.ToString(reader["Password"])
                };

                return credential;

            }
            catch (Exception e)
            {
                MessageBox.Show("User does not exist");
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<Credential> GetCredentials()
        {
            var credentials = new List<Credential>();
            try
            {
                var connection = new SqlConnection(_connectionString);

                connection.Open();

                const string sql = "SELECT UserName, [Password] FROM Credentials";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var credential = new Credential
                    {
                        UserName = Convert.ToString(reader["UserName"]),
                        Password = Convert.ToString(reader["Password"])
                    };
                    credentials.Add(credential);
                }

                return credentials;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteCredential(string username)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);

                connection.Open();

                var sql = "DELETE FROM Credentials WHERE UserName = @userName;";

                var command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@userName", username));

                var numberOfRowsAffected = command.ExecuteNonQuery();

                if (numberOfRowsAffected != 1)
                    throw new Exception("Delete didn't work");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Double GetBalance(string username)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            string PmtrBalanceString = "0";
            var PmtrBalance = new SqlParameter("@userBalance", SqlDbType.Money);
            PmtrBalance.Direction = ParameterDirection.Output;

            var PmtrUserName = new SqlParameter("@userName", SqlDbType.VarChar);
            PmtrUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(PmtrBalance);
            command.Parameters.Add(PmtrUserName);

            PmtrBalance.Value = PmtrBalanceString;
            PmtrUserName.Value = username;


            command.CommandText = "SELECT @userBalance = Balance FROM [User] WHERE CredentialsID = @userName";
            command.ExecuteNonQuery();

            PmtrBalanceString = PmtrBalance.Value.ToString();
            double balance = Convert.ToDouble(PmtrBalanceString);

            return balance;
        }

        public void AddFunds(string username, decimal amount)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            var PmtrBalance = new SqlParameter("@newBalance", SqlDbType.Money);
            PmtrBalance.Direction = ParameterDirection.Input;

            var PmtrUserName = new SqlParameter("@userName", SqlDbType.VarChar);
            PmtrUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(PmtrBalance);
            command.Parameters.Add(PmtrUserName);

            PmtrBalance.Value = amount;
            PmtrUserName.Value = username;


            command.CommandText = "UPDATE [User] SET Balance = @newBalance WHERE CredentialsID = @userName";
            command.ExecuteNonQuery();
        }

        public void RequestRide(string username, string destination, int passengers)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            // Get userID from User table
            string pmtrUserIDString = "0";
            var PmtrUserUserID = new SqlParameter("@userUserID", SqlDbType.Int);
            PmtrUserUserID.Direction = ParameterDirection.Output;

            string pmtrUserBalanceString = "0";
            var PmtrUserBalance = new SqlParameter("@userBalance", SqlDbType.Int);
            PmtrUserBalance.Direction = ParameterDirection.Output;

            var PmtrUserCredentialID = new SqlParameter("@userCredentialID", SqlDbType.VarChar);
            PmtrUserCredentialID.Direction = ParameterDirection.Input;

            command.Parameters.Add(PmtrUserUserID);
            command.Parameters.Add(PmtrUserBalance);
            command.Parameters.Add(PmtrUserCredentialID);

            PmtrUserUserID.Value = pmtrUserIDString;
            PmtrUserBalance.Value = pmtrUserBalanceString;
            PmtrUserCredentialID.Value = username;

            command.CommandText = "SELECT @userUserID = UserID, @userBalance = Balance FROM [User] WHERE CredentialsID = @userCredentialID";
            command.ExecuteNonQuery();

            pmtrUserIDString = PmtrUserUserID.Value.ToString();
            var userID = Convert.ToInt32(pmtrUserIDString);

            pmtrUserBalanceString = PmtrUserBalance.Value.ToString();
            var balance = Convert.ToDecimal(pmtrUserBalanceString);

            // add new ride to Ride table

            if (balance >= 5)
            {
                var PmtrPassengers = new SqlParameter("@passengers", SqlDbType.Int);
                PmtrPassengers.Direction = ParameterDirection.Input;

                var PmtrDestination = new SqlParameter("@destination", SqlDbType.VarChar);
                PmtrDestination.Direction = ParameterDirection.Input;

                var PmtrRider = new SqlParameter("@rider", SqlDbType.Int);
                PmtrRider.Direction = ParameterDirection.Input;

                var PmtrDriver = new SqlParameter("@driver", SqlDbType.Int);
                PmtrDriver.Direction = ParameterDirection.Input;

                var PmtrVehicle = new SqlParameter("@vehicle", SqlDbType.Int);
                PmtrVehicle.Direction = ParameterDirection.Input;

                var PmtrRideStatus = new SqlParameter("@rideStatus", SqlDbType.Int);
                PmtrRideStatus.Direction = ParameterDirection.Input;

                command.Parameters.Add(PmtrPassengers);
                command.Parameters.Add(PmtrDestination);
                command.Parameters.Add(PmtrRider);
                command.Parameters.Add(PmtrDriver);
                command.Parameters.Add(PmtrVehicle);
                command.Parameters.Add(PmtrRideStatus);

                PmtrPassengers.Value = passengers;
                PmtrDestination.Value = destination;
                PmtrRider.Value = userID;
                PmtrDriver.Value = 1;
                PmtrVehicle.Value = 1;
                PmtrRideStatus.Value = 1;

                command.CommandText = "INSERT INTO Ride VALUES(@passengers, DATEADD(MINUTE, 30, GETDATE()), DATEADD(MINUTE, 15, GETDATE()), @destination, @rider, @driver, @vehicle, @rideStatus)";
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("NOT ENOUGH FUNDS IN ACCOUNT TO REQUEST FOR A RIDE PLEASE ADD MORE FUNDS TO YOUR ACCOUNT.");
            }
        }

        public void getCurrentRide(string name, DataGridView datagrid)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            var PmtrCredentialID = new SqlParameter("@credentialID", SqlDbType.VarChar);
            PmtrCredentialID.Direction = ParameterDirection.Input;
            
            command.Parameters.Add(PmtrCredentialID);
            PmtrCredentialID.Value = name;

            command.CommandText = "SELECT U.FullName AS 'Driver', M.Make + ' ' + M.Model AS 'Car', PickupTime, EstimatedTimeOfArrival, Destination  FROM Ride AS R " +
                "INNER JOIN [User] AS U ON R.Driver = U.UserID " + "INNER JOIN [User] AS U2 ON R.Rider = U2.UserID " + "INNER JOIN Vehicle AS V ON R.VehicleID = V.VehicleID " + 
                "INNER JOIN MakeModel AS M ON V.MakeModelID = M.MakeModelID " + "WHERE R.RideStatus <> 3 AND U2.CredentialsID = @credentialID";

            var adpt = new SqlDataAdapter(command);
            var dt = new DataTable();
            adpt.Fill(dt);
            datagrid.DataSource = dt;
        }

        public bool isDriver(string username)
        {
            bool driver = false;

            GetCredential(username);

            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            string userUserTypeIDString = "0";
            var PmtrUserTypeID = new SqlParameter("@userTypeID", SqlDbType.Int);
            PmtrUserTypeID.Direction = ParameterDirection.Output;

            var PmtrUserCredentialID = new SqlParameter("@userCredentialID", SqlDbType.VarChar);
            PmtrUserCredentialID.Direction = ParameterDirection.Input;

            command.Parameters.Add(PmtrUserTypeID);
            command.Parameters.Add(PmtrUserCredentialID);

            PmtrUserTypeID.Value = userUserTypeIDString;
            PmtrUserCredentialID.Value = username;

            command.CommandText = "SELECT @userTypeID = UserTypeID FROM [User] WHERE CredentialsID = @userCredentialID";
            command.ExecuteNonQuery();

            userUserTypeIDString = PmtrUserTypeID.Value.ToString();
            var userTypeID = Convert.ToInt32(userUserTypeIDString);

            if (userTypeID > 1)
            {
                driver = true;
            }

            return driver;
        }

        public void RiderWaiting(DataGridView dataGrid)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT U.FullName AS 'Rider', R.NumOfPassengers AS '# of Passengers', Destination FROM Ride AS R " +
                "INNER JOIN [User] AS U ON R.Rider = U.UserID " + "WHERE RideStatus = 1";

            var adpt = new SqlDataAdapter(command);
            var dt = new DataTable();
            adpt.Fill(dt);
            dataGrid.DataSource = dt;
        }

        public void MyRiders(string name, DataGridView datagrid)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand();
            command.Connection = connection;

            var PmtrCredentialID = new SqlParameter("@credentialID", SqlDbType.VarChar);
            PmtrCredentialID.Direction = ParameterDirection.Input;

            command.Parameters.Add(PmtrCredentialID);
            PmtrCredentialID.Value = name;

            command.CommandText = "SELECT U2.FullName AS 'Rider Name', R.NumOfPassengers AS '# of Passengers', R.PickupTime AS 'Pickup Time', " +
                "R.EstimatedTimeOfArrival AS 'Estimated Time of Arrival', R.Destination FROM Ride AS R " + "INNER JOIN [User] AS U1 ON R.Driver = U1.UserID " +
                "INNER JOIN [User] AS U2 ON R.Rider = U2.UserID " + "WHERE U1.CredentialsID = @credentialID";

            var adpt = new SqlDataAdapter(command);
            var dt = new DataTable();
            adpt.Fill(dt);
            datagrid.DataSource = dt;
        }
    }
}
