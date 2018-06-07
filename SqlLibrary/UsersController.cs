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
		public IEnumerable<User> List() {
			return new List<User>();
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
			string connStr = $"server={server};database={database};";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql connection did not open");
			}
			return conn;
		}
		private void CloseConnection(SqlConnection conn) {
			if (conn !=null &&conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
			}
		}
		public UsersController() {

		}
		public UsersController(string server, string database) {
			SqlConnection conn=	CreateAndOpenConection(server, database);
		}
    }
}
