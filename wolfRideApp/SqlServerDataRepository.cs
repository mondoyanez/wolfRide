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
    }
}
