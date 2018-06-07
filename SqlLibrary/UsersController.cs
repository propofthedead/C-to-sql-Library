using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary
{
    public class UsersController
    {
		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();


		public IEnumerable<User> List() {
			string sql = "Select * from [User];";
			cmd.Connection = conn;
			cmd.CommandText = sql;
			List<User> users = new List<User>();
			SqlDataReader reader=	cmd.ExecuteReader();
			while (reader.Read()) {
				User user = new User(reader);
				users.Add(user);
			}

			return users;
		}
		public User Get(int id) {
			return null;
		}
		public bool Create(User user) {
			return false;
		}
		public bool Change(User user) {
			return false;
		}
		public bool Remove(User user) {
			return false;
		}

		private SqlConnection CreateAndOpenConection(string server, string database) {
			string connStr = $"server={server}; database={database};Trusted_connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql connection did not open");
			}
			return conn;
		}
		public void CloseConnection() {
			if (conn !=null &&conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
				conn = null;
			}
		}
		public UsersController() {

		}
		public UsersController(string server, string database) {
			this.conn=	CreateAndOpenConection(server, database);
		}
    }
}
