using System;
using System.Collections.Generic;
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

                var sql = "INSERT INTO Credentials (UserName, [Password]) VALUES (@usernName, @password);";
                var refCredentials = "SELECT UserName FROM Credentials WHERE UserName = @userName";
                var command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@userName", credential.UserName));
                command.Parameters.Add(new SqlParameter("@password", credential.Password));
                var numberOfRowsReturned = command.ExecuteNonQuery();

                if (numberOfRowsReturned != 1)
                    throw new Exception("Insert didn't work");


                var refState = "SELECT StateID FROM [State] WHERE [State] = @state";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@state", credential.State));

                if (refState.Equals(string.Empty))
                {
                    sql = "INSERT INTO [State] VALUES (@state);";
                    refState = "SELECT StateID FROM [State] WHERE [State] = @state";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@state", credential.State));
                }

                var refLocale = "SELECT LocaleID FROM Locale WHERE City = @city";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@city", credential.City));

                if (refLocale.Equals(string.Empty))
                {
                    sql = "INSERT INTO Locale VALUES (@city, @stateID);";
                    refState = "SELECT LocaleID FROM Locale WHERE City = @city";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@city", credential.City));
                    command.Parameters.Add(new SqlParameter("@stateID", refState));
                }

                var refZip = "SELECT ZipID FROM Zip WHERE ZipCode = @zip";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@zip", credential.Zip));

                if (refZip.Equals(string.Empty))
                {
                    sql = "INSERT INTO Zip VALUES (@zip);";
                    refZip = "SELECT ZipID FROM Zip WHERE ZipCode = @zip";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@zip", credential.Zip));
                }

                var refAddress = "SELECT AddressID FROM Address WHERE Line1 = @line1";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@line1", credential.Line1));

                if (refAddress.Equals(string.Empty))
                {
                    sql = "INSERT INTO Address VALUES (@line1, @line2, @localeID, @zipID);";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@line1", credential.Line1));
                    command.Parameters.Add(new SqlParameter("@line2", credential.Line2));
                    command.Parameters.Add(new SqlParameter("@localeID", refLocale));
                    command.Parameters.Add(new SqlParameter("@zipID", refZip));
                    refZip = "SELECT AddressID FROM Address WHERE Line1 = @line1";
                }


                sql = "INSERT INTO User VALUES (@fullName, @phoneNumber, @email, @balance, @userTypeID, @AddressID, @credentialsID);";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@fullName", credential.FullName));
                command.Parameters.Add(new SqlParameter("@phoneNumber", credential.Phone));
                command.Parameters.Add(new SqlParameter("@email", credential.Email));
                command.Parameters.Add(new SqlParameter("@balance", 0));
                command.Parameters.Add(new SqlParameter("@userTypeID", 1));
                command.Parameters.Add(new SqlParameter("@AddressID", refAddress));
                command.Parameters.Add(new SqlParameter("@credentialsID", refCredentials));

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
    }
}
