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

                //var stateSql = "INSERT INTO [State] VALUES (@state);";
                //var command = new SqlCommand(stateSql, connection);
                //command.Parameters.Add(new SqlParameter("@state", credential.);

                var credSql = "INSERT INTO Credentials (UserName, [Password]) VALUES (@usernName, @password);";
                var command = new SqlCommand(credSql, connection);
                command.Parameters.Add(new SqlParameter("@userName", credential.UserName));
                command.Parameters.Add(new SqlParameter("@password", credential.Password));

                var numberOfRowsReturned = command.ExecuteNonQuery();

                if (numberOfRowsReturned != 1)
                    throw new Exception("Insert didn't work");

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
