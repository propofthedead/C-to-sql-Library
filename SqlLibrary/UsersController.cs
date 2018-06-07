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

		private void SetupCommand(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}
		public IEnumerable<User> List() {
			string sql = "Select * from [User];";
			SetupCommand(conn, sql);
			List<User> users = new List<User>();
			SqlDataReader reader=	cmd.ExecuteReader();
			while (reader.Read()) {
				User user = new User(reader);
				users.Add(user);
			}
			reader.Close();
			return users;
		}
		public User Get(int id) {
			string sql = "select * from [User] where Id=@id ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == false) {
				reader.Close();
				return null;
			}
			reader.Read();
			User targetUser = new User(reader);
			reader.Close();
			return targetUser;
		}
		public bool Create(User user) {
			string sql = "INSERT into [User] " +
					" ( Username, Password, Firstname, Lastname, phone, email, IsReviewer, IsAdmin) " +
					" VALUES" +
					" ( @Username, @Password, @Firstname, @Lastname, @phone, @email, @IsReviewer, @IsAdmin) ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.Firstname));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			int recsaffected = cmd.ExecuteNonQuery();
			return (recsaffected==1);
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
